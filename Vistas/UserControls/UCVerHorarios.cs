using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCVerHorarios : UserControl
    {
        private int? profesionalInicialId = null;

        public UCVerHorarios(int? profesionalId = null)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            profesionalInicialId = profesionalId;

        }

        private void UCVerHorarios_Load(object sender, EventArgs e)
        {
            CargarProfesionales();

            if (profesionalInicialId.HasValue)
            {
                cboProfesional.SelectedValue = profesionalInicialId.Value;
                MostrarDisponibilidad(profesionalInicialId.Value);
            }

        }

        private void MostrarDisponibilidad(int profesionalId)
        {
            dgvHorarios.Rows.Clear();

            var horarios = new HorarioDAO().ObtenerHorariosPorProfesional(profesionalId);
            var diasSemana = new[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };

            foreach (var dia in diasSemana)
            {
                var franjas = horarios
                    .Where(h => h.DiaSemana == dia)
                    .OrderBy(h => h.HoraDesde)
                    .ToList();

                if (franjas.Count == 0)
                {
                    int filaIndex = dgvHorarios.Rows.Add();
                    var fila = dgvHorarios.Rows[filaIndex];

                    fila.Cells["Dia"].Value = dia;
                    fila.Cells["Trabaja"].Value = "❌";
                    fila.Cells["Horario"].Value = "-";
                    fila.Cells["Turnos"].Value = "-";
                    fila.Cells["IdHorario"].Value = 0; // ⚠️ Opcional, para evitar errores si luego querés agregar desde esta fila
                }
                else
                {
                    // Una fila por cada franja
                    foreach (var franja in franjas)
                    {
                        var rango = franja.HoraHasta - franja.HoraDesde;
                        int cantidadTurnos = (int)Math.Floor(rango.TotalMinutes / franja.DuracionMinutos);

                        int filaIndex = dgvHorarios.Rows.Add();
                        var fila = dgvHorarios.Rows[filaIndex];

                        fila.Cells["Dia"].Value = franja.DiaSemana;
                        fila.Cells["Trabaja"].Value = "✅";
                        fila.Cells["Horario"].Value = $"{franja.HoraDesde:hh\\:mm}–{franja.HoraHasta:hh\\:mm}";
                        fila.Cells["Turnos"].Value = $"{cantidadTurnos} turnos";
                        fila.Cells["IdHorario"].Value = franja.IdHorario;
                    }
                }
            }
            dgvHorarios.ClearSelection();
        }

        private void CargarProfesionales()
        {

            var lista = new ProfesionalDAO().ObtenerProfesionales(); 

            lista.Insert(0, new Profesional
            {
                Id = 0,
                
                NombreEspecialidad = "- Seleccionar profesional - -"
            });

            cboProfesional.DisplayMember = "Mostrar";
            cboProfesional.ValueMember = "Id";
            cboProfesional.DataSource = lista;
        }


        private void dgvHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHorarios.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                string diaSeleccionado = dgvHorarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                int profesionalId = (int)cboProfesional.SelectedValue;
                int idHorario = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["IdHorario"].Value);
               
                var profesional = ((List<Profesional>)cboProfesional.DataSource).FirstOrDefault(p => p.Id == profesionalId);

                string nombreProfesional = profesional?.Mostrar ?? "Desconocido";

                var horario = new HorarioDAO().ObtenerHorariosPorProfesional(profesionalId)
                .FirstOrDefault(h => h.IdHorario == idHorario);

                if (horario == null)
                {
                    MessageBox.Show("No se encontró el horario seleccionado.");
                    return;
                }

                var ucEditar = new UCEditarHorario();
                ucEditar.CargarDatos(
                    idHorario,
                    profesionalId,
                    nombreProfesional,
                    diaSeleccionado,
                    horario.HoraDesde,
                    horario.HoraHasta,
                    horario.DuracionMinutos
                );

                var parent = this.Parent;
                parent.Controls.Clear();
                parent.Controls.Add(ucEditar);
            }

            if (dgvHorarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                string diaSeleccionado = dgvHorarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                string horario = dgvHorarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                int profesionalId = (int)cboProfesional.SelectedValue;
                int idHorario = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells["IdHorario"].Value);

                DialogResult confirm = MessageBox.Show(
                $"¿Está seguro que desea eliminar el horario del día {diaSeleccionado} en el horario {horario}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = new HorarioDAO().EliminarHorario(idHorario);

                    if (eliminado)
                    {
                        MessageBox.Show("Horario eliminado correctamente.");
                        MostrarDisponibilidad(profesionalId);
                    }
                    else
                    {
                        MessageBox.Show("❌ No se pudo eliminar el horario.");
                    }
                }
            }
        }

       
        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cboProfesional.SelectedValue?.ToString(), out int profesionalId))
            {
                if (profesionalId == 0)
                {
                    dgvHorarios.Rows.Clear();
                    return;
                }

                MostrarDisponibilidad(profesionalId);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void dgvHorarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHorarios.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                e.CellStyle.BackColor = Color.LightSeaGreen;
                e.CellStyle.ForeColor = Color.White;
                e.FormattingApplied = true;
            }

            if (dgvHorarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                e.CellStyle.BackColor = Color.Firebrick;
                e.CellStyle.ForeColor = Color.White;
                e.FormattingApplied = true;

            }
        }
    }
}

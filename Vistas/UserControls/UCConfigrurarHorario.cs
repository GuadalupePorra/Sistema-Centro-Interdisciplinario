using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SCI
{
    public partial class UCConfigrurarHorario : UserControl, IFormularioConCambios
    {
        private readonly TimeSpan HORA_INICIO_DEFAULT = new TimeSpan(10, 0, 0);
        private readonly TimeSpan HORA_FIN_DEFAULT = new TimeSpan(10, 0, 0); // si querés también hora fin

        private int profesionalSeleccionadoId = -1;
        private ProfesionalDAO profesionalDAO = new ProfesionalDAO();
        private bool profesionalConfirmado = false;
        private bool cambios = false;

        public UCConfigrurarHorario()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            CargarProfesionales();

        }
        
        public bool TieneCambiosSinGuardar()
        {
            return cambios;
        }

        private void CargarProfesionales()
        {

            var lista = new ProfesionalDAO().ObtenerProfesionales(); // deberías tener esta función

            lista.Insert(0, new Profesional
            {
                Id = 0,

                NombreEspecialidad = "- Seleccionar profesional - -"
            });

            cboProfesional.DisplayMember = "Mostrar";
            cboProfesional.ValueMember = "Id";
            cboProfesional.DataSource = lista;
        }


        private void LimpiarCamposAgenda(bool limpiarProfesional)
        {
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;

            dtpHoraInicio.Value = DateTime.Today + HORA_INICIO_DEFAULT;
            dtpHoraFin.Value = DateTime.Today + HORA_FIN_DEFAULT;
            if (limpiarProfesional)
            {
                profesionalSeleccionadoId = -1;
                profesionalConfirmado = false;
                cboProfesional.Enabled = true;
                cboProfesional.SelectedIndex = 0;

            }
            btnAgregar.Text = "Agregar horarios";
        }

        private bool ValidarHorarioYDuracion(TimeSpan horaInicio, TimeSpan horaFin, int duracionMinutos, out int cantidadTurnos)
        {
            cantidadTurnos = 0;

            if (horaInicio >= horaFin)
            {
                MessageBox.Show("La hora de inicio debe ser menor que la hora de fin.");
                return false;
            }

            var diferencia = horaFin - horaInicio;
            cantidadTurnos = (int)(diferencia.TotalMinutes / duracionMinutos);

            if (cantidadTurnos < 2)
            {
                MessageBox.Show("El rango horario debe permitir al menos dos turnos con la duración ingresada.");
                return false;
            }

            // Validación exitosa: informamos cuántos turnos se generarían
            MessageBox.Show($"Este rango permite {cantidadTurnos} turnos de {duracionMinutos} minutos.", "Validación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (profesionalSeleccionadoId == -1)
            {
                MessageBox.Show("Debes seleccionar un profesional.");
                return;
            }

            List<string> diasSeleccionados = new List<string>();
            if (chkLunes.Checked) diasSeleccionados.Add("Lunes");
            if (chkMartes.Checked) diasSeleccionados.Add("Martes");
            if (chkMiercoles.Checked) diasSeleccionados.Add("Miércoles");
            if (chkJueves.Checked) diasSeleccionados.Add("Jueves");
            if (chkViernes.Checked) diasSeleccionados.Add("Viernes");
            

            if (diasSeleccionados.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un día.");
                return;
            }

            var horaInicio = dtpHoraInicio.Value.TimeOfDay;
            var horaFin = dtpHoraFin.Value.TimeOfDay;
            var duracion = (int)numDuracionTurno.Value;

            if (!ValidarHorarioYDuracion(horaInicio, horaFin, duracion, out int cantidadTurnos))
            {
                return;
            }

            foreach (string dia in diasSeleccionados)
            {
                dgvHorarios.Rows.Add(dia, horaInicio, horaFin, duracion);
            }

            DialogResult result = MessageBox.Show(
            "¿Desea seguir configurando la agenda de este profesional?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Mantener al profesional seleccionado, no se limpia combo
                profesionalConfirmado = false;
                cboProfesional.Enabled = false; // bloquear cambio
                LimpiarCamposAgenda(false);     // limpiar solo los campos de horario
                btnAgregar.Text = "Agregar otro horario";
            }
            else
            {
                // Profesional sigue siendo el mismo, pero también se bloquea el cambio
                btnAgregar.Enabled = false;
                profesionalConfirmado = false;
                cboProfesional.Enabled = false;
                LimpiarCamposAgenda(false); // limpiar campos excepto profesional

                MessageBox.Show("Para cambiar de profesional, primero debe confirmar la agenda profesional o presionar cancelar para eliminar la operacion actual");
            }

        }

        private void btnConfirmarAgenda_Click(object sender, EventArgs e)
        {
            if (profesionalSeleccionadoId == -1 || dgvHorarios.Rows.Count == 0)
            {
                MessageBox.Show("Debes seleccionar un profesional y agregar horarios.");
                return;
            }

            var listaHorarios = new List<Horario>();
            var horariosPorDia = new Dictionary<string, List<(TimeSpan desde, TimeSpan hasta)>>();

            // Recorremos el DataGridView y validamos
            foreach (DataGridViewRow row in dgvHorarios.Rows)
            {
                if (row.IsNewRow) continue;

                string dia = row.Cells["Dia"].Value.ToString();
                TimeSpan horaDesde = TimeSpan.Parse(row.Cells["HoraInicio"].Value.ToString());
                TimeSpan horaHasta = TimeSpan.Parse(row.Cells["HoraFin"].Value.ToString());

                if (horaDesde >= horaHasta)
                {
                    MessageBox.Show($"El horario de inicio no puede ser mayor o igual al de fin. Día: {dia}");
                    return;
                }

                if (!horariosPorDia.ContainsKey(dia))
                    horariosPorDia[dia] = new List<(TimeSpan, TimeSpan)>();

                // Validar superposición dentro del DataGridView
                foreach (var (desdeExistente, hastaExistente) in horariosPorDia[dia])
                {
                    if (Horario.SeSuperpone(horaDesde, horaHasta, desdeExistente, hastaExistente))
                    {
                        MessageBox.Show($"El horario {horaDesde} - {horaHasta} se superpone con otro en el mismo día ({dia}).");
                        return;
                    }
                }

                horariosPorDia[dia].Add((horaDesde, horaHasta));

                // Validar límite de 2 rangos por día sumando con los existentes en la BD
                var horarioDAO = new HorarioDAO();
                int cantidadExistente = horarioDAO.ContarHorariosPorDia(profesionalSeleccionadoId, dia);

                if (cantidadExistente + horariosPorDia[dia].Count > 2)
                {
                    MessageBox.Show($"No se pueden asignar más de 2 horarios para el día {dia} (ya hay {cantidadExistente} guardado/s).");
                    return;
                }

                // Validar contra horarios ya guardados en la base
                if (horarioDAO.ExisteSuperposicion(profesionalSeleccionadoId, dia, horaDesde, horaHasta))
                {
                    MessageBox.Show($"Error. El horario ingresado:  {horaDesde} - {horaHasta} ya existe o se superpone con un horario existente para el día {dia}.");
                    return;
                }

                // Si pasó todas las validaciones, lo agregamos a la lista
                var horario = new Horario
                {
                    ProfesionalId = profesionalSeleccionadoId,
                    DiaSemana = dia,
                    HoraDesde = horaDesde,
                    HoraHasta = horaHasta,
                    DuracionMinutos = int.Parse(row.Cells["Duracion"].Value.ToString())
                };

                listaHorarios.Add(horario);
            }

            var dao = new HorarioDAO();
            bool exito = dao.GuardarHorarios(listaHorarios);

            if (exito)
            {
                MessageBox.Show("Agenda guardada correctamente.");
                dgvHorarios.Rows.Clear();
                LimpiarCamposAgenda(true); // <--- esto faltaba
            }
            else
            {
                MessageBox.Show("Error al guardar la agenda.");
            }
        }
        

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvHorarios.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    var confirm = MessageBox.Show("¿Seguro que deseas eliminar el horario seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        dgvHorarios.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }

        }

        private void dgvHorarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void chkLunes_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void chkMartes_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void chkMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void chkJueves_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void chkViernes_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            LimpiarCamposAgenda(true);
            dgvHorarios.Rows.Clear();
            btnAgregar.Enabled = true;
            cambios = false;
            

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboProfesional.SelectedIndex <= 0)
            {
                profesionalSeleccionadoId = -1;
                return;
            }

            Profesional seleccionado = (Profesional)cboProfesional.SelectedItem;
            profesionalSeleccionadoId = seleccionado.Id;
            profesionalConfirmado = true;
            cambios = true;
        }
    }
}

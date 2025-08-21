using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCVerTurnos : UserControl, IVerTurnos
    {
        private readonly VerTurnosPresenter _presenter;
        private Profesional ProfesionalSeleccionado;


        public UCVerTurnos()
        {
            InitializeComponent();
            _presenter = new VerTurnosPresenter(this);

        }

        private void UCVerTurnos_Load(object sender, EventArgs e)

        {
            DgvTurnos.AutoGenerateColumns = false;
            cmbPeriodo.SelectedIndex = 0; 
            cmbEstado.SelectedIndex = 0; 

            _presenter.InicializarVista();
            
            DgvTurnos.CellFormatting += DgvTurnos_CellFormatting;

        }

        public string FiltroPeriodo => cmbPeriodo.SelectedIndex > 0 ? cmbPeriodo.SelectedItem?.ToString() : null;
        public string FiltroEstado => cmbEstado.SelectedIndex > 0? cmbEstado.SelectedItem?.ToString() : null;
        public string FiltroPaciente => txtPaciente.Text.Trim();
        public string FiltroProfesional => cmbProfesional.SelectedValue?.ToString() ?? "";

        public void MostrarTurnos(List<TurnoVista> turnos)
        {
            DgvTurnos.AutoGenerateColumns = false;

            DgvTurnos.DataSource = turnos;
            DgvTurnos.ClearSelection();
        }

        public void HayFiltros()
        {
            var hayFiltros = cmbPeriodo.SelectedIndex > 0 ||
                     cmbEstado.SelectedIndex > 0 ||
                     cmbProfesional.SelectedIndex > 0 ||
                     !string.IsNullOrWhiteSpace(FiltroProfesional);

            ActualizarBotonLimpiar(hayFiltros);
        }

        public void ActualizarBotonLimpiar(bool visible)
        {
            btnLimpiar.Visible = visible;
        }

        public void LimpiarFiltros()
        {
            cmbPeriodo.SelectedIndex =0 ;
            cmbProfesional.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            txtPaciente.Clear();
            
        }
        public void MostrarProfesionales(List<Profesional> profesionales)
        {
            // Crear un profesional vacío para usarlo como valor por defecto
            var profesionalDefault = new Profesional
            {
                Id = 0,  
                Nombre = "--Seleccione un profesional--",  // Texto por defecto
                Apellido = "",
                NombreEspecialidad = ""
            };

            profesionales.Insert(0, profesionalDefault);

            
            cmbProfesional.DataSource = null;
            cmbProfesional.DataSource = profesionales;
            cmbProfesional.DisplayMember = "Mostrar"; // lo que se ve en el combo
            cmbProfesional.ValueMember = "Id";        // valor real que representa
            cmbProfesional.SelectedIndex = 0;        // opción vacía al inicio
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEstadoTurno_Click(object sender, EventArgs e)
        {
            if (DgvTurnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un turno.");
                return;
            }

            var fila = DgvTurnos.SelectedRows[0];

            string estadoActual = fila.Cells["estado"].Value?.ToString();

            if (estadoActual == "CANCELADO" || estadoActual == "PAGADO")
            {
                MessageBox.Show("Este turno ya fue cancelado y/o pagado. No se puede modificar su estado.", "Turno cancelado/ pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idTurno = Convert.ToInt32(fila.Cells["ID"].Value);
            string paciente = fila.Cells["Paciente"].Value.ToString();
            string dni = fila.Cells["DNI"].Value.ToString();
            string profesional = fila.Cells["Profesional"].Value.ToString();
            string fecha = fila.Cells["Fecha"].Value.ToString();
            string hora = fila.Cells["Horario"].Value.ToString();

            string info = $"Turno de {paciente} DNI: {dni}\nProfesional: {profesional}\nEl {fecha} a las {hora}";

            var form = new FrmCambiarEstadoTurno(info);

            if (form.ShowDialog() == DialogResult.OK)
            {
                string nuevoEstado = form.EstadoSeleccionado;
                _presenter.CambiarEstadoTurno(idTurno, nuevoEstado); // Usás el Presenter

                fila.Cells["estado"].Value = nuevoEstado; // Refrescás visualmente la celda
            }

        }

        private void DgvTurnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvTurnos.Columns[e.ColumnIndex].Name == "estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                switch (estado)
                {
                    case "PENDIENTE":
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.SelectionBackColor = Color.Gold;

                        break;
                    case "CONFIRMADO":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.SelectionBackColor = Color.LightGreen;

                        break;
                    case "CANCELADO":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.SelectionBackColor = Color.LightCoral;
                        break;
                    case "PAGADO":
                        e.CellStyle.BackColor = Color.LightGray;
                        break;



                }
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            _presenter.FiltrarTurnos(true);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _presenter.LimpiarFiltros();
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HayFiltros();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            HayFiltros();
        }

        


        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtPaciente.Text.Trim();

            if (texto.Length >= 2)
            {
                _presenter.FiltrarTurnos(); // Filtra por DNI ingresado
            }
            else if (string.IsNullOrEmpty(texto))
            {
                _presenter.FiltrarTurnos(); // Llama igual, pero sin filtro de DNI
            }
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            HayFiltros(); // Revisa si hay filtros activos (si es necesario)
        }
    }
}

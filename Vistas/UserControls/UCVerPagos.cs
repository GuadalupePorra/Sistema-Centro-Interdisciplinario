using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCVerPagos : UserControl, IVerPagos
    {
        private VerPagosPresenter _presenter;


        public UCVerPagos()
        {
            InitializeComponent();
            _presenter = new VerPagosPresenter(this);
        }

        private void UCVerPagos_Load(object sender, EventArgs e)
        {
            _presenter.InicializarVista();
        }

        public string FiltroPeriodo => cmbPeriodo.SelectedItem?.ToString() ?? "";
        public string FiltroPaciente => TxtPaciente.Text.Trim();
        public int? FiltroProfesional
        {
            get
            {
                if (cboProfesional.SelectedValue is null)
                    return null;

                if (int.TryParse(cboProfesional.SelectedValue.ToString(), out int id) && id != 0)
                    return id;

                return null; 
            }
        }
        public string FiltroEspecialidad => cmbEspecialidad.SelectedItem?.ToString() ?? "";

        public void MostrarPagos(List<PagoVista> pagos)
        {
            DgvPagos.DataSource = pagos;
            DgvPagos.ClearSelection();

            if (DgvPagos.Columns["IdPago"] != null)
                DgvPagos.Columns["IdPago"].Visible = false;

            DgvPagos.Columns["fecha_pago"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }
        public void MostrarEspecialidades(List<Especialidad> especialidades)
        {
            var especialidadesConDefault = new List<Especialidad>(especialidades);

            var especialidadDefault = new Especialidad
            {
                ID = 0,
                Nombre = "--Seleccione una especialidad--",  // Texto por defecto
                
            };

           especialidades.Insert(0, especialidadDefault);


            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "Nombre"; // lo que se ve en el combo
            cmbEspecialidad.ValueMember = "ID";        // valor real que representa
            cmbEspecialidad.SelectedIndex = 0;        // opción vacía al inicio
        }

        public void MostrarPacientes(List<Paciente> pacientes)
        {
            if (pacientes == null || !pacientes.Any())
            {
                LstPaciente.Visible = false;
                LstPaciente.DataSource = null;
                return;
            }

            LstPaciente.DataSource = pacientes;
            LstPaciente.DisplayMember = "Mostrar"; // Asumís que la propiedad Mostrar concatena dni + nombre
            LstPaciente.ValueMember = "Id";
            LstPaciente.Visible = true;
        }

        public void MostrarProfesionales(List<Profesional> profesionales)
        {
            var profesionalDefault = new Profesional
            {
                Id = 0,
                Nombre = "--Seleccione un profesional--",  // Texto por defecto
                Apellido = "",
                NombreEspecialidad = ""
            };

            profesionales.Insert(0, profesionalDefault);


            cboProfesional.DataSource = null;
            cboProfesional.DataSource = profesionales;
            cboProfesional.DisplayMember = "Mostrar"; // lo que se ve en el combo
            cboProfesional.ValueMember = "Id";        // valor real que representa
            cboProfesional.SelectedIndex = 0;        // opción vacía al inicio

        }

        public void HayFiltros()
        {
            var hayFiltros = !string.IsNullOrWhiteSpace(FiltroPeriodo) ||
                             !string.IsNullOrWhiteSpace(FiltroEspecialidad) ||
                             !string.IsNullOrWhiteSpace(FiltroPaciente) ||
                             FiltroProfesional != null;

            ActualizarBotonLimpiar(hayFiltros);
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ActualizarBotonLimpiar(bool visible)
        {
            btnLimpiar.Visible = visible;
        }

        public void LimpiarFiltros()
        {
            cmbPeriodo.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;
            TxtPaciente.Clear();
            cboProfesional.SelectedIndex = 0;

            LstPaciente.Visible = false;
            LstPaciente.DataSource = null;

        }


        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            _presenter.FiltrarPagos();

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _presenter.LimpiarFiltros();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtPaciente_TextChanged(object sender, EventArgs e)
        {
            _presenter.BuscarPacientes(TxtPaciente.Text.Trim());

        }

        private void LstPaciente_DoubleClick(object sender, EventArgs e)
        {
            if (LstPaciente.SelectedItem is Paciente paciente)
            {
                TxtPaciente.Text = paciente.DNI;
                LstPaciente.Visible = false;
            }
        }

        private void LstPaciente_Layout(object sender, LayoutEventArgs e)
        {
            LstPaciente.Visible = false;
        }

        

        private void LstPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            HayFiltros();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            HayFiltros();
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HayFiltros();
        }

        private void DgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvPagos.Columns[e.ColumnIndex].Name == "BtnVerRecibo")
            {
                var fila = DgvPagos.Rows[e.RowIndex].DataBoundItem as PagoVista;
                if (fila == null)
                {
                    MessageBox.Show("No se pudo obtener el recibo.");
                    return;
                }

                if (DgvPagos.Columns[e.ColumnIndex].Name == "BtnVerRecibo" && e.RowIndex >= 0)
                {
                    var pago = DgvPagos.Rows[e.RowIndex].DataBoundItem as PagoVista;

                    if (pago != null && (!File.Exists(pago.RutaRecibo)))
                    {
                        DgvPagos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "No disponible";
                    }
                }

                try
                {
                    Process.Start(new ProcessStartInfo(fila.RutaRecibo) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el recibo: " + ex.Message);
                }
            }
        }

        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

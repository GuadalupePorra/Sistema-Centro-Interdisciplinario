using MySql.Data.MySqlClient;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCFormularioPersona : UserControl, IFormularioConCambios, IFormularioPersona
    {
        private FormularioPersonaPresenter _presenter;
       
        private string estadoInicial;
        

        private readonly Action<UserControl> cargarUC;

        //constructor alta
        public UCFormularioPersona(TipoPersona tipo)
        {
            InitializeComponent();

            TipoPersona = tipo;
            EsEdicion = false;

            ConfigurarFormulario();
            dtpFechaNac.MinDate = new DateTime(1900, 1, 1);
            AsignarValidaciones();
        }

        //constructor modo edicion
        public UCFormularioPersona(int idPersona, TipoPersona tipoPersona, Action<UserControl> cargarUC)
        {
            InitializeComponent();

            IdPersonaSeleccionada = idPersona;
            TipoPersona = tipoPersona;
            EsEdicion = true;

            this.cargarUC = cargarUC;
            dtpFechaNac.Value = DateTime.Today;

            GuardarEstadoInicial();

        }

        public string Nombre => txtNombre.Text;
        public string Apellido => txtApellido.Text;
        public string DNI => txtDNI.Text;
        public string Telefono => txtTel.Text;
        public DateTime FechaNacimiento => dtpFechaNac.Value;
        public string ObraSocial => txtObS.Text;
        public bool TieneObraSocialMarcada => cbObS.Checked;
        public int IdEspecialidadSeleccionada => (int)cbEspecialidad.SelectedValue;
        public TipoPersona TipoPersona { get; private set; }
        public int IdPersonaSeleccionada { get; private set; }
        public bool EsEdicion { get; private set; }
        private void GuardarEstadoInicial()
        {
            estadoInicial = ObtenerTextoFormulario();
        }

        public void MostrarError(string campo, string mensaje)
        {
            Control control = null;

            switch (campo)
            {
                case "Nombre":
                    control = txtNombre;
                    break;
                case "Apellido":
                    control = txtApellido;
                    break;
                case "DNI":
                    control = txtDNI;
                    break;
                case "Telefono":
                    control = txtTel;
                    break;
                case "ObraSocial":
                    control = txtObS;
                    break;
                case "Especialidad":
                    control = cbEspecialidad;
                    break;
                case "FechaNacimiento":
                    control = dtpFechaNac;
                    break;
            }

            if (control != null)
                errorProvider.SetError(control, mensaje);
        }

        public void LimpiarErrores()
        {
            errorProvider.Clear();
        }

        public void MostrarMensaje(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje);
        }

        public bool Confirmar(string mensaje, string titulo)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void CargarFormulario(Paciente paciente)
        {
            txtNombre.Text = paciente.Nombre;
            txtApellido.Text = paciente.Apellido;
            txtDNI.Text = paciente.DNI;
            txtTel.Text = paciente.Telefono;
            dtpFechaNac.Value = paciente.FechaNacimiento;

            if (paciente.ObraSocial == "SIN OBRA SOCIAL")
            {
                cbObS.Checked = true;
                txtObS.Enabled = false;
                txtObS.Clear();
            }
            else
            {
                cbObS.Checked = false;
                txtObS.Enabled = true;
                txtObS.Text = paciente.ObraSocial;
            }
        }
        public void CargarEspecialidades(List<Especialidad> especialidades)
        {
            var especialidadesConDefault = new List<Especialidad>(especialidades);

            var especialidadDefault = new Especialidad
            {
                ID = 0,
                Nombre = "--Seleccione una especialidad--",  
            };
            especialidades.Insert(0, especialidadDefault);

            cbEspecialidad.DataSource = null;
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.DisplayMember = "Nombre";  
            cbEspecialidad.ValueMember = "Id";        
            cbEspecialidad.SelectedIndex = 0;
        }


        public void CargarFormulario(Profesional profesional)
        {
            txtNombre.Text = profesional.Nombre;
            txtApellido.Text = profesional.Apellido;
            txtDNI.Text = profesional.DNI;
            txtTel.Text = profesional.Telefono;
            cbEspecialidad.SelectedValue = profesional.IdEspecialidad;
        }

        private string ObtenerTextoFormulario()
        {

            var valores = new List<string>
            {
                txtNombre.Text,
                txtApellido.Text,
                txtDNI.Text,
                txtTel.Text
            };

            if (txtObS.Visible)
            {
                valores.Add(cbObS.Checked.ToString());
                valores.Add(txtObS.Text);
            }

            if (cbEspecialidad.Visible && cbEspecialidad.SelectedValue != null)
            {
                valores.Add(cbEspecialidad.SelectedValue.ToString());
            }

            return string.Join("|", valores);
        }


        public bool TieneCambiosSinGuardar()
        {
            return ObtenerTextoFormulario() != estadoInicial;
        }


        //--------------------CONFIGURAR FORM----------------------------
        public void ConfigurarFormulario()
        {
            string modo = EsEdicion ? "edición" : "ingreso";

            if (TipoPersona == TipoPersona.Paciente)
            {
                gbForm.Text = $"Formulario de {modo} de Pacientes";

                lblObS.Visible = true;
                txtObS.Visible = true;
                cbObS.Visible = true;

                lblEspecialidad.Visible = false;
                cbEspecialidad.Visible = false;
            }
            else if (TipoPersona == TipoPersona.Profesional)
            {
                gbForm.Text = $"Formulario de {modo} de Profesionales";

                lblObS.Visible = false;
                txtObS.Visible = false;
                cbObS.Visible = false;
                lblNacimiento.Visible = false;
                dtpFechaNac.Visible = false;
                lblAyuda.Visible = false;

                lblEspecialidad.Visible = true;
                cbEspecialidad.Visible = true;
            }

            btnAgregar.Text = EsEdicion ? "Guardar cambios" : "Agregar";
        }


        //LIMPIAR 
        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTel.Clear();
            txtObS.Clear();
            //txtEspecialidad.Clear();
            cbObS.Checked = false;
            dtpFechaNac.Value = DateTime.Today; // Reinicia a la fecha actual
            errorProvider.Clear(); // ← Esto limpia todos los errores del formulario


        }

        //------------------------VALIDACIONES----------------------------------
        private void AsignarValidaciones()
        {
            txtNombre.KeyPress += (s, e) => Validaciones.SoloLetras(s, e, errorProvider);
            txtApellido.KeyPress += (s, e) => Validaciones.SoloLetras(s, e, errorProvider);
            txtDNI.KeyPress += (s, e) => Validaciones.SoloNumeros(s, e, 8, errorProvider);
            txtTel.KeyPress += (s, e) => Validaciones.SoloNumeros(s, e, 11, errorProvider);
            txtObS.KeyPress += (s, e) => Validaciones.SoloLetras(s, e, errorProvider);
        }
        

        //------------------MODO EDICION------------------------
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _presenter.Cancelar();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _presenter.Guardar();

        }

        private void cbObS_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtObS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
          

        }

        private void UCFormularioPersona_Load(object sender, EventArgs e)
        {
            _presenter = new FormularioPersonaPresenter(this);
            _presenter.CargarPersonaParaEdicion();
            ConfigurarFormulario();
            GuardarEstadoInicial();
            _presenter.CargarEspecialidades();

        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


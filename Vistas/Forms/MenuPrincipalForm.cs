using SCI.Models.Entidades;
using SCI.Vistas.Forms;
using SCI.Vistas.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class MenuPrincipalForm : Form
    {
        private Usuario _usuario;
        public MenuPrincipalForm(Usuario usuario)
        {
            InitializeComponent();
            lblOpcion.Text = "";

            _usuario = usuario;

            lblUsuario.Text = $"Usuario: {_usuario.Nombre}";
            lblRol.Text = $"Rol: {_usuario.Rol}";

            if (_usuario.Rol== "Administrador")
            {
                btnRegresar.Visible = true;
            }
        }

        private void CambiarSeccionConControl(string titulo, UserControl nuevoUC, FontAwesome.Sharp.IconButton botonActivo)
        {
            if (contenedor.Controls.Count > 0)
            {
                var actual = contenedor.Controls[0];
                
                IFormularioConCambios conCambios = BuscarFormularioConCambios(actual);

                if (conCambios != null && conCambios.TieneCambiosSinGuardar())
                {
                    var res = MessageBox.Show(
                        "Hay cambios sin guardar. ¿Querés salir igual?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (res == DialogResult.No)
                        return;
                }
            }

            lblOpcion.Text = titulo;

            // Cargar el nuevo UC
            contenedor.Controls.Clear();
            contenedor.Controls.Add(nuevoUC);
            nuevoUC.Dock = DockStyle.Fill;

            // Resetear estilo de todos los botones 
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is FontAwesome.Sharp.IconButton btn)
                {
                    btn.BackColor = Color.DarkCyan;
                    btn.ForeColor = Color.White;
                    btn.IconColor = Color.White;
                }
            }

            // Estilo para el btn activo
            botonActivo.BackColor = Color.White;
            botonActivo.ForeColor = Color.Black;
            botonActivo.IconColor = Color.DarkCyan;
        }




        private IFormularioConCambios BuscarFormularioConCambios(Control control)
        {
            if (control is IFormularioConCambios conCambios)
                return conCambios;

            foreach (Control hijo in control.Controls)
            {
                var resultado = BuscarFormularioConCambios(hijo);
                if (resultado != null)
                    return resultado;
            }

            return null;
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            
        }

        private void lblOpcion_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            UCProfesionale panelTurnos = new UCProfesionale();
            CambiarSeccionConControl("> Gestión de Turnos", panelTurnos, btnTurnos);
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            UCPaciente panelPac = new UCPaciente();

            CambiarSeccionConControl("> Gestión de Pacientes", panelPac, btnPacientes);
        }

        private void btnProfesional_Click(object sender, EventArgs e)
        {
            UCProfesionales panelProfesionales = new UCProfesionales();

            CambiarSeccionConControl("> Gestión de Profesionales", panelProfesionales, btnProfesional);

        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            UCCaja panelCaja = new UCCaja();

            CambiarSeccionConControl("> Caja", panelCaja, btnCaja);
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro de que desea cerrar sesion?",
                                       "Confirmar accion",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTurnosDia_Click(object sender, EventArgs e)
        {
            var panelTD = new UCTurnosDelDia();

            panelTD.PagoTurnoSolicitado += idTurno =>
            {
                var panelCaja = new UCCaja();
                panelCaja.CargarRegistrarPagoConTurno(idTurno); 
                CambiarSeccionConControl("> Caja", panelCaja, btnCaja);
            };

            CambiarSeccionConControl("> Turnos del día", panelTD, btnTurnosDia);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var formAdmin = new AdminForm(_usuario);
            formAdmin.ShowDialog(); 
            this.Show(); 
        }
    }
}

using SCI.Models.Entidades;
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

namespace SCI.Vistas.Forms
{
    public partial class AdminForm : Form
    {
        private Usuario _usuario;
        public AdminForm(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            lblUsuario.Text = $"Usuario: {_usuario.Nombre}";
            lblRol.Text = $"Rol: {_usuario.Rol}";
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void CambiarSeccionConControl(string titulo, UserControl nuevoUC, FontAwesome.Sharp.IconButton botonActivo)
        {
            // Verificar si hay algo cargado en el contenedor
            if (contenedor.Controls.Count > 0)
            {
                var actual = contenedor.Controls[0];

                // Verificar si hay cambios sin guardar
                /*/IFormularioConCambios conCambios = BuscarFormularioConCambios(actual);

                if (conCambios != null && conCambios.TieneCambiosSinGuardar())
                {
                    var res = MessageBox.Show(
                        "Hay cambios sin guardar. ¿Querés salir igual?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (res == DialogResult.No)
                        return; // no cambiar de sección
                }/*/
            }

            // Cambiar el título
            lblOpcion.Text = titulo;

            // Cargar el nuevo UserControl
            contenedor.Controls.Clear();
            contenedor.Controls.Add(nuevoUC);
            nuevoUC.Dock = DockStyle.Fill;

            // Resetear estilo de todos los botones del menú lateral
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is FontAwesome.Sharp.IconButton btn)
                {
                    btn.BackColor = Color.DarkCyan;
                    btn.ForeColor = Color.White;
                    btn.IconColor = Color.White;
                }
            }

            // Estilo para el botón activo
            botonActivo.BackColor = Color.White;
            botonActivo.ForeColor = Color.Black;
            botonActivo.IconColor = Color.DarkCyan;
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UCUsuarioSistema panelUsuario = new UCUsuarioSistema();
            CambiarSeccionConControl("> Gestión de Usuarios", panelUsuario, btnUsuarios);
        }

        private void brnEspecialidades_Click(object sender, EventArgs e)
        {
            UCEspecialidad panelEspecialidad = new UCEspecialidad();
            CambiarSeccionConControl(">Gestion de Especialidades", panelEspecialidad, brnEspecialidades);
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            var formPrincipal = new MenuPrincipalForm(_usuario);
            formPrincipal.Show();

            this.Hide();
        }
    }
}

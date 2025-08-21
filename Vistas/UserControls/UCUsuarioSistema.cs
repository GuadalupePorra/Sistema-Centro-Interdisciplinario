using SCI.Interfaces;
using SCI.Models.Entidades;
using SCI.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SCI.Vistas.UserControls
{
    public partial class UCUsuarioSistema : UserControl, IUsuarioSistema
    {
        private UsuarioSistemaPresenter _presenter;
        public string Usuario => txtUsuario.Text;
        public string Contra => txtContra.Text;
        public string RolUsuario
        {
            get
            {
                if (chAdmin.Checked)
                    return "Administrador";
                else if (chRecepcionista.Checked)
                    return "Recepcionista";
                else
                    return string.Empty;
            }
        }
        public string NombreReal => txtNombre.Text;
        public int IdUsuarioSeleccionado { get; set; } // o private set si lo querés controlar desde adentro

        public bool EsEdicion { get; private set; }
        public UCUsuarioSistema()
        {
            InitializeComponent();
        }
        private void UCUsuarioSitema_Load(object sender, EventArgs e)
        {
            _presenter = new UsuarioSistemaPresenter(this);
            _presenter.CargarUsuarios();
        }

        private void gbForm_Enter(object sender, EventArgs e)
        {

        }

        public void MostrarUsuarios(List<Usuario> usuarios)
        {
            dgvUsuarios.Rows.Clear();

            foreach (var u in usuarios)
            {
                dgvUsuarios.Rows.Add(
                    u.ID,
                    u.NombreUsuario,
                    u.Rol,
                    u.Nombre
                );
            }
        }

        public void CargarUsuarioEnFormulario(Usuario usuario)
        {
            txtUsuario.Text = usuario.NombreUsuario;
            txtContra.Text = usuario.Contrasena;
            txtNombre.Text = usuario.Nombre;

            if (usuario.Rol == "Administrador")
                chAdmin.Checked = true;
            else if (usuario.Rol == "Recepcionista")
                chRecepcionista.Checked = true;

            IdUsuarioSeleccionado = usuario.ID;

            // Activa modo edición
            EstablecerModoEdicion(true);
        }

        public void EstablecerModoEdicion(bool esEdicion)
        {
            EsEdicion = esEdicion;

            if (esEdicion)
            {
                btnAgregar.Text = "Guardar cambios";
                gbForm.Text = "Editar Usuario";
            }
            else
            {
                btnAgregar.Text = "Agregar usuario";
                gbForm.Text = "Agregar Usuario";
            }
        }

        private void AsignarValidaciones()
        {
            txtNombre.KeyPress += (s, e) => Validaciones.SoloLetras(s, e, errorProvider);
           
        }

        public void MostrarMensaje(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje);
        }

        public void MostrarError(string campo, string mensaje)
        {
            Control control = null;

            switch (campo)
            {
                case "Nombre":
                    control = txtNombre;
                    break;
                case "Usuario":
                    control = txtUsuario;
                    break;
                case "Contra":
                    control = txtContrasena;
                    break;
                case "Admin":
                    control = chAdmin;
                    break;
                case "Recepcionista":
                    control = chRecepcionista;
                    break;
                
            }

            if (control != null)
                errorProvider.SetError(control, mensaje);
        }
        public bool Confirmar(string mensaje, string titulo)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public void LimpiarErrores()
        {
            errorProvider.Clear();
        }
        public void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContra.Clear();
            chAdmin.Checked = false;
            chRecepcionista.Checked = false;
            errorProvider.Clear();

            IdUsuarioSeleccionado = 0;
            EstablecerModoEdicion(false); // Restaurar modo agregar

        }

        private void chAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chAdmin.Checked)
                chRecepcionista.Checked = false;
        }

        private void chRecepcionista_CheckedChanged(object sender, EventArgs e)
        {
            if(chRecepcionista.Checked)
                chAdmin.Checked = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _presenter.Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _presenter.Cancelar();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                int id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["id"].Value);
                string nombreUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre_usuario"].Value.ToString();
                string nombre = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string rol = dgvUsuarios.Rows[e.RowIndex].Cells["Rol"].Value.ToString();

                var usuario = new Usuario
                {
                    ID = id,
                    NombreUsuario = nombreUsuario,
                    Nombre = nombre,
                    Rol = rol
                };

                // Llamás a tu método que ya está bien hecho
                CargarUsuarioEnFormulario(usuario);
            }

            // Verifica si el click fue en la columna de botón "Eliminar"
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["id"].Value);

                IdUsuarioSeleccionado = id;

                _presenter.EliminarUsuario();
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                e.CellStyle.BackColor = Color.LightSeaGreen;
                e.CellStyle.ForeColor = Color.White;
            }
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                e.CellStyle.BackColor = Color.Firebrick;
                e.CellStyle.ForeColor = Color.White;
                
            }
        }
    }
}

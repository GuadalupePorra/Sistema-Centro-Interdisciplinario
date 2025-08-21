using SCI.Interfaces;
using SCI.Models.Entidades;
using SCI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI.Presenters
{
    internal class UsuarioSistemaPresenter
    {
        private readonly IUsuarioSistema _vista;
        private readonly UsuarioSistemaService _service;

        public UsuarioSistemaPresenter( IUsuarioSistema vista)
        {
            _vista = vista;
            _service = new UsuarioSistemaService();
        }

        public void CargarUsuarios()
        {
            var usuarios = _service.ObtenerUsuarios();
            _vista.MostrarUsuarios(usuarios);
        }
        public void EliminarUsuario()
        {
            int id = _vista.IdUsuarioSeleccionado;

            if (id == 0)
            {
                _vista.MostrarMensaje("Debe seleccionar un usuario para eliminar.");
                return;
            }

            bool confirmar = _vista.Confirmar("¿Está seguro de que desea eliminar este usuario?", "Confirmar eliminación");

            if (!confirmar)
                return;

            bool exito = _service.EliminarUsuario(id);

            if (exito)
            {
                _vista.MostrarMensaje("Usuario eliminado correctamente.");
                _vista.LimpiarFormulario();
                CargarUsuarios(); // Opcional: recarga la lista en el dgv
            }
            else
            {
                _vista.MostrarError("Usuario", "No se pudo eliminar el usuario.");
            }
        }

        private bool ValidarFormulario()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(_vista.NombreReal))
            {
                _vista.MostrarError("Nombre", "El nombre es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(_vista.Usuario))
            {
                _vista.MostrarError("Usuario", "El nombre de usuario es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(_vista.Contra))
            {
                _vista.MostrarError("Contra", "La contraseña es obligatoria.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(_vista.RolUsuario))
            {
                _vista.MostrarError("Admin", "Debés seleccionar un rol.");
                valido = false;
            }

            return valido;
        }


        public void Guardar()
        {
            _vista.LimpiarErrores();
            bool esValido = ValidarFormulario();
            if (!esValido) return;
            var usuario = new Usuario
            {
                ID = _vista.IdUsuarioSeleccionado,
                NombreUsuario = _vista.Usuario,
                Contrasena = _vista.Contra,
                Nombre = _vista.NombreReal,
                Rol = _vista.RolUsuario
            };

            bool exito;

            if (_vista.EsEdicion)
            {
                exito = _service.ActualizarUsuario(usuario);
                if (exito)
                {
                    _vista.MostrarMensaje("Usuario actualizado correctamente.");
                }
                else
                {
                    _vista.MostrarError("Usuario", "No se pudo actualizar el usuario.");
                    return;
                }
            }
            else
            {
                exito = _service.InsertarUsuario(usuario);
                if (exito)
                {
                    _vista.MostrarMensaje("Usuario agregado correctamente.");
                }
                else
                {
                    _vista.MostrarError("Usuario", "No se pudo insertar el usuario. Quizá ya exista.");
                    return;
                }
            }

            _vista.LimpiarFormulario();
            CargarUsuarios(); 
        }


        public void Cancelar()
        {
            bool confirmar = _vista.Confirmar(
                "¿Está seguro de que desea cancelar? Se perderán los datos ingresados.",
                "Confirmar cancelación");

            if (confirmar)
            {
                _vista.LimpiarFormulario();
                _vista.LimpiarErrores();
            }
        }
    }
}

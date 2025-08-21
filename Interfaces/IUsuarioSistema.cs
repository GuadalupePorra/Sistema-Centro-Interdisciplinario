using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Interfaces
{
    internal interface IUsuarioSistema
    {
        string Usuario { get; }
        string Contra { get; }
        string RolUsuario { get; }
        string NombreReal { get; }

        bool EsEdicion { get; }
        int IdUsuarioSeleccionado { get; set; }


        void CargarUsuarioEnFormulario(Usuario usuario);
        void MostrarUsuarios(List<Usuario> usuarios);

        void MostrarMensaje(string mensaje, string titulo = "Información");
        void MostrarError(string campo, string mensaje);
        bool Confirmar(string mensaje, string titulo);
        void LimpiarFormulario();
        void LimpiarErrores();
    }
}

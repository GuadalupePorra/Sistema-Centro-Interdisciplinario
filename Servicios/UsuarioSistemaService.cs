using SCI.DAO;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Servicios
{
    internal class UsuarioSistemaService
    {
        private readonly UsuarioSistemaDAO _dao;

        public UsuarioSistemaService()
        {
            _dao = new UsuarioSistemaDAO() ;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            if (_dao.ExisteUsuario(usuario.NombreUsuario))
            {
                Console.WriteLine("El nombre de usuario ya existe.");
                return false;
            }
            return _dao.InsertarUsuario(

                usuario.NombreUsuario,
                usuario.Contrasena,
                usuario.Rol,
                usuario.Nombre

            );
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _dao.ObtenerUsuarios();
        }

        public bool EliminarUsuario(int id)
        {
            return _dao.EliminarUsuario(id);
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            return _dao.ActualizarUsuario(
                usuario.ID,
                usuario.NombreUsuario,
                usuario.Contrasena,
                usuario.Rol,
                usuario.Nombre
            );
        }



    }
}

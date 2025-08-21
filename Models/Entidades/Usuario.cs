using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Models.Entidades
{
    public class Usuario
    {
        private int id;
        private string usuario;
        private string contrasena;
        private string rol;
        private string nombre;
     
        public Usuario() { }

        public Usuario(int id, string usuario, string contrasena, string rol, string nombre)
        {
            this.id = id;
            this.usuario = usuario;
            this.contrasena = contrasena; // Idealmente deberías guardar un hash, no el texto plano
            this.rol = rol;
            this.nombre = nombre;
            
        }
        public int ID { get => id; set => id = value; }
        public string NombreUsuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        
    }
}

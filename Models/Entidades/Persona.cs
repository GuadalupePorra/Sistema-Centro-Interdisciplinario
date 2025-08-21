using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Models.Entidades
{
    public abstract class Persona
    {
        private int _id { get; set; }
        private string _nombre { get; set; }
        private string _apellido { get; set; }
        private string _dni;
        private string _telefono;
        public string DNI
        {
            get => _dni;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 8)
                    throw new ArgumentException("DNI inválido");
                _dni = value;
            }
        }
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7 || value.Length > 15)
                    throw new ArgumentException("Teléfono inválido");
                _telefono = value;
            }
        }
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get =>_nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set =>_apellido = value; }

        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}

using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Paciente : Persona
    {
        private string _edad { get; set; }
        private DateTime _fechaNacimiento { get; set; }
        private string _obraSocial { get; set; }

        public string Edad { get => _edad; set => _edad = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string ObraSocial { get => _obraSocial; set => _obraSocial = value; }


        public string Mostrar => $"{DNI} - {Apellido}, {Nombre}";
    }
}

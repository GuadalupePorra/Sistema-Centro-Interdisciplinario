using SCI.Interfaces;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Profesional : Persona
    {
        public bool Activo { get; set; }
        private int _idEspecialidad { get; set; }
        private string _nombreEspecialidad { get; set; }

        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public string NombreEspecialidad { get => _nombreEspecialidad; set => _nombreEspecialidad = value; }

        public string Mostrar => $"{Apellido} {Nombre} - {NombreEspecialidad}";
    }
}

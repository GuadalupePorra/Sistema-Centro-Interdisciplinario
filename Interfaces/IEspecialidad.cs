using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Interfaces
{
    internal interface IEspecialidad
    {
        string NombreEspecialidad { get; }
        void MostrarEspecialidad(List<Especialidad>especialidades);
        void MostrarMensaje(string mensaje, string titulo = "Información");
        void LimpiarFormulario();
    }
}

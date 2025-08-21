using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IFormularioPersona
    {
        string Nombre { get; }
        string Apellido { get; }
        string DNI { get; }
        string Telefono { get; }

        DateTime FechaNacimiento { get; }
        bool TieneObraSocialMarcada { get; }
        string ObraSocial { get; }

        int IdEspecialidadSeleccionada { get; }
        void CargarEspecialidades(List<Especialidad> especialidades);

        bool EsEdicion { get; }
        int IdPersonaSeleccionada { get; }
        TipoPersona TipoPersona { get; }

        bool Confirmar(string mensaje, string titulo);
        void MostrarMensaje(string mensaje, string titulo = "Información");
        void MostrarError(string campo, string mensaje);
        void LimpiarErrores();
        void LimpiarFormulario();
        void CargarFormulario(Paciente paciente);
        void CargarFormulario(Profesional profesional);

    }
}

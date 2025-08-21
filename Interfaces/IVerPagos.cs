using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IVerPagos
    {
        string FiltroPeriodo { get; }
        string FiltroPaciente { get; }
        int? FiltroProfesional { get; }
        string FiltroEspecialidad { get; }

        void MostrarPagos(List<PagoVista> pagos);
        void MostrarEspecialidades(List<Especialidad> especialidades);
        void MostrarPacientes(List<Paciente> pacientes);
        void MostrarProfesionales(List<Profesional> profesionales);

        void LimpiarFiltros();
        void ActualizarBotonLimpiar(bool visible);
        void MostrarMensaje(string mensaje);

    }
}

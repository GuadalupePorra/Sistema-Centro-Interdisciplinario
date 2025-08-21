using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IVerTurnos
    {
        string FiltroPeriodo { get; }
        string FiltroPaciente { get; }
        string FiltroProfesional { get; }
        string FiltroEstado { get; }

        void MostrarTurnos(List<TurnoVista> turnos);
        void MostrarProfesionales(List<Profesional> profesionales);
        void LimpiarFiltros();
        void ActualizarBotonLimpiar(bool visible);
        void MostrarMensaje(string mensaje);
    }
}

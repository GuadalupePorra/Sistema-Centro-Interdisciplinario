using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IVerProfesionales
    {
        string FiltroBusqueda { get; }
        void MostrarProfesionales(List<Profesional> profesionales);
        void MostrarMensaje(string mensaje);
        int? ObtenerIdProfesionalSeleccionado();
        bool ConfirmarAccion(string mensaje);

        bool FiltrarSoloActivos();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IVerPacientes
    {
        string FiltroBusqueda { get; }
        void MostrarPacientes(List<Paciente> pacientes);
        void MostrarMensaje(string mensaje);
        int? ObtenerIdPacienteSeleccionado();
        bool ConfirmarAccion(string mensaje);



    }
}

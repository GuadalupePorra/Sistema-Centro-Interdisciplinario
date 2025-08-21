using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IRegistrarPago
    {
        string DNI { get; }
        decimal Monto { get; }
        string MedioPagoSeleccionado { get; }
        void MostrarPacientes(List<Paciente> pacientes);
        void MostrarTurnos(List<TurnoVista> turnos);
        void MostrarMensaje(string mensaje);
        void LimpiarCampos();
        void BloquearBusquedaPaciente(bool bloquear);
        void MostrarBotonCambiarPaciente(bool visible);
        void MostrarDatosTurno(TurnoVista turno, Paciente paciente);
    }
}

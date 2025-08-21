using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SCI
{
    public interface IAgendarTurno
    {
        DateTime FechaSeleccionada { get; set; }
        string HoraSeleccionada { get; set; }
        string BusquedaPaciente { get; }
        string BusquedaProfesional { get; }
        Paciente PacienteSeleccionado { get; }
        Profesional ProfesionalSeleccionado { get; }

        void MostrarPacientes(List<Paciente> pacientes);
        //void CargarProfesionales();
        void MostrarHorariosProfesional(string resumenHorarios);
        void MostrarSlots(List<(TimeSpan desde, TimeSpan hasta)> slots);
        void ConfirmarCambioProfesional(Action onConfirmado);
        void ConfirmarCambioPaciente(Action onConfirmado);
        void LimpiarVistaProfesional();
        void LimpiarVistaPaciente();
        bool Confirmar(string mensaje); // nuevo
        void ConfirmarSeleccionSlot(string mensaje, Action onConfirmar);

        void MostrarMensajeSinSlots();
        void MostrarMensaje(string mensaje);
        void MostrarMensajeExito(string mensaje);
        void MostrarMensajeError(string mensaje);
        void LimpiarCampos();


    }
}

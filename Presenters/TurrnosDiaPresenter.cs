using SCI.Interfaces;
using SCI.Models.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI.Presenters
{
    internal class TurrnosDiaPresenter
    {
        private readonly ITurnosDia _vista;
        private readonly TurnoService _turnoservice;
        private readonly PacienteService _pacienteService;
        private readonly ProfesionalService _profesionalService;

        public TurrnosDiaPresenter(ITurnosDia vista)
        {
            _vista = vista;
            _turnoservice = new TurnoService();
            _pacienteService = new PacienteService();
            _profesionalService = new ProfesionalService();
        }
        
        public void CargarTurnosDeHoy()
        {
            var turnos = _turnoservice.ObtenerTurnosDia();
            _vista.MostrarTurnos(turnos);

            var resumen = new ResumenTurnosDelDia
            {
                Total = turnos.Count,
                Confirmados = turnos.Count(t => t.Estado == "CONFIRMADO"),
                Pendientes = turnos.Count(t => t.Estado == "PENDIENTE"),
                Cancelados = turnos.Count(t => t.Estado == "CANCELADO"),
                Pagados = turnos.Count(t => t.Estado == "PAGADO") // si lo estás manejando así
            };

            _vista.MostrarResumen(resumen);
        }
        public void CargarTurnosDeHoyPorProfesional(int idProfesional)
        {
            var turnos = _turnoservice.ObtenerTurnosDeHoyPorProfesional(idProfesional);
            _vista.MostrarTurnos(turnos);
        }

        public void CargarProfesionales()
        {
            var lista = _profesionalService.ObtenerProfesionalesConSeleccion();
            _vista.MostrarProfesionales(lista);
        }

        public void CambiarEstadoTurno(int idTurno, string nuevoEstado)
        {
            try
            {
                _turnoservice.CambiarEstadoTurno(idTurno, nuevoEstado);
                _vista.MostrarMensaje("Estado actualizado con éxito.");
            }
            catch (Exception ex)
            {
                _vista.MostrarMensaje($"Error al cambiar estado del turno: {ex.Message}");
            }
        }

        public TurnoVista ObtenerTurnoPorId(int idTurno)
        {
            return _turnoservice.ObtenerTurnoVistaPorId(idTurno);
        }

        public Paciente ObtenerPacientePorDNI(string dni)
        {
            return _pacienteService.ObtenerPacientePorDNI(dni);
        }
    }
}

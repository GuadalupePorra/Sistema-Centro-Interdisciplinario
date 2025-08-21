using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class TurnoService
    {
        private readonly TurnosDAO _turnosDAO;
        private readonly ProfesionalDAO _profesionalDAO;
        private readonly PacienteDAO _pacienteDAO;
        private readonly HorarioDAO _horarioDAO;

        public TurnoService()
        {
            _turnosDAO = new TurnosDAO();
            _profesionalDAO = new ProfesionalDAO();
            _pacienteDAO = new PacienteDAO();
            _horarioDAO = new HorarioDAO();
        }

        public List<TurnoVista> ObtenerTurnos(string estado = null, string periodo = null, int cantidad = 50, string profesional = null, string paciente = null)
        {
            var turnos = _turnosDAO.ObtenerTurnosFiltrados(estado, periodo, cantidad, paciente); // ✅ Ahora sí se filtra

            if (!string.IsNullOrWhiteSpace(profesional))
            {
                turnos = turnos.Where(t => t.NombreProfesional.IndexOf(profesional, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            return turnos;
        }

        public List<TurnoVista> ObtenerTurnosDeHoyPorProfesional(int idProfesional)
        {
            return _turnosDAO.ObtenerTurnosDeHoyPorProfesional(idProfesional);
        }


        public List<Paciente> BuscarPacientes(string filtro)
        {
            return _pacienteDAO.BuscarPacientes(filtro);
        }

        public List<Profesional> ObtenerProfesionales()
        {
            return _profesionalDAO.ObtenerProfesionales();
        }

        public Profesional ObtenerProfesionalPorId(int id)
        {
            return _profesionalDAO.ObtenerProfesionalPorId(id);
        }

        public List<Profesional> BuscarProfesionales(string filtro, bool soloActivos = true)
        {
            return _profesionalDAO.BuscarProfesionales(filtro, soloActivos);
        }


        public void CambiarEstadoTurno(int idTurno, string nuevoEstado)
        {
            // Validaciones básicas
            if (idTurno <= 0)
                throw new ArgumentException("ID de turno inválido.");

            if (string.IsNullOrEmpty(nuevoEstado))
                throw new ArgumentException("El nuevo estado no puede estar vacío.");

            // Validar que sea un estado permitido
            var estadosValidos = new[] { "PENDIENTE", "CONFIRMADO", "CANCELADO" };
            if (!Array.Exists(estadosValidos, e => e.Equals(nuevoEstado, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Estado inválido.");

            _turnosDAO.ActualizarEstado(idTurno, nuevoEstado.ToUpper());
        }

        public List<(TimeSpan desde, TimeSpan hasta)> ObtenerSlotsDisponibles(int idProfesional, DateTime fecha)
        {
            var ocupados = _turnosDAO.ObtenerHorariosOcupados(idProfesional, fecha);
            var horarios = _horarioDAO.ObtenerHorariosPorProfesional(idProfesional);

            string diaSemana = fecha.ToString("dddd", new CultureInfo("es-ES"));
            var horariosDelDia = horarios
                .Where(h => h.DiaSemana.Equals(diaSemana, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var slotsDisponibles = new List<(TimeSpan, TimeSpan)>();

            foreach (var horario in horariosDelDia)
            {
                var horaActual = horario.HoraDesde;
                while (horaActual + TimeSpan.FromMinutes(horario.DuracionMinutos) <= horario.HoraHasta)
                {
                    var horaFin = horaActual + TimeSpan.FromMinutes(horario.DuracionMinutos);

                    if (!ocupados.Contains(horaActual))
                        slotsDisponibles.Add((horaActual, horaFin));

                    horaActual = horaFin;
                }
            }

            return slotsDisponibles;
        }

        public void AgendarTurno(Turno turno)
        {
            _turnosDAO.AgendarTurno(turno); // aquí puede lanzar excepción
        }

        public List<TurnoVista> ObtenerTurnosDia()
        {
            var turnos = _turnosDAO.ObtenerTurnosDeHoy();
            return turnos;
        }

        public TurnoVista ObtenerTurnoVistaPorId(int id)
        {
            return _turnosDAO.ObtenerTurnoVistaPorId(id);
        }





    }
}

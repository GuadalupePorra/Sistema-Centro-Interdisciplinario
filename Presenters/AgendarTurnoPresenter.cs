using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public class AgendarTurnoPresenter
    {
        private readonly IAgendarTurno _vista;
        private readonly TurnoService _Tservice;
        private readonly HorarioService _Hservice;


        public AgendarTurnoPresenter(IAgendarTurno vista)
        {
            _vista = vista;
            _Tservice = new TurnoService();
            _Hservice = new HorarioService();
        }

        public void BuscarPacientes(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro) || filtro.Length < 2)
            {
                _vista.MostrarPacientes(null);
                return;
            }

            var pacientes = _Tservice.BuscarPacientes(filtro);

            if (pacientes.Count > 10 && filtro.Length < 7)
            {
                _vista.MostrarMensaje("Demasiados resultados. Ingrese mas dígitos.");
                _vista.MostrarPacientes(null);
                return;
            }
           
            _vista.MostrarPacientes(pacientes);
        }

        
        
        public void ObtenerHorarioProfesional(int idProfesional)
        {
            var horarios = _Hservice.ObtenerHorarioProfesional(idProfesional);

            var horariosAgrupados = horarios
                .GroupBy(h => new { h.HoraDesde, h.HoraHasta })
                .Select(g => new
                {
                    Dias = string.Join(", ", g.Select(h => h.DiaSemana)),
                    HoraDesde = g.Key.HoraDesde,
                    HoraHasta = g.Key.HoraHasta
                })
                .ToList();

            if (!horariosAgrupados.Any())
            {
                _vista.MostrarHorariosProfesional("Este profesional no tiene horarios registrados.");
                return;
            }

            var sb = new StringBuilder();
            foreach (var h in horariosAgrupados)
            {
                sb.AppendLine($"Días: {h.Dias} - {h.HoraDesde:hh\\:mm} a {h.HoraHasta:hh\\:mm}");
            }

            _vista.MostrarHorariosProfesional(sb.ToString());
        }
        
        public void CargarSlots(int idProfesional, DateTime fecha)
        {
            var slots = _Tservice.ObtenerSlotsDisponibles(idProfesional, fecha);

            if (slots.Any())
                _vista.MostrarSlots(slots);
            else
                _vista.MostrarMensajeSinSlots();
        }

        public void SeleccionarSlot(string hora, DateTime fecha, Action onConfirmar)
        {
            string mensaje = $"¿Confirmás el turno para el día {fecha:dd/MM/yyyy} a las {hora}?";

            _vista.ConfirmarSeleccionSlot(mensaje, () =>
            {
                _vista.HoraSeleccionada = hora;
                _vista.FechaSeleccionada = fecha;

                onConfirmar?.Invoke();
            });
        }


        public void AgendarTurno()
        {
            var paciente = _vista.PacienteSeleccionado;
            var profesional = _vista.ProfesionalSeleccionado;
            var fecha = _vista.FechaSeleccionada;
            var horaSeleccionada = _vista.HoraSeleccionada;

            if (paciente == null || profesional == null || string.IsNullOrEmpty(horaSeleccionada))
            {
                _vista.MostrarMensaje("Faltan datos obligatorios para agendar el turno.");
                return;
            }

            string[] partesHora = horaSeleccionada.Split('-');
            TimeSpan horaInicio = TimeSpan.Parse(partesHora[0].Trim());
            TimeSpan horaFin = TimeSpan.Parse(partesHora[1].Trim());

            string mensaje = $"¿Confirmás agendar el siguiente turno?\n\n" +
                             $"Paciente: {paciente.DNI} {paciente.Apellido}, {paciente.Nombre}\n" +
                             $"Profesional: {profesional.Mostrar}\n" +
                             $"Fecha: {fecha:dd/MM/yyyy}\n" +
                             $"Hora: {horaSeleccionada}";

            if (!_vista.Confirmar(mensaje))
                return;

            var nuevoTurno = new Turno
            (
                profesional.Id,
                paciente.Id,
                fecha.Date,
                horaInicio,
                horaFin
            );

            try
            {
                _Tservice.AgendarTurno(nuevoTurno);
                _vista.MostrarMensajeExito("¡Turno agendado correctamente!");
                _vista.LimpiarCampos();
            }
            catch (Exception ex)
            {
                _vista.MostrarMensajeError("Error al agendar el turno: " + ex.Message);
            }
        }

        public void CambiarProfesional()
        {
            _vista.ConfirmarCambioProfesional(() =>
            {
                _vista.LimpiarVistaProfesional();
            });
        }

        public void CambiarPaciente()
        {
            _vista.ConfirmarCambioPaciente(() =>
            {
                _vista.LimpiarVistaPaciente();
            });
        }

        public void LimpiarCampos()
        {
            _vista.LimpiarCampos();
        }
    }
}

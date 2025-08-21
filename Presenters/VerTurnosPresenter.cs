using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class VerTurnosPresenter
    {
        private readonly IVerTurnos _vista;
        private readonly TurnoService _service;

        public VerTurnosPresenter(IVerTurnos vista)
        {
            _vista = vista; 
            _service = new TurnoService();
        }

        public void InicializarVista()
        {
            var profesionales = _service.ObtenerProfesionales();
            _vista.MostrarProfesionales(profesionales);

            var turnos = _service.ObtenerTurnos(null, null, 20);
            _vista.MostrarTurnos(turnos);
        }

        public void FiltrarTurnos(bool mostrarMensajeSiNoHayFiltros = false)
        {
            var hayAlgúnFiltro =
                !string.IsNullOrWhiteSpace(_vista.FiltroEstado) ||
                !string.IsNullOrWhiteSpace(_vista.FiltroPeriodo) ||
                !string.IsNullOrWhiteSpace(_vista.FiltroProfesional) ||
                !string.IsNullOrWhiteSpace(_vista.FiltroPaciente);

            if (!hayAlgúnFiltro && mostrarMensajeSiNoHayFiltros)
            {
                _vista.MostrarMensaje("Debe seleccionar al menos un criterio para filtrar.");
                _vista.ActualizarBotonLimpiar(false);
                return;
            }

            string nombreProfesional = null;
            if (!string.IsNullOrWhiteSpace(_vista.FiltroProfesional) && _vista.FiltroProfesional != "--Seleccione un profesional--")
            {
                try
                {
                    int idProfesional = Convert.ToInt32(_vista.FiltroProfesional);  

                    if (idProfesional == 0)
                    {
                        nombreProfesional = null; 
                    }
                    else
                    {
                        var profesional = _service.ObtenerProfesionalPorId(idProfesional);

                        if (profesional != null)
                        {
                            nombreProfesional = profesional.Nombre;  
                        }
                        else
                        {
                            _vista.MostrarMensaje("No se encontró el profesional con ID: " + idProfesional);
                            return;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("El ID del profesional no es válido.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("No se ha seleccionado un profesional o se seleccionó la opción por defecto.");
            }

            string estado = _vista.FiltroEstado;
            if (estado == "TODOS") estado = null;

            string periodo = _vista.FiltroPeriodo;
            if (periodo == "TODOS") periodo = null;

            // Llamar al servicio con el NombreProfesional
            var turnos = _service.ObtenerTurnos(
                estado,
                periodo,
                50,
                nombreProfesional, // Usamos el NombreProfesional
                _vista.FiltroPaciente
            );

            _vista.MostrarTurnos(turnos);
            _vista.ActualizarBotonLimpiar(hayAlgúnFiltro);

            if (turnos == null || !turnos.Any())
            {
                _vista.MostrarMensaje("No se encontraron resultados para los filtros ingresados.");
                
            }
        }

        public void CambiarEstadoTurno(int idTurno, string nuevoEstado)
        {
            try
            {
                _service.CambiarEstadoTurno(idTurno, nuevoEstado);
                _vista.MostrarMensaje("Estado actualizado con éxito.");
            }
            catch (Exception ex)
            {
                _vista.MostrarMensaje($"Error al cambiar estado del turno: {ex.Message}");
            }
        }

        public void LimpiarFiltros()
        {
            _vista.LimpiarFiltros();
            var turnos = _service.ObtenerTurnos(null, null, 20);
            _vista.MostrarTurnos(turnos);
            _vista.ActualizarBotonLimpiar(false);
        }



    }
}

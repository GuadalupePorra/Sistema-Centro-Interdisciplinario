using SCI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class VerPagosPresenter
    {
        private readonly IVerPagos _vista;
        private readonly PagoService _service;

        public VerPagosPresenter(IVerPagos view)
        {
            _vista = view;
            _service = new PagoService(); // o inyectar
        }

        public void InicializarVista()
        {
            var profesionales = _service.ObtenerProfesionales();
            _vista.MostrarProfesionales(profesionales);

            var lista = _service.ObtenerEspecialidades(); 
            _vista.MostrarEspecialidades(lista);

            var pagos = _service.ObtenerPagosFiltrados();
            _vista.MostrarPagos(pagos);
        }


        public void FiltrarPagos()
        {
            int? idProfesional = _vista.FiltroProfesional;

            var hayFiltros =
                !string.IsNullOrWhiteSpace(_vista.FiltroPeriodo) ||
                !string.IsNullOrWhiteSpace(_vista.FiltroEspecialidad) ||
                !string.IsNullOrWhiteSpace(_vista.FiltroPaciente) ||
                idProfesional != null;

            if (!hayFiltros)
            {
                _vista.MostrarMensaje("Debe seleccionar al menos un criterio para filtrar.");
                _vista.ActualizarBotonLimpiar(false);
                return;
            }

            string periodo = _vista.FiltroPeriodo;
            if (periodo == "TODOS") periodo = null;

            var pagos = _service.ObtenerPagosFiltrados(
                periodo,
                _vista.FiltroPaciente,
                _vista.FiltroEspecialidad,
                idProfesional
            );

            _vista.MostrarPagos(pagos);
            _vista.ActualizarBotonLimpiar(true);

            if (pagos == null || !pagos.Any())
            {
                _vista.MostrarMensaje("No se encontraron resultados para los filtros ingresados.");
            }
        }


        public void BuscarPacientes(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro) || filtro.Length < 2)
            {
                _vista.MostrarPacientes(null);
                return;
            }

            var pacientes = _service.BuscarPacientes(filtro);
            _vista.MostrarPacientes(pacientes);
        }

        

        public void LimpiarFiltros()
        {
            _vista.LimpiarFiltros();
            var pagos = _service.ObtenerPagosFiltrados(); // sin filtros
            _vista.MostrarPagos(pagos);
            _vista.ActualizarBotonLimpiar(false);
        }
    }

}

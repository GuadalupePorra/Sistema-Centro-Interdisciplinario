using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public class VerProfesionalesPresenter
    {
        private readonly IVerProfesionales _vista;
        private readonly ProfesionalService _service;

        public VerProfesionalesPresenter(IVerProfesionales vista, ProfesionalService service)
        {
            _vista = vista;
            _service = service;

            CargarProfesionales();
        }

        public void CargarProfesionales()
        {
            bool soloActivos = _vista.FiltrarSoloActivos(); // Esto es parte de la vista (UC)
            var lista = _service.ObtenerProfesionales(soloActivos);
            _vista.MostrarProfesionales(lista);
        }

        public void FiltrarProfesionales()
        {
            var filtro = _vista.FiltroBusqueda;
            var profesionales = _service.BuscarProfesionales(filtro);
            _vista.MostrarProfesionales(profesionales);
        }

        public void CambiarEstadoProfesional(int id, bool estaActivo)
        {
            string accion = estaActivo ? "dar de baja" : "dar de alta";
            var confirm = _vista.ConfirmarAccion($"¿Está seguro que desea {accion} al profesional seleccionado?");

            if (!confirm)
                return;

            bool resultado = _service.CambiarEstado(id, !estaActivo);

            if (resultado)
            {
                _vista.MostrarMensaje("Estado actualizado correctamente.");
                CargarProfesionales();
            }
            else
            {
                _vista.MostrarMensaje("Error al actualizar el estado.");
            }
        }


    }
}

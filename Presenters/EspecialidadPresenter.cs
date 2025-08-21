using SCI.Interfaces;
using SCI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI.Presenters
{
    internal class EspecialidadPresenter
    {
        private readonly IEspecialidad _vista;
        private readonly EspecialidadService _service;

        public EspecialidadPresenter(IEspecialidad vista)
        {
            _vista = vista;
            _service = new EspecialidadService();
        }

        public void CargarEspecialidad()
        {
            var especialidades = _service.ObtenerEspecialidades();
            _vista.MostrarEspecialidad(especialidades);
        }

        public void AgregarEspecialidad()
        {
            string nombre = _vista.NombreEspecialidad.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                _vista.MostrarMensaje("El nombre de la especialidad no puede estar vacío.");
                return;
            }

            bool resultado = _service.InsertarEspecialidad(nombre);

            if (resultado)
            {
                _vista.MostrarMensaje("Especialidad insertada correctamente.");
                _vista.LimpiarFormulario();
                CargarEspecialidad();
            }
            else
            {
                _vista.MostrarMensaje("Error al insertar la especialidad.");
            }
        }

        public void EliminarEspecialidad(int id)
        {
           
            if (_service.EspecialidadTieneProfesionales(id))
            {
                _vista.MostrarMensaje("No se puede eliminar la especialidad porque está asociada a uno o más profesionales.");
                return;
            }
            bool eliminado = _service.EliminarEspecialidad(id);
            if (eliminado)
            {
                _vista.MostrarMensaje("Especialidad eliminada correctamente.");
                CargarEspecialidad(); // Refrescás la grilla
            }
            else
            {
                _vista.MostrarMensaje("Error al eliminar la especialidad.", "Error");
            }
        }

    }
}

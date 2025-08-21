using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public class VerPacientesPresenter
    {
        private readonly IVerPacientes _vista;
        private readonly PacienteService _service;

        public VerPacientesPresenter(IVerPacientes vista, PacienteService service)
        {
            _vista = vista;
            _service = service;

            CargarPacientes();
        }

        public void CargarPacientes()
        {
            var pacientes = _service.ObtenerPacientes();
            _vista.MostrarPacientes(pacientes);
        }

        public void FiltrarPacientes()
        {
            var filtro = _vista.FiltroBusqueda;
            var pacientes = _service.BuscarPacientes(filtro);
            _vista.MostrarPacientes(pacientes);
        }
        public void EliminarPaciente(int id)
        {
            bool exito = _service.Eliminar(id);
            if (exito)
            {
                _vista.MostrarMensaje("Paciente eliminado correctamente.");
                CargarPacientes(); 
            }
            else
            {
                _vista.MostrarMensaje("No se pudo eliminar el paciente.");
            }
        }



        


    }
}

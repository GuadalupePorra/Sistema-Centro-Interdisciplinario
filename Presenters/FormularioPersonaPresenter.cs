using SCI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    internal class FormularioPersonaPresenter
    {
        private readonly IFormularioPersona _vista;
        private readonly PacienteService _pacienteService;
        private readonly ProfesionalService _profesionalService;
        private readonly EspecialidadService _especialidadService;

        public FormularioPersonaPresenter(IFormularioPersona vista)
        {
            _vista = vista;
            _pacienteService = new PacienteService();
            _profesionalService = new ProfesionalService();
            _especialidadService = new EspecialidadService(); // 👈 Aca lo asignás

        }

        public void CargarPersonaParaEdicion()
        {
            if (!_vista.EsEdicion) return;

            if (_vista.TipoPersona == TipoPersona.Paciente)
            {
                var paciente = _pacienteService.ObtenerPacientePorId(_vista.IdPersonaSeleccionada);
                if (paciente != null)
                    _vista.CargarFormulario(paciente);
            }
            else if (_vista.TipoPersona == TipoPersona.Profesional)
            {
                var profesional = _profesionalService.ObtenerProfesionalPorId(_vista.IdPersonaSeleccionada);
                if (profesional != null)
                    _vista.CargarFormulario(profesional);
            }
        }
        public void CargarEspecialidades()
        {
            var lista = _especialidadService.ObtenerEspecialidades(); // viene desde DAO o Service
            _vista.CargarEspecialidades(lista);
        }



        public void Guardar()
        {
            _vista.LimpiarErrores();

            if (!ValidarFormulario()) return;

            if (!_vista.Confirmar(
                    _vista.EsEdicion ? "¿Deseás guardar los cambios?" : "¿Deseás agregar esta persona?",
                    _vista.EsEdicion ? "Confirmar edición" : "Confirmar acción")) return;

            bool resultado = false;

            if (_vista.TipoPersona == TipoPersona.Paciente)
                resultado = GuardarPaciente();
            else if (_vista.TipoPersona == TipoPersona.Profesional)
                resultado = GuardarProfesional();

            if (resultado)
            {
                _vista.MostrarMensaje(_vista.EsEdicion ? "Actualización exitosa." : "Registro exitoso.");
                _vista.LimpiarFormulario();
            }
            else
            {
                _vista.MostrarMensaje("Ocurrió un error al guardar la información.");
            }
        }

        private bool GuardarPaciente()
        {
            var paciente = new Paciente
            {
                Id = _vista.IdPersonaSeleccionada,
                Nombre = _vista.Nombre,
                Apellido = _vista.Apellido,
                DNI = _vista.DNI,
                Telefono = _vista.Telefono,
                FechaNacimiento = _vista.FechaNacimiento,
                Edad = Utilidades.CalcularEdad(_vista.FechaNacimiento).ToString(),
                ObraSocial = _vista.TieneObraSocialMarcada ? "SIN OBRA SOCIAL" : _vista.ObraSocial
            };

            if (_vista.EsEdicion)
            {
                bool actualizado = _pacienteService.ActualizarPaciente(paciente);
                _vista.MostrarMensaje(actualizado ? "Paciente actualizado correctamente." : "Error al actualizar el paciente.");
                return actualizado;
            }
            else
            {
                string mensaje;
                bool insertado = _pacienteService.InsertarPaciente(paciente, out mensaje);
                _vista.MostrarMensaje(mensaje);
                return insertado;
            }
        }
        private bool GuardarProfesional()
        {
            var profesional = new Profesional
            {
                Id = _vista.IdPersonaSeleccionada,
                Nombre = _vista.Nombre,
                Apellido = _vista.Apellido,
                DNI = _vista.DNI,
                Telefono = _vista.Telefono,
                IdEspecialidad = _vista.IdEspecialidadSeleccionada
            };
            if (_vista.EsEdicion)
            {
                bool actualizado = _profesionalService.ActualizarProfesional(profesional);
                _vista.MostrarMensaje(actualizado ? "Profesional actualizado correctamente." : "Error al actualizar el profesional.");
                return actualizado;
            }
            else
            {
                string mensaje;
                bool insertado = _profesionalService.InsertarProfesional(profesional, out mensaje);
                _vista.MostrarMensaje(mensaje);
                return insertado;
            }

        }

        private bool ValidarCamposComunes()
        {
            bool valido = true;
            if (string.IsNullOrWhiteSpace(_vista.Nombre))
            {
                _vista.MostrarError("Nombre", "El nombre es obligatorio.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(_vista.Apellido))
            {
                _vista.MostrarError("Apellido", "El apellido es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(_vista.DNI))
            {
                _vista.MostrarError("DNI", "El DNI es obligatorio.");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(_vista.Telefono))
            {
                _vista.MostrarError("Telefono", "El telefono es obligatorio.");
                valido = false;
            }
            return valido;
        }

        private bool ValidarFormulario()
        {
            bool valido = ValidarCamposComunes();

            if (_vista.TipoPersona == TipoPersona.Paciente)
            {
                if (!_vista.TieneObraSocialMarcada && string.IsNullOrWhiteSpace(_vista.ObraSocial))
                {
                    _vista.MostrarError("ObraSocial", "Debe indicar una obra social o marcar 'Sin obra social'.");
                    valido = false;
                }

                if (_vista.FechaNacimiento >= DateTime.Today)
                {
                    _vista.MostrarError("FechaNacimiento", "La fecha de nacimiento no es válida.");
                    valido = false;
                }
            }

            if (_vista.TipoPersona == TipoPersona.Profesional)
            {
                if (_vista.IdEspecialidadSeleccionada <= 0)
                {
                    _vista.MostrarError("Especialidad", "Debe seleccionar una especialidad.");
                    valido = false;
                }
            }

            return valido;
        }

        public void Cancelar()
        {
            bool confirmar = _vista.Confirmar(
                "¿Está seguro de que desea cancelar? Se perderán los datos ingresados.",
                "Confirmar cancelación");

            if (confirmar)
            {
                _vista.LimpiarFormulario();
                _vista.LimpiarErrores();
            }
        }


    }
}

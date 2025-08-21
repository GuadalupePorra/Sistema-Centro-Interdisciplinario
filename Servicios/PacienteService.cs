using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class PacienteService
    {
        private readonly PacienteDAO _pacienteDAO;

        public PacienteService()
        {
            _pacienteDAO = new PacienteDAO();
        }

        public bool InsertarPaciente(Paciente paciente, out string mensaje)
        {
            if (_pacienteDAO.ExisteDni(paciente.DNI))
            {
                mensaje = "Error. El DNI ingresado ya pertenece a un paciente registrado.";
                return false;
            }

            bool insertado = _pacienteDAO.InsertarPaciente(
                paciente.Nombre,
                paciente.Apellido,
                paciente.DNI,
                paciente.Edad,
                paciente.FechaNacimiento,
                paciente.Telefono,
                paciente.ObraSocial
            );

            mensaje = insertado ? "Paciente agregado correctamente." : "Error al agregar el paciente.";
            return insertado;
        }


        public List<Paciente> ObtenerPacientes()
        {
            return _pacienteDAO.ObtenerPacientes();
        }

        public List<Paciente> BuscarPacientes(string filtro)
        {
            return _pacienteDAO.BuscarPacientes(filtro);
        }

        public bool ActualizarPaciente(Paciente paciente)
        {
            return _pacienteDAO.ActualizarPaciente(paciente);
        }

        public bool Eliminar(int id)
        {
            return _pacienteDAO.EliminarPaciente(id);
        }
        
        public Paciente ObtenerPacientePorId(int id)
        {
            return _pacienteDAO.ObtenerPacientePorId(id);
        }

        public Paciente ObtenerPacientePorDNI(string dni)
        {
            return _pacienteDAO.ObtenerPacientePorDNI(dni);
        }


    }
}

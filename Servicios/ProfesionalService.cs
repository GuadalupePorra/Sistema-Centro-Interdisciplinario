using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class ProfesionalService
    {
        private readonly ProfesionalDAO _profesionalDAO;

        public ProfesionalService()
        {
            _profesionalDAO = new ProfesionalDAO();
        }
        public bool InsertarProfesional(Profesional profesional, out string mensaje)
        {
            if(_profesionalDAO.ExisteDni(profesional.DNI))
            {
                mensaje = "Error. El DNI ingresado ya pertenece a un profesional registrado.";
                return false;
            }
            bool insertado = _profesionalDAO.InsertarProfesional(

                profesional.Nombre,
                profesional.Apellido,
                profesional.DNI,
                profesional.Telefono,
                profesional.IdEspecialidad
            );
            mensaje = insertado ? "Paciente agregado correctamente." : "Error al agregar el paciente.";
            return insertado;
        }

        public List<Profesional> ObtenerProfesionales(bool soloActivos = true)
        {
            return _profesionalDAO.ObtenerProfesionales(soloActivos);
        }

        public List<Profesional> BuscarProfesionales(string filtro)
        {
            return _profesionalDAO.BuscarProfesionales(filtro);
        }

        public bool CambiarEstado(int id, bool nuevoEstado)
        {
            return _profesionalDAO.CambiarEstadoProfesional(id, nuevoEstado);
        }

        public bool ActualizarProfesional(Profesional profesional)
        {
            return _profesionalDAO.ActualizarProfesional(profesional);
        }

        public Profesional ObtenerProfesionalPorId(int id)
        {
            return _profesionalDAO.ObtenerProfesionalPorId(id);
        }

        public List<Profesional> ObtenerProfesionalesConSeleccion()
        {
            var lista = _profesionalDAO.ObtenerProfesionales();

            lista.Insert(0, new Profesional
            {
                Id = 0,
                NombreEspecialidad = "- Seleccionar profesional - -"
            });

            return lista;
        }

    }
}

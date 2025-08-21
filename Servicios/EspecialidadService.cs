using SCI.DAO;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Servicios
{
    public class EspecialidadService
    {
        private readonly EspecialidadDAO _dao;
        private readonly ProfesionalDAO _profesionalDAO;


        public EspecialidadService()
        {
            _dao = new EspecialidadDAO();
            _profesionalDAO = new ProfesionalDAO();
        }

        public bool InsertarEspecialidad(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            return _dao.InsertarEspecialidad(nombre);
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            var lista = _dao.ObtenerEspecialidades();
            return lista;
        }

        public bool EliminarEspecialidad(int id)
        {
            return _dao.Eliminar(id);
        }

        public bool EspecialidadTieneProfesionales(int idEspecialidad)
        {
            return _profesionalDAO.ExisteProfesionalConEspecialidad(idEspecialidad);
        }

    }
}

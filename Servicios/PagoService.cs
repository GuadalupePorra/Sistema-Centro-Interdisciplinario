using SCI.DAO;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class PagoService
    {
        private readonly PagoDAO _pagoDAO;
        private readonly PacienteDAO _pacienteDAO;
        private readonly ProfesionalDAO _profesionalDAO;
        private readonly TurnosDAO _turnosDAO;
        private readonly EspecialidadDAO _especialidadDAO;

        public PagoService()
        {
            _pagoDAO = new PagoDAO();
            _pacienteDAO = new PacienteDAO();
            _profesionalDAO = new ProfesionalDAO();
            _turnosDAO = new TurnosDAO();
            _especialidadDAO = new EspecialidadDAO();
        }

        // 1. Obtener pagos con múltiples filtros
        public List<PagoVista> ObtenerPagosFiltrados(
            string periodo = "",
            string filtroPaciente = "",
            string especialidad = "",
            int? idProfesional = null,
            int limite = 20,
            int offset = 0)
            {
            return _pagoDAO.ObtenerPagosFiltrados(
                periodo,
                filtroPaciente,
                especialidad,
                idProfesional,
                limite,
                offset
);
        }


        // 2. Registrar pago (con lógica de negocio)
        public bool RegistrarPago(Pago pago)
        {
            return _pagoDAO.RegistrarPagoYActualizarTurno(pago);
        }

        // 3. Obtener especialidades (opcional, si querés centralizar)
        /*public List<string> ObtenerEspecialidades()
        {
            return _profesionalDAO.ObtenerEspecialidades();
        }*/

        // 4. Buscar pacientes (por nombre o dni)
        public List<Paciente> BuscarPacientes(string filtro)
        {
            return _pacienteDAO.BuscarPacientes(filtro);
        }

        public List<Profesional> ObtenerProfesionales()
        {
            return _profesionalDAO.ObtenerProfesionales();
        }
        public Profesional ObtenerProfesionalPorId(int id)
        {
            return _profesionalDAO.ObtenerProfesionalPorId(id);
        }
        public List<Especialidad> ObtenerEspecialidades()
        {
            var lista = _especialidadDAO.ObtenerEspecialidades();

            lista.Insert(0, new Especialidad
            {
                ID = 0,
                Nombre = "- - Seleccionar profesional - -"
            });

            return lista;
        }

        public List<TurnoVista> ObtenerTurnosConfirmadosPorDNI(string dni)
        {
            return _turnosDAO.ObtenerTurnosConfirmadosPorDNI(dni);
        }
    }

        

}

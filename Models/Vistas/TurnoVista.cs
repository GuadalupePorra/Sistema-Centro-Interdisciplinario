using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class TurnoVista
    {
        public int IdTurno { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public string DniPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string TelefonoPaciente { get; set; }
        public string NombreProfesional { get; set; }
        public string Especialidad { get; set; }
        public string Estado { get; set; }



    }
}

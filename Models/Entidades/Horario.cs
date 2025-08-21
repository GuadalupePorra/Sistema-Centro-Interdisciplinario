using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Horario
    {
        public int IdHorario{ get; set; }
        public int ProfesionalId { get; set; }
        public string NombreProfesional { get; set; }  // nombre completo
        public string Especialidad { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public int DuracionMinutos { get; set; }

        //public string Mostrar => $"Día: {DiaSemana} - {HoraDesde:hh\\:mm} a {HoraHasta:hh\\:mm}";

        public static bool SeSuperpone(TimeSpan desde1, TimeSpan hasta1, TimeSpan desde2, TimeSpan hasta2)
        {
            return desde1 < hasta2 && desde2 < hasta1;
        }
    }

}

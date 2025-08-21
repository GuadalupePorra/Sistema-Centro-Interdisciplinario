using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class PagoVista
    {
        public string IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MedioPago { get; set; }

        public string NombrePaciente { get; set; }
        public string DniPaciente { get; set; }

        public string NombreProfesional { get; set; }

        public string Especialidad { get; set; }

        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraTurno { get; set; }
        public string RutaRecibo { get; set; }
    }

}

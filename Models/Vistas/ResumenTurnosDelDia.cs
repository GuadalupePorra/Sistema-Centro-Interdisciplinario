using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Models.Vistas
{
    public class ResumenTurnosDelDia
    {
        public int Total { get; set; }
        public int Confirmados { get; set; }
        public int Pendientes { get; set; }
        public int Cancelados { get; set; }
        public int Pagados { get; set; }
    }

}

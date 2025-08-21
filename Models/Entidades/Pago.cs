using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdTurno { get; set; }
        public DateTime FechaPago { get; set; }
        private decimal _monto;
        public decimal Monto
        {
            get => _monto;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El monto debe ser mayor a cero.");
                _monto = value;
            }
        }
        public string MedioPago { get; set; }
        public string RutaRecibo { get; set; }
        


        public Pago(int idTurno, DateTime fechaPago, decimal monto, string medioPago)
        {
            IdTurno = idTurno;
            FechaPago = fechaPago;
            Monto = monto;
            MedioPago = medioPago;
        }

        // Constructor vacío opcional para usar con ORMs, Dapper, etc.
        public Pago() { }
    }
}

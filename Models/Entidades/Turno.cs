using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class Turno
    {
        private int _idTurno;
        private int _idProfesional;
        private int _idPaciente;
        private DateTime _fecha;
        private TimeSpan _horaInicio;
        private TimeSpan _horaFin;
        private string _rutaRecibo;
        public Turno(int idProfesional, int idPaciente, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            _idProfesional = idProfesional;
            _idPaciente = idPaciente;
            _fecha = fecha;
            _horaInicio = horaInicio;
            _horaFin = horaFin;
        }

        public int IDTurno { get => _idTurno; set => _idTurno = value; }
        public int IDProfesional { get => _idProfesional; set => _idProfesional = value; }
        public int IDPaciente { get => _idPaciente; set => _idPaciente = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public TimeSpan HoraInicio { get => _horaInicio; set => _horaInicio = value; }
        public TimeSpan HoraFin { get => _horaFin; set => _horaFin = value; }
        public string RutaRecibo { get => _rutaRecibo; set =>_rutaRecibo = value; }

    }
}

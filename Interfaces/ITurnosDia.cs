using SCI.Models.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Interfaces
{
    public  interface ITurnosDia
    {
        void MostrarTurnos(List<TurnoVista> turnos);
        void MostrarMensaje(string mensaje);
        void MostrarResumen(ResumenTurnosDelDia resumen);
        void MostrarProfesionales(List<Profesional> profesionales);


    }
}

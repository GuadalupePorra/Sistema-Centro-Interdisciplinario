using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public interface IHorarioService
    {
        List<Horario> ObtenerHorarioProfesional(int profesionalId);
    }
}

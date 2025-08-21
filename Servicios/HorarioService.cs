using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class HorarioService : IHorarioService
    {
        private readonly HorarioDAO _dao;

        public HorarioService()
        {
            _dao = new HorarioDAO();
        }

        public List<Horario> ObtenerHorarioProfesional(int profesionalId)
        {
            return _dao.ObtenerHorariosPorProfesional(profesionalId);
        }
    }
}

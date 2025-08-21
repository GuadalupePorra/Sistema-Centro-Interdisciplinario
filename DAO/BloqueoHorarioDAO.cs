using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    public class BloqueoHorario
    {
        public int IdProfesional { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
    }

    internal class BloqueoHorarioDAO
    {
        public void InsertarBloqueo(int profId, DateTime fecha, TimeSpan horaDesde, TimeSpan horaHasta, string motivo)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = @"INSERT INTO bloqueo_horario (prf_id, fecha, hora_desde, hora_hasta, motivo)
                         VALUES (@prf_id, @fecha, @hora_desde, @hora_hasta, @motivo)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prf_id", profId);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                cmd.Parameters.AddWithValue("@hora_desde", horaDesde);
                cmd.Parameters.AddWithValue("@hora_hasta", horaHasta);
                cmd.Parameters.AddWithValue("@motivo", motivo);

                cmd.ExecuteNonQuery();
            }
        }


        public List<BloqueoHorario> ObtenerBloqueosPorProfesional(int idProfesional)
        {
            var bloqueos = new List<BloqueoHorario>();

            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT prf_id, fecha, motivo
                             FROM bloqueo_horario
                             WHERE prf_id = @prf_id
                             ORDER BY fecha";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prf_id", idProfesional);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var bloqueo = new BloqueoHorario
                        {
                            IdProfesional = reader.GetInt32("prf_id"),
                            Fecha = reader.GetDateTime("fecha"),
                            Motivo = reader.GetString("motivo")
                        };
                        bloqueos.Add(bloqueo);
                    }
                }
            }

            return bloqueos;
        }


    }
}

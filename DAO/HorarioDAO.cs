using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    internal class HorarioDAO
    {
        private Conexion conexion = new Conexion();



        //GUARDAR
        public bool GuardarHorarios(List<Horario> horarios)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                try
                {
                    foreach (var h in horarios)
                    {
                        string query = @"INSERT INTO horario_profesional 
                                (prof_id, dia_semana, hora_desde, hora_hasta, duracion_minutos)
                                VALUES (@prof, @dia, @desde, @hasta, @duracion)";

                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@prof", h.ProfesionalId);
                            cmd.Parameters.AddWithValue("@dia", h.DiaSemana);
                            cmd.Parameters.AddWithValue("@desde", h.HoraDesde);
                            cmd.Parameters.AddWithValue("@hasta", h.HoraHasta);
                            cmd.Parameters.AddWithValue("@duracion", h.DuracionMinutos);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public int ContarHorariosPorDia(int profesionalId, string dia)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM horario_profesional WHERE prof_id = @id AND dia_semana = @dia";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", profesionalId);
                    cmd.Parameters.AddWithValue("@dia", dia);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool ExisteSuperposicion(int profesionalId, string dia, TimeSpan nuevoDesde, TimeSpan nuevoHasta)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT hora_desde, hora_hasta FROM horario_profesional WHERE prof_id = @id AND dia_semana = @dia";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", profesionalId);
                    cmd.Parameters.AddWithValue("@dia", dia);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan desdeExistente = TimeSpan.Parse(reader["hora_desde"].ToString());
                            TimeSpan hastaExistente = TimeSpan.Parse(reader["hora_hasta"].ToString());

                            if (Horario.SeSuperpone(nuevoDesde, nuevoHasta, desdeExistente, hastaExistente))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool ExisteSuperposicionExcluyendoActual(MySqlConnection conn, int profesionalId, string dia, TimeSpan desde, TimeSpan hasta, int idHorarioActual)
        {
                string query = @"
            SELECT hora_desde, hora_hasta
            FROM horario_profesional
            WHERE prof_id = @id AND dia_semana = @dia AND id_horario_profesional != @idActual";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", profesionalId);
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@idActual", idHorarioActual);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeSpan desdeExistente = TimeSpan.Parse(reader["hora_desde"].ToString());
                        TimeSpan hastaExistente = TimeSpan.Parse(reader["hora_hasta"].ToString());

                        if (Horario.SeSuperpone(desde, hasta, desdeExistente, hastaExistente))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool VerificarSuperposicionAlActualizar(int profesionalId, string dia, TimeSpan desde, TimeSpan hasta, int idHorarioActual)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                return ExisteSuperposicionExcluyendoActual(conn, profesionalId, dia, desde, hasta, idHorarioActual);
            }
        }



        /*/
                public List<Horario> ObtenerTodosLosHorarios()
                {
                    List<Horario> horarios = new List<Horario>();

                    using (var conn = new Conexion().ObtenerConexion())
                    {
                        string query = @"SELECT 
                                    hp.prof_id, 
                                    CONCAT(p.apellido, ', ', p.nombre) AS nombre_apellido,
                                    p.especialidad, 
                                    hp.dia_semana, 
                                    hp.hora_desde, 
                                    hp.hora_hasta, 
                                    hp.duracion_minutos
                                 FROM 
                                    horario_profesional hp
                                 JOIN 
                                    profesional p ON hp.prof_id = p.id_profesional
                                 ORDER BY 
                                    p.apellido, p.nombre, hp.dia_semana";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Horario horario = new Horario
                            {
                                ProfesionalId = reader.GetInt32("prof_id"),
                                NombreProfesional = reader.GetString("nombre_apellido"),
                                Especialidad = reader.GetString("especialidad"),
                                DiaSemana = reader.GetString("dia_semana"),
                                HoraDesde = reader.GetTimeSpan("hora_desde"),
                                HoraHasta = reader.GetTimeSpan("hora_hasta"),
                                DuracionMinutos = reader.GetInt32("duracion_minutos")
                            };

                            horarios.Add(horario);
                        }
                    }

                    return horarios;
                }/*/

        public List<Horario> ObtenerHorariosPorProfesional(int idProfesional)
        {
            List<Horario> horarios = new List<Horario>();

            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT 
                            hp.id_horario_profesional,
                            hp.prof_id, 
                            CONCAT(p.apellido, ', ', p.nombre) AS nombre_apellido,
                            e.especialidad AS especialidad, 
                            hp.dia_semana, 
                            hp.hora_desde, 
                            hp.hora_hasta, 
                            hp.duracion_minutos
                        FROM 
                            horario_profesional hp
                        JOIN 
                            profesional p ON hp.prof_id = p.id_profesional
                        JOIN 
                            especialidades e ON p.id_especialidad = e.id_especialidad

                        WHERE 
                            hp.prof_id = @IDProfesional
                        ORDER BY 
                            p.apellido, p.nombre, hp.dia_semana";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDProfesional", idProfesional);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Horario horario = new Horario
                    {
                        IdHorario = reader.GetInt32("id_horario_profesional"), // 👈 Faltaba esto
                        ProfesionalId = reader.GetInt32("prof_id"),
                        NombreProfesional = reader.GetString("nombre_apellido"),
                        Especialidad = reader.GetString("especialidad"),
                        DiaSemana = reader.GetString("dia_semana"),
                        HoraDesde = reader.GetTimeSpan("hora_desde"),
                        HoraHasta = reader.GetTimeSpan("hora_hasta"),
                        DuracionMinutos = reader.GetInt32("duracion_minutos")
                    };

                    horarios.Add(horario);
                }
            }

            return horarios;
        }

        //ACTUALIZAR
        public bool ActualizarHorario(Horario horario)
        {
            try
            {
                using (var conn = new Conexion().ObtenerConexion())
                {
                    if (ExisteSuperposicionExcluyendoActual(conn, horario.ProfesionalId, horario.DiaSemana, horario.HoraDesde, horario.HoraHasta, horario.IdHorario))
                    {
                        // Opcional: lanzar excepción o devolver falso
                        return false;
                    }

                    string queryActualizar = @"
                    UPDATE horario_profesional
                    SET
                        dia_semana = @DiaSemana,
                        hora_desde = @HoraDesde,
                        hora_hasta = @HoraHasta,
                        duracion_minutos = @DuracionMinutos
                    WHERE
                        id_horario_profesional = @IdHorario";

                    using (var cmd = new MySqlCommand(queryActualizar, conn))
                    {
                        cmd.Parameters.AddWithValue("@DiaSemana", horario.DiaSemana);
                        cmd.Parameters.AddWithValue("@HoraDesde", horario.HoraDesde);
                        cmd.Parameters.AddWithValue("@HoraHasta", horario.HoraHasta);
                        cmd.Parameters.AddWithValue("@DuracionMinutos", horario.DuracionMinutos);
                        cmd.Parameters.AddWithValue("@IdHorario", horario.IdHorario);

                        int filas = cmd.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        //ELIMINAR
        public bool EliminarHorario(int id)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "DELETE FROM horario_profesional WHERE id_horario_profesional = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar horario: " + ex.Message);
                return false;
            }
        }


    }
}

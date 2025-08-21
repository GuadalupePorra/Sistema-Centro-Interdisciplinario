using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using SCI.Interfaces;
using SCI.Models.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace SCI
{
    //AGREGAR
    internal class TurnosDAO
    {
        public void AgendarTurno(Turno turno)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = @"INSERT INTO turno 
                             (profesional_id, paciente_id, fecha, hora_inicio, hora_fin) 
                             VALUES (@IDProfesional, @idPaciente, @fecha, @horaInicio, @horaFin)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDProfesional", turno.IDProfesional);
                    cmd.Parameters.AddWithValue("@idPaciente", turno.IDPaciente);
                    cmd.Parameters.AddWithValue("@fecha", turno.Fecha.Date);
                    cmd.Parameters.AddWithValue("@horaInicio", turno.HoraInicio);
                    cmd.Parameters.AddWithValue("@horaFin", turno.HoraFin);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //OBTENER
        public List<TimeSpan> ObtenerHorariosOcupados(int idProfesional, DateTime fecha)
        {
            List<TimeSpan> horariosOcupados = new List<TimeSpan>();

            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT hora_inicio 
                                FROM turno 
                                WHERE profesional_id = @IDProfesional 
                                AND fecha = @fecha
                                AND estado <> 'CANCELADO'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDProfesional", idProfesional);
                    cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())  
                        {
                            horariosOcupados.Add(reader.GetTimeSpan("hora_inicio"));
                        }
                    }
                }
            }

            return horariosOcupados;
        }
        /*
        public List<TurnoVista> ObtenerTodosLosTurnos(int cantidad)
        {
            List<TurnoVista> lista = new List<TurnoVista>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT t.id_turno,
                                t.fecha,
                                t.hora_inicio,
                                p.dni,
                                CONCAT(p.apellido, ', ', p.nombre) AS nombre_paciente,
                                p.telefono,
                                CONCAT(pr.apellido, ', ', pr.nombre) AS nombre_profesional,
                                pr.especialidad,
                                t.estado
                             FROM turno t
                             INNER JOIN paciente p ON t.paciente_id = p.id_paciente
                             INNER JOIN profesional pr ON t.profesional_id = pr.id_profesional
                             LIMIT @cantidad";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TurnoVista t = new TurnoVista
                            {
                                IdTurno = reader.GetInt32("id_turno"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraInicio = reader.GetTimeSpan("hora_inicio"),
                                DniPaciente = reader.GetString("dni"),
                                NombrePaciente = reader.GetString("nombre_paciente"),
                                TelefonoPaciente = reader.GetString("telefono"),
                                NombreProfesional = reader.GetString("nombre_profesional"),
                                Especialidad = reader.GetString("especialidad"),
                                Estado = reader.GetString("estado")
                            };

                            lista.Add(t);
                        }
                    }
                }
            }

            return lista;
        }*/

        public List<TurnoVista> ObtenerTurnosConfirmadosPorDNI(string dni)
        {
            List<TurnoVista> lista = new List<TurnoVista>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT t.id_turno,
                                t.fecha,
                                t.hora_inicio,
                                p.dni,
                                CONCAT(p.apellido, ', ', p.nombre) AS nombre_paciente,
                                p.telefono,
                                CONCAT(pr.apellido, ', ', pr.nombre) AS nombre_profesional,
                                e.especialidad AS especialidad,
                                t.estado
                             FROM turno t
                             INNER JOIN paciente p ON t.paciente_id = p.id_paciente
                             INNER JOIN profesional pr ON t.profesional_id = pr.id_profesional
                             INNER JOIN especialidades e ON pr.id_especialidad = e.id_especialidad
                             WHERE p.dni = @dni AND t.estado = 'CONFIRMADO'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TurnoVista turno = new TurnoVista
                            {
                                IdTurno = reader.GetInt32("id_turno"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraInicio = reader.GetTimeSpan("hora_inicio"),
                                DniPaciente = reader.GetString("dni"),
                                NombrePaciente = reader.GetString("nombre_paciente"),
                                TelefonoPaciente = reader.GetString("telefono"),
                                NombreProfesional = reader.GetString("nombre_profesional"),
                                Especialidad = reader.GetString("especialidad"),
                                Estado = reader.GetString("estado")
                            };

                            lista.Add(turno);
                        }
                    }
                }
            }

            return lista;
        }

        public List<TurnoVista> ObtenerTurnosDeHoy()
        {
            List<TurnoVista> lista = new List<TurnoVista>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT t.id_turno,
                                t.fecha,
                                t.hora_inicio,
                                p.dni AS dni_paciente,
                                CONCAT(p.apellido, ', ', p.nombre) AS nombre_paciente,
                                p.telefono AS telefono_paciente,
                                CONCAT(pr.apellido, ', ', pr.nombre) AS nombre_profesional,
                                e.especialidad AS especialidad,
                                t.estado AS estado_turno
                                
                         FROM turno t
                         INNER JOIN paciente p ON t.paciente_id = p.id_paciente
                         INNER JOIN profesional pr ON t.profesional_id = pr.id_profesional
                         INNER JOIN especialidades e ON pr.id_especialidad = e.id_especialidad
                         WHERE t.fecha = @fechaHoy
                         ORDER BY t.hora_inicio";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaHoy", DateTime.Today);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TurnoVista turno = new TurnoVista
                            {
                                IdTurno = reader.GetInt32("id_turno"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraInicio = reader.GetTimeSpan("hora_inicio"),
                                DniPaciente = reader.GetString("dni_paciente"),
                                NombrePaciente = reader.GetString("nombre_paciente"),
                                TelefonoPaciente = reader.GetString("telefono_paciente"),
                                NombreProfesional = reader.GetString("nombre_profesional"),
                                Especialidad = reader.GetString("especialidad"),
                                Estado = reader.GetString("estado_turno")
                            };

                            lista.Add(turno);
                        }
                    }
                }
            }

            return lista;
        }

        public List<TurnoVista> ObtenerTurnosDeHoyPorProfesional(int idProfesional)
        {
            var turnos = new List<TurnoVista>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT t.id_turno,
                                t.fecha,
                                t.hora_inicio,
                                p.dni AS dni_paciente,
                                CONCAT(p.apellido, ', ', p.nombre) AS nombre_paciente,
                                p.telefono AS telefono_paciente,
                                CONCAT(pr.apellido, ', ', pr.nombre) AS nombre_profesional,
                                e.especialidad AS especialidad,
                                t.estado AS estado_turno

                         FROM turno t
                         INNER JOIN paciente p ON t.paciente_id = p.id_paciente
                         INNER JOIN profesional pr ON t.profesional_id = pr.id_profesional
                         INNER JOIN especialidades e ON pr.id_especialidad = e.id_especialidad
                         WHERE t.fecha = @fechaHoy
                         ORDER BY t.hora_inicio";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProfesional);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TurnoVista turno = new TurnoVista
                            {
                                IdTurno = reader.GetInt32("id_turno"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraInicio = reader.GetTimeSpan("hora_inicio"),
                                DniPaciente = reader.GetString("dni_paciente"),
                                NombrePaciente = reader.GetString("nombre_paciente"),
                                TelefonoPaciente = reader.GetString("telefono_paciente"),
                                NombreProfesional = reader.GetString("nombre_profesional"),
                                Especialidad = reader.GetString("especialidad"),
                                Estado = reader.GetString("estado_turno")
                            };
                        }
                    }
                }
            }

            return turnos;
        }



        //FILTRAR

        public List<TurnoVista> ObtenerTurnosFiltrados(string estado = null, string periodo = null, int cantidad = 50, string dniPaciente = null)
        {
            List<TurnoVista> lista = new List<TurnoVista>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                List<string> condiciones = new List<string>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                string query = @"SELECT t.id_turno,
                                t.fecha,
                                t.hora_inicio,
                                p.dni,
                                CONCAT(p.apellido, ', ', p.nombre) AS nombre_paciente,
                                p.telefono,
                                CONCAT(pr.apellido, ', ', pr.nombre) AS nombre_profesional,
                                e.especialidad AS especialidad,
                                t.estado
                         FROM turno t
                         INNER JOIN paciente p ON t.paciente_id = p.id_paciente
                         INNER JOIN profesional pr ON t.profesional_id = pr.id_profesional
                         INNER JOIN especialidades e ON pr.id_especialidad = e.id_especialidad
                         WHERE 1=1 ";

                // Filtro por estado
                if (!string.IsNullOrEmpty(estado))
                {
                    condiciones.Add("t.estado = @estado");
                    cmd.Parameters.AddWithValue("@estado", estado);
                }

                // Filtro por período
                if (!string.IsNullOrEmpty(periodo))
                {
                    DateTime desde = DateTime.MinValue;
                    DateTime hasta = DateTime.MaxValue;

                    switch (periodo.ToUpper())
                    {
                        case "DIARIO":
                            desde = hasta = DateTime.Today;
                            break;
                        case "SEMANAL":
                            int diff = (int)DateTime.Today.DayOfWeek;
                            desde = DateTime.Today.AddDays(-diff);
                            hasta = desde.AddDays(6);
                            break;
                        case "MENSUAL":
                            desde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                            hasta = desde.AddMonths(1).AddDays(-1);
                            break;
                    }

                    condiciones.Add("t.fecha BETWEEN @desde AND @hasta");
                    cmd.Parameters.AddWithValue("@desde", desde.Date);
                    cmd.Parameters.AddWithValue("@hasta", hasta.Date);
                }

                // ✅ Filtro por DNI del paciente
                if (!string.IsNullOrWhiteSpace(dniPaciente))
                {
                    condiciones.Add("p.dni LIKE @dniPaciente ");
                    cmd.Parameters.AddWithValue("@dniPaciente", $"{dniPaciente}%");
                }


                // Agregar condiciones al query
                if (condiciones.Count > 0)
                    query += " AND " + string.Join(" AND ", condiciones);

                query += " ORDER BY t.fecha DESC, t.hora_inicio ASC";
                query += " LIMIT @cantidad";

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TurnoVista t = new TurnoVista
                        {
                            IdTurno = reader.GetInt32("id_turno"),
                            Fecha = reader.GetDateTime("fecha"),
                            HoraInicio = reader.GetTimeSpan("hora_inicio"),
                            DniPaciente = reader.GetString("dni"),
                            NombrePaciente = reader.GetString("nombre_paciente"),
                            TelefonoPaciente = reader.GetString("telefono"),
                            NombreProfesional = reader.GetString("nombre_profesional"),
                            Especialidad = reader.GetString("especialidad"),
                            Estado = reader.GetString("estado")
                        };

                        lista.Add(t);
                    }
                }
            }

            return lista;
        }




        //ACTUALIZAR
        public void ActualizarEstado(int idTurno, string nuevoEstado)
        {
            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                try
                {
                    string query = "UPDATE turno SET estado = @estado WHERE id_turno = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id", idTurno);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            MessageBox.Show("No se encontró el turno para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el estado del turno:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public TurnoVista ObtenerTurnoVistaPorId(int idTurno)
        {
            var query = @"SELECT t.id_turno, t.fecha, t.hora_inicio, t.estado,
                         p.dni, p.nombre AS NombrePaciente, p.telefono,
                         pr.nombre AS NombreProfesional, e.especialidad AS Especialidad
                  FROM turno t
                  JOIN paciente p ON t.paciente_id = p.id_paciente
                  JOIN Profesional pr ON t.Profesional_id = pr.id_profesional
                  JOIN especialidades e ON pr.id_especialidad = e.id_especialidad
                  WHERE t.id_turno = @id";

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idTurno);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TurnoVista
                        {
                            IdTurno = reader.GetInt32("id_turno"),
                            Fecha = reader.GetDateTime("fecha"),
                            HoraInicio = reader.GetTimeSpan("hora_inicio"),
                            DniPaciente = reader.GetString("dni"),
                            Estado = reader.GetString("estado"),
                            NombrePaciente = reader.GetString("NombrePaciente"),
                            TelefonoPaciente = reader.GetString("telefono"),
                            NombreProfesional = reader.GetString("NombreProfesional"),
                            Especialidad = reader.GetString("Especialidad")
                        };
                    }
                }
            }
            return null;
        }




    }
}

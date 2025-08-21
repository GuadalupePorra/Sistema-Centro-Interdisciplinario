using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI
{
    internal class ProfesionalDAO
    {
        private Conexion conexion = new Conexion();

        private Profesional MapearProfesional(MySqlDataReader reader)
        {
            return new Profesional
            {
                Id = Convert.ToInt32(reader["id_profesional"]),
                Nombre = reader["nombre"].ToString(),
                Apellido = reader["apellido"].ToString(),
                DNI = reader["dni"].ToString(),
                Telefono = reader["telefono"].ToString(),
                IdEspecialidad = Convert.ToInt32(reader["id_especialidad"]),
                NombreEspecialidad = reader["nombre_especialidad"]?.ToString(),
                Activo = reader.GetBoolean("activo")
            };
        }

        //AGREGAR
        public bool InsertarProfesional(string nombre, string apellido, string dni, string telefono, int idEspecialidad)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "INSERT INTO profesional (nombre, apellido, dni, telefono, id_especialidad) " +
                                   "VALUES (@nombre, @apellido, @dni, @telefono, @idEspecialidad)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar profesional: " + ex.Message);
                return false;
            }
        }

        public bool ExisteDni(string dni)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM profesional WHERE dni = @dni";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        //BUSCAR
        public List<Profesional> BuscarProfesionales(string filtro, bool soloActivos = true)
        {
            List<Profesional> lista = new List<Profesional>();

            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    // Construir la base de la consulta
                    string query = @"SELECT * FROM profesional 
                             WHERE (UPPER(apellido) LIKE @filtro 
                                 OR UPPER(dni) LIKE @filtro ";

                    // Agregar filtro por activos si se requiere
                    if (soloActivos)
                        query += " AND activo = TRUE";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro.ToUpper() + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(MapearProfesional(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar profesionales: " + ex.Message);
            }

            return lista;
        }


        //OBTENER
        public List<Profesional> ObtenerProfesionales(bool soloActivos = true)
        {
            List<Profesional> lista = new List<Profesional>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = @"SELECT p.*, e.especialidad AS nombre_especialidad
                 FROM profesional p
                 JOIN especialidades e ON p.id_especialidad = e.id_especialidad";

                if (soloActivos)
                    query += " WHERE activo = TRUE";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearProfesional(reader));
                    }
                }
            }

            return lista;
        }

        /*public List<string> ObtenerEspecialidades()
        {
            var especialidades = new List<string>();

            using (var conn = new Conexion().ObtenerConexion())
            {
                string sql = "SELECT DISTINCT especialidad FROM profesional ORDER BY especialidad";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        especialidades.Add(reader["especialidad"].ToString());
                    }
                }
            }

            return especialidades;
        }*/


        public Profesional ObtenerProfesionalPorId(int id)
        {
            Profesional profesional = null;

            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = @"SELECT p.*, e.especialidad AS nombre_especialidad
                         FROM profesional p
                         JOIN especialidades e ON p.id_especialidad = e.id_especialidad
                         WHERE p.id_profesional = @id";                                              

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                profesional = MapearProfesional(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener profesional: " + ex.Message);
            }

            return profesional;
        }

        public bool ExisteProfesionalConEspecialidad(int idEspecialidad)
        {
            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                var query = "SELECT COUNT(*) FROM Profesional WHERE id_especialidad = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idEspecialidad);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }



        //CAMBIAR ESTADOC
        public bool CambiarEstadoProfesional(int id, bool activo)
        {
            using (var conn = new Conexion().ObtenerConexion())
            {
                string query = "UPDATE profesional SET activo = @activo WHERE id_profesional = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@activo", activo);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        //ACUALIZAR
        public bool ActualizarProfesional(Profesional profesional)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = @"UPDATE profesional SET 
                                nombre = @nombre,
                                apellido = @apellido,
                                dni = @dni,
                                telefono = @telefono,
                            WHERE id_profesional = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", profesional.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", profesional.Apellido);
                        cmd.Parameters.AddWithValue("@dni", profesional.DNI);
                        cmd.Parameters.AddWithValue("@telefono", profesional.Telefono);
                        cmd.Parameters.AddWithValue("@id_especialidad", profesional.IdEspecialidad);
                        cmd.Parameters.AddWithValue("@id", profesional.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar profesional: " + ex.Message);
                return false;
            }
        }

    }


}



using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCI
{
    internal class PacienteDAO
    {
        private Conexion conexion = new Conexion();

        private Paciente MapearPaciente(MySqlDataReader reader)
        {
            return new Paciente
            {
                Id = Convert.ToInt32(reader["id_paciente"]),
                Nombre = reader["nombre"].ToString(),
                Apellido = reader["apellido"].ToString(),
                DNI = reader["dni"].ToString(),
                Edad = reader["edad"].ToString(),
                FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                Telefono = reader["telefono"].ToString(),
                ObraSocial = reader["obra_social"].ToString(),
            };
        }

        //INSERTAR
        public bool InsertarPaciente(string nombre, string apellido, string dni, string edad, DateTime fechaNacimiento, string telefono, string obraSocial)
        {
            try
            {
                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    string query = "INSERT INTO paciente (nombre, apellido, dni, edad,fecha_nacimiento, telefono,  obra_social) " +
                                   "VALUES (@nombre, @apellido, @dni,@edad, @fechaNacimiento, @telefono,@obraSocial)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@obraSocial", obraSocial);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar paciente: " + ex.Message);
                return false;
            }
        }

        public bool ExisteDni(string dni)
        {
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM paciente WHERE dni = @dni";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        //OBTENER
        public List<Paciente> ObtenerPacientes()
        {
            List<Paciente> lista = new List<Paciente>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT * FROM paciente";
                query += " ORDER BY id_paciente DESC LIMIT 20"; // <-- Agregado

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearPaciente(reader));
                    }
                }
            }

            return lista;
        }
        public Paciente ObtenerPacientePorId(int id)
        {
            Paciente paciente = null;

            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "SELECT * FROM paciente WHERE id_paciente = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               paciente = MapearPaciente(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener paciente: " + ex.Message);
            }

            return paciente;
        }
        public Paciente ObtenerPacientePorDNI(string dni)
        {
            var query = @"SELECT id_paciente, dni, nombre, apellido, Telefono
                  FROM paciente
                  WHERE dni = @dni";

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Paciente
                        {
                            Id = Convert.ToInt32(reader["id_paciente"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            DNI = reader["dni"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                        };
                    }
                }
            }
            return null;
        }
        //BUSCAR
        public List<Paciente> BuscarPacientes(string filtro)
        {
            List<Paciente> lista = new List<Paciente>();

            try 
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = @"SELECT * FROM paciente 
                                     WHERE UPPER (apellido) LIKE @filtro
                                        OR UPPER (dni) LIKE @filtro";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", filtro + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(MapearPaciente(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar paciente: " + ex.Message);
            }

            return lista;
        }
        //ACTUALIZAR
        public bool ActualizarPaciente(Paciente paciente)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = @"UPDATE paciente SET 
                                nombre = @nombre,
                                apellido = @apellido,
                                dni = @dni,
                                edad= @edad,
                                fecha_nacimiento = @fecha_nacimiento,
                                telefono = @telefono,
                                obra_social = @obra_social
                                
                            WHERE id_paciente = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                        cmd.Parameters.AddWithValue("@dni", paciente.DNI);
                        cmd.Parameters.AddWithValue("@edad", paciente.Edad);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", paciente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                        cmd.Parameters.AddWithValue("@obra_social", paciente.ObraSocial);
                        cmd.Parameters.AddWithValue("@id", paciente.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar paciente: " + ex.Message);
                return false;
            }
        }
        //ELIMINAR
        public  bool EliminarPaciente(int id)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "DELETE FROM paciente WHERE id_paciente = @id";
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
                Console.WriteLine("Error al eliminar el paciente: " + ex.Message);
                return false;
            }
        }

    }
}

using MySql.Data.MySqlClient;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.DAO
{
    public class EspecialidadDAO
    {
        public List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> lista = new List<Especialidad>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT * FROM especialidades";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Especialidad
                        {
                            ID = Convert.ToInt32(reader["id_especialidad"]),
                            Nombre = reader["especialidad"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
        public bool InsertarEspecialidad(string nombre)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {

                    string query = "INSERT INTO especialidades (especialidad) " +
                                   "VALUES (@especialidad)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@especialidad", nombre);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar especialidad: " + ex.Message);
                return false;
            }
        }

        public bool ExisteEspecialidad(string nombre)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "SELECT COUNT(*) FROM especialidades WHERE especialidad = @nombre";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar existencia de la especialidad: " + ex.Message);
                return true;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "DELETE FROM especialidades WHERE id_especialidad = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la especialidad: " + ex.Message);
                return false;
            }

        }
        
    }
}

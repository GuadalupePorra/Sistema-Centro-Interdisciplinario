using MySql.Data.MySqlClient;
using SCI.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.DAO
{
    internal class UsuarioSistemaDAO
    {
        private Conexion conexion = new Conexion();

        public bool InsertarUsuario(string usuario, string contraseña, string rol, string nombre)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {

                    string query = "INSERT INTO usuario_sistema (usuario, contraseña, rol, nombre) " +
                                   "VALUES (@usuario, @contraseña, @rol, @nombre)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
                return false;
            }
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "SELECT COUNT(*) FROM usuario_sistema WHERE usuario = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", nombreUsuario);

                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar existencia de usuario: " + ex.Message);
                return true; 
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conn = new Conexion().ObtenerConexion())
            {
                string query = "SELECT * FROM usuario_sistema";
                
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            ID = Convert.ToInt32(reader["id_usuario"]),
                            NombreUsuario = reader["usuario"].ToString(),
                            Rol = reader["rol"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            
                        });
                    }
                }
            }

            return lista;
        }

        //ACTUALIZAR
        public bool ActualizarUsuario(int id, string usuario, string contraseña, string rol, string nombre)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "UPDATE usuario_sistema SET usuario = @usuario, contraseña = @contraseña, rol = @rol, nombre = @nombre " +
                                   "WHERE id_usuario = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar usuario: " + ex.Message);
                return false;
            }
        }
        //ELIMINAR
        public bool EliminarUsuario(int id)
        {
            try
            {
                using (MySqlConnection conn = new Conexion().ObtenerConexion())
                {
                    string query = "DELETE FROM usuario_sistema WHERE id_usuario = @id";

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
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                return false;
            }
        }

    }
}

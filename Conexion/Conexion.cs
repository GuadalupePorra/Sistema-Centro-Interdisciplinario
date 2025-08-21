using System;
using MySql.Data.MySqlClient;


namespace SCI
{
    public class Conexion
    {
        private string connectionString = "server=localhost;port=3306;user=root;password=159753;database=sci;";
        private  MySqlConnection connection = null;

        public  MySqlConnection ObtenerConexion()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

    }
}

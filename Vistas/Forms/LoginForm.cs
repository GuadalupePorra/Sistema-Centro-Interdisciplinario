using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using Mysqlx;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using SCI.Vistas.Forms;
using SCI.Models.Entidades;

namespace SCI
{
    public partial class LoginForm : Form
    {
        public Usuario UsuarioAutenticado { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                Conexion miConexion = new Conexion();

                using (MySqlConnection conexion = miConexion.ObtenerConexion())
                {
                    string query = "SELECT rol, nombre FROM usuario_sistema WHERE usuario = @usuario AND contraseña = @contraseña";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rol = reader["rol"].ToString();
                                string nombre = reader["nombre"].ToString();

                                MessageBox.Show($"Bienvenido {nombre} ({rol})");

                                UsuarioAutenticado = new Usuario
                                {
                                    Nombre = nombre,
                                    Rol = rol
                                };

                                // Indicás al Main que el login fue exitoso
                                this.DialogResult = DialogResult.OK;
                                this.Close(); // Esto cierra el login y vuelve a Program.cs
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos.");
                                txtUsuario.Clear();
                                txtContraseña.Clear();
                                txtUsuario.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        

 


    }
}

using SCI.Models.Entidades;
using SCI.Vistas.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SCI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true) // Bucle principal de sesión
            {
                Usuario usuarioAutenticado = null;

                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        usuarioAutenticado = loginForm.UsuarioAutenticado;
                    }
                    else
                    {
                        // Si se cierra el login, salimos del programa
                        break;
                    }
                }

                if (usuarioAutenticado != null)
                {
                    Form formPrincipal;

                    if (usuarioAutenticado.Rol == "Administrador")
                        formPrincipal = new AdminForm(usuarioAutenticado);
                    else
                        formPrincipal = new MenuPrincipalForm(usuarioAutenticado);

                    Application.Run(formPrincipal);
                }
            }
        }
    }
}

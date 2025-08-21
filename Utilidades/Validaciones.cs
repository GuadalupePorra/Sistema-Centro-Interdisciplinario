using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public static class Validaciones
    {
        public static void SoloLetras(object sender, KeyPressEventArgs e, ErrorProvider errorProvider)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MostrarError(sender, "Este campo solo admite letras", errorProvider);
            }
            else
            {
                LimpiarError(sender, errorProvider);
            }
        }


        public static void SoloNumeros(object sender, KeyPressEventArgs e, int maxLength, ErrorProvider errorProvider)
        {
            if (sender is TextBox textBox)
            {
                if (!char.IsControl(e.KeyChar) && textBox.Text.Length >= maxLength)
                {
                    e.Handled = true;
                    MostrarError(textBox, $"Máximo {maxLength} dígitos permitidos.", errorProvider);
                    return;
                }

                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MostrarError(textBox, "Este campo solo admite números", errorProvider);
                }
                else
                {
                    LimpiarError(textBox, errorProvider);
                }
            }
        }


        private static void MostrarError(object sender, string mensaje, ErrorProvider errorProvider)
        {
            if (sender is TextBox textBox && errorProvider != null)
            {
                errorProvider.SetError(textBox, mensaje);
            }
        }

        private static void LimpiarError(object sender, ErrorProvider errorProvider)
        {
            if (sender is TextBox textBox && errorProvider != null)
            {
                errorProvider.SetError(textBox, "");
            }
        }
    }

}

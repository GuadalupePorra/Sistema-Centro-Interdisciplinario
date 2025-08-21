using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCPaciente : UserControl, IFormularioConCambios
    {
        public UCPaciente()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void AbrirUserControl(UserControl control)
        {
            if (panelPacientes.Controls.Count > 0)
            {
                var actual = panelPacientes.Controls[0];

                var formularioConCambios = BuscarFormularioConCambios(actual);

                if (formularioConCambios != null && formularioConCambios.TieneCambiosSinGuardar())
                {
                    DialogResult resultado = MessageBox.Show(
                        "Hay cambios sin guardar. ¿Seguro que querés salir?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resultado == DialogResult.No)
                        return;
                }
            }
            panelPacientes.Controls.Clear(); // Limpia el panel
            panelPacientes.Controls.Add(control); // Agrega el nuevo control
        }

        //FORM CON CAMBIOS-
        private IFormularioConCambios BuscarFormularioConCambios(Control control)
        {
            if (control is IFormularioConCambios conCambios)
                return conCambios;

            foreach (Control hijo in control.Controls)
            {
                var resultado = BuscarFormularioConCambios(hijo);
                if (resultado != null)
                    return resultado;
            }

            return null;
        }
        public bool TieneCambiosSinGuardar()
        {
            if (panelPacientes.Controls.Count > 0)
            {
                var controlActual = panelPacientes.Controls[0];
                var conCambios = BuscarFormularioConCambios(controlActual);
                return conCambios != null && conCambios.TieneCambiosSinGuardar();
            }

            return false;
        }

        private void UCPaciente_Load(object sender, EventArgs e)
        {

        }

        private void panelPacientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregarPac_Click(object sender, EventArgs e)
        {
            UCFormularioPersona panelAdd = new UCFormularioPersona(TipoPersona.Paciente);

            AbrirUserControl(panelAdd);
        }

        private void btnPacRegistrados_Click(object sender, EventArgs e)
        {
            UCVerPacientes panelVerPac = new UCVerPacientes(AbrirUserControl);
            AbrirUserControl(panelVerPac);
        }
    }
}

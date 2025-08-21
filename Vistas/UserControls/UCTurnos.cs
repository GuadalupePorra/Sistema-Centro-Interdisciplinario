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
    public partial class UCProfesionale : UserControl, IFormularioConCambios
    {
        public UCProfesionale()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void AbrirUserControl(UserControl control)
        {
            if (PanelTurnos.Controls.Count > 0)
            {
                var actual = PanelTurnos.Controls[0];

                var formularioConCambios = BuscarFormularioConCambios(actual);

                if (formularioConCambios != null && formularioConCambios.TieneCambiosSinGuardar())
                {
                    DialogResult resultado = MessageBox.Show(
                        "Hay cambios sin guardar. ¿Seguro que desea salir?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resultado == DialogResult.No)
                        return;
                }
            }

            PanelTurnos.Controls.Clear();
            PanelTurnos.Controls.Add(control);
            control.Dock = DockStyle.Fill;
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
            if (PanelTurnos.Controls.Count > 0)
            {
                var controlActual = PanelTurnos.Controls[0];
                var conCambios = BuscarFormularioConCambios(controlActual);
                return conCambios != null && conCambios.TieneCambiosSinGuardar();
            }

            return false;
        }

        private void UCProfesionale_Load(object sender, EventArgs e)
        {

        }

        private void BtnAsignarTurno_Click(object sender, EventArgs e)
        {
            UCAgendarTurno agendarTurno = new UCAgendarTurno();
            AbrirUserControl(agendarTurno);
        }

        private void btnTurnosRegistrados_Click(object sender, EventArgs e)
        {
            UCVerTurnos verTurnos = new UCVerTurnos();
            AbrirUserControl(verTurnos);
        }

        private void PanelTurnos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

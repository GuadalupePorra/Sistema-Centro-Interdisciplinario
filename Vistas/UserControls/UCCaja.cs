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
    public partial class UCCaja : UserControl, IFormularioConCambios
    {
        public UCCaja()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        private void AbrirUserControl(UserControl control)
        {
            if (PanelCaja.Controls.Count > 0)
            {
                var actual = PanelCaja.Controls[0];

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

            PanelCaja.Controls.Clear();
            PanelCaja.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        public void CargarRegistrarPagoConTurno(int idTurno)
        {
            var registrarPago = new UCRegistrarPago(idTurno);
            AbrirUserControl(registrarPago);
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
            if (PanelCaja.Controls.Count > 0)
            {
                var controlActual = PanelCaja.Controls[0];
                var conCambios = BuscarFormularioConCambios(controlActual);
                return conCambios != null && conCambios.TieneCambiosSinGuardar();
            }

            return false;
        }

        private void UCCaja_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            UCRegistrarPago registrarPago = new UCRegistrarPago();
            AbrirUserControl(registrarPago);

        }

        private void BtnPagosRegistrados_Click(object sender, EventArgs e)
        {
            UCVerPagos verPagos = new UCVerPagos();
            AbrirUserControl(verPagos);

        }

        private void PanelCaja_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

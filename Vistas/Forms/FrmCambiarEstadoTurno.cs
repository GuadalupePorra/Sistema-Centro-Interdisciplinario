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
    public partial class FrmCambiarEstadoTurno : Form
    {
        public string EstadoSeleccionado { get; private set; } = null;

        public FrmCambiarEstadoTurno(string infoTurno)
        {
            InitializeComponent();
            LblDatosTurno.Text = infoTurno;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCambiarEstadoTurno_Load(object sender, EventArgs e)
        {

        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            EstadoSeleccionado = "CONFIRMADO";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            EstadoSeleccionado = "CANCELADO";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LblDatosTurno_Click(object sender, EventArgs e)
        {

        }
    }
}

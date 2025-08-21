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
    public partial class UCProfesionales : UserControl, IFormularioConCambios
    {
        public UCProfesionales()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void AbrirUserControl(UserControl control)
        {
            if (panelProfesionales.Controls.Count > 0)
            {
                var actual = panelProfesionales.Controls[0];

                var formularioConCambios = BuscarFormularioConCambios(actual);

                if (formularioConCambios != null && formularioConCambios.TieneCambiosSinGuardar())
                {
                    DialogResult resultado = MessageBox.Show(
                        "Hay cambios sin guardar. ¿Desea salir de todos modos?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resultado == DialogResult.No)
                        return;
                }
            }

            panelProfesionales.Controls.Clear();
            panelProfesionales.Controls.Add(control);
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
            if (panelProfesionales.Controls.Count > 0)
            {
                var controlActual = panelProfesionales.Controls[0];
                var conCambios = BuscarFormularioConCambios(controlActual);
                return conCambios != null && conCambios.TieneCambiosSinGuardar();
            }

            return false;
        }

        private void BtnNuevoProfesional_Click(object sender, EventArgs e)
        {
            UCFormularioPersona panelForm = new UCFormularioPersona(TipoPersona.Profesional);

            AbrirUserControl(panelForm);
        }

        private void panelProfesionales_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        { 
            UCConfigrurarHorario panelAgenda = new UCConfigrurarHorario();

            AbrirUserControl(panelAgenda);
        }

        private void BtnDisponibilidad_Click(object sender, EventArgs e)
        {
            UCVerHorarios panelHorarios = new UCVerHorarios();

            AbrirUserControl(panelHorarios);

        }

        private void BtnProfRegistrados_Click(object sender, EventArgs e)
        {
            UCVerProfesionales panelVerProfesionales = new UCVerProfesionales(AbrirUserControl);

            AbrirUserControl(panelVerProfesionales);
        }
    }
}

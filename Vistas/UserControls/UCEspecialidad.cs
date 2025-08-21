using SCI.DAO;
using SCI.Interfaces;
using SCI.Models.Entidades;
using SCI.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI.Vistas.UserControls
{
    public partial class UCEspecialidad : UserControl, IEspecialidad
    {
        private EspecialidadPresenter _presenter;
        public UCEspecialidad()
        {
            InitializeComponent();
            _presenter = new EspecialidadPresenter(this);
        }

        public string NombreEspecialidad => txtEspecialidad.Text;

        public void MostrarMensaje(string mensaje, string titulo = "Información")
        {
            MessageBox.Show(mensaje);
        }

        public void MostrarEspecialidad(List<Especialidad> especialidades)
        {
            dgvEspecialidad.DataSource = null;
            dgvEspecialidad.DataSource = especialidades;
        }


        public void LimpiarFormulario()
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            btnAgregarEspecialidad.Visible = false;
            groupBox1.Visible = true;
            txtEspecialidad.Text = ""; // limpio el campo por si había algo
            txtEspecialidad.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            btnAgregarEspecialidad.Visible = true;
        }

        private void UCEspecialidad_Load(object sender, EventArgs e)
        {
            dgvEspecialidad.AutoGenerateColumns = false;
            _presenter.CargarEspecialidad();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _presenter.AgregarEspecialidad();
        }

        private void dgvEspecialidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEspecialidad.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                // Obtenés el ID de la especialidad seleccionada
                int id = Convert.ToInt32(dgvEspecialidad.Rows[e.RowIndex].Cells["ID"].Value);
                string nombre = dgvEspecialidad.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                var confirm = MessageBox.Show($"¿Está seguro de que desea eliminar '{nombre}'?",
                                              "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    _presenter.EliminarEspecialidad(id);
                }
            }
        }

        private void dgvEspecialidad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEspecialidad.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                e.CellStyle.BackColor = Color.Firebrick;
                e.CellStyle.ForeColor = Color.White;

            }
        }
    }
}

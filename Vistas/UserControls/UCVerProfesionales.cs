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
    public partial class UCVerProfesionales : UserControl, IVerProfesionales
    {
        private readonly Action<UserControl> cargarUC;
        private readonly VerProfesionalesPresenter _presenter;

        public UCVerProfesionales(Action<UserControl> cargarUC)
        {
            InitializeComponent();
            this.cargarUC = cargarUC;

            var service = new ProfesionalService();
            _presenter = new VerProfesionalesPresenter(this, service);
        }

        public string FiltroBusqueda => TxtFiltrar.Text;

        public void MostrarProfesionales(List<Profesional>profesionales)
        {
            DgvProfesionales.Rows.Clear();

            foreach (var prof in profesionales)
            {
                DgvProfesionales.Rows.Add(
                    prof.Id,
                    $"{prof.Apellido}, {prof.Nombre}",  // Nombre y apellido en una sola celda
                    prof.NombreEspecialidad,
                    prof.DNI,
                    prof.Telefono,
                    prof.Activo ? "Activo" : "Inactivo",
                    "Editar",
                    prof.Activo ? "Dar de baja" : "Dar de alta"

                );
            }
            DgvProfesionales.ClearSelection();
        }

        public int? ObtenerIdProfesionalSeleccionado()
        {
            if (DgvProfesionales.SelectedRows.Count == 0)
                return null;

            return Convert.ToInt32(DgvProfesionales.SelectedRows[0].Cells["id"].Value);
        }

        /*private void FiltrarProfesionales(string filtro)
        {
            var dao = new ProfesionalDAO();
            List<Profesional> listaFiltrada = dao.BuscarProfesionales(filtro.ToUpper());

            DgvProfesionales.Rows.Clear();

            foreach (var prof in listaFiltrada)
            {
                DgvProfesionales.Rows.Add(
                    prof.Id,
                    $"{prof.Apellido}, {prof.Nombre}",  
                    prof.Especialidad,
                    prof.DNI,
                    prof.Telefono
                );
                
            }
           
        }*/

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        public bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public bool FiltrarSoloActivos()
        {
            return chkActivos.Checked;
        }


        private void UCVerProfesionales_Load(object sender, EventArgs e)
        {
            _presenter.CargarProfesionales();

        }

        private void DgvProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idSeleccionado = Convert.ToInt32(DgvProfesionales.Rows[e.RowIndex].Cells["id"].Value);

            if (DgvProfesionales.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                if (ConfirmarAccion("¿Está seguro que desea editar al profesional seleccionado?"))
                {
                    var formulario = new UCFormularioPersona(idSeleccionado, TipoPersona.Profesional, cargarUC);
                    cargarUC?.Invoke(formulario);
                }
            }

            if (DgvProfesionales.Columns[e.ColumnIndex].Name == "btnEstado")
            {
                string estadoActual = DgvProfesionales.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                _presenter.CambiarEstadoProfesional(idSeleccionado, estadoActual == "Activo");
            }
        }

        


        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            _presenter.FiltrarProfesionales();

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DgvProfesionales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvProfesionales.Columns[e.ColumnIndex].Name == "btnEstado" && e.RowIndex >= 0)
            {
                string estado = DgvProfesionales.Rows[e.RowIndex].Cells["estado"].Value?.ToString();

                if (estado == "Activo")
                    e.Value = "Dar de baja";
                else
                    e.Value = "Dar de alta";

                e.FormattingApplied = true;
            }
            if (DgvProfesionales.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                e.CellStyle.BackColor = Color.LightSeaGreen;
                e.CellStyle.ForeColor = Color.White;
            }
            if (DgvProfesionales.Columns[e.ColumnIndex].Name == "btnEstado")
            {
                string estado = DgvProfesionales.Rows[e.RowIndex].Cells["estado"].Value?.ToString();

                if (estado == "Activo")
                {
                    // Dar de baja
                    e.CellStyle.BackColor = Color.Firebrick;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Dar de alta
                    e.CellStyle.BackColor = Color.DarkSlateGray;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.CargarProfesionales();
        }
    }

}



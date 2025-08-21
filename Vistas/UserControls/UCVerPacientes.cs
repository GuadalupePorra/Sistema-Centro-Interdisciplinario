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
    public partial class UCVerPacientes : UserControl, IVerPacientes

    {
        private readonly Action<UserControl> cargarUC;
        private VerPacientesPresenter _presenter;
        public UCVerPacientes(Action<UserControl> cargarUC)
        {
            InitializeComponent();
            this.cargarUC = cargarUC;

            var service = new PacienteService();
            _presenter = new VerPacientesPresenter(this, service);

        }

        public string FiltroBusqueda => txtFiltrar.Text;

        public void MostrarPacientes(List<Paciente> pacientes)
        {
            DgvPaciente.Rows.Clear();
            foreach (var pac in pacientes)
            {
                DgvPaciente.Rows.Add(
                    pac.Id,
                    $"{pac.Apellido}, {pac.Nombre}",
                    pac.DNI,
                    pac.Edad,
                    pac.FechaNacimiento.ToString("dd/MM/yyyy"),
                    pac.Telefono,
                    pac.ObraSocial

                );
                
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public int? ObtenerIdPacienteSeleccionado()
        {
            if (DgvPaciente.SelectedRows.Count == 0)
                return null;

            return Convert.ToInt32(DgvPaciente.SelectedRows[0].Cells["ID"].Value);
        }

        private void FiltrarPacientes(string filtro)
        {
            var dao = new PacienteDAO();
            List<Paciente> listaFiltrada = dao.BuscarPacientes(filtro.ToUpper());

            DgvPaciente.Rows.Clear();

            foreach (var pac in listaFiltrada)
            {
                DgvPaciente.Rows.Add(
                    pac.Id,
                    $"{pac.Apellido}, {pac.Nombre}",  // Nombre y apellido en una sola celda
                    pac.DNI,
                    pac.Edad,
                    pac.FechaNacimiento.ToString(@"dd/MM/yyyy"),
                    pac.Telefono,
                    pac.ObraSocial
                );
            }
        }

        private void DgvPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(DgvPaciente.Rows[e.RowIndex].Cells["ID"].Value);

            if (DgvPaciente.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                if (ConfirmarAccion("¿Está seguro que desea editar la informacion del paciente seleccionado?"))
                {
                    var formulario = new UCFormularioPersona(id, TipoPersona.Paciente, cargarUC);
                    cargarUC?.Invoke(formulario);
                }
            }
            if (DgvPaciente.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                if (ConfirmarAccion("¿Está seguro que desea eliminar al paciente seleccionado?"))
                {
                    _presenter.EliminarPaciente(id);
                }
            }


        }

        private void UCVerPacientes_Load(object sender, EventArgs e)
        {
            _presenter.CargarPacientes();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            _presenter.FiltrarPacientes();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void DgvPaciente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(DgvPaciente.Rows[e.RowIndex].Cells["ID"].Value);

            if (DgvPaciente.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                e.CellStyle.BackColor = Color.Teal;
                e.CellStyle.ForeColor = Color.White;
            }

            if (DgvPaciente.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                e.CellStyle.BackColor = Color.Firebrick;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void DgvPaciente_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = DgvPaciente.Columns[e.ColumnIndex];

                if (col.Name == "btnEditar")
                    e.ToolTipText = "Editar información del paciente";
                else if (col.Name == "btnEliminar")
                    e.ToolTipText = "Eliminar este paciente";
            }
        }
    }
}

using SCI.Interfaces;
using SCI.Models.Vistas;
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
    public partial class UCTurnosDelDia : UserControl, ITurnosDia
    {
        private readonly TurrnosDiaPresenter _presenter;
        public event Action<int> PagoTurnoSolicitado;//para redirigirme a registrar pago


        public UCTurnosDelDia()
        {
            InitializeComponent();
            _presenter = new TurrnosDiaPresenter(this);
        }
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MostrarResumen(ResumenTurnosDelDia resumen)
        {
            lblTotalTurnos.Text = $"Turnos del dia: {resumen.Total}";
            lblPendientes.Text = $"Pendientes: {resumen.Pendientes}";
            lblConfirmados.Text = $"Confirmados: {resumen.Confirmados}";
            lblCancelados.Text = $"Cancelados: {resumen.Cancelados}";
            lblPagados.Text = $"Pagados: {resumen.Pagados}";
        }


        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProfesional.SelectedItem is Profesional seleccionado && seleccionado.Id != 0)
            {
                _presenter.CargarTurnosDeHoyPorProfesional(seleccionado.Id);
            }
            else
            {
                _presenter.CargarTurnosDeHoy(); // sin filtro
            }
        }

        public void MostrarTurnos(List<TurnoVista> turnos)
        {
           dgvTD.AutoGenerateColumns = false;

            dgvTD.DataSource = turnos;
            dgvTD.ClearSelection();
        }

        public void MostrarProfesionales(List<Profesional> profesionales)
        {
            cboProfesional.DisplayMember = "Mostrar";
            cboProfesional.ValueMember = "Id";
            cboProfesional.DataSource = profesionales;
        }


        private void UCTurnosDelDia_Load(object sender, EventArgs e)
        {
            _presenter.CargarTurnosDeHoy();
            _presenter.CargarProfesionales();
        }


        private void dgvTD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var fila = dgvTD.Rows[e.RowIndex];
            string estadoActual = dgvTD.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

            if (dgvTD.Columns[e.ColumnIndex].Name == "btnCambiarEstado" && e.RowIndex >= 0)
            {
                if (estadoActual == "CANCELADO" || estadoActual == "PAGADO")
                {
                    MessageBox.Show("No se puede modificar el estado de un turno cancelado o pagado.",
                                    "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idTurno = Convert.ToInt32(fila.Cells["ID"].Value);
                string paciente = fila.Cells["Paciente"].Value.ToString();
                string dni = fila.Cells["DNI"].Value.ToString();
                string profesional = fila.Cells["Profesional"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                string fechaFormateada = fecha.ToString("dd/MM/yyyy");
                string hora = fila.Cells["Hora"].Value.ToString();

                string info = $"Turno de {paciente} DNI: {dni}\nProfesional: {profesional}\nEl {fechaFormateada} a las {hora}";

                var resultado = MessageBox.Show("¿Cambiar estado del turno?\nActual: " + estadoActual,
                                                "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    var form = new FrmCambiarEstadoTurno(info);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string nuevoEstado = form.EstadoSeleccionado;
                        _presenter.CambiarEstadoTurno(idTurno, nuevoEstado); 

                        fila.Cells["Estado"].Value = nuevoEstado; 
                    }
                }
            }

            if (dgvTD.Columns[e.ColumnIndex].Name == "btnRegistrarPago" && e.RowIndex >= 0)
            {
                if (estadoActual == "PAGADO")
                {
                    MessageBox.Show("Este turno ya fue pagado.", "Acción no permitida",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (estadoActual != "CONFIRMADO")
                {
                    MessageBox.Show("Solo se puede registrar el pago de turnos confirmados.",
                                    "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idTurno = Convert.ToInt32(fila.Cells["ID"].Value);
                string dni = fila.Cells["DNI"].Value.ToString();

                TurnoVista turno = _presenter.ObtenerTurnoPorId(idTurno);
                Paciente paciente = _presenter.ObtenerPacientePorDNI(dni);

                if (turno == null || paciente == null)
                {
                    MostrarMensaje("No se pudo obtener la información del turno o paciente.");
                    return;
                }

                var ucPago = new UCRegistrarPago(idTurno);
                ucPago.MostrarDatosTurno(turno, paciente);

                PagoTurnoSolicitado?.Invoke(idTurno);
            }
        }

        private void dgvTD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTD.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                switch (estado)
                {
                    case "PENDIENTE":
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.SelectionBackColor = Color.Gold;

                        break;
                    case "CONFIRMADO":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.SelectionBackColor = Color.LightGreen;

                        break;
                    case "CANCELADO":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.SelectionBackColor = Color.LightCoral;
                        break;
                    case "PAGADO":
                        e.CellStyle.BackColor = Color.LightGray;
                        break;



                }
            }
        }
    }
}

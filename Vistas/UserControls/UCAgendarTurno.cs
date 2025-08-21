using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace SCI
{
    public partial class UCAgendarTurno : System.Windows.Forms.UserControl, IAgendarTurno, IFormularioConCambios
    {
        private Paciente pacienteElegido;
        private Profesional profesionalElegido;
        private AgendarTurnoPresenter _presenter;
        private System.Windows.Forms.Button slotSeleccionado = null;
        private string horaSeleccionada;
        private DateTime fechaSeleccionada;
        private bool _hayCambios;

        public UCAgendarTurno()
        {
            InitializeComponent();
            monthCalendar1.MinDate = DateTime.Today;
            _presenter = new AgendarTurnoPresenter(this);
            CargarProfesionales();

        }

        public string BusquedaPaciente => TxtPaciente.Text.Trim();
        public string BusquedaProfesional => cboProfesional.Text.Trim();
        public bool TieneCambiosSinGuardar()
        {
            return _hayCambios;
        }
        private void CargarProfesionales()
        {

            var lista = new ProfesionalDAO().ObtenerProfesionales();

            lista.Insert(0, new Profesional
            {
                Id = 0,

                NombreEspecialidad = "- Seleccionar profesional - -"
            });

            cboProfesional.DisplayMember = "Mostrar";
            cboProfesional.ValueMember = "Id";
            cboProfesional.DataSource = lista;
        }
        public void MostrarPacientes(List<Paciente> pacientes)
        {
            if (pacientes == null || pacientes.Count == 0)
            {
                LstResultadosPaciente.Visible = false;
                LstResultadosPaciente.DataSource = null;
                return;
            }

            if (pacientes.Count > 10)
            {
                MessageBox.Show("Demasiados resultados. Ingresá más dígitos para refinar la búsqueda.");
                LstResultadosPaciente.Visible = false;
                LstResultadosPaciente.DataSource = null;
                return;
            }

            LstResultadosPaciente.Visible = true;
            LstResultadosPaciente.DataSource = pacientes;
            LstResultadosPaciente.DisplayMember = "Mostrar";
            LstResultadosPaciente.ValueMember = "Id";
        }


        public void MostrarHorariosProfesional(string resumenHorarios)
        {
            LblHorariosProfesional.Text = resumenHorarios;
            LblHorariosProfesional.Visible = true;
        }

        public void MostrarMensajeSinSlots()
        {
            FlpSlotsTurno.Controls.Clear();

            var lbl = new System.Windows.Forms.Label
            {
                Text = "No hay turnos disponibles para esta fecha.",
                AutoSize = true
            };

            FlpSlotsTurno.Controls.Add(lbl);
        }


        public void MostrarSlots(List<(TimeSpan desde, TimeSpan hasta)> slots)
        {
            FlpSlotsTurno.Controls.Clear();

            foreach (var slot in slots)
            {
                var btnSlot = new Button
                {
                    Text = $"{slot.desde:hh\\:mm} - {slot.hasta:hh\\:mm}",
                    Width = 100,
                    Height = 40,
                    Tag = slot.desde
                };

                btnSlot.Click += BtnSlot_Click; // ← asegurate de tener este handler aún

                FlpSlotsTurno.Controls.Add(btnSlot);
            }
        }
        
        public bool Confirmar(string mensaje)
        {
            var resultado = MessageBox.Show(mensaje, "Confirmar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resultado == DialogResult.Yes;
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ConfirmarSeleccionSlot(string mensaje, Action onConfirmar)
        {
            var confirm = MessageBox.Show(mensaje, "Confirmar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                onConfirmar?.Invoke();
            }
        }

       public void LimpiarCampos()
        {
            TxtPaciente.Clear();
            //cboProfesional.Items.Clear();
            TxtPaciente.ReadOnly = false;

            pacienteElegido = null;
            profesionalElegido = null;

            LstResultadosPaciente.DataSource = null;
            LstResultadosPaciente.Visible = false;

            LblHorariosProfesional.Text = "";
            LblHorariosProfesional.Visible = false;

            FlpSlotsTurno.Controls.Clear();

            BtnCambiarPaciente.Visible = false;

            slotSeleccionado = null;
            horaSeleccionada = null;
            fechaSeleccionada = default;

            TxtPaciente.Focus();
        }


        private void ActualizarVistaProfesional(Profesional nuevoProfesional)
        {
            profesionalElegido = nuevoProfesional;

            FlpSlotsTurno.Controls.Clear();

           _presenter.ObtenerHorarioProfesional(nuevoProfesional.Id);
        }

        public void ConfirmarCambioProfesional(Action onConfirmado)
        {
            var resultado = MessageBox.Show("¿Estás seguro que querés cambiar el profesional seleccionado?",
                             "Confirmar cambio",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
                onConfirmado?.Invoke();
        }

        public void ConfirmarCambioPaciente(Action onConfirmado)
        {
            var resultado = MessageBox.Show("¿Estás seguro que querés cambiar el paciente seleccionado?",
                                             "Confirmar cambio",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
                onConfirmado?.Invoke();
        }

        public void LimpiarVistaProfesional()
        {
            cboProfesional.Items.Clear();
            profesionalElegido = null;

            LblHorariosProfesional.Text = "";
            LblHorariosProfesional.Visible = false;

            FlpSlotsTurno.Controls.Clear();
            _hayCambios = false;

        }

        public void LimpiarVistaPaciente()
        {
            TxtPaciente.Text = "";
            pacienteElegido = null;
            TxtPaciente.ReadOnly = false;
            TxtPaciente.Focus();
            LstResultadosPaciente.Visible = false;
            _hayCambios = false;
        }
        public Paciente PacienteSeleccionado => pacienteElegido;

        public Profesional ProfesionalSeleccionado => profesionalElegido;

        public string HoraSeleccionada
        {
            get => horaSeleccionada;
            set => horaSeleccionada = value;
        }

        public DateTime FechaSeleccionada
        {
            get => fechaSeleccionada;
            set => fechaSeleccionada = value;
        }

        private void BtnSlot_Click(object sender, EventArgs e)
        {
            if (sender is Button btnSlot)
            {
                string hora = btnSlot.Text;
                string fecha = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                TimeSpan horaDesde = (TimeSpan)btnSlot.Tag;

                // Llamás al presenter para que maneje la lógica de confirmación
                _presenter.SeleccionarSlot(hora, monthCalendar1.SelectionStart, () =>
                {
                    // Esta acción se ejecuta solo si el usuario confirma
                    if (slotSeleccionado != null)
                        slotSeleccionado.Enabled = true;

                    btnSlot.Enabled = false;
                    slotSeleccionado = btnSlot;
                });
            }
        }

        private void UCAgendarTurno_Load(object sender, EventArgs e)
        {

        }

        private void TxtPaciente_TextChanged(object sender, EventArgs e)
        {
            _presenter.BuscarPacientes(BusquedaPaciente);

        }

        private void LstResultadosPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LstResultadosPaciente_DoubleClick(object sender, EventArgs e)
        {
            if (LstResultadosPaciente.SelectedItem is Paciente pacienteSeleccionado)
            {
                TxtPaciente.Text = pacienteSeleccionado.Mostrar;
                TxtPaciente.ReadOnly = true;
                pacienteElegido = pacienteSeleccionado;

                LstResultadosPaciente.Visible = false;
                BtnCambiarPaciente.Visible = true;
                _hayCambios = true;
            }
        }

        private void BtnCambiarPaciente_Click(object sender, EventArgs e)
        {
            _presenter.CambiarPaciente();
        
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date < DateTime.Today)
            {
                MessageBox.Show("No se pueden ver turnos en fechas anteriores a hoy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (profesionalElegido != null)
                _presenter.CargarSlots(profesionalElegido.Id, e.Start);
        }

        private void BtnAgendar_Click(object sender, EventArgs e)
        {
            _presenter.AgendarTurno();
            _presenter.LimpiarCampos();
        }
        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
            "¿Está seguro que desea cancelar la operación? Se perderán los datos ingresados.",
            "Confirmar cancelación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    _presenter.LimpiarCampos();
                    _hayCambios = false;
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TxtPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(sender, e, 8, errorProvider1);
        }

        private void TxtProfesional_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(sender, e, errorProvider1);
        }

        private void LstResultadosProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblHorariosProfesional_Click(object sender, EventArgs e)
        {

        }

        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProfesional.SelectedItem is Profesional profesional && profesional.Id != 0)
            {
                // Confirmar si ya hay un profesional seleccionado
                if (profesionalElegido != null && profesionalElegido.Id != profesional.Id)
                {
                    ConfirmarCambioProfesional(() =>
                    {
                        ActualizarVistaProfesional(profesional);
                        // Mostrar horarios
                        _presenter.ObtenerHorarioProfesional(profesional.Id);
                        // Cargar slots para la fecha actual seleccionada
                        _presenter.CargarSlots(profesional.Id, monthCalendar1.SelectionStart);
                    });

                    return;
                }

                // Si aún no había profesional seleccionado
                ActualizarVistaProfesional(profesional);
                _presenter.ObtenerHorarioProfesional(profesional.Id);
                _presenter.CargarSlots(profesional.Id, monthCalendar1.SelectionStart);
            }
        }
    }
}

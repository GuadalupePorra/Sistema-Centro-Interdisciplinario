using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCRegistrarPago : UserControl, IRegistrarPago, IFormularioConCambios
    {
        private Paciente pacienteElegido;   
        private RegistrarPagoPresenter _presenter;
        private int? _idTurno = null;
        private bool _hayCambios;

        public UCRegistrarPago()
        {
            InitializeComponent();
            _presenter = new RegistrarPagoPresenter(this);
            
        }

        // ✅ Constructor para cuando SÍ se seleccionó turno
        public UCRegistrarPago(int idTurno)
        {
            InitializeComponent();
            _idTurno = idTurno;
            _presenter = new RegistrarPagoPresenter(this);
            _presenter.CargarDatosPago(idTurno); // carga datos específicos
        }
        public string DNI => TxtDNI.Text.Trim();
        public decimal Monto => decimal.TryParse(TxtMonto.Text, out var m) ? m : 0;
        public string MedioPagoSeleccionado => CbxFormaPago.SelectedItem?.ToString() ?? "";
        public bool TieneCambiosSinGuardar()
        {
            return _hayCambios;
        }
        private void UCRegistrarPago_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void MostrarPacientes(List<Paciente> pacientes)
        {
            if (pacientes == null || !pacientes.Any())
            {
                LstResultadosPaciente.Visible = false;
                LstResultadosPaciente.DataSource = null;
                return;
            }

            LstResultadosPaciente.DataSource = pacientes;
            LstResultadosPaciente.DisplayMember = "Mostrar";
            LstResultadosPaciente.ValueMember = "Id";
            LstResultadosPaciente.Visible = true;
        }

        public void MostrarTurnos(List<TurnoVista> turnos)
        {
            DgvDatosTurno.AutoGenerateColumns = false;
            DgvDatosTurno.DataSource = turnos;
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public void LimpiarCampos()
        {
            TxtDNI.Clear();
            TxtDNI.ReadOnly = false;
            LstResultadosPaciente.DataSource = null;
            DgvDatosTurno.DataSource = null;
            pacienteElegido = null;
            BtnCambiarPaciente.Visible = false;
            _hayCambios = false;
        }

        public void BloquearBusquedaPaciente(bool bloquear)
        {
            TxtDNI.ReadOnly = bloquear;
            LstResultadosPaciente.Visible = false;
        }

        public void MostrarBotonCambiarPaciente(bool visible)
        {
            BtnCambiarPaciente.Visible = visible;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (DgvDatosTurno.SelectedRows.Count == 0)
            {
                errorProvider1.SetError(DgvDatosTurno, "Debe seleccionar un turno.");
                esValido = false;
            }

            if (Monto <= 0)
            {
                errorProvider1.SetError(TxtMonto, "Ingrese un monto válido mayor a cero.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(MedioPagoSeleccionado))
            {
                errorProvider1.SetError(CbxFormaPago, "Seleccione una forma de pago.");
                esValido = false;
            }

            if (!esValido)
                return;

            var turno = (TurnoVista)DgvDatosTurno.SelectedRows[0].DataBoundItem;

            var generar = MessageBox.Show("¿Desea generar un recibo en PDF?", "Confirmación", MessageBoxButtons.YesNo);
            string rutaRecibo = null;

            if (generar == DialogResult.Yes)
            {
                string carpeta = @"C:\Users\gudaa\OneDrive\Desktop\SCI\Recibos_pagos";
                Directory.CreateDirectory(carpeta); 
                string archivo = $"Recibo_{turno.NombrePaciente.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                rutaRecibo = Path.Combine(carpeta, archivo);

                try
                {
                    _presenter.GenerarRecibo(
                        rutaRecibo,
                        turno.NombrePaciente,
                        turno.DniPaciente,
                        turno.NombreProfesional,
                        turno.Especialidad,
                        MedioPagoSeleccionado,
                        Monto
                    );
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Ocurrió un error al generar el recibo: " + ex.Message);
                    return;
                }
            }

            _presenter.RegistrarPago(turno, rutaRecibo);
        }

        public void MostrarDatosTurno(TurnoVista turno, Paciente paciente)
        {
            pacienteElegido = paciente;
            TxtDNI.Text = paciente.Mostrar;
            TxtDNI.ReadOnly = true;
            MostrarBotonCambiarPaciente(true); 
            _presenter.SeleccionarPaciente(paciente); 

   
            MostrarTurnos(new List<TurnoVista> { turno });

            if (DgvDatosTurno.Rows.Count > 0)
            {
                DgvDatosTurno.Rows[0].Selected = true;
            }
        }

   


        private void TxtDNI_TextChanged(object sender, EventArgs e)
        {
            _presenter.BuscarPacientes(DNI);
        }

        private void LstResultadosPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LstResultadosPaciente_DoubleClick(object sender, EventArgs e)
        {
            if (LstResultadosPaciente.SelectedItem is Paciente p)
            {
                pacienteElegido = p;
                TxtDNI.Text = p.Mostrar;
                _presenter.SeleccionarPaciente(p);
                _hayCambios = true;
            }
        }

        private void BtnCambiarPaciente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cambiar el paciente elegido?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void TxtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(sender, e, 8, errorProvider1);
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(sender, e, 9, errorProvider1); 
        }
    }
}

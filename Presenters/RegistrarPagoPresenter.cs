using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public class RegistrarPagoPresenter
    {
        private readonly IRegistrarPago _vista;
        private readonly PagoService _service;
        private readonly PacienteService _pacienteService;
        private readonly TurnoService _turnoService;

        public RegistrarPagoPresenter(IRegistrarPago vista)
        {
            _vista = vista;
            _service = new PagoService();
            _pacienteService = new PacienteService();
            _turnoService = new TurnoService();
        }

        public void BuscarPacientes(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro) || filtro.Length < 2)
            {
                _vista.MostrarPacientes(null);
                return;
            }

            var pacientes = _service.BuscarPacientes(filtro);

            if (pacientes.Count > 10 && filtro.Length < 7)
            {
                _vista.MostrarMensaje("Demasiados resultados. Ingresá más dígitos.");
                _vista.MostrarPacientes(null);
                return;
            }

            _vista.MostrarPacientes(pacientes);
        }

        public void SeleccionarPaciente(Paciente paciente)
        {
            var turnos = _service.ObtenerTurnosConfirmadosPorDNI(paciente.DNI);

            if (!turnos.Any())
            {
                _vista.MostrarMensaje("Este paciente no tiene turnos confirmados.");
                _vista.MostrarTurnos(null);
            }
            else
            {
                _vista.MostrarTurnos(turnos);
                _vista.BloquearBusquedaPaciente(true);
                _vista.MostrarBotonCambiarPaciente(true);
            }
        }

        public void CargarDatosPago(int idTurno)
        {
            var turno = _turnoService.ObtenerTurnoVistaPorId(idTurno);
            var paciente = _pacienteService.ObtenerPacientePorDNI(turno.DniPaciente);
            _vista.MostrarDatosTurno(turno, paciente);
        }

        public void RegistrarPago(TurnoVista turno, string rutaRecibo)
        {
            var pago = new Pago
            {
                IdTurno = turno.IdTurno,
                FechaPago = DateTime.Now,
                Monto = _vista.Monto,
                MedioPago = _vista.MedioPagoSeleccionado,
                RutaRecibo = rutaRecibo
            };

            var exito = _service.RegistrarPago(pago); // internamente guarda RutaRecibo

            if (exito)
            {
                _vista.MostrarMensaje("Pago registrado con éxito.");
                _vista.LimpiarCampos();

                if (!string.IsNullOrEmpty(rutaRecibo))
                {
                    var abrir = MessageBox.Show("¿Desea abrir el recibo generado?", "Recibo creado", MessageBoxButtons.YesNo);
                    if (abrir == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(rutaRecibo) { UseShellExecute = true });
                    }
                }
            }
            else
            {
                _vista.MostrarMensaje("Error al registrar el pago.");
            }
        }

        public void GenerarRecibo(
        string ruta,
        string nombrePaciente,
        string dni,
        string profesional,
        string descripcion,
        string formaPago,
        decimal monto)

        {
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;

            var fecha = DateTime.Now.ToString("dd/MM/yyyy");

            var doc = new PdfDocument();
            doc.Info.Title = "Recibo de Pago";
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Arial", 12, XFontStyleEx.Bold);  // funciona sin problemas
            var fontTitle = new XFont("Arial", 16, XFontStyleEx.Bold);

            double y = 40;
            gfx.DrawString("Centro interdisciplinario", fontTitle, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.Center);
            y += 40;
            gfx.DrawString("RECIBO DE PAGO", fontTitle, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.Center);
            y += 40;

            gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y);
            y += 20;

            gfx.DrawString($"Fecha: {fecha}", font, XBrushes.Black, 40, y); y += 25;
            gfx.DrawString($"Paciente: {nombrePaciente}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"DNI: {dni}", font, XBrushes.Black, 40, y); y += 20;

            gfx.DrawString($"Profesional: {profesional}", font, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Descripción: Consulta de {descripcion}", font, XBrushes.Black, 40, y); y += 30;
            gfx.DrawString($"Total: ${monto}", font, XBrushes.Black, 40, y); y += 30;

            gfx.DrawString($"Estado: PAGADO", font, XBrushes.Black, 40, y); y += 30;

            gfx.DrawString($"Forma de pago: {formaPago}", font, XBrushes.Black, 40, y); y += 20;

            gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y); y += 40;

            gfx.DrawString("Firma y sello Profesional: _______________________", font, XBrushes.Black, 40, y); y += 40;

            gfx.DrawString("Gracias por su visita", new XFont("Arial", 10, XFontStyleEx.Bold), XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.Center);

            doc.Save(ruta);

        }

    }

}

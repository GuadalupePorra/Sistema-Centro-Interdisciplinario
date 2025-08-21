using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCBloquearHorario : UserControl
    {
        private readonly string _nombreProfesional;
        private readonly int _idProfesional;

        public UCBloquearHorario(string nombreProfesional, int idProfesional)
        {
            InitializeComponent();
            _nombreProfesional = nombreProfesional;
            _idProfesional = idProfesional;

            this.Load += UCBloquearHorario_Load;
        }

       
        private void GuardarBloqueosDeCalendario(int profId, string motivo)
        {
            var daoHorario = new HorarioDAO();
            var daoBloqueo = new BloqueoHorarioDAO();
            var horarios = daoHorario.ObtenerHorariosPorProfesional(profId);

            DateTime fechaDesde = monthCalendar1.SelectionRange.Start.Date;
            DateTime fechaHasta = monthCalendar1.SelectionRange.End.Date;

            for (DateTime fecha = fechaDesde; fecha <= fechaHasta; fecha = fecha.AddDays(1))
            {
                string diaNombre = fecha.ToString("dddd", new CultureInfo("es-ES")); // ejemplo: "lunes"
                diaNombre = char.ToUpper(diaNombre[0]) + diaNombre.Substring(1).ToLower(); // Capitaliza

                var horariosDelDia = horarios.Where(h => string.Equals(h.DiaSemana, diaNombre, StringComparison.OrdinalIgnoreCase));

                foreach (var h in horariosDelDia)
                {
                    daoBloqueo.InsertarBloqueo(profId, fecha, h.HoraDesde, h.HoraHasta, motivo);
                }
            }

            MessageBox.Show("Bloqueos guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarDatosProfesional(string nombreProfesional, int idProfesional)
        {
            LblDatosProfesional.Text = nombreProfesional;
            LstBloquesHorarios.Items.Clear();

            var dao = new HorarioDAO();
            var horariosProfesional = dao.ObtenerHorariosPorProfesional(idProfesional);

            var ordenDias = new Dictionary<string, int>
        {
            { "Lunes", 1 }, { "Martes", 2 }, { "Miércoles", 3 },
            { "Miercoles", 3 }, { "Jueves", 4 }, { "Viernes", 5 },
            { "Sábado", 6 }, { "Sabado", 6 }, { "Domingo", 7 }
        };

            var agrupado = horariosProfesional
                .GroupBy(h => new { h.HoraDesde, h.HoraHasta, h.DuracionMinutos })
                .Select(g => new
                {
                    Dias = string.Join(", ", g.Select(h => h.DiaSemana)
                                              .OrderBy(d => ordenDias.ContainsKey(d) ? ordenDias[d] : 99)),
                    Desde = g.Key.HoraDesde.ToString(@"hh\:mm"),
                    Hasta = g.Key.HoraHasta.ToString(@"hh\:mm"),
                    Duracion = $"{g.Key.DuracionMinutos} min"
                });

            foreach (var item in agrupado)
            {
                string linea = $"{item.Dias} - {item.Desde} a {item.Hasta} - {item.Duracion}";
                LstBloquesHorarios.Items.Add(linea);
            }
        }

        private bool ValidarFechasSeleccionadas()
        {
            if (monthCalendar1.SelectionRange.Start < DateTime.Today)
            {
                MessageBox.Show("No puedes bloquear fechas pasadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarMotivo()
        {
            if (string.IsNullOrWhiteSpace(TxtMotivo.Text))
            {
                MessageBox.Show("Debes ingresar un motivo para el bloqueo.", "Motivo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }



        private void LblDatosProfesional_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void UCBloquearHorario_Load(object sender, EventArgs e)
        {
            CargarDatosProfesional(_nombreProfesional, _idProfesional);
        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            if(!ValidarFechasSeleccionadas() || !ValidarMotivo())
            return;

            string motivo = TxtMotivo.Text.Trim();
            GuardarBloqueosDeCalendario(_idProfesional, motivo);
        }
    }
}

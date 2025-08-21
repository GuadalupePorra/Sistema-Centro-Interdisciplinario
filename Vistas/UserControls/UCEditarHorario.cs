using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI
{
    public partial class UCEditarHorario : UserControl, IFormularioConCambios
    {
        private int profesionalId;
        private int idHorario;
        private bool cambios = false;


        public UCEditarHorario()
        {
            InitializeComponent();
        }

        public bool TieneCambiosSinGuardar()
        {
            return cambios;
        }

        public void CargarDatos(int idHorario, int profesionalId, string nombreProfesional, string dia, TimeSpan horaInicio, TimeSpan horaFin, int duracion)
        {
            this.idHorario = idHorario;
            this.profesionalId = profesionalId;
            lblProfesional.Text = nombreProfesional;
            lblDia.Text = dia;
            dtpHoraInicio.Value = DateTime.Today.Add(horaInicio);
            dtpHoraFin.Value = DateTime.Today.Add(horaFin);
            numDuracionTurno.Value = duracion;

            cambios = true;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea cancelar la edición y regresar?",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cambios = false;
                var ucVer = new UCVerHorarios(profesionalId);

                var parent = this.Parent;
                parent.Controls.Clear();
                parent.Controls.Add(ucVer);
            }
        }

        private void UCEditarHorario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TimeSpan desde = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan hasta = dtpHoraFin.Value.TimeOfDay;
            int duracion = (int)numDuracionTurno.Value;
            string dia = lblDia.Text;
            var dao = new HorarioDAO();

            if (desde >= hasta)
            {
                MessageBox.Show("La hora de inicio debe ser menor que la de fin.");
                return;
            }

            if (duracion <= 0)
            {
                MessageBox.Show("La duración del turno debe ser mayor a cero.");
                return;
            }

            if (dao.VerificarSuperposicionAlActualizar(profesionalId, dia, desde, hasta, idHorario))
            {
                MessageBox.Show($"El horario ingresado ({desde:hh\\:mm} - {hasta:hh\\:mm}) se superpone con otro ya guardado para el día {dia}.");
                return;
            }

            // ✅ Armamos y actualizamos
            Horario horarioEditado = new Horario
            {
                IdHorario = this.idHorario,
                ProfesionalId = this.profesionalId,
                DiaSemana = dia,
                HoraDesde = desde,
                HoraHasta = hasta,
                DuracionMinutos = duracion
            };

            bool actualizado = dao.ActualizarHorario(horarioEditado);

            if (actualizado)
            {
                MessageBox.Show("Horario actualizado correctamente.");
                var verUC = new UCVerHorarios(profesionalId);
                var parent = this.Parent;
                parent.Controls.Clear();
                parent.Controls.Add(verUC);
            }
            else
            {
                MessageBox.Show("❌ No se pudo actualizar. Verificá que no haya superposición u otros errores.");
            }
        }
    }
}

namespace SCI.Vistas.UserControls
{
    partial class UCTurnosDelDia
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboProfesional = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTD = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCambiarEstado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRegistrarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalTurnos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConfirmados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPendientes = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCancelados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPagados = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTD)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboProfesional
            // 
            this.cboProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesional.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProfesional.FormattingEnabled = true;
            this.cboProfesional.Location = new System.Drawing.Point(278, 62);
            this.cboProfesional.Margin = new System.Windows.Forms.Padding(4);
            this.cboProfesional.Name = "cboProfesional";
            this.cboProfesional.Size = new System.Drawing.Size(246, 27);
            this.cboProfesional.TabIndex = 78;
            this.cboProfesional.SelectedIndexChanged += new System.EventHandler(this.cboProfesional_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Filtrar por profesional:";
            // 
            // dgvTD
            // 
            this.dgvTD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.Hora,
            this.Profesional,
            this.Especialidad,
            this.Paciente,
            this.DNI,
            this.ContactoPaciente,
            this.Estado,
            this.btnCambiarEstado,
            this.btnRegistrarPago});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTD.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTD.Location = new System.Drawing.Point(79, 112);
            this.dgvTD.Name = "dgvTD";
            this.dgvTD.Size = new System.Drawing.Size(942, 271);
            this.dgvTD.TabIndex = 79;
            this.dgvTD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTD_CellContentClick);
            this.dgvTD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTD_CellFormatting);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "IdTurno";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Visible = false;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "HoraInicio";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Profesional
            // 
            this.Profesional.DataPropertyName = "NombreProfesional";
            this.Profesional.HeaderText = "Profesional";
            this.Profesional.Name = "Profesional";
            this.Profesional.ReadOnly = true;
            // 
            // Especialidad
            // 
            this.Especialidad.DataPropertyName = "Especialidad";
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "NombrePaciente";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "DniPaciente";
            this.DNI.HeaderText = "DNI Paciente";
            this.DNI.Name = "DNI";
            // 
            // ContactoPaciente
            // 
            this.ContactoPaciente.DataPropertyName = "TelefonoPaciente";
            this.ContactoPaciente.HeaderText = "Contacto paciente";
            this.ContactoPaciente.Name = "ContactoPaciente";
            this.ContactoPaciente.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // btnCambiarEstado
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            this.btnCambiarEstado.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.HeaderText = "Cambiar estado";
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.ReadOnly = true;
            this.btnCambiarEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnCambiarEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.UseColumnTextForButtonValue = true;
            // 
            // btnRegistrarPago
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            this.btnRegistrarPago.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPago.HeaderText = "Registrar Pago";
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.ReadOnly = true;
            this.btnRegistrarPago.Text = "Registrar pago";
            this.btnRegistrarPago.UseColumnTextForButtonValue = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalTurnos,
            this.lblConfirmados,
            this.lblPendientes,
            this.lblCancelados,
            this.lblPagados});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.statusStrip1.MinimumSize = new System.Drawing.Size(0, 40);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1131, 40);
            this.statusStrip1.TabIndex = 81;
            this.statusStrip1.Text = "Resumen del dia de hoy:";
            // 
            // lblTotalTurnos
            // 
            this.lblTotalTurnos.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTurnos.Name = "lblTotalTurnos";
            this.lblTotalTurnos.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblTotalTurnos.Size = new System.Drawing.Size(180, 35);
            this.lblTotalTurnos.Text = "Turnos del dia:";
            // 
            // lblConfirmados
            // 
            this.lblConfirmados.Name = "lblConfirmados";
            this.lblConfirmados.Size = new System.Drawing.Size(193, 35);
            this.lblConfirmados.Text = "toolStripStatusLabel1";
            // 
            // lblPendientes
            // 
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPendientes.Size = new System.Drawing.Size(213, 35);
            this.lblPendientes.Text = "toolStripStatusLabel1";
            // 
            // lblCancelados
            // 
            this.lblCancelados.Name = "lblCancelados";
            this.lblCancelados.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblCancelados.Size = new System.Drawing.Size(213, 35);
            this.lblCancelados.Text = "toolStripStatusLabel1";
            // 
            // lblPagados
            // 
            this.lblPagados.Name = "lblPagados";
            this.lblPagados.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPagados.Size = new System.Drawing.Size(213, 35);
            this.lblPagados.Text = "toolStripStatusLabel1";
            // 
            // UCTurnosDelDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvTD);
            this.Controls.Add(this.cboProfesional);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCTurnosDelDia";
            this.Size = new System.Drawing.Size(1131, 557);
            this.Load += new System.EventHandler(this.UCTurnosDelDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTD)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProfesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTD;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalTurnos;
        private System.Windows.Forms.ToolStripStatusLabel lblPendientes;
        private System.Windows.Forms.ToolStripStatusLabel lblCancelados;
        private System.Windows.Forms.ToolStripStatusLabel lblPagados;
        private System.Windows.Forms.ToolStripStatusLabel lblConfirmados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn btnCambiarEstado;
        private System.Windows.Forms.DataGridViewButtonColumn btnRegistrarPago;
    }
}

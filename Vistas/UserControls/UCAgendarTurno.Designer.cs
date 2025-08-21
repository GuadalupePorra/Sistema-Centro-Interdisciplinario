namespace SCI
{
    partial class UCAgendarTurno
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProfesional = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LblHorariosProfesional = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCambiarPaciente = new FontAwesome.Sharp.IconButton();
            this.LstResultadosPaciente = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FlpSlotsTurno = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnAgendar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPaciente = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.LstResultadosPaciente);
            this.groupBox1.Controls.Add(this.cboProfesional);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LblHorariosProfesional);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnCambiarPaciente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.FlpSlotsTurno);
            this.groupBox1.Controls.Add(this.BtnAgendar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtPaciente);
            this.groupBox1.Font = new System.Drawing.Font("Humnst777 BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(300, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 494);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "        Agendar nuevo turno";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cboProfesional
            // 
            this.cboProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesional.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProfesional.FormattingEnabled = true;
            this.cboProfesional.Location = new System.Drawing.Point(27, 129);
            this.cboProfesional.Margin = new System.Windows.Forms.Padding(4);
            this.cboProfesional.Name = "cboProfesional";
            this.cboProfesional.Size = new System.Drawing.Size(282, 27);
            this.cboProfesional.TabIndex = 77;
            this.cboProfesional.SelectedIndexChanged += new System.EventHandler(this.cboProfesional_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dias y horarios de atencion:";
            // 
            // LblHorariosProfesional
            // 
            this.LblHorariosProfesional.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHorariosProfesional.Location = new System.Drawing.Point(27, 186);
            this.LblHorariosProfesional.Name = "LblHorariosProfesional";
            this.LblHorariosProfesional.Size = new System.Drawing.Size(488, 47);
            this.LblHorariosProfesional.TabIndex = 14;
            this.LblHorariosProfesional.Click += new System.EventHandler(this.LblHorariosProfesional_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Gray;
            this.BtnCancelar.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancelar.Location = new System.Drawing.Point(358, 434);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(157, 45);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click_1);
            // 
            // BtnCambiarPaciente
            // 
            this.BtnCambiarPaciente.FlatAppearance.BorderSize = 0;
            this.BtnCambiarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarPaciente.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarPaciente.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.BtnCambiarPaciente.IconColor = System.Drawing.Color.Teal;
            this.BtnCambiarPaciente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCambiarPaciente.IconSize = 40;
            this.BtnCambiarPaciente.Location = new System.Drawing.Point(315, 64);
            this.BtnCambiarPaciente.Name = "BtnCambiarPaciente";
            this.BtnCambiarPaciente.Size = new System.Drawing.Size(37, 31);
            this.BtnCambiarPaciente.TabIndex = 11;
            this.BtnCambiarPaciente.UseVisualStyleBackColor = true;
            this.BtnCambiarPaciente.Visible = false;
            this.BtnCambiarPaciente.Click += new System.EventHandler(this.BtnCambiarPaciente_Click);
            // 
            // LstResultadosPaciente
            // 
            this.LstResultadosPaciente.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstResultadosPaciente.FormattingEnabled = true;
            this.LstResultadosPaciente.ItemHeight = 19;
            this.LstResultadosPaciente.Location = new System.Drawing.Point(22, 86);
            this.LstResultadosPaciente.Name = "LstResultadosPaciente";
            this.LstResultadosPaciente.Size = new System.Drawing.Size(287, 61);
            this.LstResultadosPaciente.TabIndex = 9;
            this.LstResultadosPaciente.Visible = false;
            this.LstResultadosPaciente.SelectedIndexChanged += new System.EventHandler(this.LstResultadosPaciente_SelectedIndexChanged);
            this.LstResultadosPaciente.DoubleClick += new System.EventHandler(this.LstResultadosPaciente_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccione un horario:";
            // 
            // FlpSlotsTurno
            // 
            this.FlpSlotsTurno.Location = new System.Drawing.Point(282, 262);
            this.FlpSlotsTurno.Name = "FlpSlotsTurno";
            this.FlpSlotsTurno.Size = new System.Drawing.Size(233, 162);
            this.FlpSlotsTurno.TabIndex = 1;
            // 
            // BtnAgendar
            // 
            this.BtnAgendar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnAgendar.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgendar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAgendar.Location = new System.Drawing.Point(22, 434);
            this.BtnAgendar.Name = "BtnAgendar";
            this.BtnAgendar.Size = new System.Drawing.Size(330, 45);
            this.BtnAgendar.TabIndex = 6;
            this.BtnAgendar.Text = "AGENDAR TURNO";
            this.BtnAgendar.UseVisualStyleBackColor = false;
            this.BtnAgendar.Click += new System.EventHandler(this.BtnAgendar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione la fecha:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(21, 262);
            this.monthCalendar1.MinDate = new System.DateTime(2025, 5, 3, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.MediumAquamarine;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione un profesional:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI del paciente:";
            // 
            // TxtPaciente
            // 
            this.TxtPaciente.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaciente.Location = new System.Drawing.Point(21, 67);
            this.TxtPaciente.Name = "TxtPaciente";
            this.TxtPaciente.Size = new System.Drawing.Size(288, 26);
            this.TxtPaciente.TabIndex = 0;
            this.TxtPaciente.TextChanged += new System.EventHandler(this.TxtPaciente_TextChanged);
            this.TxtPaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPaciente_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UCAgendarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCAgendarTurno";
            this.Size = new System.Drawing.Size(1131, 557);
            this.Load += new System.EventHandler(this.UCAgendarTurno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPaciente;
        private System.Windows.Forms.Button BtnAgendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel FlpSlotsTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LstResultadosPaciente;
        private FontAwesome.Sharp.IconButton BtnCambiarPaciente;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblHorariosProfesional;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cboProfesional;
    }
}

namespace SCI
{
    partial class UCBloquearHorario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstBloquesHorarios = new System.Windows.Forms.ListBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnBloquear = new System.Windows.Forms.Button();
            this.TxtMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.LblDatosProfesional = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstBloquesHorarios);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnBloquear);
            this.groupBox1.Controls.Add(this.TxtMotivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LblDatosProfesional);
            this.groupBox1.Font = new System.Drawing.Font("Humnst777 BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(253, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(486, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bloquear horario";
            // 
            // LstBloquesHorarios
            // 
            this.LstBloquesHorarios.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBloquesHorarios.FormattingEnabled = true;
            this.LstBloquesHorarios.ItemHeight = 19;
            this.LstBloquesHorarios.Location = new System.Drawing.Point(32, 64);
            this.LstBloquesHorarios.Name = "LstBloquesHorarios";
            this.LstBloquesHorarios.Size = new System.Drawing.Size(420, 61);
            this.LstBloquesHorarios.TabIndex = 7;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DimGray;
            this.BtnCancelar.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(254, 385);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(166, 56);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnBloquear
            // 
            this.BtnBloquear.BackColor = System.Drawing.Color.Teal;
            this.BtnBloquear.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBloquear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnBloquear.Location = new System.Drawing.Point(67, 385);
            this.BtnBloquear.Name = "BtnBloquear";
            this.BtnBloquear.Size = new System.Drawing.Size(166, 56);
            this.BtnBloquear.TabIndex = 5;
            this.BtnBloquear.Text = "Bloquear horario";
            this.BtnBloquear.UseVisualStyleBackColor = false;
            this.BtnBloquear.Click += new System.EventHandler(this.BtnBloquear_Click);
            // 
            // TxtMotivo
            // 
            this.TxtMotivo.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMotivo.Location = new System.Drawing.Point(116, 337);
            this.TxtMotivo.Name = "TxtMotivo";
            this.TxtMotivo.Size = new System.Drawing.Size(336, 26);
            this.TxtMotivo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Motivo:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(131, 163);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar fechas:";
            // 
            // LblDatosProfesional
            // 
            this.LblDatosProfesional.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.LblDatosProfesional.Location = new System.Drawing.Point(32, 37);
            this.LblDatosProfesional.Name = "LblDatosProfesional";
            this.LblDatosProfesional.Size = new System.Drawing.Size(420, 24);
            this.LblDatosProfesional.TabIndex = 0;
            this.LblDatosProfesional.Text = ".";
            this.LblDatosProfesional.Click += new System.EventHandler(this.LblDatosProfesional_Click);
            // 
            // UCBloquearHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCBloquearHorario";
            this.Size = new System.Drawing.Size(1131, 557);
            this.Load += new System.EventHandler(this.UCBloquearHorario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblDatosProfesional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnBloquear;
        private System.Windows.Forms.TextBox TxtMotivo;
        private System.Windows.Forms.ListBox LstBloquesHorarios;
    }
}

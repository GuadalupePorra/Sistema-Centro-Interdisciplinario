namespace SCI
{
    partial class UCRegistrarPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstResultadosPaciente = new System.Windows.Forms.ListBox();
            this.DgvDatosTurno = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFecha = new System.Windows.Forms.Label();
            this.BtnCambiarPaciente = new FontAwesome.Sharp.IconButton();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CbxFormaPago = new System.Windows.Forms.ComboBox();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstResultadosPaciente);
            this.groupBox1.Controls.Add(this.DgvDatosTurno);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.BtnCambiarPaciente);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnRegistrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CbxFormaPago);
            this.groupBox1.Controls.Add(this.TxtMonto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Humnst777 BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(322, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(626, 432);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar pago";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // LstResultadosPaciente
            // 
            this.LstResultadosPaciente.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstResultadosPaciente.FormattingEnabled = true;
            this.LstResultadosPaciente.ItemHeight = 19;
            this.LstResultadosPaciente.Location = new System.Drawing.Point(256, 75);
            this.LstResultadosPaciente.Name = "LstResultadosPaciente";
            this.LstResultadosPaciente.Size = new System.Drawing.Size(293, 61);
            this.LstResultadosPaciente.TabIndex = 10;
            this.LstResultadosPaciente.Visible = false;
            this.LstResultadosPaciente.SelectedIndexChanged += new System.EventHandler(this.LstResultadosPaciente_SelectedIndexChanged);
            this.LstResultadosPaciente.DoubleClick += new System.EventHandler(this.LstResultadosPaciente_DoubleClick);
            // 
            // DgvDatosTurno
            // 
            this.DgvDatosTurno.AllowUserToAddRows = false;
            this.DgvDatosTurno.AllowUserToDeleteRows = false;
            this.DgvDatosTurno.AllowUserToResizeColumns = false;
            this.DgvDatosTurno.AllowUserToResizeRows = false;
            this.DgvDatosTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvDatosTurno.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDatosTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvDatosTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatosTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fech,
            this.profesional,
            this.especialidad,
            this.hora});
            this.DgvDatosTurno.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DgvDatosTurno.Location = new System.Drawing.Point(25, 95);
            this.DgvDatosTurno.MultiSelect = false;
            this.DgvDatosTurno.Name = "DgvDatosTurno";
            this.DgvDatosTurno.ReadOnly = true;
            this.DgvDatosTurno.Size = new System.Drawing.Size(550, 143);
            this.DgvDatosTurno.TabIndex = 36;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdTurno";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 49;
            // 
            // fech
            // 
            this.fech.DataPropertyName = "Fecha";
            this.fech.HeaderText = "Fecha turno";
            this.fech.Name = "fech";
            this.fech.ReadOnly = true;
            this.fech.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fech.Width = 114;
            // 
            // profesional
            // 
            this.profesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.profesional.DataPropertyName = "NombreProfesional";
            this.profesional.HeaderText = "Profesional";
            this.profesional.Name = "profesional";
            this.profesional.ReadOnly = true;
            this.profesional.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // especialidad
            // 
            this.especialidad.DataPropertyName = "Especialidad";
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            this.especialidad.Width = 118;
            // 
            // hora
            // 
            this.hora.DataPropertyName = "HoraInicio";
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            this.hora.Width = 66;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(157, 282);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 19);
            this.lblFecha.TabIndex = 13;
            // 
            // BtnCambiarPaciente
            // 
            this.BtnCambiarPaciente.FlatAppearance.BorderSize = 0;
            this.BtnCambiarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambiarPaciente.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarPaciente.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.BtnCambiarPaciente.IconColor = System.Drawing.Color.Teal;
            this.BtnCambiarPaciente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCambiarPaciente.IconSize = 35;
            this.BtnCambiarPaciente.Location = new System.Drawing.Point(557, 48);
            this.BtnCambiarPaciente.Name = "BtnCambiarPaciente";
            this.BtnCambiarPaciente.Size = new System.Drawing.Size(37, 33);
            this.BtnCambiarPaciente.TabIndex = 12;
            this.BtnCambiarPaciente.UseVisualStyleBackColor = true;
            this.BtnCambiarPaciente.Visible = false;
            this.BtnCambiarPaciente.Click += new System.EventHandler(this.BtnCambiarPaciente_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BtnCancelar.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancelar.Location = new System.Drawing.Point(325, 336);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(187, 61);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.BackColor = System.Drawing.Color.Teal;
            this.BtnRegistrar.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnRegistrar.Location = new System.Drawing.Point(91, 336);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(190, 61);
            this.BtnRegistrar.TabIndex = 8;
            this.BtnRegistrar.Text = "Registrar pago";
            this.BtnRegistrar.UseVisualStyleBackColor = false;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de pago:";
            // 
            // CbxFormaPago
            // 
            this.CbxFormaPago.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbxFormaPago.FormattingEnabled = true;
            this.CbxFormaPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TRANFERENCIA",
            "TARJETA"});
            this.CbxFormaPago.Location = new System.Drawing.Point(439, 244);
            this.CbxFormaPago.Name = "CbxFormaPago";
            this.CbxFormaPago.Size = new System.Drawing.Size(136, 27);
            this.CbxFormaPago.TabIndex = 6;
            // 
            // TxtMonto
            // 
            this.TxtMonto.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMonto.Location = new System.Drawing.Point(91, 247);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(134, 26);
            this.TxtMonto.TabIndex = 5;
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Forma de pago:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monto:";
            // 
            // TxtDNI
            // 
            this.TxtDNI.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDNI.Location = new System.Drawing.Point(256, 52);
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(293, 26);
            this.TxtDNI.TabIndex = 1;
            this.TxtDNI.TextChanged += new System.EventHandler(this.TxtDNI_TextChanged);
            this.TxtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDNI_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese DNI del paciente:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // iconButton1
            // 
            this.iconButton1.Enabled = false;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Humnst777 BT", 9F);
            this.iconButton1.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.iconButton1.IconColor = System.Drawing.Color.Teal;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(23, 173);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(274, 67);
            this.iconButton1.TabIndex = 67;
            this.iconButton1.Text = "Para poder registrar el pago de un turno, este debe estar previamente establecido" +
    " como \"CONFIRMADO\"";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // UCRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCRegistrarPago";
            this.Size = new System.Drawing.Size(1131, 557);
            this.Load += new System.EventHandler(this.UCRegistrarPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDNI;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbxFormaPago;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.ListBox LstResultadosPaciente;
        private FontAwesome.Sharp.IconButton BtnCambiarPaciente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView DgvDatosTurno;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fech;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
    }
}

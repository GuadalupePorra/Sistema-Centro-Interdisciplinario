namespace SCI
{
    partial class UCFormularioPersona
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.gbForm = new System.Windows.Forms.GroupBox();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbObS = new System.Windows.Forms.CheckBox();
            this.txtObS = new System.Windows.Forms.TextBox();
            this.lblObS = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAyuda = new System.Windows.Forms.Label();
            this.gbForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.label3.Location = new System.Drawing.Point(19, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teléfono:";
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(197, 139);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(268, 27);
            this.txtTel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDNI.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(197, 103);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(268, 27);
            this.txtDNI.TabIndex = 7;
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(197, 67);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(268, 27);
            this.txtApellido.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(197, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(268, 27);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.label2.Location = new System.Drawing.Point(19, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(279, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(146, 64);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Teal;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(60, 326);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(146, 64);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Humnst777 Cn BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(177, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(660, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Complete el formulario y presione Agregar para registrar un nuevo paciente o Canc" +
    "elar para descartar los cambios.";
            // 
            // gbForm
            // 
            this.gbForm.BackColor = System.Drawing.Color.White;
            this.gbForm.Controls.Add(this.cbEspecialidad);
            this.gbForm.Controls.Add(this.lblNacimiento);
            this.gbForm.Controls.Add(this.dtpFechaNac);
            this.gbForm.Controls.Add(this.cbObS);
            this.gbForm.Controls.Add(this.txtObS);
            this.gbForm.Controls.Add(this.lblObS);
            this.gbForm.Controls.Add(this.btnCancelar);
            this.gbForm.Controls.Add(this.lblEspecialidad);
            this.gbForm.Controls.Add(this.btnAgregar);
            this.gbForm.Controls.Add(this.label3);
            this.gbForm.Controls.Add(this.label4);
            this.gbForm.Controls.Add(this.label1);
            this.gbForm.Controls.Add(this.txtNombre);
            this.gbForm.Controls.Add(this.txtApellido);
            this.gbForm.Controls.Add(this.txtDNI);
            this.gbForm.Controls.Add(this.label2);
            this.gbForm.Controls.Add(this.txtTel);
            this.gbForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbForm.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbForm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbForm.Location = new System.Drawing.Point(301, 21);
            this.gbForm.Name = "gbForm";
            this.gbForm.Size = new System.Drawing.Size(484, 406);
            this.gbForm.TabIndex = 14;
            this.gbForm.TabStop = false;
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.Font = new System.Drawing.Font("Humnst777 BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(197, 240);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(267, 27);
            this.cbEspecialidad.TabIndex = 18;
            this.cbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidad_SelectedIndexChanged);
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.lblNacimiento.Location = new System.Drawing.Point(19, 210);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(153, 24);
            this.lblNacimiento.TabIndex = 16;
            this.lblNacimiento.Text = "Fecha de nacimieto: ";
            this.lblNacimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.CalendarFont = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Bold);
            this.dtpFechaNac.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(197, 207);
            this.dtpFechaNac.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(147, 27);
            this.dtpFechaNac.TabIndex = 15;
            this.dtpFechaNac.Value = new System.DateTime(2025, 5, 10, 17, 9, 4, 0);
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // cbObS
            // 
            this.cbObS.AutoSize = true;
            this.cbObS.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbObS.Location = new System.Drawing.Point(197, 284);
            this.cbObS.Name = "cbObS";
            this.cbObS.Size = new System.Drawing.Size(134, 24);
            this.cbObS.TabIndex = 13;
            this.cbObS.Text = "Sin Obra social";
            this.cbObS.UseVisualStyleBackColor = true;
            this.cbObS.CheckedChanged += new System.EventHandler(this.cbObS_CheckedChanged);
            // 
            // txtObS
            // 
            this.txtObS.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObS.Location = new System.Drawing.Point(197, 240);
            this.txtObS.Name = "txtObS";
            this.txtObS.Size = new System.Drawing.Size(268, 27);
            this.txtObS.TabIndex = 9;
            this.txtObS.TextChanged += new System.EventHandler(this.txtObS_TextChanged);
            // 
            // lblObS
            // 
            this.lblObS.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.lblObS.ForeColor = System.Drawing.Color.Black;
            this.lblObS.Location = new System.Drawing.Point(19, 246);
            this.lblObS.Name = "lblObS";
            this.lblObS.Size = new System.Drawing.Size(153, 25);
            this.lblObS.TabIndex = 4;
            this.lblObS.Text = "Ob. Social/ Prepaga:";
            this.lblObS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Humnst777 BT", 12F);
            this.lblEspecialidad.Location = new System.Drawing.Point(19, 248);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(103, 20);
            this.lblEspecialidad.TabIndex = 5;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblAyuda
            // 
            this.lblAyuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAyuda.Font = new System.Drawing.Font("Humnst777 Cn BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyuda.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAyuda.Location = new System.Drawing.Point(800, 244);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(182, 43);
            this.lblAyuda.TabIndex = 17;
            this.lblAyuda.Text = "Debe ingresar una obra social o marcar \'Sin obra social\'.";
            this.lblAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCFormularioPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbForm);
            this.Name = "UCFormularioPersona";
            this.Size = new System.Drawing.Size(1050, 487);
            this.Load += new System.EventHandler(this.UCFormularioPersona_Load);
            this.gbForm.ResumeLayout(false);
            this.gbForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.CheckBox cbObS;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtObS;
        private System.Windows.Forms.Label lblObS;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cbEspecialidad;
    }
}

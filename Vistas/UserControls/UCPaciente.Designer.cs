namespace SCI
{
    partial class UCPaciente
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPacRegistrados = new FontAwesome.Sharp.IconButton();
            this.btnAgregarPac = new FontAwesome.Sharp.IconButton();
            this.panelPacientes = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnPacRegistrados);
            this.panel1.Controls.Add(this.btnAgregarPac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 49);
            this.panel1.TabIndex = 1;
            // 
            // btnPacRegistrados
            // 
            this.btnPacRegistrados.AutoSize = true;
            this.btnPacRegistrados.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnPacRegistrados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacRegistrados.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.btnPacRegistrados.FlatAppearance.BorderSize = 0;
            this.btnPacRegistrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacRegistrados.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.btnPacRegistrados.ForeColor = System.Drawing.Color.White;
            this.btnPacRegistrados.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnPacRegistrados.IconColor = System.Drawing.Color.White;
            this.btnPacRegistrados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPacRegistrados.IconSize = 40;
            this.btnPacRegistrados.Location = new System.Drawing.Point(423, 0);
            this.btnPacRegistrados.Name = "btnPacRegistrados";
            this.btnPacRegistrados.Size = new System.Drawing.Size(417, 49);
            this.btnPacRegistrados.TabIndex = 5;
            this.btnPacRegistrados.Text = "PACIENTES REGISTRADOS";
            this.btnPacRegistrados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPacRegistrados.UseVisualStyleBackColor = false;
            this.btnPacRegistrados.Click += new System.EventHandler(this.btnPacRegistrados_Click);
            // 
            // btnAgregarPac
            // 
            this.btnAgregarPac.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAgregarPac.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.btnAgregarPac.FlatAppearance.BorderSize = 0;
            this.btnAgregarPac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPac.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPac.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPac.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnAgregarPac.IconColor = System.Drawing.Color.White;
            this.btnAgregarPac.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarPac.IconSize = 40;
            this.btnAgregarPac.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarPac.Name = "btnAgregarPac";
            this.btnAgregarPac.Size = new System.Drawing.Size(417, 49);
            this.btnAgregarPac.TabIndex = 4;
            this.btnAgregarPac.Text = "NUEVO PACIENTE";
            this.btnAgregarPac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPac.UseVisualStyleBackColor = false;
            this.btnAgregarPac.Click += new System.EventHandler(this.btnAgregarPac_Click);
            // 
            // panelPacientes
            // 
            this.panelPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPacientes.Location = new System.Drawing.Point(0, 49);
            this.panelPacientes.Name = "panelPacientes";
            this.panelPacientes.Size = new System.Drawing.Size(886, 371);
            this.panelPacientes.TabIndex = 2;
            this.panelPacientes.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPacientes_Paint);
            // 
            // UCPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panelPacientes);
            this.Controls.Add(this.panel1);
            this.Name = "UCPaciente";
            this.Size = new System.Drawing.Size(886, 420);
            this.Load += new System.EventHandler(this.UCPaciente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnAgregarPac;
        private FontAwesome.Sharp.IconButton btnPacRegistrados;
        private System.Windows.Forms.Panel panelPacientes;
    }
}

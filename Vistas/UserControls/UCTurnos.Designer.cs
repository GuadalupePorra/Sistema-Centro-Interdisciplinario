namespace SCI
{
    partial class UCProfesionale
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
            this.btnTurnosRegistrados = new FontAwesome.Sharp.IconButton();
            this.BtnAsignarTurno = new FontAwesome.Sharp.IconButton();
            this.PanelTurnos = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnTurnosRegistrados);
            this.panel1.Controls.Add(this.BtnAsignarTurno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 49);
            this.panel1.TabIndex = 2;
            // 
            // btnTurnosRegistrados
            // 
            this.btnTurnosRegistrados.AutoSize = true;
            this.btnTurnosRegistrados.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnTurnosRegistrados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTurnosRegistrados.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnTurnosRegistrados.FlatAppearance.BorderSize = 0;
            this.btnTurnosRegistrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnosRegistrados.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.btnTurnosRegistrados.ForeColor = System.Drawing.Color.White;
            this.btnTurnosRegistrados.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnTurnosRegistrados.IconColor = System.Drawing.Color.White;
            this.btnTurnosRegistrados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTurnosRegistrados.IconSize = 40;
            this.btnTurnosRegistrados.Location = new System.Drawing.Point(423, 0);
            this.btnTurnosRegistrados.Name = "btnTurnosRegistrados";
            this.btnTurnosRegistrados.Size = new System.Drawing.Size(417, 50);
            this.btnTurnosRegistrados.TabIndex = 5;
            this.btnTurnosRegistrados.Text = "TURNOS REGISTRADOS";
            this.btnTurnosRegistrados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTurnosRegistrados.UseVisualStyleBackColor = false;
            this.btnTurnosRegistrados.Click += new System.EventHandler(this.btnTurnosRegistrados_Click);
            // 
            // BtnAsignarTurno
            // 
            this.BtnAsignarTurno.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnAsignarTurno.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnAsignarTurno.FlatAppearance.BorderSize = 0;
            this.BtnAsignarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAsignarTurno.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnAsignarTurno.ForeColor = System.Drawing.Color.White;
            this.BtnAsignarTurno.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.BtnAsignarTurno.IconColor = System.Drawing.Color.White;
            this.BtnAsignarTurno.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAsignarTurno.IconSize = 40;
            this.BtnAsignarTurno.Location = new System.Drawing.Point(0, 0);
            this.BtnAsignarTurno.Name = "BtnAsignarTurno";
            this.BtnAsignarTurno.Size = new System.Drawing.Size(417, 49);
            this.BtnAsignarTurno.TabIndex = 4;
            this.BtnAsignarTurno.Text = "ASIGNAR NUEVO TURNO";
            this.BtnAsignarTurno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAsignarTurno.UseVisualStyleBackColor = false;
            this.BtnAsignarTurno.Click += new System.EventHandler(this.BtnAsignarTurno_Click);
            // 
            // PanelTurnos
            // 
            this.PanelTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTurnos.Location = new System.Drawing.Point(0, 49);
            this.PanelTurnos.Name = "PanelTurnos";
            this.PanelTurnos.Size = new System.Drawing.Size(899, 420);
            this.PanelTurnos.TabIndex = 3;
            this.PanelTurnos.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTurnos_Paint);
            // 
            // UCProfesionale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelTurnos);
            this.Controls.Add(this.panel1);
            this.Name = "UCProfesionale";
            this.Size = new System.Drawing.Size(899, 469);
            this.Load += new System.EventHandler(this.UCProfesionale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnTurnosRegistrados;
        private FontAwesome.Sharp.IconButton BtnAsignarTurno;
        private System.Windows.Forms.Panel PanelTurnos;
    }
}

namespace SCI
{
    partial class UCProfesionales
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
            this.BtnProfRegistrados = new FontAwesome.Sharp.IconButton();
            this.btnAgenda = new FontAwesome.Sharp.IconButton();
            this.BtnDisponibilidad = new FontAwesome.Sharp.IconButton();
            this.BtnNuevoProfesional = new FontAwesome.Sharp.IconButton();
            this.panelProfesionales = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.BtnProfRegistrados);
            this.panel1.Controls.Add(this.btnAgenda);
            this.panel1.Controls.Add(this.BtnDisponibilidad);
            this.panel1.Controls.Add(this.BtnNuevoProfesional);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 49);
            this.panel1.TabIndex = 2;
            // 
            // BtnProfRegistrados
            // 
            this.BtnProfRegistrados.AutoSize = true;
            this.BtnProfRegistrados.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnProfRegistrados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProfRegistrados.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnProfRegistrados.FlatAppearance.BorderSize = 0;
            this.BtnProfRegistrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProfRegistrados.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnProfRegistrados.ForeColor = System.Drawing.Color.White;
            this.BtnProfRegistrados.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.BtnProfRegistrados.IconColor = System.Drawing.Color.White;
            this.BtnProfRegistrados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnProfRegistrados.IconSize = 40;
            this.BtnProfRegistrados.Location = new System.Drawing.Point(810, 0);
            this.BtnProfRegistrados.Name = "BtnProfRegistrados";
            this.BtnProfRegistrados.Size = new System.Drawing.Size(300, 49);
            this.BtnProfRegistrados.TabIndex = 5;
            this.BtnProfRegistrados.Text = "PROFESIONALES REGISTRADOS";
            this.BtnProfRegistrados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnProfRegistrados.UseVisualStyleBackColor = false;
            this.BtnProfRegistrados.Click += new System.EventHandler(this.BtnProfRegistrados_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.AutoSize = true;
            this.btnAgenda.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgenda.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgenda.ForeColor = System.Drawing.Color.White;
            this.btnAgenda.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnAgenda.IconColor = System.Drawing.Color.White;
            this.btnAgenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgenda.IconSize = 40;
            this.btnAgenda.Location = new System.Drawing.Point(262, 0);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(289, 49);
            this.btnAgenda.TabIndex = 6;
            this.btnAgenda.Text = "CONFIGURAR DISPONIBILIDAD";
            this.btnAgenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // BtnDisponibilidad
            // 
            this.BtnDisponibilidad.AutoSize = true;
            this.BtnDisponibilidad.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnDisponibilidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDisponibilidad.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnDisponibilidad.FlatAppearance.BorderSize = 0;
            this.BtnDisponibilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisponibilidad.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnDisponibilidad.ForeColor = System.Drawing.Color.White;
            this.BtnDisponibilidad.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.BtnDisponibilidad.IconColor = System.Drawing.Color.White;
            this.BtnDisponibilidad.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnDisponibilidad.IconSize = 40;
            this.BtnDisponibilidad.Location = new System.Drawing.Point(557, 0);
            this.BtnDisponibilidad.Name = "BtnDisponibilidad";
            this.BtnDisponibilidad.Size = new System.Drawing.Size(247, 49);
            this.BtnDisponibilidad.TabIndex = 7;
            this.BtnDisponibilidad.Text = "VER DISPONIBILIDAD";
            this.BtnDisponibilidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDisponibilidad.UseVisualStyleBackColor = false;
            this.BtnDisponibilidad.Click += new System.EventHandler(this.BtnDisponibilidad_Click);
            // 
            // BtnNuevoProfesional
            // 
            this.BtnNuevoProfesional.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnNuevoProfesional.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnNuevoProfesional.FlatAppearance.BorderSize = 0;
            this.BtnNuevoProfesional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevoProfesional.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnNuevoProfesional.ForeColor = System.Drawing.Color.White;
            this.BtnNuevoProfesional.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.BtnNuevoProfesional.IconColor = System.Drawing.Color.White;
            this.BtnNuevoProfesional.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnNuevoProfesional.IconSize = 40;
            this.BtnNuevoProfesional.Location = new System.Drawing.Point(0, 0);
            this.BtnNuevoProfesional.Name = "BtnNuevoProfesional";
            this.BtnNuevoProfesional.Size = new System.Drawing.Size(256, 49);
            this.BtnNuevoProfesional.TabIndex = 4;
            this.BtnNuevoProfesional.Text = "NUEVO PROFESIONAL";
            this.BtnNuevoProfesional.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevoProfesional.UseVisualStyleBackColor = false;
            this.BtnNuevoProfesional.Click += new System.EventHandler(this.BtnNuevoProfesional_Click);
            // 
            // panelProfesionales
            // 
            this.panelProfesionales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProfesionales.Location = new System.Drawing.Point(0, 49);
            this.panelProfesionales.Name = "panelProfesionales";
            this.panelProfesionales.Size = new System.Drawing.Size(1122, 379);
            this.panelProfesionales.TabIndex = 3;
            this.panelProfesionales.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProfesionales_Paint);
            // 
            // UCProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelProfesionales);
            this.Controls.Add(this.panel1);
            this.Name = "UCProfesionales";
            this.Size = new System.Drawing.Size(1122, 428);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnAgenda;
        private FontAwesome.Sharp.IconButton BtnProfRegistrados;
        private FontAwesome.Sharp.IconButton BtnNuevoProfesional;
        private System.Windows.Forms.Panel panelProfesionales;
        private FontAwesome.Sharp.IconButton BtnDisponibilidad;
    }
}

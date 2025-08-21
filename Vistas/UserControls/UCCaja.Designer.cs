namespace SCI
{
    partial class UCCaja
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
            this.BtnPagosRegistrados = new FontAwesome.Sharp.IconButton();
            this.BtnRegistrarPago = new FontAwesome.Sharp.IconButton();
            this.PanelCaja = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.BtnPagosRegistrados);
            this.panel1.Controls.Add(this.BtnRegistrarPago);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 49);
            this.panel1.TabIndex = 2;
            // 
            // BtnPagosRegistrados
            // 
            this.BtnPagosRegistrados.AutoSize = true;
            this.BtnPagosRegistrados.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnPagosRegistrados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPagosRegistrados.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnPagosRegistrados.FlatAppearance.BorderSize = 0;
            this.BtnPagosRegistrados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagosRegistrados.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnPagosRegistrados.ForeColor = System.Drawing.Color.White;
            this.BtnPagosRegistrados.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.BtnPagosRegistrados.IconColor = System.Drawing.Color.White;
            this.BtnPagosRegistrados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnPagosRegistrados.IconSize = 40;
            this.BtnPagosRegistrados.Location = new System.Drawing.Point(434, 0);
            this.BtnPagosRegistrados.Name = "BtnPagosRegistrados";
            this.BtnPagosRegistrados.Size = new System.Drawing.Size(428, 49);
            this.BtnPagosRegistrados.TabIndex = 5;
            this.BtnPagosRegistrados.Text = " REGISTRO DE PAGOS";
            this.BtnPagosRegistrados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPagosRegistrados.UseVisualStyleBackColor = false;
            this.BtnPagosRegistrados.Click += new System.EventHandler(this.BtnPagosRegistrados_Click);
            // 
            // BtnRegistrarPago
            // 
            this.BtnRegistrarPago.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnRegistrarPago.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnRegistrarPago.FlatAppearance.BorderSize = 0;
            this.BtnRegistrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistrarPago.Font = new System.Drawing.Font("Humnst777 BT", 11F, System.Drawing.FontStyle.Bold);
            this.BtnRegistrarPago.ForeColor = System.Drawing.Color.White;
            this.BtnRegistrarPago.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.BtnRegistrarPago.IconColor = System.Drawing.Color.White;
            this.BtnRegistrarPago.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnRegistrarPago.IconSize = 40;
            this.BtnRegistrarPago.Location = new System.Drawing.Point(0, 0);
            this.BtnRegistrarPago.Name = "BtnRegistrarPago";
            this.BtnRegistrarPago.Size = new System.Drawing.Size(428, 49);
            this.BtnRegistrarPago.TabIndex = 4;
            this.BtnRegistrarPago.Text = "REGISTRAR PAGO";
            this.BtnRegistrarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRegistrarPago.UseVisualStyleBackColor = false;
            this.BtnRegistrarPago.Click += new System.EventHandler(this.BtnRegistrarPago_Click);
            // 
            // PanelCaja
            // 
            this.PanelCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCaja.Location = new System.Drawing.Point(0, 49);
            this.PanelCaja.Name = "PanelCaja";
            this.PanelCaja.Size = new System.Drawing.Size(904, 311);
            this.PanelCaja.TabIndex = 3;
            this.PanelCaja.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCaja_Paint);
            // 
            // UCCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelCaja);
            this.Controls.Add(this.panel1);
            this.Name = "UCCaja";
            this.Size = new System.Drawing.Size(904, 360);
            this.Load += new System.EventHandler(this.UCCaja_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton BtnPagosRegistrados;
        private FontAwesome.Sharp.IconButton BtnRegistrarPago;
        private System.Windows.Forms.Panel PanelCaja;
    }
}

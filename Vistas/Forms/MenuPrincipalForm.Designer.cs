namespace SCI
{
    partial class MenuPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contenedor = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnPacientes = new FontAwesome.Sharp.IconButton();
            this.btnProfesional = new FontAwesome.Sharp.IconButton();
            this.btnTurnos = new FontAwesome.Sharp.IconButton();
            this.btnCaja = new FontAwesome.Sharp.IconButton();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOpcion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnTurnosDia = new FontAwesome.Sharp.IconButton();
            this.btnRegresar = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.White;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Right;
            this.contenedor.Location = new System.Drawing.Point(262, 90);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1108, 639);
            this.contenedor.TabIndex = 1;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPacientes.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Humnst777 BT", 14.25F);
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnPacientes.IconColor = System.Drawing.Color.White;
            this.btnPacientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPacientes.IconSize = 50;
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(61, 183);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(220, 69);
            this.btnPacientes.TabIndex = 6;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnProfesional
            // 
            this.btnProfesional.BackColor = System.Drawing.Color.DarkCyan;
            this.btnProfesional.FlatAppearance.BorderSize = 0;
            this.btnProfesional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesional.Font = new System.Drawing.Font("Humnst777 BT", 14.25F);
            this.btnProfesional.ForeColor = System.Drawing.Color.White;
            this.btnProfesional.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnProfesional.IconColor = System.Drawing.Color.White;
            this.btnProfesional.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfesional.IconSize = 50;
            this.btnProfesional.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesional.Location = new System.Drawing.Point(61, 333);
            this.btnProfesional.Name = "btnProfesional";
            this.btnProfesional.Size = new System.Drawing.Size(220, 69);
            this.btnProfesional.TabIndex = 7;
            this.btnProfesional.Text = "Profesionales";
            this.btnProfesional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesional.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfesional.UseVisualStyleBackColor = false;
            this.btnProfesional.Click += new System.EventHandler(this.btnProfesional_Click);
            this.btnProfesional.MouseHover += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnTurnos
            // 
            this.btnTurnos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnTurnos.FlatAppearance.BorderSize = 0;
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnos.Font = new System.Drawing.Font("Humnst777 BT", 14.25F);
            this.btnTurnos.ForeColor = System.Drawing.Color.White;
            this.btnTurnos.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.btnTurnos.IconColor = System.Drawing.Color.White;
            this.btnTurnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTurnos.IconSize = 50;
            this.btnTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTurnos.Location = new System.Drawing.Point(61, 258);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(220, 69);
            this.btnTurnos.TabIndex = 8;
            this.btnTurnos.Text = "Turnos";
            this.btnTurnos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTurnos.UseVisualStyleBackColor = false;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            this.btnTurnos.MouseHover += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Humnst777 BT", 14.25F);
            this.btnCaja.ForeColor = System.Drawing.Color.White;
            this.btnCaja.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnCaja.IconColor = System.Drawing.Color.White;
            this.btnCaja.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaja.IconSize = 50;
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.Location = new System.Drawing.Point(61, 408);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(220, 69);
            this.btnCaja.TabIndex = 9;
            this.btnCaja.Text = "Caja";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaja.UseVisualStyleBackColor = false;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            this.btnCaja.MouseHover += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(61, 571);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(142, 71);
            this.btnCerrarSesion.TabIndex = 10;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Humnst777 BT", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(307, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema Centro interdisciplinario";
            // 
            // lblOpcion
            // 
            this.lblOpcion.AutoSize = true;
            this.lblOpcion.Font = new System.Drawing.Font("Humnst777 Cn BT", 14F);
            this.lblOpcion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblOpcion.Location = new System.Drawing.Point(310, 64);
            this.lblOpcion.Name = "lblOpcion";
            this.lblOpcion.Size = new System.Drawing.Size(20, 22);
            this.lblOpcion.TabIndex = 1;
            this.lblOpcion.Tag = " ";
            this.lblOpcion.Text = "  ";
            this.lblOpcion.Click += new System.EventHandler(this.lblOpcion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.lblRol);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.lblOpcion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 90);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRol.Location = new System.Drawing.Point(27, 53);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 20);
            this.lblRol.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Humnst777 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsuario.Location = new System.Drawing.Point(27, 24);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 20);
            this.lblUsuario.TabIndex = 2;
            // 
            // btnTurnosDia
            // 
            this.btnTurnosDia.BackColor = System.Drawing.Color.DarkCyan;
            this.btnTurnosDia.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnTurnosDia.FlatAppearance.BorderSize = 0;
            this.btnTurnosDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnosDia.Font = new System.Drawing.Font("Humnst777 BT", 14.25F);
            this.btnTurnosDia.ForeColor = System.Drawing.Color.White;
            this.btnTurnosDia.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            this.btnTurnosDia.IconColor = System.Drawing.Color.White;
            this.btnTurnosDia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTurnosDia.IconSize = 50;
            this.btnTurnosDia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTurnosDia.Location = new System.Drawing.Point(61, 108);
            this.btnTurnosDia.Name = "btnTurnosDia";
            this.btnTurnosDia.Size = new System.Drawing.Size(205, 69);
            this.btnTurnosDia.TabIndex = 11;
            this.btnTurnosDia.Text = "Turnos del dia";
            this.btnTurnosDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTurnosDia.UseVisualStyleBackColor = false;
            this.btnTurnosDia.Click += new System.EventHandler(this.btnTurnosDia_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRegresar.Font = new System.Drawing.Font("Humnst777 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.btnRegresar.IconColor = System.Drawing.Color.White;
            this.btnRegresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegresar.IconSize = 45;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(1135, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(204, 64);
            this.btnRegresar.TabIndex = 13;
            this.btnRegresar.Text = "Regresar a Panel Admin";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Visible = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1370, 729);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.btnTurnosDia);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnTurnos);
            this.Controls.Add(this.btnProfesional);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Humnst777 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MenuPrincipalForm";
            this.Text = "MenuPrincipalForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipalForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.ImageList imageList1;
        private FontAwesome.Sharp.IconButton btnPacientes;
        private FontAwesome.Sharp.IconButton btnProfesional;
        private FontAwesome.Sharp.IconButton btnTurnos;
        private FontAwesome.Sharp.IconButton btnCaja;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOpcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private FontAwesome.Sharp.IconButton btnTurnosDia;
        private FontAwesome.Sharp.IconButton btnRegresar;
    }
}
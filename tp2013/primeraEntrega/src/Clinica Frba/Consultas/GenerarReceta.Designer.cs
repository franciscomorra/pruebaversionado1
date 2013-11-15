namespace ClinicaFrba.Consultas
{
    partial class GenerarRecetaForm
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelProfesional = new System.Windows.Forms.Panel();
            this.btnBuscarProfesional = new System.Windows.Forms.Button();
            this.lblProf = new System.Windows.Forms.Label();
            this.txtProfesional = new System.Windows.Forms.TextBox();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.panelTurno = new System.Windows.Forms.Panel();
            this.btnBuscarTurno = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.panelBono = new System.Windows.Forms.Panel();
            this.btnBuscarBonoF = new System.Windows.Forms.Button();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.panelMed1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCant1 = new System.Windows.Forms.ComboBox();
            this.cbxMed1 = new System.Windows.Forms.ComboBox();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.panelMed5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxCant5 = new System.Windows.Forms.ComboBox();
            this.cbxMed5 = new System.Windows.Forms.ComboBox();
            this.panelMed2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCant2 = new System.Windows.Forms.ComboBox();
            this.cbxMed2 = new System.Windows.Forms.ComboBox();
            this.panelMed3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxCant3 = new System.Windows.Forms.ComboBox();
            this.cbxMed3 = new System.Windows.Forms.ComboBox();
            this.panelMed4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxCant4 = new System.Windows.Forms.ComboBox();
            this.cbxMed4 = new System.Windows.Forms.ComboBox();
            this.panelProfesional.SuspendLayout();
            this.panelAfiliado.SuspendLayout();
            this.panelTurno.SuspendLayout();
            this.panelBono.SuspendLayout();
            this.panelMed1.SuspendLayout();
            this.panelAcciones.SuspendLayout();
            this.panelMed5.SuspendLayout();
            this.panelMed2.SuspendLayout();
            this.panelMed3.SuspendLayout();
            this.panelMed4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(3, 338);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(399, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Agregar Medicamentos A Receta";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelProfesional
            // 
            this.panelProfesional.Controls.Add(this.btnBuscarProfesional);
            this.panelProfesional.Controls.Add(this.lblProf);
            this.panelProfesional.Controls.Add(this.txtProfesional);
            this.panelProfesional.Location = new System.Drawing.Point(7, 2);
            this.panelProfesional.Name = "panelProfesional";
            this.panelProfesional.Size = new System.Drawing.Size(435, 43);
            this.panelProfesional.TabIndex = 15;
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(327, 7);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProfesional.TabIndex = 34;
            this.btnBuscarProfesional.Text = "Buscar";
            this.btnBuscarProfesional.UseVisualStyleBackColor = true;
            this.btnBuscarProfesional.Click += new System.EventHandler(this.btnBuscarProfesional_Click);
            // 
            // lblProf
            // 
            this.lblProf.AutoSize = true;
            this.lblProf.Location = new System.Drawing.Point(6, 12);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(59, 13);
            this.lblProf.TabIndex = 32;
            this.lblProf.Text = "Profesional";
            // 
            // txtProfesional
            // 
            this.txtProfesional.Location = new System.Drawing.Point(90, 9);
            this.txtProfesional.Name = "txtProfesional";
            this.txtProfesional.ReadOnly = true;
            this.txtProfesional.Size = new System.Drawing.Size(231, 20);
            this.txtProfesional.TabIndex = 33;
            // 
            // panelAfiliado
            // 
            this.panelAfiliado.Controls.Add(this.btnBuscarAfiliado);
            this.panelAfiliado.Controls.Add(this.lblAfiliado);
            this.panelAfiliado.Controls.Add(this.txtAfiliado);
            this.panelAfiliado.Location = new System.Drawing.Point(7, 51);
            this.panelAfiliado.Name = "panelAfiliado";
            this.panelAfiliado.Size = new System.Drawing.Size(432, 43);
            this.panelAfiliado.TabIndex = 22;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(327, 7);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 34;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.btnBuscarAfiliado_Click);
            // 
            // lblAfiliado
            // 
            this.lblAfiliado.AutoSize = true;
            this.lblAfiliado.Location = new System.Drawing.Point(6, 12);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(41, 13);
            this.lblAfiliado.TabIndex = 32;
            this.lblAfiliado.Text = "Afiliado";
            // 
            // txtAfiliado
            // 
            this.txtAfiliado.Location = new System.Drawing.Point(90, 10);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.ReadOnly = true;
            this.txtAfiliado.Size = new System.Drawing.Size(231, 20);
            this.txtAfiliado.TabIndex = 33;
            // 
            // panelTurno
            // 
            this.panelTurno.Controls.Add(this.btnBuscarTurno);
            this.panelTurno.Controls.Add(this.lblTurno);
            this.panelTurno.Controls.Add(this.txtTurno);
            this.panelTurno.Location = new System.Drawing.Point(7, 100);
            this.panelTurno.Name = "panelTurno";
            this.panelTurno.Size = new System.Drawing.Size(432, 43);
            this.panelTurno.TabIndex = 22;
            // 
            // btnBuscarTurno
            // 
            this.btnBuscarTurno.Location = new System.Drawing.Point(327, 9);
            this.btnBuscarTurno.Name = "btnBuscarTurno";
            this.btnBuscarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTurno.TabIndex = 34;
            this.btnBuscarTurno.Text = "Buscar";
            this.btnBuscarTurno.UseVisualStyleBackColor = true;
            this.btnBuscarTurno.Click += new System.EventHandler(this.btnBuscarTurno_Click);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(6, 12);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(35, 13);
            this.lblTurno.TabIndex = 32;
            this.lblTurno.Text = "Turno";
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(90, 9);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(231, 20);
            this.txtTurno.TabIndex = 33;
            // 
            // panelBono
            // 
            this.panelBono.Controls.Add(this.btnBuscarBonoF);
            this.panelBono.Controls.Add(this.lblBono);
            this.panelBono.Controls.Add(this.txtBono);
            this.panelBono.Location = new System.Drawing.Point(7, 149);
            this.panelBono.Name = "panelBono";
            this.panelBono.Size = new System.Drawing.Size(432, 43);
            this.panelBono.TabIndex = 22;
            // 
            // btnBuscarBonoF
            // 
            this.btnBuscarBonoF.Location = new System.Drawing.Point(327, 7);
            this.btnBuscarBonoF.Name = "btnBuscarBonoF";
            this.btnBuscarBonoF.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarBonoF.TabIndex = 34;
            this.btnBuscarBonoF.Text = "Buscar";
            this.btnBuscarBonoF.UseVisualStyleBackColor = true;
            this.btnBuscarBonoF.Click += new System.EventHandler(this.btnBuscarBonoF_Click);
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(6, 12);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(78, 13);
            this.lblBono.TabIndex = 32;
            this.lblBono.Text = "Bono Farmacia";
            // 
            // txtBono
            // 
            this.txtBono.Location = new System.Drawing.Point(90, 9);
            this.txtBono.Name = "txtBono";
            this.txtBono.ReadOnly = true;
            this.txtBono.Size = new System.Drawing.Size(231, 20);
            this.txtBono.TabIndex = 33;
            // 
            // panelMed1
            // 
            this.panelMed1.Controls.Add(this.label1);
            this.panelMed1.Controls.Add(this.label2);
            this.panelMed1.Controls.Add(this.cbxCant1);
            this.panelMed1.Controls.Add(this.cbxMed1);
            this.panelMed1.Location = new System.Drawing.Point(7, 199);
            this.panelMed1.Name = "panelMed1";
            this.panelMed1.Size = new System.Drawing.Size(432, 32);
            this.panelMed1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Medicamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cantidad";
            // 
            // cbxCant1
            // 
            this.cbxCant1.FormattingEnabled = true;
            this.cbxCant1.Location = new System.Drawing.Point(256, 3);
            this.cbxCant1.Name = "cbxCant1";
            this.cbxCant1.Size = new System.Drawing.Size(65, 21);
            this.cbxCant1.TabIndex = 0;
            // 
            // cbxMed1
            // 
            this.cbxMed1.FormattingEnabled = true;
            this.cbxMed1.Location = new System.Drawing.Point(83, 3);
            this.cbxMed1.Name = "cbxMed1";
            this.cbxMed1.Size = new System.Drawing.Size(88, 21);
            this.cbxMed1.TabIndex = 0;
            // 
            // panelAcciones
            // 
            this.panelAcciones.Controls.Add(this.panelMed5);
            this.panelAcciones.Controls.Add(this.panelMed2);
            this.panelAcciones.Controls.Add(this.btnGuardar);
            this.panelAcciones.Location = new System.Drawing.Point(7, 51);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(435, 376);
            this.panelAcciones.TabIndex = 24;
            // 
            // panelMed5
            // 
            this.panelMed5.Controls.Add(this.label9);
            this.panelMed5.Controls.Add(this.label10);
            this.panelMed5.Controls.Add(this.cbxCant5);
            this.panelMed5.Controls.Add(this.cbxMed5);
            this.panelMed5.Location = new System.Drawing.Point(0, 300);
            this.panelMed5.Name = "panelMed5";
            this.panelMed5.Size = new System.Drawing.Size(432, 32);
            this.panelMed5.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Medicamento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Cantidad";
            // 
            // cbxCant5
            // 
            this.cbxCant5.FormattingEnabled = true;
            this.cbxCant5.Location = new System.Drawing.Point(256, 3);
            this.cbxCant5.Name = "cbxCant5";
            this.cbxCant5.Size = new System.Drawing.Size(65, 21);
            this.cbxCant5.TabIndex = 0;
            // 
            // cbxMed5
            // 
            this.cbxMed5.FormattingEnabled = true;
            this.cbxMed5.Location = new System.Drawing.Point(83, 3);
            this.cbxMed5.Name = "cbxMed5";
            this.cbxMed5.Size = new System.Drawing.Size(88, 21);
            this.cbxMed5.TabIndex = 0;
            // 
            // panelMed2
            // 
            this.panelMed2.Controls.Add(this.label3);
            this.panelMed2.Controls.Add(this.label4);
            this.panelMed2.Controls.Add(this.cbxCant2);
            this.panelMed2.Controls.Add(this.cbxMed2);
            this.panelMed2.Location = new System.Drawing.Point(0, 186);
            this.panelMed2.Name = "panelMed2";
            this.panelMed2.Size = new System.Drawing.Size(432, 32);
            this.panelMed2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Medicamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cantidad";
            // 
            // cbxCant2
            // 
            this.cbxCant2.FormattingEnabled = true;
            this.cbxCant2.Location = new System.Drawing.Point(256, 3);
            this.cbxCant2.Name = "cbxCant2";
            this.cbxCant2.Size = new System.Drawing.Size(65, 21);
            this.cbxCant2.TabIndex = 0;
            // 
            // cbxMed2
            // 
            this.cbxMed2.FormattingEnabled = true;
            this.cbxMed2.Location = new System.Drawing.Point(83, 3);
            this.cbxMed2.Name = "cbxMed2";
            this.cbxMed2.Size = new System.Drawing.Size(88, 21);
            this.cbxMed2.TabIndex = 0;
            // 
            // panelMed3
            // 
            this.panelMed3.Controls.Add(this.label5);
            this.panelMed3.Controls.Add(this.label6);
            this.panelMed3.Controls.Add(this.cbxCant3);
            this.panelMed3.Controls.Add(this.cbxMed3);
            this.panelMed3.Location = new System.Drawing.Point(7, 275);
            this.panelMed3.Name = "panelMed3";
            this.panelMed3.Size = new System.Drawing.Size(432, 32);
            this.panelMed3.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Medicamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Cantidad";
            // 
            // cbxCant3
            // 
            this.cbxCant3.FormattingEnabled = true;
            this.cbxCant3.Location = new System.Drawing.Point(256, 3);
            this.cbxCant3.Name = "cbxCant3";
            this.cbxCant3.Size = new System.Drawing.Size(65, 21);
            this.cbxCant3.TabIndex = 0;
            // 
            // cbxMed3
            // 
            this.cbxMed3.FormattingEnabled = true;
            this.cbxMed3.Location = new System.Drawing.Point(83, 3);
            this.cbxMed3.Name = "cbxMed3";
            this.cbxMed3.Size = new System.Drawing.Size(88, 21);
            this.cbxMed3.TabIndex = 0;
            // 
            // panelMed4
            // 
            this.panelMed4.Controls.Add(this.label7);
            this.panelMed4.Controls.Add(this.label8);
            this.panelMed4.Controls.Add(this.cbxCant4);
            this.panelMed4.Controls.Add(this.cbxMed4);
            this.panelMed4.Location = new System.Drawing.Point(7, 313);
            this.panelMed4.Name = "panelMed4";
            this.panelMed4.Size = new System.Drawing.Size(432, 32);
            this.panelMed4.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Medicamento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Cantidad";
            // 
            // cbxCant4
            // 
            this.cbxCant4.FormattingEnabled = true;
            this.cbxCant4.Location = new System.Drawing.Point(256, 3);
            this.cbxCant4.Name = "cbxCant4";
            this.cbxCant4.Size = new System.Drawing.Size(65, 21);
            this.cbxCant4.TabIndex = 0;
            // 
            // cbxMed4
            // 
            this.cbxMed4.FormattingEnabled = true;
            this.cbxMed4.Location = new System.Drawing.Point(83, 3);
            this.cbxMed4.Name = "cbxMed4";
            this.cbxMed4.Size = new System.Drawing.Size(88, 21);
            this.cbxMed4.TabIndex = 0;
            // 
            // GenerarRecetaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 430);
            this.Controls.Add(this.panelMed4);
            this.Controls.Add(this.panelMed3);
            this.Controls.Add(this.panelMed1);
            this.Controls.Add(this.panelBono);
            this.Controls.Add(this.panelTurno);
            this.Controls.Add(this.panelAfiliado);
            this.Controls.Add(this.panelProfesional);
            this.Controls.Add(this.panelAcciones);
            this.Name = "GenerarRecetaForm";
            this.Text = "Generar Receta";
            this.Load += new System.EventHandler(this.GenerarReceta_Load);
            this.panelProfesional.ResumeLayout(false);
            this.panelProfesional.PerformLayout();
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            this.panelTurno.ResumeLayout(false);
            this.panelTurno.PerformLayout();
            this.panelBono.ResumeLayout(false);
            this.panelBono.PerformLayout();
            this.panelMed1.ResumeLayout(false);
            this.panelMed1.PerformLayout();
            this.panelAcciones.ResumeLayout(false);
            this.panelMed5.ResumeLayout(false);
            this.panelMed5.PerformLayout();
            this.panelMed2.ResumeLayout(false);
            this.panelMed2.PerformLayout();
            this.panelMed3.ResumeLayout(false);
            this.panelMed3.PerformLayout();
            this.panelMed4.ResumeLayout(false);
            this.panelMed4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelProfesional;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.TextBox txtProfesional;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Panel panelTurno;
        private System.Windows.Forms.Button btnBuscarTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Panel panelBono;
        private System.Windows.Forms.Button btnBuscarBonoF;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Panel panelMed1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCant1;
        private System.Windows.Forms.ComboBox cbxMed1;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Panel panelMed5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxCant5;
        private System.Windows.Forms.ComboBox cbxMed5;
        private System.Windows.Forms.Panel panelMed2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCant2;
        private System.Windows.Forms.ComboBox cbxMed2;
        private System.Windows.Forms.Panel panelMed3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxCant3;
        private System.Windows.Forms.ComboBox cbxMed3;
        private System.Windows.Forms.Panel panelMed4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxCant4;
        private System.Windows.Forms.ComboBox cbxMed4;

    }
}
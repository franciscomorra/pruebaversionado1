namespace ClinicaFrba.AbmTurno
{
    partial class PedirTurnoForm
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
            this.panelProfesional = new System.Windows.Forms.Panel();
            this.btnBuscarProfesional = new System.Windows.Forms.Button();
            this.lblProf = new System.Windows.Forms.Label();
            this.txtProfesional = new System.Windows.Forms.TextBox();
            this.dtTurno = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFecha = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHorario = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbxHorarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEsp = new System.Windows.Forms.Label();
            this.panelProfesional.SuspendLayout();
            this.panelFecha.SuspendLayout();
            this.panelHorario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProfesional
            // 
            this.panelProfesional.Controls.Add(this.btnBuscarProfesional);
            this.panelProfesional.Controls.Add(this.lblProf);
            this.panelProfesional.Controls.Add(this.txtProfesional);
            this.panelProfesional.Location = new System.Drawing.Point(3, 12);
            this.panelProfesional.Name = "panelProfesional";
            this.panelProfesional.Size = new System.Drawing.Size(435, 43);
            this.panelProfesional.TabIndex = 16;
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
            this.txtProfesional.Location = new System.Drawing.Point(71, 9);
            this.txtProfesional.Name = "txtProfesional";
            this.txtProfesional.ReadOnly = true;
            this.txtProfesional.Size = new System.Drawing.Size(250, 20);
            this.txtProfesional.TabIndex = 33;
            // 
            // dtTurno
            // 
            this.dtTurno.Location = new System.Drawing.Point(121, 3);
            this.dtTurno.Name = "dtTurno";
            this.dtTurno.Size = new System.Drawing.Size(200, 20);
            this.dtTurno.TabIndex = 17;
            this.dtTurno.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtTurno.ValueChanged += new System.EventHandler(this.dtTurno_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ingrese la Fecha";
            // 
            // panelFecha
            // 
            this.panelFecha.Controls.Add(this.button1);
            this.panelFecha.Controls.Add(this.dtTurno);
            this.panelFecha.Controls.Add(this.label2);
            this.panelFecha.Controls.Add(this.panelHorario);
            this.panelFecha.Location = new System.Drawing.Point(3, 105);
            this.panelFecha.Name = "panelFecha";
            this.panelFecha.Size = new System.Drawing.Size(435, 141);
            this.panelFecha.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelHorario
            // 
            this.panelHorario.Controls.Add(this.btnConfirmar);
            this.panelHorario.Controls.Add(this.cbxHorarios);
            this.panelHorario.Controls.Add(this.label1);
            this.panelHorario.Location = new System.Drawing.Point(5, 29);
            this.panelHorario.Name = "panelHorario";
            this.panelHorario.Size = new System.Drawing.Size(413, 70);
            this.panelHorario.TabIndex = 20;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(234, 40);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 21;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cbxHorarios
            // 
            this.cbxHorarios.FormattingEnabled = true;
            this.cbxHorarios.Location = new System.Drawing.Point(116, 9);
            this.cbxHorarios.Name = "cbxHorarios";
            this.cbxHorarios.Size = new System.Drawing.Size(200, 21);
            this.cbxHorarios.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Seleccione Horario";
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Location = new System.Drawing.Point(82, 67);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(242, 21);
            this.cbxEspecialidad.TabIndex = 20;
            this.cbxEspecialidad.Visible = false;
            this.cbxEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblEsp
            // 
            this.lblEsp.AutoSize = true;
            this.lblEsp.Location = new System.Drawing.Point(9, 70);
            this.lblEsp.Name = "lblEsp";
            this.lblEsp.Size = new System.Drawing.Size(67, 13);
            this.lblEsp.TabIndex = 21;
            this.lblEsp.Text = "Especialidad";
            this.lblEsp.Visible = false;
            // 
            // PedirTurnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 380);
            this.Controls.Add(this.lblEsp);
            this.Controls.Add(this.cbxEspecialidad);
            this.Controls.Add(this.panelFecha);
            this.Controls.Add(this.panelProfesional);
            this.Name = "PedirTurnoForm";
            this.Text = "PedirTurno";
            this.Load += new System.EventHandler(this.PedirTurnoForm_Load);
            this.panelProfesional.ResumeLayout(false);
            this.panelProfesional.PerformLayout();
            this.panelFecha.ResumeLayout(false);
            this.panelFecha.PerformLayout();
            this.panelHorario.ResumeLayout(false);
            this.panelHorario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelProfesional;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.TextBox txtProfesional;
        private System.Windows.Forms.DateTimePicker dtTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHorarios;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelHorario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
        private System.Windows.Forms.Label lblEsp;
    }
}
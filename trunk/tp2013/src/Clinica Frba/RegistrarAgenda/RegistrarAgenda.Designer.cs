namespace ClinicaFrba.RegistrarAgenda
{
    partial class RegistrarAgenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelProfesional = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblProf = new System.Windows.Forms.Label();
            this.txtProfesional = new System.Windows.Forms.TextBox();
            this.cbxLunesIN = new System.Windows.Forms.ComboBox();
            this.cbxLunesOUT = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxMartesIN = new System.Windows.Forms.ComboBox();
            this.cbxMartesOUT = new System.Windows.Forms.ComboBox();
            this.cbxMiercIN = new System.Windows.Forms.ComboBox();
            this.cbxMiercOUT = new System.Windows.Forms.ComboBox();
            this.cbxJueIN = new System.Windows.Forms.ComboBox();
            this.cbxJueOUT = new System.Windows.Forms.ComboBox();
            this.cbxViesIN = new System.Windows.Forms.ComboBox();
            this.cbxVieOUT = new System.Windows.Forms.ComboBox();
            this.cbxSabIN = new System.Windows.Forms.ComboBox();
            this.cbxSabOUT = new System.Windows.Forms.ComboBox();
            this.panelProfesional.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(544, 210);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hasta";
            // 
            // dtHasta
            // 
            this.dtHasta.Location = new System.Drawing.Point(419, 51);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(200, 20);
            this.dtHasta.TabIndex = 5;
            this.dtHasta.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Desde";
            // 
            // dtDesde
            // 
            this.dtDesde.Location = new System.Drawing.Point(54, 51);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(200, 20);
            this.dtDesde.TabIndex = 7;
            this.dtDesde.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lunes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Martes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Miercoles";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jueves";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Viernes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(542, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sabado";
            // 
            // panelProfesional
            // 
            this.panelProfesional.Controls.Add(this.btnBuscar);
            this.panelProfesional.Controls.Add(this.lblProf);
            this.panelProfesional.Controls.Add(this.txtProfesional);
            this.panelProfesional.Location = new System.Drawing.Point(7, 2);
            this.panelProfesional.Name = "panelProfesional";
            this.panelProfesional.Size = new System.Drawing.Size(618, 43);
            this.panelProfesional.TabIndex = 15;
            this.panelProfesional.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(180, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.txtProfesional.Size = new System.Drawing.Size(100, 20);
            this.txtProfesional.TabIndex = 33;
            // 
            // cbxLunesIN
            // 
            this.cbxLunesIN.FormattingEnabled = true;
            this.cbxLunesIN.Location = new System.Drawing.Point(54, 117);
            this.cbxLunesIN.Name = "cbxLunesIN";
            this.cbxLunesIN.Size = new System.Drawing.Size(78, 21);
            this.cbxLunesIN.TabIndex = 16;
            // 
            // cbxLunesOUT
            // 
            this.cbxLunesOUT.FormattingEnabled = true;
            this.cbxLunesOUT.Location = new System.Drawing.Point(54, 165);
            this.cbxLunesOUT.Name = "cbxLunesOUT";
            this.cbxLunesOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxLunesOUT.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Desde";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Hasta";
            // 
            // cbxMartesIN
            // 
            this.cbxMartesIN.FormattingEnabled = true;
            this.cbxMartesIN.Location = new System.Drawing.Point(151, 117);
            this.cbxMartesIN.Name = "cbxMartesIN";
            this.cbxMartesIN.Size = new System.Drawing.Size(78, 21);
            this.cbxMartesIN.TabIndex = 16;
            // 
            // cbxMartesOUT
            // 
            this.cbxMartesOUT.FormattingEnabled = true;
            this.cbxMartesOUT.Location = new System.Drawing.Point(151, 165);
            this.cbxMartesOUT.Name = "cbxMartesOUT";
            this.cbxMartesOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxMartesOUT.TabIndex = 16;
            // 
            // cbxMiercIN
            // 
            this.cbxMiercIN.FormattingEnabled = true;
            this.cbxMiercIN.Location = new System.Drawing.Point(248, 117);
            this.cbxMiercIN.Name = "cbxMiercIN";
            this.cbxMiercIN.Size = new System.Drawing.Size(78, 21);
            this.cbxMiercIN.TabIndex = 16;
            // 
            // cbxMiercOUT
            // 
            this.cbxMiercOUT.FormattingEnabled = true;
            this.cbxMiercOUT.Location = new System.Drawing.Point(248, 165);
            this.cbxMiercOUT.Name = "cbxMiercOUT";
            this.cbxMiercOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxMiercOUT.TabIndex = 16;
            // 
            // cbxJueIN
            // 
            this.cbxJueIN.FormattingEnabled = true;
            this.cbxJueIN.Location = new System.Drawing.Point(345, 117);
            this.cbxJueIN.Name = "cbxJueIN";
            this.cbxJueIN.Size = new System.Drawing.Size(78, 21);
            this.cbxJueIN.TabIndex = 16;
            // 
            // cbxJueOUT
            // 
            this.cbxJueOUT.FormattingEnabled = true;
            this.cbxJueOUT.Location = new System.Drawing.Point(345, 165);
            this.cbxJueOUT.Name = "cbxJueOUT";
            this.cbxJueOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxJueOUT.TabIndex = 16;
            // 
            // cbxViesIN
            // 
            this.cbxViesIN.FormattingEnabled = true;
            this.cbxViesIN.Location = new System.Drawing.Point(442, 117);
            this.cbxViesIN.Name = "cbxViesIN";
            this.cbxViesIN.Size = new System.Drawing.Size(78, 21);
            this.cbxViesIN.TabIndex = 16;
            // 
            // cbxVieOUT
            // 
            this.cbxVieOUT.FormattingEnabled = true;
            this.cbxVieOUT.Location = new System.Drawing.Point(442, 165);
            this.cbxVieOUT.Name = "cbxVieOUT";
            this.cbxVieOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxVieOUT.TabIndex = 16;
            // 
            // cbxSabIN
            // 
            this.cbxSabIN.FormattingEnabled = true;
            this.cbxSabIN.Location = new System.Drawing.Point(539, 117);
            this.cbxSabIN.Name = "cbxSabIN";
            this.cbxSabIN.Size = new System.Drawing.Size(78, 21);
            this.cbxSabIN.TabIndex = 16;
            // 
            // cbxSabOUT
            // 
            this.cbxSabOUT.FormattingEnabled = true;
            this.cbxSabOUT.Location = new System.Drawing.Point(539, 165);
            this.cbxSabOUT.Name = "cbxSabOUT";
            this.cbxSabOUT.Size = new System.Drawing.Size(78, 21);
            this.cbxSabOUT.TabIndex = 16;
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.cbxSabOUT);
            this.Controls.Add(this.cbxSabIN);
            this.Controls.Add(this.cbxVieOUT);
            this.Controls.Add(this.cbxViesIN);
            this.Controls.Add(this.cbxJueOUT);
            this.Controls.Add(this.cbxJueIN);
            this.Controls.Add(this.cbxMiercOUT);
            this.Controls.Add(this.cbxMiercIN);
            this.Controls.Add(this.cbxMartesOUT);
            this.Controls.Add(this.cbxMartesIN);
            this.Controls.Add(this.cbxLunesOUT);
            this.Controls.Add(this.cbxLunesIN);
            this.Controls.Add(this.panelProfesional);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.btnGuardar);
            this.Name = "RegistrarAgenda";
            this.Text = "Agenda de Profesional";
            this.Load += new System.EventHandler(this.RegistrarAgenda_Load);
            this.panelProfesional.ResumeLayout(false);
            this.panelProfesional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelProfesional;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.TextBox txtProfesional;
        private System.Windows.Forms.ComboBox cbxLunesIN;
        private System.Windows.Forms.ComboBox cbxLunesOUT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxMartesIN;
        private System.Windows.Forms.ComboBox cbxMartesOUT;
        private System.Windows.Forms.ComboBox cbxMiercIN;
        private System.Windows.Forms.ComboBox cbxMiercOUT;
        private System.Windows.Forms.ComboBox cbxJueIN;
        private System.Windows.Forms.ComboBox cbxJueOUT;
        private System.Windows.Forms.ComboBox cbxViesIN;
        private System.Windows.Forms.ComboBox cbxVieOUT;
        private System.Windows.Forms.ComboBox cbxSabIN;
        private System.Windows.Forms.ComboBox cbxSabOUT;

    }
}
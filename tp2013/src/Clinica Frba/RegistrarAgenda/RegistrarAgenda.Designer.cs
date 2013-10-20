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
            this.listLunes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listMartes = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listMiercoles = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listJueves = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listViernes = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listSabado = new System.Windows.Forms.ListBox();
            this.panelProfesional = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxProfesional = new System.Windows.Forms.ComboBox();
            this.panelProfesional.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(545, 321);
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
            // listLunes
            // 
            this.listLunes.FormattingEnabled = true;
            this.listLunes.Location = new System.Drawing.Point(7, 111);
            this.listLunes.Name = "listLunes";
            this.listLunes.Size = new System.Drawing.Size(103, 69);
            this.listLunes.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lunes";
            // 
            // listMartes
            // 
            this.listMartes.FormattingEnabled = true;
            this.listMartes.Location = new System.Drawing.Point(110, 111);
            this.listMartes.Name = "listMartes";
            this.listMartes.Size = new System.Drawing.Size(103, 69);
            this.listMartes.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Martes";
            // 
            // listMiercoles
            // 
            this.listMiercoles.FormattingEnabled = true;
            this.listMiercoles.Location = new System.Drawing.Point(213, 111);
            this.listMiercoles.Name = "listMiercoles";
            this.listMiercoles.Size = new System.Drawing.Size(103, 69);
            this.listMiercoles.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Miercoles";
            // 
            // listJueves
            // 
            this.listJueves.FormattingEnabled = true;
            this.listJueves.Location = new System.Drawing.Point(316, 111);
            this.listJueves.Name = "listJueves";
            this.listJueves.Size = new System.Drawing.Size(103, 69);
            this.listJueves.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jueves";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Viernes";
            // 
            // listViernes
            // 
            this.listViernes.FormattingEnabled = true;
            this.listViernes.Location = new System.Drawing.Point(419, 111);
            this.listViernes.Name = "listViernes";
            this.listViernes.Size = new System.Drawing.Size(103, 69);
            this.listViernes.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(519, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sabado";
            // 
            // listSabado
            // 
            this.listSabado.FormattingEnabled = true;
            this.listSabado.Location = new System.Drawing.Point(522, 111);
            this.listSabado.Name = "listSabado";
            this.listSabado.Size = new System.Drawing.Size(103, 69);
            this.listSabado.TabIndex = 13;
            // 
            // panelProfesional
            // 
            this.panelProfesional.Controls.Add(this.label9);
            this.panelProfesional.Controls.Add(this.cbxProfesional);
            this.panelProfesional.Location = new System.Drawing.Point(7, 2);
            this.panelProfesional.Name = "panelProfesional";
            this.panelProfesional.Size = new System.Drawing.Size(618, 43);
            this.panelProfesional.TabIndex = 15;
            this.panelProfesional.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Profesional";
            // 
            // cbxProfesional
            // 
            this.cbxProfesional.FormattingEnabled = true;
            this.cbxProfesional.Location = new System.Drawing.Point(103, 10);
            this.cbxProfesional.Name = "cbxProfesional";
            this.cbxProfesional.Size = new System.Drawing.Size(121, 21);
            this.cbxProfesional.TabIndex = 0;
            this.cbxProfesional.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.panelProfesional);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listSabado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listViernes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listJueves);
            this.Controls.Add(this.listMiercoles);
            this.Controls.Add(this.listMartes);
            this.Controls.Add(this.listLunes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.btnGuardar);
            this.Name = "RegistrarAgenda";
            this.Text = "RegistrarAgenda";
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
        private System.Windows.Forms.ListBox listLunes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listMartes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listMiercoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listJueves;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listViernes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listSabado;
        private System.Windows.Forms.Panel panelProfesional;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxProfesional;

    }
}
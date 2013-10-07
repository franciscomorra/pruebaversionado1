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
            this.calendarioAgenda = new System.Windows.Forms.MonthCalendar();
            this.listHorarios = new System.Windows.Forms.ListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calendarioAgenda
            // 
            this.calendarioAgenda.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.calendarioAgenda.Location = new System.Drawing.Point(12, 18);
            this.calendarioAgenda.Name = "calendarioAgenda";
            this.calendarioAgenda.TabIndex = 0;
            this.calendarioAgenda.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarioAgenda_DateSelected);
            // 
            // listHorarios
            // 
            this.listHorarios.FormattingEnabled = true;
            this.listHorarios.Location = new System.Drawing.Point(12, 185);
            this.listHorarios.Name = "listHorarios";
            this.listHorarios.Size = new System.Drawing.Size(346, 134);
            this.listHorarios.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(283, 325);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.listHorarios);
            this.Controls.Add(this.calendarioAgenda);
            this.Name = "RegistrarAgenda";
            this.Text = "RegistrarAgenda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendarioAgenda;
        private System.Windows.Forms.ListBox listHorarios;
        private System.Windows.Forms.Button btnGuardar;

    }
}
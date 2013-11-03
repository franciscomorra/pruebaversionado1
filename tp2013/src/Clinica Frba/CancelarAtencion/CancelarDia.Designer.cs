namespace ClinicaFrba.CancelarAtencion
{
    partial class CancelarDia
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProfesional.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProfesional
            // 
            this.panelProfesional.Controls.Add(this.btnBuscarProfesional);
            this.panelProfesional.Controls.Add(this.lblProf);
            this.panelProfesional.Controls.Add(this.txtProfesional);
            this.panelProfesional.Location = new System.Drawing.Point(2, 3);
            this.panelProfesional.Name = "panelProfesional";
            this.panelProfesional.Size = new System.Drawing.Size(618, 43);
            this.panelProfesional.TabIndex = 24;
            this.panelProfesional.Visible = false;
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(180, 7);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProfesional.TabIndex = 34;
            this.btnBuscarProfesional.Text = "Buscar";
            this.btnBuscarProfesional.UseVisualStyleBackColor = true;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(214, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(109, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(178, 23);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar Turnos del Dia";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Fecha";
            // 
            // CancelarDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panelProfesional);
            this.Name = "CancelarDia";
            this.Text = "Cancelar Turnos del Dia";
            this.panelProfesional.ResumeLayout(false);
            this.panelProfesional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelProfesional;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.TextBox txtProfesional;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;

    }
}
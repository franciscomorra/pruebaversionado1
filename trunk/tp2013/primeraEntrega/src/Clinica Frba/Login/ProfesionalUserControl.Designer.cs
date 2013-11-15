namespace ClinicaFrba.Login
{
    partial class ProfesionalUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Especialidades = new System.Windows.Forms.Label();
            this.clbEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(96, 2);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(200, 20);
            this.txtMatricula.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Matricula";
            // 
            // Especialidades
            // 
            this.Especialidades.AutoSize = true;
            this.Especialidades.Location = new System.Drawing.Point(12, 28);
            this.Especialidades.Name = "Especialidades";
            this.Especialidades.Size = new System.Drawing.Size(78, 13);
            this.Especialidades.TabIndex = 29;
            this.Especialidades.Text = "Especialidades";
            // 
            // clbEspecialidades
            // 
            this.clbEspecialidades.FormattingEnabled = true;
            this.clbEspecialidades.Location = new System.Drawing.Point(96, 28);
            this.clbEspecialidades.Name = "clbEspecialidades";
            this.clbEspecialidades.Size = new System.Drawing.Size(200, 109);
            this.clbEspecialidades.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Especialidades);
            this.panel1.Controls.Add(this.clbEspecialidades);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtMatricula);
            this.panel1.Location = new System.Drawing.Point(26, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 147);
            this.panel1.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Medicas";
            // 
            // ProfesionalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ProfesionalUserControl";
            this.Size = new System.Drawing.Size(437, 183);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Especialidades;
        private System.Windows.Forms.CheckedListBox clbEspecialidades;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}

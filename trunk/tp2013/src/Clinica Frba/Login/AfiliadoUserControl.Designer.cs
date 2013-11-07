namespace ClinicaFrba.Login
{
    partial class AfiliadoUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.panelMotivo = new System.Windows.Forms.Panel();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panelFamiliar = new System.Windows.Forms.Panel();
            this.txtHijos = new System.Windows.Forms.TextBox();
            this.cbxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxPlanMedico = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelMotivo.SuspendLayout();
            this.panelFamiliar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cbxRoles);
            this.panel1.Location = new System.Drawing.Point(22, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 35);
            this.panel1.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Rol de Afiliado";
            // 
            // cbxRoles
            // 
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(102, 6);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(200, 21);
            this.cbxRoles.TabIndex = 30;
            // 
            // panelMotivo
            // 
            this.panelMotivo.Controls.Add(this.txtMotivo);
            this.panelMotivo.Controls.Add(this.label12);
            this.panelMotivo.Location = new System.Drawing.Point(22, 136);
            this.panelMotivo.Name = "panelMotivo";
            this.panelMotivo.Size = new System.Drawing.Size(312, 26);
            this.panelMotivo.TabIndex = 42;
            this.panelMotivo.Visible = false;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(102, 4);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(202, 20);
            this.txtMotivo.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Motivo de Cambio";
            // 
            // panelFamiliar
            // 
            this.panelFamiliar.Controls.Add(this.txtHijos);
            this.panelFamiliar.Controls.Add(this.cbxEstadoCivil);
            this.panelFamiliar.Controls.Add(this.label6);
            this.panelFamiliar.Controls.Add(this.label8);
            this.panelFamiliar.Location = new System.Drawing.Point(22, 33);
            this.panelFamiliar.Name = "panelFamiliar";
            this.panelFamiliar.Size = new System.Drawing.Size(312, 57);
            this.panelFamiliar.TabIndex = 41;
            // 
            // txtHijos
            // 
            this.txtHijos.Location = new System.Drawing.Point(101, 33);
            this.txtHijos.Name = "txtHijos";
            this.txtHijos.Size = new System.Drawing.Size(200, 20);
            this.txtHijos.TabIndex = 23;
            // 
            // cbxEstadoCivil
            // 
            this.cbxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCivil.FormattingEnabled = true;
            this.cbxEstadoCivil.Location = new System.Drawing.Point(101, 5);
            this.cbxEstadoCivil.Name = "cbxEstadoCivil";
            this.cbxEstadoCivil.Size = new System.Drawing.Size(200, 21);
            this.cbxEstadoCivil.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Estado Civil";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Cantidad de Hijos";
            // 
            // cbxPlanMedico
            // 
            this.cbxPlanMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlanMedico.FormattingEnabled = true;
            this.cbxPlanMedico.Location = new System.Drawing.Point(123, 3);
            this.cbxPlanMedico.Name = "cbxPlanMedico";
            this.cbxPlanMedico.Size = new System.Drawing.Size(200, 21);
            this.cbxPlanMedico.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "PlanMedico";
            // 
            // AfiliadoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMotivo);
            this.Controls.Add(this.panelFamiliar);
            this.Controls.Add(this.cbxPlanMedico);
            this.Controls.Add(this.label10);
            this.Name = "AfiliadoUserControl";
            this.Size = new System.Drawing.Size(437, 271);
            this.Load += new System.EventHandler(this.AfiliadoUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMotivo.ResumeLayout(false);
            this.panelMotivo.PerformLayout();
            this.panelFamiliar.ResumeLayout(false);
            this.panelFamiliar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Panel panelMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelFamiliar;
        private System.Windows.Forms.TextBox txtHijos;
        private System.Windows.Forms.ComboBox cbxEstadoCivil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxPlanMedico;
        private System.Windows.Forms.Label label10;

    }
}

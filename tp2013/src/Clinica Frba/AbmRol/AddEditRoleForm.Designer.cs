namespace ClinicaFrba
{
    partial class AddEditRoleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lstFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.perfilPanel = new System.Windows.Forms.Panel();
            this.cbxPerfiles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rolPanel = new System.Windows.Forms.Panel();
            this.perfilPanel.SuspendLayout();
            this.rolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionalidades";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(113, 2);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lstFuncionalidades
            // 
            this.lstFuncionalidades.FormattingEnabled = true;
            this.lstFuncionalidades.Location = new System.Drawing.Point(113, 28);
            this.lstFuncionalidades.Name = "lstFuncionalidades";
            this.lstFuncionalidades.Size = new System.Drawing.Size(156, 139);
            this.lstFuncionalidades.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(197, 214);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(13, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // perfilPanel
            // 
            this.perfilPanel.Controls.Add(this.cbxPerfiles);
            this.perfilPanel.Controls.Add(this.label3);
            this.perfilPanel.Enabled = false;
            this.perfilPanel.Location = new System.Drawing.Point(3, 3);
            this.perfilPanel.Name = "perfilPanel";
            this.perfilPanel.Size = new System.Drawing.Size(278, 33);
            this.perfilPanel.TabIndex = 6;
            this.perfilPanel.Visible = false;
            // 
            // cbxPerfiles
            // 
            this.cbxPerfiles.FormattingEnabled = true;
            this.cbxPerfiles.Location = new System.Drawing.Point(113, 3);
            this.cbxPerfiles.Name = "cbxPerfiles";
            this.cbxPerfiles.Size = new System.Drawing.Size(156, 21);
            this.cbxPerfiles.TabIndex = 1;
            this.cbxPerfiles.SelectedIndexChanged += new System.EventHandler(this.cbxPerfiles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Perfil";
            // 
            // rolPanel
            // 
            this.rolPanel.Controls.Add(this.lstFuncionalidades);
            this.rolPanel.Controls.Add(this.txtNombre);
            this.rolPanel.Controls.Add(this.label2);
            this.rolPanel.Controls.Add(this.label1);
            this.rolPanel.Location = new System.Drawing.Point(3, 41);
            this.rolPanel.Name = "rolPanel";
            this.rolPanel.Size = new System.Drawing.Size(278, 173);
            this.rolPanel.TabIndex = 7;
            // 
            // AddEditRoleForm
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(284, 250);
            this.Controls.Add(this.rolPanel);
            this.Controls.Add(this.perfilPanel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRoleForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.AddEditRoleForm_Load);
            this.perfilPanel.ResumeLayout(false);
            this.perfilPanel.PerformLayout();
            this.rolPanel.ResumeLayout(false);
            this.rolPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckedListBox lstFuncionalidades;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel perfilPanel;
        private System.Windows.Forms.ComboBox cbxPerfiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel rolPanel;
    }
}
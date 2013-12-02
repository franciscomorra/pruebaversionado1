namespace ClinicaFrba.AbmTurno
{
    partial class TurnosForm
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonsPanel.SuspendLayout();
            this.panelAfiliado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonsPanel.Controls.Add(this.btnCancelar);
            this.buttonsPanel.Controls.Add(this.btnAgregar);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 43);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(843, 39);
            this.buttonsPanel.TabIndex = 2;
            this.buttonsPanel.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(93, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar Turno";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Nuevo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelAfiliado
            // 
            this.panelAfiliado.Controls.Add(this.btnBuscarAfiliado);
            this.panelAfiliado.Controls.Add(this.lblAfiliado);
            this.panelAfiliado.Controls.Add(this.txtAfiliado);
            this.panelAfiliado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAfiliado.Location = new System.Drawing.Point(0, 0);
            this.panelAfiliado.Name = "panelAfiliado";
            this.panelAfiliado.Size = new System.Drawing.Size(843, 43);
            this.panelAfiliado.TabIndex = 1;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(344, 7);
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
            this.txtAfiliado.Location = new System.Drawing.Point(71, 9);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.ReadOnly = true;
            this.txtAfiliado.Size = new System.Drawing.Size(250, 20);
            this.txtAfiliado.TabIndex = 33;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AllowUserToOrderColumns = true;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Profesional,
            this.Numero});
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 82);
            this.dgvTurnos.MultiSelect = false;
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(843, 379);
            this.dgvTurnos.TabIndex = 4;
            this.dgvTurnos.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Profesional
            // 
            this.Profesional.DataPropertyName = "Profesional";
            this.Profesional.HeaderText = "Profesional";
            this.Profesional.Name = "Profesional";
            this.Profesional.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // TurnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 461);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.panelAfiliado);
            this.Name = "TurnosForm";
            this.Text = "Administrar Turnos";
            this.Load += new System.EventHandler(this.TurnosForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
    }
}
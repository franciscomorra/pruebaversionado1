namespace ClinicaFrba.AbmBono
{
    partial class BonosForm
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfiliadoCompro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            this.panelAfiliado.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonsPanel.Controls.Add(this.btnAgregar);
            this.buttonsPanel.Location = new System.Drawing.Point(0, 51);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(834, 39);
            this.buttonsPanel.TabIndex = 4;
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
            // dgvBonos
            // 
            this.dgvBonos.AllowUserToAddRows = false;
            this.dgvBonos.AllowUserToDeleteRows = false;
            this.dgvBonos.AllowUserToOrderColumns = true;
            this.dgvBonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.AfiliadoCompro});
            this.dgvBonos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBonos.Location = new System.Drawing.Point(0, 96);
            this.dgvBonos.MultiSelect = false;
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonos.Size = new System.Drawing.Size(834, 422);
            this.dgvBonos.TabIndex = 5;
            // 
            // panelAfiliado
            // 
            this.panelAfiliado.Controls.Add(this.btnBuscarAfiliado);
            this.panelAfiliado.Controls.Add(this.lblAfiliado);
            this.panelAfiliado.Controls.Add(this.txtAfiliado);
            this.panelAfiliado.Location = new System.Drawing.Point(0, 2);
            this.panelAfiliado.Name = "panelAfiliado";
            this.panelAfiliado.Size = new System.Drawing.Size(831, 43);
            this.panelAfiliado.TabIndex = 23;
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
            // Numero
            // 
            this.Numero.HeaderText = "Numero de Bono";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // AfiliadoCompro
            // 
            this.AfiliadoCompro.HeaderText = "Comprado Por";
            this.AfiliadoCompro.Name = "AfiliadoCompro";
            this.AfiliadoCompro.ReadOnly = true;
            // 
            // BonosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 518);
            this.Controls.Add(this.panelAfiliado);
            this.Controls.Add(this.dgvBonos);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "BonosForm";
            this.Text = "Administrar Bonos";
            this.Load += new System.EventHandler(this.BonosForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfiliadoCompro;
    }
}
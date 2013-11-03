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
            this.lblResults = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.panelAfiliado.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonsPanel.Controls.Add(this.lblResults);
            this.buttonsPanel.Controls.Add(this.label5);
            this.buttonsPanel.Controls.Add(this.btnCancelar);
            this.buttonsPanel.Controls.Add(this.btnAgregar);
            this.buttonsPanel.Location = new System.Drawing.Point(0, 51);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(834, 39);
            this.buttonsPanel.TabIndex = 4;
            // 
            // lblResults
            // 
            this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResults.AutoSize = true;
            this.lblResults.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResults.Location = new System.Drawing.Point(746, 20);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(14, 13);
            this.lblResults.TabIndex = 4;
            this.lblResults.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(766, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "resultados";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(93, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Nuevo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AllowUserToOrderColumns = true;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 96);
            this.dgvTurnos.MultiSelect = false;
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(834, 422);
            this.dgvTurnos.TabIndex = 5;
            this.dgvTurnos.DataSourceChanged += new System.EventHandler(this.dgvTurnos_DataSourceChanged);
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
            this.panelAfiliado.Visible = false;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(180, 7);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAfiliado.TabIndex = 34;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
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
            this.txtAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txtAfiliado.TabIndex = 33;
            // 
            // TurnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 518);
            this.Controls.Add(this.panelAfiliado);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "TurnosForm";
            this.Text = "Administrar Turnos";
            this.Load += new System.EventHandler(this.TurnosForm_Load);
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
    }
}
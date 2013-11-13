namespace FrbaBus.Abm_Micro
{
    partial class ButacaForm
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
            this.datagvButca = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.txtNumeroButaca = new System.Windows.Forms.TextBox();
            this.volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PATENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PISO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODIFICAR = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagvButca)).BeginInit();
            this.SuspendLayout();
            // 
            // datagvButca
            // 
            this.datagvButca.AllowUserToAddRows = false;
            this.datagvButca.AllowUserToDeleteRows = false;
            this.datagvButca.AllowUserToResizeColumns = false;
            this.datagvButca.AllowUserToResizeRows = false;
            this.datagvButca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvButca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvButca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PATENTE,
            this.NUMERO,
            this.TIPO,
            this.PISO,
            this.MODIFICAR});
            this.datagvButca.Location = new System.Drawing.Point(0, 73);
            this.datagvButca.Name = "datagvButca";
            this.datagvButca.ReadOnly = true;
            this.datagvButca.Size = new System.Drawing.Size(561, 294);
            this.datagvButca.TabIndex = 0;
            this.datagvButca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvButca_CellClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(435, 41);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(114, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar Butaca";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(292, 41);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // cmbPiso
            // 
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(151, 41);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(121, 21);
            this.cmbPiso.TabIndex = 4;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(207, 12);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(118, 20);
            this.txtPatente.TabIndex = 5;
            this.txtPatente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroButaca
            // 
            this.txtNumeroButaca.Location = new System.Drawing.Point(12, 41);
            this.txtNumeroButaca.MaxLength = 9;
            this.txtNumeroButaca.Name = "txtNumeroButaca";
            this.txtNumeroButaca.Size = new System.Drawing.Size(118, 20);
            this.txtNumeroButaca.TabIndex = 6;
            this.txtNumeroButaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroButaca_KeyPress);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(435, 12);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(114, 23);
            this.volver.TabIndex = 7;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Patente";
            // 
            // PATENTE
            // 
            this.PATENTE.DataPropertyName = "PATENTE";
            this.PATENTE.HeaderText = "PATENTE";
            this.PATENTE.Name = "PATENTE";
            this.PATENTE.ReadOnly = true;
            this.PATENTE.Visible = false;
            // 
            // NUMERO
            // 
            this.NUMERO.DataPropertyName = "NUMERO";
            this.NUMERO.HeaderText = "NUMERO";
            this.NUMERO.Name = "NUMERO";
            this.NUMERO.ReadOnly = true;
            this.NUMERO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TIPO
            // 
            this.TIPO.DataPropertyName = "TIPO";
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PISO
            // 
            this.PISO.DataPropertyName = "PISO";
            this.PISO.HeaderText = "PISO";
            this.PISO.Name = "PISO";
            this.PISO.ReadOnly = true;
            this.PISO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MODIFICAR
            // 
            this.MODIFICAR.HeaderText = "MODIFICAR";
            this.MODIFICAR.Name = "MODIFICAR";
            this.MODIFICAR.ReadOnly = true;
            this.MODIFICAR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MODIFICAR.Text = "Modificar";
            this.MODIFICAR.UseColumnTextForButtonValue = true;
            // 
            // ButacaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 368);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.txtNumeroButaca);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.cmbPiso);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.datagvButca);
            this.Name = "ButacaForm";
            this.Text = "ButacaForm";
            this.Load += new System.EventHandler(this.ButacaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvButca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagvButca;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtNumeroButaca;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PISO;
        private System.Windows.Forms.DataGridViewButtonColumn MODIFICAR;
    }
}
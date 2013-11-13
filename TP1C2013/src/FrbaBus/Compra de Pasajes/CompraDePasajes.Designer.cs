namespace FrbaBus.Compra_de_Pasajes
{
    partial class CompraDePasajes
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxOrigen = new System.Windows.Forms.ComboBox();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TIPO_SERVICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_SALIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_LLEGADA_ESTIMADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KG_DISPONIBLES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUTACAS_DISPONIBLES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPRAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listarCompra = new System.Windows.Forms.Button();
            this.confirmarCompra = new System.Windows.Forms.Button();
            this.CancelarCompra = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // comboBoxOrigen
            // 
            this.comboBoxOrigen.FormattingEnabled = true;
            this.comboBoxOrigen.Location = new System.Drawing.Point(12, 72);
            this.comboBoxOrigen.Name = "comboBoxOrigen";
            this.comboBoxOrigen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrigen.TabIndex = 1;
            this.comboBoxOrigen.SelectedValueChanged += new System.EventHandler(this.comboBoxOrigen_SelectedValueChanged);
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(226, 72);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDestino.TabIndex = 2;
            this.comboBoxDestino.SelectedValueChanged += new System.EventHandler(this.comboBoxDestino_SelectedValueChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(272, 28);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 3;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO_SERVICIO,
            this.ID,
            this.PATENTE,
            this.FECHA_SALIDA,
            this.FECHA_LLEGADA_ESTIMADA,
            this.KG_DISPONIBLES,
            this.BUTACAS_DISPONIBLES,
            this.COMPRAR});
            this.dataGridView1.Location = new System.Drawing.Point(0, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(815, 367);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // TIPO_SERVICIO
            // 
            this.TIPO_SERVICIO.DataPropertyName = "TIPO_SERVICIO";
            this.TIPO_SERVICIO.HeaderText = "TIPO_SERVICIO";
            this.TIPO_SERVICIO.Name = "TIPO_SERVICIO";
            this.TIPO_SERVICIO.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Visible = false;
            // 
            // PATENTE
            // 
            this.PATENTE.DataPropertyName = "PATENTE";
            this.PATENTE.HeaderText = "PATENTE";
            this.PATENTE.Name = "PATENTE";
            this.PATENTE.ReadOnly = true;
            this.PATENTE.Visible = false;
            // 
            // FECHA_SALIDA
            // 
            this.FECHA_SALIDA.DataPropertyName = "FECHA_SALIDA";
            this.FECHA_SALIDA.HeaderText = "FECHA_SALIDA";
            this.FECHA_SALIDA.Name = "FECHA_SALIDA";
            this.FECHA_SALIDA.ReadOnly = true;
            // 
            // FECHA_LLEGADA_ESTIMADA
            // 
            this.FECHA_LLEGADA_ESTIMADA.DataPropertyName = "FECHA_LLEGADA_ESTIMADA";
            this.FECHA_LLEGADA_ESTIMADA.HeaderText = "FECHA_LLEGADA_ESTIMADA";
            this.FECHA_LLEGADA_ESTIMADA.Name = "FECHA_LLEGADA_ESTIMADA";
            this.FECHA_LLEGADA_ESTIMADA.ReadOnly = true;
            // 
            // KG_DISPONIBLES
            // 
            this.KG_DISPONIBLES.DataPropertyName = "KG_DISPONIBLES";
            this.KG_DISPONIBLES.HeaderText = "KG_DISPONIBLES";
            this.KG_DISPONIBLES.Name = "KG_DISPONIBLES";
            this.KG_DISPONIBLES.ReadOnly = true;
            // 
            // BUTACAS_DISPONIBLES
            // 
            this.BUTACAS_DISPONIBLES.DataPropertyName = "BUTACAS_DISPONIBLES";
            this.BUTACAS_DISPONIBLES.HeaderText = "BUTACAS_DISPONIBLES";
            this.BUTACAS_DISPONIBLES.Name = "BUTACAS_DISPONIBLES";
            this.BUTACAS_DISPONIBLES.ReadOnly = true;
            // 
            // COMPRAR
            // 
            this.COMPRAR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COMPRAR.HeaderText = "SELECCIONAR";
            this.COMPRAR.Name = "COMPRAR";
            this.COMPRAR.ReadOnly = true;
            this.COMPRAR.Text = "Seleccionar Viaje";
            this.COMPRAR.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha de Salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ciudad Destino";
            // 
            // listarCompra
            // 
            this.listarCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listarCompra.Location = new System.Drawing.Point(686, 25);
            this.listarCompra.Name = "listarCompra";
            this.listarCompra.Size = new System.Drawing.Size(120, 23);
            this.listarCompra.TabIndex = 8;
            this.listarCompra.Text = "Listar Compra";
            this.listarCompra.UseVisualStyleBackColor = true;
            this.listarCompra.Click += new System.EventHandler(this.button1_Click);
            // 
            // confirmarCompra
            // 
            this.confirmarCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmarCompra.Location = new System.Drawing.Point(540, 70);
            this.confirmarCompra.Name = "confirmarCompra";
            this.confirmarCompra.Size = new System.Drawing.Size(122, 23);
            this.confirmarCompra.TabIndex = 9;
            this.confirmarCompra.Text = "Confirmar Compra";
            this.confirmarCompra.UseVisualStyleBackColor = true;
            this.confirmarCompra.Click += new System.EventHandler(this.button2_Click);
            // 
            // CancelarCompra
            // 
            this.CancelarCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarCompra.Location = new System.Drawing.Point(684, 70);
            this.CancelarCompra.Name = "CancelarCompra";
            this.CancelarCompra.Size = new System.Drawing.Size(122, 23);
            this.CancelarCompra.TabIndex = 10;
            this.CancelarCompra.Text = "Cerrar";
            this.CancelarCompra.UseVisualStyleBackColor = true;
            this.CancelarCompra.Click += new System.EventHandler(this.CancelarCompra_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 499);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 11);
            this.panel1.TabIndex = 11;
            // 
            // CompraDePasajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelarCompra);
            this.Controls.Add(this.confirmarCompra);
            this.Controls.Add(this.listarCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.comboBoxOrigen);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "CompraDePasajes";
            this.Text = "Compra De Pasajes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxOrigen;
        private System.Windows.Forms.ComboBox comboBoxDestino;
        private System.Windows.Forms.Button Seleccionar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button listarCompra;
        private System.Windows.Forms.Button confirmarCompra;
        private System.Windows.Forms.Button CancelarCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_SERVICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_SALIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_LLEGADA_ESTIMADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn KG_DISPONIBLES;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUTACAS_DISPONIBLES;
        private System.Windows.Forms.DataGridViewButtonColumn COMPRAR;
        private System.Windows.Forms.Panel panel1;
    }
}
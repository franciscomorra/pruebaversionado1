namespace FrbaBus.Cancelar_Viaje
{
    partial class CancelarViaje
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
            this.IDCompra = new System.Windows.Forms.TextBox();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Chequear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CancelarItems = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MotivoCancelacion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KGBUTACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANCELACION = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDCompra
            // 
            this.IDCompra.Location = new System.Drawing.Point(13, 12);
            this.IDCompra.MaxLength = 9;
            this.IDCompra.Name = "IDCompra";
            this.IDCompra.Size = new System.Drawing.Size(179, 20);
            this.IDCompra.TabIndex = 0;
            this.IDCompra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IDCompra_MouseClick);
            this.IDCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDCompra_KeyPress);
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(439, 12);
            this.DNI.MaxLength = 18;
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(168, 20);
            this.DNI.TabIndex = 1;
            this.DNI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DNI_MouseClick);
            this.DNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DNI_KeyPress);
            // 
            // Chequear
            // 
            this.Chequear.Location = new System.Drawing.Point(266, 38);
            this.Chequear.Name = "Chequear";
            this.Chequear.Size = new System.Drawing.Size(75, 23);
            this.Chequear.TabIndex = 2;
            this.Chequear.Text = "Seleccionar";
            this.Chequear.UseVisualStyleBackColor = true;
            this.Chequear.Click += new System.EventHandler(this.Chequear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO,
            this.CODIGO,
            this.KGBUTACA,
            this.PRECIO,
            this.CANCELACION});
            this.dataGridView1.Location = new System.Drawing.Point(6, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(594, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // CancelarItems
            // 
            this.CancelarItems.Location = new System.Drawing.Point(259, 268);
            this.CancelarItems.Name = "CancelarItems";
            this.CancelarItems.Size = new System.Drawing.Size(110, 23);
            this.CancelarItems.TabIndex = 5;
            this.CancelarItems.Text = "Cancelar Items";
            this.CancelarItems.UseVisualStyleBackColor = true;
            this.CancelarItems.Click += new System.EventHandler(this.CancelarItems_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(526, 387);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(81, 23);
            this.Cancelar.TabIndex = 6;
            this.Cancelar.Text = "Cerrar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MotivoCancelacion);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.CancelarItems);
            this.groupBox1.Location = new System.Drawing.Point(7, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 297);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // MotivoCancelacion
            // 
            this.MotivoCancelacion.Location = new System.Drawing.Point(6, 194);
            this.MotivoCancelacion.MaxLength = 255;
            this.MotivoCancelacion.Multiline = true;
            this.MotivoCancelacion.Name = "MotivoCancelacion";
            this.MotivoCancelacion.Size = new System.Drawing.Size(594, 68);
            this.MotivoCancelacion.TabIndex = 6;
            this.MotivoCancelacion.Text = "Ingrese el motivo de la cancelación...";
            this.MotivoCancelacion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MotivoCancelacion_MouseClick);
            this.MotivoCancelacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MotivoCancelacion_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.DNI);
            this.panel1.Controls.Add(this.Chequear);
            this.panel1.Controls.Add(this.IDCompra);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Cancelar);
            this.panel1.Location = new System.Drawing.Point(40, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 434);
            this.panel1.TabIndex = 8;
            // 
            // TIPO
            // 
            this.TIPO.DataPropertyName = "TIPO";
            this.TIPO.HeaderText = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "ID";
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            // 
            // KGBUTACA
            // 
            this.KGBUTACA.DataPropertyName = "KG_BUTACA";
            this.KGBUTACA.HeaderText = "KG / BUTACA";
            this.KGBUTACA.Name = "KGBUTACA";
            this.KGBUTACA.ReadOnly = true;
            // 
            // PRECIO
            // 
            this.PRECIO.DataPropertyName = "PRECIO";
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            // 
            // CANCELACION
            // 
            this.CANCELACION.DataPropertyName = "CANCELADO";
            this.CANCELACION.HeaderText = "CANCELAR";
            this.CANCELACION.Name = "CANCELACION";
            // 
            // CancelarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 486);
            this.Controls.Add(this.panel1);
            this.Name = "CancelarViaje";
            this.Text = "CancelarViaje";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IDCompra;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Button Chequear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CancelarItems;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox MotivoCancelacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KGBUTACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CANCELACION;
    }
}
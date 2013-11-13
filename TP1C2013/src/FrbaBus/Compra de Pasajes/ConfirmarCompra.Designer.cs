namespace FrbaBus.Compra_de_Pasajes
{
    partial class ConfirmarCompra
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
            this.button1 = new System.Windows.Forms.Button();
            this.DNIElegido = new System.Windows.Forms.TextBox();
            this.Tarjeta = new System.Windows.Forms.Button();
            this.compraEfectivo = new System.Windows.Forms.Button();
            this.groupBoxTarjeta = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Confirmar = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SeleccionarTarjeta = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MontoAbonar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Seleccionar Comprador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DNIElegido
            // 
            this.DNIElegido.Location = new System.Drawing.Point(12, 30);
            this.DNIElegido.Name = "DNIElegido";
            this.DNIElegido.ReadOnly = true;
            this.DNIElegido.ShortcutsEnabled = false;
            this.DNIElegido.Size = new System.Drawing.Size(137, 20);
            this.DNIElegido.TabIndex = 1;
            this.DNIElegido.TabStop = false;
            // 
            // Tarjeta
            // 
            this.Tarjeta.Location = new System.Drawing.Point(12, 94);
            this.Tarjeta.Name = "Tarjeta";
            this.Tarjeta.Size = new System.Drawing.Size(75, 23);
            this.Tarjeta.TabIndex = 2;
            this.Tarjeta.Text = "Tarjeta";
            this.Tarjeta.UseVisualStyleBackColor = true;
            this.Tarjeta.Click += new System.EventHandler(this.Tarjeta_Click);
            // 
            // compraEfectivo
            // 
            this.compraEfectivo.Location = new System.Drawing.Point(236, 94);
            this.compraEfectivo.Name = "compraEfectivo";
            this.compraEfectivo.Size = new System.Drawing.Size(75, 23);
            this.compraEfectivo.TabIndex = 3;
            this.compraEfectivo.Text = "Efectivo";
            this.compraEfectivo.UseVisualStyleBackColor = true;
            this.compraEfectivo.Click += new System.EventHandler(this.Efectivo_Click);
            // 
            // groupBoxTarjeta
            // 
            this.groupBoxTarjeta.Controls.Add(this.label5);
            this.groupBoxTarjeta.Controls.Add(this.label4);
            this.groupBoxTarjeta.Controls.Add(this.label3);
            this.groupBoxTarjeta.Controls.Add(this.label2);
            this.groupBoxTarjeta.Controls.Add(this.label1);
            this.groupBoxTarjeta.Controls.Add(this.Confirmar);
            this.groupBoxTarjeta.Controls.Add(this.comboBox2);
            this.groupBoxTarjeta.Controls.Add(this.comboBox1);
            this.groupBoxTarjeta.Controls.Add(this.dateTimePicker1);
            this.groupBoxTarjeta.Controls.Add(this.textBox3);
            this.groupBoxTarjeta.Controls.Add(this.SeleccionarTarjeta);
            this.groupBoxTarjeta.Controls.Add(this.textBox2);
            this.groupBoxTarjeta.Location = new System.Drawing.Point(12, 123);
            this.groupBoxTarjeta.Name = "groupBoxTarjeta";
            this.groupBoxTarjeta.Size = new System.Drawing.Size(304, 231);
            this.groupBoxTarjeta.TabIndex = 4;
            this.groupBoxTarjeta.TabStop = false;
            this.groupBoxTarjeta.Text = "Pago Tarjeta";
            this.groupBoxTarjeta.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad de Cuotas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo de Tarjeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha de Vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Código de Seguridad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Número de Tarjeta";
            // 
            // Confirmar
            // 
            this.Confirmar.Location = new System.Drawing.Point(223, 202);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(75, 23);
            this.Confirmar.TabIndex = 6;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = true;
            this.Confirmar.Click += new System.EventHandler(this.Confirmar_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(16, 204);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.CustomFormat = "MM / yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 117);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 78);
            this.textBox3.MaxLength = 98;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // SeleccionarTarjeta
            // 
            this.SeleccionarTarjeta.Location = new System.Drawing.Point(152, 36);
            this.SeleccionarTarjeta.Name = "SeleccionarTarjeta";
            this.SeleccionarTarjeta.Size = new System.Drawing.Size(146, 23);
            this.SeleccionarTarjeta.TabIndex = 1;
            this.SeleccionarTarjeta.Text = "Seleccionar Tarjeta";
            this.SeleccionarTarjeta.UseVisualStyleBackColor = true;
            this.SeleccionarTarjeta.Click += new System.EventHandler(this.SeleccionarTarjeta_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 36);
            this.textBox2.MaxLength = 9;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // MontoAbonar
            // 
            this.MontoAbonar.Location = new System.Drawing.Point(85, 68);
            this.MontoAbonar.Name = "MontoAbonar";
            this.MontoAbonar.ReadOnly = true;
            this.MontoAbonar.ShortcutsEnabled = false;
            this.MontoAbonar.Size = new System.Drawing.Size(154, 20);
            this.MontoAbonar.TabIndex = 5;
            this.MontoAbonar.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Monto a Abonar";
            // 
            // ConfirmarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 366);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MontoAbonar);
            this.Controls.Add(this.groupBoxTarjeta);
            this.Controls.Add(this.compraEfectivo);
            this.Controls.Add(this.Tarjeta);
            this.Controls.Add(this.DNIElegido);
            this.Controls.Add(this.button1);
            this.Name = "ConfirmarCompra";
            this.Text = "ConfirmarCompra";
            this.groupBoxTarjeta.ResumeLayout(false);
            this.groupBoxTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DNIElegido;
        private System.Windows.Forms.Button Tarjeta;
        private System.Windows.Forms.Button compraEfectivo;
        private System.Windows.Forms.GroupBox groupBoxTarjeta;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button SeleccionarTarjeta;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox MontoAbonar;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}
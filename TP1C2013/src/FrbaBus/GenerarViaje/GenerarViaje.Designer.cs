namespace FrbaBus.GenerarViaje
{
    partial class GenerarViaje
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
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.SelecRecorrido = new System.Windows.Forms.Button();
            this.dateTimePicker1Salida = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2Llegada = new System.Windows.Forms.DateTimePicker();
            this.SelecFechas = new System.Windows.Forms.Button();
            this.cmbPatente = new System.Windows.Forms.ComboBox();
            this.generar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(109, 27);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(201, 21);
            this.cmbCiudadOrigen.TabIndex = 0;
            this.cmbCiudadOrigen.SelectedValueChanged += new System.EventHandler(this.cmbCiudadOrigen_SelectedValueChanged);
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(110, 54);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(200, 21);
            this.cmbCiudadDestino.TabIndex = 1;
            this.cmbCiudadDestino.SelectedValueChanged += new System.EventHandler(this.cmbCiudadDestino_SelectedValueChanged);
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Location = new System.Drawing.Point(110, 81);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoServicio.TabIndex = 2;
            this.cmbTipoServicio.SelectedValueChanged += new System.EventHandler(this.cmbTipoServicio_SelectedValueChanged);
            // 
            // SelecRecorrido
            // 
            this.SelecRecorrido.Location = new System.Drawing.Point(334, 54);
            this.SelecRecorrido.Name = "SelecRecorrido";
            this.SelecRecorrido.Size = new System.Drawing.Size(122, 23);
            this.SelecRecorrido.TabIndex = 3;
            this.SelecRecorrido.Text = "Seleccionar Recorrido";
            this.SelecRecorrido.UseVisualStyleBackColor = true;
            this.SelecRecorrido.Click += new System.EventHandler(this.SelecRecorrido_Click);
            // 
            // dateTimePicker1Salida
            // 
            this.dateTimePicker1Salida.Location = new System.Drawing.Point(110, 33);
            this.dateTimePicker1Salida.Name = "dateTimePicker1Salida";
            this.dateTimePicker1Salida.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1Salida.TabIndex = 4;
            // 
            // dateTimePicker2Llegada
            // 
            this.dateTimePicker2Llegada.Location = new System.Drawing.Point(110, 59);
            this.dateTimePicker2Llegada.Name = "dateTimePicker2Llegada";
            this.dateTimePicker2Llegada.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2Llegada.TabIndex = 5;
            // 
            // SelecFechas
            // 
            this.SelecFechas.Location = new System.Drawing.Point(334, 55);
            this.SelecFechas.Name = "SelecFechas";
            this.SelecFechas.Size = new System.Drawing.Size(122, 23);
            this.SelecFechas.TabIndex = 6;
            this.SelecFechas.Text = "Seleccionar Fechas";
            this.SelecFechas.UseVisualStyleBackColor = true;
            this.SelecFechas.Click += new System.EventHandler(this.SelecFechas_Click);
            // 
            // cmbPatente
            // 
            this.cmbPatente.FormattingEnabled = true;
            this.cmbPatente.Location = new System.Drawing.Point(186, 50);
            this.cmbPatente.Name = "cmbPatente";
            this.cmbPatente.Size = new System.Drawing.Size(124, 21);
            this.cmbPatente.TabIndex = 7;
            this.cmbPatente.SelectedValueChanged += new System.EventHandler(this.cmbPatente_SelectedValueChanged);
            // 
            // generar
            // 
            this.generar.Location = new System.Drawing.Point(6, 389);
            this.generar.Name = "generar";
            this.generar.Size = new System.Drawing.Size(122, 23);
            this.generar.TabIndex = 8;
            this.generar.Text = "Generar Viaje";
            this.generar.UseVisualStyleBackColor = true;
            this.generar.Click += new System.EventHandler(this.generar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(393, 389);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 9;
            this.cancelar.Text = "Cerrar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCiudadDestino);
            this.groupBox1.Controls.Add(this.cmbCiudadOrigen);
            this.groupBox1.Controls.Add(this.cmbTipoServicio);
            this.groupBox1.Controls.Add(this.SelecRecorrido);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 109);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorrido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ciudad Origen";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePicker1Salida);
            this.groupBox2.Controls.Add(this.dateTimePicker2Llegada);
            this.groupBox2.Controls.Add(this.SelecFechas);
            this.groupBox2.Location = new System.Drawing.Point(6, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 122);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de Llegada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Salida";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbPatente);
            this.groupBox3.Location = new System.Drawing.Point(6, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 100);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Micro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Patente";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.cancelar);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.generar);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 420);
            this.panel1.TabIndex = 13;
            // 
            // GenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 427);
            this.Controls.Add(this.panel1);
            this.Name = "GenerarViaje";
            this.Text = "GenerarViaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.Button SelecRecorrido;
        private System.Windows.Forms.DateTimePicker dateTimePicker1Salida;
        private System.Windows.Forms.DateTimePicker dateTimePicker2Llegada;
        private System.Windows.Forms.Button SelecFechas;
        private System.Windows.Forms.ComboBox cmbPatente;
        private System.Windows.Forms.Button generar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
    }
}
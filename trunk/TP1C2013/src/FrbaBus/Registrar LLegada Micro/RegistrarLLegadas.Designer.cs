namespace FrbaBus.Registrar_LLegada_Micro
{
    partial class RegistrarLLegadas
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
            this.CiudadOrigenBox = new System.Windows.Forms.ComboBox();
            this.CiudadDestinoBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CargarButton = new System.Windows.Forms.Button();
            this.PatenteBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CiudadOrigenBox
            // 
            this.CiudadOrigenBox.FormattingEnabled = true;
            this.CiudadOrigenBox.Location = new System.Drawing.Point(179, 69);
            this.CiudadOrigenBox.Name = "CiudadOrigenBox";
            this.CiudadOrigenBox.Size = new System.Drawing.Size(121, 21);
            this.CiudadOrigenBox.TabIndex = 1;
            this.CiudadOrigenBox.SelectedValueChanged += new System.EventHandler(this.CiudadOrigenBox_SelectedValueChanged);
            // 
            // CiudadDestinoBox
            // 
            this.CiudadDestinoBox.FormattingEnabled = true;
            this.CiudadDestinoBox.Location = new System.Drawing.Point(179, 104);
            this.CiudadDestinoBox.Name = "CiudadDestinoBox";
            this.CiudadDestinoBox.Size = new System.Drawing.Size(121, 21);
            this.CiudadDestinoBox.TabIndex = 2;
            this.CiudadDestinoBox.SelectedValueChanged += new System.EventHandler(this.CiudadDestinoBox_SelectedValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 152);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Patente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ciudad_Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ciudad_Destino";
            // 
            // CargarButton
            // 
            this.CargarButton.Location = new System.Drawing.Point(10, 222);
            this.CargarButton.Name = "CargarButton";
            this.CargarButton.Size = new System.Drawing.Size(75, 23);
            this.CargarButton.TabIndex = 7;
            this.CargarButton.Text = "Cargar";
            this.CargarButton.UseVisualStyleBackColor = true;
            this.CargarButton.Click += new System.EventHandler(this.Cargar_Click);
            // 
            // PatenteBox
            // 
            this.PatenteBox.FormattingEnabled = true;
            this.PatenteBox.Location = new System.Drawing.Point(179, 25);
            this.PatenteBox.Name = "PatenteBox";
            this.PatenteBox.Size = new System.Drawing.Size(121, 21);
            this.PatenteBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Llegada";
            // 
            // salir
            // 
            this.salir.Location = new System.Drawing.Point(225, 222);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(75, 23);
            this.salir.TabIndex = 10;
            this.salir.Text = "Cerrar";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.salir);
            this.panel1.Controls.Add(this.PatenteBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CiudadOrigenBox);
            this.panel1.Controls.Add(this.CiudadDestinoBox);
            this.panel1.Controls.Add(this.CargarButton);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 252);
            this.panel1.TabIndex = 11;
            // 
            // RegistrarLLegadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 267);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrarLLegadas";
            this.Text = "RegistrarLLegadas";
            this.Load += new System.EventHandler(this.RegistrarLLegadas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CiudadOrigenBox;
        private System.Windows.Forms.ComboBox CiudadDestinoBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CargarButton;
        private System.Windows.Forms.ComboBox PatenteBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Panel panel1;

        public System.EventHandler dateTimePicker1_ValueChanged { get; set; }

    
    }
}
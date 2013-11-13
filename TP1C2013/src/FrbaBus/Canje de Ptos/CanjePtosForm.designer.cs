namespace FrbaBus.Canje_de_Ptos
{
    partial class CanjePtosForm
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
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.Canjear = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.comboBoxProductos = new System.Windows.Forms.ComboBox();
            this.textBoxMaxDisponible = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(6, 19);
            this.textBoxDNI.MaxLength = 9;
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.ShortcutsEnabled = false;
            this.textBoxDNI.Size = new System.Drawing.Size(123, 20);
            this.textBoxDNI.TabIndex = 0;
            this.textBoxDNI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxDNI_MouseClick);
            this.textBoxDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDNI_KeyPress);
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(157, 16);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 1;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // Canjear
            // 
            this.Canjear.Location = new System.Drawing.Point(6, 217);
            this.Canjear.Name = "Canjear";
            this.Canjear.Size = new System.Drawing.Size(75, 23);
            this.Canjear.TabIndex = 2;
            this.Canjear.Text = "Canjear";
            this.Canjear.UseVisualStyleBackColor = true;
            this.Canjear.Click += new System.EventHandler(this.Canjear_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(90, 217);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 3;
            this.Cancelar.Text = "Limpiar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // comboBoxProductos
            // 
            this.comboBoxProductos.AllowDrop = true;
            this.comboBoxProductos.FormattingEnabled = true;
            this.comboBoxProductos.Location = new System.Drawing.Point(6, 66);
            this.comboBoxProductos.Name = "comboBoxProductos";
            this.comboBoxProductos.Size = new System.Drawing.Size(226, 21);
            this.comboBoxProductos.TabIndex = 4;
            this.comboBoxProductos.SelectedValueChanged += new System.EventHandler(this.comboBoxProductos_SelectedValueChanged);
            // 
            // textBoxMaxDisponible
            // 
            this.textBoxMaxDisponible.Location = new System.Drawing.Point(9, 117);
            this.textBoxMaxDisponible.Name = "textBoxMaxDisponible";
            this.textBoxMaxDisponible.ReadOnly = true;
            this.textBoxMaxDisponible.Size = new System.Drawing.Size(120, 20);
            this.textBoxMaxDisponible.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad Max Disponible";
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Location = new System.Drawing.Point(9, 160);
            this.textBoxCantidad.MaxLength = 9;
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.ShortcutsEnabled = false;
            this.textBoxCantidad.Size = new System.Drawing.Size(120, 20);
            this.textBoxCantidad.TabIndex = 7;
            this.textBoxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCantidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Productos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad Elegida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DNI";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDNI);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Seleccionar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Canjear);
            this.panel1.Controls.Add(this.textBoxCantidad);
            this.panel1.Controls.Add(this.Cancelar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxProductos);
            this.panel1.Controls.Add(this.textBoxMaxDisponible);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 244);
            this.panel1.TabIndex = 12;
            // 
            // CanjePtosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Name = "CanjePtosForm";
            this.Text = "CanjePtosForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Button Seleccionar;
        private System.Windows.Forms.Button Canjear;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.ComboBox comboBoxProductos;
        private System.Windows.Forms.TextBox textBoxMaxDisponible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
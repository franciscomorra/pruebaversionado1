namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    partial class ConsultaPuntosAdquiridosForm
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
            this.dgvPuntosAdq = new System.Windows.Forms.DataGridView();
            this.textBoxPuntos = new System.Windows.Forms.TextBox();
            this.Puntos = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.DNI = new System.Windows.Forms.Label();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosAdq)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPuntosAdq
            // 
            this.dgvPuntosAdq.AllowUserToAddRows = false;
            this.dgvPuntosAdq.AllowUserToDeleteRows = false;
            this.dgvPuntosAdq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPuntosAdq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPuntosAdq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuntosAdq.Location = new System.Drawing.Point(2, 80);
            this.dgvPuntosAdq.Name = "dgvPuntosAdq";
            this.dgvPuntosAdq.ReadOnly = true;
            this.dgvPuntosAdq.Size = new System.Drawing.Size(284, 158);
            this.dgvPuntosAdq.TabIndex = 0;
            // 
            // textBoxPuntos
            // 
            this.textBoxPuntos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPuntos.Location = new System.Drawing.Point(172, 25);
            this.textBoxPuntos.Name = "textBoxPuntos";
            this.textBoxPuntos.ReadOnly = true;
            this.textBoxPuntos.Size = new System.Drawing.Size(100, 20);
            this.textBoxPuntos.TabIndex = 1;
            // 
            // Puntos
            // 
            this.Puntos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Puntos.AutoSize = true;
            this.Puntos.Location = new System.Drawing.Point(169, 9);
            this.Puntos.Name = "Puntos";
            this.Puntos.Size = new System.Drawing.Size(40, 13);
            this.Puntos.TabIndex = 2;
            this.Puntos.Text = "Puntos";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(12, 25);
            this.textBoxDNI.MaxLength = 9;
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.ShortcutsEnabled = false;
            this.textBoxDNI.Size = new System.Drawing.Size(100, 20);
            this.textBoxDNI.TabIndex = 3;
            this.textBoxDNI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxDNI_MouseClick);
            this.textBoxDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDNI_KeyPress);
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.Location = new System.Drawing.Point(12, 9);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(26, 13);
            this.DNI.TabIndex = 4;
            this.DNI.Text = "DNI";
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(12, 51);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 5;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(197, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 20);
            this.panel1.TabIndex = 7;
            // 
            // ConsultaPuntosAdquiridosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.Puntos);
            this.Controls.Add(this.textBoxPuntos);
            this.Controls.Add(this.dgvPuntosAdq);
            this.Name = "ConsultaPuntosAdquiridosForm";
            this.Text = "ConsultaPuntosAdquiridosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosAdq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPuntosAdq;
        private System.Windows.Forms.TextBox textBoxPuntos;
        private System.Windows.Forms.Label Puntos;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.Button Seleccionar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;

    }
}
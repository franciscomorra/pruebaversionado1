namespace FrbaBus.Abm_Recorrido
{
    partial class AgregarModificarRecorrido
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.txtPrecioKG = new System.Windows.Forms.TextBox();
            this.txtPrecioPJ = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ciudad destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio base por KG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio base por pasaje";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 227);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(151, 38);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadOrigen.TabIndex = 7;
            this.cmbCiudadOrigen.SelectedValueChanged += new System.EventHandler(this.cmbCiudadOrigen_SelectedValueChanged);
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(151, 78);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadDestino.TabIndex = 8;
            this.cmbCiudadDestino.SelectedValueChanged += new System.EventHandler(this.cmbCiudadDestino_SelectedValueChanged);
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Location = new System.Drawing.Point(151, 114);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoServicio.TabIndex = 9;
            // 
            // txtPrecioKG
            // 
            this.txtPrecioKG.Location = new System.Drawing.Point(151, 151);
            this.txtPrecioKG.Name = "txtPrecioKG";
            this.txtPrecioKG.Size = new System.Drawing.Size(121, 20);
            this.txtPrecioKG.TabIndex = 10;
            this.txtPrecioKG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioKG_KeyPress);
            // 
            // txtPrecioPJ
            // 
            this.txtPrecioPJ.Location = new System.Drawing.Point(151, 187);
            this.txtPrecioPJ.Name = "txtPrecioPJ";
            this.txtPrecioPJ.Size = new System.Drawing.Size(121, 20);
            this.txtPrecioPJ.TabIndex = 11;
            // 
            // AgregarModificarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtPrecioPJ);
            this.Controls.Add(this.txtPrecioKG);
            this.Controls.Add(this.cmbTipoServicio);
            this.Controls.Add(this.cmbCiudadDestino);
            this.Controls.Add(this.cmbCiudadOrigen);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AgregarModificarRecorrido";
            this.Text = "AgregarModificarRecorrido";
            this.Load += new System.EventHandler(this.AgregarModificarRecorrido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
        private System.Windows.Forms.TextBox txtPrecioKG;
        private System.Windows.Forms.TextBox txtPrecioPJ;
    }
}
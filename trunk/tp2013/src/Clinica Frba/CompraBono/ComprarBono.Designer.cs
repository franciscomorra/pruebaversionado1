namespace ClinicaFrba.CompraBono
{
    partial class ComprarBono
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
            this.cbxCantConsulta = new System.Windows.Forms.ComboBox();
            this.cbxCantFarmacia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblprecioConsulta = new System.Windows.Forms.Label();
            this.lblprecioFarmacia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.panelCompra = new System.Windows.Forms.Panel();
            this.panelAfiliado.SuspendLayout();
            this.panelCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxCantConsulta
            // 
            this.cbxCantConsulta.FormattingEnabled = true;
            this.cbxCantConsulta.Location = new System.Drawing.Point(151, 8);
            this.cbxCantConsulta.Name = "cbxCantConsulta";
            this.cbxCantConsulta.Size = new System.Drawing.Size(61, 21);
            this.cbxCantConsulta.TabIndex = 17;
            // 
            // cbxCantFarmacia
            // 
            this.cbxCantFarmacia.FormattingEnabled = true;
            this.cbxCantFarmacia.Location = new System.Drawing.Point(151, 35);
            this.cbxCantFarmacia.Name = "cbxCantFarmacia";
            this.cbxCantFarmacia.Size = new System.Drawing.Size(61, 21);
            this.cbxCantFarmacia.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cantidad de bonos consulta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cantidad de bonos farmacia";
            // 
            // lblprecioConsulta
            // 
            this.lblprecioConsulta.AutoSize = true;
            this.lblprecioConsulta.Location = new System.Drawing.Point(218, 11);
            this.lblprecioConsulta.Name = "lblprecioConsulta";
            this.lblprecioConsulta.Size = new System.Drawing.Size(13, 13);
            this.lblprecioConsulta.TabIndex = 19;
            this.lblprecioConsulta.Text = "0";
            // 
            // lblprecioFarmacia
            // 
            this.lblprecioFarmacia.AutoSize = true;
            this.lblprecioFarmacia.Location = new System.Drawing.Point(218, 38);
            this.lblprecioFarmacia.Name = "lblprecioFarmacia";
            this.lblprecioFarmacia.Size = new System.Drawing.Size(13, 13);
            this.lblprecioFarmacia.TabIndex = 19;
            this.lblprecioFarmacia.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "pesos cada uno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "pesos cada uno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(278, 64);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "pesos";
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(279, 91);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 20;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            // 
            // panelAfiliado
            // 
            this.panelAfiliado.Controls.Add(this.btnBuscar);
            this.panelAfiliado.Controls.Add(this.lblAfiliado);
            this.panelAfiliado.Controls.Add(this.txtAfiliado);
            this.panelAfiliado.Location = new System.Drawing.Point(0, 0);
            this.panelAfiliado.Name = "panelAfiliado";
            this.panelAfiliado.Size = new System.Drawing.Size(368, 43);
            this.panelAfiliado.TabIndex = 21;
            this.panelAfiliado.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(180, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
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
            // panelCompra
            // 
            this.panelCompra.Controls.Add(this.btnComprar);
            this.panelCompra.Controls.Add(this.lblTotal);
            this.panelCompra.Controls.Add(this.lblprecioFarmacia);
            this.panelCompra.Controls.Add(this.lblprecioConsulta);
            this.panelCompra.Controls.Add(this.label2);
            this.panelCompra.Controls.Add(this.label5);
            this.panelCompra.Controls.Add(this.label6);
            this.panelCompra.Controls.Add(this.label4);
            this.panelCompra.Controls.Add(this.label3);
            this.panelCompra.Controls.Add(this.label1);
            this.panelCompra.Controls.Add(this.cbxCantFarmacia);
            this.panelCompra.Controls.Add(this.cbxCantConsulta);
            this.panelCompra.Location = new System.Drawing.Point(0, 49);
            this.panelCompra.Name = "panelCompra";
            this.panelCompra.Size = new System.Drawing.Size(368, 128);
            this.panelCompra.TabIndex = 22;
            // 
            // ComprarBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 181);
            this.Controls.Add(this.panelCompra);
            this.Controls.Add(this.panelAfiliado);
            this.Name = "ComprarBono";
            this.Text = "Comprar Bonos";
            this.Load += new System.EventHandler(this.ComprarBono_Load);
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            this.panelCompra.ResumeLayout(false);
            this.panelCompra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCantConsulta;
        private System.Windows.Forms.ComboBox cbxCantFarmacia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblprecioConsulta;
        private System.Windows.Forms.Label lblprecioFarmacia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Panel panelCompra;
    }
}
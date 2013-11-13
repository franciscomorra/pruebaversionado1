namespace FrbaBus.Abm_Micro
{
    partial class MicroForm
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
            this.datagvMicro = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AgregarButaca = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ModificarMicro = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BajaDefinitiva = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BajaTemporal = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagvMicro)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagvMicro
            // 
            this.datagvMicro.AllowUserToAddRows = false;
            this.datagvMicro.AllowUserToDeleteRows = false;
            this.datagvMicro.AllowUserToResizeColumns = false;
            this.datagvMicro.AllowUserToResizeRows = false;
            this.datagvMicro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datagvMicro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvMicro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvMicro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AgregarButaca,
            this.ModificarMicro,
            this.BajaDefinitiva,
            this.BajaTemporal});
            this.datagvMicro.Location = new System.Drawing.Point(0, 54);
            this.datagvMicro.Name = "datagvMicro";
            this.datagvMicro.ReadOnly = true;
            this.datagvMicro.Size = new System.Drawing.Size(337, 198);
            this.datagvMicro.TabIndex = 0;
            this.datagvMicro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvMicro_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cerrar);
            this.panel1.Controls.Add(this.Agregar);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 55);
            this.panel1.TabIndex = 1;
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Location = new System.Drawing.Point(252, 13);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(75, 23);
            this.cerrar.TabIndex = 1;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // Agregar
            // 
            this.Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Agregar.Location = new System.Drawing.Point(12, 14);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(103, 23);
            this.Agregar.TabIndex = 0;
            this.Agregar.Text = "Agregar Micro";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(0, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 22);
            this.panel2.TabIndex = 2;
            // 
            // AgregarButaca
            // 
            this.AgregarButaca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AgregarButaca.HeaderText = "Agregar / Modificar Butacas";
            this.AgregarButaca.Name = "AgregarButaca";
            this.AgregarButaca.ReadOnly = true;
            this.AgregarButaca.Text = "A / M Butacas";
            this.AgregarButaca.UseColumnTextForButtonValue = true;
            // 
            // ModificarMicro
            // 
            this.ModificarMicro.HeaderText = "Modificar";
            this.ModificarMicro.Name = "ModificarMicro";
            this.ModificarMicro.ReadOnly = true;
            this.ModificarMicro.Text = "Modificar";
            this.ModificarMicro.UseColumnTextForButtonValue = true;
            // 
            // BajaDefinitiva
            // 
            this.BajaDefinitiva.HeaderText = "Baja Definitiva";
            this.BajaDefinitiva.Name = "BajaDefinitiva";
            this.BajaDefinitiva.ReadOnly = true;
            this.BajaDefinitiva.Text = "Baja Definitiva";
            this.BajaDefinitiva.UseColumnTextForButtonValue = true;
            // 
            // BajaTemporal
            // 
            this.BajaTemporal.HeaderText = "Baja Temporal";
            this.BajaTemporal.Name = "BajaTemporal";
            this.BajaTemporal.ReadOnly = true;
            this.BajaTemporal.Text = "Baja Temporal";
            this.BajaTemporal.UseColumnTextForButtonValue = true;
            // 
            // MicroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 279);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagvMicro);
            this.Name = "MicroForm";
            this.Text = "MicroForm";
            this.Load += new System.EventHandler(this.MicroForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvMicro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagvMicro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewButtonColumn AgregarButaca;
        private System.Windows.Forms.DataGridViewButtonColumn ModificarMicro;
        private System.Windows.Forms.DataGridViewButtonColumn BajaDefinitiva;
        private System.Windows.Forms.DataGridViewButtonColumn BajaTemporal;
    }
}
namespace diseñoIntegrador
{
    partial class Form1
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
            this.btn_Siguiente = new System.Windows.Forms.Button();
            this.combo_Recital = new System.Windows.Forms.ComboBox();
            this.combo_Sector = new System.Windows.Forms.ComboBox();
            this.label_recital = new System.Windows.Forms.Label();
            this.label_sector = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Siguiente
            // 
            this.btn_Siguiente.Location = new System.Drawing.Point(100, 59);
            this.btn_Siguiente.Name = "btn_Siguiente";
            this.btn_Siguiente.Size = new System.Drawing.Size(75, 23);
            this.btn_Siguiente.TabIndex = 0;
            this.btn_Siguiente.Text = "Siguiente >>";
            this.btn_Siguiente.UseVisualStyleBackColor = true;
            // 
            // combo_Recital
            // 
            this.combo_Recital.FormattingEnabled = true;
            this.combo_Recital.Location = new System.Drawing.Point(54, 5);
            this.combo_Recital.Name = "combo_Recital";
            this.combo_Recital.Size = new System.Drawing.Size(121, 21);
            this.combo_Recital.TabIndex = 1;
            // 
            // combo_Sector
            // 
            this.combo_Sector.FormattingEnabled = true;
            this.combo_Sector.Location = new System.Drawing.Point(54, 32);
            this.combo_Sector.Name = "combo_Sector";
            this.combo_Sector.Size = new System.Drawing.Size(121, 21);
            this.combo_Sector.TabIndex = 2;
            // 
            // label_recital
            // 
            this.label_recital.AutoSize = true;
            this.label_recital.Location = new System.Drawing.Point(8, 13);
            this.label_recital.Name = "label_recital";
            this.label_recital.Size = new System.Drawing.Size(40, 13);
            this.label_recital.TabIndex = 3;
            this.label_recital.Text = "Recital";
            // 
            // label_sector
            // 
            this.label_sector.AutoSize = true;
            this.label_sector.Location = new System.Drawing.Point(8, 42);
            this.label_sector.Name = "label_sector";
            this.label_sector.Size = new System.Drawing.Size(38, 13);
            this.label_sector.TabIndex = 3;
            this.label_sector.Text = "Sector";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 91);
            this.Controls.Add(this.label_sector);
            this.Controls.Add(this.label_recital);
            this.Controls.Add(this.combo_Sector);
            this.Controls.Add(this.combo_Recital);
            this.Controls.Add(this.btn_Siguiente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Siguiente;
        private System.Windows.Forms.ComboBox combo_Recital;
        private System.Windows.Forms.ComboBox combo_Sector;
        private System.Windows.Forms.Label label_recital;
        private System.Windows.Forms.Label label_sector;
    }
}


namespace FrbaBus.Abm_Permisos
{
    partial class PermisosForm
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
            this.components = new System.ComponentModel.Container();
            this.datagvPermisos = new System.Windows.Forms.DataGridView();
            this.funcionalidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionalidadesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.funcionalidadesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.rolManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionalidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rolManagerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolManagerBindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagvPermisos
            // 
            this.datagvPermisos.AllowUserToAddRows = false;
            this.datagvPermisos.AllowUserToDeleteRows = false;
            this.datagvPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modificar,
            this.Eliminar});
            this.datagvPermisos.Location = new System.Drawing.Point(0, 51);
            this.datagvPermisos.Name = "datagvPermisos";
            this.datagvPermisos.ReadOnly = true;
            this.datagvPermisos.Size = new System.Drawing.Size(284, 185);
            this.datagvPermisos.TabIndex = 0;
            this.datagvPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvPermisos_CellClick);
            // 
            // funcionalidadesBindingSource
            // 
            this.funcionalidadesBindingSource.DataMember = "Funcionalidades";
            this.funcionalidadesBindingSource.DataSource = this.rolBindingSource;
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(FrbaBus.Common.Rol);
            // 
            // funcionalidadesBindingSource1
            // 
            this.funcionalidadesBindingSource1.DataMember = "Funcionalidades";
            this.funcionalidadesBindingSource1.DataSource = this.rolBindingSource;
            // 
            // funcionalidadesBindingSource2
            // 
            this.funcionalidadesBindingSource2.DataMember = "Funcionalidades";
            this.funcionalidadesBindingSource2.DataSource = this.rolBindingSource;
            // 
            // rolManagerBindingSource
            // 
            this.rolManagerBindingSource.DataSource = typeof(FrbaBus.Business.RolManager);
            // 
            // funcionalidadBindingSource
            // 
            this.funcionalidadBindingSource.DataSource = typeof(FrbaBus.Common.Funcionalidad);
            // 
            // rolBindingSource1
            // 
            this.rolBindingSource1.DataSource = typeof(FrbaBus.Common.Rol);
            // 
            // rolManagerBindingSource1
            // 
            this.rolManagerBindingSource1.DataSource = typeof(FrbaBus.Business.RolManager);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 13);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar Rol";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 56);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(182, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 19);
            this.panel2.TabIndex = 5;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseColumnTextForButtonValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Habilitar / Inhabilitar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Habilitar / Inhabilitar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // PermisosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagvPermisos);
            this.Name = "PermisosForm";
            this.Text = "PermisosForm";
            this.Load += new System.EventHandler(this.PermisosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolManagerBindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagvPermisos;
        private System.Windows.Forms.BindingSource rolManagerBindingSource;
        private System.Windows.Forms.BindingSource funcionalidadBindingSource;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.BindingSource funcionalidadesBindingSource;
        private System.Windows.Forms.BindingSource funcionalidadesBindingSource1;
        private System.Windows.Forms.BindingSource rolBindingSource1;
        private System.Windows.Forms.BindingSource funcionalidadesBindingSource2;
        private System.Windows.Forms.BindingSource rolManagerBindingSource1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}
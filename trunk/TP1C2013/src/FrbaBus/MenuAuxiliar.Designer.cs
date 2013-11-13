namespace FrbaBus
{
    partial class MenuAuxiliar
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
            this.abmRol = new System.Windows.Forms.Button();
            this.abmMicro = new System.Windows.Forms.Button();
            this.abmRecorrido = new System.Windows.Forms.Button();
            this.puntosCliente = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.canjearPuntoClientes = new System.Windows.Forms.Button();
            this.comprar = new System.Windows.Forms.Button();
            this.registroLLegada = new System.Windows.Forms.Button();
            this.devolucionItems = new System.Windows.Forms.Button();
            this.generarViaje = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.desloguear = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.GroupBox();
            this.cerrar = new System.Windows.Forms.Button();
            this.listado.SuspendLayout();
            this.SuspendLayout();
            // 
            // abmRol
            // 
            this.abmRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.abmRol.Location = new System.Drawing.Point(33, 237);
            this.abmRol.Name = "abmRol";
            this.abmRol.Size = new System.Drawing.Size(189, 23);
            this.abmRol.TabIndex = 0;
            this.abmRol.Text = "ABM Rol";
            this.abmRol.UseVisualStyleBackColor = true;
            this.abmRol.Click += new System.EventHandler(this.button1_Click);
            // 
            // abmMicro
            // 
            this.abmMicro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.abmMicro.Location = new System.Drawing.Point(33, 277);
            this.abmMicro.Name = "abmMicro";
            this.abmMicro.Size = new System.Drawing.Size(189, 23);
            this.abmMicro.TabIndex = 1;
            this.abmMicro.Text = "ABM Micro";
            this.abmMicro.UseVisualStyleBackColor = true;
            this.abmMicro.Click += new System.EventHandler(this.button2_Click);
            // 
            // abmRecorrido
            // 
            this.abmRecorrido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.abmRecorrido.Location = new System.Drawing.Point(33, 315);
            this.abmRecorrido.Name = "abmRecorrido";
            this.abmRecorrido.Size = new System.Drawing.Size(189, 23);
            this.abmRecorrido.TabIndex = 2;
            this.abmRecorrido.Text = "ABM Recorrido";
            this.abmRecorrido.UseVisualStyleBackColor = true;
            this.abmRecorrido.Click += new System.EventHandler(this.button3_Click);
            // 
            // puntosCliente
            // 
            this.puntosCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.puntosCliente.Location = new System.Drawing.Point(301, 64);
            this.puntosCliente.Name = "puntosCliente";
            this.puntosCliente.Size = new System.Drawing.Size(189, 23);
            this.puntosCliente.TabIndex = 3;
            this.puntosCliente.Text = "Consulta de Puntos";
            this.puntosCliente.UseVisualStyleBackColor = true;
            this.puntosCliente.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button5.Location = new System.Drawing.Point(32, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(335, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Top 5 de los Clientes con más Puntos Acumulos a la Fecha";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button6.Location = new System.Drawing.Point(32, 57);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(335, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Top 5 de los Destinos con más Pasajes Comprados";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button7.Location = new System.Drawing.Point(32, 97);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(335, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Top 5 de los Destinos con Micros más Vacios";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.Location = new System.Drawing.Point(32, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(335, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Top 5 de los Destinos con Pasajes Cancelados";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button9.Location = new System.Drawing.Point(32, 174);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(335, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "Top 5 de los Micros con Mayor Cantidad de Días Fuera de Servicio";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // canjearPuntoClientes
            // 
            this.canjearPuntoClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.canjearPuntoClientes.Location = new System.Drawing.Point(301, 140);
            this.canjearPuntoClientes.Name = "canjearPuntoClientes";
            this.canjearPuntoClientes.Size = new System.Drawing.Size(189, 23);
            this.canjearPuntoClientes.TabIndex = 9;
            this.canjearPuntoClientes.Text = "Canje de Puntos";
            this.canjearPuntoClientes.UseVisualStyleBackColor = true;
            this.canjearPuntoClientes.Click += new System.EventHandler(this.button10_Click);
            // 
            // comprar
            // 
            this.comprar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comprar.Location = new System.Drawing.Point(301, 102);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(189, 23);
            this.comprar.TabIndex = 11;
            this.comprar.Text = "Compra de Pasaje / Encomienda";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.button12_Click);
            // 
            // registroLLegada
            // 
            this.registroLLegada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.registroLLegada.Location = new System.Drawing.Point(33, 160);
            this.registroLLegada.Name = "registroLLegada";
            this.registroLLegada.Size = new System.Drawing.Size(189, 23);
            this.registroLLegada.TabIndex = 12;
            this.registroLLegada.Text = "Registro de Llegada de Micro";
            this.registroLLegada.UseVisualStyleBackColor = true;
            this.registroLLegada.Click += new System.EventHandler(this.button13_Click);
            // 
            // devolucionItems
            // 
            this.devolucionItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.devolucionItems.Location = new System.Drawing.Point(33, 199);
            this.devolucionItems.Name = "devolucionItems";
            this.devolucionItems.Size = new System.Drawing.Size(189, 23);
            this.devolucionItems.TabIndex = 13;
            this.devolucionItems.Text = "Devolución de Pasaje/Encomienda";
            this.devolucionItems.UseVisualStyleBackColor = true;
            this.devolucionItems.Click += new System.EventHandler(this.button14_Click);
            // 
            // generarViaje
            // 
            this.generarViaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generarViaje.Location = new System.Drawing.Point(33, 354);
            this.generarViaje.Name = "generarViaje";
            this.generarViaje.Size = new System.Drawing.Size(189, 23);
            this.generarViaje.TabIndex = 14;
            this.generarViaje.Text = "Generación de Viaje";
            this.generarViaje.UseVisualStyleBackColor = true;
            this.generarViaje.Click += new System.EventHandler(this.button15_Click);
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.login.Location = new System.Drawing.Point(622, 12);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(169, 23);
            this.login.TabIndex = 15;
            this.login.Text = "Iniciar Sesión";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.button16_Click);
            // 
            // desloguear
            // 
            this.desloguear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.desloguear.Location = new System.Drawing.Point(622, 12);
            this.desloguear.Name = "desloguear";
            this.desloguear.Size = new System.Drawing.Size(169, 23);
            this.desloguear.TabIndex = 16;
            this.desloguear.Text = "Cerrar Sesión";
            this.desloguear.UseVisualStyleBackColor = true;
            this.desloguear.Click += new System.EventHandler(this.desloguear_Click);
            // 
            // listado
            // 
            this.listado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listado.Controls.Add(this.button5);
            this.listado.Controls.Add(this.button6);
            this.listado.Controls.Add(this.button7);
            this.listado.Controls.Add(this.button8);
            this.listado.Controls.Add(this.button9);
            this.listado.Location = new System.Drawing.Point(269, 180);
            this.listado.Name = "listado";
            this.listado.Size = new System.Drawing.Size(397, 212);
            this.listado.TabIndex = 17;
            this.listado.TabStop = false;
            this.listado.Text = "Listado Estadístico";
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.Location = new System.Drawing.Point(660, 344);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(131, 48);
            this.cerrar.TabIndex = 18;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // MenuAuxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 431);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.desloguear);
            this.Controls.Add(this.login);
            this.Controls.Add(this.generarViaje);
            this.Controls.Add(this.devolucionItems);
            this.Controls.Add(this.registroLLegada);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.canjearPuntoClientes);
            this.Controls.Add(this.puntosCliente);
            this.Controls.Add(this.abmRecorrido);
            this.Controls.Add(this.abmMicro);
            this.Controls.Add(this.abmRol);
            this.Name = "MenuAuxiliar";
            this.Text = "MenuAuxiliar";
            this.listado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button abmRol;
        private System.Windows.Forms.Button abmMicro;
        private System.Windows.Forms.Button abmRecorrido;
        private System.Windows.Forms.Button puntosCliente;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button canjearPuntoClientes;
        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.Button registroLLegada;
        private System.Windows.Forms.Button devolucionItems;
        private System.Windows.Forms.Button generarViaje;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button desloguear;
        private System.Windows.Forms.GroupBox listado;
        private System.Windows.Forms.Button cerrar;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Core;
using FrbaBus.Common;
using FrbaBus.Business;

namespace FrbaBus
{
    public partial class MenuAuxiliar : Form
    {


        public MenuAuxiliar()
        {
            InitializeComponent();
            if (Configuracion.Instancia().usuario.ID == -1)
            {
                Configuracion.Instancia().usuario = Configuracion.Instancia().usuario = new UsuarioManager().funcionalidadesDefecto();
                desloguear.Visible = false;
                login.BringToFront();
            }
            else
            {
                Configuracion.Instancia().usuario.FUNCIONALIDADES = new UsuarioManager().funcionalidadesUsuario(Configuracion.Instancia().usuario.ID);
                login.Visible = false;
                desloguear.BringToFront();
            }

            BindingList<System.Windows.Forms.Control> listaDeElementos = new BindingList<System.Windows.Forms.Control>();

            listaDeElementos.Add(abmRol);
            listaDeElementos.Add(abmMicro);
            listaDeElementos.Add(abmRecorrido);
            listaDeElementos.Add(puntosCliente);
            listaDeElementos.Add(canjearPuntoClientes);
            listaDeElementos.Add(comprar);
            listaDeElementos.Add(registroLLegada);
            listaDeElementos.Add(devolucionItems);
            listaDeElementos.Add(generarViaje);
            listaDeElementos.Add(listado);

            if (Configuracion.Instancia().usuario.FUNCIONALIDADES != null)
            {
                foreach (System.Windows.Forms.Control boton in listaDeElementos)
                {

                    if (!Configuracion.Instancia().usuario.FUNCIONALIDADES.Contains(boton.Name)) boton.Visible = false;
                }
            }
            else
            {
                foreach (System.Windows.Forms.Control boton in listaDeElementos)
                {

                    boton.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Abm_Permisos.PermisosForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Abm_Micro.MicroForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Abm_Recorrido.RecorridoForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Consulta_Puntos_Adquiridos.ConsultaPuntosAdquiridosForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Top_Clientes.TopClientes());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Top_Destinos.DestinosMasPasajes());
        }

        private void button7_Click(object sender, EventArgs e)
        {
             ViewsManager.LoadView(new FrbaBus.Top_Destinos.DestinosMasVacios());
        }

        private void button8_Click(object sender, EventArgs e)
        {
             ViewsManager.LoadView(new FrbaBus.Top_Destinos.DestinosPasajesCancelados());
        }

        private void button9_Click(object sender, EventArgs e)
        {
             ViewsManager.LoadView(new FrbaBus.Top_Micros.TopMicros());
        }

        private void button10_Click(object sender, EventArgs e)
        {
           ViewsManager.LoadView(new FrbaBus.Canje_de_Ptos.CanjePtosForm());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Compra_de_Pasajes.CompraDePasajes());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Registrar_LLegada_Micro.RegistrarLLegadas());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Cancelar_Viaje.CancelarViaje());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.GenerarViaje.GenerarViaje());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.Login.Login());
        }

        private void desloguear_Click(object sender, EventArgs e)
        {
            Configuracion.Instancia().usuario = new UsuarioManager().funcionalidadesDefecto();
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Configuracion.Instancia().meCierro();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Business;
using FrbaBus.Common;
using FrbaBus.Abm_Permisos;
using FrbaBus.Core;


namespace FrbaBus.Cancelar_Viaje
{
    public partial class CancelarViaje : Form
    {
        ItemCancelacionManager _itemCancelacionManager = new ItemCancelacionManager();
        
        public CancelarViaje()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            IDCompra.Text = "Ingrese el número de Voucher";
            DNI.Text = "Ingrese número de DNI";
        }

        private void Chequear_Click(object sender, EventArgs e)
        {
            if (((DNI.Text.Length > 0) && (DNI.Text != "Ingrese número de DNI")) && (IDCompra.Text.Length > 0) && (IDCompra.Text != "Ingrese el número de Voucher"))
          {
           var items = _itemCancelacionManager.cargarItems(long.Parse(DNI.Text), int.Parse(IDCompra.Text));
           if(items.Count > 0)
           {
            dataGridView1.DataSource = items;
            Chequear.Enabled = false;
            groupBox1.Visible = true;
            DNI.Enabled = false;
            IDCompra.Enabled = false;
           }
           else
           {
            MessageBox.Show("Número de Voucher y DNI inválidos o sin items disponibles en la compra");
           }
          }

        }

        private void CancelarItems_Click(object sender, EventArgs e)
        {

            if (MotivoCancelacion.Text.Length > 0 && MotivoCancelacion.Text != "Ingrese el motivo de la cancelación...")
            {

                float precio = 0;
                int numeroDeTarjeta;
                BindingList<ItemCancelacion> lista = new BindingList<ItemCancelacion>();

                foreach (ItemCancelacion row in dataGridView1.DataSource as BindingList<ItemCancelacion>)
                {
                    if (row.CANCELADO)
                    {
                        lista.Add(row);
                        precio += row.PRECIO;
                    }
                }

                if (lista.Count > 0)
                {
                    _itemCancelacionManager.cancelarItems(lista, MotivoCancelacion.Text);
                    numeroDeTarjeta = _itemCancelacionManager.numeroDeTarjeta(int.Parse(IDCompra.Text));

                    if (numeroDeTarjeta == -1)
                        MessageBox.Show("El saldo a devolver es de $" + precio.ToString() + " en efectivo.");
                    else
                        MessageBox.Show("El saldo a devolver es de $" + precio.ToString() + " en la tarjeta de credito " + numeroDeTarjeta + " .");


                    ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos un Item de la Compra");
                }


            }
            else
            {
                MessageBox.Show("Debe escribir el motivo de la cancelación");
            }

      
            
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }

        private void IDCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (IDCompra.Text == "Ingrese el número de Voucher")
            {
                IDCompra.Clear();
            }
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                } 
        }

        private void DNI_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (DNI.Text == "Ingrese número de DNI")
            {
                DNI.Clear();
            }
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                } 
        }

        private void IDCompra_MouseClick(object sender, MouseEventArgs e)
        {
            IDCompra.Clear();
        }

        private void DNI_MouseClick(object sender, MouseEventArgs e)
        {
            DNI.Clear();
        }

        private void MotivoCancelacion_MouseClick(object sender, MouseEventArgs e)
        {
            MotivoCancelacion.Clear();
        }

        private void MotivoCancelacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MotivoCancelacion.Text == "Ingrese el motivo de la cancelación...")
            {
                MotivoCancelacion.Clear();
            }
        }
    }
}

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
using FrbaBus.Core;

namespace FrbaBus.Canje_de_Ptos
{
    public partial class CanjePtosForm : Form
    {

        private PasajeroCanjeManager _pasajeroCanjeManager = new PasajeroCanjeManager();

        private PasajeroCanje _pasajeroCanje;
        
        public CanjePtosForm()
        {
            InitializeComponent();
            textBoxDNI.AppendText("Ingrese DNI");
            textBoxCantidad.Enabled = false;
            Canjear.Enabled = false;
            comboBoxProductos.Enabled = false;

        }

        private void textBoxDNI_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxDNI.Clear();
            comboBoxProductos.Items.Clear();
            comboBoxProductos.ResetText();
            textBoxMaxDisponible.Clear();
            textBoxCantidad.Clear();
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBoxDNI.Text == "Ingrese DNI")
            {
                textBoxDNI.Clear();
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

        private void Seleccionar_Click(object sender, EventArgs e)
        {
                    
            textBoxMaxDisponible.Clear();

            textBoxCantidad.Clear();

            comboBoxProductos.Items.Clear();

            comboBoxProductos.ResetText();


            if ((textBoxDNI.Text.Length > 0) && (textBoxDNI.Text != "Ingrese DNI"))
            {

                _pasajeroCanje = _pasajeroCanjeManager.ObtenerPasajeroCanje(long.Parse(textBoxDNI.Text.ToString()));


                if (_pasajeroCanje.PRODCANT.Count > 0)
                {
                    comboBoxProductos.Enabled = true;

                    foreach (ProductoCantidad productoCantidad in _pasajeroCanje.PRODCANT)
                    {
                        comboBoxProductos.Items.Add(productoCantidad.NombreProducto+" - ("+productoCantidad.PuntosNecesarios.ToString()+" Ptos.)");

                    }

                }





                if (_pasajeroCanje.PRODCANT.Count == 0)
                {

                    MessageBox.Show("El Cliente no existe o no dispone de puntos suficientes para realizar un canje");
                    

                }
            }
        
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            textBoxDNI.Clear();
            comboBoxProductos.ResetText();
            textBoxDNI.AppendText("Ingrese DNI");
            textBoxCantidad.Enabled = false;
            Canjear.Enabled = false;
            textBoxDNI.Enabled = true;
            Seleccionar.Enabled = true;
            textBoxCantidad.Clear();
            comboBoxProductos.Enabled = false;
            textBoxMaxDisponible.Clear();
            comboBoxProductos.Items.Clear();

        }

        private void comboBoxProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxProductos.Text.Length > 0)
            {
                String aux = comboBoxProductos.Text.Substring(0, comboBoxProductos.Text.IndexOf("-")-1);

                textBoxDNI.Enabled = false;

                Seleccionar.Enabled = false;

                comboBoxProductos.Enabled = false;

                textBoxCantidad.Enabled = true;

                Canjear.Enabled = true;

                textBoxMaxDisponible.Text = (_pasajeroCanje.PRODCANT.Find(elem => elem.NombreProducto == aux).Cantidad.ToString());
            }
            

            
        }

        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void Canjear_Click(object sender, EventArgs e)
        {
            if ((textBoxCantidad.Text.Length > 0) && (0 < int.Parse(textBoxCantidad.Text)) && (int.Parse(textBoxCantidad.Text) <= int.Parse(textBoxMaxDisponible.Text)))
            {
                String aux = comboBoxProductos.Text.Substring(0, comboBoxProductos.Text.IndexOf("-") - 1);
                _pasajeroCanjeManager.realizarCanje(long.Parse(textBoxDNI.Text), int.Parse(textBoxCantidad.Text), aux);

                MessageBox.Show("El canje se realizó con éxito");
                ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());

            }
            else
            {
                MessageBox.Show("Cantidad ingresada fuera de rango");
                textBoxCantidad.Clear();
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    

       
    }
}

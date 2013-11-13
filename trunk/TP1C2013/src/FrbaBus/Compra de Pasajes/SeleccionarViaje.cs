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

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class SeleccionarViaje : Form
    {
        private PasajePaquete _pasajePaquete = new PasajePaquete();
        private Viaje _viaje;
        public event EventHandler<PaquetePasajeQueSePasa> onPaquetePasajeGet;
        private CompraManager _compraManager = new CompraManager();
        private BindingList<PasajePaquete> _compra;

        public SeleccionarViaje(Viaje viaje, BindingList<PasajePaquete> compra)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            Cliente.Enabled = true;
            Pasaje.Visible = false;
            Paquete.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            _viaje = viaje;
            _pasajePaquete.ID_VIAJE = _viaje.ID;
            _compra = compra;
  
            
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            
            var clienteForm = new FrbaBus.Abm_Cliente.ClienteForm();
            clienteForm.OnClienteGet += new EventHandler<PaquetePasajeQueSePasa>(recibirCliente_OnClienteGet);
            clienteForm.ShowDialog();
           
            
        }

        void recibirCliente_OnClienteGet(object sender, PaquetePasajeQueSePasa e)
        {

            if( _compraManager.puedoAsociarCliente(e.pasajePaquete.DNI, _compra)){ 

            _pasajePaquete.DNI = e.pasajePaquete.DNI;


            Cliente.Enabled = false;
            if(_viaje.KG_DISPONIBLES > 0)
                Paquete.Visible = true;
            
            if (_viaje.BUTACAS_DISPONIBLES > 0)
            {
                if (_compraManager.puedoComprarPasaje(e.pasajePaquete.DNI, _compra))
                    Pasaje.Visible = true;
                else
                    MessageBox.Show("No se puede comprar mas de 2 pasajes en una compra con un pasajero discapacitado");
            }

            }else{
                MessageBox.Show("No se puede ingresar otro cliente discapacitado en esta compra");
            }


        }

        private void Cancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Pasaje_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
            groupBox2.Visible = true;
            Pasaje.Enabled = false;
            Paquete.Enabled = false;

            foreach (Butaca butaca in _viaje.BUTACAS)
            {
                if (!comboBox1.Items.Contains(butaca.PISO))
                    comboBox1.Items.Add(butaca.PISO);
                if (!comboBox2.Items.Contains(butaca.TIPO))
                    comboBox2.Items.Add(butaca.TIPO);
                comboBox3.Items.Add(butaca.NUMERO);
            }
        }

        private void Paquete_Click(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
            groupBox1.Visible = true;
            Pasaje.Enabled = false;
            Paquete.Enabled = false;
            textBox1.Text = _viaje.KG_DISPONIBLES.ToString();
        }

        private void AceptarPaquete_Click(object sender, EventArgs e)
        {

            if ((textBox2.Text.Length > 0) && (0 < int.Parse(textBox2.Text)) && (int.Parse(textBox2.Text) <= int.Parse(textBox1.Text)))
            {
                _pasajePaquete.KG_PAQUETE = int.Parse(textBox2.Text);
                if (onPaquetePasajeGet != null)
                {
                    onPaquetePasajeGet(this, new PaquetePasajeQueSePasa() { pasajePaquete = _pasajePaquete });
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Cantidad ingresada fuera de rango");
                textBox2.Clear();
            }
        }

        private void AceptarPasaje_Click(object sender, EventArgs e)
        {
            if( comboBox3.Text.Length > 0 && comboBox3.Items.Contains(int.Parse(comboBox3.Text))){
                _pasajePaquete.NUMERO_BUTACA = int.Parse(comboBox3.Text);
                if (onPaquetePasajeGet != null)
                {
                 onPaquetePasajeGet(this, new PaquetePasajeQueSePasa() { pasajePaquete = _pasajePaquete });
                }

                this.Close();
            } else {
                MessageBox.Show("Debe seleccionar un numero de butaca válido");
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach(Butaca butaca in _viaje.BUTACAS){
                if (int.Parse(comboBox3.Text) == butaca.NUMERO)
                {
                    comboBox1.Text = butaca.PISO.ToString();
                    comboBox2.Text = butaca.TIPO;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            String combo1 = comboBox1.Text;
            comboBox3.Items.Clear();
            comboBox1.Items.Clear();

            if (comboBox1.Text.Length == 0)
            {
                foreach (Butaca butaca in _viaje.BUTACAS)
                {
                    if (comboBox2.Text == butaca.TIPO)
                    {
                        if (!comboBox1.Items.Contains(butaca.PISO))
                            comboBox1.Items.Add(butaca.PISO);
                        comboBox3.Items.Add(butaca.NUMERO);
                    }
                }
            }
            else
            {
                comboBox1.Items.Add(combo1);
                foreach (Butaca butaca in _viaje.BUTACAS)
                {
                    if (comboBox2.Text == butaca.TIPO && int.Parse(comboBox1.Text) == butaca.PISO)
                    {
                        comboBox3.Items.Add(butaca.NUMERO);
                    }
                }
            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            String combo2 = comboBox2.Text;
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
            if (comboBox2.Text.Length == 0)
            {
                foreach (Butaca butaca in _viaje.BUTACAS)
                {
                    if (int.Parse(comboBox1.Text) == butaca.PISO)
                    {
                        if (!comboBox2.Items.Contains(butaca.TIPO))
                            comboBox2.Items.Add(butaca.TIPO);
                        comboBox3.Items.Add(butaca.NUMERO);
                    }
                }
            }
            else
            {
                comboBox2.Items.Add(combo2);
                foreach (Butaca butaca in _viaje.BUTACAS)
                {
                    if (int.Parse(comboBox1.Text) == butaca.PISO && comboBox2.Text == butaca.TIPO)
                    {
                        comboBox3.Items.Add(butaca.NUMERO);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            foreach (Butaca butaca in _viaje.BUTACAS)
            {
                if (!comboBox1.Items.Contains(butaca.PISO))
                    comboBox1.Items.Add(butaca.PISO);
                if (!comboBox2.Items.Contains(butaca.TIPO))
                    comboBox2.Items.Add(butaca.TIPO);
                comboBox3.Items.Add(butaca.NUMERO);
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
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

       
    }
}

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
    public partial class ConfirmarCompra : Form
    {

        ClienteManager  _clienteManager = new ClienteManager();
        CompraManager _compraManager = new CompraManager();
        TarjetaManager _tarjetaManager = new TarjetaManager();
        int _IDCompra = 0;
        public BindingList<PasajePaquete> _compra = new BindingList<PasajePaquete>();
        Tarjeta _unaTarjeta = new Tarjeta();

        public ConfirmarCompra(int IDCompra, BindingList<PasajePaquete> compra)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM / yyyy";
            _IDCompra = IDCompra;
            _compra = compra;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            Confirmar.Enabled = false;
            groupBoxTarjeta.Enabled = false;
            compraEfectivo.Enabled = false;
            Tarjeta.Enabled = false;
            if (Configuracion.Instancia().usuario.ID == -1) compraEfectivo.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var clienteForm = new FrbaBus.Abm_Cliente.ClienteForm();
            clienteForm.OnClienteGet += new EventHandler<PaquetePasajeQueSePasa>(recibirCliente_OnClienteGet);
            clienteForm.ShowDialog();
        }

        void recibirCliente_OnClienteGet(object sender, PaquetePasajeQueSePasa e)
        {
            int cantDiscapacitados = _compraManager.cantidadDiscapacitados(_compra);

            if (cantDiscapacitados > 1 || ((_compraManager.elDiscapacitado(_compra) != -1) && (_compraManager.cuantosPasajesHay(_compra) > 2)))
            {
                MessageBox.Show("Se modificó indebidamente el campo discapacitado de un cliente durante la compra. La compra será canelada");
                _compraManager.cancelarCompra(_IDCompra);
                this.Close();
            }
            else
            {
                DNIElegido.Text = e.pasajePaquete.DNI.ToString();
                DNIElegido.Enabled = false;
                compraEfectivo.Enabled = true;
                Tarjeta.Enabled = true;
                button1.Enabled = false;
                MontoAbonar.Text = (_compraManager.calcularSeatearMonto(_IDCompra, _compra)).ToString();
            }
        }

        private void Efectivo_Click(object sender, EventArgs e)
        {
            _compraManager.confirmarCompra(_IDCompra, long.Parse(DNIElegido.Text), -1);
            MessageBox.Show("Su número de voucher es "+_IDCompra.ToString()+".");
            this.Close();
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {

           if((textBox2.Text.Length > 0) && 
              (textBox3.Text.Length > 0) &&
              (dateTimePicker1.Text.Length > 0) &&
              (comboBox1.Text.Length > 0) &&
              (comboBox2.Text.Length > 0))
            {
            if (_unaTarjeta.CODIGO_SEGURIDAD == null)
                {
                _unaTarjeta.FECHA_VENCIMIENTO = Convert.ToDateTime(dateTimePicker1.Text);
                _unaTarjeta.DESCRIPCION = comboBox1.Text;
                _unaTarjeta.CODIGO_SEGURIDAD = textBox3.Text;

                _tarjetaManager.cargarNuevaTarjeta(_unaTarjeta);
                }   

            _compraManager.confirmarCompra(_IDCompra, long.Parse(DNIElegido.Text), int.Parse(textBox2.Text));
            MessageBox.Show("Su número de voucher es " + _IDCompra.ToString() + ".");
            this.Close();
            }
           else
            {
               MessageBox.Show("Todos los campos de la tarjeta son obligatorios");
            }
        
        }

        private void Tarjeta_Click(object sender, EventArgs e)
        {
            compraEfectivo.Enabled = false;
            Tarjeta.Enabled = false;
            groupBoxTarjeta.Visible = true;
            groupBoxTarjeta.Enabled = true;
        }

        private void SeleccionarTarjeta_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                SeleccionarTarjeta.Enabled = false;
                textBox2.Enabled = false;

                _unaTarjeta = _tarjetaManager.obtenerTarjeta(long.Parse(DNIElegido.Text), int.Parse(textBox2.Text));

                if (_unaTarjeta.CODIGO_SEGURIDAD != null)
                {

                    textBox3.Text = _unaTarjeta.CODIGO_SEGURIDAD;
                    dateTimePicker1.Text = _unaTarjeta.FECHA_VENCIMIENTO.ToString();
                    comboBox1.Text = _unaTarjeta.DESCRIPCION;
                    int i;
                    comboBox2.Items.Clear();
                    for (i = 1; i <= _unaTarjeta.CANT_CUOTAS; i++)
                        comboBox2.Items.Add(i);

                }
                else
                {

                    textBox3.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    comboBox1.Enabled = true;

                    comboBox1.Items.Clear();
                    var descripciones = _tarjetaManager.getAllDescripciones();
                    foreach (String descripcion in descripciones) comboBox1.Items.Add(descripcion);
                }
                comboBox2.Enabled = true;
                Confirmar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debe ingresar un número de tarjeta");

            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            int max = _tarjetaManager.getCuotasMaximas(comboBox1.Text);

            int i;
            for (i = 1; i <= max; i++) comboBox2.Items.Add(i);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
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

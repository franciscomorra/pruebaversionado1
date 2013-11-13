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
using FrbaBus.Compra_de_Pasajes;

namespace FrbaBus.Abm_Cliente
{
    public partial class ClienteForm : Form
    {

        private ClienteManager _clienteManager = new ClienteManager();
        private Cliente _cliente = new Cliente();
        public event EventHandler<PaquetePasajeQueSePasa> OnClienteGet;
        
        
        public ClienteForm()
        {

            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            textBoxDNI.AppendText("Ingrese DNI");
            textBoxNombre.Enabled = false;
            textBoxApellido.Enabled = false;
            textBoxDireccion.Enabled = false;
            textBoxMail.Enabled = false;
            textBoxTelefono.Enabled = false;
            dateTimePicker1.Enabled = false;
            groupBoxSexo.Enabled = false;
            Discapacitado.Enabled = false;
            Agregar.Visible = false;
            Aceptar.Enabled = false;
            

            
            
            
        }

        

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            



            if ((textBoxDNI.Text.Length > 0) && (textBoxDNI.Text != "Ingrese DNI"))
            {

                textBoxDNI.Enabled = false;

                _cliente = _clienteManager.EncontrarCliente(long.Parse(textBoxDNI.Text));
                
                if (_cliente.NOMBRE != null )
                {
                    
                    textBoxApellido.Text = _cliente.APELLIDO;
                    textBoxNombre.Text = _cliente.NOMBRE;
                    textBoxDireccion.Text = _cliente.DIRECCION;
                    textBoxTelefono.Text = _cliente.TELEFONO.ToString();
                    textBoxMail.Text = _cliente.MAIL;
                    dateTimePicker1.Text = _cliente.FECHA_NAC.ToString();
                    Discapacitado.Checked = _cliente.DISCAPACITADO;
                    if (_cliente.SEXO == "M")
                    {
                        Masculino.Checked = true;
                    }
                    else if (_cliente.SEXO == "F")
                    {
                        Femenino.Checked = true;
                    }

                    Seleccionar.Text = "Resetear";
                    Agregar.Text = "Modificar";
                    Aceptar.Enabled = true;
                }
                else
                {
                    Agregar.Text = "Agregar";
                    Seleccionar.Visible = false;

                }
               
            textBoxNombre.Enabled = true;
            textBoxApellido.Enabled = true;
            textBoxDireccion.Enabled = true;
            textBoxMail.Enabled = true;
            textBoxTelefono.Enabled = true;
            dateTimePicker1.Enabled = true;
            groupBoxSexo.Enabled = true;
            Discapacitado.Enabled = true;
            Agregar.Visible = true;

            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {

            if((textBoxApellido.Text.Length > 0) &&
               (textBoxNombre.Text.Length > 0) &&
               (textBoxDireccion.Text.Length > 0) &&
               (textBoxTelefono.Text.Length > 0) &&
               ((Masculino.Checked) || (Femenino.Checked)))
            {

            _cliente.DNI = long.Parse(textBoxDNI.Text);
            _cliente.APELLIDO = textBoxApellido.Text;
            _cliente.NOMBRE = textBoxNombre.Text;
            _cliente.DIRECCION = textBoxDireccion.Text;
            _cliente.TELEFONO= long.Parse(textBoxTelefono.Text);
            _cliente.MAIL = textBoxMail.Text;
            _cliente.FECHA_NAC = Convert.ToDateTime(dateTimePicker1.Text);
            _cliente.DISCAPACITADO = Discapacitado.Checked;
            if (Masculino.Checked)
            {
                _cliente.SEXO = "M";
            }
            else if (Femenino.Checked)
            {
                _cliente.SEXO = "F";
            }


            _clienteManager.InsertaoModificarCliente(_cliente);
            Aceptar.Enabled = true;
            Agregar.Text = "Modificar";
           }
           else
           {
                MessageBox.Show("Todos los campos son obligatorios excepto el mail");
           }

           
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

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        

        private void textBoxDNI_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxDNI.Clear();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            PasajePaquete pasajePaquete = new PasajePaquete();
            pasajePaquete.DNI = long.Parse(textBoxDNI.Text);

            if (OnClienteGet != null)
            {
                OnClienteGet(this, new PaquetePasajeQueSePasa() { pasajePaquete = pasajePaquete });
            }
            this.Close();
        }
    }
}

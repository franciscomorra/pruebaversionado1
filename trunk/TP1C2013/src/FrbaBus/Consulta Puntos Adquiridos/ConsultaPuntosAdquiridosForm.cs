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


namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    public partial class ConsultaPuntosAdquiridosForm : Form
    {

        private PasajeroFrecuenteManager _pasajeroFrecuenteManager = new PasajeroFrecuenteManager();
        
        public ConsultaPuntosAdquiridosForm()
        {
            InitializeComponent();
            textBoxDNI.AppendText("Ingrese DNI");
        }

        private void textBoxDNI_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxDNI.Clear();
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            textBoxPuntos.Clear();


            if ((textBoxDNI.Text.Length > 0) && (textBoxDNI.Text != "Ingrese DNI"))
            {
                var pasajeroFrecuente = _pasajeroFrecuenteManager.ObtenerPasajero(long.Parse(textBoxDNI.Text.ToString()));

                textBoxPuntos.AppendText(pasajeroFrecuente.PUNTOS.ToString());



                dgvPuntosAdq.DataSource = pasajeroFrecuente.COMPOSICIONPUNTOS;








            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    }
}

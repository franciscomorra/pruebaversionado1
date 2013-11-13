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

namespace FrbaBus.Abm_Recorrido
{
    public partial class AgregarModificarRecorrido : Form
    {

        private CiudadManager _ciudadManager = new CiudadManager();

        public AgregarModificarRecorrido() : this(new Recorrido()) { }

        public AgregarModificarRecorrido(Recorrido Recorrido)
        {
            InitializeComponent();
            this.Recorrido = Recorrido;
            if (Recorrido.RECORRIDO_CODIGO != 0)
            {
                cmbCiudadDestino.Enabled = false;
                cmbCiudadOrigen.Enabled = false;
                cmbTipoServicio.Enabled = false;
            }
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public event EventHandler<RecorridoQueSePasa> OnRecorridoeUpdated;

        private Recorrido Recorrido { get; set; }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((cmbCiudadOrigen.Text).Length > 0 &&
                cmbCiudadDestino.Text.Length > 0 &&
                cmbTipoServicio.Text.Length > 0 &&
                txtPrecioKG.Text.Length > 0 &&
                txtPrecioPJ.Text.Length > 0)
            {
                if (float.Parse(txtPrecioPJ.Text) > 0 && float.Parse(txtPrecioKG.Text) > 0)
                {
                    Recorrido.CIUDAD_ORIGEN = (cmbCiudadOrigen.Text);
                    Recorrido.CIUDAD_DESTINO = cmbCiudadDestino.Text;
                    Recorrido.TIPO_SERVICIO = cmbTipoServicio.Text;
                    Recorrido.PRECIO_BASE_KG = float.Parse(txtPrecioKG.Text);
                    Recorrido.PRECIO_BASE_PASAJE = float.Parse(txtPrecioPJ.Text);

                    if (OnRecorridoeUpdated != null)
                        OnRecorridoeUpdated(this, new RecorridoQueSePasa() { Recorrido = this.Recorrido });


                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se permite ingresar el valor $0 como precio base");
                }
            }else{
                MessageBox.Show("Todos los campos deben ser completados");
            }
        }

        private void AgregarModificarRecorrido_Load(object sender, EventArgs e)
        {
            cmbCiudadOrigen.Text = Recorrido.CIUDAD_ORIGEN;
            cmbCiudadDestino.Text = Recorrido.CIUDAD_DESTINO;
            cmbTipoServicio.Text = Recorrido.TIPO_SERVICIO;
            txtPrecioKG.Text = Recorrido.PRECIO_BASE_KG.ToString();
            txtPrecioPJ.Text = Recorrido.PRECIO_BASE_PASAJE.ToString();


            var servicioManager = new ServicioManager();
            var servicios = servicioManager.GetAll();
            foreach (Servicio servicio in servicios)
            {
                cmbTipoServicio.Items.Add(servicio.TIPO_SERVICIO);

            }

            var ciudades = _ciudadManager.GetAll();
            foreach (Ciudad ciudad in ciudades)
            {
                cmbCiudadOrigen.Items.Add(ciudad.NOMBRE);
                cmbCiudadDestino.Items.Add(ciudad.NOMBRE);

            }

        }

        private void cmbCiudadOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            
            var ciudades = _ciudadManager.GetAllMenosCiudad(cmbCiudadOrigen.Text);
            cmbCiudadDestino.Items.Clear();
            foreach (Ciudad ciudad in ciudades)
            {
                cmbCiudadDestino.Items.Add(ciudad.NOMBRE);
            }

        }

        private void cmbCiudadDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            var ciudades = _ciudadManager.GetAllMenosCiudad(cmbCiudadDestino.Text);
            cmbCiudadOrigen.Items.Clear();
            foreach (Ciudad ciudad in ciudades)
            {
                cmbCiudadOrigen.Items.Add(ciudad.NOMBRE);
            }

        }

        private void txtPrecioKG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',') //permitir teclas de control como retroceso 
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

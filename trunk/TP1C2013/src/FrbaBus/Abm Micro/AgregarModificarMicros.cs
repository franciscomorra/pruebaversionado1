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

namespace FrbaBus.Abm_Micro
{
    public partial class AgregarModificarMicros : Form
    {

        private ModeloManager _modeloManager = new ModeloManager();

        public AgregarModificarMicros() : this(new Micro()) { }

        public AgregarModificarMicros(Micro micro)
        {
            InitializeComponent();
            this.Micro = micro;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public event EventHandler<MicroQueSePasa> OnMicroeUpdated;

        private Micro Micro { get; set; }

        private void AgregarModificarMicrocs_Load(object sender, EventArgs e)
        {
            txtPatente.Text = Micro.PATENTE;
            txtKGD.Text = Micro.KG_DISPONIBLES.ToString();
            cmbTipoServicio.SelectedText = Micro.TIPO_SERVICIO;
            cmbMarca.SelectedText = Micro.MARCA;
            cmbModelo.SelectedText = Micro.MODELO;
            if (Micro.PATENTE != null)
            {
                txtPatente.Enabled = false;
                txtKGD.Enabled = false;
                cmbTipoServicio.Enabled = false;
            }
            

            var servicioManager = new ServicioManager();
            var servicios = servicioManager.GetAll();
            foreach(Servicio servicio in servicios){
                cmbTipoServicio.Items.Add(servicio.TIPO_SERVICIO);

            }

            var modelos = _modeloManager.GetAll();
            foreach (Modelo modelo in modelos)
            {
                cmbModelo.Items.Add(modelo.MODELO);
                cmbMarca.Items.Add(modelo.MARCA);

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (((string.IsNullOrEmpty(txtPatente.Text.Trim())) || (txtPatente.Text == "SinPatente")) || (cmbTipoServicio.Text.Length == 0) || (txtKGD.Text.Length == 0) || (cmbMarca.Text.Length == 0) || (cmbModelo.Text.Length == 0))
            {
                MessageBox.Show("La patente del Micro no puede ser nula y todos los campos deben ser completados");
                return;
            }

            Micro.PATENTE = txtPatente.Text;
            Micro.KG_DISPONIBLES = int.Parse(txtKGD.Text);
            Micro.TIPO_SERVICIO = (cmbTipoServicio.Text);
            Micro.MARCA = (cmbMarca.Text);
            Micro.MODELO = (cmbModelo.Text);


            if (OnMicroeUpdated != null)
                OnMicroeUpdated(this, new MicroQueSePasa() { Micro = this.Micro});
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbModelo_SelectedValueChanged(object sender, EventArgs e)
        {
            var marcas = _modeloManager.GetAllMarcassQueTengaModelo(cmbModelo.Text);
            cmbMarca.Items.Clear();
            foreach (String marca in marcas)
            {
                cmbMarca.Items.Add(marca);
            }
   
            
        }

        private void cmbMarca_SelectedValueChanged(object sender, EventArgs e)
        {
            var modelos = _modeloManager.GetAllModelosQueTengaMarca(cmbMarca.Text);
            cmbModelo.Items.Clear();
            foreach(String modelo in modelos){
                cmbModelo.Items.Add(modelo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPatente.Enabled == true)
            {
                txtKGD.Clear();
                txtPatente.Clear();
                cmbTipoServicio.Text = "";
            }

            cmbModelo.Items.Clear();
            cmbMarca.Items.Clear();

            cmbModelo.Text = "";
            cmbMarca.Text = "";


            var servicioManager = new ServicioManager();
            var servicios = servicioManager.GetAll();
            foreach (Servicio servicio in servicios)
            {
                cmbTipoServicio.Items.Add(servicio.TIPO_SERVICIO);

            }

            var modelos = _modeloManager.GetAll();
            foreach (Modelo modelo in modelos)
            {
                cmbModelo.Items.Add(modelo.MODELO);
                cmbMarca.Items.Add(modelo.MARCA);

            }
        }
    }
}

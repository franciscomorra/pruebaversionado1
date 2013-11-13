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
    public partial class CompraDePasajes : Form
    {
        private CiudadManager _ciudadManager = new CiudadManager();
        private CompraManager _compraManager = new CompraManager();
        private ViajeManager _viajeManager = new ViajeManager();
        int _IDCompra = 0;
        public BindingList<PasajePaquete> _compra = new BindingList<PasajePaquete>();
        
        public CompraDePasajes()
        {
            InitializeComponent();
            var ciudades = _ciudadManager.GetAll();
            foreach (Ciudad ciudad in ciudades)
            {
                comboBoxOrigen.Items.Add(ciudad.NOMBRE);
                comboBoxDestino.Items.Add(ciudad.NOMBRE);

            }
            listarCompra.Enabled = false;
            confirmarCompra.Enabled = false;
            dateTimePicker1.MinDate = Configuracion.fechaAhora();
            dateTimePicker1.Value = Configuracion.fechaAhora();

        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            
            var viajes = _viajeManager.GetPorFechaSalidaOrigenDestino(Convert.ToDateTime(dateTimePicker1.Text), comboBoxOrigen.Text, comboBoxDestino.Text);
            dataGridView1.DataSource = viajes;


            dataGridView1.Columns["COMPRAR"].DisplayIndex = 7;


        }

        private void comboBoxOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            var ciudades = _ciudadManager.GetAllMenosCiudad(comboBoxOrigen.Text);
            comboBoxDestino.Items.Clear();
            foreach (Ciudad ciudad in ciudades)
            {
                comboBoxDestino.Items.Add(ciudad.NOMBRE);
            }

        }

        private void comboBoxDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            var ciudades = _ciudadManager.GetAllMenosCiudad(comboBoxDestino.Text);
            comboBoxOrigen.Items.Clear();
            foreach (Ciudad ciudad in ciudades)
            {
                comboBoxOrigen.Items.Add(ciudad.NOMBRE);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                var dataSource = dataGridView1.DataSource as BindingList<Viaje>;
                var viaje = dataSource[e.RowIndex];

                var seleccionarViajeForm = new FrbaBus.Compra_de_Pasajes.SeleccionarViaje(viaje, _compra);
                seleccionarViajeForm.onPaquetePasajeGet += new EventHandler<PaquetePasajeQueSePasa>(recibirPasajePaquete_OnPaquetePasajeGet);
                seleccionarViajeForm.ShowDialog();

            }
        }

        void recibirPasajePaquete_OnPaquetePasajeGet(object sender, PaquetePasajeQueSePasa e)
        {
            bool seInserto;

            if (_compra.Count == 0)
            {

                _IDCompra = _compraManager.crearCompra(e.pasajePaquete.DNI);
                comboBoxDestino.Enabled = false;
            }

            if (e.pasajePaquete.KG_PAQUETE > 0)
            {

                seInserto = _compraManager.crearPaquete(_IDCompra, e.pasajePaquete);

            }else
            {
                seInserto = _compraManager.crearPasaje(_IDCompra, e.pasajePaquete);

            }
            if (seInserto)
            {
                _compra.Add(e.pasajePaquete);
                listarCompra.Enabled = true;
                confirmarCompra.Enabled = true;
                CancelarCompra.Text = "Cancelar Compra";
            }
            else
                MessageBox.Show("No se pudo agregar el item a la compra");

            this.Seleccionar_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new listadoCompra(_compra).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantDiscapacitados = _compraManager.cantidadDiscapacitados(_compra);

            if (cantDiscapacitados > 1 || ((_compraManager.elDiscapacitado(_compra) != -1) && (_compraManager.cuantosPasajesHay(_compra) > 2)))
            {
                MessageBox.Show("Se modificó el campo discapacitado de un cliente durante la compra. La compra será canelada");
                _compraManager.cancelarCompra(_IDCompra);
                ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
            }
            else
            {
                new ConfirmarCompra(_IDCompra, _compra).ShowDialog();
                ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
            }
        }

        private void CancelarCompra_Click(object sender, EventArgs e)
        {
            if(_IDCompra != 0)
                _compraManager.cancelarCompra(_IDCompra);
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    }
}

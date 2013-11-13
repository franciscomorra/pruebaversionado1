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

namespace FrbaBus.GenerarViaje
{
    public partial class GenerarViaje : Form
    {
        CiudadManager _ciudadManager = new CiudadManager();
        RecorridoManager _recorridoManager = new RecorridoManager();

        int _IDRecorrido = -1;

        public GenerarViaje()
        {
            InitializeComponent();
            dateTimePicker1Salida.Format = DateTimePickerFormat.Custom;
            dateTimePicker1Salida.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dateTimePicker2Llegada.Format = DateTimePickerFormat.Custom;
            dateTimePicker2Llegada.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            generar.Visible = false;
            SelecRecorrido.Enabled = false;
            cmbCiudadDestino.Enabled = false;
            cmbTipoServicio.Enabled = false;
            generar.Enabled = false;
            

            BindingList<Ciudad> ciudades = _ciudadManager.GetAllRecorrido();
            foreach (Ciudad ciudad in ciudades)
            {
                cmbCiudadOrigen.Items.Add(ciudad.NOMBRE);
            }



        }

        private void cmbTipoServicio_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbTipoServicio.Enabled = false;
            SelecRecorrido.Enabled = true;

        }

        private void cmbCiudadOrigen_SelectedValueChanged(object sender, EventArgs e)
        {

            BindingList<Ciudad> ciudades = _ciudadManager.getAllSaliendoDe(cmbCiudadOrigen.Text);
            foreach (Ciudad ciudad in ciudades)
            {
                cmbCiudadDestino.Items.Add(ciudad.NOMBRE);
            }

            
            cmbCiudadOrigen.Enabled = false;
            cmbCiudadDestino.Enabled = true;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }

        private void cmbCiudadDestino_SelectedValueChanged(object sender, EventArgs e)
        {
            ServicioManager servicioManager = new ServicioManager();

            BindingList<Servicio> servicios = servicioManager.getAllCiudadOrigenDestino(cmbCiudadOrigen.Text, cmbCiudadDestino.Text);
            foreach (Servicio servicio in servicios)
            {
                cmbTipoServicio.Items.Add(servicio.TIPO_SERVICIO);
            }

            cmbCiudadDestino.Enabled = false;
            cmbTipoServicio.Enabled = true;
        }

        private void SelecRecorrido_Click(object sender, EventArgs e)
        {
            _IDRecorrido = _recorridoManager.getIDRecorrido(cmbCiudadOrigen.Text, cmbCiudadDestino.Text, cmbTipoServicio.Text);
            if (_IDRecorrido != -1)
            {
                groupBox2.Visible = true;
                SelecRecorrido.Enabled = false;
                dateTimePicker1Salida.MinDate = FrbaBus.Common.Configuracion.fechaAhora();
                dateTimePicker2Llegada.MinDate = FrbaBus.Common.Configuracion.fechaAhora();
                dateTimePicker1Salida.Value= FrbaBus.Common.Configuracion.fechaAhora();
                dateTimePicker2Llegada.Value = FrbaBus.Common.Configuracion.fechaAhora();
                dateTimePicker2Llegada.Value = dateTimePicker1Salida.Value;
            }
            else
            {
                MessageBox.Show("Ingreso un parametro del recorrido incorrecto.");
            }
        }

        private void SelecFechas_Click(object sender, EventArgs e)
        {

            if ((dateTimePicker2Llegada.Value.Subtract(dateTimePicker1Salida.Value).Days) < 1 && dateTimePicker1Salida.Value.CompareTo(dateTimePicker2Llegada.Value) < 0)
            {
                ViajeManager viajeManager = new ViajeManager();
                BindingList<Viaje> viajes = viajeManager.getPatentesPosibles(_IDRecorrido, dateTimePicker1Salida.Value, dateTimePicker2Llegada.Value);
                if (viajes.Count > 0)
                {
                    foreach (Viaje viaje in viajes)
                    {
                        cmbPatente.Items.Add(viaje.PATENTE);
                    }
                    groupBox3.Visible = true;
                    generar.Visible = true;
                    SelecFechas.Enabled = false;
                    dateTimePicker1Salida.Enabled = false;
                    dateTimePicker2Llegada.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontraron micros disponibles.");
                }
            }
            else
            {
                MessageBox.Show("Fecha invalida. La fecha de salida debe ser anterior a la de llegada, y un viaje no puede durar mas de 24 hs");
            }
        }

        private void cmbPatente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPatente.Text.Length > 0)
                generar.Enabled = true;
            else
                generar.Enabled = false;
        }

        private void generar_Click(object sender, EventArgs e)
        {
          
                ViajeManager viajeManager = new ViajeManager();
                viajeManager.insertarViaje(_IDRecorrido, cmbPatente.Text, dateTimePicker1Salida.Value, dateTimePicker2Llegada.Value);
                MessageBox.Show(string.Format("El viaje con origen en {0} y destino {1} asociado al micro {2} fue generado con exito",
                    cmbCiudadOrigen.Text, cmbCiudadDestino.Text, cmbPatente.Text));
                ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    }
}

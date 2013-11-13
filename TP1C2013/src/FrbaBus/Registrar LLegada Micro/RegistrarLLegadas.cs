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

namespace FrbaBus.Registrar_LLegada_Micro
{
    public partial class RegistrarLLegadas : Form
    {

        private RegistroLlegadasManager _registroLlegadasManager = new RegistroLlegadasManager();

        private RegistroLlegadas _registroLlegadas;
      
        private CiudadManager _ciudadManager = new CiudadManager();

        private MicroManager _microManager = new MicroManager();

        public RegistrarLLegadas()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Value = Configuracion.fechaAhora(); 
        }

        private void RegistrarLLegadas_Load(object sender, EventArgs e)
        {   
            var ciudades = _ciudadManager.GetAll();
            foreach (Ciudad ciudad in ciudades)
            {
                CiudadOrigenBox.Items.Add(ciudad.NOMBRE);
                CiudadDestinoBox.Items.Add(ciudad.NOMBRE);

            }
            var micros = _microManager.GetAll();
            foreach (Micro micro in micros)
            {
                PatenteBox.Items.Add(micro.PATENTE);
            }
        }
         
    
        private void Cargar_Click(object sender, EventArgs e)
        {

            if (CiudadDestinoBox.Text.ToString() != CiudadOrigenBox.Text.ToString() && CiudadDestinoBox.Text.Length > 0 && CiudadOrigenBox.Text.Length > 0)
                   {

                       _registroLlegadas = _registroLlegadasManager.Buscar_ID_Viaje(PatenteBox.Text.ToString(), CiudadOrigenBox.Text.ToString(), CiudadDestinoBox.Text.ToString(), dateTimePicker1.Value);

                       if (_registroLlegadas.ID_VIAJE !=  0)
                       {
                          _registroLlegadasManager.Cargar_Fecha_Llegada( dateTimePicker1.Value, _registroLlegadas.ID_VIAJE);
                           MessageBox.Show("La Fecha de Llegada ha sido registrada con exito");
                           PatenteBox.Text = "";
                           CiudadDestinoBox.Text = "";
                           CiudadOrigenBox.Text = "";
                       }
                       else
                       {
                       MessageBox.Show("Error al registrar fecha de llegada, el micro de patente "+ PatenteBox.Text + " no tiene viajes pendientes desde "+  CiudadOrigenBox.Text  + " a " +  CiudadDestinoBox.Text);
                       }

                       }
                    else
                  {
                     MessageBox.Show("Falta ingresar una ciudad");                
                  }
           
                
         }
                private void CiudadOrigenBox_SelectedValueChanged(object sender, EventArgs e)
            {

                var ciudades = _ciudadManager.GetAllMenosCiudad(CiudadOrigenBox.Text);
                CiudadDestinoBox.Items.Clear();
                foreach (Ciudad ciudad in ciudades)
                {
                    CiudadDestinoBox.Items.Add(ciudad.NOMBRE);
                }

                }
           
                private void CiudadDestinoBox_SelectedValueChanged(object sender, EventArgs e)
                {
                    var ciudades = _ciudadManager.GetAllMenosCiudad(CiudadDestinoBox.Text);
                CiudadOrigenBox.Items.Clear();
                foreach (Ciudad ciudad in ciudades)
                {
                    CiudadOrigenBox.Items.Add(ciudad.NOMBRE);
                }

            }

                private void salir_Click(object sender, EventArgs e)
                {
                    ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
                }
                                
    }
} 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Negocio;
using ClinicaFrba.Core;
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.Comun;

namespace ClinicaFrba
{
    [NonNavigable]
    public partial class AddEditProfesionalForm : Form
    {

        private PlanesMedicosManager Planesmanager = new PlanesMedicosManager();
        private Profesional _Profesional = new Profesional();
        public event EventHandler<ProfesionalSavedEventArgs> OnProfesionalSaved;
        public event EventHandler<ProfesionalSavedEventArgs> OnProfesionalUpdated;
        public AddEditProfesionalForm()
        {
            InitializeComponent();
            

        }
        public AddEditProfesionalForm(Profesional Profesional)
        {
            _Profesional = Profesional;
            
            /*var planesMedicos = Planesmanager.GetAll();
            if (planesMedicos.Count > 1)
            {
                cbxPlanMedico.DataSource = planesMedicos;
                cbxPlanMedico.DisplayMember = "Nombre";
                cbxPlanMedico.SelectedIndex = 0;
            }
            */


            InitializeComponent();
        }


        private void AddEditProfesionalForm_Load(object sender, EventArgs e)
        {
            ProcessForm();
            
            /*var planes = Planesmanager.GetAll();
            if (planes.Count > 1)
            {
                cbxPlanMedico.DataSource = planes;
                cbxPlanMedico.DisplayMember = "Nombre";
                cbxPlanMedico.SelectedIndex = 0;
            }
            else
            {


            }*/
        }

        private void ProcessForm()
        {
            /*var profileMan = new ProfileManager();
            Profile perfil = (Profile)cbxPerfiles.SelectedItem;
            var functionalities = functMan.GetProfileFunctionalities(perfil.ID);
            foreach (var item in functionalities)
            {
                lstFuncionalidades.Items.Add(item, ProfesionalHasFunctionality(item));
            }

            txtNombre.Text = Rol.Nombre;*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            
            /*if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("El nombre del Rol no puede ser nulo");
                return;
            }

            Rol.Functionalities = new List<Functionalities>();
            foreach (Functionalities item in lstFuncionalidades.CheckedItems)
            {
                Rol.Functionalities.Add(item);
            }
            Rol.Nombre = txtNombre.Text;

            if (OnProfesionalUpdated != null)
                OnProfesionalUpdated(this, new ProfesionalUpdatedEventArgs() { Rol = this.Rol });
        */
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

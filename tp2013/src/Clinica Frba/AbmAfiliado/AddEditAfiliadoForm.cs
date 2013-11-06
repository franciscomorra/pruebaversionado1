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
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.Comun;
using ClinicaFrba.Login;

namespace ClinicaFrba
{
    [NonNavigable]
    public partial class AddEditAfiliadoForm : Form
    {

        private PlanesMedicosManager Planesmanager = new PlanesMedicosManager();
        private Afiliado _afiliado = new Afiliado();
        List<PlanMedico> _planes;
        public DetallesPersonaUserControl _detallesPersonaUserControl = new DetallesPersonaUserControl();
        public event EventHandler<AfiliadoSavedEventArgs> OnAfiliadoSaved;
        public event EventHandler<AfiliadoSavedEventArgs> OnAfiliadoUpdated;

        public AddEditAfiliadoForm()
        {

            InitializeComponent();
            try
            {
                List<PlanMedico> _planes = Planesmanager.GetAll();
                _planes.ForEach(x => cbxPlanMedico.Items.Add(x));
                cbxPlanMedico.SelectedIndex = 0;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            panelDetalles.Controls.Add(_detallesPersonaUserControl);

        }
        public void SetAfiliado(Afiliado afiliado) { 
        
        }
        public void GetAfiliado(Afiliado afiliado)
        {

        }
        public AddEditAfiliadoForm(Afiliado afiliado)
        {

        }
        private void AddEditAfiliadoForm_Load(object sender, EventArgs e)
        {

        }

        private void ProcessForm()
        {
            /*var profileMan = new ProfileManager();
            Profile perfil = (Profile)cbxPerfiles.SelectedItem;
            var functionalities = functMan.GetProfileFunctionalities(perfil.ID);
            foreach (var item in functionalities)
            {
                lstFuncionalidades.Items.Add(item, AfiliadoHasFunctionality(item));
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

            if (OnAfiliadoUpdated != null)
                OnAfiliadoUpdated(this, new AfiliadoUpdatedEventArgs() { Rol = this.Rol });
        */
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

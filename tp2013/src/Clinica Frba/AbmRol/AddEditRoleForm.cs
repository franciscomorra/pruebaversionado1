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
using ClinicaFrba.AbmRol;
using ClinicaFrba.Comun;

namespace ClinicaFrba
{
    [NonNavigable]
    public partial class AddEditRoleForm : Form
    {
        //public AddEditRoleForm() : this(new Rol()) { }
        private ProfileManager profileMan = new ProfileManager();
        private FunctionalitiesManager functMan = new FunctionalitiesManager();
        private Rol _rol = new Rol();
        private Profile _perfil = new Profile();
        public event EventHandler<RoleUpdatedEventArgs> OnRoleUpdated;


        public AddEditRoleForm()
        {
            InitializeComponent();
            var perfiles = profileMan.GetAllProfiles();
            if (perfiles.Count > 1)
            {
                cbxPerfiles.DataSource = perfiles;
                cbxPerfiles.DisplayMember = "Nombre";
                cbxPerfiles.SelectedIndex = 0;
            }
        }

        public void Set(Rol rol)
        {
            _rol = rol;
            cbxPerfiles.SelectedItem = _rol.Perfil;
            var functionalities = functMan.GetProfileFunctionalities(_rol.Perfil.ID);
            lstFuncionalidades.Items.Clear();
            foreach (var item in functionalities)
            {
                lstFuncionalidades.Items.Add(item, RoleHasFunctionality(item));
            }
            cbxPerfiles.Enabled = false;
            txtNombreRol.Text = _rol.Nombre;
        }


        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profileMan = new ProfileManager();
            if ((Profile)cbxPerfiles.SelectedItem != null)
            {
                _perfil = (Profile)cbxPerfiles.SelectedItem;

                var functionalities = functMan.GetProfileFunctionalities(_perfil.ID);
                lstFuncionalidades.Items.Clear();
                foreach (var item in functionalities)
                {
                    lstFuncionalidades.Items.Add(item, RoleHasFunctionality(item));
                }
            }
        }
        private bool RoleHasFunctionality(Functionalities functionality)
        {
            if (_rol == null || _rol.Functionalities == null) return false;
            return _rol.Functionalities.Contains(functionality);
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreRol.Text.Trim()))
                    throw new Exception("El Nombre es obligatorio!");


                _rol.Functionalities = new List<Functionalities>();
                foreach (Functionalities item in lstFuncionalidades.CheckedItems)
                {
                    _rol.Functionalities.Add(item);
                }
                _rol.Nombre = txtNombreRol.Text;
                _rol.Perfil = (Profile)cbxPerfiles.SelectedItem;
                if (OnRoleUpdated != null)
                    OnRoleUpdated(this, new RoleUpdatedEventArgs() { Rol = _rol });
                this.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }







        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

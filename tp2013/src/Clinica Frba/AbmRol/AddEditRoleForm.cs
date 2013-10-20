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

namespace ClinicaFrba //REHACER AGREGANDO EL PERFIL
{
    [NonNavigable]
    public partial class AddEditRoleForm : Form
    {
        //public AddEditRoleForm() : this(new Rol()) { }
        private ProfileManager profileMan = new ProfileManager();
        private FunctionalitiesManager functMan = new FunctionalitiesManager();
        private Rol Rol { get; set; }
        private Profile Perfil { get; set; }
        public AddEditRoleForm()
        {
            var perfiles = profileMan.GetAllProfiles();
            if (perfiles.Count > 1)
            {
                cbxPerfiles.DataSource = perfiles;
                cbxPerfiles.DisplayMember = "Nombre";
                cbxPerfiles.SelectedIndex = 0;
                perfilPanel.Show();
                rolPanel.Hide();
            }
            InitializeComponent();
        }
        public AddEditRoleForm(Rol rol)
        {
            perfilPanel.Hide();
            rolPanel.Show();
            InitializeComponent();
            this.Rol = rol;
            this.Perfil = rol.Perfil;

        }

        public event EventHandler<RoleUpdatedEventArgs> OnRoleUpdated;

        private void AddEditRoleForm_Load(object sender, EventArgs e)
        {
            ProcessForm();
        }

        private void ProcessForm()
        {
            
            var profileMan = new ProfileManager();
            Profile perfil = (Profile)cbxPerfiles.SelectedItem;
            var functionalities = functMan.GetProfileFunctionalities(perfil.ID);
            foreach (var item in functionalities)
            {
                lstFuncionalidades.Items.Add(item, RoleHasFunctionality(item));
            }

            txtNombre.Text = Rol.Nombre;
        }

        private bool RoleHasFunctionality(Functionalities functionality)
        {
            if (Rol == null || Rol.Functionalities == null) return false;
            return Rol.Functionalities.Contains(functionality);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
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

            if (OnRoleUpdated != null)
                OnRoleUpdated(this, new RoleUpdatedEventArgs() { Rol = this.Rol });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Perfil = (Profile)cbxPerfiles.SelectedItem;
            var functionalities = functMan.GetProfileFunctionalities(this.Perfil.ID);
            foreach (var item in functionalities)
            {
                lstFuncionalidades.Items.Add(item, RoleHasFunctionality(item));
            }
            rolPanel.Show();
            perfilPanel.Hide();
        }
    }
}

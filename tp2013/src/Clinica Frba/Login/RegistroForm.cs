using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Negocio;
using ClinicaFrba.Comun;
using ClinicaFrba.Login;
using ClinicaFrba.Core;

namespace ClinicaFrba
{
    [NonNavigable]
    public partial class RegistroForm : Form
    {
        public event EventHandler<UserSavedEventArgs> OnUserSaved;
        //private List<Profile> Profiles;
        private AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
        private ProfesionalUserControl profesionalUserControl = new ProfesionalUserControl();
        private Profesional _profesional = new Profesional();
        private Afiliado _afiliado = new Afiliado();
        private bool _updatingData = false;
        
        public Profile Profile
        {
            get
            {
                return (Profile)cbxProfiles.SelectedItem;
            }
            set
            {
                cbxProfiles.SelectedItem = value;
                cbxProfiles.Enabled = false;
                cbxProfiles.Visible = false;
                lblPerfil.Visible = false;
            }
        }
        

        public RegistroForm()
        {
            InitializeComponent();
            var manager = new ProfileManager();
            var perfiles = manager.GetAllProfiles();
            cbxProfiles.DataSource = perfiles;
            cbxProfiles.DisplayMember = "Nombre";
            cbxProfiles.SelectedIndex = 0;
        }

        public void SetUser(User user)
        {
            _updatingData = true;
            txtUsername.Text = user.UserName;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            cbxProfiles.Enabled = false;
            Profile perfilmascara = new Profile();
            if (user is Afiliado)
            {
                perfilmascara.Nombre = "Afiliado";
                _afiliado = user as Afiliado;
                cbxProfiles.SelectedIndex = cbxProfiles.Items.IndexOf(perfilmascara);//HotFix para que seleccione el perfil
                afiliadoUserControl.SetUser(_afiliado);
            }
            else
            {
                perfilmascara.Nombre = "Profesional";
                _profesional = user as Profesional;
                cbxProfiles.SelectedIndex = cbxProfiles.Items.IndexOf(perfilmascara);
                profesionalUserControl.SetUser(_profesional);
            }
            
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cbxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            userPanel.Controls.Clear();
            Profile perfilSelected = (Profile)cbxProfiles.SelectedItem;
            if (perfilSelected.Nombre == "Afiliado")
            {
                
                userPanel.Controls.Add(afiliadoUserControl);
            }
            else
            {
                userPanel.Controls.Add(profesionalUserControl);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_updatingData)
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                    throw new Exception("El nombre de usuario es obligatorio!");
                if (string.IsNullOrEmpty(txtPassword.Text))
                    throw new Exception("El password es obligatorio!");
                if (txtPassword.Text != txtConfirmPassword.Text)
                    throw new Exception("Los passwords no coinciden!");
            }

            User user = null;
            if (Profile.Nombre == "Afiliado")
            {
                _afiliado = ((AfiliadoUserControl)afiliadoUserControl).GetAfiliado();
                _afiliado.UserName = txtUsername.Text;
                var manager = new AfiliadoManager();
                int nroAfiliado = manager.GuardarAfiliado(_afiliado, txtPassword.Text);
                user = _afiliado;
                if (nroAfiliado != 0) //Nuevo afiliado
                {
                    if (_afiliado.EstadoCivil != EstadoCivil.Soltero || _afiliado.EstadoCivil != EstadoCivil.Viudo)
                    {
                        
                        //Preguntar si quiere agregar Conyuge


                    }
                    if (_afiliado.CantHijos > 0)
                    {
                        nroAfiliado = nroAfiliado + 1;

                    }
                }
            }
            else
            {
                _profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                _profesional.UserName = txtUsername.Text;
                var manager = new ProfesionalManager();
                manager.GuardarProfesional(_profesional, txtPassword.Text);
                user = _profesional; 
            }

            if (OnUserSaved != null)
            {
                OnUserSaved(this, new UserSavedEventArgs() { Username = this.txtUsername.Text, Password = this.txtPassword.Text, User = user });
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignarPerfil_Click(object sender, EventArgs e)
        {

        }

    }
}

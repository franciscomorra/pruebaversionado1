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
        private List<Profile> Profiles;
        private AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
        private ProfesionalUserControl profesionalUserControl = new ProfesionalUserControl();
        private Profesional _profesional = new Profesional();
        private Afiliado _afiliado = new Afiliado();
        private ProfileManager _profmanager = new ProfileManager();

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
            try
            {
                Profiles = _profmanager.GetAllProfilesForRegistration();
                Profiles.ForEach(x => cbxProfiles.Items.Add(x));
                cbxProfiles.SelectedIndex = 0;
                cbxProfiles.DisplayMember = "Nombre";
                cbxSexo.DataSource = Enum.GetValues(typeof(TipoSexo)).Cast<TipoSexo>().ToList();
                cbxTipoDNI.DataSource = Enum.GetValues(typeof(TipoDoc)).Cast<TipoDoc>().ToList();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        public void SetUser(User user)
        {
            txtUsername.Text = user.UserName;
            txtApellido.Text = user.DetallePersona.Apellido.Trim();
            txtNombre.Text = user.DetallePersona.Nombre.Trim();
            txtDNI.Text = user.DetallePersona.DNI.ToString();
            cbxSexo.SelectedItem = user.DetallePersona.Sexo;
            dtFechaNacimiento.Value = user.DetallePersona.FechaNacimiento;
            txtDireccion.Text = user.DetallePersona.Direccion.Trim();
            txtTelefono.Text = user.DetallePersona.Telefono.ToString();
            txtMail.Text = user.DetallePersona.Email.Trim();
           // cbxProfiles.Enabled = false;
            Profile perfil = new Profile();
            if (user is Afiliado)
            {
                _afiliado = user as Afiliado;
                perfil = _profmanager.getInfo("Afiliado");
                cbxProfiles.SelectedItem = perfil;
                afiliadoUserControl.SetUser(_afiliado);
            }
            else if (user is Profesional)
            {
                _profesional = user as Profesional;
                perfil = _profmanager.getInfo("Profesional");
                cbxProfiles.SelectedItem = perfil;
                profesionalUserControl.SetUser(_profesional);
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {

        }

        private void cbxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            userPanel.Controls.Clear();

            if (Profile.Nombre == "Afiliado")
            {
                userPanel.Controls.Add(afiliadoUserControl);
            }
            else if (Profile.Nombre == "Profesional")
            {
                userPanel.Controls.Add(profesionalUserControl);
            }
            else {
                throw new Exception("Error de Perfiles");
            
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            User user = new User();
            long telefono;
            long dni;
            if (string.IsNullOrEmpty(txtUsername.Text))
                throw new Exception("El nombre de usuario es obligatorio!");
            if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                throw new Exception("El teléfono debe ser numérico!");
            if (!long.TryParse(txtDNI.Text, out dni))
                throw new Exception("El DNI debe ser numérico!");
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                throw new Exception("El Nombre es obligatorio!");
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                throw new Exception("El Apellido es obligatorio!");

            if (string.IsNullOrEmpty(txtMail.Text.Trim()))
                throw new Exception("El Email es obligatorio!");

            user.DetallePersona.Apellido = txtApellido.Text.Trim();
            user.DetallePersona.Nombre = txtNombre.Text.Trim();
            user.DetallePersona.DNI = dni;
            user.DetallePersona.FechaNacimiento = dtFechaNacimiento.Value;
            user.DetallePersona.Direccion = txtDireccion.Text.Trim();
            user.DetallePersona.Telefono = telefono;
            user.DetallePersona.Email = txtMail.Text.Trim();

            
            if (Profile.Nombre == "Afiliado")
            {
                _afiliado = ((AfiliadoUserControl)afiliadoUserControl).GetAfiliado();
                _afiliado.UserName = txtUsername.Text;
                var manager = new AfiliadoManager();
                _afiliado.DetallePersona = user.DetallePersona;
                manager.GuardarAfiliado(_afiliado, txtPassword.Text);

            }
            else if (Profile.Nombre == "Profesional")
            {
                _profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                _profesional.DetallePersona = user.DetallePersona;
                _profesional.UserName = txtUsername.Text;
                var manager = new ProfesionalManager();
                manager.GuardarProfesional(_profesional, txtPassword.Text);
                user = _profesional;
            }
            else {
                throw new Exception("Error en Perfiles"); 
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
    }
}










/*
 * using System;
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

        private bool _updatingData = false;
        ProfileManager _perfilManager = new ProfileManager();
        RolesManager _rolesManager = new RolesManager();
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
        }
        
        public void SetUser(User user, Profile perfil)
        {

               _updatingData = true;
               txtUsername.Text = user.UserName;
               txtUsername.Enabled = true;
              // cbxProfiles.Enabled = false;

               //Inicio detalles de persona
               txtApellido.Text = user.DetallePersona.Apellido.Trim();
               txtNombre.Text = user.DetallePersona.Nombre.Trim();
               txtDNI.Text = user.DetallePersona.DNI.ToString();
               cbxSexo.SelectedItem = user.DetallePersona.Sexo;
               dtFechaNacimiento.Value = user.DetallePersona.FechaNacimiento;
               txtDireccion.Text = user.DetallePersona.Direccion.Trim();
               txtTelefono.Text = user.DetallePersona.Telefono.ToString();
               txtMail.Text = user.DetallePersona.Email.Trim();
               //Fin detalles de persona

            
               BindingList<Rol> listadoRoles = _rolesManager.GetUserRoles(user.UserID);
               ProfileManager prmanager = new ProfileManager();
               perfil = prmanager.getInfo(perfil.Nombre);

               if (listadoRoles.Count == 1) {
                   cbxProfiles.Enabled = false;
                   cbxProfiles.SelectedIndex = cbxProfiles.Items.IndexOf(perfil);
               }

               if (perfil.Nombre == "Afiliado") {
                   AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
                   Afiliado afiliado = user as Afiliado;
                   afiliadoUserControl.SetAfiliado(afiliado);

                   userPanel.Controls.Add(afiliadoUserControl);
               }else if (perfil.Nombre == "Profesional")
               {
                   AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
                   Afiliado afiliado = user as Afiliado;
                   afiliadoUserControl.SetUser(afiliado);
               }

        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
   try
            {
                cbxSexo.DataSource = Enum.GetValues(typeof(TipoSexo)).Cast<TipoSexo>().ToList();
                cbxTipoDNI.DataSource = Enum.GetValues(typeof(TipoDoc)).Cast<TipoDoc>().ToList();
                var manager = new ProfileManager();
                var perfiles = manager.GetAllProfiles();
                cbxProfiles.DataSource = perfiles;
                cbxProfiles.DisplayMember = "Nombre";
                cbxProfiles.SelectedIndex = 0;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void cbxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

                userPanel.Controls.Clear();
                Profile perfilSelected = (Profile)cbxProfiles.SelectedItem;
                if (perfilSelected.Nombre.ToString() == "Afiliado")
                {
                    AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
                    userPanel.Controls.Add(afiliadoUserControl);
                }
                else if (perfilSelected.Nombre == "Profesional")
                {
                    ProfesionalUserControl profesionalUserControl = new ProfesionalUserControl();
                    userPanel.Controls.Add(profesionalUserControl);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try{
                long telefono = 0;
                long dni = 0;
                User user = new User();
                if (!_updatingData)
                {
                    if (string.IsNullOrEmpty(txtUsername.Text))
                        throw new Exception("El nombre de usuario es obligatorio!");
                }

                if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                    throw new Exception("El teléfono debe ser numérico!");
                if (!long.TryParse(txtDNI.Text, out dni))
                    throw new Exception("El DNI debe ser numérico!");
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                    throw new Exception("El Nombre es obligatorio!");
                if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                    throw new Exception("El Apellido es obligatorio!");

                if (string.IsNullOrEmpty(txtMail.Text.Trim()))
                    throw new Exception("El Email es obligatorio!");

                user.DetallePersona.Apellido = txtApellido.Text.Trim();
                user.DetallePersona.Nombre = txtNombre.Text.Trim();
                user.DetallePersona.DNI = dni;
                user.DetallePersona.FechaNacimiento = dtFechaNacimiento.Value;
                user.DetallePersona.Direccion = txtDireccion.Text.Trim();
                user.DetallePersona.Telefono = telefono;
                user.DetallePersona.Email = txtMail.Text.Trim();


                if (Profile.Nombre == "Afiliado")
                {
                    Afiliado afiliado = new Afiliado();
                    AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
                    afiliado = ((AfiliadoUserControl)afiliadoUserControl).GetAfiliado();
                    afiliado.UserName = txtUsername.Text;
                    var manager = new AfiliadoManager();
                    long nroAfiliado = manager.GuardarAfiliado(afiliado, txtPassword.Text);
                    user = afiliado;
                    if (nroAfiliado != 0) //Nuevo afiliado
                    {
                        if (afiliado.EstadoCivil != EstadoCivil.Soltero || afiliado.EstadoCivil != EstadoCivil.Viudo)
                        {
                            //Preguntar si quiere agregar Conyuge
                        }
                        if (afiliado.CantHijos > 0)
                        {
                            nroAfiliado = nroAfiliado + 1;

                        }
                    }
                }
                else
                {
                    Profesional profesional = new Profesional();
                    ProfesionalUserControl profesionalUserControl = new ProfesionalUserControl();
                    profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                    profesional.UserName = txtUsername.Text;
                    var manager = new ProfesionalManager();
                    manager.GuardarProfesional(profesional, txtPassword.Text);
                    user = profesional; 
                }

                if (OnUserSaved != null)
                {
                    OnUserSaved(this, new UserSavedEventArgs() { Username = this.txtUsername.Text, Password = this.txtPassword.Text, User = user });
                    this.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
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
*/
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



/*
Casos de uso del formulario Registro_form
 * 1. Afiliado
 *  a. Afiliado Nuevo
 *      Motivo de cambio no aplica
 *      a. Afiliado Nuevo que es jefe de familia
 *          Formulario vacio, Paneles de hijo de y conyuge de no se deben mostrar
 *          Si se debe preguntar la cantidad de hijos y estado civil
 *          Segun cantidad de hijos y estado civil, se preguntara si quiere cargarlos.
 *          Salvo que existan ya todos los hijos, y tenga conyuge cargado
 *      b. Afiliado Nuevo que es conyuge de otro afiliado existente
 *          Formulario debe contener mismos datos que el conyuge, como direccion y telefono
 *          No se pregunta cantidad de hijos y estado civil, no se muestran
 *          No se muesta panel hijo de, y conyuge esta rellenado pero inhabilitado
 *      c. Afiliado Nuevo que es hijo de otro afiliado existente
 *          Formulario debe contener mismos datos que el padre, como direccion y telefono
 *          No se pregunta cantidad de hijos y estado civil, no se muestran
 *          Panel hijo de esta autocompletado, y conyuge no se muestra
 *  b. Afiliado que modifica sus datos 
 *      a. Afiliado jefe de familia
 *          Si varia la cantidad de hijos, aumentando, que pregunte si desea cargar
 *      b. Afiliado conyuge
 *          
 *      c. Afiliado hijo de 
 * 2. Profesional
 *  a. Profesional Nuevo
 *      
 *  b. Profesional Existente
 */
namespace ClinicaFrba
{
    [NonNavigable]
    public partial class RegistroForm : Form
    {
        public event EventHandler<UserSavedEventArgs> OnUserSaved;
        private List<Perfil> Perfiles;
        private AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
        private ProfesionalUserControl profesionalUserControl = new ProfesionalUserControl();
        private Profesional _profesional = new Profesional();
        private Afiliado _afiliado = new Afiliado();
        private PerfilManager _perfilesManager = new PerfilManager();
        public bool elegirPerfil = true;
        public Perfil perfil;

        public RegistroForm()
        {
            bool puedeModificarAfiliados = Session.User.Permissions.Contains(Functionalities.AdministrarAfiliados);
            bool puedeModificarProfesionales = Session.User.Permissions.Contains(Functionalities.AdministrarProfesionales);
            if ((puedeModificarAfiliados && !puedeModificarProfesionales) || (puedeModificarProfesionales && !puedeModificarAfiliados))
                elegirPerfil = false;

            InitializeComponent(); 
            try
            {
                Perfiles = _perfilesManager.GetAllPerfilesForRegistration();
                Perfiles.ForEach(x => cbxPerfiles.Items.Add(x));
                cbxPerfiles.SelectedIndex = 0;
               // cbxPerfiles.DisplayMember = "Nombre";
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
           // cbxPerfiles.Enabled = false;
            Perfil perfil = new Perfil();
            if (user is Afiliado)
            {
                _afiliado = user as Afiliado;
                perfil = _perfilesManager.getInfo("Afiliado");
                cbxPerfiles.SelectedItem = perfil;
            }
            else if (user is Profesional)
            {
                _profesional = user as Profesional;
                perfil = _perfilesManager.getInfo("Profesional");
                cbxPerfiles.SelectedItem = perfil;
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {
            if (!elegirPerfil)
                cbxPerfiles.Enabled = false;
        }

        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                userPanel.Controls.Clear();
                perfil = cbxPerfiles.SelectedItem as Perfil;
                if (perfil.Nombre == "Afiliado")
                {
                    afiliadoUserControl.SetUser(_afiliado);
                    userPanel.Controls.Add(afiliadoUserControl);
                }
                else if (perfil.Nombre == "Profesional")
                {
                    profesionalUserControl.SetUser(_profesional);
                    userPanel.Controls.Add(profesionalUserControl);
                }
                else
                   throw new Exception("Error de Perfiles");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           try
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

                
                if (perfil.Nombre == "Afiliado")
                {
                    _afiliado = ((AfiliadoUserControl)afiliadoUserControl).GetAfiliado();
                    _afiliado.UserName = txtUsername.Text;
                    var manager = new AfiliadoManager();
                    _afiliado.DetallePersona = user.DetallePersona;
                    manager.GuardarAfiliado(_afiliado, txtPassword.Text);

                }
                else if (perfil.Nombre == "Profesional")
                {
                    _profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                    _profesional.DetallePersona = user.DetallePersona;
                    _profesional.UserName = txtUsername.Text;
                    var manager = new ProfesionalManager();
                    manager.GuardarProfesional(_profesional, txtPassword.Text);
                    user = _profesional;
                }
                else 
                    throw new Exception("Error en Perfiles"); 
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
        PerfilManager _perfilManager = new PerfilManager();
        RolesManager _rolesManager = new RolesManager();
        public Perfil Perfil
        {
            get
            {
                return (Perfil)cbxPerfiles.SelectedItem;
            }
            set
            {
                cbxPerfiles.SelectedItem = value;
                cbxPerfiles.Enabled = false;
                cbxPerfiles.Visible = false;
                lblPerfil.Visible = false;
            }
        }
        

        public RegistroForm()
        {
            InitializeComponent();
        }
        
        public void SetUser(User user, Perfil perfil)
        {

               _updatingData = true;
               txtUsername.Text = user.UserName;
               txtUsername.Enabled = true;
              // cbxPerfiles.Enabled = false;

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
               PerfilManager prmanager = new PerfilManager();
               perfil = prmanager.getInfo(perfil.Nombre);

               if (listadoRoles.Count == 1) {
                   cbxPerfiles.Enabled = false;
                   cbxPerfiles.SelectedIndex = cbxPerfiles.Items.IndexOf(perfil);
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
                var manager = new PerfilManager();
                var perfiles = manager.GetAllPerfiles();
                cbxPerfiles.DataSource = perfiles;
                cbxPerfiles.DisplayMember = "Nombre";
                cbxPerfiles.SelectedIndex = 0;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

                userPanel.Controls.Clear();
                Perfil Perfileselected = (Perfil)cbxPerfiles.SelectedItem;
                if (Perfileselected.Nombre.ToString() == "Afiliado")
                {
                    AfiliadoUserControl afiliadoUserControl = new AfiliadoUserControl();
                    userPanel.Controls.Add(afiliadoUserControl);
                }
                else if (Perfileselected.Nombre == "Profesional")
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


                if (Perfil.Nombre == "Afiliado")
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
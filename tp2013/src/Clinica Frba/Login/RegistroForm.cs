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
        public Afiliado _conyuge = new Afiliado();
        public Afiliado _padre = new Afiliado();
        User user = new User();
        public int _nroAfiliado;
        public bool esNuevoUsuario = true;

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
        private void RegistroForm_Load(object sender, EventArgs e)
        {
            if (!elegirPerfil)
                cbxPerfiles.Enabled = false;

        }

        public void rellenarAfiliado(Afiliado afiliado)//Modificacion de afiliado existente
        {
            _afiliado = afiliado;
            rellenarCamposUsuario(afiliado.DetallesPersona);
            cbxPerfiles.SelectedItem = _perfilesManager.getInfo("Afiliado");
            afiliadoUserControl.esNuevoUsuario = esNuevoUsuario;
            afiliadoUserControl.rellenarCampos(_afiliado);
            afiliadoUserControl._conyuge = _conyuge;
            afiliadoUserControl._padre = _padre;
            afiliadoUserControl._nroAfiliado = _nroAfiliado;
            userPanel.Controls.Add(afiliadoUserControl);

        }
        public void rellenarProfesional(Profesional profesional)//Modificacion de profesional
        {
            _profesional = profesional;
            rellenarCamposUsuario(profesional.DetallesPersona);
            cbxPerfiles.SelectedItem = _perfilesManager.getInfo("Profesional");
            profesionalUserControl.SetUser(_profesional);
            userPanel.Controls.Add(profesionalUserControl);
        }


        private void rellenarCamposUsuario(DetallesPersona detalles){
            
            txtApellido.Text = detalles.Apellido.Trim();
            txtNombre.Text = detalles.Nombre.Trim();
            txtDNI.Text = detalles.DNI.ToString();
            cbxSexo.SelectedItem = detalles.Sexo;
            cbxTipoDNI.SelectedIndex = cbxTipoDNI.Items.IndexOf(detalles.TipoDNI);
            dtFechaNacimiento.Value = detalles.FechaNacimiento;
            txtDireccion.Text = detalles.Direccion.Trim();
            txtTelefono.Text = detalles.Telefono.ToString();
            txtMail.Text = detalles.Email.Trim();
        }
        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                userPanel.Controls.Clear();
                perfil = cbxPerfiles.SelectedItem as Perfil;
                RolesManager rman = new RolesManager();
                var roles = rman.GetRolesByPerfil(perfil);
                cbxRoles.Items.Clear();
                foreach (Rol rol in roles)
                    cbxRoles.Items.Add(rol);
                
                cbxRoles.DisplayMember = "Nombre";
                cbxRoles.SelectedIndex = 0;
                if (perfil.Nombre == "Afiliado")
                {
                    afiliadoUserControl.esNuevoUsuario = esNuevoUsuario;
                    afiliadoUserControl.rellenarCampos(_afiliado);
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

            user = new User();    
            long telefono;
            long dni;
            Session.Errores = null;
            if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                throw new Exception(" El teléfono debe ser numérico!");
            if (!long.TryParse(txtDNI.Text, out dni))
                throw new Exception(" El DNI debe ser numérico!");
            if(dni > 99999999)
                throw new Exception(" El DNI no es valido!");
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                throw new Exception(" El Nombre es obligatorio!");
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                throw new Exception(" El Apellido es obligatorio!");
            if (string.IsNullOrEmpty(txtMail.Text.Trim()))
                throw new Exception(" El Email es obligatorio!");
            user.DetallesPersona.Apellido = txtApellido.Text.Trim();
            user.DetallesPersona.Nombre = txtNombre.Text.Trim();
            user.DetallesPersona.DNI = dni;
            user.DetallesPersona.FechaNacimiento = dtFechaNacimiento.Value;
            user.DetallesPersona.Direccion = txtDireccion.Text.Trim();
            user.DetallesPersona.Telefono = telefono;
            user.DetallesPersona.Email = txtMail.Text.Trim();
            user.DetallesPersona.TipoDNI = (TipoDoc)cbxTipoDNI.SelectedItem;
            user.DetallesPersona.Sexo = (TipoSexo)cbxSexo.SelectedItem;
            Rol rolSeleccionado = (Rol)cbxRoles.SelectedItem;

            if (perfil.Nombre == "Afiliado")
            {
                _afiliado = ((AfiliadoUserControl)afiliadoUserControl).devolverCampos();
                _afiliado.UserName = user.DetallesPersona.DNI.ToString();
                var manager = new AfiliadoManager();
                _afiliado.DetallesPersona = user.DetallesPersona;
                _afiliado.RoleID = rolSeleccionado.ID;
                try
                {
                    manager.GuardarAfiliado(_afiliado);
                    user = _afiliado as User;
                    OnUserSaved(this, new UserSavedEventArgs() { User = user });
                    this.Close();
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
            else if (perfil.Nombre == "Profesional")
            {
                _profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                _profesional.DetallesPersona = user.DetallesPersona;
                _profesional.UserName = user.DetallesPersona.DNI.ToString();
                var manager = new ProfesionalManager();
                _profesional.RoleID = rolSeleccionado.ID;

                try
                {
                    manager.GuardarProfesional(_profesional);
                    user = _profesional as User;
                    OnUserSaved(this, new UserSavedEventArgs() { User = user });
                    this.Close();
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }

            }
            else
            {
                throw new Exception("Error en Perfiles");
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

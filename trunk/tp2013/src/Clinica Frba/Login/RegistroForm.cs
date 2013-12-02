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
 *      c. Afiliado hijo de 
 * 2. Profesional
 *  a. Profesional Nuevo
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
        private UsersManager _userManager = new UsersManager();
        private DetallePersonaManager _detallesManager = new DetallePersonaManager();

        private ProfesionalManager _profesionalManager = new ProfesionalManager();
        private Profesional _profesional = new Profesional();
        private AfiliadoManager _afiliadoManager = new AfiliadoManager();
        private Afiliado _afiliado = new Afiliado();
        private PerfilManager _perfilesManager = new PerfilManager();
        RolesManager _rolesManager = new RolesManager();
        public bool puedeElegirPerfil = true;
        public Perfil perfil;
        public string perfilSeleccionado;
        User user;
        private long _grupoFamiliar = 0;
        public bool esNuevoUsuario = true;
        private int _tipoAfiliado;
        public RegistroForm()
        {
            try
            {
                InitializeComponent(); 
                bool puedeModificarAfiliados = Session.User.Permissions.Contains(Functionalities.AdministrarAfiliados);
                bool puedeModificarProfesionales = Session.User.Permissions.Contains(Functionalities.AdministrarProfesionales);
                if ((puedeModificarAfiliados && !puedeModificarProfesionales) || (puedeModificarProfesionales && !puedeModificarAfiliados))
                    puedeElegirPerfil = false;

                Perfiles = _perfilesManager.GetAllPerfilesForRegistration();
                Perfiles.ForEach(x => cbxPerfiles.Items.Add(x));
                
                cbxPerfiles.DisplayMember = "Nombre";
                
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
            if (!puedeElegirPerfil || esNuevoUsuario)
                cbxPerfiles.Enabled = false;
            if(!esNuevoUsuario)
                txtDNI.Enabled = false;
            cbxPerfiles.SelectedItem = _perfilesManager.getInfo(perfilSeleccionado);
        }

        public void rellenarAfiliado(Afiliado afiliado)//Modificacion de afiliado existente
        {
            _afiliado = afiliado;
            _grupoFamiliar = afiliado.grupoFamiliar;
            _tipoAfiliado = afiliado.tipoAfiliado;
            user = afiliado as User;
            rellenarCamposUsuario(user);
            afiliadoUserControl.esNuevoUsuario = esNuevoUsuario;
            afiliadoUserControl.rellenarAfiliado(_afiliado);
            afiliadoUserControl._grupoFamiliar = _grupoFamiliar;
            afiliadoUserControl._tipoAfiliado = _afiliado.tipoAfiliado;
            userPanel.Controls.Add(afiliadoUserControl);
        }
        public void rellenarProfesional(Profesional profesional)//Modificacion de profesional
        {
            _profesional = profesional;
            user = _profesional as User;
            rellenarCamposUsuario(user);
            
            profesionalUserControl.RellenarProfesional(_profesional);
            userPanel.Controls.Add(profesionalUserControl);
        }
        private void rellenarCamposUsuario(User usuario){

            if (Session.User.UserID == usuario.UserID) {
                lblPerfil.Visible = false;
                lblRol.Visible = false;
                cbxPerfiles.Visible = false;
                cbxRoles.Visible = false;
            }
            txtApellido.Text = usuario.DetallesPersona.Apellido.Trim();
            txtNombre.Text = usuario.DetallesPersona.Nombre.Trim();
            txtDNI.Text = usuario.DetallesPersona.DNI.ToString();
            cbxSexo.SelectedItem = usuario.DetallesPersona.Sexo;
            cbxTipoDNI.SelectedIndex = cbxTipoDNI.Items.IndexOf(usuario.DetallesPersona.TipoDNI);
            dtFechaNacimiento.Value = usuario.DetallesPersona.FechaNacimiento;
            txtDireccion.Text = usuario.DetallesPersona.Direccion.Trim();
            txtTelefono.Text = usuario.DetallesPersona.Telefono.ToString();
            txtMail.Text = usuario.DetallesPersona.Email.Trim();
            cbxPerfiles.Enabled = true;
        }
        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                userPanel.Controls.Clear();
                perfil = cbxPerfiles.SelectedItem as Perfil;
                var roles = _rolesManager.BuscarTodosPorPerfil(perfil);
                cbxRoles.Items.Clear();
                foreach (Rol rol in roles)
                    cbxRoles.Items.Add(rol);
                cbxRoles.DisplayMember = "Nombre";
                cbxRoles.SelectedIndex = 0;
                if (perfil.Nombre == "Afiliado")
                {
                    if (!esNuevoUsuario)
                    {
                        _afiliado = _afiliadoManager.actualizarInformacion(user.UserID);
                    }
                    afiliadoUserControl.rellenarAfiliado(_afiliado);
                    afiliadoUserControl.esNuevoUsuario = esNuevoUsuario;
                    userPanel.Controls.Add(afiliadoUserControl);
                }
                else if (perfil.Nombre == "Profesional")
                {
                    if (!esNuevoUsuario)
                    {
                        _profesional = _profesionalManager.getInfo(user.UserID);
                        profesionalUserControl.RellenarProfesional(_profesional);
                    }
                    userPanel.Controls.Add(profesionalUserControl);
                }
                else
                   throw new Exception("Error de Perfiles");

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(esNuevoUsuario)
                    user = new User();
                user = ValidarDetallesPersona(user);
                Rol rolSeleccionado = (Rol)cbxRoles.SelectedItem;
                if (esNuevoUsuario)
                {
                    user.UserName = user.DetallesPersona.DNI.ToString() ;
                    user.UserID= _userManager.InsertarUsuario(user);
                    _detallesManager.AgregarDetalles(user.DetallesPersona, user.UserID);
                }
                else {
                    _detallesManager.ModificarDetalles(user.DetallesPersona, user.UserID);
                }
                if (perfil.Nombre == "Afiliado")
                {
                    _afiliado = ((AfiliadoUserControl)afiliadoUserControl).devolverCampos();
                    _afiliado.UserID = user.UserID;
                    _afiliado.grupoFamiliar = _grupoFamiliar;
                    _afiliado.DetallesPersona = user.DetallesPersona;
                    _afiliado.tipoAfiliado = _tipoAfiliado;
                    _afiliado.RoleID = rolSeleccionado.ID;
                    _afiliado = _afiliadoManager.GuardarAfiliado(_afiliado);
                    user = _afiliado as User;
                }
                else if (perfil.Nombre == "Profesional")
                {
                    _profesional = ((ProfesionalUserControl)profesionalUserControl).GetProfesional();
                    _profesional.DetallesPersona = user.DetallesPersona;
                    _profesional.UserID = user.UserID;
                    _profesional.RoleID = rolSeleccionado.ID;
                    _profesionalManager.GuardarProfesional(_profesional);
                    user = _profesional as User;
                }
                else
                {
                    throw new Exception("Error en Perfiles");
                }
                OnUserSaved(this, new UserSavedEventArgs() { User = user, grupoFamiliar = _grupoFamiliar });
                this.Close();
                
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
        }

        private User ValidarDetallesPersona(User user)
        {
            long telefono;
            long dni;
            if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                throw new Exception(" El teléfono debe ser numérico!");
            if (!long.TryParse(txtDNI.Text, out dni))
                throw new Exception(" El DNI debe ser numérico!");
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                throw new Exception(" El Nombre es obligatorio!");
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                throw new Exception(" El Apellido es obligatorio!");
            if (string.IsNullOrEmpty(txtMail.Text.Trim()))
                throw new Exception(" El Email es obligatorio!");
            if (dni==0 || dni>99999999)
                throw new Exception("El DNI no es valido!");

            user.DetallesPersona.Apellido = txtApellido.Text.Trim();
            user.DetallesPersona.Nombre = txtNombre.Text.Trim();
            user.DetallesPersona.DNI = dni;
            user.DetallesPersona.FechaNacimiento = dtFechaNacimiento.Value;
            user.DetallesPersona.Direccion = txtDireccion.Text.Trim();
            user.DetallesPersona.Telefono = telefono;
            user.DetallesPersona.Email = txtMail.Text.Trim();
            user.DetallesPersona.TipoDNI = (TipoDoc)cbxTipoDNI.SelectedItem;
            user.DetallesPersona.Sexo = (TipoSexo)cbxSexo.SelectedItem;
            return user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

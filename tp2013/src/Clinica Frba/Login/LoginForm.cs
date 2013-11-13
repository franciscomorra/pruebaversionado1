using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Negocio;
using ClinicaFrba.Comun;
using System.Security.Cryptography;
using System.Configuration;

namespace ClinicaFrba.Login
{
    [NonNavigable]
    public partial class LoginForm : Form
    {
        User user;
        LoginService svc = new LoginService();
        RolesManager rolManager = new RolesManager();
        DetallePersonaManager detallesManager = new DetallePersonaManager();
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login(txtUserName.Text, txtPassword.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void Login(string userName, string pass)
        {
            try
            {
                user = svc.Login(userName, pass);
                var roles = rolManager.GetUserRoles(user.UserID);
                if (roles.Count > 1)
                {
                    comboRoles.DataSource = roles;
                    comboRoles.DisplayMember = "Nombre";
                    panelRoles.Show();
                }
                else
                {
                    if (roles.Count < 1)
                        throw new Exception("El usuario no tiene roles asignados, contacte a un administrativo!");
                    Rol rol = (Rol)roles.ElementAt(0);
                    user.RoleID = rol.ID;
                    user.Perfil = rol.Perfil;
                    svc.SetUserFunctionalities(user);
                    user.DetallePersona = detallesManager.getDetalles(user.UserID);
                    Session.StartSession(user);
                    ViewsManager.LimpiarVistas();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol rolSelected = (Rol)comboRoles.SelectedItem;
            user.RoleID = rolSelected.ID;
            try
            {
                user.Perfil = rolSelected.Perfil;
                svc.SetUserFunctionalities(user);
                Session.StartSession(user);

                if (user.Perfil.Nombre == "Afiliado")
                {
                    var manager = new AfiliadoManager();
                    var usuario = manager.getInfo(user.UserID);
                }
                else if (user.Perfil.Nombre == "Profesional")
                {
                    var manager = new ProfesionalManager();
                    var usuario = manager.getInfo(user.UserID);
                }


                if (user.FaltanDatos)
                { //Aca va lo de actualizacion de datos incompletos
                    MessageBox.Show("Faltan Datos!");
                    //Rehacer con un formulario a parte solo para los datos faltantes
                    //Afiliado: Sexo, Tipo de Documento, Cantidad de Hijos, Estado Civil
                    //Profesional: Matricula
                    var registroForm = new RegistroForm();
                    //registroForm.SetUser(usuario);
                }
                else
                {
                    ViewsManager.LimpiarVistas();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }

    }
}

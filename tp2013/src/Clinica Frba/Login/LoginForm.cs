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
        public LoginForm()
        {
            InitializeComponent();
            //var Config = new ConfigurationManager();
            string conexion = ConfigurationManager.ConnectionStrings["StringConexion"].ToString();


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
            
            user = svc.Login(userName, pass);
            var roles = svc.GetUserRoles(user.UserID);
            if (roles.Count > 1)
            {
                comboRoles.DataSource = roles;
                comboRoles.DisplayMember = "Nombre";
                comboRoles.SelectedIndex = 0;
                panelRoles.Show();
            }
            else
            {
                Rol rol = (Rol)roles.Take(1);
                user.RoleID = rol.ID;
                user.Perfil = rol.Perfil;
                svc.SetUserFunctionalities(user);
                Session.StartSession(user);
                ViewsManager.ClearViews();
            }
        }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol rolSelected = (Rol)comboRoles.SelectedItem;
            user.RoleID = rolSelected.ID;

            user.Perfil = rolSelected.Perfil;
            svc.SetUserFunctionalities(user);
            Session.StartSession(user);

            if (user.Estado == "") { //Aca va lo de actualizacion de datos incompletos
            
            
            }
            ViewsManager.ClearViews();
        }

    }
}

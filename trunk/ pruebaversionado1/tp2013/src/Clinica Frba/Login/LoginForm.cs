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
using System.Security.Cryptography;


namespace ClinicaFrba.Login
{
    [NonNavigable]
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            Login(txtUserName.Text, txtPassword.Text);
        }

        private void Login(string userName, string pass)
        {
            var svc = new LoginService();
            var user = svc.Login(userName, pass);

            //Iniciar sesion con el usuario cargado
            Session.StartSession(user);
            ViewsManager.ClearViews();
        }
    }
}

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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtUserName.Text, txtPassword.Text);
        }

        private void Login(string userName, string pass)
        {
            
            user = svc.Login(userName, pass);
//TERMINAR!
            user.Roles = svc.GetUserRoles(user.UserID);
            
            if (user.Roles.Count > 1)
            {
                foreach (var rol in user.Roles)
                {
                    //comboRoles.Items.Add(descrRol.Nombre.ToString());
                    comboRoles.Items.Insert(rol.ID, rol.Nombre.ToString());
                                       
                }
                comboRoles.Show();
            }
            else {
                //user.RolSeleccionado = user.Roles.First<Rol>();
                //user.RolSeleccionado = (int).user.Roles.First;
                //Setear el primer elemento de la lista
                //Iniciar sesion con el usuario cargado

                Session.StartSession(user);
                ViewsManager.ClearViews();
            }

        }

        private void btnAceptarRol_Click(object sender, EventArgs e)
        {
           MessageBox.Show(comboRoles.SelectedText);
            //comboRoles.SelectedItem 
            //Si se eligio algo en el combo, setear el rol
        }

        private void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //De aca tengo que agarrar el nombre, y sacar la posicion en la lista de roles de usuario
            //Con la posicion, saco el ID, y en la session le cargo las funcionalidades
            Rol rolSelect = user.Roles.ElementAt(comboRoles.SelectedIndex);
            user.RolSeleccionado = rolSelect.ID;             
            svc.SetUserFunctionalities(user);
            Session.StartSession(user);
            ViewsManager.ClearViews();
        }
    }
}

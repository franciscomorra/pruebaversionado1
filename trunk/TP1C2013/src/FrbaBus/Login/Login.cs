using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Business;
using FrbaBus.Common;
using System.Reflection;
using FrbaBus.Login;
using FrbaBus.Core;

namespace FrbaBus.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
           
           if((usuario.Text.Length > 0) && (contrasenia.Text.Length > 0)){ 
           Configuracion.Instancia().usuario = new UsuarioManager().loguearse(usuario.Text, contrasenia.Text);

           if (Configuracion.Instancia().usuario != null)
           {

               if (Configuracion.Instancia().usuario.Estado == 1)
               {
                   MessageBox.Show("Contraseña incorrecta.");
               }
               else if (Configuracion.Instancia().usuario.Estado == 2)
               {
                   MessageBox.Show("Usuario inexistente.");
               }
               else if (Configuracion.Instancia().usuario.Estado == 3)
               {
                   MessageBox.Show("Ha superado el maximo de intentos posibles.");
               }
               else
               {
                   ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
               }
           }
        }


        }
    }
}

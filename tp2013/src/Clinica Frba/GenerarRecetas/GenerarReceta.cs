using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.Login;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.GenerarReceta
{
    [PermissionRequired(Functionalities.GenerarRecetas)]
    public partial class GenerarReceta : Form
    {
        private User _user;
        private ProfesionalesForm _profesionalesForm;
        public GenerarReceta()
        {

            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_profesionalesForm == null)
            {
                _profesionalesForm = new ProfesionalesForm();
                _profesionalesForm.SetSearchMode();
                _profesionalesForm.OnUserSelected += new EventHandler<UserSelectedEventArgs>(clientesForm_OnUserSelected);
            }
            ViewsManager.LoadModal(_profesionalesForm);
        }
        
        void clientesForm_OnUserSelected(object sender, UserSelectedEventArgs e)
        {
            _user = e.User;
            txtProfesional.Text = _user.UserName;
            _profesionalesForm.Hide();
            //rellenarAgendas();
        }

        private void GenerarReceta_Load(object sender, EventArgs e)
        {

        }

    }
}

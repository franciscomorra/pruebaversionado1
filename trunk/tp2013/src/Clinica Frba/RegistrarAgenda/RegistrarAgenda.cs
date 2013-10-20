using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;

namespace ClinicaFrba.RegistrarAgenda
{
    [PermissionRequired(Functionalities.RegistrarAgenda)]
    public partial class RegistrarAgenda : Form
    {
        private int id_profesional;
        public RegistrarAgenda()
        {
            //CARGAR HORARIOS LABORALES EN LAS LISTAS


            if (Session.User.Perfil.Nombre != "Profesional")
            {
                ProfesionalManager manager = new ProfesionalManager();
                var listadoProfesionales = manager.GetAll();
                if (listadoProfesionales.Count > 1)
                {
                    cbxProfesional.DataSource = listadoProfesionales;
                    cbxProfesional.DisplayMember = "Matricula";
                    cbxProfesional.SelectedIndex = 0;
                    panelProfesional.Show();
                }
            }
            else {
                id_profesional = Session.User.UserID;
                //Cargar Agenda!
            }
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           /* if ((dtDesde.Value - dtHasta.Value) < 120 dias )
            {
            }
            */

            //Validar datos y guardar por fecha cambiada
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profesional profSelected = (Profesional)cbxProfesional.SelectedItem;
            this.id_profesional = profSelected.UserID;
            //Cargar Agenda!
        }



    }
}

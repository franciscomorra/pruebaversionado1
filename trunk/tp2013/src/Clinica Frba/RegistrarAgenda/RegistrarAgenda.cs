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

namespace ClinicaFrba.RegistrarAgenda
{
    [PermissionRequired(Functionalities.RegistrarAgenda)]
    public partial class RegistrarAgenda : Form
    {
        private User _user;
        private ProfesionalesForm _profesionalesForm;
        private Agenda _agenda = new Agenda();
        private AgendaManager mgr = new AgendaManager();
        public RegistrarAgenda()
        {
            //CARGAR HORARIOS LABORALES EN LAS LISTAS
            if (Session.User.Perfil.Nombre != "Profesional")
            {
                panelProfesional.Show();
            }
            else
            {
                txtProfesional.Text = Session.User.UserID.ToString();
                panelProfesional.Hide();
            }
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            _agenda.FechaDesde = dtDesde.Value;
            _agenda.FechaHasta = dtHasta.Value;
            //RELLENAR AGENDA LUNES - SABADO
            /*
            if (_agenda.FechaDesde - ) < 120 dias )
            {
            }
            if (calcularCantidadTotalHoras() > 40) { 
            
            }
           */

            //Validar datos y guardar por fecha cambiada
            mgr.GuardarAgenda(_agenda);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_profesionalesForm == null)
            {
                _profesionalesForm = new ProfesionalesForm();
                _profesionalesForm.SetSearchMode();
                _profesionalesForm.OnUserSelected += new EventHandler<UserSelectedEventArgs>(profesionalesForm_OnUserSelected);
            }
            ViewsManager.LoadModal(_profesionalesForm);
        }
        
        void profesionalesForm_OnUserSelected(object sender, UserSelectedEventArgs e)
        {
            _user = e.User;
            txtProfesional.Text = _user.UserName;
            _profesionalesForm.Hide();
            rellenarAgendas();
        }
        private void rellenarAgendas()
        {
            //RELLENAR DIAS DE AGENDAS!
        }
        private int calcularCantidadTotalHoras()
        {
            //VA CAMPO POR CAMPO Y SUMA
            return 0;
        }

    }
}

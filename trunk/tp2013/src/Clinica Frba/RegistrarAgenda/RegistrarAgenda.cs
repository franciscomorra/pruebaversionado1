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
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.RegistrarAgenda
{
    [PermissionRequired(Functionalities.RegistrarAgenda)]
    public partial class RegistrarAgenda : Form
    {
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private Agenda _agenda = new Agenda();
        private AgendaManager mgr = new AgendaManager();
        public RegistrarAgenda()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (dtDesde.Value < dtHasta.Value) {      
            //    throw new Exception("La fecha hasta ser mayor a desde!");
            }

            TimeSpan diferencia  = dtHasta.Value - dtDesde.Value;
            if (diferencia.TotalDays > 120 || diferencia.TotalDays < 1) {
                throw new Exception("Error de fecha!");
            
            }
            _agenda.FechaDesde = dtDesde.Value;
            _agenda.FechaHasta = dtHasta.Value;

            //RELLENAR AGENDA LUNES - SABADO
            /*
            if (calcularCantidadTotalHoras() > 40) { 
            
            }
           */
            mgr.GuardarAgenda(_agenda);
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_profesionalesForm == null)
            {
                _profesionalesForm = new ProfesionalesForm();
                _profesionalesForm.SetSearchMode();
                _profesionalesForm.OnProfesionalSelected += new EventHandler<ProfesionalSelectedEventArgs>(profesionalesForm_OnProfesionalSelected);
            }
            ViewsManager.LoadModal(_profesionalesForm);
        }

        void profesionalesForm_OnProfesionalSelected(object sender, ProfesionalSelectedEventArgs e)
        {
            _profesional = e.Profesional;
            txtProfesional.Text = "Dr. " + _profesional.DetallePersona.Apellido + ", " + _profesional.DetallePersona.Nombre;
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

        private void RegistrarAgenda_Load(object sender, EventArgs e)
        {
            if (Session.User.Perfil.Nombre != "Profesional")
            {
                //panelProfesional.Show();
                panelProfesional.Visible = true;
            }
            else
            {
                txtProfesional.Text = Session.User.UserID.ToString();
                panelProfesional.Hide();
                rellenarAgendas();
            }
            dtDesde.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtHasta.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtDesde.MaxDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(120);
            dtHasta.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(120);
        }

    }
}

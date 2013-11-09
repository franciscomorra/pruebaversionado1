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

            //MessageBox.Show(cbxSabOUT.SelectedItem.ToString());
            //MessageBox.Show(cbxSabIN.SelectedIndex.ToString());
            if (calcularCantidadTotalHoras() > 40) {
                throw new Exception("La carga horaria debe ser menor que 40!!");
            }
           
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
            txtProfesional.Text = _profesional.ToString();
            _profesionalesForm.Hide();
            rellenarAgendas();
        }


        private void rellenarAgendas()
        {
            DateTime time = DateTime.Today;
            for (DateTime _time = time.AddHours(7); _time < time.AddHours(20); _time = _time.AddMinutes(30)) 
            {
                cbxLunesIN.Items.Add(_time.ToShortTimeString());
                cbxLunesOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());
                cbxMartesIN.Items.Add(_time.ToShortTimeString());
                cbxMartesOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());
                cbxMiercIN.Items.Add(_time.ToShortTimeString());
                cbxMiercOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());
                cbxJueIN.Items.Add(_time.ToShortTimeString());
                cbxJueOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());
                cbxViesIN.Items.Add(_time.ToShortTimeString());
                cbxVieOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());
            }
            time = DateTime.Today;
            for (DateTime _time = time.AddHours(10); _time < time.AddHours(15); _time = _time.AddMinutes(30))
            {
                cbxSabIN.Items.Add(_time.ToShortTimeString());
                cbxSabOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());

            }
        }



            //for(hora = 700; hora < 2000; hora)

        private double calcularCantidadTotalHoras()
        {
            double contador = 0;
            if (cbxLunesIN.SelectedIndex >= 0) {
                if(cbxLunesOUT.SelectedIndex <0)
                    throw new Exception("Complete la hora de salida de los lunes!");
                if(cbxLunesOUT.SelectedIndex < cbxLunesIN.SelectedIndex)
                    throw new Exception("Error de hora en los lunes!");
                
                var horaIN =  cbxLunesIN.SelectedItem;
                               MessageBox.Show(horaIN.ToString());
                TimeSpan diferencia = (DateTime)cbxLunesIN.SelectedItem - (DateTime)cbxLunesOUT.SelectedItem;
                if (diferencia.TotalDays > 0)
                {
                    contador = contador + diferencia.TotalHours;
                }
            }


            return contador;
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

            }
            rellenarAgendas();
            dtDesde.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtHasta.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtHasta.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(120);
            dtDesde.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
        }

    }
}

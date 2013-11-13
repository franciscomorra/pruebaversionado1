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

namespace ClinicaFrba.AbmProfesional
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
            try
            {
                if (dtDesde.Value > dtHasta.Value)      
                    throw new Exception("La fecha hasta ser mayor a desde!");
                TimeSpan diferencia  = dtHasta.Value - dtDesde.Value;
                if (diferencia.TotalDays > 120 || diferencia.TotalDays < 1)
                    throw new Exception("Error de fecha!");
                _agenda.FechaDesde = dtDesde.Value;
                _agenda.FechaHasta = dtHasta.Value;
                if (calcularCantidadTotalHoras().TotalHours >= 40)
                    throw new Exception("La carga horaria debe ser menor que 40!!");
                if (cbxLunesIN.SelectedIndex > 0)
                {
                    _agenda.LunesIN = Convert.ToDateTime(cbxLunesIN.SelectedItem);
                    _agenda.LunesOUT = Convert.ToDateTime(cbxLunesOUT.SelectedItem);
                }
                if (cbxMartesIN.SelectedIndex > 0)
                {
                    _agenda.MartesIN = Convert.ToDateTime(cbxMartesIN.SelectedItem);
                    _agenda.MartesOUT = Convert.ToDateTime(cbxMartesOUT.SelectedItem);
                }
                if (cbxMiercIN.SelectedIndex > 0)
                {
                    _agenda.MiercolesIN = Convert.ToDateTime(cbxMiercIN.SelectedItem);
                    _agenda.MiercolesOUT = Convert.ToDateTime(cbxMiercOUT.SelectedItem);
                }
                if (cbxJueIN.SelectedIndex > 0)
                {
                    _agenda.JuevesIN = Convert.ToDateTime(cbxJueIN.SelectedItem);
                    _agenda.JuevesOUT = Convert.ToDateTime(cbxJueOUT.SelectedItem);
                }
                if (cbxViesIN.SelectedIndex > 0)
                {
                    _agenda.ViernesIN = Convert.ToDateTime(cbxViesIN.SelectedItem);
                    _agenda.ViernesOUT = Convert.ToDateTime(cbxVieOUT.SelectedItem);
                }
                if (cbxSabIN.SelectedIndex > 0)
                {
                    _agenda.SabadoIN = Convert.ToDateTime(cbxSabIN.SelectedItem);
                    _agenda.SabadoOUT = Convert.ToDateTime(cbxSabOUT.SelectedItem);
                }

                _agenda.profesional = _profesional;
                mgr.GuardarAgenda(_agenda);
                MessageBox.Show("Se ha guardado la agenda");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_profesionalesForm == null)
            {
                _profesionalesForm = new ProfesionalesForm();
                _profesionalesForm.ModoBusqueda();
                _profesionalesForm.OnProfesionalSelected += new EventHandler<ProfesionalSelectedEventArgs>(profesionalesForm_OnProfesionalSelected);
            }
            ViewsManager.LoadModal(_profesionalesForm);
        }

        void profesionalesForm_OnProfesionalSelected(object sender, ProfesionalSelectedEventArgs e)
        {
            _profesional = e.Profesional;
            txtProfesional.Text = _profesional.ToString();
            _profesionalesForm.Hide();
            rellenarCombos();
            panelAcciones.Visible = true;

        }
        private void rellenarCombos()
        {
            DateTime time = DateTime.Today;
            cbxLunesIN.Items.Clear();
            cbxLunesIN.Items.Add("--");
            cbxLunesIN.SelectedIndex = 0;
            cbxLunesOUT.Items.Clear();
            cbxLunesOUT.Items.Add("--");
            cbxLunesOUT.SelectedIndex = 0;
            cbxMartesIN.Items.Clear();
            cbxMartesIN.Items.Add("--");
            cbxMartesIN.SelectedIndex = 0;
            cbxMartesOUT.Items.Clear();
            cbxMartesOUT.Items.Add("--");
            cbxMartesOUT.SelectedIndex = 0;
            cbxMiercIN.Items.Clear();
            cbxMiercIN.Items.Add("--");
            cbxMiercIN.SelectedIndex = 0;
            cbxMiercOUT.Items.Clear();
            cbxMiercOUT.Items.Add("--");
            cbxMiercOUT.SelectedIndex = 0;
            cbxJueIN.Items.Clear();
            cbxJueIN.Items.Add("--");
            cbxJueIN.SelectedIndex = 0;
            cbxJueOUT.Items.Clear();
            cbxJueOUT.Items.Add("--");
            cbxJueOUT.SelectedIndex = 0;
            cbxViesIN.Items.Clear();
            cbxViesIN.Items.Add("--");
            cbxViesIN.SelectedIndex = 0;
            cbxVieOUT.Items.Clear();
            cbxVieOUT.Items.Add("--");
            cbxVieOUT.SelectedIndex = 0;
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
            cbxSabIN.Items.Clear();
            cbxSabIN.Items.Add("--");
            cbxSabIN.SelectedIndex = 0;
            cbxSabOUT.Items.Clear();
            cbxSabOUT.Items.Add("--");
            cbxSabOUT.SelectedIndex = 0;
            for (DateTime _time = time.AddHours(10); _time < time.AddHours(15); _time = _time.AddMinutes(30))
            {
                cbxSabIN.Items.Add(_time.ToShortTimeString());
                cbxSabOUT.Items.Add(_time.AddMinutes(30).ToShortTimeString());

            }
        }
        private TimeSpan calcularCantidadTotalHoras()
        {
            TimeSpan contador = new TimeSpan();
            TimeSpan diferencia = contador;
            if (cbxLunesIN.SelectedIndex > 0) 
            {
                if(cbxLunesOUT.SelectedIndex <1)
                    throw new Exception("Complete la hora de salida de los lunes!");
                if(cbxLunesOUT.SelectedIndex < cbxLunesIN.SelectedIndex)
                    throw new Exception("Error de hora en los lunes!");
                diferencia = Convert.ToDateTime(cbxLunesOUT.SelectedItem) - Convert.ToDateTime(cbxLunesIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }

            if (cbxMartesIN.SelectedIndex > 0)
            {
                if (cbxMartesOUT.SelectedIndex < 1)
                    throw new Exception("Complete la hora de salida de los Martes!");
                if (cbxMartesOUT.SelectedIndex < cbxMartesIN.SelectedIndex)
                    throw new Exception("Error de hora en los Martes!");
                diferencia = Convert.ToDateTime(cbxMartesOUT.SelectedItem) - Convert.ToDateTime(cbxMartesIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }


            if (cbxMiercIN.SelectedIndex > 0)
            {
                if (cbxMiercOUT.SelectedIndex < 1)
                    throw new Exception("Complete la hora de salida de los Miercoles!");
                if (cbxMiercOUT.SelectedIndex < cbxMiercIN.SelectedIndex)
                    throw new Exception("Error de hora en los Miercoles!");
                diferencia = Convert.ToDateTime(cbxMiercOUT.SelectedItem) - Convert.ToDateTime(cbxMiercIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }

            if (cbxJueIN.SelectedIndex > 0)
            {
                if (cbxJueOUT.SelectedIndex < 1)
                    throw new Exception("Complete la hora de salida de los Jueves!");
                if (cbxJueOUT.SelectedIndex < cbxJueIN.SelectedIndex)
                    throw new Exception("Error de hora en los Jueves!");
                diferencia = Convert.ToDateTime(cbxJueOUT.SelectedItem) - Convert.ToDateTime(cbxJueIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }


            if (cbxViesIN.SelectedIndex > 0)
            {
                if (cbxVieOUT.SelectedIndex < 1)
                    throw new Exception("Complete la hora de salida de los Viernes!!");
                if (cbxVieOUT.SelectedIndex < cbxViesIN.SelectedIndex)
                    throw new Exception("Error de hora en los Viernes!");
                diferencia = Convert.ToDateTime(cbxVieOUT.SelectedItem) - Convert.ToDateTime(cbxViesIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }

            if (cbxSabIN.SelectedIndex > 0)
            {
                if (cbxSabOUT.SelectedIndex < 1)
                    throw new Exception("Complete la hora de salida de los Sabados!");
                if (cbxSabOUT.SelectedIndex < cbxSabIN.SelectedIndex)
                    throw new Exception("Error de hora en los Sabados!");
                diferencia = Convert.ToDateTime(cbxSabOUT.SelectedItem) - Convert.ToDateTime(cbxSabIN.SelectedItem);
                if (diferencia.TotalDays > 0)
                    contador = contador + diferencia;
            }
            return contador;
        }
        private void RegistrarAgenda_Load(object sender, EventArgs e)
        {
            if (Session.User.Perfil.Nombre != "Profesional")
            {
                btnBuscar.Visible = true;
                panelAcciones.Visible = false;
            }
            else
            {
                _profesional = new Profesional();
                _profesional.UserID = Session.User.UserID;
                _profesional.DetallesPersona = Session.User.DetallesPersona;
                txtProfesional.Text = _profesional.ToString();

                btnBuscar.Hide();
                panelAcciones.Visible = true;
            }
            rellenarCombos();
            dtDesde.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtHasta.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtHasta.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(120);
            dtDesde.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
        }

    }
}

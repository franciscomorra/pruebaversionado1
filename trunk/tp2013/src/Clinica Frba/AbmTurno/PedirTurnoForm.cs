using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Login;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;

using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.AbmProfesional;
using System.Configuration;

namespace ClinicaFrba.AbmTurno
{
    [NonNavigable]
    public partial class PedirTurnoForm : Form
    {
        public Afiliado _afiliado = new Afiliado();
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private TurnosManager _turnosManager = new TurnosManager();
        private Turno _turno = new Turno();
        public event EventHandler<TurnoUpdatedEventArgs> OnTurnoUpdated;
        
        public PedirTurnoForm()
        {
            InitializeComponent();
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
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

            panelFecha.Visible = true;
            panelHorario.Visible = false;

        }
        private void dtTurno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            _turno = (Turno)cbxHorarios.SelectedItem;
            _turno.Afiliado = _afiliado;
            
            _turnosManager.SaveTurno(_turno);
            if (OnTurnoUpdated != null)
                OnTurnoUpdated(this, new TurnoUpdatedEventArgs() { Turno = _turno });
            this.Close();
        }

        private void PedirTurnoForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_afiliado == null)
                    throw new Exception("No se cargo el afiliado");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
            panelFecha.Visible = false;
            dtTurno.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtTurno.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dtTurno.MaxDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(120);
            panelHorario.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxHorarios.DataSource = null;
            if (_profesional != null)
            {
                List<Turno> turnos = _turnosManager.GetDiasHorariosLibres(_profesional, dtTurno.Value);
                cbxHorarios.DataSource = turnos;
                if (turnos.Count > 0)
                    panelHorario.Visible = true;
                else
                    MessageBox.Show("No hay horarios disponibles en la fecha!");
            }
        }
    }
}

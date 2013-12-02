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


namespace ClinicaFrba.AbmTurno
{
    [PermissionRequired(Functionalities.CancelarDia)]
    public partial class CancelarDia : Form
    {
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private ProfesionalManager _profesionalManager = new ProfesionalManager();
        private TurnosManager _turnoManager = new TurnosManager();
        public CancelarDia()
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
            _profesionalesForm.Close();
            panelAcciones.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DateTime fecha = dateTimePicker1.Value;
            var sysDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            if (fecha < sysDate)
                MessageBox.Show(" La fecha debe ser mayor a la actual!");
            else
                try
                {
                    List<Turno> turnosDeLaFecha = _turnoManager.BuscarTurnosProfesional(_profesional, fecha);

                    if (MessageBox.Show(string.Format("Usted tiene {0} turnos en la fecha\n Seguro que desea cancelar el dia?", turnosDeLaFecha.Count)
                     , "Cancelar Dia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        _turnoManager.CancelarDiaProfesional(_profesional.UserID, fecha);
                        MessageBox.Show("Dia Cancelado");
                    }
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
        }

        private void CancelarDia_Load(object sender, EventArgs e)
        {
            if (Session.User.Perfil.Nombre == "Profesional")
            {
                _profesional = new Profesional();
                _profesional = Session.Profesional;
                txtProfesional.Text = _profesional.ToString();
                btnBuscarProfesional.Visible = false;
                panelAcciones.Show();
            }
            else
            {
                btnBuscarProfesional.Visible = true;
            }
            dateTimePicker1.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
            dateTimePicker1.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1);
        }
    }
}

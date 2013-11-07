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
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.AbmBono;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.GenerarReceta
{
    [PermissionRequired(Functionalities.GenerarRecetas)]
    public partial class GenerarReceta : Form
    {
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm; 
        //private BonosForm _bonosForm;
        private Bono _bono;

        public GenerarReceta()
        {

            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }

        private void GenerarReceta_Load(object sender, EventArgs e)
        {
            if (Session.User.Perfil.Nombre == "Profesional")
            {
                _profesional = new Profesional() { UserID = Session.User.UserID};
                panelProfesional.Hide();
                panelAcciones.Top = 0;
            }
            else
            {
                panelProfesional.Show();
                panelAcciones.Hide();
            }

        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
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
            panelAcciones.Location = new Point(0, 0);
            panelAcciones.Show();
        }



        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.SetSearchMode();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(_afiliadosForm_OnAfiliadoSelected);            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void _afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _afiliado = e.Afiliado;
            txtAfiliado.Text = _afiliado.DetallePersona.Apellido + ", " + _afiliado.DetallePersona.Nombre;
            _afiliadosForm.Hide();
            panelTurno.Show();
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {

        }

        /*
        private void btnBuscarBonoF_Click(object sender, EventArgs e)
        {
            if (_bonosForm == null)
            {
                _bonosForm = new BonosForm();
                _bonosForm.SetSearchMode();
                _bonosForm.SetFarmaciaOnly();
                _bonosForm.OnBonoSelected += new EventHandler<BonoSelectedEventArgs>(_bonosForm_OnBonoSelected);
            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void _bonosForm_OnBonoSelected(object sender, BonoSelectedEventArgs e)
        {
            _bono = e.Bono;
            txtBono.Text = _bono.Numero.ToString();
            //_afiliadosForm.Hide();
            panelTurno.Show();
        }*/

    }
}

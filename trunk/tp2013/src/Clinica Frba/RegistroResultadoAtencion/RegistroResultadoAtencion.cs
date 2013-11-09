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
using System.Configuration;
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.AbmTurno;
namespace ClinicaFrba.RegistroResultadoAtencion
{
    [PermissionRequired(Functionalities.RegistroResultadoAtencion)]
    public partial class RegistroResultadoAtencion : Form
    {
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        private Turno _turno;
        private TurnosForm _turnosForm;
        
        public RegistroResultadoAtencion()
        {
            InitializeComponent();
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
            txtProfesional.Text = _profesional.ToString();
            _profesionalesForm.Hide();
            //panelAcciones.Location = new Point(0, 0);
            panelAfiliado.Visible = true;
        }



        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.SetSearchMode();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(_afiliadosForm_OnAfiliadoSelected);
            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void _afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _afiliado = e.Afiliado;
            txtAfiliado.Text = _afiliado.DetallePersona.Apellido + ", " + _afiliado.DetallePersona.Nombre;
            _afiliadosForm.Hide();
            panelTurno.Visible = true;
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            if (_turnosForm == null)
            {
                _turnosForm = new TurnosForm();
                _turnosForm.SetSearchMode(_afiliado);
                _turnosForm.OnTurnoselected += new EventHandler<TurnoSelectedEventArgs>(_turnosForm_OnTurnoSelected);
            }
            ViewsManager.LoadModal(_turnosForm);
        }

        void _turnosForm_OnTurnoSelected(object sender, TurnoSelectedEventArgs e)
        {
            _turno = e.Turno;
            txtTurno.Text = _turno.Fecha.ToString();
            _turnosForm.Hide();
            panelAcciones.Visible = true;
        }

        private void btnGenerarReceta_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void RegistroResultadoAtencion_Load(object sender, EventArgs e)
        {
            panelAcciones.Visible = false;
            panelAfiliado.Visible = false;
            panelTurno.Visible = false;
            if (Session.User.Perfil.Nombre == "Profesional") {
                this._profesional = Session.User as Profesional;
                panelProfesional.Visible = false;
                panelAfiliado.Visible = true;
            }else{ 
                panelProfesional.Visible = true;
            }
        }

    }
}

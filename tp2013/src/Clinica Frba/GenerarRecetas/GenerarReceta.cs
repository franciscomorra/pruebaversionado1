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
using ClinicaFrba.AbmTurno;
using ClinicaFrba.AbmBono;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.GenerarReceta
{
   // [PermissionRequired(Functionalities.GenerarRecetas)]
    [NonNavigable]
    public partial class GenerarRecetaForm : Form
    {
        public Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        public Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        public Turno _turno;
        private TurnosForm _turnosForm;
        public Bono _bonoFarmacia;
        private BonosForm _bonosForm;
        public event EventHandler<RecetaUpdatedEventArgs> OnRecetaUpdated;
        public RecetasManager _recetaManager = new RecetasManager();
        private Receta _receta;
        public GenerarRecetaForm()
        {
            InitializeComponent();
        }
        private void GenerarReceta_Load(object sender, EventArgs e)
        {
            if (Session.User.Perfil.Nombre == "Profesional")
            {
                _profesional = new Profesional();
                _profesional.UserID = Session.User.UserID;
                _profesional.DetallePersona = Session.User.DetallePersona;
                txtProfesional.Text = _profesional.ToString();
                btnBuscarProfesional.Hide();
            }
            else
            {
                btnBuscarProfesional.Show();
                panelAcciones.Hide();
            }

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
            panelAcciones.Location = new Point(0, 0);
            panelAcciones.Show();
        }



        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.ModoBusqueda();
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
            if (_turnosForm == null)
            {
                _turnosForm = new TurnosForm();
                _turnosForm.ModoBusqueda(_afiliado);
                _turnosForm.OnTurnoselected += new EventHandler<TurnoSelectedEventArgs>(_turnosForm_OnTurnoSelected);
            }
            ViewsManager.LoadModal(_turnosForm);
        }

        void _turnosForm_OnTurnoSelected(object sender, TurnoSelectedEventArgs e)
        {
            _turno = e.Turno;
            txtTurno.Text = _turno.Fecha.ToString();
            _turnosForm.Hide();
            panelBono.Show();
        }

        private void btnBuscarBonoF_Click(object sender, EventArgs e)
        {
            if (_bonosForm == null)
            {
                _bonosForm = new BonosForm();
                _bonosForm.ModoBusqueda(_afiliado, TipoBono.Farmacia);
                _bonosForm.OnBonoselected += new EventHandler<BonoSelectedEventArgs>(_bonosForm_OnBonoSelected);
            }
            ViewsManager.LoadModal(_bonosForm);
        }

        void _bonosForm_OnBonoSelected(object sender, BonoSelectedEventArgs e)
        {
            _bonoFarmacia = e.Bono;
            txtBono.Text = _bonoFarmacia.Numero.ToString();
            _bonosForm.Hide();
            panelBono.Show();
        }
        private List<Medicamento> getMedicamentos() { 
            List<Medicamento> listado = new List<Medicamento>();

            return listado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _receta = new Receta() { 
                BonoFarmacia = _bonoFarmacia,
                Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]),
                Medicamentos = getMedicamentos()
            };
            _recetaManager.Save(_receta);


            if (OnRecetaUpdated != null)
                OnRecetaUpdated(this, new RecetaUpdatedEventArgs() { Receta = _receta });
            this.Close();


        }

    }
}

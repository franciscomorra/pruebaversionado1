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

namespace ClinicaFrba.Consultas
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
        private RecetasManager _recetaManager = new RecetasManager();
        private Receta _receta;
        private MedicamentosManager _medicamentosManager = new MedicamentosManager();

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
            List<int> cantidadMedicamentos = new List<int>();
            int i = 0;
            for (i = 0; i < 4; i++)
                cantidadMedicamentos.Add(i);

            cbxCant1.DataSource = cantidadMedicamentos;
            cbxCant2.DataSource = cantidadMedicamentos;
            cbxCant3.DataSource = cantidadMedicamentos;
            cbxCant4.DataSource = cantidadMedicamentos;
            cbxCant5.DataSource = cantidadMedicamentos;
            List<Medicamento> medicamentos = new List<Medicamento>();
            Medicamento medVacio = new Medicamento();
            medVacio.Nombre = "--";
            medicamentos.Add(medVacio);
            medicamentos.AddRange(_medicamentosManager.GetAll());
            cbxMed1.DataSource = medicamentos;
            cbxMed2.DataSource = medicamentos;
            cbxMed3.DataSource = medicamentos;
            cbxMed4.DataSource = medicamentos;
            cbxMed5.DataSource = medicamentos;
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
                _turnosForm.SoloTurnosdeHoy();
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
            panelMed1.Show();

        }

        private List<Medicamento> getMedicamentos() { 
            List<Medicamento> listado = new List<Medicamento>();
            int i=0;

            if (cbxMed1.SelectedIndex > 0)
                for (i = 0; i <= (int)cbxCant1.SelectedItem; i++)
                    listado.Add((Medicamento)cbxMed1.SelectedItem);

            if (cbxMed2.SelectedIndex > 0)
                if (listado.Contains((Medicamento)cbxMed2.SelectedItem) && cbxCant2.SelectedIndex>0)
                    throw new Exception("No puede agregar mas medicamentos de ese tipo");
                for (i = 0; i <= (int)cbxCant2.SelectedItem; i++)
                    listado.Add((Medicamento)cbxMed2.SelectedItem);

            if (cbxMed3.SelectedIndex > 0)
                if (listado.Contains((Medicamento)cbxMed3.SelectedItem) && cbxCant3.SelectedIndex > 0)
                    throw new Exception("No puede agregar mas medicamentos de ese tipo");
                for (i = 0; i <= (int)cbxCant3.SelectedItem; i++)
                    listado.Add((Medicamento)cbxMed3.SelectedItem);

            if (cbxMed4.SelectedIndex > 0)
                if (listado.Contains((Medicamento)cbxMed4.SelectedItem) && cbxCant4.SelectedIndex > 0)
                    throw new Exception("No puede agregar mas medicamentos de ese tipo");
                for (i = 0; i <= (int)cbxCant4.SelectedItem; i++)
                    listado.Add((Medicamento)cbxMed4.SelectedItem);

            if (cbxMed5.SelectedIndex > 0)
                if (listado.Contains((Medicamento)cbxMed5.SelectedItem) && cbxCant5.SelectedIndex > 0)
                    throw new Exception("No puede agregar mas medicamentos de ese tipo");
                for (i = 0; i <= (int)cbxCant5.SelectedItem; i++)
                    listado.Add((Medicamento)cbxMed5.SelectedItem);


            return listado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
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
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

    }
}

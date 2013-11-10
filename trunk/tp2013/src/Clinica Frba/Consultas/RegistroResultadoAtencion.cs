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
using ClinicaFrba.Negocio;
using System.Configuration;
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.AbmTurno;

namespace ClinicaFrba.Consultas
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
        private GenerarRecetaForm _recetaForm;    
        private int _contadorRecetas = 0;
        private Consulta _consulta;
        private ConsultasManager _consultasManager = new ConsultasManager();
        private bool _consultaAlmacenada = false;


        public RegistroResultadoAtencion()
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
            //panelAcciones.Location = new Point(0, 0);
            panelAfiliado.Visible = true;
        }



        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.ModoBusqueda();
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
            _turnosForm = new TurnosForm();
            _turnosForm.ModoBusqueda(_afiliado);

            _turnosForm.SoloTurnosdeHoy();
            _turnosForm.OnTurnoselected += new EventHandler<TurnoSelectedEventArgs>(_turnosForm_OnTurnoSelected);
            ViewsManager.LoadModal(_turnosForm);
        }

        void _turnosForm_OnTurnoSelected(object sender, TurnoSelectedEventArgs e)
        {
            _turno = e.Turno;
            txtTurno.Text = _turno.Fecha.ToString();
            _turnosForm.Hide();
            panelAcciones.Visible = true;
        }
        private Consulta rellenarConsulta() { 
            Consulta consulta = new Consulta();
            consulta.Turno = _turno;

            if (string.IsNullOrEmpty(txtSintomas.Text.Trim()))
                throw new Exception("Los sintomas son obligatorios");
            if (string.IsNullOrEmpty(txtDiagnostico.Text.Trim()))
                throw new Exception("El diagnostico es obligatorio!");
            consulta.Enfermedad = txtDiagnostico.Text;
            consulta.Sintomas = txtSintomas.Text;
            return consulta;

        }

        private void btnGenerarReceta_Click(object sender, EventArgs e)
        {

            if (_contadorRecetas <= 5)
            {
                if (!_consultaAlmacenada)
                {
                    _consulta = rellenarConsulta();
                    _consultasManager.Save(_consulta);
                }
            }
            else { 
                throw new Exception("No se pueden agregar mas de cinco recetas");
            }
            _recetaForm = new GenerarRecetaForm();
            _recetaForm._afiliado = _afiliado;
            _recetaForm._profesional = _profesional;
            _recetaForm._turno = _turno;
            _recetaForm.OnRecetaUpdated += new EventHandler<RecetaUpdatedEventArgs>(_recetaForm_OnRecetaUpdated);

        }

        void _recetaForm_OnRecetaUpdated(object sender, RecetaUpdatedEventArgs e)
        {
            _contadorRecetas++;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!_consultaAlmacenada)
            {
                _consulta = rellenarConsulta();
                _consultasManager.Save(_consulta);
            }
            this.Close();


        }

        private void RegistroResultadoAtencion_Load(object sender, EventArgs e)
        {
            panelAcciones.Visible = false;
            panelAfiliado.Visible = false;
            panelTurno.Visible = false;
            if (Session.User.Perfil.Nombre == "Profesional") {
                _profesional = new Profesional();
                _profesional.UserID = Session.User.UserID;
                _profesional.DetallePersona = Session.User.DetallePersona;
                txtProfesional.Text = _profesional.ToString();
                btnBuscarProfesional.Visible = false;
                panelAfiliado.Visible = true;
            }else{
                btnBuscarProfesional.Visible = true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ClinicaFrba.Core;
using ClinicaFrba.Negocio;
using ClinicaFrba.Comun;
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.AbmBono;

namespace ClinicaFrba.AbmTurno
{
    [PermissionRequired(Functionalities.RegistroLlegada)]
    public partial class RegistrarLlegada : Form
    {
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        private Turno _turno;
        private TurnosForm _turnosForm;
        private BonosForm _bonosForm;
        private Bono _bono;
        private TurnosManager _turnosManager = new TurnosManager();
        private bool _registrado = false;
        public RegistrarLlegada()
        {
            _registrado = false;
            InitializeComponent();

        }

        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {

            _afiliadosForm = new AfiliadosForm();
            _afiliadosForm.ModoBusqueda();
            _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(_afiliadosForm_OnAfiliadoSelected);
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void _afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _afiliado = e.Afiliado;
            txtAfiliado.Text = _afiliado.ToString();
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

        private void btnBuscarBonoC_Click(object sender, EventArgs e)
        {
            if (_bonosForm == null)
            {
                _bonosForm = new BonosForm();
                _bonosForm.ModoBusqueda(_afiliado,TipoBono.Consulta);
                _bonosForm.OnBonoselected += new EventHandler<BonoSelectedEventArgs>(_bonosForm_OnBonoSelected);
            }
            ViewsManager.LoadModal(_bonosForm);
        }

        void _bonosForm_OnBonoSelected(object sender, BonoSelectedEventArgs e)
        {
            _bono = e.Bono;
            txtBono.Text = _bono.Numero.ToString();
            _bonosForm.Hide();
            btnRegistrar.Show();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_turno.Fecha > Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddMinutes(15))
                {
                    throw new Exception("El usuario debia registrarse 15 minutos antes!");
                }
                if (_registrado == false)
                {
                    _turnosManager.RegistrarLlegada(_turno, _bono);
                    _registrado = true;
                    MessageBox.Show("Registrado Correctamente!");
                    this.Refresh();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using ClinicaFrba.Core;
namespace ClinicaFrba.Login
{
    public partial class AfiliadoUserControl : UserControl
    {
        private Afiliado _afiliado = new Afiliado();
        public Afiliado _conyuge = new Afiliado();
        public Afiliado _padre = new Afiliado();
        public int _nroAfiliado;
        public bool esNuevoUsuario = false;

        public Afiliado devolverCampos()
        {
            int cantHijos;
            if (!int.TryParse(txtHijos.Text, out cantHijos))
                throw new Exception("La cantidad de hijos debe ser numérica!");
            if (string.IsNullOrEmpty(txtMotivo.Text.Trim()))
                throw new Exception("El Motivo es obligatorio!"); 
            _afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil),cbxEstadoCivil.SelectedItem.ToString());
            _afiliado.PlanMedico = (PlanMedico)cbxPlanMedico.SelectedItem;
            _afiliado.CantHijos = cantHijos;
            _afiliado.MotivoCambio = txtMotivo.Text.Trim();
            return _afiliado;
        }

        public void rellenarCampos(Afiliado afiliado)
        {
            _afiliado = afiliado;
            cbxPlanMedico.SelectedItem = afiliado.PlanMedico;
            cbxEstadoCivil.SelectedItem = afiliado.EstadoCivil;
            txtHijos.Text = afiliado.CantHijos.ToString();
            if (_conyuge.UserID!=0) { //Cargando marido/esposa del afiliado principal
                txtConyuge.Text = _conyuge.ToString();
                panelFamiliar.Visible = false;
                txtHijos.Text = _afiliado.CantHijos.ToString();
                txtHijos.Enabled = false;
                cbxEstadoCivil.SelectedItem = _afiliado.EstadoCivil;
                cbxEstadoCivil.Enabled = false;
                _afiliado.grupoFamiliar = _conyuge.grupoFamiliar;
                _afiliado.tipoAfiliado = 2;
            }
            else if (_padre.UserID != 0)//Carga de hijos
            {
                txtPadre.Text = _padre.ToString();
                panelPadre.Visible = false;
                txtHijos.Text = "0";
                txtHijos.Enabled = false;
                cbxEstadoCivil.SelectedItem = EstadoCivil.Soltero;
                cbxEstadoCivil.Enabled = false;
                _afiliado.NroAfiliado = _nroAfiliado;
            }
            else {//Es padre
                panelPadre.Visible = false;
                panelConyuge.Visible = false;
            }
            if (esNuevoUsuario)
            {
                txtMotivo.Text = "Alta";
                txtMotivo.Enabled = false;
            }
        }

        public AfiliadoUserControl()
        {
            InitializeComponent();
            //_afiliado = new Afiliado();
            var manager = new PlanesMedicosManager();
            var planesMedicos = manager.GetAll();
            cbxPlanMedico.DisplayMember = "Name";
            planesMedicos.ForEach(x => cbxPlanMedico.Items.Add(x));
            cbxPlanMedico.SelectedIndex = 0;
            var items = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();
            items.ForEach(x => cbxEstadoCivil.Items.Add(x));
            cbxEstadoCivil.DisplayMember = "Name";
            cbxPlanMedico.SelectedIndex = 0;

        }

    }
}

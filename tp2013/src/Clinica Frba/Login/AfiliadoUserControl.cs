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
        private Afiliado _afiliado;
        public long _grupoFamiliar;
        public int _tipoAfiliado;
        public bool esNuevoUsuario = false;

        public Afiliado devolverCampos()
        {
            int cantHijos;  
            try
            {
                if (!int.TryParse(txtHijos.Text, out cantHijos))
                    throw new Exception("La cantidad de hijos debe ser numérica!");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return null;
            } 
            _afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), cbxEstadoCivil.SelectedItem.ToString());
            _afiliado.PlanMedico = (PlanMedico)cbxPlanMedico.SelectedItem;
            _afiliado.CantHijos = cantHijos;
            return _afiliado;
        }

        public void rellenarAfiliado(Afiliado afiliado)
        {
            _afiliado = afiliado;
            cbxPlanMedico.SelectedItem = afiliado.PlanMedico;
            cbxEstadoCivil.SelectedItem = afiliado.EstadoCivil;
            txtHijos.Text = afiliado.CantHijos.ToString();
            if (_afiliado.tipoAfiliado==2) { //Cargando marido/esposa del afiliado principal

                panelFamiliar.Visible = false;
                txtHijos.Text = _afiliado.CantHijos.ToString();
                txtHijos.Enabled = false;
                cbxEstadoCivil.SelectedItem = _afiliado.EstadoCivil;
                cbxEstadoCivil.Enabled = false;
                _afiliado.tipoAfiliado = 2;
                _tipoAfiliado = 2;
                cbxEstadoCivil.Enabled = false;
            }
            else if (_afiliado.tipoAfiliado>2)//Carga de hijos
            {
                panelFamiliar.Visible = false;
                txtHijos.Text = "0";
                txtHijos.Enabled = false;
                txtHijos.Visible = false;
                cbxEstadoCivil.SelectedItem = EstadoCivil.Soltero;
                cbxEstadoCivil.Enabled = false;
                cbxEstadoCivil.Visible = false;
                _afiliado.grupoFamiliar = _grupoFamiliar;
            }
            else {//Es padre
                panelFamiliar.Visible = true;
                cbxEstadoCivil.Enabled = true;
                cbxEstadoCivil.Visible = true;
                txtHijos.Enabled = true;
                txtHijos.Visible = true;
            }
        }

        public AfiliadoUserControl()
        {
            InitializeComponent();
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

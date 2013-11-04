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

namespace ClinicaFrba.Login
{
    public partial class AfiliadoUserControl : UserControl
    {
        private Afiliado _afiliado;

        public Afiliado GetAfiliado()
        {
            int CantHijos = 0;
           
            if (string.IsNullOrEmpty(txtMotivo.Text.Trim()))
                throw new Exception("El Motivo es obligatorio!"); 
            _afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil),cbxEstadoCivil.SelectedItem.ToString());
            _afiliado.PlanMedico = (PlanMedico)cbxPlanMedico.SelectedItem;
            _afiliado.CantHijos = CantHijos;
            _afiliado.MotivoCambio = txtMotivo.Text.Trim();
            return _afiliado;
        }

        public void SetUser(Afiliado afiliado)
        {
            _afiliado = afiliado;
            
            
            cbxPlanMedico.SelectedItem = afiliado.PlanMedico;
            cbxEstadoCivil.SelectedItem = afiliado.EstadoCivil;
            txtHijos.Text = afiliado.CantHijos.ToString();

            if (afiliado.NroAfiliado != 0) {
                panelMotivo.Show();            
            }

            

        }

        public AfiliadoUserControl()
        {
            InitializeComponent();
            _afiliado = new Afiliado();
            //Rellenar Sexo
            var manager = new PlanesMedicosManager();
            var planesMedicos = manager.GetAll();
            cbxPlanMedico.DisplayMember = "Name";
            planesMedicos.ForEach(x => cbxPlanMedico.Items.Add(x));
            cbxPlanMedico.SelectedIndex = 0;

            var items = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();
            items.ForEach(x => cbxEstadoCivil.Items.Add(x));
            cbxEstadoCivil.DisplayMember = "Name";
            cbxPlanMedico.SelectedIndex = 0;

            RolesManager rman = new RolesManager();

            Profile perfilMasc = new Profile() { Nombre = "Afiliado" };
            var roles = rman.GetRolesByPerfil(perfilMasc);
            if (roles.Count > 1)
            {
                cbxRoles.DataSource = roles;
                cbxRoles.DisplayMember = "Nombre";
                cbxRoles.SelectedIndex = 0;
            }


        }

        private void AfiliadoUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}

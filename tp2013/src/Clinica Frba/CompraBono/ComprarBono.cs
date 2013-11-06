using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.AbmAfiliado;
//using ClinicaFrba.Login;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.CompraBono
{
    [PermissionRequired(Functionalities.ComprarBonos)]
    public partial class ComprarBono : Form
    {
        private User _user;
        private AfiliadosForm _afiliadosForm;
        private AfiliadoManager _afiliadoMan = new AfiliadoManager();
        private Afiliado afiliado;
        public ComprarBono()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.SetSearchMode();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(afiliadosForm_OnAfiliadoSelected);
            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _user = e.Afiliado;
            txtAfiliado.Text = _user.DetallePersona.Apellido+", " + _user.DetallePersona.Nombre;
            _afiliadosForm.Hide();
            rellenarPrecios();
            panelCompra.Show();
        }
        private void rellenarPrecios()
        { 
            
            afiliado = _afiliadoMan.getInfo(_user.UserID);
            lblprecioConsulta.Text = afiliado.PlanMedico.PrecioConsulta.ToString();
            lblprecioFarmacia.Text = afiliado.PlanMedico.PrecioFarmacia.ToString();
            lblTotal.Text = "0";
            for (int i = 0; i <= 10; i++)
            {
                cbxCantConsulta.Items.Add(i);
                cbxCantConsulta.SelectedIndex = 0;
                cbxCantFarmacia.Items.Add(i);
                cbxCantFarmacia.SelectedIndex = 0;
            }
        
        }

        private void ComprarBono_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.User.Perfil.Nombre != "Afiliado")
                {
                    panelCompra.Hide();
                    panelAfiliado.Show();
                }
                else
                {
                    txtAfiliado.Text = Session.User.UserID.ToString();
                    panelAfiliado.Hide();
                    rellenarPrecios();
                    panelCompra.Show();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void cbxCantConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalConsulta = cbxCantConsulta.SelectedIndex * afiliado.PlanMedico.PrecioConsulta;
            int totalFarmacia = cbxCantFarmacia.SelectedIndex * afiliado.PlanMedico.PrecioFarmacia;
            int total = totalConsulta + totalFarmacia;
            lblTotal.Text = total.ToString();
        }


    }
}


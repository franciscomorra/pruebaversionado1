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
using ClinicaFrba.Login;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.CompraBono
{
    [PermissionRequired(Functionalities.CompraBono)]
    public partial class ComprarBono : Form
    {
        private User _user;
        private AfiliadosForm _afiliadosForm;
        private AfiliadoManager _afiliadoMan = new AfiliadoManager();
        private Afiliado afiliado;
        public ComprarBono()
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
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.SetSearchMode();
                _afiliadosForm.OnUserSelected += new EventHandler<UserSelectedEventArgs>(afiliadosForm_OnUserSelected);
            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void afiliadosForm_OnUserSelected(object sender, UserSelectedEventArgs e)
        {
            _user = e.User;
            txtAfiliado.Text = _user.UserName;
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
        
        }
    }
}


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
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using System.Configuration;

namespace ClinicaFrba.AbmBono
{
    [NonNavigable]
    public partial class ComprarBonoForm : Form
    {
        private AfiliadosForm _afiliadosForm;
        private AfiliadoManager _afiliadoManager = new AfiliadoManager();
        public Afiliado _afiliado;
        private BonosManager _bonoManager = new BonosManager();

        public event EventHandler<BonoUpdatedEventArgs> OnBonosUpdated;

        public ComprarBonoForm()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.ModoBusqueda();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(afiliadosForm_OnAfiliadoSelected);
            
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _afiliado = e.Afiliado;
            txtAfiliado.Text = e.Afiliado.ToString() ;
            _afiliadosForm.Hide();
            rellenarPrecios();
            panelCompra.Show();
        }
        private void rellenarPrecios()
        { 
            try
            {
                _afiliado = _afiliadoManager.actualizarInformacion(_afiliado.UserID);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            lblprecioConsulta.Text = _afiliado.PlanMedico.PrecioConsulta.ToString();
            lblprecioFarmacia.Text = _afiliado.PlanMedico.PrecioFarmacia.ToString();
            lblTotal.Text = "0";
            cbxCantConsulta.Items.Clear();
            cbxCantFarmacia.Items.Clear();
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
                if (Session.User.Perfil.Nombre != "Afiliado" && _afiliado == null)
                {
                    panelCompra.Hide();
                    panelAfiliado.Show();
                }
                else
                {
                    if(_afiliado == null)
                        _afiliado = Session.Afiliado;
                    txtAfiliado.Text = _afiliado.ToString();
                    btnBuscar.Visible = false;
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
            int totalConsulta = cbxCantConsulta.SelectedIndex * _afiliado.PlanMedico.PrecioConsulta;
            int totalFarmacia = cbxCantFarmacia.SelectedIndex * _afiliado.PlanMedico.PrecioFarmacia;
            int total = totalConsulta + totalFarmacia;
            lblTotal.Text = total.ToString();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroCompra;
                if (cbxCantConsulta.SelectedIndex > 0 || cbxCantFarmacia.SelectedIndex > 0)
                    numeroCompra = _bonoManager.Nueva_Compra(_afiliado);
                else
                    return;
                int i = 0;
                int j = 0;
                if (cbxCantConsulta.SelectedIndex > 0)
                {
                    for (i = 0; i < cbxCantConsulta.SelectedIndex; i++)
                    {
                        Bono bono = new Bono();
                        bono.Compra = numeroCompra;
                        bono.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
                        bono.AfiliadoCompro = _afiliado;
                        bono.Precio = _afiliado.PlanMedico.PrecioConsulta;
                        bono.TipodeBono = TipoBono.Consulta;
                        _bonoManager.Comprar(bono);
                    }
                }
                if (cbxCantFarmacia.SelectedIndex > 0)
                {
                    for (j = 0; j < cbxCantFarmacia.SelectedIndex; j++)
                    {
                        Bono bono = new Bono();
                        bono.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
                        bono.Compra = numeroCompra;
                        bono.AfiliadoCompro = _afiliado;
                        bono.Precio = _afiliado.PlanMedico.PrecioFarmacia;
                        bono.TipodeBono = TipoBono.Farmacia;
                        _bonoManager.Comprar(bono);
                    }
                }
                MessageBox.Show(string.Format("Se han comprado {0} bonos consulta y {1} bonos farmacia",i,j));
                if (OnBonosUpdated != null)
                    OnBonosUpdated(this, new BonoUpdatedEventArgs());
                this.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
    }
}


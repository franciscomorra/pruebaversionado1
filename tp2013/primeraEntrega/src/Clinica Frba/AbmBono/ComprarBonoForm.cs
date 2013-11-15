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
    [PermissionRequired(Functionalities.ComprarBonos)]
    public partial class ComprarBonoForm : Form
    {

        private AfiliadosForm _afiliadosForm;
        private Afiliado _afiliado;
        private AfiliadoManager _afiliadoMan = new AfiliadoManager();
        public Afiliado afiliado;
        private BonosManager _bonoManager = new BonosManager();

        public event EventHandler<BonoUpdatedEventArgs> OnBonosUpdated;

        public ComprarBonoForm()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.ModoBusqueda();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(afiliadosForm_OnAfiliadoSelected);
            }
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
                afiliado = _afiliadoMan.getInfo(_afiliado.UserID);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            lblprecioConsulta.Text = afiliado.PlanMedico.PrecioConsulta.ToString();
            lblprecioFarmacia.Text = afiliado.PlanMedico.PrecioFarmacia.ToString();
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
                if (Session.User.Perfil.Nombre != "Afiliado")
                {
                    panelCompra.Hide();
                    panelAfiliado.Show();
                }
                else
                {
                    AfiliadoManager manager = new AfiliadoManager();
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
            int totalConsulta = cbxCantConsulta.SelectedIndex * afiliado.PlanMedico.PrecioConsulta;
            int totalFarmacia = cbxCantFarmacia.SelectedIndex * afiliado.PlanMedico.PrecioFarmacia;
            int total = totalConsulta + totalFarmacia;
            lblTotal.Text = total.ToString();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                List<Bono> bonos = new List<Bono>();
                if (cbxCantConsulta.SelectedIndex > 0)
                {
                    for (i = 0; i < cbxCantConsulta.SelectedIndex; i++)
                    {
                        Bono bono = new Bono();
                        bono.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
                        bono.AfiliadoCompro = afiliado;
                        bono.Precio = afiliado.PlanMedico.PrecioConsulta;
                        bono.TipodeBono = TipoBono.Consulta;
                        int numeroBono = _bonoManager.Comprar(bono);
                        bonos.Add(bono);
                    }
                }
                if (cbxCantFarmacia.SelectedIndex > 0)
                {
                    for (i = 0; i < cbxCantFarmacia.SelectedIndex; i++)
                    {
                        Bono bono = new Bono();
                        bono.Fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
                        bono.AfiliadoCompro = afiliado;
                        bono.Precio = afiliado.PlanMedico.PrecioFarmacia;
                        bono.TipodeBono = TipoBono.Farmacia;
                        int numeroBono = _bonoManager.Comprar(bono);
                        bonos.Add(bono);
                    }
                }
                string mensaje = "Se han asignado los siguientes bonos: \n";
                foreach(Bono bono in bonos)
                {
                    mensaje = mensaje +" " +bono.Numero.ToString()+ " \n";
                }
                MessageBox.Show(mensaje);
                
                if (OnBonosUpdated != null)
                    OnBonosUpdated(this, new BonoUpdatedEventArgs() { Bonos = bonos});
                
                
                this.Close();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }


    }
}


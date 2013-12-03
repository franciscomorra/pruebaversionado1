using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Login;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;
using ClinicaFrba.AbmAfiliado;
using System.Configuration;


namespace ClinicaFrba.AbmBono
{
    [PermissionRequired(Functionalities.ComprarBonos)]
    public partial class BonosForm : Form
    {
        private bool _isSearchMode = false;
        public event EventHandler<BonoSelectedEventArgs> OnBonoselected;
        private Bono bono = new Bono();
        private BonosManager _bonosManager = new BonosManager();
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        bool _soloReceta = false;
        bool _soloConsulta = false;

        public BonosForm()
        {
            InitializeComponent();
        }
        public void ModoBusqueda(Afiliado afiliado, TipoBono tipo)
        {
            _afiliado = afiliado;
            buttonsPanel.Visible = false;
            btnBuscarAfiliado.Visible = false;
            txtAfiliado.Text = _afiliado.ToString();
            _isSearchMode = true;
            if (tipo == TipoBono.Farmacia)
            {
                _soloReceta = true;            }
            else if (tipo == TipoBono.Consulta)
            {
                _soloConsulta = true;
            }
            else {
                _soloReceta = false;
                _soloConsulta = false;
            }
        }
        private void RefrescarDatagrid() {

            var bonos = _bonosManager.GetAll(_afiliado);
            if (_soloConsulta)
                bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Consulta).ToList());
            else if (_soloReceta)
                bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Farmacia).ToList());
            dgvBonos.DataSource = bonos;
            dgvBonos.AutoGenerateColumns = false;
        }
        private void BonosForm_Load(object sender, EventArgs e)
        {
            btnBuscarAfiliado.Visible = true;
            buttonsPanel.Visible = false;
            dgvBonos.Visible = false;
            if (Session.User.Perfil.Nombre == "Afiliado" || _afiliado != null)
            {
                if (_afiliado == null)
                {
                    _afiliado = Session.Afiliado;
                    txtAfiliado.Text = _afiliado.ToString();
                    btnBuscarAfiliado.Visible = false;
                }
                RefrescarDatagrid();
                dgvBonos.DoubleClick += new EventHandler(dgvBonos_CellContentDoubleClick);
                dgvBonos.Visible = true;
                buttonsPanel.Visible = true;
            }

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
            RefrescarDatagrid();
            dgvBonos.Visible = true;
            buttonsPanel.Visible = true;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_afiliado == null)
                    throw new Exception("Error de afiliado!");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
            var addBonoForm = new ComprarBonoForm();
            addBonoForm._afiliado = _afiliado;
            addBonoForm.OnBonosUpdated += new EventHandler<BonoUpdatedEventArgs>(pedirBonoOnBonoUpdated);
            ViewsManager.LoadModal(addBonoForm);
        }

        void pedirBonoOnBonoUpdated(object sender, BonoUpdatedEventArgs e)
        {
            try
            {
                RefrescarDatagrid();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void dgvBonos_CellContentDoubleClick(object sender, EventArgs e)
        {
            if (_isSearchMode)
            {
                if (dgvBonos.SelectedRows == null || dgvBonos.SelectedRows.Count == 0) return;
                var row = dgvBonos.SelectedRows[0];
                var bono = row.DataBoundItem as Bono;
                if (OnBonoselected != null)
                    OnBonoselected(this, new BonoSelectedEventArgs(){Bono = bono});
                this.Close();
            }
        }


    }
}

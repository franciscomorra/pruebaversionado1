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
    [NonNavigable]
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

        private void BonosForm_Load(object sender, EventArgs e)
        {
            btnBuscarAfiliado.Visible = true;
            if (Session.User.Perfil.Nombre == "Afiliado" || _afiliado != null)
            {
                if (_afiliado == null)
                {
                    _afiliado = Session.User as Afiliado;
                    txtAfiliado.Text = _afiliado.ToString();
                    btnBuscarAfiliado.Visible = false;
                }
                var bonos = _bonosManager.GetAll(_afiliado);
                if (_soloConsulta)
                    bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Consulta).ToList());
                else if (_soloReceta)
                    bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Farmacia).ToList());
                dgvBonos.DataSource = bonos;
                dgvBonos.AutoGenerateColumns = false;
                dgvBonos.DoubleClick += new EventHandler(dgvBonos_CellContentDoubleClick);
            }

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
            txtAfiliado.Text = _afiliado.ToString();
            _afiliadosForm.Hide();
            var bonos = _bonosManager.GetAll(_afiliado);
            if (_soloConsulta)
                bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Consulta).ToList());
            else if(_soloReceta)
                bonos = new List<Bono>(bonos.Where(x => x.TipodeBono == TipoBono.Farmacia).ToList());
            dgvBonos.DataSource = bonos;

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var addBonoForm = new ComprarBonoForm();
            addBonoForm.afiliado = _afiliado;
            addBonoForm.OnBonosUpdated += new EventHandler<BonoUpdatedEventArgs>(pedirBonoOnBonoUpdated);
            ViewsManager.LoadModal(addBonoForm);
        }

        void pedirBonoOnBonoUpdated(object sender, BonoUpdatedEventArgs e)
        {
            try
            {
                var dataSource = dgvBonos.DataSource as BindingList<Bono>;
                foreach(var bono in e.Bonos){
                    dataSource.Add(bono);     
                }

                dgvBonos.Refresh();
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
                {
                    OnBonoselected(this, new BonoSelectedEventArgs()
                    {
                        Bono = bono
                    });
                }
                this.Close();
            }
        }









    }
}

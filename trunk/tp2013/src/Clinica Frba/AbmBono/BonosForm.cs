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
        private BonosManager _bonosManager = new BonosManager();
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;

        public BonosForm()
        {
            InitializeComponent();
        }
        public void SetSearchMode()
        {
            buttonsPanel.Visible = false;
            _isSearchMode = true;
        }

        private void BonosForm_Load(object sender, EventArgs e)
        {
            var dataSource = _bonosManager.GetAll(_afiliado.UserID);
            dgvBonos.DataSourceChanged += new EventHandler(dgvBonos_DataSourceChanged);
            dgvBonos.DataSource = dataSource;
        }

        private void dgvBonos_DataSourceChanged(object sender, EventArgs e)
        {
            var dataSource = dgvBonos.DataSource as BindingList<Bono>;
            lblResults.Text = dataSource.Count.ToString();
        }

        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            if (_afiliadosForm == null)
            {
                _afiliadosForm = new AfiliadosForm();
                _afiliadosForm.SetSearchMode();
                _afiliadosForm.OnAfiliadoSelected += new EventHandler<AfiliadoSelectedEventArgs>(_afiliadosForm_OnAfiliadoSelected);
            }
            ViewsManager.LoadModal(_afiliadosForm);
        }

        void _afiliadosForm_OnAfiliadoSelected(object sender, AfiliadoSelectedEventArgs e)
        {
            _afiliado = e.Afiliado;
            txtAfiliado.Text = _afiliado.DetallePersona.Apellido + ", " + _afiliado.DetallePersona.Nombre;
            _afiliadosForm.Hide();

        }

    }
}

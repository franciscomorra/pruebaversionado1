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


namespace ClinicaFrba.AbmTurno
{
    [PermissionRequired(Functionalities.AdministrarTurnos)]
    public partial class TurnosForm : Form
    {
        private bool _isSearchMode = false;
        private TurnosManager _turnosManager = new TurnosManager();
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;

        public TurnosForm()
        {
            InitializeComponent();
        }
        public void SetSearchMode()
        {
            buttonsPanel.Visible = false;
            _isSearchMode = true;
        }

        private void TurnosForm_Load(object sender, EventArgs e)
        {
            var dataSource = _turnosManager.GetAll(_afiliado.UserID);
            dgvTurnos.DataSourceChanged += new EventHandler(dgvTurnos_DataSourceChanged);
            dgvTurnos.DataSource = dataSource;
        }

        private void dgvTurnos_DataSourceChanged(object sender, EventArgs e)
        {
            var dataSource = dgvTurnos.DataSource as BindingList<Turno>;
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

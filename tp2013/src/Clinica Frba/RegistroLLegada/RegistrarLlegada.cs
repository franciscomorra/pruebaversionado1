using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Comun;
using ClinicaFrba.AbmAfiliado;


namespace ClinicaFrba.RegistroLlegada
{
    [PermissionRequired(Functionalities.RegistroLlegada)]
    public partial class RegistrarLlegada : Form
    {
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        public RegistrarLlegada()
        {
            InitializeComponent();
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
            panelTurno.Show();
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarBonoC_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}

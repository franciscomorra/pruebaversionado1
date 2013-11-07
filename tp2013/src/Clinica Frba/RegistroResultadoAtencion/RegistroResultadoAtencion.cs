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
using System.Configuration;
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.AbmAfiliado;

namespace ClinicaFrba.RegistroResultadoAtencion
{
    [PermissionRequired(Functionalities.RegistroResultadoAtencion)]
    public partial class RegistroResultadoAtencion : Form
    {
        private Profesional _profesional;
        private ProfesionalesForm _profesionalesForm;
        private Afiliado _afiliado;
        private AfiliadosForm _afiliadosForm;
        
        public RegistroResultadoAtencion()
        {
            InitializeComponent();
        }

        private void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            if (_profesionalesForm == null)
            {
                _profesionalesForm = new ProfesionalesForm();
                _profesionalesForm.SetSearchMode();
                _profesionalesForm.OnProfesionalSelected += new EventHandler<ProfesionalSelectedEventArgs>(profesionalesForm_OnProfesionalSelected);
            }
            ViewsManager.LoadModal(_profesionalesForm);
        }
        void profesionalesForm_OnProfesionalSelected(object sender, ProfesionalSelectedEventArgs e)
        {
            _profesional = e.Profesional;
            txtProfesional.Text = "Dr. " + _profesional.DetallePersona.Apellido + ", " + _profesional.DetallePersona.Nombre;
            _profesionalesForm.Hide();
            //panelAcciones.Location = new Point(0, 0);
            panelAcciones.Show();
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


        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarReceta_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

    }
}

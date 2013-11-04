using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;

namespace ClinicaFrba.Login
{
    public partial class ProfesionalUserControl : UserControl
    {
        private Profesional _profesional;
        public Profesional GetProfesional()
        {

            if (clbEspecialidades.SelectedItems == null) {
                throw new Exception("Debe elegir al menos Una especialidad"); 
                //PROBAR!!!!
            }
            if (string.IsNullOrEmpty(txtMatricula.Text.Trim()))
                throw new Exception("La Matricula es obligatoria!");

            _profesional.Matricula = txtMatricula.Text.Trim();
            /* HACER ESTO; COMO ES??
            _profesional.Especialidades = clbEspecialidades.SelectedItems;
            clbEspecialidades.ForEach(x => _profesional.Especialidades.Add(x))
            */
            return _profesional;
        }

        public void SetUser(Profesional profesional)
        {
            _profesional = profesional;
            //SELECCIONAR LAS ESPECIALIDADES DEL PROFESIONAL
            var especialidadesManager = new EspecialidadesManager();
            List<Especialidad> especialidadesProfesional = especialidadesManager.GetAllForUser(profesional.UserID);
            //clbEspecialidades.SelectedIndices = especialidadesProfesional;
        }

        public ProfesionalUserControl()
        {
            InitializeComponent();
            _profesional = new Profesional();
            var manager = new EspecialidadesManager();
            var especialidades = manager.GetAll();
            especialidades.ForEach(x => clbEspecialidades.Items.Add(x, false));

            clbEspecialidades.DisplayMember = "Name";

            RolesManager rman = new RolesManager();
            Profile perfilMasc = new Profile() { Nombre = "Profesional" };
            var roles = rman.GetRolesByPerfil(perfilMasc);
            if (roles.Count > 1)
            {
                cbxRoles.DataSource = roles;
                cbxRoles.DisplayMember = "Nombre";
                cbxRoles.SelectedIndex = 0;
            }
        }

        private void ProfesionalUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}

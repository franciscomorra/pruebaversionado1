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
            long telefono = 0;
            long dni = 0;
            if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                throw new Exception("El teléfono debe ser numérico!");
            if (!long.TryParse(txtDNI.Text, out dni))
                throw new Exception("El DNI debe ser numérico!");
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                throw new Exception("El Nombre es obligatorio!");
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                throw new Exception("El Apellido es obligatorio!"); 
            if (string.IsNullOrEmpty(txtMail.Text.Trim()))
                throw new Exception("El Email es obligatorio!");

            _profesional.DetallePersona.Apellido = txtApellido.Text.Trim();
            _profesional.DetallePersona.Nombre = txtNombre.Text.Trim();
            _profesional.DetallePersona.DNI = dni;
            _profesional.DetallePersona.FechaNacimiento = dtFechaNacimiento.Value;
            _profesional.DetallePersona.Direccion = txtDireccion.Text.Trim();
            _profesional.DetallePersona.Telefono = telefono;
            _profesional.DetallePersona.Email = txtMail.Text.Trim();
            _profesional.Matricula = txtMatricula.Text.Trim();
            return _profesional;
        }

        public void SetUser(Profesional profesional)
        {
            _profesional = profesional;
            txtApellido.Text = profesional.DetallePersona.Apellido.Trim();
            txtNombre.Text = profesional.DetallePersona.Nombre.Trim();
            txtDNI.Text = profesional.DetallePersona.DNI.ToString();
            dtFechaNacimiento.Value = profesional.DetallePersona.FechaNacimiento;
            txtDireccion.Text = profesional.DetallePersona.Direccion.Trim();
            txtTelefono.Text = profesional.DetallePersona.Telefono.ToString();
            txtMail.Text = profesional.DetallePersona.Email.Trim();

        }

        public ProfesionalUserControl()
        {
            InitializeComponent();
            _profesional = new Profesional();
            var manager = new EspecialidadesManager();
            var especialidades = manager.GetAll();
            clbEspecialidades.DisplayMember = "Name";
            especialidades.ForEach(x => clbEspecialidades.Items.Add(x, false));
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

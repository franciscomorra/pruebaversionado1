using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Negocio;
using ClinicaFrba.Comun;

namespace ClinicaFrba.Login
{
    public partial class ProfesionalUserControl : UserControl
    {
        private Profesional _profesional;

        public ProfesionalUserControl()
        {
            InitializeComponent();
            _profesional = new Profesional();
            /*
            var especialidadesManager = new EspecialidadesManager();
            var especialidades = especialidadesManager.GetAll();
            var rubrosManager = new RubrosManager();
            
            cbxRubro.DataSource = rubrosManager.GetAll();
            cbxRubro.DisplayMember = "Name";
            cbxRubro.SelectedIndex = 0;
            cbxEspecialidad.DataSource = especialidades;
            cbxEspecialidad.DisplayMember = "Name";
            cbxEspecialidad.SelectedIndex = 0;
            */
        }

        public Profesional GetProfesional()
        {
            long telefono = 0;
            if (!long.TryParse(txtTelefono.Text, out telefono))
                throw new Exception("El teléfono debe ser numérico!");
            if (string.IsNullOrEmpty(txtCUIT.Text.Trim()))
                throw new Exception("El CUIT es obligatorio!");
            if (string.IsNullOrEmpty(txtMatricula.Text.Trim()))
                throw new Exception("La Razón Social es obligatoria!");
            _profesional.CUIT = txtCUIT.Text.Trim();
            _profesional.NombreContacto = txtContacto.Text.Trim();
            _profesional.Matricula = txtMatricula.Text.Trim();
            //_profesional.Rubro = (Rubro)cbxRubro.SelectedItem;
            _profesional.Especialidad = (Especialidad)cbxEspecialidad.SelectedItem;
                
            _profesional.DetalleEntidad = new DetalleEntidad()
            {
                Email = txtMail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = telefono
            };

            return _profesional;
        }

        public void SetUser(Profesional profesional)
        {
            _profesional = profesional;
            txtContacto.Text = profesional.NombreContacto.Trim();
            txtCUIT.Text = profesional.CUIT.Trim();
            txtMatricula.Text = profesional.Matricula.Trim();
            txtCP.Text = profesional.DetalleEntidad.CP.Trim();
            txtDireccion.Text = profesional.DetalleEntidad.Direccion.Trim();
            txtTelefono.Text = profesional.DetalleEntidad.Telefono.ToString();
            txtMail.Text = profesional.DetalleEntidad.Email.Trim();
            cbxEspecialidad.SelectedItem = profesional.DetalleEntidad.Especialidad;
            cbxRubro.SelectedItem = profesional.Rubro;
        }

        private void ProfesionalUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Comun;
namespace ClinicaFrba.Login
{
    public partial class DetallesPersonaUserControl : UserControl
    {
        private DetallesPersona _detalles;
        public DetallesPersonaUserControl()
        {
            InitializeComponent();
            cbxSexo.DataSource = Enum.GetValues(typeof(TipoSexo)).Cast<TipoSexo>().ToList();
            cbxTipoDNI.DataSource = Enum.GetValues(typeof(TipoDoc)).Cast<TipoDoc>().ToList();
        }
        public DetallesPersona GetDetalles(){
            long telefono = 0;
            long dni = 0;
            User user = new User();

            if (string.IsNullOrEmpty(txtUsername.Text))
                throw new Exception("El nombre de usuario es obligatorio!");
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

            user.DetallePersona.Apellido = txtApellido.Text.Trim();
            user.DetallePersona.Nombre = txtNombre.Text.Trim();
            user.DetallePersona.DNI = dni;
            user.DetallePersona.FechaNacimiento = dtFechaNacimiento.Value;
            user.DetallePersona.Direccion = txtDireccion.Text.Trim();
            user.DetallePersona.Telefono = telefono;
            user.DetallePersona.Email = txtMail.Text.Trim();


            return _detalles;
        }
        public DetallesPersona SetDetalles(User user) {

            txtUsername.Text = user.UserName.Trim();
            //Inicio detalles de persona
            txtApellido.Text = user.DetallePersona.Apellido.Trim();
            txtNombre.Text = user.DetallePersona.Nombre.Trim();
            txtDNI.Text = user.DetallePersona.DNI.ToString();
            cbxSexo.SelectedItem = user.DetallePersona.Sexo;
            dtFechaNacimiento.Value = user.DetallePersona.FechaNacimiento;
            txtDireccion.Text = user.DetallePersona.Direccion.Trim();
            txtTelefono.Text = user.DetallePersona.Telefono.ToString();
            txtMail.Text = user.DetallePersona.Email.Trim();
            //Fin detalles de persona
            return _detalles;
        }

        private void DetallesPersonaUserControl_Load(object sender, EventArgs e)
        {
        }
    }
}

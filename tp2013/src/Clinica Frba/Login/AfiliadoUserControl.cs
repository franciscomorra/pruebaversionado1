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
    public partial class AfiliadoUserControl : UserControl
    {
        private Afiliado _afiliado;

        public Afiliado GetAfiliado()
        {
            long telefono = 0;
            long dni = 0;
            int CantHijos = 0;
            if (!long.TryParse(txtTelefono.Text.Trim().Replace("-", ""), out telefono))
                throw new Exception("El teléfono debe ser numérico!");
            if (!long.TryParse(txtDNI.Text, out dni))
                throw new Exception("El DNI debe ser numérico!");
            if (!int.TryParse(txtHijos.Text, out CantHijos))
                throw new Exception("Cantidad de hijos debe ser numérico!");

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                throw new Exception("El Nombre es obligatorio!");
            if (string.IsNullOrEmpty(txtMotivo.Text.Trim()))
                throw new Exception("El Motivo es obligatorio!");
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                throw new Exception("El Apellido es obligatorio!");

            _afiliado.DetallePersona.Apellido = txtApellido.Text.Trim();
            _afiliado.DetallePersona.Nombre = txtNombre.Text.Trim();
            //_afiliado.DetallePersona.Sexo = (Sexo)cbxSexo.SelectedItem();
            _afiliado.DetallePersona.DNI = dni;
            _afiliado.DetallePersona.FechaNacimiento = dtFechaNacimiento.Value;
            _afiliado.DetallePersona.Direccion = txtDireccion.Text.Trim();
            _afiliado.DetallePersona.Telefono = telefono;
            _afiliado.DetallePersona.Email = txtMail.Text.Trim();
           // EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString()),
                        
            _afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil),cbxEstadoCivil.SelectedItem.ToString());
            _afiliado.PlanMedico = (PlanMedico)cbxPlanMedico.SelectedItem;
            _afiliado.CantHijos = CantHijos;
            _afiliado.MotivoCambio = txtMotivo.Text.Trim();
            return _afiliado;
        }

        public void SetUser(Afiliado afiliado)
        {
            _afiliado = afiliado;
            txtApellido.Text = afiliado.DetallePersona.Apellido.Trim();
            txtNombre.Text = afiliado.DetallePersona.Nombre.Trim();
            txtDNI.Text = afiliado.DetallePersona.DNI.ToString();
            //cbxSexo.SelectedItem = afiliado.DetallePersona.sexo.toString();
            dtFechaNacimiento.Value = afiliado.DetallePersona.FechaNacimiento;
            txtDireccion.Text = afiliado.DetallePersona.Direccion.Trim();
            txtTelefono.Text = afiliado.DetallePersona.Telefono.ToString();
            txtMail.Text = afiliado.DetallePersona.Email.Trim();
            
            cbxPlanMedico.SelectedItem = afiliado.PlanMedico;
            cbxEstadoCivil.SelectedItem = afiliado.EstadoCivil;
            txtHijos.Text = afiliado.CantHijos.ToString();

            if (afiliado.NroAfiliado != 0) {
                panelMotivo.Show();            
            }

            

        }

        public AfiliadoUserControl()
        {
            InitializeComponent();
            _afiliado = new Afiliado();
            //Rellenar Sexo
            var manager = new PlanesMedicosManager();
            var planesMedicos = manager.GetAll();
            cbxPlanMedico.DisplayMember = "Name";
            planesMedicos.ForEach(x => cbxPlanMedico.Items.Add(x));
            cbxPlanMedico.SelectedIndex = 0;
            cbxSexo.Items.Add("Masculino");
            cbxSexo.Items.Add("Femenino");
            var items = Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();
            items.ForEach(x => cbxEstadoCivil.Items.Add(x));
            cbxEstadoCivil.DisplayMember = "Name";
            cbxPlanMedico.SelectedIndex = 0;

            RolesManager rman = new RolesManager();
            Profile perfilMasc = new Profile() { Nombre = "Afiliado" };
            var roles = rman.GetRolesByPerfil(perfilMasc);
            if (roles.Count > 1)
            {
                cbxRoles.DataSource = roles;
                cbxRoles.DisplayMember = "Nombre";
                cbxRoles.SelectedIndex = 0;
            }


        }

        private void AfiliadoUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}

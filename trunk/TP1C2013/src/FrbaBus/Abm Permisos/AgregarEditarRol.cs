using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Business;
using FrbaBus.Common;
using FrbaBus.Abm_Permisos;
using FrbaBus.Core;

namespace FrbaBus
{
    public partial class AgregarEditarRol : Form
    {
        public AgregarEditarRol() : this(new Rol()) { }

        public AgregarEditarRol(Rol rol)
        {
            InitializeComponent();
            this.Rol = rol;
        }

        public event EventHandler<RolQueSePasa> OnRoleUpdated;

        private Rol Rol { get; set; }

        private void AgregarEditarRol_Load(object sender, EventArgs e)
        {
            ProcessForm();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void ProcessForm()
        {
            var manager = new FuncionalidadManager();
            var funcionalidades = manager.GetAll();
            foreach (var funcionalidad in funcionalidades)
            {
                listaDeFuncionalidades.Items.Add(funcionalidad.NOMBRE, RolTieneLaFuncionalidad(funcionalidad));
                txtNombre.Text = Rol.NOMBRE;
            }
        }

        private bool RolTieneLaFuncionalidad(Funcionalidad funcionalidad)
        {
            if (Rol == null || Rol.Funcionalidades == null) return false;
            return Rol.Funcionalidades.Exists(unaFuncionalidad => unaFuncionalidad.NOMBRE == funcionalidad.NOMBRE);
        }

     
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("El nombre del Rol no puede ser nulo");
                return;
            }

            Rol.Funcionalidades = new List<Funcionalidad>();
            foreach (string nombreFuncionalidad in listaDeFuncionalidades.CheckedItems)
            {
                Funcionalidad aux = new Funcionalidad();
                aux.NOMBRE = nombreFuncionalidad;
                Rol.Funcionalidades.Add(aux);
                
            }
            Rol.NOMBRE = txtNombre.Text;

            if (OnRoleUpdated != null)
                OnRoleUpdated(this, new RolQueSePasa() { Rol = this.Rol });
            this.Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

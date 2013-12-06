using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Comun;
using ClinicaFrba.Core;
using ClinicaFrba.Negocio;
using System.Collections;

namespace ClinicaFrba.AbmRol
{
    [PermissionRequired(Functionalities.AdministrarRoles)]
    public partial class RolesForm : Form
    {
        private RolesManager rolesManager = new RolesManager();

        public RolesForm()
        {
            InitializeComponent();
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            var bindingSource = new BindingSource();
            var rolesTable = rolesManager.BuscarTodos();
            rolesDataGridView.DataSourceChanged += new EventHandler(rolesDataGridView_DataSourceChanged);
            rolesDataGridView.AutoGenerateColumns = false;
            rolesDataGridView.DataSource = rolesTable;
        }

        void rolesDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            var dataSource = rolesDataGridView.DataSource as IList;
            lblResults.Text = dataSource.Count.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var addEditForm = new AddEditRoleForm();
            addEditForm.OnRoleUpdated += new EventHandler<RoleUpdatedEventArgs>(addEditForm_OnRoleUpdated);
            ViewsManager.LoadModal(addEditForm);
        }

        void addEditForm_OnRoleUpdated(object sender, RoleUpdatedEventArgs e)
        {
            try
            {
                var dataSource = rolesDataGridView.DataSource as BindingList<Rol>;
                if (e.Rol.ID == 0)
                {
                    if (dataSource.Where(x => x.Nombre.Trim().ToUpperInvariant() == e.Rol.Nombre.Trim().ToUpperInvariant()).Count() >= 1)
                    {
                        MessageBox.Show("Ya hay un rol con ese nombre, ingrese uno nuevo");
                        return;
                    }
                }

                var manager = new RolesManager();
                manager.SaveRole(e.Rol);
                MessageBox.Show(string.Format("Rol {0} guardado correctamente", e.Rol.Nombre));

                if (dataSource.Contains(e.Rol)) dataSource.Remove(e.Rol);
                dataSource.Add(e.Rol);
                rolesDataGridView.Refresh();
                lblResults.Text = dataSource.Count.ToString();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rolesDataGridView.SelectedRows == null || rolesDataGridView.SelectedRows.Count == 0) return;
            var row = rolesDataGridView.SelectedRows[0];
            var rol = row.DataBoundItem as Rol;
            if (MessageBox.Show(string.Format("Confirma que desea eliminar el rol {0}?", rol.Nombre)
                , "Eliminar rol", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    rolesManager.BorrarRol(rol);
                    var dataSource = rolesDataGridView.DataSource as BindingList<Rol>;
                    dataSource.Remove(rol);
                    rolesDataGridView.Refresh();
                    lblResults.Text = dataSource.Count.ToString();
                    MessageBox.Show(string.Format("Rol {0} eliminado", rol.Nombre));

                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rolesDataGridView.SelectedRows == null || rolesDataGridView.SelectedRows.Count == 0) return;
                var row = rolesDataGridView.SelectedRows[0];
                var rol = row.DataBoundItem as Rol;
                //Que no se puedan borrar los roles por defecto!
                if(rol.Nombre == "Administrador" || rol.Nombre == "Afiliado" || rol.Nombre == "Profesional" || rol.Nombre == "Administrativo")
                    throw new Exception("No se puede editar el rol "+rol.ToString()+" debido a una regla de negocio");
                var addEditForm = new AddEditRoleForm();
                addEditForm.Set(rol);
                addEditForm.OnRoleUpdated += new EventHandler<RoleUpdatedEventArgs>(addEditForm_OnRoleUpdated);
                ViewsManager.LoadModal(addEditForm);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                return;
            }
        }
    }
}

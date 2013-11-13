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

using FrbaBus.Core;

namespace FrbaBus.Abm_Permisos
{
    public partial class PermisosForm : Form
    {

        private RolManager _permisosManager = new RolManager();



        public PermisosForm()
        {
            InitializeComponent();
        }

        private void PermisosForm_Load(object sender, EventArgs e)
        {
            var dataSource = _permisosManager.GetAll();
            datagvPermisos.DataSource = dataSource;
            datagvPermisos.Columns["Modificar"].DisplayIndex = 4;
            datagvPermisos.Columns["Eliminar"].DisplayIndex = 4;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var agregarEditarRol = new AgregarEditarRol();
            agregarEditarRol.OnRoleUpdated += new EventHandler<RolQueSePasa>(agregarEditarRol_OnRoleUpdated);
            agregarEditarRol.ShowDialog();
            //ViewsManager.LoadModal(agregarEditarRol); TODO
        }

        void agregarEditarRol_OnRoleUpdated(object sender, RolQueSePasa e)
        {
            try
            {
                var dataSource = datagvPermisos.DataSource as BindingList<Rol>;
                if (e.Rol.ID == 0)
                {
                    if (dataSource.Where(x => x.NOMBRE.Trim().ToUpperInvariant() == e.Rol.NOMBRE.Trim().ToUpperInvariant()).Count() >= 1)
                    {
                        MessageBox.Show("El nombre ya esta en uno de los roles, ingrese otro.");
                        return;
                    }
                }
                var manager = new RolManager();
                manager.SalvarRol(e.Rol);
                MessageBox.Show(string.Format("Se guardo correctamente el rol {0}.", e.Rol.NOMBRE));


                if (dataSource.Contains(e.Rol))
                {
                    int aux = dataSource.IndexOf(e.Rol);
                    dataSource.Remove(e.Rol);
                    dataSource.Insert(aux, e.Rol);
                }
                else
                {
                    dataSource.Add(e.Rol);
                }
                datagvPermisos.Refresh();
            }
            catch
            {
                MessageBox.Show("No se pudo guardar el rol.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (datagvPermisos.SelectedRows == null || datagvPermisos.SelectedRows.Count == 0) return;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {


            if (datagvPermisos.SelectedRows == null || datagvPermisos.SelectedRows.Count == 0) return;
            var row = datagvPermisos.SelectedRows[0];
            var rol = row.DataBoundItem as Rol;
            /*if (rol.ID == Session.DefaultRoleID)
            {
                MessageBox.Show("Rol no editable");
                return;
            }*/
            var agregarEditarRol = new AgregarEditarRol(rol);
            agregarEditarRol.OnRoleUpdated += new EventHandler<RolQueSePasa>(agregarEditarRol_OnRoleUpdated);
            agregarEditarRol.ShowDialog();
            //ViewsManager.LoadModal(addEditForm);


        }

        private void datagvPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                var dataSource = datagvPermisos.DataSource as BindingList<Rol>;
                var rol = dataSource[e.RowIndex];

                if (e.ColumnIndex == 0)
                {
                    var agregarEditarRol = new AgregarEditarRol(rol);
                    agregarEditarRol.OnRoleUpdated += new EventHandler<RolQueSePasa>(agregarEditarRol_OnRoleUpdated);
                    agregarEditarRol.ShowDialog();
                }
                else
                {
                    //if (rol.ID == Session.DefaultRoleID)
                    //{
                    //  MessageBox.Show("Rol no editable");
                    //  return;
                    //} TODO poder borrar su propio ROLL
                    if (rol.BAJA_LOGICA)
                    {
                        if (MessageBox.Show(string.Format("Desea habilitar el rol {0}?", rol.NOMBRE)
                            , "Habilitar rol", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            _permisosManager.habilitarRol(rol);


                            int auxIndex = e.RowIndex;
                            dataSource.Remove(rol);
                            rol.BAJA_LOGICA = false;
                            dataSource.Insert(auxIndex, rol);
                            datagvPermisos.Refresh();
                            MessageBox.Show(string.Format("Rol {0} fue habilitado", rol.NOMBRE));

                        }
                    }
                    else
                    {

                        if (MessageBox.Show(string.Format("Desea deshabilitar el rol {0}?", rol.NOMBRE)
                            , "Eliminar rol", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            try
                            {
                                _permisosManager.BorrarRol(rol);

                                int auxIndex = e.RowIndex;
                                dataSource.Remove(rol);
                                rol.BAJA_LOGICA = true;
                                dataSource.Insert(auxIndex, rol);
                                datagvPermisos.Refresh();
                                MessageBox.Show(string.Format("Rol {0} fue deshabilitado", rol.NOMBRE));
                            }
                            catch
                            {
                                MessageBox.Show("Error al eliminar el rol");
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    }
}


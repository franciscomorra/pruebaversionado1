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
using ClinicaFrba.Negocio;
using ClinicaFrba.AbmAfiliado;
using ClinicaFrba.Login;

namespace ClinicaFrba.AbmAfiliado
{
    [PermissionRequired(Functionalities.AdministrarAfiliados)]
    public partial class AfiliadosForm : Form
    {
        private AfiliadoManager _afiliadoManager = new AfiliadoManager();
        private bool _isSearchMode = false;
        public event EventHandler<AfiliadoSelectedEventArgs> OnAfiliadoSelected;

        public AfiliadosForm()
        {
            InitializeComponent();
        }
        public void ModoBusqueda() //Usado para cuando se busca a un usuario
        {
            buttonsPanel.Visible = false;
            _isSearchMode = true;
        }

        private void AfiliadosForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = _afiliadoManager.GetAll();
                if (_isSearchMode)
                {
                    dataSource.Remove(new Afiliado() { UserID = Session.User.UserID });
                }
                dgvAfiliados.AutoGenerateColumns = false;
                dgvAfiliados.DataSourceChanged += new EventHandler(dgvAfiliados_DataSourceChanged);
                dataSource.Remove(new Afiliado() { UserID = Session.User.UserID});
                dgvAfiliados.DataSource = dataSource;
                dgvAfiliados.DoubleClick += new EventHandler(dgvAfiliados_DoubleClick);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        void dgvAfiliados_DataSourceChanged(object sender, EventArgs e)
        {
            var dataSource = dgvAfiliados.DataSource as BindingList<Afiliado>;
            lblResults.Text = dataSource.Count.ToString();
        }

        void dgvAfiliados_DoubleClick(object sender, EventArgs e) //Seleccion de afiliado, para otros forms
        {
            if (dgvAfiliados.SelectedRows == null || dgvAfiliados.SelectedRows.Count == 0) return;
            var row = dgvAfiliados.SelectedRows[0];
            var afiliado = row.DataBoundItem as Afiliado;
            if (OnAfiliadoSelected != null)
            {
                OnAfiliadoSelected(this, new AfiliadoSelectedEventArgs()
                {
                    Afiliado = afiliado
                });
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) //Eliminando afiliado
        {
            if (dgvAfiliados.SelectedRows == null || dgvAfiliados.SelectedRows.Count == 0) return;
            var row = dgvAfiliados.SelectedRows[0];
            var afiliado = row.DataBoundItem as Afiliado;
            if (MessageBox.Show(string.Format("Confirma que desea eliminar al afiliado {0} {1}?", afiliado.DetallePersona.Nombre.Trim(), afiliado.DetallePersona.Apellido.Trim())
                , "Eliminar afiliado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _afiliadoManager.Delete(afiliado);
                    var dataSource = dgvAfiliados.DataSource as BindingList<Afiliado>;
                    dataSource.Remove(afiliado);
                    dgvAfiliados.Refresh();
                    MessageBox.Show(string.Format("Afiliado {0} {1} eliminado", afiliado.DetallePersona.Nombre.Trim(), afiliado.DetallePersona.Apellido.Trim()));
                    
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }/*
                catch
                {
                    MessageBox.Show("Error al eliminar el afiliado");
                }*/
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) //Modificando afiliado existente
        {
           try{
               if (dgvAfiliados.SelectedRows == null || dgvAfiliados.SelectedRows.Count == 0) return;
               var row = dgvAfiliados.SelectedRows[0];
               var afiliado = row.DataBoundItem as Afiliado;
               var regForm = new RegistroForm();
               regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
               regForm.SetUser(afiliado);

               ViewsManager.LoadModal(regForm);

               /*
               if (dgvAfiliados.SelectedRows == null || dgvAfiliados.SelectedRows.Count == 0) return;
               var row = dgvAfiliados.SelectedRows[0];
               var afiliado = row.DataBoundItem as Afiliado;
               var afliadoModificarForm = new AddEditAfiliadoForm();
               afliadoModificarForm.OnAfiliadoSaved += new EventHandler<AfiliadoSavedEventArgs>(afiliadosForm_OnAfiliadoSaved);
               //afliadoModificarForm.SetAfiliado(afiliado);
               ViewsManager.LoadModal(afliadoModificarForm);
                **/
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        void regForm_OnUserSaved(object sender, UserSavedEventArgs e)
        {
            var dataSource = dgvAfiliados.DataSource as BindingList<Afiliado>;
            var afiliado = e.User as Afiliado;
            if (dataSource.Contains(afiliado)) dataSource.Remove(afiliado);
            dataSource.Add(afiliado);
            dgvAfiliados.DataSource = new BindingList<Afiliado>(dataSource.OrderBy(x => x.DetallePersona.Apellido + x.DetallePersona.Nombre).ToList());
            dgvAfiliados.Refresh();
            MessageBox.Show("Se han guardado los datos del Afiliado " + e.Username);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var regForm = new RegistroForm();
            
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            Profile _perfil = new Profile(){ Nombre = "Afiliado"};

            regForm.Profile = _perfil;
            ViewsManager.LoadModal(regForm);
        }
        /*
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var afiliadoAgregarForm = new AddEditAfiliadoForm(); //HACER!
            afiliadoAgregarForm.OnAfiliadoSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            ViewsManager.LoadModal(afiliadoAgregarForm);
        }
        */
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAfiliadoNro.Text = string.Empty;
            dgvAfiliados.DataSource = _afiliadoManager.GetAll();
            dgvAfiliados.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            long nroAfiliado = 0;
            if (!string.IsNullOrEmpty(txtAfiliadoNro.Text) && !long.TryParse(txtAfiliadoNro.Text, out nroAfiliado))
            {
                MessageBox.Show("El Nro de Afiliado debe ser numérico");
                return;
            }
            var afiliados = _afiliadoManager.GetAll();
            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallePersona.Apellido.ToLowerInvariant().Contains(txtApellido.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallePersona.Nombre.ToLowerInvariant().Contains(txtNombre.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallePersona.Email.ToLowerInvariant().Contains(txtEmail.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtAfiliadoNro.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.NroAfiliado == nroAfiliado).ToList());
            }
            afiliados.Remove(new Afiliado() { UserID = Session.User.UserID });
            dgvAfiliados.DataSource = new BindingList<Afiliado>(afiliados.OrderBy(x => x.DetallePersona.Apellido + x.DetallePersona.Nombre).ToList());
            dgvAfiliados.Refresh();
        }
    }
}

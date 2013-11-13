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
            if (MessageBox.Show(string.Format("Confirma que desea eliminar al afiliado {0} {1}?", afiliado.DetallesPersona.Nombre.Trim(), afiliado.DetallesPersona.Apellido.Trim())
                , "Eliminar afiliado", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _afiliadoManager.Delete(afiliado);
                    var dataSource = dgvAfiliados.DataSource as BindingList<Afiliado>;
                    dataSource.Remove(afiliado);
                    dgvAfiliados.Refresh();
                    MessageBox.Show(string.Format("Afiliado {0} {1} eliminado", afiliado.DetallesPersona.Nombre.Trim(), afiliado.DetallesPersona.Apellido.Trim()));
                    
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
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
               regForm.rellenarAfiliado(afiliado);
               ViewsManager.LoadModal(regForm);
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
            dgvAfiliados.DataSource = new BindingList<Afiliado>(dataSource.OrderBy(x => x.DetallesPersona.Apellido + x.DetallesPersona.Nombre).ToList());
            dgvAfiliados.Refresh();
            MessageBox.Show("Se han guardado los datos del Afiliado " + e.Username);



            if (tieneGenteACargo(afiliado))
            {
                var grupoFamiliar = _afiliadoManager.GetAllFromGrupoFamiliar(afiliado.grupoFamiliar);

                if (!todosLosIntegrantesCargados(afiliado))
                { 
                
                }
            
            }
        }
        private bool todosLosIntegrantesCargados(Afiliado afiliado)
        {
            return true;
        }
        private bool tieneGenteACargo(Afiliado afiliado)
        {
            var integrantes_grupoFamiliar = _afiliadoManager.GetAll();
            integrantes_grupoFamiliar = new BindingList<Afiliado>(integrantes_grupoFamiliar.Where(x => x.grupoFamiliar == afiliado.grupoFamiliar).ToList());
            //Filtro los que tengan el mismo grupo familiar que el que guardo
            if (integrantes_grupoFamiliar.Count > 0) { 
            //Hay mas gente en el grupo familiar
                if (afiliado.EstadoCivil == EstadoCivil.Casado || afiliado.EstadoCivil == EstadoCivil.Concubinato)
                    //Pregunto por los estados civiles que significan pareja a cargo
                    return true;

            
            }
            return false;
        }


        private void btnAgregar_Click(object sender, EventArgs e) //Nuevo Afiliado
        {
            var regForm = new RegistroForm(); //Registro para usuarios
            
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            Perfil _perfil = new Perfil(){ Nombre = "Afiliado"};

            regForm.perfil = _perfil;
            
            ViewsManager.LoadModal(regForm);

        }
        private void btnLimpiar_Click(object sender, EventArgs e) //Limpiar Filtros
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAfiliadoNro.Text = string.Empty;
            dgvAfiliados.DataSource = _afiliadoManager.GetAll();
            dgvAfiliados.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e) //Filtros
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
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallesPersona.Apellido.ToLowerInvariant().Contains(txtApellido.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallesPersona.Nombre.ToLowerInvariant().Contains(txtNombre.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.DetallesPersona.Email.ToLowerInvariant().Contains(txtEmail.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtAfiliadoNro.Text))
            {
                afiliados = new BindingList<Afiliado>(afiliados.Where(x => x.NroAfiliado == nroAfiliado).ToList());
            }
            afiliados.Remove(new Afiliado() { UserID = Session.User.UserID });
            dgvAfiliados.DataSource = new BindingList<Afiliado>(afiliados.OrderBy(x => x.DetallesPersona.Apellido + x.DetallesPersona.Nombre).ToList());
            dgvAfiliados.Refresh();
        }
    }
}

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
                var dataSource = _afiliadoManager.buscarTodos();
                if (_isSearchMode)
                    dataSource.Remove(Session.Afiliado);
                dgvAfiliados.AutoGenerateColumns = false;
                dgvAfiliados.DataSourceChanged += new EventHandler(dgvAfiliados_DataSourceChanged);
                dataSource.Remove(Session.Afiliado);
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
                    var dataSource = _afiliadoManager.buscarTodos();
                    dgvAfiliados.DataSource = dataSource;
                    dgvAfiliados.Refresh();
                    MessageBox.Show(string.Format("Afiliado {0} {1} eliminado", afiliado.DetallesPersona.Nombre.Trim(), afiliado.DetallesPersona.Apellido.Trim()));
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    return;
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e) //Nuevo Afiliado
        {
            var regForm = new RegistroForm(); //Registro para usuarios
            regForm.esNuevoUsuario = true;
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            regForm.perfilSeleccionado = "Afiliado";
            ViewsManager.LoadModal(regForm);
        }
        private void btnModificar_Click(object sender, EventArgs e) //Modificando afiliado existente
        {
           if (dgvAfiliados.SelectedRows == null || dgvAfiliados.SelectedRows.Count == 0) return;
           var row = dgvAfiliados.SelectedRows[0];
           var afiliado = row.DataBoundItem as Afiliado;
           var regForm = new RegistroForm();
           regForm.esNuevoUsuario = false;
           regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
           regForm.perfilSeleccionado = "Afiliado";
           regForm.rellenarAfiliado(afiliado);
           ViewsManager.LoadModal(regForm);
        }

        void regForm_OnUserSaved(object sender, UserSavedEventArgs e)
        {

            var dataSource = _afiliadoManager.buscarTodos();
            dgvAfiliados.DataSource = dataSource;
            dgvAfiliados.Refresh();
            MessageBox.Show("Se han guardado los datos del Afiliado " + e.User.ToString());
            Afiliado afiliado = _afiliadoManager.actualizarInformacion(e.User.UserID);
            verificar_Familiares(afiliado);
        }
        void regForm_OnConyugeSaved(object sender, UserSavedEventArgs e)
        {
            var afiliado = e.User as Afiliado;
            MessageBox.Show("Se han guardado los datos del Afiliado " + e.User.ToString());
            //verificar_Familiares(afiliado);
        }
        void regForm_OnHijoSaved(object sender, UserSavedEventArgs e)
        {
            MessageBox.Show("Se han guardado los datos del Afiliado " + e.User.ToString());
        }
        private void verificar_Familiares(Afiliado afiliado){

            if (afiliado.tipoAfiliado == 1 || afiliado.tipoAfiliado == 2)//Afiliado Principal
            {
                var familia = _afiliadoManager.GetAllFromGrupoFamiliar(afiliado.grupoFamiliar);
                int miembrosSegunRegistro = 1; //El afiliado principal
                miembrosSegunRegistro = miembrosSegunRegistro + afiliado.CantHijos; //Sumo cantidad de hijos
                if (_afiliadoManager.correspondeConyuge(afiliado))//Sumo Conyuge
                    miembrosSegunRegistro++;
                if (familia.Count < miembrosSegunRegistro)
                {
                    if (_afiliadoManager.correspondeConyuge(afiliado) && !_afiliadoManager.conyugeFueCargado(familia))
                    {
                        if (MessageBox.Show(string.Format("Desea agregar a su conyuge?"), "Agregar Conyuge", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            var regForm = new RegistroForm();
                            Afiliado conyuge = _afiliadoManager.RellenarDatosConyuge(afiliado);
                            regForm.esNuevoUsuario = true;
                            regForm.perfilSeleccionado = "Afiliado";
                            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnConyugeSaved);
                            regForm.rellenarAfiliado(conyuge);
                            ViewsManager.LoadModal(regForm);
                        }
                    }
                    BindingList<Afiliado> hijosEnSistema = new BindingList<Afiliado>(familia.Where(x => (x.grupoFamiliar == afiliado.grupoFamiliar && x.tipoAfiliado > 2)).ToList());
                    int cantidadHijosFaltantes = afiliado.CantHijos - hijosEnSistema.Count;//Los que ingreso en el campo menos los que estan ya cargados
                    for (int i = hijosEnSistema.Count; i < cantidadHijosFaltantes + hijosEnSistema.Count; i++)//Verificar el for
                    {
                        if (MessageBox.Show(string.Format(("Se registro que tiene {1} hijos, pero en el sistema hay {0} hijos cargados, desea cargarlos?"), i, afiliado.CantHijos), "Agregar Hijos", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            var regForm = new RegistroForm();
                            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnHijoSaved);
                            Afiliado hijo = _afiliadoManager.RellenarDatosHijo(afiliado);
                            regForm.perfilSeleccionado = "Afiliado";
                            regForm.rellenarAfiliado(hijo);
                            regForm.esNuevoUsuario = true;
                            ViewsManager.LoadModal(regForm);
                        }
                    }
                }
                var dataSource = _afiliadoManager.buscarTodos();
                dgvAfiliados.DataSource = dataSource;
                dgvAfiliados.Refresh();
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e) //Limpiar Filtros
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAfiliadoNro.Text = string.Empty;
            var dataSource = _afiliadoManager.buscarTodos();
            dgvAfiliados.DataSource = dataSource;
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
            var afiliados = _afiliadoManager.buscarTodos();
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
            afiliados.Remove(Session.Afiliado);
            dgvAfiliados.DataSource = afiliados;
            dgvAfiliados.Refresh();
        }
    }
}

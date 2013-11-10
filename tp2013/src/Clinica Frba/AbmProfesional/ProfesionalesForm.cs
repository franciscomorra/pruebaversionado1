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
using ClinicaFrba.AbmProfesional;
using ClinicaFrba.Login;

namespace ClinicaFrba.AbmProfesional
{
    [PermissionRequired(Functionalities.AdministrarProfesionales)]
    public partial class ProfesionalesForm : Form
    {
        private ProfesionalManager _ProfesionalManager = new ProfesionalManager();
        private bool _isSearchMode = false;
        public event EventHandler<ProfesionalSelectedEventArgs> OnProfesionalSelected;


        public ProfesionalesForm()
        {
            InitializeComponent();
        }

        public void ModoBusqueda()
        {
            buttonsPanel.Visible = false;
            _isSearchMode = true;
        }

        private void ProfesionalesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = _ProfesionalManager.GetAll();
                if (_isSearchMode)
                {
                    dataSource.Remove(new Profesional() { UserID = Session.User.UserID });
                }

                profesionalesGrid.AutoGenerateColumns = false;
                profesionalesGrid.DataSourceChanged += new EventHandler(profesionalesGrid_DataSourceChanged);
                dataSource.Remove(new Profesional() { UserID = Session.User.UserID });
                profesionalesGrid.DataSource = dataSource;
                profesionalesGrid.DoubleClick += new EventHandler(profesionalesGrid_DoubleClick);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        void profesionalesGrid_DataSourceChanged(object sender, EventArgs e)
        {
            var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
            lblResults.Text = dataSource.Count.ToString();
        }

        void profesionalesGrid_DoubleClick(object sender, EventArgs e)
        {
            if (profesionalesGrid.SelectedRows == null || profesionalesGrid.SelectedRows.Count == 0) return;
            var row = profesionalesGrid.SelectedRows[0];
            var profesional = row.DataBoundItem as Profesional;

            if (OnProfesionalSelected != null)
            {
                OnProfesionalSelected(this, new ProfesionalSelectedEventArgs()
                {
                    Profesional = profesional
                });
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (profesionalesGrid.SelectedRows == null || profesionalesGrid.SelectedRows.Count == 0) return;
            var row = profesionalesGrid.SelectedRows[0];
            var profesional = row.DataBoundItem as Profesional;
            if (MessageBox.Show(string.Format("Confirma que desea eliminar al profesional {0}?", profesional.DetallePersona.Apellido.Trim())
                , "Eliminar profesional", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _ProfesionalManager.Delete(profesional);
                    var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
                    dataSource.Remove(profesional);
                    profesionalesGrid.Refresh();
                    MessageBox.Show(string.Format("Profesional {0} eliminado", profesional.DetallePersona.Apellido.Trim()));
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (profesionalesGrid.SelectedRows == null || profesionalesGrid.SelectedRows.Count == 0) return;
            var row = profesionalesGrid.SelectedRows[0];
            var profesional = row.DataBoundItem as Profesional;
            var regForm = new RegistroForm();
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            regForm.SetUser(profesional);

            ViewsManager.LoadModal(regForm);
        }

        void regForm_OnUserSaved(object sender, UserSavedEventArgs e)
        {
            var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
            var profesional = e.User as Profesional;
            if (dataSource.Contains(profesional)) dataSource.Remove(profesional);
            dataSource.Add(profesional);
            profesionalesGrid.DataSource = new BindingList<Profesional>(dataSource.OrderBy(x => x.DetallePersona.Apellido + x.DetallePersona.Nombre).ToList());
            profesionalesGrid.Refresh();
            MessageBox.Show("Se han guardado los datos del profesional " + e.Username);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var regForm = new RegistroForm();
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            Profile _perfil = new Profile() { Nombre = "Profesional" };
            regForm.Profile = _perfil;
            ViewsManager.LoadModal(regForm);
        }










        /*

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (profesionalesGrid.SelectedRows == null || profesionalesGrid.SelectedRows.Count == 0) return;
            var row = profesionalesGrid.SelectedRows[0];
            var profesional = row.DataBoundItem as Profesional;
            
            //var regForm = new RegistroForm();
            //regForm.OnProfesionalSaved += new EventHandler<ProfesionalSavedEventArgs>(regForm_OnProfesionalSaved);
            //regForm.SetProfesional(profesional, new Profile() { Nombre = "Profesional"});

            ViewsManager.LoadModal(regForm);
        }

        void regForm_OnProfesionalSaved(object sender, ProfesionalSavedEventArgs e)
        {
            MessageBox.Show("Se han guardado los datos del profesional " + e.Profesional.DetallePersona.Apellido);
            var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
            var profesional = e.Profesional;
            if (dataSource.Contains(profesional)) dataSource.Remove(profesional);
            dataSource.Add(profesional);
            profesionalesGrid.DataSource = new BindingList<Profesional>(dataSource.OrderBy(x => x.DetallePersona.Apellido).ToList());
            profesionalesGrid.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //var regForm = new RegistroForm();
            //regForm.OnProfesionalSaved += new EventHandler<ProfesionalSavedEventArgs>(regForm_OnProfesionalSaved);
            //regForm.Profile = new Profile() { Nombre = "Profesional" };
        //    ViewsManager.LoadModal(regForm);
        
        }*/
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtEmail.Text = string.Empty;
            profesionalesGrid.DataSource = _ProfesionalManager.GetAll();
            profesionalesGrid.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var profesionales = _ProfesionalManager.GetAll();
            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                profesionales = new BindingList<Profesional>(profesionales.Where(x => x.DetallePersona.Apellido.ToLowerInvariant().Contains(txtApellido.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                profesionales = new BindingList<Profesional>(profesionales.Where(x => x.DetallePersona.Nombre.ToLowerInvariant().Contains(txtNombre.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                profesionales = new BindingList<Profesional>(profesionales.Where(x => x.DetallePersona.Email.ToLowerInvariant().Contains(txtEmail.Text.ToLowerInvariant())).ToList());
            }
            if (!string.IsNullOrEmpty(txtMatricula.Text))
            {
                profesionales = new BindingList<Profesional>(profesionales.Where(x => x.Matricula.ToLowerInvariant().Equals(txtMatricula.Text.ToLowerInvariant())).ToList());
            }
            profesionales.Remove(new Profesional() { UserID = Session.User.UserID });
            profesionalesGrid.DataSource = profesionales;
            profesionalesGrid.Refresh();
        }
    }
}

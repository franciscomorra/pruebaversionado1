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
using ClinicaFrba.Login;

namespace ClinicaFrba.AbmProfesional
{
    [PermissionRequired(Functionalities.AdministrarProfesionales)]
    public partial class ProfesionalesForm : Form
    {
        private ProfesionalManager _manager = new ProfesionalManager();
        public event EventHandler<UserSelectedEventArgs> OnUserSelected;

        public ProfesionalesForm()
        {
            InitializeComponent();
        }

        public void SetSearchMode()
        {
            buttonsPanel.Visible = false;
        }

        private void ProfesionalesForm_Load(object sender, EventArgs e)
        {
            var bindingSource = new BindingSource();
            var table = _manager.GetAll();
            table.Remove(new Profesional() { UserID = Session.User.UserID });
            profesionalesGrid.AutoGenerateColumns = false;
            profesionalesGrid.DataSourceChanged += new EventHandler(profesionalesGrid_DataSourceChanged);
            profesionalesGrid.DataSource = table;
            profesionalesGrid.DoubleClick += new EventHandler(profesionalesGrid_DoubleClick);
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

            if (OnUserSelected != null)
            {
                OnUserSelected(this, new UserSelectedEventArgs()
                {
                    User = profesional as User
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
                    _manager.Delete(profesional);
                    var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
                    dataSource.Remove(profesional);
                    profesionalesGrid.Refresh();
                    MessageBox.Show(string.Format("Profesional {0} eliminado", profesional.DetallePersona.Apellido.Trim()));
                }
                catch
                {
                    MessageBox.Show("Error al eliminar el profesional");
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
            MessageBox.Show("Se han guardado los datos del profesional " + e.Username);
            var dataSource = profesionalesGrid.DataSource as BindingList<Profesional>;
            var profesional = e.User as Profesional;
            if (dataSource.Contains(profesional)) dataSource.Remove(profesional);
            dataSource.Add(profesional);
            profesionalesGrid.DataSource = new BindingList<Profesional>(dataSource.OrderBy(x => x.DetallePersona.Apellido).ToList());
            profesionalesGrid.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var regForm = new RegistroForm();
            regForm.OnUserSaved += new EventHandler<UserSavedEventArgs>(regForm_OnUserSaved);
            regForm.Profile = Profile.Profesional;
            ViewsManager.LoadModal(regForm);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtEmail.Text = string.Empty;
            profesionalesGrid.DataSource = _manager.GetAll();
            profesionalesGrid.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var profesionales = _manager.GetAll();
            if (!string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                profesionales = new BindingList<Profesional>(profesionales.Where(x => x.DetallePersona.Apellido.ToLowerInvariant().Contains(txtRazonSocial.Text.ToLowerInvariant())).ToList());
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

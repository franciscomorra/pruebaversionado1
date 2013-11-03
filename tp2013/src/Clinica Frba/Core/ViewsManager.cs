using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Login;
/*
using ClinicaFrba.CargaCredito;
using ClinicaFrba.ComprarGiftCard;
*/
namespace ClinicaFrba.Core
{
    /// <summary>
    /// Administra los formularios y las pantallas en el sistema
    /// </summary>
    class ViewsManager
    {
        /// <summary>
        /// Setea cual sera la ventana principal durante la sesion
        /// </summary>
        /// <param name="mainWindow">El formulario principal que sera el padre de todos los demas</param>
        public static void SetMainWindow(Form mainWindow)
        {
            mainWindow.IsMdiContainer = true;
            _mainWindow = mainWindow;
        }

        /// <summary>
        /// Carga un formulario para su visualizacion en el sistema
        /// </summary>
        /// <param name="form">Formulario a mostrar</param>
        public static void LoadView(Form form)
        {
            LimpiarVistas();

            form.Text = string.Empty;
            form.ShowIcon = false;
            form.ControlBox = false;
            form.Dock = DockStyle.Fill;
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Maximized;
            form.MdiParent = _mainWindow;
            form.TopMost = true;
            form.Top = 1;

            form.Show();
        }

        /// <summary>
        /// Carga un formulario como modal en el sistema
        /// </summary>
        /// <param name="form">Formulario a mostrar</param>
        public static void LoadModal(Form form)
        {
            form.ShowIcon = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.ShowDialog();
        }

        /// <summary>
        /// Carga el menu del sistema segun los permisos del usuario
        /// </summary>
        public static void LoadMenu()
        {
            var formTypes = typeof(MainView).Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Form)));
            var dropDown = new System.Windows.Forms.ToolStripMenuItem()
            {
                Name = "AccionesTS",
                Text = "Acciones"
            };
            foreach (var formType in formTypes)
            {

                if (IsAccesibleForm(formType)) {
                    var form = (Form)Activator.CreateInstance(formType);
                    var menuItem = new ToolStripMenuItem(form.Text, null, new EventHandler(Navigate))
                    {
                        Tag = formType
                    };
                    dropDown.DropDownItems.Add(menuItem);
                }
            }
            var salir = new ToolStripMenuItem("Salir", null, new EventHandler(Logoff));
            dropDown.DropDownItems.Add(salir);
            _mainWindow.MainMenuStrip.Items.Add(dropDown);
        }

        /// <summary>
        /// Cierra todas las ventanas activas en el sistema
        /// </summary>
        public static void LimpiarVistas()
        {
            foreach (var chilren in _mainWindow.MdiChildren)
            {
                chilren.Hide();
            }

            if (_mainWindow.ActiveMdiChild != null)
                _mainWindow.ActiveMdiChild.Hide();
        }

        /// <summary>
        /// Muestra un mensaje de alerta en la aplicacion
        /// </summary>
        /// <param name="message">El mensaje a mostrarse</param>
        public static void Alert(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Reinicia el sistema
        /// </summary>
        public static void BorrarMenu()
        {
            _mainWindow.MainMenuStrip.Items.Clear();
            _Views.Clear();
            LoadView(new Login.LoginForm());
        }

        #region Private Members
        private static Form _mainWindow;

        /// <summary>
        /// Metodo ejecutado al seleccionar un elemento del menu
        /// </summary>
        /// <param name="sender">El elemento del menu seleccionado</param>
        /// <param name="e">Argumentos del evento</param>
        private static void Navigate(object sender, EventArgs e)
        {
            var formType = (sender as ToolStripMenuItem).Tag as Type;
            if (_Views.ContainsKey(formType))
            {
                LoadView(_Views[formType]);
            }
            else
            {
                var viewInstance = Activator.CreateInstance(formType) as Form;
                _Views.Add(formType, viewInstance);
                LoadView(viewInstance);
            }
        }

        private static void Logoff(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea salir del sistema?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Session.Salir();
            }
        }

        /// <summary>
        /// Determina si un formulario es accesible para el usuario logueado
        /// </summary>
        /// <param name="formType">Type del formulario a evaluar</param>
        /// <returns>Retorna true si el usuario tiene acceso al formulario, de otra forma retorna false</returns>
        private static bool IsAccesibleForm(Type formType)
        {
            var nonNavigableAttribute = (NonNavigableAttribute)Attribute.GetCustomAttribute(formType, typeof(NonNavigableAttribute));
            if (nonNavigableAttribute != null) return false;

            var permissionAttribute = (PermissionRequiredAttribute)Attribute.GetCustomAttribute(formType, typeof(PermissionRequiredAttribute));
            if (permissionAttribute == null) return true;

            foreach (var permission in permissionAttribute.Permissions)
            {
                if (!Session.User.Permissions.Contains(permission))
                    return false;
            }

            return true;
        }

        private static Dictionary<Type, Form> _Views = new Dictionary<Type, Form>();

        #endregion
    }
}
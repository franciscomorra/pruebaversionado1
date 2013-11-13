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
using System.Reflection;
using FrbaBus.Login;
using FrbaBus.Core;

namespace FrbaBus
{
    public partial class MainView : Form
    {

        bool _noPuedoCerrarme = true;

        public MainView()
        {
            InitializeComponent();
            mainMenu.Visible = false;
           

        }

        private void MainView_Load(object sender, EventArgs e)
        {
            ViewsManager.SetMainWindow(this);

            Configuracion.Instancia().cerrarSe += new EventHandler<EventArgs>(thisClose);
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            ViewsManager.LoadView(new MenuAuxiliar());
        }

        public void thisClose(object sender, EventArgs e)
        {
            _noPuedoCerrarme = !_noPuedoCerrarme;
            this.Close();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _noPuedoCerrarme;
        }
    }
}

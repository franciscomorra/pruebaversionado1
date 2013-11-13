using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Core
{

    class ViewsManager
    {
        private static Form _mainWindow;


        public static void SetMainWindow(Form mainWindow)
        {
            mainWindow.IsMdiContainer = true;
            _mainWindow = mainWindow;
        }

        public static void ClearViews()
        {
            foreach (var chilren in _mainWindow.MdiChildren)
            {
                chilren.Hide();
            }

            if (_mainWindow.ActiveMdiChild != null)
                _mainWindow.ActiveMdiChild.Hide();
        }


        public static void LoadView(Form form)
        {
            ClearViews();

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

    }
}
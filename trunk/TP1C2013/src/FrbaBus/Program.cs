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
using FrbaBus.Abm_Permisos;
using FrbaBus.Core;
using System.Configuration;

namespace FrbaBus
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Configuracion.Instancia().usuario = new Usuario();
            Configuracion.Instancia().usuario.ID = -1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrbaBus.MainView());
        }
    }
}

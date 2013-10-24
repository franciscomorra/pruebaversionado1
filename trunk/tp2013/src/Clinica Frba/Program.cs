using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClinicaFrba.Core;



namespace ClinicaFrba
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppExceptionHandler.Invoke);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
           
        }
    }
}

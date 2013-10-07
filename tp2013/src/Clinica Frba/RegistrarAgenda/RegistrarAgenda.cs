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

namespace ClinicaFrba.RegistrarAgenda
{
    [PermissionRequired(Functionalities.RegistrarAgenda)]
    public partial class RegistrarAgenda : Form
    {
        public RegistrarAgenda()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar datos y guardar por fecha cambiada
        }

        private void calendarioAgenda_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Rellenar horarios en la lista, cada item tiene que tener un checkbox
        }
    }
}

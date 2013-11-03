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

namespace ClinicaFrba.RegistroResultadoAtencion
{
    [PermissionRequired(Functionalities.RegistroResultadoAtencion)]
    public partial class RegistroResultadoAtencion : Form
    {
        public RegistroResultadoAtencion()
        {
            InitializeComponent();
        }

    }
}

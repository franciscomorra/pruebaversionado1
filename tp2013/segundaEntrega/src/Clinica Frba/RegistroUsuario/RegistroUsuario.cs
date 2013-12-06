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

namespace ClinicaFrba.RegistroUsuario
{
    [PermissionRequired(Functionalities.RegistroUsuario)]
    public partial class RegistroUsuario : Form
    {

        public RegistroUsuario()
        {
            InitializeComponent();
        }
    }
}

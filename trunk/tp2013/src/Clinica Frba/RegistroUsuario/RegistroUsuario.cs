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
    public partial class RegistroUsuario : Form
    {
        [PermissionRequired(Functionalities.RegistroUsuario)]
        public RegistroUsuario()
        {
            InitializeComponent();
        }
    }
}

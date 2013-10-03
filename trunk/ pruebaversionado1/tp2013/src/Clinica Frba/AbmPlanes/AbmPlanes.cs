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

namespace ClinicaFrba.AbmPlanes
{
    public partial class AbmPlanes : Form
    {
        [PermissionRequired(Functionalities.AbmEspecialidadesMedicas)]
        public AbmPlanes()
        {
            InitializeComponent();
        }
    }
}

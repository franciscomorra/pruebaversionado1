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


namespace ClinicaFrba.AbmEspecialidadesMedicas
{
    [PermissionRequired(Functionalities.AbmEspecialidadesMedicas)]
    public partial class AbmEspecialidadesMedicas : Form
    {
        public AbmEspecialidadesMedicas()
        {
            InitializeComponent();
        }
    }
}


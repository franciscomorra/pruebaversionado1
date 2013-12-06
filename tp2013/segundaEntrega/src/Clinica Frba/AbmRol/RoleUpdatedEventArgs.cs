using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmRol
{
    public class RoleUpdatedEventArgs : EventArgs
    {
        public Rol Rol { get; set; }
    }
}

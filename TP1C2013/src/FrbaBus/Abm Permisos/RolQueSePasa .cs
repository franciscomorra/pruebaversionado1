using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;

namespace FrbaBus.Abm_Permisos
{
    public class RolQueSePasa : EventArgs
    {
        public Rol Rol { get; set; }
    }
}


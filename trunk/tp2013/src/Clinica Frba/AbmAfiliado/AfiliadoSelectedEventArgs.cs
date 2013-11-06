using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmAfiliado
{
    public class AfiliadoSelectedEventArgs : EventArgs
    {
        public Afiliado Afiliado { get; set;}
    }
}

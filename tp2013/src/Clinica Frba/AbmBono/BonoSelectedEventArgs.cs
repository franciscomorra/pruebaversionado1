using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmBono
{
    public class BonoSelectedEventArgs : EventArgs
    {
        public Bono Bono { get; set; }
    }
}

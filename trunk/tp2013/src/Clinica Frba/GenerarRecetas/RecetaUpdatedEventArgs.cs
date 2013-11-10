using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.GenerarReceta
{
    public class RecetaUpdatedEventArgs : EventArgs
    {
        public Receta Receta { get; set; }

    }
}

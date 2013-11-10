using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.Consultas
{
    public class RecetaUpdatedEventArgs : EventArgs
    {
        public Receta Receta { get; set; }

    }
}

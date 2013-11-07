using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmTurno
{
    public class TurnoSelectedEventArgs : EventArgs
    {
        public Turno Turno { get; set; }
    }
}

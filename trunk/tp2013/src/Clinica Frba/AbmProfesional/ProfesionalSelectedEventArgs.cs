using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmProfesional
{
    public class ProfesionalSelectedEventArgs : EventArgs
    {
        public Profesional Profesional { get; set; }
    }
}

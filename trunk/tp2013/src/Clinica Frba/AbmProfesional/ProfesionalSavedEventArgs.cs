using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.AbmProfesional
{
    public class ProfesionalSavedEventArgs : EventArgs
    {
        public Profesional Profesional { get; set; }
    }
}

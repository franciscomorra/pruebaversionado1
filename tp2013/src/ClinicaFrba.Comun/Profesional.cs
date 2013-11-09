using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Profesional : User
    {
        //public static Profile Profile = Profile.Profesional;
        public string Matricula { get; set; }
        public List<Especialidad> Especialidades { get; set; }

        public override string ToString()
        {
            return "Dr. "+this.DetallePersona.Apellido + ", " + this.DetallePersona.Nombre;
        }
        
    }
}

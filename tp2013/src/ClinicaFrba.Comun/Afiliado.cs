using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Afiliado : User
    {
        //public static Profile Profile = Profile.Afiliado;
        public int NroAfiliado { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int CantHijos { get; set; }
        public PlanMedico PlanMedico { get; set; }
        public string MotivoCambio { get; set; }
    }
}

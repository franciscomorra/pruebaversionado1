using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Afiliado : User
    {
        public long grupoFamiliar  { get; set; }
        public long tipoAfiliado { get; set; }
        
        public long NroAfiliado { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int CantHijos { get; set; }
        public PlanMedico PlanMedico { get; set; }
        public string MotivoCambio { get; set; }



        public override string ToString()
        {
            return this.DetallesPersona.Apellido +", "+this.DetallesPersona.Nombre;
        }
    }
}

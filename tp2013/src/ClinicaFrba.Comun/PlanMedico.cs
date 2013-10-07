using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class PlanMedico
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int PrecioConsulta { get; set; }
        public int PrecioFarmacia { get; set; }
        

        public override bool Equals(object obj)
        {
            if (!(obj is PlanMedico)) return false;
            return ((PlanMedico)obj).ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}

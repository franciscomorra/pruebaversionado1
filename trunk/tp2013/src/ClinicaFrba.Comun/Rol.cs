using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Rol
    {
        public int ID { get; set; }
        public string Nombre { get; set; }        
        public Perfil Perfil { get; set; }

        public List<Functionalities> Functionalities { get; set; }

        public Rol()
        {}

        public override bool Equals(object obj)
        {
            if (!(obj is Rol)) return false;
            return ((Rol)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return Nombre+" (Perfil: "+Perfil+")";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Perfil
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Functionalities> Functionalities { get; set; }

        public Perfil(){}

        public override bool Equals(object obj)
        {
            if (!(obj is Perfil)) return false;
            return ((Perfil)obj).Nombre == this.Nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Profile
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Functionalities> Functionalities { get; set; }

        public Profile()
        {
            //Functionalities = new List<Functionalities>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Profile)) return false;
            return ((Profile)obj).Nombre == this.Nombre;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
    
    /*
    public enum Profile
    {
        Afiliado,
        Profesional,
        Administrativo,
        Administrador
    }
    */


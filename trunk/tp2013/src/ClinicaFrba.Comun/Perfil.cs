using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{

    public enum Perfil
    {
        Afiliado,
        Profesional,
        Administrativo,
        Administrador
        /*
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Functionalities> Functionalities { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Perfil)) return false;
            return ((Perfil)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        */
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
}

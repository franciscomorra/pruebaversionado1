using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Especialidad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public TiposEspecialidad TipoEspecialidad { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Especialidad)) return false;
            return ((Especialidad)obj).ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }

    public class TiposEspecialidad
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Especialidad)) return false;
            return ((Especialidad)obj).ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}

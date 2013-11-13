using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
    public class Rol
    {

        public int ID { get; set; }

        public string NOMBRE { get; set; }

        public bool BAJA_LOGICA { get; set; }

        public List<Funcionalidad> Funcionalidades { get; set; }

        public Rol()
        {

            Funcionalidades = new List<Funcionalidad>();
        }
    }

}

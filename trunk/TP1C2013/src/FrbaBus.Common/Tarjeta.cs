using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
    public class Tarjeta
    {
        public int ID { get; set; }

        public string DESCRIPCION { get; set; }

        public long DNI { get; set; }

        public string CODIGO_SEGURIDAD { get; set; }

        public DateTime FECHA_VENCIMIENTO { get; set; }

        public float CANT_CUOTAS { get; set; }
    }
}

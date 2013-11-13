using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
    public class Recorrido
    {

        public long RECORRIDO_CODIGO { get; set; }

        public string TIPO_SERVICIO { get; set; }

        public string CIUDAD_ORIGEN { get; set; }

        public string CIUDAD_DESTINO { get; set; }

        public float PRECIO_BASE_PASAJE { get; set; }

        public float PRECIO_BASE_KG { get; set; }

        public float RECARGO { get; set; }

        public bool BAJA_LOGICA { get; set; }

    }
}
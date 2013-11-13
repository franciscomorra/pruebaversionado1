using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
   public class PasajeroFrecuente
    {

       public long DNI { get; set; }

       public long PUNTOS { get; set; }

       public List<ComposicionPuntos> COMPOSICIONPUNTOS { get; set; }

       public PasajeroFrecuente()
       {
           COMPOSICIONPUNTOS = new List<ComposicionPuntos>();
       }




    }
}

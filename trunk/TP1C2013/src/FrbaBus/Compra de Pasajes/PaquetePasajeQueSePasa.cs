using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;

namespace FrbaBus.Compra_de_Pasajes
{
    public class PaquetePasajeQueSePasa : EventArgs
    {

        public PasajePaquete pasajePaquete { get; set; }
    }
}

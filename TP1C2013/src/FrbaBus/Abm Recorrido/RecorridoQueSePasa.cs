using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;

namespace FrbaBus.Abm_Recorrido
{
    public class RecorridoQueSePasa : EventArgs
    {
        public Recorrido Recorrido { get; set; }
    }
}
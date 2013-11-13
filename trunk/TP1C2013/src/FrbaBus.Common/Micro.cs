using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FrbaBus.Common
{
    public class Micro
    {

        public string PATENTE { get; set; }

        public string TIPO_SERVICIO { get; set; }

        public DateTime? FECHA_ALTA { get; set; }

        public DateTime? FECHA_BAJA_DEFINITIVA { get; set; }

        public int KG_DISPONIBLES { get; set; }

        public int CANT_BUTACAS { get; set; }

        public string MODELO { get; set; }

        public string MARCA { get; set; }
    
        public BindingList<Butaca> BUTACAS { get; set; }


        public Micro()
        {

            BUTACAS = new BindingList<Butaca>();
        }
    


    }
}

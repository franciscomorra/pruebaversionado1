using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;





namespace FrbaBus.Common
{
    public class Viaje
    {

        public int ID { get; set; }

        public string PATENTE { get; set; }

        public string TIPO_SERVICIO { get; set; }

        public int KG_DISPONIBLES { get; set; }

        public int BUTACAS_DISPONIBLES { get; set; }

        public DateTime FECHA_SALIDA { get; set; }

        public DateTime FECHA_LLEGADA_ESTIMADA { get; set; }
        
        public BindingList<Butaca> BUTACAS { get; set; }


        public Viaje()
        {

            BUTACAS = new BindingList<Butaca>();
        }
    
    
    
    
    }
}

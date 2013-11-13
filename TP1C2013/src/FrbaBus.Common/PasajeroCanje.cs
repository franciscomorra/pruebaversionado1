using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
    public class PasajeroCanje
    {

        public long DNI { get; set; }

        public List<ProductoCantidad> PRODCANT { get; set; }

        public PasajeroCanje()
        {

            PRODCANT = new List<ProductoCantidad>();
        
        }

        
    
    }
}

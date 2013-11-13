using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FrbaBus.Common
{
    public class Usuario
    {
        public int ID; 

        public BindingList<String> FUNCIONALIDADES { get; set; }
        
        public int Estado { get; set; }

        public Usuario()
        {
            FUNCIONALIDADES = new BindingList<string>();
        }
    }
}

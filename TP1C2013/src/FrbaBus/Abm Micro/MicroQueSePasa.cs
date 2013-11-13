using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;

namespace FrbaBus.Abm_Micro
{
    public class MicroQueSePasa : EventArgs
    {
        public Micro Micro { get; set; }
    }
}


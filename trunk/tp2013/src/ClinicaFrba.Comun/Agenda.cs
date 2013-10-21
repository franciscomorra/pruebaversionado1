using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Agenda
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public TimeSpan Lunes { get; set; }
        public TimeSpan Martes { get; set; }
        public TimeSpan Miercoles { get; set; }
        public TimeSpan Jueves { get; set; }
        public TimeSpan Viernes { get; set; }
        public TimeSpan Sabado { get; set; }

    }
}

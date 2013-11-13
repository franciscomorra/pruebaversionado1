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
        public DateTime LunesIN { get; set; }
        public DateTime LunesOUT { get; set; }
        public DateTime MartesIN { get; set; }
        public DateTime MartesOUT { get; set; }
        public DateTime MiercolesIN { get; set; }
        public DateTime MiercolesOUT { get; set; }
        public DateTime JuevesIN { get; set; }
        public DateTime JuevesOUT { get; set; }
        public DateTime ViernesIN { get; set; }
        public DateTime ViernesOUT { get; set; }
        public DateTime SabadoIN { get; set; }
        public DateTime SabadoOUT { get; set; }
        public Profesional profesional { get; set; }


    }
}

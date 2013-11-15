using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Consulta
    {
        public Turno Turno { get; set; }
        public string Sintomas { get; set; }
        public string Enfermedad { get; set; }
        public int NumeroConsulta { get; set; }

    }
}

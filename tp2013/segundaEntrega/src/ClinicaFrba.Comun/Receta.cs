using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Receta
    {
        public Bono BonoFarmacia { get; set; }
        public Turno Turno { get; set; }
        public int Precio{ get; set; }
        public DateTime Fecha { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
    }
}

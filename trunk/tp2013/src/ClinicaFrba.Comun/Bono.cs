using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class Bono
    {
        public int Numero { get; set; }
        public int Precio{ get; set; }
        public Afiliado AfiliadoCompro { get; set; }
        public DateTime Fecha { get; set; }
        public TipoBono TipodeBono { get; set; }

    }
    public enum TipoBono
    {
        Consulta,
        Receta
    }
}

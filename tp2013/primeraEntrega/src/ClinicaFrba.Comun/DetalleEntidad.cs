using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class DetalleEntidad
    {
        public int DNI { get; set; }
        public string TipoDNI { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public override string ToString()
        {
            return Email;
        }

    }
}

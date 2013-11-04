using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba.Comun
{
    public class DetallesPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long DNI { get; set; }
        public TipoDoc TipoDNI { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public TipoSexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public override string ToString()
        {
            return Nombre+ " "+Apellido;
        }
    }
    public enum TipoDoc
    {
        DNI,
        LC,
        LE,
        Pas
    }
    public enum TipoSexo 
    {
        Masculino,
        Femenino
    }
    public enum EstadoCivil
    {
        Soltero,
        Casado,
        Viudo,
        Concubinato,
        Divorciado
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Data;
using ClinicaFrba.Comun;
using System.Data;

namespace ClinicaFrba.Negocio
{
    public class EstadoCivilManager
    {
        public List<EstadoCivil> GetAll()//Devuelve una lista con las funcionalidades existentes (son 15)
        {
            return Enum.GetValues(typeof(EstadoCivil)).Cast<EstadoCivil>().ToList();
        }
    }
}
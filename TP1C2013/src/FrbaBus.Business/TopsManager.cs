using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;
using Data;
using System.Configuration;
using System.Data;
using System.ComponentModel;

namespace FrbaBus.Business
{
    public class TopsManager
    {
        public int aniosFueraDeServicio()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ANIOS_POSIBLES");
            
            if (int.Parse(resultado.Rows[0]["valor"].ToString()) > Configuracion.fechaAhora().Year)
                return int.Parse(resultado.Rows[0]["valor"].ToString());
            else
                return Configuracion.fechaAhora().Year;

        }
    }
}

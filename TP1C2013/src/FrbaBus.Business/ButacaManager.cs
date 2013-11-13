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
    public class ButacaManager
    {
       
       /* public List<Butaca> ObtenerButacasDeMicro(string patente)
        {
            var retorno = new List<Butaca>();
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.BUTACASDEMICRO", SqlDataAccessArgs.CreateWith("@PATENTE_MICRO", patente).Arguments);

            if (resultado != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    retorno.Add(new Butaca()
                    {
                        NUMERO = int.Parse(row["NUMERO"].ToString()),
                        PATENTE = row["PATENTE"].ToString(),
                        TIPO = row["TIPO"].ToString(),
                        PISO = row["PISO"].ToString()
                    });

                }
            }


            return retorno;

        }*/





        public void agregarButaca(Butaca auxButaca)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.INSERTARBUTACA", SqlDataAccessArgs.CreateWith("@PATENTE_MICRO", auxButaca.PATENTE).And("@NUMERO", auxButaca.NUMERO)
                .And("@PISO",auxButaca.PISO).And("@TIPO", auxButaca.TIPO).Arguments);
        }

        public void modificarButacaPropiedades(Butaca unaButaca)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ACTUALIZARPROPIEDADESBUTACA", SqlDataAccessArgs.CreateWith("@PATENTE_MICRO", unaButaca.PATENTE).And("@NUMERO", unaButaca.NUMERO)
                .And("@PISO", unaButaca.PISO).And("@TIPO", unaButaca.TIPO).Arguments);
        }

        public void modificarButacaCompleta(Butaca unaButaca, int numeroViejo)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ACTUALIZARBUTACACOMPLETA", SqlDataAccessArgs.CreateWith("@PATENTE_MICRO", unaButaca.PATENTE).And("@NUMERO", unaButaca.NUMERO)
                .And("@PISO", unaButaca.PISO).And("@TIPO", unaButaca.TIPO).And("@NUMERO_VIEJO", numeroViejo).And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora() ).Arguments);
        }
    }
}

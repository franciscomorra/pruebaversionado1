using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;
using System.Data;
using System.Data.SqlClient;
using Data;
using System.Configuration;
using System.ComponentModel;

namespace FrbaBus.Business
{
   public class PasajeroFrecuenteManager
    {

       public PasajeroFrecuente ObtenerPasajero(long DNI)
       {

           var pasajero = new PasajeroFrecuente();

           pasajero.DNI = DNI;

           
          var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), 
              "ACTITUD_GDD.CALCULARPUNTOS", SqlDataAccessArgs.CreateWith("@DNI", DNI).And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);


           

          if (!(resultado.Rows[0].IsNull("PUNTOS")))
          {
              foreach (DataRow row in resultado.Rows)
              {

                  pasajero.PUNTOS = long.Parse(row["PUNTOS"].ToString());

              }




              
              var resultado2 = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                 "ACTITUD_GDD.CALCULARFORMACIONPUNTOS", SqlDataAccessArgs.CreateWith("@DNI", DNI).And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);

              
              if ( resultado2 != null && resultado2.Rows.Count > 0)
              {
                  foreach (DataRow row in resultado2.Rows)
                  {


                      var composicionPuntos = new ComposicionPuntos();

                      composicionPuntos.TIPO = row["TIPO"].ToString();

                      composicionPuntos.PUNTOS_GENERADOS_CANJEADOS = long.Parse(row["PUNTOS"].ToString());

                      composicionPuntos.FECHA = Convert.ToDateTime(row["FECHA"]);


                      pasajero.COMPOSICIONPUNTOS.Add(composicionPuntos);
                  }
              }


          }

              return pasajero;

          
       }
   
   
   }
}

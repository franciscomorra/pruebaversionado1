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
    public class  RegistroLlegadasManager
    {

        public RegistroLlegadas Buscar_ID_Viaje(String PATENTE,String CIUDAD_ORIGEN,String CIUDAD_DESTINO,DateTime FECHA_LLEGADA)
         {
            var registro = new RegistroLlegadas();

            registro.PATENTE = PATENTE;
            registro.CIUDAD_DESTINO = CIUDAD_DESTINO;
            registro.CIUDAD_ORIGEN = CIUDAD_ORIGEN;
            registro.FECHA_LLEGADA = FECHA_LLEGADA.ToString();

             
             var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                 "ACTITUD_GDD.BUSCAR_ID_VIAJE", SqlDataAccessArgs.CreateWith("@PATENTE",PATENTE).And
                 ("@CIUDAD_ORIGEN",CIUDAD_ORIGEN).And("@CIUDAD_DESTINO",CIUDAD_DESTINO)
                 .And("@FECHA_LLEGADA",FECHA_LLEGADA)
                 .Arguments);

             if (resultado != null && resultado.Rows.Count > 0)
             {
                 
                 registro.ID_VIAJE = int.Parse(resultado.Rows[0]["ID_VIAJE"].ToString());
              }

             return registro;
         }
      
        public void Cargar_Fecha_Llegada(DateTime FECHA_LLEGADA, int ID_VIAJE)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
             "ACTITUD_GDD.CARGAR_FECHAS_LLEGADAS_MICROS", SqlDataAccessArgs.CreateWith("@FECHA_LLEGADA", FECHA_LLEGADA).
             And("@ID_VIAJE", ID_VIAJE)
              .Arguments);
        }
        
    }
}

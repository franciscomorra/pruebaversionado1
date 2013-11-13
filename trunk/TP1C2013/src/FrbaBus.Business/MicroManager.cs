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
   public class MicroManager
    {


       public BindingList<Micro> GetAll()
       {
           

           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarMicros");
           var micros = new BindingList<Micro>();
           if (resultado != null && resultado.Rows != null)
           {
               foreach (DataRow row in resultado.Rows)
               {
                   
                     
                   var micro = new Micro();
                   
                     micro.PATENTE = row["PATENTE"].ToString();
                     micro.TIPO_SERVICIO = row["TIPO_SERVICIO"].ToString();
                     if (!(row.IsNull("FECHA_ALTA")))
                     {
                         micro.FECHA_ALTA = Convert.ToDateTime(row["FECHA_ALTA"]);
                     }

                     if (!(row.IsNull("FECHA_BAJA_DEFINITIVA")))
                     {
                           micro.FECHA_BAJA_DEFINITIVA = Convert.ToDateTime(row["FECHA_BAJA_DEFINITIVA"]);
                     }
                   
                     
                     micro.KG_DISPONIBLES = int.Parse(row["KG_DISPONIBLES"].ToString());
                     micro.MODELO = row["MODELO"].ToString();
                     micro.MARCA = row["MARCA"].ToString();
                     micro.BUTACAS = GetButacas(row["PATENTE"].ToString());
                    
                   
               
                   micros.Add(micro);
               }



               
           }


           return micros;
       
       
       
       
       }



       public BindingList<Butaca> GetButacas(string patente)
       {
           var retorno = new BindingList<Butaca>();
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
                       PISO = int.Parse(row["PISO"].ToString())
                   });

               }
           }


           return retorno;

       }

       public void BorrarMicro(Micro micro)
       {
           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
               "ACTITUD_GDD.ELIMINAR_MICRO", SqlDataAccessArgs
               .CreateWith("@MICRO_PATENTE", micro.PATENTE)
           .Arguments);
       }

       public void UpdatearMicro(Micro micro)
       {
           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
               "ACTITUD_GDD.ACTUALIZARMICRO", SqlDataAccessArgs
               .CreateWith("@PATENTE", micro.PATENTE).And("@KG_DISPONIBLES", micro.KG_DISPONIBLES).And("@TIPO_SERVICIO", micro.TIPO_SERVICIO).And("@MODELO", micro.MODELO).And("@MARCA", micro.MARCA)
           .Arguments);

       }

       public void InsertarMicro(Micro micro)
       {
           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
               "ACTITUD_GDD.INSERTAR_MICRO", SqlDataAccessArgs
               .CreateWith("@PATENTE", micro.PATENTE).And("@KG_DISPONIBLES", micro.KG_DISPONIBLES).And("@TIPO_SERVICIO", micro.TIPO_SERVICIO).And("@MODELO", micro.MODELO).And("@MARCA",micro.MARCA).And("@FECHA_ALTA",micro.FECHA_ALTA)
           .Arguments);           
       }


       public void bajaDefinitivaSinReemplazo(DateTime fechaAhora, Micro micro)
       {
           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
               "ACTITUD_GDD.ELIMINAR_MICRO", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_BAJA", micro.FECHA_BAJA_DEFINITIVA).Arguments);
           
           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.CANCELAR_TODO_POR_BAJA_LOGICA", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_ACTUAL", fechaAhora).Arguments);

       }

       public bool bajaTemporalSinReemplazo(DateTime fechaAhora, Micro micro, DateTime fechaInicial, DateTime fechaFinal)
       {

           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.DAR_DE_BAJA_TEMPORAL", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_FUERA_SERVICIO", fechaInicial)
              .And("@FECHA_REINICIO_SERVICIO", fechaFinal).Arguments);

           int bajaTemporal = int.Parse(resultado.Rows[0]["FLAG"].ToString());

           if (bajaTemporal > 0)
           {

               SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.CANCELAR_TODO_POR_BAJA_TEMPORAL", SqlDataAccessArgs.CreateWith("@ID_BAJA_TEMPORAL", bajaTemporal).And("@FECHA_ACTUAL", fechaAhora).Arguments);

               return true;
           }
           else
           {
               return false;
           }


       }

       public string bajaDefinitivaConReemplazo(DateTime fechaAhora, Micro micro)
       {

           SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
               "ACTITUD_GDD.ELIMINAR_MICRO", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_BAJA", micro.FECHA_BAJA_DEFINITIVA).Arguments);

           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.REEMPLAZAR_TODO_POR_BAJA_LOGICA", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_ACTUAL", fechaAhora).Arguments);

           return resultado.Rows[0]["SE_ENCONTRO_MICRO"].ToString();


       }

       public String bajaTemporalConReemplazo(DateTime fechaAhora, Micro micro, DateTime fechaInicial, DateTime fechaFinal)
       {
           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.DAR_DE_BAJA_TEMPORAL", SqlDataAccessArgs.CreateWith("@PATENTE", micro.PATENTE).And("@FECHA_FUERA_SERVICIO", fechaInicial)
              .And("@FECHA_REINICIO_SERVICIO", fechaFinal).Arguments);

           int bajaTemporal = int.Parse(resultado.Rows[0]["FLAG"].ToString());

           if (bajaTemporal > 0)
           {

               var resultado2 = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.REEMPLAZAR_TODO_POR_BAJA_TEMPORAL", SqlDataAccessArgs.CreateWith("@ID_BAJA_TEMPORAL", bajaTemporal).And("@FECHA_ACTUAL", fechaAhora).Arguments);
               return resultado2.Rows[0]["SE_ENCONTRO_MICRO"].ToString();
           }else
                return null;
       }
    }
}

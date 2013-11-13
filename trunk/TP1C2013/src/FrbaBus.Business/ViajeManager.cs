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
    public class ViajeManager
    {

        public BindingList<Viaje> GetPorFechaSalidaOrigenDestino(DateTime fecha, string origen, string destino)
        {


            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarViajesPosibles",
                SqlDataAccessArgs.CreateWith("@FECHA", fecha).And("@ORIGEN", origen).And("@DESTINO", destino).And("@FECHA_CONSULTA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);
           
            var viajes = new BindingList<Viaje>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {


                    var viaje = new Viaje();

                    viaje.ID = int.Parse(row["ID"].ToString());

                    viaje.KG_DISPONIBLES = int.Parse(row["KG_DISPONIBLES"].ToString());

                    viaje.PATENTE = row["PATENTE"].ToString();

                    viaje.TIPO_SERVICIO = row["TIPO_SERVICIO"].ToString();

                    viaje.FECHA_SALIDA = Convert.ToDateTime(row["FECHA_SALIDA"]);

                    viaje.FECHA_LLEGADA_ESTIMADA = Convert.ToDateTime(row["FECHA_LLEGADA_ESTIMADA"]);


                    var resultadoButacas = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarButacasLibres",
                    SqlDataAccessArgs.CreateWith("@ID_VIAJE", viaje.ID).And("@PATENTE", viaje.PATENTE).Arguments);

                    if (resultadoButacas != null && resultadoButacas.Rows != null)
                    {
                        foreach (DataRow rowButaca in resultadoButacas.Rows)
                        {
                            Butaca butaca = new Butaca();

                            butaca.PATENTE = viaje.PATENTE;
                            butaca.NUMERO = int.Parse(rowButaca["NUMERO"].ToString());
                            butaca.PISO = int.Parse(rowButaca["PISO"].ToString());
                            butaca.TIPO = rowButaca["TIPO"].ToString();

                            viaje.BUTACAS.Add(butaca);
                        }
                    }

                    viaje.BUTACAS_DISPONIBLES = viaje.BUTACAS.Count;
                    viajes.Add(viaje);
                }





            }


            return viajes;




        }



        public BindingList<Viaje> getPatentesPosibles(int IDRecorrido, DateTime fechaSalida, DateTime fechaLlegadaEstimada)
        {

            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.PatentesPosibles",
                SqlDataAccessArgs.CreateWith("@RECORRIDO_CODIGO", IDRecorrido).And("@FECHA_SALIDA", fechaSalida).And("@FECHA_LLEGADA_ESTIMADA", fechaLlegadaEstimada).Arguments);
           
            var viajes = new BindingList<Viaje>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {


                    var viaje = new Viaje();

                    viaje.PATENTE = row["PATENTE"].ToString();
                    viajes.Add(viaje);
                }
            }
            return viajes;
        }


        public void insertarViaje(int Recorrido_codigo, string patente, DateTime fecha_origen, DateTime fecha_llegada)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.InsertarViaje",
                SqlDataAccessArgs.CreateWith("@RECORRIDO_CODIGO", Recorrido_codigo).And("@PATENTE", patente).And
                ("@FECHA_SALIDA",fecha_origen).And("@FECHA_LLEGADA_ESTIMADA", fecha_llegada).Arguments);
        }
    }
}

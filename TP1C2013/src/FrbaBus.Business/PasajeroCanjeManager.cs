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
    public class PasajeroCanjeManager
    {

        public PasajeroCanje ObtenerPasajeroCanje(long DNI)
        {

            var pasajero = new PasajeroCanje();


            pasajero.DNI = DNI;



            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.CALCULARPOSIBLESCANJES", SqlDataAccessArgs.CreateWith("@DNI", DNI).And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);



            if (resultado != null && resultado.Rows.Count > 0)
            {
                foreach (DataRow row in resultado.Rows)
                {

                    var productoCantidad = new ProductoCantidad();

                    productoCantidad.NombreProducto = row["NOMBREPRODUCTO"].ToString();

                    productoCantidad.Cantidad = int.Parse(row["CANTIDAD"].ToString());

                    productoCantidad.PuntosNecesarios = int.Parse(row["PUNTOSNECESARIOS"].ToString());

                    
                  pasajero.PRODCANT.Add(productoCantidad);
                }


            }




            return pasajero;

        }



        public void realizarCanje(long DNI, int cantidadProductos, String producto)
        {

            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.INSERTAR_CANJE", SqlDataAccessArgs.CreateWith("@NOMBRE_PRODUCTO", producto).And("@CANTIDAD",cantidadProductos).And("@DNI", DNI)
              .And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);

        }

    
    }
}

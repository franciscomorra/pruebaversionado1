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
    public class TarjetaManager
    {


        public Tarjeta obtenerTarjeta(long DNI, int ID_TARJETA)
        {
            Tarjeta retorno = new Tarjeta();

            retorno.DNI = DNI;
            retorno.ID = ID_TARJETA;
            retorno.CODIGO_SEGURIDAD = null;

            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ObtenerTarjeta", SqlDataAccessArgs.CreateWith("@DNI", retorno.DNI).And("@ID", retorno.ID).Arguments);

            if (resultado != null && resultado.Rows != null)
            {
                retorno.CODIGO_SEGURIDAD = resultado.Rows[0]["CODIGO_SEGURIDAD"].ToString();
                retorno.CANT_CUOTAS = int.Parse(resultado.Rows[0]["CANT_CUOTAS"].ToString());
                retorno.DESCRIPCION = resultado.Rows[0]["DESCRIPCION"].ToString();
                retorno.FECHA_VENCIMIENTO = Convert.ToDateTime(resultado.Rows[0]["VENCIMIENTO"]);
            }

            return retorno;

        }

        public void cargarNuevaTarjeta(Tarjeta unaTarjeta)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
            "ACTITUD_GDD.CargarNuevaTarjeta", SqlDataAccessArgs.CreateWith("@DNI", unaTarjeta.DNI).And("@ID", unaTarjeta.ID).And("@CODIGO", unaTarjeta.CODIGO_SEGURIDAD)
            .And("@VENCIMIENTO", unaTarjeta.FECHA_VENCIMIENTO).And("@DESCRIPCION", unaTarjeta.DESCRIPCION).Arguments);
        }

        public BindingList<String> getAllDescripciones(){
            
            BindingList<String> retorno = new BindingList<string>();
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ListarTiposTarjeta");

            foreach(DataRow row in resultado.Rows){
                retorno.Add( row["DESCRIPCION"].ToString() );
            }

            return retorno;

        }

        public int getCuotasMaximas(String Descripcion)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.conseguirCuotaMaxima", SqlDataAccessArgs.CreateWith("@DESCRIPCION",Descripcion).Arguments);

            return int.Parse(resultado.Rows[0]["CUOTASMAXIMAS"].ToString());

        }

    }
}

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
    public class ItemCancelacionManager
    {




        public BindingList<ItemCancelacion> cargarItems(long DNI, int IDCompra)
        {
           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarItemsCompra",
               SqlDataAccessArgs.CreateWith("@DNI", DNI).And("@ID_COMPRA", IDCompra).And("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);
           var items = new BindingList<ItemCancelacion>();
           if (resultado != null && resultado.Rows != null)
           {
               foreach (DataRow row in resultado.Rows)
               {


                   var item = new ItemCancelacion();

                   item.CANCELADO = false;
                   item.ID = int.Parse(row["ID"].ToString());
                   item.KG_BUTACA = int.Parse(row["KG_BUTACA"].ToString());
                   item.PRECIO = float.Parse(row["PRECIO"].ToString());
                   item.TIPO = row["TIPO"].ToString();

                   items.Add(item);
               }
           }

           return items;
        }

        public void cancelarItems(BindingList<ItemCancelacion> lista, String motivo)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.CrearCancelacion",
               SqlDataAccessArgs.CreateWith("@FECHA", FrbaBus.Common.Configuracion.fechaAhora()).And("@MOTIVO", motivo).Arguments);

            int cancelacion = int.Parse(resultado.Rows[0]["IDCANCELACION"].ToString());

            foreach (ItemCancelacion item in lista)
            {
                SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.CancelarItem",
               SqlDataAccessArgs.CreateWith("@ID", item.ID).And("@TIPO", item.TIPO).And("@ID_CANCELACION", cancelacion).Arguments);
            }
        }

        public int numeroDeTarjeta(int IDCompra)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ObtenerTarjetaCompra",
               SqlDataAccessArgs.CreateWith("@ID", IDCompra).Arguments);

            return int.Parse(resultado.Rows[0]["IDTARJETA"].ToString()); ;
        }
    }
}
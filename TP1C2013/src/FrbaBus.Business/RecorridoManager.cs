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
    public class RecorridoManager
    {

        public BindingList<Recorrido> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarRecorrido");
            var recorridos = new BindingList<Recorrido>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    recorridos.Add(new Recorrido()
                    {
                        RECORRIDO_CODIGO = long.Parse(row["RECORRIDO_CODIGO"].ToString()),
                        TIPO_SERVICIO = row["TIPO_SERVICIO"].ToString(),
                        CIUDAD_ORIGEN = row["CIUDAD_ORIGEN"].ToString(),
                        CIUDAD_DESTINO = row["CIUDAD_DESTINO"].ToString(),
                        PRECIO_BASE_KG = float.Parse(row["PRECIO_BASE_KG"].ToString()),
                        PRECIO_BASE_PASAJE = float.Parse(row["PRECIO_BASE_PASAJE"].ToString()),
                        RECARGO = float.Parse(row["RECARGO"].ToString()),
                        BAJA_LOGICA = Convert.ToBoolean(row["BAJA_LOGICA"])
                    });


                }

            }

            return recorridos;

        }

        public void BorrarRecorrido(Recorrido recorrido)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ELIMINAR_RECORRIDO", SqlDataAccessArgs
                .CreateWith("@RECORRIDO_CODIGO", recorrido.RECORRIDO_CODIGO).And("@FECHA_AHORA",Configuracion.fechaAhora())
            .Arguments);
        }

        public void SalvarRecorrido(Recorrido recorrido)
        {
            if (recorrido.RECORRIDO_CODIGO > 0) UpdatearRecorrido(recorrido);
            else InsertarRecorrido(recorrido);
        }


        private void UpdatearRecorrido(Recorrido recorrido)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ACTUALIZARRECORRIDO", SqlDataAccessArgs
                .CreateWith("@RECORRIDO_CODIGO",recorrido.RECORRIDO_CODIGO).And("@CIUDAD_ORIGEN", recorrido.CIUDAD_ORIGEN).And("@CIUDAD_DESTINO", recorrido.CIUDAD_DESTINO).And("@TIPO_SERVICIO", recorrido.TIPO_SERVICIO).
                And("@PRECIO_BASE_KG", recorrido.PRECIO_BASE_KG).And("@PRECIO_BASE_PASAJE", recorrido.PRECIO_BASE_PASAJE)
            .Arguments);
        }

        private void InsertarRecorrido(Recorrido recorrido)
        {
            var recorridoeId = SqlDataAccess.ExecuteScalarQuery<int>(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.INSERTAR_RECORRIDO", SqlDataAccessArgs
                .CreateWith("@CIUDAD_ORIGEN", recorrido.CIUDAD_ORIGEN).And("@CIUDAD_DESTINO", recorrido.CIUDAD_DESTINO).And("@TIPO_SERVICIO", recorrido.TIPO_SERVICIO).
                And("@PRECIO_BASE_KG", recorrido.PRECIO_BASE_KG).And("@PRECIO_BASE_PASAJE", recorrido.PRECIO_BASE_PASAJE)
            .Arguments);
            recorrido.RECORRIDO_CODIGO = recorridoeId;
        }




        public int getIDRecorrido(string origen, string destino, string tipoServicio)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                  "ACTITUD_GDD.IDRecorrido", SqlDataAccessArgs
                  .CreateWith("@CIUDAD_ORIGEN",origen).And("@CIUDAD_DESTINO", destino).And("@TIPO_SERVICIO", tipoServicio)
              .Arguments);

           return int.Parse(resultado.Rows[0]["CODIGO_RECORRIDO"].ToString());
        }
    }
}
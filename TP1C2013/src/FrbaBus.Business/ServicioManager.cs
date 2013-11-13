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
    public class ServicioManager
    {

        public BindingList<Servicio> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARSERVICIOS");
            var servicios = new BindingList<Servicio>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    servicios.Add(new Servicio()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        TIPO_SERVICIO = row["TIPO_SERVICIO"].ToString(),
                        RECARGO = float.Parse(row["RECARGO"].ToString())
                    });


                }

            }
            return servicios;

        }




        public BindingList<Servicio> getAllCiudadOrigenDestino(string origen, string destino)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarServiciosCiudadOrigenDestino",
                SqlDataAccessArgs.CreateWith("@CIUDAD_ORIGEN",origen).And("@CIUDAD_DESTINO",destino).Arguments);
            var servicios = new BindingList<Servicio>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    servicios.Add(new Servicio()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        TIPO_SERVICIO = row["TIPO_SERVICIO"].ToString(),
                        RECARGO = float.Parse(row["RECARGO"].ToString())
                    });


                }

            }
            return servicios;
        }
    }
}

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
    public class CiudadManager
    {


        public BindingList<Ciudad> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARCIUDADES");
            var ciudades = new BindingList<Ciudad>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    ciudades.Add(new Ciudad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });


                }

            }
            return ciudades;

        }


        public BindingList<Ciudad> GetAllMenosCiudad(String ciudad)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARCIUDADESMENOSCIUDAD",
                SqlDataAccessArgs.CreateWith("@CIUDAD", ciudad).Arguments);
            var ciudades = new BindingList<Ciudad>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    ciudades.Add(new Ciudad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });


                }

            }
            return ciudades;

        }


        public BindingList<Ciudad> getAllSaliendoDe(string ciudad)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARCIUDADESSALIENDODE",
                SqlDataAccessArgs.CreateWith("@CIUDAD", ciudad).Arguments);
            var ciudades = new BindingList<Ciudad>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    ciudades.Add(new Ciudad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });


                }

            }
            return ciudades;
        }

        public BindingList<Ciudad> GetAllRecorrido()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARCIUDADESCONRECORRIDO");
            var ciudades = new BindingList<Ciudad>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    ciudades.Add(new Ciudad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });


                }

            }
            return ciudades;
        }
    }
}

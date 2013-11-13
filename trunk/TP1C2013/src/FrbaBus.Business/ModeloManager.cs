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
    public class ModeloManager
    {

        public BindingList<Modelo> GetAll()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARMODELOS");
            var modelos = new BindingList<Modelo>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    modelos.Add(new Modelo()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        MODELO = row["MODELO"].ToString(),
                        MARCA = row["MARCA"].ToString()
                    });


                }

            }
            return modelos;

        }

        public BindingList<String> GetAllMarcassQueTengaModelo(String modelo)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARMARCASDEMODELO", 
                SqlDataAccessArgs.CreateWith("@MODELO",modelo).Arguments);
            var marcas = new BindingList<String>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    marcas.Add(row["MARCA"].ToString());
                }

            }
            return marcas;

        }
        public BindingList<String> GetAllModelosQueTengaMarca(String marca)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARMODELOSDEMARCA", 
                SqlDataAccessArgs.CreateWith("@MARCA",marca).Arguments);
            var modelos = new BindingList<String>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    modelos.Add(row["MODELO"].ToString());
                }

            }
            return modelos;

        }



    }
}

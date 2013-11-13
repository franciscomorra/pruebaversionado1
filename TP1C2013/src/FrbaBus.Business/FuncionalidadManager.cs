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
    public class FuncionalidadManager
    {
        public BindingList<Funcionalidad> GetAll()
        {


            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarFuncionalidad");
            var funcionalidades = new BindingList<Funcionalidad>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    funcionalidades.Add(new Funcionalidad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });


                }

            }

            return funcionalidades;

        }



        public void BorrarFuncionalidades(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.BORRAR_ROL_FUNCIONALIDADES", SqlDataAccessArgs
                .CreateWith("@ROL_ID", rol.ID)
            .Arguments);
        }

        public void InsertarFuncionalidades(Rol rol, Funcionalidad  funcionalidad)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.INSERTARFUNCIONALIDADES", SqlDataAccessArgs
                .CreateWith("@ROL_ID", rol.ID)
                .And("@FUNCIONALIDAD", funcionalidad.NOMBRE)
            .Arguments);
        }

     public List<Funcionalidad> ObtenerFuncionalidadesDelRol(int id)
        {
            var retorno = new List<Funcionalidad>();
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.FUNCIONALIDADESDELROL", SqlDataAccessArgs
                .CreateWith("@ROL_ID", id)
            .Arguments);

            if (resultado != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var permission = row["Descripcion"].ToString();
                    var enumItem = (Funcionalidad)Enum.Parse(typeof(Funcionalidad), permission);
                    retorno.Add(enumItem);
                }
            }

            return retorno;
        }
    }
}

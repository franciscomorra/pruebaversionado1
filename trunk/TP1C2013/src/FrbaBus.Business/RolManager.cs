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
    public class RolManager
    {

        public BindingList<Rol> GetAll()
        {


            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarRol");
            var roles = new BindingList<Rol>();

            if (resultado != null && resultado.Rows != null)
            {

                foreach (DataRow row in resultado.Rows)
                {
                    roles.Add(new Rol(){
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString(),
                        BAJA_LOGICA = Convert.ToBoolean(row["BAJA_LOGICA"]),
                       Funcionalidades = GetFuncionalidades(int.Parse(row["ID"].ToString()))
                    });

                        
                    }

                }

            return roles;

            }


        private List<Funcionalidad> GetFuncionalidades(int id)
        {
            var retorno = new List<Funcionalidad>();
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.FuncionalidadesRol",
                SqlDataAccessArgs.CreateWith("@ID_ROL", id).Arguments);
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    retorno.Add(new Funcionalidad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString()
                    });
                }
            }
            return retorno;
        }

        public void SalvarRol(Rol rol)
        {
            if (rol.ID > 0) UpdatearRol(rol);
            else InsertarRol(rol);
        }

        private void UpdatearRol(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ACTUALIZARROL", SqlDataAccessArgs
                .CreateWith("@NOMBRE", rol.NOMBRE)
                .And("@ID", rol.ID)
            .Arguments);

            ActualizarFuncionesDelRol(rol);
        }


        private void ActualizarFuncionesDelRol(Rol rol)
        {
            var manager = new FuncionalidadManager();
            if (rol.ID > 0)
                manager.BorrarFuncionalidades(rol);
            foreach (var funcionalidad in rol.Funcionalidades)
            {
                manager.InsertarFuncionalidades(rol, funcionalidad);
            }
        }

        private void InsertarRol(Rol rol)
        {
            var roleId = SqlDataAccess.ExecuteScalarQuery<int>(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.INSERTAR_ROL", SqlDataAccessArgs
                .CreateWith("@NOMBRE", rol.NOMBRE)
            .Arguments);
            rol.ID = roleId;

            ActualizarFuncionesDelRol(rol);
        }

        public void BorrarRol(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.ELIMINAR_ROL", SqlDataAccessArgs
                .CreateWith("@ROL_ID", rol.ID)
            .Arguments);
        }


        public void habilitarRol(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.HABILITAR_ROL", SqlDataAccessArgs
                .CreateWith("@ROL_ID", rol.ID)
            .Arguments);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;
using Data;
using System.Configuration;
using System.Data;
using System.ComponentModel;
using System.Security.Cryptography;

namespace FrbaBus.Business
{
    public class UsuarioManager
    {
        public Usuario loguearse(string usuario, string contrasenia)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(contrasenia);
            SHA256 shaM = new SHA256Managed();

             byte[] hash = shaM.ComputeHash(bytes);


             string hashString = string.Empty;
             foreach (byte x in hash)
             {
                 hashString += String.Format("{0:x2}", x);
             }

           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LOGUEARSE",
               SqlDataAccessArgs.CreateWith("@USUARIO",usuario).And("@CONTRASENIA",hashString).Arguments);

           if (resultado != null ){

               Usuario user = new Usuario();

               if (!(resultado.Rows[0].IsNull("FUNCIONALIDAD"))){
                   BindingList<String> funcionalidades = new BindingList<string>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        user.FUNCIONALIDADES.Add(row["FUNCIONALIDAD"].ToString());
                    } 
               }
               user.Estado = int.Parse(resultado.Rows[0]["ESTADO"].ToString());
               user.ID = int.Parse(resultado.Rows[0]["ID"].ToString());

               return user;
           } else {
               return null;
           }
        }

        public Usuario funcionalidadesDefecto()
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.LISTARFUNCIONALIDADESKIOSKO");
            Usuario user = new Usuario();
            if (resultado != null)
            {
                BindingList<String> funcionalidades = new BindingList<string>();
                foreach (DataRow row in resultado.Rows)
                {
                    user.FUNCIONALIDADES.Add(row["FUNCIONALIDAD"].ToString());
                }
            }
            user.ID = -1;
            return user;
        }

        public BindingList<String> funcionalidadesUsuario(int ID)
        {
            
           var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.RECARGARFUNCIONALIDADES",
               SqlDataAccessArgs.CreateWith("@USUARIO",ID).Arguments);

           BindingList<String> funcionalidades = new BindingList<string>();
           if (resultado != null ){

                    foreach (DataRow row in resultado.Rows)
                    {
                        funcionalidades.Add(row["FUNCIONALIDAD"].ToString());
                    } 
           }

               return funcionalidades;
           
        }

        }
}

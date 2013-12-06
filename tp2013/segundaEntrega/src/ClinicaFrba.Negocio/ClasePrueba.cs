using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Configuration;

namespace ClinicaFrba.Negocio
{
    public class ClasePrueba
    {
        public int funcionprueba()
        {
            /*
             * var result2 = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
       "dbo.GetClients"); 
            
            DataRow result1 = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "Login", SqlDataAccessArgs
                .CreateWith("@Nombre", "asd")
                .And("@Password", "asdads")
                .Arguments);
            */
            string config = ConfigurationManager.ConnectionStrings["StringConexion"].ToString();
            //throw new Exception(config);

            //var result = SqlDataAccess.ExecuteScalarQuery<object>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            var result = SqlDataAccess.ExecuteScalarQuery<object>("Data Source=localhost\\SQLSERVER2008;Initial Catalog=dbABM;user=sa;password=gestiondedatos",
            "GetUserLoginAttempts", SqlDataAccessArgs
            .CreateWith("@Nombre", "asd")
            .Arguments);

            if (result == null)
                throw new Exception("Usuario o contraseña inválidos");

            if (int.Parse(result.ToString()) == 3)
            {
                throw new Exception("Usuario Bloqueado, contacte al administrador del sistema");
            }
            else
            {
                return int.Parse(result.ToString());
            }
        }
    }
}

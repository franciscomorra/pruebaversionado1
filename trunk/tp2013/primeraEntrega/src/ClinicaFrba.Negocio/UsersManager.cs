using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace ClinicaFrba.Negocio
{
    public class UsersManager
    {
        public int insertarUsuario(User user)
        {
            var transaction = SessionData.Contains("Transaction") ? SessionData.Get<SqlTransaction>("Transaction") : null;
            var service = new LoginService();
            var encryptedPass = service.ComputeHash("w23e", new SHA256Managed()); 
            int result = 0;
            if (transaction != null)//Si usa la transaccion
            {
                 result = SqlDataAccess.ExecuteScalarQuery<int>(
                     "[SHARPS].InsertUser", SqlDataAccessArgs
                    .CreateWith("@UserName", user.UserName)
                    .And("@Password", encryptedPass)
                .Arguments, transaction);
                return result;
            }
            else//Sin transaccion
            {
                 result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].InsertUser", SqlDataAccessArgs
                    .CreateWith("@UserName", user.UserName)
                    .And("@Password", encryptedPass)
                .Arguments);
                return result;
            }
        }
    }
}

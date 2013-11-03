using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Data.SqlClient;
//SHA256CryptoServiceProvider tira error de compilacion, SHA256Managed funciona
namespace ClinicaFrba.Negocio
{
    public class UsersManager
    {
        public void DeleteAccount(User user)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "DeleteUser", SqlDataAccessArgs
                .CreateWith("@User_ID", user.UserID)
            .Arguments);
        }

        public int CreateAccount(User user, string password)
        {
            var transaction = SessionData.Contains("Transaction") ? SessionData.Get<SqlTransaction>("Transaction") : null;
            var service = new LoginService();
            var encryptedPass = service.ComputeHash(password, new SHA256Managed());
            int result = 0;
            if (transaction != null)
            {
                 result = SqlDataAccess.ExecuteScalarQuery<int>(
                     "InsertUser", SqlDataAccessArgs
                    .CreateWith("@UserName", user.UserName)
                    .And("@Password", encryptedPass)
                .Arguments, transaction);
                return result;
            }
            else
            {
                 result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "InsertUser", SqlDataAccessArgs
                    .CreateWith("@UserName", user.UserName)
                    .And("@Password", encryptedPass)
                .Arguments);
                return result;
            }
        }
    }
}

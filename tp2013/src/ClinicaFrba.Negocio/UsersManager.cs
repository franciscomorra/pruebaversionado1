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
        public void DeleteAccount(User user)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.DeleteUser", SqlDataAccessArgs
                .CreateWith("@User_ID", user.UserID)
            .Arguments);
        }

        public int CreateAccount(User user, string password)
        {
            var service = new LoginService();
            var encryptedPass = service.ComputeHash(password, new SHA256CryptoServiceProvider());
            var result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.InsertUser", SqlDataAccessArgs
                .CreateWith("@UserName", user.UserName)
                .And("@Password", encryptedPass)
            .Arguments);
            return result;
        }
    }
}

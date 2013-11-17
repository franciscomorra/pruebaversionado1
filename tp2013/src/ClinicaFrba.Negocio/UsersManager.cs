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
            var service = new LoginService();
            var encryptedPass = service.ComputeHash("w23e", new SHA256Managed()); 
            int result = 0;
             result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertUser", SqlDataAccessArgs
                .CreateWith("@UserName", user.UserName)
                .And("@Password", encryptedPass)
            .Arguments);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;



namespace ClinicaFrba.Negocio
{
    public class LoginService
    {
       public User Login(string userName, string password)//Desafia con user y password a db, si correcto, devuelve usuario
        {
            this.ValidateLockedUser(userName);

            var encryptedPassword = ComputeHash(password, new SHA256Managed());
            DataRow result = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "Login", SqlDataAccessArgs
                .CreateWith("@Nombre", userName)
                .And("@Password", encryptedPassword)
                .Arguments);

            if (result == null)
                throw new Exception("Usuario o contraseña inválidos");
            var user = new User()
            {
                UserID = int.Parse(result["ID"].ToString()),
                UserName = result["Nombre"].ToString(),
                //FaltanDatos = result["Estado"].ToString(),
                FaltanDatos = "false"
            };

            return user;
        }

        public bool UpdateUserPassword(User user, string oldPassword, string newPassword)
        {
            var encryptedOldPassword = ComputeHash(oldPassword, new SHA256Managed());
            var encryptedNewPassword = ComputeHash(newPassword, new SHA256Managed());
            var result = SqlDataAccess.ExecuteScalarQuery<object>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "UpdateUserPassword", SqlDataAccessArgs
                .CreateWith("@ID_Usuario", user.UserID)
                .And("@OldPassword", encryptedOldPassword)
                .And("@NewPassword", encryptedNewPassword)
            .Arguments);

            return (result != null);
        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

   
        private void ValidateLockedUser(string userName)//Validar si esta bloqueado
        {
                
            var result = SqlDataAccess.ExecuteScalarQuery<object>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "GetUserLoginAttempts", SqlDataAccessArgs
                .CreateWith("@Nombre", userName)
            .Arguments);

            if (result == null)
                throw new Exception("Usuario o contraseña inválidos");

            if (int.Parse(result.ToString()) == 3)
                throw new Exception("Usuario Bloqueado, contacte al administrador del sistema");
        }

        public BindingList<Rol> GetUserRoles(int userID)//Buscar los roles de un usuario
        {//21124787
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "GetUserRoles", SqlDataAccessArgs
                .CreateWith("@userID", userID).Arguments);

            var roles = new BindingList<Rol>();

            if (result != null && result.Rows != null)
            {

                foreach (DataRow row in result.Rows)
                {
                    var rol = new Rol()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Nombre = row["Descripcion"].ToString()
                    };
                    rol.Perfil = new Profile();
                    rol.Perfil.ID = int.Parse(row["PerfilId"].ToString());
                    rol.Perfil.Nombre = row["PerfilNombre"].ToString();
                    roles.Add(rol);
                }
            }

            return roles;
        }


        public void SetUserFunctionalities(User user)
        {
            
            var manager = new FunctionalitiesManager();
            var functionalities = manager.GetRoleFunctionalities(user.RoleID);

            foreach (var functionality in functionalities)
            {
                user.Permissions.Add(functionality);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Data;

namespace ClinicaFrba.Negocio
{
    public class FunctionalitiesManager
    {
        /*
        public List<Functionalities> GetAllFunctionalities()
         * Devuelve una lista con las funcionalidades listada en la clase functionalities 
        public void DeleteRoleFunctionalities(Rol rol)
         * usa el procedimiento DeleteRoleFunctionalities de SQL, borra las funcionalidades de un rol
         * Requiere id de rol
        public void InsertRoleFunctionality(Rol rol, Functionalities functionality)
         * usa el procedimiento InsertRoleFunctionality de SQL, inserta funcionalidades de un rol
         * Requiere id de rol y la funcionalidad
        public List<Functionalities> GetRoleFunctionalities(int roleId)
         * usa el procedimiento GetRoleFunctionalities de SQL, para un rol saca todas las funcionalidades
         * Requiere id de rol y la funcionalidad
         */


        public List<Functionalities> GetAllFunctionalities()//Devuelve una lista con las funcionalidades existentes (son 15)
        {
            return Enum.GetValues(typeof(Functionalities)).Cast<Functionalities>().ToList();
        }

        public void DeleteRoleFunctionalities(Rol rol)//Borra las funcionalidades de un rol
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].DeleteRoleFunctionalities", SqlDataAccessArgs
                .CreateWith("@Rol_ID", rol.ID)
            .Arguments);
        }

        public void InsertRoleFunctionality(Rol rol, Functionalities functionality)//Inserta las funcionalidades a un rol
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertRoleFunctionality", SqlDataAccessArgs
                .CreateWith("@Rol_ID", rol.ID)
                .And("@Funcionalidad", functionality.ToString())
            .Arguments);
        }

        public List<Functionalities> GetRoleFunctionalities(int roleId)//Saca las funcionalidades de un rol
        {
            var ret = new List<Functionalities>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetRoleFunctionalities", SqlDataAccessArgs
                .CreateWith("@Rol_ID", roleId)
            .Arguments);

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    var permission = row["Descripcion"].ToString();
                    var enumItem = (Functionalities)Enum.Parse(typeof(Functionalities), permission);
                    ret.Add(enumItem);
                }
            }

            return ret;
        }
        public List<Functionalities> GetProfileFunctionalities(int profileId)//Saca las funcionalidades de un rol
        {
            var ret = new List<Functionalities>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetProfileFunctionalities", SqlDataAccessArgs
                .CreateWith("@Perfil_Id", profileId)
            .Arguments);

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    var permission = row["Descripcion"].ToString();
                    var enumItem = (Functionalities)Enum.Parse(typeof(Functionalities), permission);
                    ret.Add(enumItem);
                }
            }

            return ret;
        }
    }
}

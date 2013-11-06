using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Configuration;
using System.Data;
using ClinicaFrba.Comun;
using System.ComponentModel;


namespace ClinicaFrba.Negocio
{
    public class ProfileManager
    {
        public List<Profile> GetAllProfiles()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfiles"
            );
            var perfiles = new List<Profile>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Profile()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    //Functionalities = functionalitiesManager.GetProfileFunctionalities(int.Parse(row["ID"].ToString()))

                };
                perfiles.Add(profile);
            }

            return perfiles;
        }

        public Profile getInfo(string NombrePerfil) 
        {
            Profile perfil = new Profile();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetProfileInfo", SqlDataAccessArgs
                .CreateWith("@NombrePerfil", NombrePerfil)
                .Arguments);

            if (row != null)
            {
                perfil.Nombre = NombrePerfil;
                perfil.ID = int.Parse(row["PerfilId"].ToString());
                //perfil.Functionalities = functionalitiesManager.GetProfileFunctionalities(int.Parse(row["ID"].ToString()))
            }
            return perfil;
        }
    }
}

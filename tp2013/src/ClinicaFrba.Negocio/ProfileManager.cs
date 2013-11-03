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
        public BindingList<Profile> GetAllProfiles()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "GetPerfiles"
            );
            var perfiles = new BindingList<Profile>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Profile()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    Functionalities = functionalitiesManager.GetProfileFunctionalities(int.Parse(row["ID"].ToString()))

                };
                perfiles.Add(profile);
            }

            return perfiles;
        }
    }
}

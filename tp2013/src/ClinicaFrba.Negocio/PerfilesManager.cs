using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Data;
using System.ComponentModel;

namespace ClinicaFrba.Negocio
{
    public class PerfilesManager
    {
        public List<Perfil> GetAllPerfiles()
        {
            return Enum.GetValues(typeof(Perfil)).Cast<Perfil>().ToList();
        }

        public List<Perfil> GetRegistrationPerfiles()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.GetPerfiles"
            );
            var perfiles = new BindingList<Perfil>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var perfil = new Perfil()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    //Perfil = row["Perfil"].ToString(),
                    Functionalities = functionalitiesManager.GetPerfilFunctionalities(int.Parse(row["ID"].ToString()))

                };
                perfiles.Add(perfil);
            }

            return perfiles;
            /*
            var items = Enum.GetValues(typeof(Profile)).Cast<Profile>().ToList();
            items.Remove(Profile.Administrador);
            return items;
             */
        }
    }
}

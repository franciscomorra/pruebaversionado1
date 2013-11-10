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
    public class PerfilManager
    {
        public List<Perfil> GetAllPerfils()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfiles"
            );
            var perfiles = new List<Perfil>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Perfil()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    //Functionalities = functionalitiesManager.GetPerfilFunctionalities(int.Parse(row["ID"].ToString()))

                };
                perfiles.Add(profile);
            }

            return perfiles;
        }

        public List<Perfil> GetAllPerfilsForRegistration()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfiles"
            );
            var perfiles = new List<Perfil>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Perfil()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    //Functionalities = functionalitiesManager.GetPerfilFunctionalities(int.Parse(row["ID"].ToString()))

                };
                if(profile.Nombre == "Afiliado" || profile.Nombre == "Profesional")
                    perfiles.Add(profile);
            }

            return perfiles;
        }

        public Perfil getInfo(string NombrePerfil) 
        {
            Perfil perfil = new Perfil();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfilInfo", SqlDataAccessArgs
                .CreateWith("@NombrePerfil", NombrePerfil)
                .Arguments);

            if (row != null)
            {
                perfil.Nombre = NombrePerfil;
                perfil.ID = int.Parse(row["PerfilId"].ToString());
                //perfil.Functionalities = functionalitiesManager.GetPerfilFunctionalities(int.Parse(row["ID"].ToString()))
            }
            return perfil;
        }
    }
}

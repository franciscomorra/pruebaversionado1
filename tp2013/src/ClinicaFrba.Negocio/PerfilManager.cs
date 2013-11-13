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
        public List<Perfil> GetAllPerfiles()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfiles"
                //Devuelve todos los perfiles
            );
            var perfiles = new List<Perfil>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Perfil()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                };
                perfiles.Add(profile);
            }

            return perfiles;
        }

        public List<Perfil> GetAllPerfilesForRegistration()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetPerfiles"

                //Devuelve todos los perfiles
            );
            var perfiles = new List<Perfil>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var profile = new Perfil()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                };
                if(profile.Nombre == "Afiliado" || profile.Nombre == "Profesional")
                    //Filtro los que se pueden registrar (hoy son estos dos nomas)
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
                
            //Dado un nombre de perfil, dame el ID
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

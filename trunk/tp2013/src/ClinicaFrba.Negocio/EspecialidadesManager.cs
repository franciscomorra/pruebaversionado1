using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Data;
using ClinicaFrba.Comun;
using System.Data;

namespace ClinicaFrba.Negocio
{
    public class EspecialidadesManager
    {

        public List<Especialidad> GetAllForUser(int userID)
        {
            var ret = new List<Especialidad>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetEspecialidadesForUser", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new Especialidad()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Nombre = row["Descripcion"].ToString()
                    });

                }
            }
            return ret;
        }
        public List<Especialidad> GetAll()
        {
            if (SessionData.Contains("Especialidades"))
            {
                return SessionData.Get<List<Especialidad>>("Especialidades");
            }
            var ret = new List<Especialidad>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAllEspecialidades");
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new Especialidad() { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Nombre = row["Descripcion"].ToString() });
                        
                }
            }
            SessionData.Set("Especialidades", ret);
            return ret;
        }
    }
}

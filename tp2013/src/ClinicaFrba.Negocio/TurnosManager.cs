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
    public class TurnosManager
    {
        public List<Turno> GetAll(int userID)
        {
            var ret = new List<Turno>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetTurnos", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new Turno()
                    {
                        Fecha = Convert.ToDateTime(row["Fecha"]),
                        Numero = int.Parse(row["Numero"].ToString()),
                        Profesional = new Profesional() {
                            UserID = int.Parse(row["UserProfesional"].ToString()),
                            Matricula = row["Matricula"].ToString(),

                        },

                    });

                }
            }
            return ret;
        }
    }
}

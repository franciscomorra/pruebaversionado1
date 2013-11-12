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
        public List<Turno> GetAll(Afiliado afiliado,bool soloTurnosHoy)
        {
            var ret = new List<Turno>();
            DataTable resultado;

            if(soloTurnosHoy)
                 resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].GetTurnosAfiliadoDate", SqlDataAccessArgs
                    .CreateWith("@profesionalID", afiliado.UserID)
                    .And("@fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]))
                    .Arguments);
            else
                 resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].GetAllAfiliadoTurnos", SqlDataAccessArgs
                    .CreateWith("@userId", afiliado.UserID)
                    .Arguments);

            if (resultado != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    ret.Add(new Turno()
                    {
                        Fecha = Convert.ToDateTime(row["Fecha"]),
                        Numero = int.Parse(row["Numero"].ToString()),
                        Profesional = new Profesional() {
                            UserID = int.Parse(row["UserProfesional"].ToString()),
                            Matricula = row["Matricula"].ToString(),
                        },
                        Afiliado = afiliado
                    });
                }
            }
            return ret;
        }

        public List<Turno> GetTurnosForFecha(Profesional profesional, DateTime fecha)
        {

            List<Turno> ret = new List<Turno>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetTurnosByProfesional", SqlDataAccessArgs
                .CreateWith("@profesionalID", profesional.UserID)
                .And("@fecha",fecha)
                .Arguments);
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    /*
                    fecha1.= int.Parse(row["Hora"].ToString());
                    fecha.Minute = int.Parse(row["Minuto"].ToString());
                    ret.Add(fecha);
                    */
                }
            }
            return ret;
        }
        public void SaveTurno(Turno turno) {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertTurno", SqlDataAccessArgs
                .CreateWith(
                    "@Fecha", turno.Fecha.ToString())
                    .And("@Profesional_ID", turno.Profesional.UserID)
                    .And("@Afiliado_ID", turno.Afiliado.UserID)
            .Arguments);
        }
        public void RegistrarLlegada(Turno turno,Bono bono)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].RegistrarLlegada", SqlDataAccessArgs
                .CreateWith(
                    "@HoraLlegada", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]))
                    .And("@Turno", turno.Numero)
                    .And("@Bono_Consulta", bono.Numero)
            .Arguments);
        }
        public void CancelarTurno(Turno turno)
        {
            
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].RegistrarLlegada", SqlDataAccessArgs
                .CreateWith(
                    "@HoraLlegada", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]))
                    .And("@Profesional_ID", turno.Profesional.UserID)
                    .And("@Afiliado_ID", turno.Afiliado.UserID)
            .Arguments);
        }
    }
}

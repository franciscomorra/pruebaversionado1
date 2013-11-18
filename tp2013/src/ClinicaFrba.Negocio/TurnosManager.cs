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
        public List<Turno> GetAll(Afiliado afiliado,bool soloTurnosHoy, Profesional profesional)
        {
            var ret = new List<Turno>();
            DataTable resultado;
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].GetAllAfiliadoTurnos", SqlDataAccessArgs
                    .CreateWith("@userId", afiliado.UserID)
                    .And("@fecha", fechaActual)
                    .Arguments);
                //Todos los turnos del afiliado, desde la fecha de hoy

            if (resultado != null)
            {
                ProfesionalManager profMan = new ProfesionalManager();
                foreach (DataRow row in resultado.Rows)
                {
                    
                    Turno turno = new Turno();
                    turno.Fecha = Convert.ToDateTime(row["Fecha"]);
                    turno.Numero = int.Parse(row["Numero"].ToString());
                    turno.Profesional = profMan.getInfo(int.Parse(row["UserProfesional"].ToString()));
                     turno.Afiliado = afiliado;
                    if(!soloTurnosHoy || (soloTurnosHoy && turno.Fecha.Date == fechaActual.Date))
                        if(profesional == null || (profesional.UserID == turno.Profesional.UserID))
                            ret.Add(turno);
                }
            }
            return ret;
        }

        public List<Turno> GetDiasHorariosLibres(Profesional profesional, DateTime fecha)
        {

            List<Turno> ret = new List<Turno>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAgendaByProfesional", SqlDataAccessArgs
                .CreateWith("@profesionalID", profesional.UserID)
                .And("@fecha",fecha)
                .Arguments);
            //Debe devolver las horas que tiene libre el profesional ese dia
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Turno turno = new Turno();
                    turno.Fecha = Convert.ToDateTime(row["Fecha"]);
                    //turno.Numero = int.Parse(row["Numero"].ToString());
                    turno.Profesional = profesional;
                    ret.Add(turno);
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
            //Turno nuevo
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
            //Ingresa la hora de llegada (guarda toda la fecha por si los horarios de la clinica cambian algun dia)
        }
        public void CancelarTurno(Turno turno)
        {
            
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].CancelarTurnoAfiliado", SqlDataAccessArgs
                .CreateWith(
                    "@turno", turno.Numero)
                    .Arguments);
            //Cancela un turno por parte del afiliado, motivo es cancelado por afiliado
        }
    }
}

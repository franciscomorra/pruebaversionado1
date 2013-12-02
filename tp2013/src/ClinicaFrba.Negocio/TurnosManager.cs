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
        public List<Turno> BuscarTodos(Afiliado afiliado,bool soloTurnosHoy, Profesional profesional)
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
        public List<Turno> BuscarConConsulta(Afiliado afiliado, bool soloTurnosHoy, Profesional profesional)
        {
            var ret = new List<Turno>();
            DataTable resultado;
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].GetAfiliadoTurnosConsulta", SqlDataAccessArgs
                    .CreateWith("@userId", afiliado.UserID)
                    .And("@fecha", fechaActual)
                    .Arguments);
            //Todos los turnos del afiliado, en la fecha de hoy, que tienen consulta asociada

            if (resultado != null)
            {
                ProfesionalManager profMan = new ProfesionalManager();
                foreach (DataRow row in resultado.Rows)
                {
                    Turno turno = new Turno();
                    turno.Fecha = Convert.ToDateTime(row["Fecha"]);
                    turno.Numero = int.Parse(row["Numero"].ToString());
                    turno.NroConsulta = int.Parse(row["NROCONSULTA"].ToString());
                    turno.Profesional = profMan.getInfo(int.Parse(row["UserProfesional"].ToString()));
                    turno.Afiliado = afiliado;
                    if (!soloTurnosHoy || (soloTurnosHoy && turno.Fecha.Date == fechaActual.Date))
                        if (profesional == null || (profesional.UserID == turno.Profesional.UserID))
                            ret.Add(turno);
                }
            }
            return ret;
        }



        public List<Turno> BuscarHorariosLibres(Profesional profesional, DateTime fecha)
        {
            List<Turno> ret = new List<Turno>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAgendaByProfesional", SqlDataAccessArgs
                .CreateWith("@profesionalID", profesional.UserID)
                .And("@fecha",fecha)
                .Arguments);//Debe devolver las horas que tiene libre el profesional ese dia
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Turno turno = new Turno();
                    turno.Fecha = Convert.ToDateTime(row["Fecha"]);
                    turno.Profesional = profesional;
                    ret.Add(turno);
                }
            }
            return ret;
        }


        public List<Turno> BuscarTurnosProfesional(Profesional profesional, DateTime fecha)
        {
            List<Turno> ret = new List<Turno>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetTurnosByProfesional", SqlDataAccessArgs
                .CreateWith("@profesionalID", profesional.UserID)
                .And("@fecha", fecha)
                .Arguments);
            //Devuelve los turnos que tiene un profesional asignados en una fecha

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Turno turno = new Turno();
                    turno.Fecha = Convert.ToDateTime(row["Fecha"]);
                    turno.Profesional = profesional;
                    ret.Add(turno);
                }
            }
            return ret;

        }
        public void GuardarTurno(Turno turno) {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertTurno", SqlDataAccessArgs
                .CreateWith(
                    "@Fecha", turno.Fecha)
                    .And("@Profesional_ID", turno.Profesional.UserID)
                    .And("@Afiliado_ID", turno.Afiliado.UserID)
            .Arguments);
            //Turno nuevo
        }
        public void RegistrarLlegada(Turno turno,Bono bono)
        {
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            
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

        public void CancelarDiaProfesional(int usuarioID, DateTime fecha)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].CancelarDiaProfesional", SqlDataAccessArgs
                //Busca todos los turnos del dia, y los pone como cancelado por profesional.
                //Deshabilita la agenda para que no se puedan cargar nuevos turnos ese dia
                .CreateWith("@Profesional", usuarioID)
                .And("@Fecha", fecha)
                .Arguments);
        }
    }
}

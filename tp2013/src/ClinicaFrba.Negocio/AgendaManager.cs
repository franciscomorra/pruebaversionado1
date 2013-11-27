using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Data.SqlClient;


namespace ClinicaFrba.Negocio
{
    public class AgendaManager
    {

        /*
       public void GuardarAgenda(Agenda agenda) {
           
           SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "[SHARPS].InsertAgendaProfesional", SqlDataAccessArgs
               .CreateWith(
                   "@FechaDesde", agenda.FechaDesde)
                   .And("@FechaHasta", agenda.FechaHasta)
                   .And("@LunesIN", agenda.LunesIN)
                   .And("@LunesOUT", agenda.LunesOUT)
                   .And("@MartesIN", agenda.MartesIN)
                   .And("@MartesOUT", agenda.MartesOUT)
                   .And("@MiercolesIN", agenda.MiercolesIN)
                   .And("@MiercolesOUT", agenda.MiercolesOUT)
                   .And("@JuevesIN", agenda.JuevesIN)
                   .And("@JuevesOUT", agenda.JuevesOUT)
                   .And("@ViernesIN", agenda.ViernesIN)
                   .And("@ViernesOUT", agenda.ViernesOUT)
                   .And("@SabadoIN", agenda.SabadoIN)
                   .And("@SabadoOUT", agenda.SabadoOUT)  
                   .And("@Profesional", agenda.profesional.UserID)  
         
           .Arguments);
           //Paso todos los dias de la semana, con sus horarios, y la fecha inicio y fin del rango
           //El procedimiento debe ir dia por dia, y guardar ese horario.
           //El horario va a ser null en algunos dias
           //Por cada dia, guardar cada media hora una entrada de la agenda
       }
       */
        public void GuardarAgenda(Agenda agenda, DateTime actual)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "[SHARPS].InsertAgendaProfesional", SqlDataAccessArgs
               .CreateWith(
                   "@Fecha", actual)
                   .And("@profesional", agenda.profesional.UserID)
               .Arguments);
        }

        public void BorrarRegistrosFueraDeRango(Profesional profesional, DateTime actual, DateTime horaIn, DateTime horaOut)
        {
            DateTime fecha = actual.Date;
            /*
            while (fecha.TimeOfDay < horaOut.TimeOfDay)
            {
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
              "[SHARPS].InsertAgendaProfesional", SqlDataAccessArgs
              .CreateWith(
                  "@Fecha", actual)
                  .And("@profesional", profesional.UserID)
              .Arguments);
            
            }
            */

        }
    }
}

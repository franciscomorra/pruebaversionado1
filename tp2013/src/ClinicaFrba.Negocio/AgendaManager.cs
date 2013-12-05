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
        public void GuardarAgenda(Agenda agenda, DateTime actual)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
               "[SHARPS].InsertAgendaProfesional", SqlDataAccessArgs
               .CreateWith(
                   "@Fecha", actual)
                   .And("@profesional", agenda.profesional.UserID)
               .Arguments);
        }

        public void LimpiarDia(Profesional profesional, DateTime actual)
        {
            //Busca las entradas de agenda de la fecha del profesional que estan libres, y las elimina
            
            DateTime fecha = actual.Date;
            TurnosManager turnosManager = new TurnosManager();
            List<Turno> agendaLibre = turnosManager.BuscarHorariosLibres(profesional, actual);
            foreach (Turno turnoLibre in agendaLibre) {
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].DeleteAgenda", SqlDataAccessArgs
                .CreateWith(
                    "@agendaID", turnoLibre.AgendaID)
                .Arguments);
            }
        }
    }
}

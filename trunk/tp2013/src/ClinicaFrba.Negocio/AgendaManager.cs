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
        public void GuardarAgenda(Agenda agenda)
        {
            TimeSpan diferenciaDias = agenda.FechaHasta - agenda.FechaDesde;
            
            for (int i = 0; i < diferenciaDias.Days; i++) {
                DateTime actual = agenda.FechaDesde.Date;
                actual = actual.AddDays(i);
                DateTime horain = new DateTime();
                DateTime horaout = new DateTime();

                switch(actual.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        horain = agenda.LunesIN;
                        horaout = agenda.LunesOUT;
                    break;
                    case DayOfWeek.Tuesday:
                        horain = agenda.MartesIN;
                        horaout = agenda.MartesOUT;
                        break;
                    case DayOfWeek.Wednesday:
                        horain = agenda.MiercolesIN;
                        horaout = agenda.MiercolesOUT;
                        break;
                    case DayOfWeek.Thursday:
                        horain = agenda.JuevesIN;
                        horaout = agenda.JuevesOUT;
                        break;
                    case DayOfWeek.Friday:
                        horain = agenda.ViernesIN;
                        horaout = agenda.ViernesOUT;
                        break;
                    case DayOfWeek.Saturday:
                        horain = agenda.SabadoIN;
                        horaout = agenda.SabadoOUT;
                        break;

                }
                actual = actual.AddHours(horain.Hour);
                if (horaout.TimeOfDay != horain.TimeOfDay)
                {
                    while (actual.TimeOfDay < horaout.TimeOfDay)
                    {
                        SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "[SHARPS].InsertDiaProfesional", SqlDataAccessArgs
                        .CreateWith(
                            "@Fecha", actual)
                            .And("@profesional", agenda.profesional.UserID)
                        .Arguments);


/*
USE [GD2C2013]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [SHARPS].[InsertDiaProfesional]
	@Fecha datetime,
	@Profesional int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM SHARPS.Agendas WHERE Profesional = @Profesional AND Horario > @Fecha 
    --Si tiene un turno asignado en la fecha, deberiamos cancelarlo, de alguna manera
	INSERT INTO SHARPS.Agendas(Horario,Profesional, Activo) VALUES (@Fecha,@Profesional,1)
	--SELECT @@Identity AS ID
END
*/

                        actual = actual.AddMinutes(30);
                    }
                }
            }
        }

    }
}

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
        public void GuardarAgenda(Agenda agenda) {
            /*
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
                                        
            .Arguments);
            */
        }



    }
}

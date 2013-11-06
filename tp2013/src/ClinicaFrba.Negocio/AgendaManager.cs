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

            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertAgendaProfesional", SqlDataAccessArgs
                .CreateWith(
                    "@FechaDesde", agenda.FechaDesde)
                    .And("@FechaHasta", agenda.FechaHasta)
                    .And("@Lunes", agenda.Lunes)
                    .And("@Martes", agenda.Martes)
                    .And("@Miercoles", agenda.Miercoles)
                    .And("@Jueves", agenda.Jueves)
                    .And("@Viernes", agenda.Viernes)
                    .And("@Sabado", agenda.Sabado)
            .Arguments);

        }



    }
}

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
    public class ConsultasManager
    {
        public void Save(Consulta consulta)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertConsulta", SqlDataAccessArgs
                .CreateWith(
                    "@Turno", consulta.Turno.Numero)
                    .And("@Sintomas", consulta.Sintomas)
                    .And("@Enfermedad", consulta.Enfermedad)
            .Arguments);
        }
    }
}
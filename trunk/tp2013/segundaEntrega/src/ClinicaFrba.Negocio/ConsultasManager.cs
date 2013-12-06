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
            //Guarda la consulta de un turno (Obs. Un turno fue atendido si solo si tiene una consulta asociada a el)
        }
        public Consulta getInfo(Turno turno)
        {
            Consulta consulta = new Consulta();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetConsultaInfo", SqlDataAccessArgs
                .CreateWith("@turno", turno.Numero)
                .Arguments);

            //Dado un nombre de perfil, dame el ID
            if (row != null)
            {
                consulta.Enfermedad = row["Enfermedad"].ToString();
                consulta.Sintomas = row["Sintomas"].ToString();
                consulta.Turno = turno;
                consulta.NumeroConsulta = int.Parse(row["Numero_Consulta"].ToString());
            }
            return consulta;
        }


    }
}
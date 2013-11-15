using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;

namespace ClinicaFrba.Negocio
{
    public class ReportesManager
    {
        public DataTable GetReporte(TipoReporte tipoReporte, DateTime fechaInicio, DateTime fechaFin)
        {
            return SqlDataAccess.ExecuteDataTableQuery
            (
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                tipoReporte.StoredProcedure, SqlDataAccessArgs
                .CreateWith("@fecha_inicio", fechaInicio)
                .And("@fecha_fin", fechaFin)
                .Arguments
            );
        }

        public BindingList<TipoReporte> GetReportTypes()
        {
            return new BindingList<TipoReporte>()
            {
                { new TipoReporte("[SHARPS].Get_TOPCancelaciones", "Top 5 de las especialidades que más se registraron cancelaciones, tanto de afiliados como de profesionales")},
                { new TipoReporte("[SHARPS].Get_TOPVencidos", "Top 5 de la cantidad total de bonos farmacia vencidos por afiliado.")},
                { new TipoReporte("[SHARPS].Get_TOPRecetados", "Top 5 de las especialidades de médicos con más bonos de farmacia recetados.")},
                { new TipoReporte("[SHARPS].Get_TOPVividores", "Top 10 de los afiliados que utilizaron bonos que ellos mismo no compraron")}
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Data;
using ClinicaFrba.Comun;
using System.Data;

namespace ClinicaFrba.Negocio
{
    public class PlanesMedicosManager
    {        
        public List<PlanMedico> GetAll()
        {
            var ret = new List<PlanMedico>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "GetPlanesMedicos");

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new PlanMedico() { 
                        ID = int.Parse(row["Codigo"].ToString()), 
                        Nombre = row["Descripcion"].ToString(),
                        PrecioConsulta = int.Parse(row["Precio_Bono_Consulta"].ToString()),
                        PrecioFarmacia = int.Parse(row["Precio_Bono_Farmacia"].ToString())
                    });
                }
            }

            return ret;
        }
    }
}

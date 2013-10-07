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
                "SHARPS.GetPlanesMedicos");

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new PlanMedico() { 
                        ID = int.Parse(row["codigo"].ToString()), 
                        Nombre = row["Descripcion"].ToString(), 
                        PrecioConsulta = int.Parse(row["precioConsulta"].ToString()), 
                        PrecioFarmacia = int.Parse(row["precioFarmacia"].ToString())
                    });
                }
            }

            return ret;
        }
    }
}

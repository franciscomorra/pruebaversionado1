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
    public class MedicamentosManager
    {
        public List<Medicamento> GetAll()
        {
            var ret = new List<Medicamento>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetMedicamentos");
            //Devuelve la tabla medicamentos entera
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new Medicamento()
                    {
                        Codigo = int.Parse(row["Numero"].ToString()),
                        Nombre = row["Nombre"].ToString()

                    });
                }
            }
            return ret;
        }
    }
}
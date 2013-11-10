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
    public class RecetasManager
    {
        public void Save(Receta receta)
        {

            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertReceta", SqlDataAccessArgs
                .CreateWith(
                    "@BonoFarmacia", receta.BonoFarmacia.Numero)
            .Arguments);

            foreach (var medicamento in receta.Medicamentos)
            {

                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].AgregarMedicamentos", SqlDataAccessArgs
                    .CreateWith(
                        "@BonoFarmacia", receta.BonoFarmacia.Numero)
                        .And("@BonoFarmacia",receta.BonoFarmacia)
                        .And("@Medicamento", medicamento.Codigo)
                .Arguments);
            
            }


        }
    }
}
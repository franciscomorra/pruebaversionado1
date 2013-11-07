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
    public class BonosManager
    {
        public List<Bono> GetAll(int userID)
        {
            var ret = new List<Bono>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetBonos", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    ret.Add(new Bono()
                    {
                        Fecha = Convert.ToDateTime(row["Fecha"]),
                        Numero = int.Parse(row["Numero"].ToString()),
                        Precio = int.Parse(row["Precio"].ToString()),
                        //TipoBono = 
                        AfiliadoCompro = new Afiliado()
                        {
                            UserID = int.Parse(row["UserIDAfiliado"].ToString()),
                        },

                    });

                }
            }
            return ret;
        }

        public int Comprar(Bono bono)
        {
            int result = 0;
            if(bono.TipodeBono == TipoBono.Consulta){
                result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].ComprarBonoConsulta", SqlDataAccessArgs
                   .CreateWith("@Precio", bono.Precio)
                   .And("@Fecha", bono.Precio)
                   .And("@AfiliadoCompro", bono.AfiliadoCompro.UserID)
               .Arguments);
                return result;
            }
            else{
                result = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].ComprarBonoReceta", SqlDataAccessArgs
                   .CreateWith("@Precio", bono.Precio)
                   .And("@Fecha", bono.Precio)
                   .And("@AfiliadoCompro", bono.AfiliadoCompro.UserID)
                .Arguments);
                return result;
            }
        
        }
    }
}
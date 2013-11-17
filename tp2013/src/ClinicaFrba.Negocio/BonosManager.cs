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
        public List<Bono> GetAll(Afiliado afiliado)
        {
            var ret = new List<Bono>();
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetBonos", SqlDataAccessArgs
                .CreateWith("@userId", afiliado.UserID)
                .And("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]))
                .Arguments);
            //Devuelve los bonos que no fueron usados
            //Los que son farmacia, debe devolver los que no estan vencidos
            //Para ambos, que devuelva todos los bonos del grupo familiar, no solo del usuario
            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    var tipoBono = row["TipoBono"].ToString();
                    ret.Add(new Bono()
                    {
                        Fecha = Convert.ToDateTime(row["Fecha"]),
                        Numero = int.Parse(row["Numero"].ToString()),
                        TipodeBono = (TipoBono)Enum.Parse(typeof(TipoBono), tipoBono),
                        AfiliadoCompro = afiliado,
                        Precio = int.Parse(row["Precio"].ToString()),
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
                   .And("@Fecha", bono.Fecha)
                   .And("@AfiliadoCompro", bono.AfiliadoCompro.UserID)
               .Arguments);
                //Guarda un bono, pasa la fecha de impresion, y el precio abonado (sale del plan, se guarda porque el plan puede variar sus precios)
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
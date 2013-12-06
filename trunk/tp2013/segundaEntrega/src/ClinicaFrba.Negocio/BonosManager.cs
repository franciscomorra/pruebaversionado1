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
            AfiliadoManager _afiliadoManager = new AfiliadoManager();
            var ret = new List<Bono>();
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetBonos", SqlDataAccessArgs
                .CreateWith("@userId", afiliado.UserID)
                .And("@Fecha", fechaActual)
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
                        AfiliadoCompro = _afiliadoManager.actualizarInformacion(int.Parse(row["comprador"].ToString())),
                        Precio = int.Parse(row["Precio"].ToString()),
                        Compra = int.Parse(row["CompraID"].ToString()),
                    });
                }
            }
            return ret;
        }
        public int Nueva_Compra(Afiliado afiliado)
        {
            DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            int numeroCompra = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "[SHARPS].InsertarCompra", SqlDataAccessArgs
            .CreateWith("@afiliadoID", afiliado.UserID)
            .And("@fecha", fechaActual)
            .And("@precioCons", afiliado.PlanMedico.PrecioConsulta)
            .And("@precioFar", afiliado.PlanMedico.PrecioFarmacia)
            .Arguments);
            //Inserta una compra
            return numeroCompra;
        }
        public void Comprar(Bono bono)
        {
            
            if(bono.TipodeBono == TipoBono.Consulta){
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].ComprarBonoConsulta", SqlDataAccessArgs
                   .CreateWith("@Precio", bono.Precio)
                   .And("@Fecha", bono.Fecha)
                   .And("@AfiliadoCompro", bono.AfiliadoCompro.UserID)
                   .And("@Compra", bono.Compra)
               .Arguments);
                //Guarda un bono, pasa la fecha de impresion, y el precio abonado (sale del plan, se guarda porque el plan puede variar sus precios)
            }
            else{
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].ComprarBonoReceta", SqlDataAccessArgs
                   .CreateWith("@Precio", bono.Precio)
                   .And("@Fecha", bono.Fecha)
                   .And("@AfiliadoCompro", bono.AfiliadoCompro.UserID)
                   .And("@Compra", bono.Compra)
                .Arguments);
            }
        }
    }
}
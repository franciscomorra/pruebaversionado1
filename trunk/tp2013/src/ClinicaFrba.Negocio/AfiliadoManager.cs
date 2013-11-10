using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using System.Data;
using System.Data.SqlClient;
using Data;
using System.Configuration;
using System.ComponentModel;

namespace ClinicaFrba.Negocio
{
    /// <summary>
    /// Gestiona las instancias de la clase Afiliado en el sistema
    /// </summary>
    public class AfiliadoManager
    {
        private UsersManager _usersManager = new UsersManager();
        public Afiliado getInfo(int userID) 
        {
            Afiliado afiliado = new Afiliado();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAfiliadoInfo", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            if (row != null && row != null)
            {
                //afiliado.UserID = int.Parse(row["ID"].ToString());
                afiliado.UserName = row["UserName"].ToString();
                afiliado.UserID = userID;
                //afiliado.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                afiliado.PlanMedico = new PlanMedico();
                afiliado.PlanMedico.ID = int.Parse(row["Plan_ID"].ToString());
                afiliado.PlanMedico.PrecioConsulta = int.Parse(row["PrecioConsulta"].ToString());
                afiliado.PlanMedico.PrecioFarmacia = int.Parse(row["PrecioFarmacia"].ToString());
                if (!DBNull.Value.Equals(row["EstadoCivil"]))
                    afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString());

                if (!DBNull.Value.Equals(row["CantHijos"]))
                    afiliado.CantHijos = int.Parse(row["CantHijos"].ToString());
                afiliado.DetallePersona = new DetallesPersona();
                afiliado.DetallePersona.Apellido = row["Apellido"].ToString();
                afiliado.DetallePersona.Nombre = row["Nombre"].ToString();
                afiliado.DetallePersona.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                afiliado.DetallePersona.DNI = long.Parse(row["DNI"].ToString());
                afiliado.DetallePersona.Email = row["Email"].ToString();
                afiliado.DetallePersona.Direccion = row["Direccion"].ToString();
                afiliado.DetallePersona.Telefono = long.Parse(row["Telefono"].ToString());
                if (!DBNull.Value.Equals(row["Sexo"]))
                    afiliado.DetallePersona.Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString());
                afiliado.DetallePersona.TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString());
                long grupoFamiliar = long.Parse(row["GrupoFamiliar"].ToString());
                long tipoAfiliado = long.Parse(row["TipoAfiliado"].ToString());
                afiliado.NroAfiliado = ((grupoFamiliar * 100) + tipoAfiliado);
                //afiliado.NroAfiliado = int.Parse(row["nroAfiliado"].ToString());
                afiliado.PlanMedico = new PlanMedico()
                {
                    ID = int.Parse(row["Plan_ID"].ToString()),
                    PrecioConsulta = int.Parse(row["PrecioConsulta"].ToString()),
                    PrecioFarmacia = int.Parse(row["PrecioFarmacia"].ToString())

                };
                afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString());
                afiliado.CantHijos = int.Parse(row["CantHijos"].ToString());
            }
            return afiliado;
        }
        
        /// <summary>
        /// Obtiene el listado de afiliados del sistema
        /// </summary>
        /// <returns>Listado de afiliados</returns>
        
        
        
        public BindingList<Afiliado> GetAll()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAfiliados");
            var afiliados = new BindingList<Afiliado>();
            if (result != null && result.Rows != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Afiliado afiliado = new Afiliado();
                    afiliado.UserID = int.Parse(row["ID"].ToString());
                    afiliado.UserName = row["UserName"].ToString();
                    //afiliado.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                    afiliado.PlanMedico = new PlanMedico();
                    afiliado.PlanMedico.ID = int.Parse(row["Plan_ID"].ToString());
                    afiliado.PlanMedico.PrecioConsulta = int.Parse(row["PrecioConsulta"].ToString());
                    afiliado.PlanMedico.PrecioFarmacia = int.Parse(row["PrecioFarmacia"].ToString());
                    if (!DBNull.Value.Equals(row["EstadoCivil"]))
                        afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString());

                    if (!DBNull.Value.Equals(row["CantHijos"])) 
                        afiliado.CantHijos = int.Parse(row["CantHijos"].ToString());
                    afiliado.DetallePersona = new DetallesPersona();
                    afiliado.DetallePersona.Apellido = row["Apellido"].ToString();
                    afiliado.DetallePersona.Nombre = row["Nombre"].ToString();
                    afiliado.DetallePersona.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                    afiliado.DetallePersona.DNI = long.Parse(row["DNI"].ToString());
                    afiliado.DetallePersona.Email = row["Email"].ToString();
                    afiliado.DetallePersona.Direccion = row["Direccion"].ToString();
                    afiliado.DetallePersona.Telefono = long.Parse(row["Telefono"].ToString());
                    if (!DBNull.Value.Equals(row["Sexo"])) 
                        afiliado.DetallePersona.Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString());
                    afiliado.DetallePersona.TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString());
                    long grupoFamiliar = long.Parse(row["GrupoFamiliar"].ToString());
                    long tipoAfiliado = long.Parse(row["TipoAfiliado"].ToString());
                    afiliado.NroAfiliado = ((grupoFamiliar*100) + tipoAfiliado);
                    afiliados.Add(afiliado);
                       
                }
            }
            return afiliados;
        }

        /// <summary>
        /// Guarda un afiliado en la base de datos
        /// </summary>
        public long GuardarAfiliado(Afiliado afiliado, string password)
        {
            var usersManager = new UsersManager();
            var entityDetailManager = new DetallePersonaManager();
            if (afiliado.UserID == 0)//NUEVO USUARIO
            {
               var transaction = SqlDataAccess.OpenTransaction(ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
               try
                {
                    afiliado.UserID = usersManager.CreateAccount(afiliado as User, password);
                    var detalleID = entityDetailManager.AddDetallePersona(afiliado as User);
                    if (afiliado.NroAfiliado == 0)//Primero del grupo familiar
                    {
                        afiliado.NroAfiliado = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                            "InsertAfiliado", SqlDataAccessArgs
                            .CreateWith("@PlanMedico", afiliado.PlanMedico)
                            .And("@ID", afiliado.UserID)
                            .And("@EstadoCivil", afiliado.EstadoCivil)
                            .And("@CantHijos", afiliado.CantHijos)
                            .Arguments);
                    }
                    else
                    {
                        afiliado.NroAfiliado = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "InsertMiembroGrupoFamiliar", SqlDataAccessArgs
                        .CreateWith("@PlanMedico", afiliado.PlanMedico)
                        .And("@ID", afiliado.UserID)
                        .And("@EstadoCivil", afiliado.EstadoCivil)
                        .And("@CantHijos", afiliado.CantHijos)
                        .And("@RolAfiliado", afiliado.RoleID)
                        .And("@nroAfiliado", afiliado.NroAfiliado)//Hay que sumarle uno
                        .Arguments);
                    }
                    SessionData.Remove("Transaction");
                    SqlDataAccess.Commit(transaction);
                    return afiliado.NroAfiliado;
                }catch{
                    SqlDataAccess.Rollback(transaction);
                    afiliado.UserID = 0;
                    throw;
                }
            }
            else
            {
                entityDetailManager.UpdateDetallePersona(afiliado as User);
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "UpdateAfiliado", SqlDataAccessArgs
                    .CreateWith("@PlanMedico", afiliado.PlanMedico)
                    .And("@ID", afiliado.UserID)
                    .And("@EstadoCivil", afiliado.EstadoCivil)
                    .And("@RolAfiliado", afiliado.RoleID)
                    .And("@CantHijos", afiliado.CantHijos)
                    .And("@Motivo", afiliado.MotivoCambio)
                .Arguments);
                return 0;
            }
        }
        public void Delete(Afiliado afiliado)
        {
            _usersManager.DeleteAccount(afiliado as User);
        }
    }
}

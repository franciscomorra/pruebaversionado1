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


        public Afiliado actualizarInformacion(int userID) 
        {
            Afiliado afiliado = new Afiliado();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAfiliadoInfo", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            //Dado un id de usuario, busca toda su informacion, tambien los detalles de persona


            if (row != null && row != null)
            {
                afiliado.UserName = row["UserName"].ToString();
                afiliado.UserID = userID;
                afiliado.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                afiliado.PlanMedico = new PlanMedico();
                afiliado.PlanMedico.ID = int.Parse(row["Plan_ID"].ToString());
                afiliado.PlanMedico.PrecioConsulta = int.Parse(row["PrecioConsulta"].ToString());
                afiliado.PlanMedico.PrecioFarmacia = int.Parse(row["PrecioFarmacia"].ToString());
                if (!DBNull.Value.Equals(row["EstadoCivil"]))
                    afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString());

                if (!DBNull.Value.Equals(row["CantHijos"]))
                    afiliado.CantHijos = int.Parse(row["CantHijos"].ToString());
                
                //Pedir a partes los detalles de persona
                afiliado.DetallesPersona = new DetallesPersona();
                afiliado.DetallesPersona.Apellido = row["Apellido"].ToString();
                afiliado.DetallesPersona.Nombre = row["Nombre"].ToString();
                afiliado.DetallesPersona.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                afiliado.DetallesPersona.DNI = long.Parse(row["DNI"].ToString());
                afiliado.DetallesPersona.Email = row["Email"].ToString();
                afiliado.DetallesPersona.Direccion = row["Direccion"].ToString();
                afiliado.DetallesPersona.Telefono = long.Parse(row["Telefono"].ToString());
                if (!DBNull.Value.Equals(row["Sexo"]))
                    afiliado.DetallesPersona.Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString());
                afiliado.DetallesPersona.TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString());
                
                
                afiliado.grupoFamiliar = long.Parse(row["GrupoFamiliar"].ToString());
                afiliado.tipoAfiliado = long.Parse(row["TipoAfiliado"].ToString());
                afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
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

        public BindingList<Afiliado> GetAllFromGrupoFamiliar(long grupoFamiliar)
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAfiliadosFromGrupoFamiliar", SqlDataAccessArgs
                .CreateWith("@GrupoFamiliar", grupoFamiliar)
                .Arguments);
            var afiliados = new BindingList<Afiliado>();
            //Devuelve los ID de los usuarios que pertenecen a ese grupo y estan activos
            if (result != null && result.Rows != null)
            {
                int id;
                Afiliado afiliado;
                foreach (DataRow row in result.Rows)
                {
                    id = int.Parse(row["UsuarioID"].ToString());
                    afiliado = actualizarInformacion(id);
                    afiliados.Add(afiliado);
                }
            }
            return afiliados;
        }

        public BindingList<Afiliado> buscarTodos()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetAfiliados");
            var afiliados = new BindingList<Afiliado>();
            DetallePersonaManager detallesManager = new DetallePersonaManager();
            //Busca todos los afiliados que estan activos
            if (result != null && result.Rows != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Afiliado afiliado = new Afiliado();
                    afiliado.UserID = int.Parse(row["ID"].ToString());
                    afiliado.UserName = row["UserName"].ToString();
                    afiliado.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                    afiliado.PlanMedico = new PlanMedico() { 
                        ID = int.Parse(row["Plan_ID"].ToString()),
                        PrecioConsulta = int.Parse(row["PrecioConsulta"].ToString()),
                        PrecioFarmacia = int.Parse(row["PrecioFarmacia"].ToString())
                    };
                    if (!DBNull.Value.Equals(row["EstadoCivil"]))
                        afiliado.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), row["EstadoCivil"].ToString());
                    if (!DBNull.Value.Equals(row["CantHijos"])) 
                        afiliado.CantHijos = int.Parse(row["CantHijos"].ToString());
                    afiliado.grupoFamiliar = long.Parse(row["GrupoFamiliar"].ToString());
                    afiliado.tipoAfiliado = long.Parse(row["TipoAfiliado"].ToString());
                    afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);

                   
                    afiliado.DetallesPersona = detallesManager.BuscarDetallesEnRow(row);



                    afiliados.Add(afiliado);
                       
                }
            }
            return afiliados;
        }
        public long GuardarAfiliado(Afiliado afiliado)
        {
            var usersManager = new UsersManager();
            var _detallesManager = new DetallePersonaManager();
            if (afiliado.UserID == 0)//NUEVO USUARIO
            {
               try
                {
                    afiliado.UserID = usersManager.insertarUsuario(afiliado as User);
                    _detallesManager.AgregarDetalles(afiliado.DetallesPersona, afiliado.UserID);

                    if (afiliado.grupoFamiliar == 0)//Primero del grupo familiar
                    {
                        afiliado.grupoFamiliar = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                            "[SHARPS].InsertAfiliado", SqlDataAccessArgs
                            .CreateWith("@PlanMedico", afiliado.PlanMedico.ID)
                            .And("@ID", afiliado.UserID)
                            .And("@EstadoCivil", afiliado.EstadoCivil.ToString())
                            .And("@CantHijos", afiliado.CantHijos)
                            .And("@RolAfiliado", afiliado.RoleID)
                            .Arguments);
                        afiliado.tipoAfiliado = 1;
                        afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
                        //Inserta, y devuelve el grupo familiar que se le creo
                    }
                    else
                    {
                        afiliado.grupoFamiliar = SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "[SHARPS].InsertMiembroGrupoFamiliar", SqlDataAccessArgs
                        .CreateWith("@PlanMedico", afiliado.PlanMedico.ID)
                        .And("@EstadoCivil", afiliado.EstadoCivil.ToString())
                        .And("@CantHijos", afiliado.CantHijos)
                        .And("@RolAfiliado", afiliado.RoleID)
                        .And("@GrupoFamiliar", afiliado.NroAfiliado)
                        .And("@TipoAfiliado", afiliado.tipoAfiliado)
                        .And("@UserID", afiliado.UserID)
                        .Arguments);
                        //Inserta el usuario, y le paso el tipo de afiliado
                    }
                    return afiliado.NroAfiliado;
                }catch{
                    afiliado.UserID = 0;
                    throw;
                }
            }
            else
            {
                _detallesManager.ModificarDetalles(afiliado.DetallesPersona, afiliado.UserID);
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].UpdateAfiliado", SqlDataAccessArgs
                    .CreateWith("@PlanMedico", afiliado.PlanMedico.ID)
                    .And("@ID", afiliado.UserID)
                    .And("@EstadoCivil", afiliado.EstadoCivil.ToString())
                    .And("@RolAfiliado", afiliado.RoleID)
                    .And("@CantHijos", afiliado.CantHijos)
                    .And("@Motivo", afiliado.MotivoCambio)
                    .And("@Fecha", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]))
                .Arguments);
                //Guarda la informacion del usuario
                return 0;
            }
        }
        public void Delete(Afiliado afiliado)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].DeleteAfiliado", SqlDataAccessArgs
                .CreateWith("@ID", afiliado.UserID)
                .Arguments);
        }
    }
}

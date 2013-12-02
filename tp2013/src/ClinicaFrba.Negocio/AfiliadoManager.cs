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
        private DetallePersonaManager _detallesManager = new DetallePersonaManager();
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
                afiliado.DetallesPersona = _detallesManager.BuscarDetallesEnRow(row);
                
                
                afiliado.grupoFamiliar = long.Parse(row["GrupoFamiliar"].ToString());
                afiliado.tipoAfiliado = int.Parse(row["TipoAfiliado"].ToString());
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
                    afiliado.tipoAfiliado = int.Parse(row["TipoAfiliado"].ToString());
                    afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
                    afiliado.DetallesPersona = _detallesManager.BuscarDetallesEnRow(row);
                    afiliados.Add(afiliado);
                       
                }
            }
            return afiliados;
        }
        public Afiliado GuardarAfiliado(Afiliado afiliado)
        {
            Afiliado _afiliadoExistente = actualizarInformacion(afiliado.UserID);

            if (_afiliadoExistente.DetallesPersona.DNI == 0)
            {
                if (afiliado.grupoFamiliar == 0)//Primero del grupo familiar
                {
                    afiliado.tipoAfiliado = 1;
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                        "[SHARPS].InsertAfiliado", SqlDataAccessArgs
                        .CreateWith("@PlanMedico", afiliado.PlanMedico.ID)
                        .And("@ID", afiliado.UserID)
                        .And("@EstadoCivil", afiliado.EstadoCivil.ToString())
                        .And("@CantHijos", afiliado.CantHijos)
                        .And("@RolAfiliado", afiliado.RoleID)
                        .Arguments);
                    afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
                    afiliado = actualizarInformacion(afiliado.UserID);
                    //Inserta, y devuelve el grupo familiar que se le creo
                }
                else
                {
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].InsertMiembroGrupoFamiliar", SqlDataAccessArgs
                    .CreateWith("@PlanMedico", afiliado.PlanMedico.ID)
                    .And("@EstadoCivil", afiliado.EstadoCivil.ToString())
                    .And("@CantHijos", afiliado.CantHijos)
                    .And("@RolAfiliado", afiliado.RoleID)
                    .And("@GrupoFamiliar", afiliado.grupoFamiliar)
                    .And("@TipoAfiliado", afiliado.tipoAfiliado)
                    .And("@ID", afiliado.UserID)
                    .Arguments);
                    //Inserta el usuario, y le paso el tipo de afiliado
                    afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
                }
                return afiliado;
            }
            else
            {
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
                afiliado.NroAfiliado = ((afiliado.grupoFamiliar * 100) + afiliado.tipoAfiliado);
                //Guarda la informacion del usuario
                return afiliado;
            }
        }
        public void Delete(Afiliado afiliado)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].DeleteAfiliado", SqlDataAccessArgs
                .CreateWith("@ID", afiliado.UserID)
                .Arguments);
        }

        public Afiliado RellenarDatosConyuge(Afiliado afiliado)
        {
            Afiliado conyuge = new Afiliado();
            conyuge.CantHijos = afiliado.CantHijos;
            conyuge.EstadoCivil = afiliado.EstadoCivil;
            conyuge.grupoFamiliar = afiliado.grupoFamiliar;
            conyuge.PlanMedico = afiliado.PlanMedico;
            conyuge.tipoAfiliado = 2;
            conyuge.DetallesPersona = afiliado.DetallesPersona;
            conyuge.DetallesPersona.DNI = 0;
            conyuge.DetallesPersona.Nombre = "";
            return conyuge;
        }
        public Afiliado RellenarDatosHijo(Afiliado afiliado)
        {
            Afiliado hijo = new Afiliado();
            hijo.CantHijos = 0;
            hijo.EstadoCivil = EstadoCivil.Soltero;
            hijo.PlanMedico = afiliado.PlanMedico;
            hijo.Perfil = afiliado.Perfil;
            hijo.grupoFamiliar = afiliado.grupoFamiliar;
            hijo.DetallesPersona = afiliado.DetallesPersona;
            hijo.DetallesPersona.DNI = 0;
            hijo.DetallesPersona.Nombre = "";
            hijo.tipoAfiliado = CalcularTipoAfiliado(hijo);
            return hijo;

        }
        private int CalcularTipoAfiliado(Afiliado hijo){
            int tipoAfiliado = 3;
            BindingList<Afiliado> familia = GetAllFromGrupoFamiliar(hijo.grupoFamiliar);
            BindingList<Afiliado> hijosEnSistema = new BindingList<Afiliado>(familia.Where(x => (x.grupoFamiliar == hijo.grupoFamiliar && x.tipoAfiliado > 2)).ToList());

            if (hijosEnSistema.Count > 0)
            {
                Afiliado ultimo = (Afiliado)(hijosEnSistema.OrderBy(x => x.tipoAfiliado).ToList().Last());
                tipoAfiliado = ultimo.tipoAfiliado + 1;
            }
                
            return tipoAfiliado;
        }
        public bool correspondeConyuge(Afiliado afiliado)
        {
            return (afiliado.EstadoCivil == EstadoCivil.Casado || afiliado.EstadoCivil == EstadoCivil.Concubinato);
        }
        public bool conyugeFueCargado(BindingList<Afiliado> familia)
        {
            if (familia.Count <= 1) return false;
            Afiliado conyugeCargado = (Afiliado)(familia.Where(x => (x.tipoAfiliado == 2)).ToList().First());
            return conyugeCargado == null;
        }

        public bool tieneGenteACargo(Afiliado afiliado)
        {
            BindingList<Afiliado> integrantes_grupoFamiliar = this.buscarTodos();
            //Filtro los que tengan el mismo grupo familiar que el que guardo
            integrantes_grupoFamiliar = new BindingList<Afiliado>(integrantes_grupoFamiliar.Where(x => x.grupoFamiliar == afiliado.grupoFamiliar).ToList());
            if (integrantes_grupoFamiliar.Count > 0)
            {
                if (afiliado.EstadoCivil == EstadoCivil.Casado || afiliado.EstadoCivil == EstadoCivil.Concubinato)
                    return true;
                //Pregunto por los estados civiles que significan pareja a cargo
            }
            return false;
        }
    }
}

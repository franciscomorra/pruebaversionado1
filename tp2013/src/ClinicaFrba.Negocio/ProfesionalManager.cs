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
    public class ProfesionalManager
    {
        private UsersManager _usersManager = new UsersManager();
        private EspecialidadesManager _especialidadesManager = new EspecialidadesManager();
        private DetallePersonaManager _detallesManager = new DetallePersonaManager();
        public Profesional getInfo(int userID)
        {
            Profesional profesional = new Profesional();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetProfesionalInfo", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);
            //Devuelve la informacion del profesional
            if (row != null && row != null)
            {
                profesional.UserName = row["UserName"].ToString();
                profesional.UserID = userID;
                profesional.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                profesional.Matricula = row["matricula"].ToString();
                profesional.Especialidades = _especialidadesManager.GetAllForUser(userID);
                profesional.DetallesPersona = _detallesManager.BuscarDetallesEnRow(row);
            }
            return profesional;
        }
        public BindingList<Profesional> GetAll()
        {
            
            if (SessionData.Contains("Profesionales"))
            {
                return SessionData.Get<BindingList<Profesional>>("Profesionales");
            }
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetProfesionales");
            //Todos los profesionales activos
            var profesionales = new BindingList<Profesional>();
            if (result != null && result.Rows != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Profesional profesional = new Profesional();
                    profesional.UserID = int.Parse(row["ID"].ToString());
                    profesional.UserName = row["UserName"].ToString();
                    profesional.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                    if (!DBNull.Value.Equals(row["Matricula"]))
                        profesional.Matricula = row["Matricula"].ToString();
                    profesional.DetallesPersona = _detallesManager.BuscarDetallesEnRow(row);
                    profesional.Especialidades = _especialidadesManager.GetAllForUser(profesional.UserID);
                    profesionales.Add(profesional);

                }
            }
            SessionData.Set("Profesionales", profesionales);
            return profesionales;
        }
        public void GuardarProfesional(Profesional profesional)
        {
            var usersManager = new UsersManager();
            if (profesional.UserID == 0)//Profesional nuevo
            {
                try
                {
                    profesional.UserID = usersManager.insertarUsuario(profesional as User);
                    _detallesManager.AgregarDetalles(profesional.DetallesPersona, profesional.UserID);
                    SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].InsertProfesional", SqlDataAccessArgs
                        .CreateWith("@Matricula", profesional.Matricula)
                        .And("@ID", profesional.UserID)
                        .And("@Rol", profesional.RoleID)
                        .Arguments);
                }
                catch
                {
                    profesional.UserID = 0;
                    throw;
                }
            }
            else //Editando un profesional
            {
                _detallesManager.ModificarDetalles(profesional.DetallesPersona, profesional.UserID);
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].UpdateProfesional", SqlDataAccessArgs
                    .CreateWith("@Matricula", profesional.Matricula)
                    .And("@ID", profesional.UserID)
                    .Arguments);
            }
            InsertarEspecialidades(profesional);
        }

        public void Delete(Profesional profesional)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            "[SHARPS].DeleteProfesional", SqlDataAccessArgs
            .CreateWith("@ID", profesional.UserID)
            .Arguments);
        }

        public void InsertarEspecialidades(Profesional profesional) {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].LimpiarEspecialidadesDeProfesional", SqlDataAccessArgs
                //Borra las especialidades del profesional
                    .CreateWith("@profesionalID", profesional.UserID)
                .Arguments);
            foreach (var especialidad in profesional.Especialidades){
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                    "[SHARPS].InsertEspecialidad", SqlDataAccessArgs
                    //Inserta una especialidad
                    .CreateWith("@profesionalID", profesional.UserID)
                    .And("@Especialidad", especialidad.ID)
                .Arguments);
            }
        }

        public void CancelarTurnos(int usuarioID, DateTime fecha) {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].CancelarDiaProfesional", SqlDataAccessArgs
                //Busca todos los turnos del dia, y los pone como cancelado por profesional.
                //Deshabilita la agenda para que no se puedan cargar nuevos turnos ese dia
                .CreateWith("@MedicoID", usuarioID)
                .And("@Fecha", fecha)
                .Arguments);
        }
    }
}

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

        public Profesional getInfo(int userID)
        {
            Profesional profesional = new Profesional();
            EspecialidadesManager espMan = new EspecialidadesManager();
            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetProfesionalInfo", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);

            if (row != null && row != null)
            {
                profesional.UserName = row["UserName"].ToString();
                profesional.UserID = userID;
                profesional.FaltanDatos = bool.Parse(row["FaltanDatos"].ToString());
                profesional.Matricula = row["matricula"].ToString();
                profesional.Especialidades = espMan.GetAllForUser(userID);
                profesional.DetallePersona = new DetallesPersona()
                {
                    Apellido = row["Apellido"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    DNI = long.Parse(row["DNI"].ToString()),
                    Email = row["Email"].ToString(),
                    Direccion = row["Direccion"].ToString(),
                    Telefono = long.Parse(row["Telefono"].ToString()),
                    Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString()),
                    TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString())
                };


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
            var profesionales = new BindingList<Profesional>();
            if (result != null && result.Rows != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    Profesional profesional = new Profesional();
                    profesional.UserID = int.Parse(row["ID"].ToString());
                    profesional.UserName = row["UserName"].ToString();

                    if (!DBNull.Value.Equals(row["Matricula"]))
                        profesional.Matricula = row["Matricula"].ToString();

                    profesional.DetallePersona = new DetallesPersona();
                    profesional.DetallePersona.Apellido = row["Apellido"].ToString();
                    profesional.DetallePersona.Nombre = row["Nombre"].ToString();
                    profesional.DetallePersona.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                    profesional.DetallePersona.DNI = long.Parse(row["DNI"].ToString());
                    profesional.DetallePersona.Email = row["Email"].ToString();
                    profesional.DetallePersona.Direccion = row["Direccion"].ToString();
                    profesional.DetallePersona.Telefono = long.Parse(row["Telefono"].ToString());
                    if (!DBNull.Value.Equals(row["Sexo"]))
                        profesional.DetallePersona.Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString());
                    if (!DBNull.Value.Equals(row["TipoDoc"])) 
                        profesional.DetallePersona.TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString());
                    profesionales.Add(profesional);

                }
            }
            SessionData.Set("Profesionales", profesionales);
            return profesionales;
        }
        public void GuardarProfesional(Profesional profesional, string password)
        {
            var usersManager = new UsersManager();
            var entityDetailManager = new DetallePersonaManager();
            if (profesional.UserID == 0)//Profesional nuevo
            {
                var transaction = SqlDataAccess.OpenTransaction(ConfigurationManager.ConnectionStrings["StringConexion"].ToString());
                try
                {
                    SessionData.Set("Transaction", transaction);

                    profesional.UserID = usersManager.CreateAccount(profesional as User,password);

                    var detalleID = entityDetailManager.AddDetallePersona(profesional as User);

                    SqlDataAccess.ExecuteNonQuery(
                        "[SHARPS].InsertProfesional", SqlDataAccessArgs
                        .CreateWith("@Matricula", profesional.Matricula)
                        .And("@ID", profesional.UserID)
                        .And("@Rol", profesional.RoleID)
                        .Arguments,
                    transaction);

                    SessionData.Remove("Transaction");
                    SqlDataAccess.Commit(transaction);
                }
                catch
                {
                    SqlDataAccess.Rollback(transaction);
                    profesional.UserID = 0;
                    throw;
                }
            }
            else //Editando un profesional
            {
                entityDetailManager.UpdateDetallePersona(profesional as User);
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
            _usersManager.DeleteAccount(profesional as User);
        }

        public void InsertarEspecialidades(Profesional profesional) {
            foreach (var especialidad in profesional.Especialidades){
                SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["GrouponConnectionString"].ToString(),
                    "[SHARPS].InsertSpeciality", SqlDataAccessArgs
                    .CreateWith("@MedicoID", profesional.UserID)
                    .And("@Especialidad", especialidad)
                .Arguments);
            }
        }

        public void CancelarTurnos(int usuarioID, DateTime fecha) {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["GrouponConnectionString"].ToString(),
                "[SHARPS].CancelarDiaProfesional", SqlDataAccessArgs
                .CreateWith("@MedicoID", usuarioID)
                .And("@Fecha", fecha)
                .Arguments);
        
        }
    }
}

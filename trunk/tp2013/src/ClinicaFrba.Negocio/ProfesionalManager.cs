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
                "GetProfesionalInfo", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);

            if (row != null && row != null)
            {
                profesional.UserName = row["UserName"].ToString();
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
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "GetProfesionales");
            var data = new BindingList<Profesional>();
            if (result != null && result.Rows != null)
            {
                EspecialidadesManager espMan = new EspecialidadesManager();
                foreach (DataRow row in result.Rows)
                {
                    data.Add(new Profesional()
                    {
                        UserID = int.Parse(row["ID"].ToString()),
                        UserName = row["UserName"].ToString(),
                        Matricula = row["RazonSocial"].ToString(),
                        Especialidades = espMan.GetAllForUser(int.Parse(row["ID"].ToString())),
                        DetallePersona = new DetallesPersona()
                        {
                            Apellido = row["Apellido"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            DNI = long.Parse(row["DNI"].ToString()),
                            Email = row["Email"].ToString(),
                            Nombre = row["Nombre"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                            Telefono = long.Parse(row["Telefono"].ToString()),
                            Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString()),
                            TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString())
                        }
                    });
                }
            }
            return data;
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
                        "InsertProfesional", SqlDataAccessArgs
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
                    "UpdateProfesional", SqlDataAccessArgs
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
                    "InsertSpeciality", SqlDataAccessArgs
                    .CreateWith("@MedicoID", profesional.UserID)
                    .And("@Especialidad", especialidad)
                .Arguments);
            }
        }

    }
}

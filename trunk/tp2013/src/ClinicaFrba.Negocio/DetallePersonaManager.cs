using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaFrba.Negocio
{
    public class DetallePersonaManager
    {
        public int AddDetallePersona(User user)
        {
            var transaction = SessionData.Contains("Transaction") ? SessionData.Get<SqlTransaction>("Transaction") : null;
            if (transaction != null)
            {
                return SqlDataAccess.ExecuteScalarQuery<int>(
                    "[SHARPS].InsertDetallePersona", SqlDataAccessArgs
                    .CreateWith(
                        "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Sexo", user.DetallePersona.Sexo)
                    .And("@FechaNacimiento", user.DetallePersona.FechaNacimiento)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID)
                    .Arguments,
                    transaction); //Con transaccion (de C#)
            }
            return SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertDetallePersona", SqlDataAccessArgs
                .CreateWith(
                        "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Sexo", user.DetallePersona.Sexo)
                    .And("@FechaNacimiento", user.DetallePersona.FechaNacimiento)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID)
            .Arguments); //Sin transaccion (de C#)
        }

        internal void UpdateDetallePersona(User user)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].UpdateDetallePersona", SqlDataAccessArgs
                .CreateWith(
                    "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Sexo", user.DetallePersona.Sexo)
                    .And("@FechaNacimiento", user.DetallePersona.FechaNacimiento)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID) 
            .Arguments);
        }


        public DetallesPersona getDetalles(int userID)
        {
            DetallesPersona detalles = new DetallesPersona();

            var row = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetDetallesPersona", SqlDataAccessArgs
                .CreateWith("@userId", userID)
                .Arguments);

            if (row != null && row != null)
            {
                    detalles.Apellido = row["Apellido"].ToString();
                    detalles.Nombre = row["Nombre"].ToString();
                    detalles.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
                    detalles.DNI = long.Parse(row["DNI"].ToString());
                    detalles.Email = row["Email"].ToString();
                    detalles.Direccion = row["Direccion"].ToString();
                    detalles.Telefono = long.Parse(row["Telefono"].ToString());
                    if (!DBNull.Value.Equals(row["Sexo"]))
                        detalles.Sexo = (TipoSexo)Enum.Parse(typeof(TipoSexo), row["Sexo"].ToString());
                    if (!DBNull.Value.Equals(row["TipoDoc"]))
                        detalles.TipoDNI = (TipoDoc)Enum.Parse(typeof(TipoDoc), row["TipoDoc"].ToString());
            };

            return detalles;
        }
    }
}

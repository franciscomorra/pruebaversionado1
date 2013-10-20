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
                    "SHARPS.InsertDetallePersona", SqlDataAccessArgs
                    .CreateWith(
                        "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID)
                    .Arguments,
                    transaction);
            }
            return SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.InsertDetallePersona", SqlDataAccessArgs
                .CreateWith(
                    "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID)
            .Arguments);
        }

        internal void UpdateDetallePersona(User user)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.UpdateDetallePersona", SqlDataAccessArgs
                .CreateWith(
                    "@Telefono", user.DetallePersona.Telefono)
                    .And("@Email", user.DetallePersona.Email)
                    .And("@Nombre", user.DetallePersona.Nombre)
                    .And("@Apellido", user.DetallePersona.Apellido)
                    .And("@DNI", user.DetallePersona.DNI)
                    .And("@TipoDNI", user.DetallePersona.TipoDNI)
                    .And("@Direccion", user.DetallePersona.Direccion)
                    .And("@ID_Usuario", user.UserID)
            .Arguments);
        }
    }
}

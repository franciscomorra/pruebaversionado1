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
        public void AgregarDetalles(DetallesPersona detalles, int userID)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertDetallePersona", SqlDataAccessArgs
                .CreateWith(
                        "@Telefono", detalles.Telefono)
                    .And("@Email", detalles.Email)
                    .And("@Nombre", detalles.Nombre)
                    .And("@Apellido", detalles.Apellido)
                    .And("@DNI", detalles.DNI)
                    .And("@TipoDNI", detalles.TipoDNI)
                    .And("@Sexo", detalles.Sexo)
                    .And("@FechaNacimiento", detalles.FechaNacimiento)
                    .And("@Direccion", detalles.Direccion)
                    .And("@ID_Usuario", userID)
            .Arguments);
        }

        internal void ModificarDetalles(DetallesPersona detallePersona, int userID)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].UpdateDetallePersona", SqlDataAccessArgs
                .CreateWith(
                    "@Telefono", detallePersona.Telefono)
                    .And("@Email", detallePersona.Email)
                    .And("@Nombre", detallePersona.Nombre)
                    .And("@Apellido", detallePersona.Apellido)
                    .And("@DNI", detallePersona.DNI)
                    .And("@TipoDNI", detallePersona.TipoDNI)
                    .And("@Sexo", detallePersona.Sexo)
                    .And("@FechaNacimiento", detallePersona.FechaNacimiento)
                    .And("@Direccion", detallePersona.Direccion)
                    .And("@ID_Usuario", userID) 
            .Arguments);
        }


        public DetallesPersona BuscarDetalles(int userID)
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

        public DetallesPersona BuscarDetallesEnRow(System.Data.DataRow row)
        {
            DetallesPersona detalles = new DetallesPersona();
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
            return detalles;
        }
    }
}

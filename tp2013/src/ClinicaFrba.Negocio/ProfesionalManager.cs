﻿using System;
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

        public BindingList<Profesional> GetAll()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "SHARPS.GetProfesionales");
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
                        //HACER ESPECIALIDADES
                        DetallePersona = new DetallesPersona()
                        {
                            Apellido = row["Apellido"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            DNI = long.Parse(row["DNI"].ToString()),
                            Email = row["Email"].ToString(),
                            Nombre = row["Nombre"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                            Telefono = long.Parse(row["Telefono"].ToString()),
                            TipoDNI = row["TipoDNI"].ToString(),
                            //Ver lo del tipo de Sexo
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
                    profesional.UserID = usersManager.CreateProfileAccount(profesional as User, Profesional.Profile, password);
                    var detalleID = entityDetailManager.AddDetallePersona(profesional as User);

                    SqlDataAccess.ExecuteNonQuery(
                        "SHARPS.InsertProfesional", SqlDataAccessArgs
                        .CreateWith("@Matricula", profesional.Matricula)
                        .And("@ID", profesional.UserID)
                        //HACER ESPECIALIDADES
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
                    "SHARPS.UpdateProfesional", SqlDataAccessArgs
                    .CreateWith("@Matricula", profesional.Matricula)
                    //HACER ESPECIALIDADES
                    .And("@ID", profesional.UserID)
                    .Arguments);
            }
        }

        public void Delete(Profesional profesional)
        {
            _usersManager.DeleteAccount(profesional as User);
        }
    }
}
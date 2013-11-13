using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Configuration;
using System.Data;
using ClinicaFrba.Comun;
using System.ComponentModel;

namespace ClinicaFrba.Negocio
{
    public class RolesManager
    {
        public BindingList<Rol> GetRolesByPerfil(Perfil perfil)
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetRolesByPerfil", SqlDataAccessArgs
                .CreateWith("@Perfil", perfil.Nombre)
            .Arguments);
            //Dado un nombre de perfil, devolve los roles que cumplan que tienen su id
            var roles = new BindingList<Rol>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var rol = new Rol()
                {
                    ID = int.Parse(row["RolID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                };
                roles.Add(rol);
            }

            return roles;
        }
        
        
        public BindingList<Rol> GetRoles() //Para el abm roles en particular
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(
                ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetRoles"
                //Todos los roles
            );
            var roles = new BindingList<Rol>();
            var functionalitiesManager = new FunctionalitiesManager();
            foreach (DataRow row in result.Rows)
            {
                var rol = new Rol()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Nombre = row["Descripcion"].ToString(),
                    Perfil = new Perfil(){

                        ID = int.Parse(row["PerfilID"].ToString()),
                        Nombre = row["PerfilNombre"].ToString()
                    },
                    Functionalities = functionalitiesManager.GetRoleFunctionalities(int.Parse(row["ID"].ToString()))

                };
                roles.Add(rol);
            }

            return roles;
        }
        public void DeleteRole(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].DeleteRole", SqlDataAccessArgs
                .CreateWith("@Rol_ID", rol.ID) 
                //Inhabilita el rol, no hace falta tocar a los usuarios, cuando se loguean, si no tienen rol asignado salta error
            .Arguments);
        }

        public void SaveRole(Rol rol)
        {
            if (rol.ID > 0) UpdateRole(rol);
            else InsertRole(rol);
        }

        private void InsertRole(Rol rol)
        {
            var roleId = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].InsertRole", SqlDataAccessArgs
                .CreateWith("@Description", rol.Nombre).And("@PerfilID",rol.Perfil.ID)
            .Arguments);
            //Inserta un rol
            rol.ID = roleId;
            UpdateRoleFunctionalities(rol);
        }

        private void UpdateRole(Rol rol)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].UpdateRole", SqlDataAccessArgs
                .CreateWith("@Description", rol.Nombre)
                .And("@ID", rol.ID)
            .Arguments);
            //Cambia la descripcion de un rol
            UpdateRoleFunctionalities(rol);
        }

        private void UpdateRoleFunctionalities(Rol rol)
        {
            var manager = new FunctionalitiesManager();
            if(rol.ID > 0)
                manager.DeleteRoleFunctionalities(rol);
            foreach (var functionality in rol.Functionalities)
            {
                manager.InsertRoleFunctionality(rol, functionality);
            }
        }

        public BindingList<Rol> GetUserRoles(int userID)//Buscar los roles de un usuario
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "[SHARPS].GetUserRoles", SqlDataAccessArgs
                .CreateWith("@userID", userID).Arguments);
            //Devuelve todos los roles que estan activos
            var roles = new BindingList<Rol>();

            if (result != null && result.Rows != null)
            {

                foreach (DataRow row in result.Rows)
                {
                    var rol = new Rol()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Nombre = row["Descripcion"].ToString()
                    };
                    rol.Perfil = new Perfil();
                    rol.Perfil.ID = int.Parse(row["PerfilId"].ToString());
                    rol.Perfil.Nombre = row["PerfilNombre"].ToString();
                    roles.Add(rol);
                }
            }

            return roles;
        }


    }
}

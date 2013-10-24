using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ABM.Common;
using Data;
using System.Configuration;
using System.Data;

namespace ABM.Business
{
    public class ClientsManager
    {
        public int funcionprueba() {

            var result = SqlDataAccess.ExecuteScalarQuery<object>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),"dbo.GetUserLoginAttempts", SqlDataAccessArgs.CreateWith("@Nombre", "asd").Arguments);

            if (result == null)
                throw new Exception("Usuario o contraseña inválidos");

            if (int.Parse(result.ToString()) == 3)
            {
                throw new Exception("Usuario Bloqueado, contacte al administrador del sistema");
            }
            else
            {
                return int.Parse(result.ToString());
            }
        }
        public BindingList<Client> GetAllClients()
        {
            var result = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                   "dbo.GetClients");
            var data = new BindingList<Client>();
            if (result != null && result.Rows != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    data.Add(new Client()
                    {
                        Id = int.Parse(row["ID"].ToString()),
                        Name = row["Name"].ToString(),
                        Address = row["Address"].ToString(),
                    });
                }
            }
            return data;

        }

        public Client buscarDatos(int id){
            //Client cliente = new Client();
            var data = SqlDataAccess.ExecuteDataRowQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "dbo.buscarCliente", SqlDataAccessArgs
               .CreateWith("@id", id).Arguments);
            Client cliente = new Client();
            
            return cliente;
        }
        public Client Add(string name,string address)
        {
            var id = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "dbo.InsertClient", SqlDataAccessArgs
               .CreateWith("@Name", name)
               .And("@Address", address)
           .Arguments);

            Client cliente = new Client();
            cliente.Address = address;
            cliente.Id = id;
            cliente.Name = name;
            return cliente;
        }
        public void Edit(int id, string name, string address)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "dbo.modificarCliente", SqlDataAccessArgs
               .CreateWith("@Name", name)
               .And("@Address", address)
               .And("@ID", id)
           .Arguments);
        }
        public void Delete(int id)
        {
            SqlDataAccess.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                "dbo.borrarCliente", SqlDataAccessArgs
               .CreateWith("@ID", id)
           .Arguments);
        }
    }
        
}


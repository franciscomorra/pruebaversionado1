using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaBus.Common;
using System.Data;
using System.Data.SqlClient;
using Data;
using System.Configuration;
using System.ComponentModel;



namespace FrbaBus.Business
{
    public class ClienteManager
    {
        public BindingList<Cliente> GetAll()
        {
            
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.ListarClientes");
            var clientes = new BindingList<Cliente>();
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    clientes.Add(new Cliente()
                    {
                        DNI = long.Parse(row["DNI"].ToString()),
                        NOMBRE = row["NOMBRE"].ToString(),
                        APELLIDO = row["APELLIDO"].ToString(),
                        DIRECCION = row["DIRECCION"].ToString(),
                        MAIL = row["MAIL"].ToString(),
                        TELEFONO = long.Parse(row["TELEFONO"].ToString()),
                        FECHA_NAC = Convert.ToDateTime(row["FECHA_NAC"]),
                        SEXO = row["SEXO"].ToString(),
                        DISCAPACITADO = Convert.ToBoolean(row["DISCAPACITADO"])
                    });
                }
            }
            return clientes;
                
        }




        public Cliente EncontrarCliente(long DNI)
        {
            var cliente = new Cliente();
            cliente.DNI = DNI;
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.EncontrarCliente", SqlDataAccessArgs.CreateWith("@DNI", DNI).Arguments);
            if (resultado != null && resultado.Rows != null && resultado.Rows.Count > 0)
            {
                cliente.NOMBRE = resultado.Rows[0]["NOMBRE"].ToString();
                cliente.APELLIDO = resultado.Rows[0]["APELLIDO"].ToString();
                cliente.DIRECCION = resultado.Rows[0]["DIRECCION"].ToString();
                cliente.MAIL = resultado.Rows[0]["MAIL"].ToString();
                cliente.TELEFONO = long.Parse(resultado.Rows[0]["TELEFONO"].ToString());
                cliente.FECHA_NAC = Convert.ToDateTime(resultado.Rows[0]["FECHA_NAC"]);
                cliente.SEXO = resultado.Rows[0]["SEXO"].ToString();
                cliente.DISCAPACITADO = Convert.ToBoolean(resultado.Rows[0]["DISCAPACITADO"]);
                
            }
            return cliente;

        }

        public void InsertaoModificarCliente(Cliente unCliente)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(), "ACTITUD_GDD.AgregarActualizarCliente", SqlDataAccessArgs
                .CreateWith("@DNI", unCliente.DNI).And("@NOMBRE", unCliente.NOMBRE).And("@APELLIDO", unCliente.APELLIDO).And("@DIRECCION", unCliente.DIRECCION)
                .And("@TELEFONO", unCliente.TELEFONO).And("@MAIL", unCliente.MAIL).And("@FECHA_NAC", unCliente.FECHA_NAC).And("@SEXO", unCliente.SEXO).And("@DISCAPACITADO", unCliente.DISCAPACITADO)
                .Arguments);
        }



    }
}

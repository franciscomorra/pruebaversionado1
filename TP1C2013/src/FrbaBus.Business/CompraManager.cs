using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Data;
using System.Configuration;
using System.ComponentModel;
using FrbaBus.Common;

namespace FrbaBus.Business
{
    public class CompraManager
    {

        private bool esDiscapacitado(long DNI)
        {
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
              "ACTITUD_GDD.ESDISCAPACITADO", SqlDataAccessArgs.CreateWith("@DNI", DNI).Arguments);
            return Convert.ToBoolean(resultado.Rows[0]["DISCAPACITADO"]);
        }

        public int cantidadDiscapacitados( BindingList<PasajePaquete> ITEMS ){
           BindingList<long> discapacitadosDNI = new BindingList<long>();
            bool esDiscapacitado;

            foreach (PasajePaquete item in ITEMS)
            {

                esDiscapacitado = this.esDiscapacitado(item.DNI);


                if (esDiscapacitado)
                {
                    discapacitadosDNI.Add(item.DNI);
                }
            }

            return discapacitadosDNI.Distinct().ToList().Count;
        }

        // Si no hay ningun discapacitado retorna 0, caso contrario el primero (creemos)
        public long elDiscapacitado(BindingList<PasajePaquete> ITEMS)
        {
            long DNI = -1;

            foreach (PasajePaquete item in ITEMS)
            {
                if (this.esDiscapacitado(item.DNI) && item.KG_PAQUETE == 0)
                    DNI = item.DNI;
            }

                return DNI;
        }


        public int cuantosPasajeCompro(long DNI, BindingList<PasajePaquete> ITEMS)
        {
            int cont = 0;

            foreach (PasajePaquete item in ITEMS)
            {
                if (item.DNI == DNI && item.KG_PAQUETE == 0)
                    cont++;
            }

            return cont;

        }

        public int cuantosPasajesHay(BindingList<PasajePaquete> ITEMS)
        {
            int cont = 0;

            foreach (PasajePaquete item in ITEMS)
            {
                if (item.KG_PAQUETE == 0)
                    cont++;
            }

            return cont;

        }

        private bool estaEnLaLista( BindingList<PasajePaquete> ITEMS, long DNI)
        {
            bool retorno = false;

            foreach(PasajePaquete item in ITEMS){

                if (item.DNI == DNI)
                    retorno = true;
            
            }

            return retorno;
        }

        public bool puedoAsociarCliente(long DNI, BindingList<PasajePaquete> ITEMS)
        {
            bool esDiscapacitado = this.esDiscapacitado(DNI);
            int  cantDisc = this.cantidadDiscapacitados(ITEMS);

            if( esDiscapacitado && (cantDisc > 0) ){
                if((cantDisc == 1) && estaEnLaLista(ITEMS, DNI)){
                    return true;
                } else {
                    return false;
                }
            }
            else {
                return true;
            }
        }

        public bool puedoComprarPasaje(long DNI, BindingList<PasajePaquete> ITEMS)
        {

            if (( elDiscapacitado(ITEMS) != -1 || esDiscapacitado(DNI)) && (this.cuantosPasajesHay(ITEMS) > 1) )
                return false;
            else
                return true;
        }

        public int crearCompra(long DNI){

            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
             "ACTITUD_GDD.CREARCOMPRA", SqlDataAccessArgs.CreateWith("@DNI", DNI).Arguments);

            return int.Parse(resultado.Rows[0]["ID_COMPRA"].ToString());
        
        }

        public bool crearPasaje(int IDCompra, PasajePaquete item)
        {

            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.CREARPASAJE", SqlDataAccessArgs.CreateWith("@DNI", item.DNI).And("@BUTACA_NRO",item.NUMERO_BUTACA)
                .And("@ID_VIAJE", item.ID_VIAJE).And("@ID_COMPRA", IDCompra).Arguments);
            return Convert.ToBoolean(resultado.Rows[0]["INSERTO"]);
        }

        public bool crearPaquete(int IDCompra, PasajePaquete item)
        {

            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.CREARPAQUETE", SqlDataAccessArgs.CreateWith("@DNI", item.DNI).And("@PESO",item.KG_PAQUETE)
                .And("@ID_VIAJE", item.ID_VIAJE).And("@ID_COMPRA", IDCompra).Arguments);
            return Convert.ToBoolean(resultado.Rows[0]["INSERTO"]);
        }

    
        public void cancelarCompra(int ID)
        {
            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.CANCELARCOMPRA", SqlDataAccessArgs.CreateWith("@ID_COMPRA", ID).Arguments);
        }

        public void confirmarCompra(int ID, long DNI, int codigoTarjeta)
        {

            SqlDataAccess.ExecuteNonQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.CONFIRMARCOMPRA", SqlDataAccessArgs.CreateWith("@ID_COMPRA", ID).And("@DNI", DNI).And("@CODIGO_TARJETA",codigoTarjeta).And("@FECHA_COMPRA", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);

        }


        public float calcularSeatearMonto(int IDCompra, BindingList<PasajePaquete> compra)
        {
            float retorno = 0;
            var resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                "ACTITUD_GDD.CalcularSetearMontoPaquetes", SqlDataAccessArgs.CreateWith("@ID", IDCompra).Arguments);

                retorno += float.Parse(resultado.Rows[0]["MONTO"].ToString());


            if (this.elDiscapacitado(compra) == -1)
            {
                resultado = SqlDataAccess.ExecuteDataTableQuery(FrbaBus.Common.Configuracion.ConnectionString(),
                 "ACTITUD_GDD.CalcularSetearMontoPasajes", SqlDataAccessArgs.CreateWith("@ID", IDCompra).And("@FECHA_ACTUAL", FrbaBus.Common.Configuracion.fechaAhora()).Arguments);

                retorno += float.Parse(resultado.Rows[0]["MONTO"].ToString());
            }

            return retorno;
        }
    }
}

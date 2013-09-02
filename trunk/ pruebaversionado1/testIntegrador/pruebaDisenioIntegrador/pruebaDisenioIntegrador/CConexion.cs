using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class CConexion
    {
        private string _cadena;
        private SqlConnection _conexion;
        private SqlDataAdapter _adaptador = new SqlDataAdapter();
        private Array[] recitales;
        private DataTable recital = new DataTable();
        public void Conectar(){
            this._cadena = "Data Source=SQLSERVER2008;AttachDbFilename=|DataDirectory|\\dbPruebaDisenio.mdf;Persist Security Info=True;User ID=sa;Password=gestiondedatos;Connect Timeout=30;User Instance=False";
            this._conexion = new SqlConnection(this._cadena);
        }

        public bool Consultar_Recitales() {
            bool estado = true;
            try{
                Conectar();
                this._adaptador.SelectCommand = new SqlCommand("SELECT fecha,precioBase FROM recitales",_conexion);
                this._adaptador.;


                

            }catch (Exception ex){
                estado = false;
            }
            return estado;
        }

        public void Desconectar(){
            this._conexion.Close();
        }
    }
}

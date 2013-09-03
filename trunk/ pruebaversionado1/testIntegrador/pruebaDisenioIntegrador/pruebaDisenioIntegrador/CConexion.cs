using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class CConexion
    {
        private string _cadena;
        private SqlConnection _conexion;
        private SqlDataAdapter _adaptador = new SqlDataAdapter();
        private Array[] recitales;
       
        //private DataTable recital = new DataTable();
        public DataTable _tabla { get; set; }
        
        public void Conectar(){
           // this._cadena = "Data Source=SQLSERVER2008;AttachDbFilename=\\dbPruebaDisenio.mdf;Persist Security Info=True;User ID=sa;Password=gestiondedatos;Connect Timeout=30;User Instance=False";
            this._cadena = "Server=.\\SQLSERVER2008;Database=dbPruebaDisenio;User Id=sa;Password=gestiondedatos";
            this._conexion = new SqlConnection(this._cadena);
            this._conexion.Open();
        }

        public void Consultar_Recitales() {
            try
            {
                this.Conectar();
                this._adaptador.SelectCommand = new SqlCommand("SELECT fecha,precioBase FROM recitales", _conexion);
                this._adaptador.Fill(this._tabla);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                this.Desconectar();
            }
        }


        public void Desconectar(){
            this._conexion.Close();
            
        }
    }
}

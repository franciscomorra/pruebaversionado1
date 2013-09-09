using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration; //Para que tome bien click derecho en references y agregar referencia
using Data; //Para que tome bien click derecho en references y agregar referencia


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                /*
                 * Funciona el insert
                 * Lo que hace es llamar al proyecto Data, y le manda el mensaje con ExecuteScalarQuery
                 * Inserta un student nuevo, y devuelve el ID del que inserto
                 * Para crear un procedimiento en SQL, ir a SQL Server, ir a la db, procedimientos, crearlo y darle correr.
                 * Para ver bien la sintaxis ir al proyecto de 2008, y fijarse en la parte de data y script_creación_inicial.sql
                 * En ese archivo se guardan los procedimientos y funciones, pero para adjuntarlos a la db hay que ejecutarlos
                 * 
                 */
                //var id = SqlDataAccess.ExecuteScalarQuery<int>(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
                /*
                 * Me falta ver como hacer para que el configuration manager me tome el string de conexion, asi no se copia en todo el documento
                 * 
                 */
                var id = SqlDataAccess.ExecuteScalarQuery<int>("Data Source=.\\SQLSERVER2008;Connect Timeout=200;User Instance=False; database = dbDisenio; User ID=sa; Password=gestiondedatos;",
                    "dbo.InsertarStudent", SqlDataAccessArgs
                   .CreateWith("@Name", txtName.Text)
                   .And("@Address", txtAdd.Text)
               .Arguments);
                MessageBox.Show("Update OK "+id);

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}

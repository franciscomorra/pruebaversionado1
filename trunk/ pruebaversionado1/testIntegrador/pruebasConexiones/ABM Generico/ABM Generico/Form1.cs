using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection sc = new SqlConnection("Data Source=.\\SQLSERVER2008;AttachDbFilename=\"C:\\Documents and Settings\\UsuarioAdmin\\Escritorio\\versionado\\testIntegrador\\dbPruebaDisenio.mdf\";Persist Security Info=True;User ID=sa;Password=gestiondedatos;Connect Timeout=30;User Instance=False");
        SqlCommand cmd;

        
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
                sc.Open();
                cmd = new SqlCommand("INSERT into Students (Name,Address) values ('" + txtName + "','" + txtAdd.Text + "')", sc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update OK");
                sc.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FrbaBus.Core;
using FrbaBus.Common;


namespace FrbaBus.Top_Clientes
{
    public partial class TopClientes : Form
    {
        public TopClientes()
        {
            InitializeComponent();
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            for (int i = 1990; i <= Configuracion.fechaAhora().Year; i++)
                comboBox1.Items.Add(i);
            comboBox2.Text = "1";
            comboBox1.Text = Configuracion.fechaAhora().Year.ToString();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


          
        private void button1_Click(object sender, EventArgs e)
        {


           

            var connectionstring = FrbaBus.Common.Configuracion.ConnectionString();

            SqlConnection con = new SqlConnection(connectionstring);
            
            SqlDataAdapter sda = new SqlDataAdapter(@"ACTITUD_GDD.TOP5CLIENTES '" + Semestre.calcularFechaSemestre(int.Parse(comboBox1.Text), int.Parse(comboBox2.Text)).ToShortDateString()+ "'", con);
            
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }

       
    }
}

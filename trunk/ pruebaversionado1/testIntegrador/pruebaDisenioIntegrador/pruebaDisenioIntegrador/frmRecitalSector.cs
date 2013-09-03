using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmRecitalSector : Form
    {
        public frmRecitalSector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CConexion conection = new CConexion();
            conection.Consultar_Recitales();

            foreach (DataRow row in conection._tabla.Rows)
            {
                string primerCol = row["0"].ToString();
                string segundaCol = row["1"].ToString();
                string tercerCol = row["2"].ToString();

            }

        }
    }
}

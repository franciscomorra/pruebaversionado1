using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Business;
using FrbaBus.Common;
using FrbaBus.Abm_Permisos;
using FrbaBus.Core;

namespace FrbaBus.Compra_de_Pasajes
{
    public partial class listadoCompra : Form
    {
        public listadoCompra(BindingList<PasajePaquete> compra)
        {
            InitializeComponent();
            dataGridView1.DataSource = compra;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

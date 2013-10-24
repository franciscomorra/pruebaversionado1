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
//using Data; //Para que tome bien click derecho en references y agregar referencia
using ABM.Business;
using ABM.Common;
using System.Collections;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /* Atributos */
        private ClientsManager ayudanteClientes = new ClientsManager(); //Creo la clase que va a manejar las operaciones de clientes
        /* Fin Atributos */

        public Form1()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["StringConexion"].ToString();

        }
        private void Form1_Load(object sender, EventArgs e) //Cuando carga el formulario
        {
            this.refrescarDataGrid();
            dataGridClients.DoubleClick += new EventHandler(dataGridClients_DoubleClick);
        }
        private void refrescarDataGrid() 
        {
            var table = ayudanteClientes.GetAllClients(); //Devuelve lista de objetos client
            dataGridClients.DataSource = table as BindingList<Client>; //Llena la tabla
            lblResults.Text = table.Count.ToString(); //Actualiza el contador
        }
 
        void dataGridClients_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridClients.SelectedRows == null || dataGridClients.SelectedRows.Count == 0) return;
            var row = dataGridClients.SelectedRows[0]; //Dame la fila que eligio
            var cliente = row.DataBoundItem as Client; //va a ser un client
            txtAdd.Text = cliente.Address.ToString(); //Rellena los campos
            txtId.Text = cliente.Id.ToString();
            txtName.Text = cliente.Name.ToString();
            btnBorrar.Show();
            btnNuevo.Show(); 
        }
        private void btnSave_Click(object sender, EventArgs e)//Cuando hace click en guardar
        {
            try
            {
                //Inicio Validacion de datos
                if (string.IsNullOrEmpty(txtName.Text.Trim())) //Si nombre es vacio
                {
                    MessageBox.Show("El nombre no puede ser nulo");
                    return;
                }
                if (string.IsNullOrEmpty(txtAdd.Text.Trim())) //Si la direccion es vacia
                {
                    MessageBox.Show("La direccion no puede ser nula");
                    return;
                }
                //Fin validacion de datos


                if (string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    this.nuevoUsuario(); //Nuevo
                }
                else {

                    this.updateUsuario(); //Existente
                }
                this.refrescarDataGrid();
                this.limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuevoUsuario()
        {
            Client cliente = ayudanteClientes.Add(txtName.Text, txtAdd.Text);//Agrega un cliente nuevo a la db
            MessageBox.Show("Insertado"); 

        }
        private void updateUsuario()
        {

            this.ayudanteClientes.Edit(int.Parse(txtId.Text),txtName.Text.ToString(),txtAdd.Text.ToString() );
            MessageBox.Show("Actualizado" );

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text.Trim())) //Si la direccion es vacia
            {
                MessageBox.Show("No hay un usuario seleccionado!");
                return;
            }
            try
            {
                this.ayudanteClientes.Delete(int.Parse(txtId.Text));
                MessageBox.Show("Eliminado");
                this.refrescarDataGrid();
                this.limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void limpiarCampos()
        {
            txtAdd.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            btnBorrar.Hide();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int numero = this.ayudanteClientes.funcionprueba();
           MessageBox.Show("Numero = "+numero.ToString());
           var encryptedPassword = ComputeHash("w23e", new SHA256Managed());
           MessageBox.Show("Hash = " + encryptedPassword.ToString());

        }
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

    }
}

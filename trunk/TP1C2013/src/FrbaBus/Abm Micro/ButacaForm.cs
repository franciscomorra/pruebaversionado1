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


namespace FrbaBus.Abm_Micro
{
    public partial class ButacaForm : Form
    {

        Micro _elMicro = new Micro();
        ButacaManager _butacaManager = new ButacaManager();
        public event EventHandler<MicroQueSePasa> recargarButacas;
        int _butacaAModificar;

        public ButacaForm(Micro micro)
        {
            InitializeComponent();
            var dataSource = micro.BUTACAS;
            datagvButca.DataSource = dataSource;
            txtPatente.Text = micro.PATENTE;
            txtPatente.Enabled = false;

            cmbPiso.Items.Add(1);
            cmbPiso.Items.Add(2);
            cmbTipo.Items.Add("Ventanilla");
            cmbTipo.Items.Add("Pasillo");
            _elMicro = micro;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void ButacaForm_Load(object sender, EventArgs e)
        {
            datagvButca.Columns["NUMERO"].DisplayIndex = 1;
            datagvButca.Columns["PISO"].DisplayIndex = 2;
            datagvButca.Columns["MODIFICAR"].DisplayIndex = 4;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text == "Agregar Butaca")
            {
                if ((txtNumeroButaca.Text.Length > 0) && (cmbPiso.Text.Length > 0) && (cmbTipo.Text.Length > 0))
                {
                    bool flag = true;



                    foreach (Butaca butaca in _elMicro.BUTACAS)
                    {
                        if (butaca.NUMERO == int.Parse(txtNumeroButaca.Text))
                            flag = false;
                    }

                    if (flag)
                    {
                        Butaca auxButaca = new Butaca();
                        auxButaca.NUMERO = int.Parse(txtNumeroButaca.Text);
                        auxButaca.PATENTE = _elMicro.PATENTE;
                        auxButaca.PISO = int.Parse(cmbPiso.Text);
                        auxButaca.TIPO = cmbTipo.Text;
                        _butacaManager.agregarButaca(auxButaca);
                        MessageBox.Show("Se inserto la butaca " + auxButaca.NUMERO.ToString() + " ");



                        _elMicro.BUTACAS.Add(auxButaca);
                        datagvButca.DataSource = _elMicro.BUTACAS;

                    }
                    else
                    {
                        MessageBox.Show("El número de butaca ingresado ya existe.");
                    }
                    txtNumeroButaca.Clear();
                }
            }
            else
            {
                if ((txtNumeroButaca.Text.Length > 0) && (cmbPiso.Text.Length > 0) && (cmbTipo.Text.Length > 0))
                {

                    if (_butacaAModificar != int.Parse(txtNumeroButaca.Text))
                    {
                        bool flag = true;



                        foreach (Butaca butaca in _elMicro.BUTACAS)
                        {
                            if (butaca.NUMERO == int.Parse(txtNumeroButaca.Text))
                                flag = false;
                        }

                        if (flag)
                        {
                            Butaca aux = new Butaca();
                            aux.TIPO = cmbTipo.Text;
                            aux.PISO = int.Parse(cmbPiso.Text);
                            aux.NUMERO = int.Parse(txtNumeroButaca.Text);
                            aux.PATENTE = txtPatente.Text;
                            _butacaManager.modificarButacaCompleta(aux, _butacaAModificar);
                            MessageBox.Show("Butaca "+ _butacaAModificar +" se modifico con el nuevo numero " + aux.NUMERO + " con exito. Todos sus pasajes vendidos que todavia no hayan viajado, sufrieron esta modificacion en el numero de butaca");
                            btnAgregar.Text = "Agregar Butaca";
                            txtNumeroButaca.Clear();
                            
                            Butaca butacaABorrar = new Butaca();

                            foreach(Butaca unaButaca in _elMicro.BUTACAS){

                                if (unaButaca.NUMERO == _butacaAModificar)
                                    butacaABorrar = unaButaca;
                            }

                            _elMicro.BUTACAS.Remove(butacaABorrar);
                            _elMicro.BUTACAS.Add(aux);


                        }
                        else
                        {
                            MessageBox.Show("El número de butaca ingresado ya existe, por favor elija otro");
                        }
                    }
                    else
                    {
                        Butaca aux = new Butaca();
                        aux.TIPO = cmbTipo.Text;
                        aux.PISO = int.Parse(cmbPiso.Text);
                        aux.NUMERO = _butacaAModificar;
                        aux.PATENTE = txtPatente.Text;
                        _butacaManager.modificarButacaPropiedades( aux);
                        MessageBox.Show("Butaca "+ aux.NUMERO +" modificada con exito");
                        btnAgregar.Text = "Agregar Butaca";
                        txtNumeroButaca.Clear();

                        Butaca butacaABorrar = new Butaca();

                        foreach (Butaca unaButaca in _elMicro.BUTACAS)
                        {

                            if (unaButaca.NUMERO == _butacaAModificar)
                                butacaABorrar = unaButaca;
                        }

                        _elMicro.BUTACAS.Remove(butacaABorrar);
                        _elMicro.BUTACAS.Add(aux);
                    }

                    
                }
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            recargarButacas(this, new MicroQueSePasa() { Micro = _elMicro });
            this.Close();
        }

        private void txtNumeroButaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }

        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                } 
        
        }

        private void datagvButca_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                var dataSource = datagvButca.DataSource as BindingList<Butaca>;
                var butaca = dataSource[e.RowIndex];

                _butacaAModificar = butaca.NUMERO;
                txtNumeroButaca.Text = butaca.NUMERO.ToString();
                cmbPiso.Text = butaca.PISO.ToString();
                cmbTipo.Text = butaca.TIPO;

                btnAgregar.Text = "Modificar Butaca";
            }
        }
    }
}

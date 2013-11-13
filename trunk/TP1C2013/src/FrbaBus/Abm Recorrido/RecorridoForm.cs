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
using FrbaBus.Core;


namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoForm : Form
    {

        private RecorridoManager _recorridoManager = new RecorridoManager();

        public RecorridoForm()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (datagvRecorrido.SelectedRows == null || datagvRecorrido.SelectedRows.Count == 0) return;
            var row = datagvRecorrido.SelectedRows[0];
            var recorrido = row.DataBoundItem as Recorrido;

            if (MessageBox.Show(string.Format("Desea eliminar el recorrido {0}?", recorrido.RECORRIDO_CODIGO)
                , "Eliminar recorrido", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _recorridoManager.BorrarRecorrido(recorrido);
                    var dataSource = datagvRecorrido.DataSource as BindingList<Recorrido>;

                    int auxIndex = row.Index;
                    dataSource.Remove(recorrido);
                    recorrido.BAJA_LOGICA = true;
                    dataSource.Insert(auxIndex, recorrido);
                    datagvRecorrido.Refresh();
                    MessageBox.Show(string.Format("Recorrido {0} fue eliminado", recorrido.RECORRIDO_CODIGO));
                }
                catch
                {
                    MessageBox.Show("Error al eliminar el recorrido");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (datagvRecorrido.SelectedRows == null || datagvRecorrido.SelectedRows.Count == 0) return;
            var row = datagvRecorrido.SelectedRows[0];
            var recorrido = row.DataBoundItem as Recorrido;


            var agregarModificarRecorridos = new AgregarModificarRecorrido(recorrido);
            agregarModificarRecorridos.OnRecorridoeUpdated += new EventHandler<RecorridoQueSePasa>(agregarModificarRecorrido_OnRecorridoeUpdated);
            agregarModificarRecorridos.ShowDialog();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var agregarModificarRecorrido = new AgregarModificarRecorrido();
            agregarModificarRecorrido.OnRecorridoeUpdated += new EventHandler<RecorridoQueSePasa>(agregarModificarRecorrido_OnRecorridoeUpdated);
            agregarModificarRecorrido.ShowDialog();
        }

        void agregarModificarRecorrido_OnRecorridoeUpdated(object sender, RecorridoQueSePasa e)
        {
            try
            {
                var dataSource = datagvRecorrido.DataSource as BindingList<Recorrido>;
                var manager = new RecorridoManager();
                manager.SalvarRecorrido(e.Recorrido);
                MessageBox.Show(string.Format("Se guardo correctamente el recorrido {0}.", e.Recorrido.RECORRIDO_CODIGO));


                if (dataSource.Contains(e.Recorrido))
                {
                    int aux = dataSource.IndexOf(e.Recorrido);
                    dataSource.Remove(e.Recorrido);
                    dataSource.Insert(aux, e.Recorrido);
                }
                else
                {
                    dataSource.Add(e.Recorrido);
                }
                datagvRecorrido.Refresh();
            }
            catch
            {
                MessageBox.Show("Ya existia una terna ciudad origen, ciudad destino y tipo servicio con esos valores. Se actualizaron los precios");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dataSource = _recorridoManager.GetAll();
            datagvRecorrido.DataSource = dataSource;
            datagvRecorrido.Columns["Modificar"].DisplayIndex = 9;
            datagvRecorrido.Columns["BajaLogica"].DisplayIndex = 9;
        }

        private void datagvRecorrido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {

                var dataSource = datagvRecorrido.DataSource as BindingList<Recorrido>;
                var recorrido = dataSource[e.RowIndex];

                if (recorrido.BAJA_LOGICA == true)
                    MessageBox.Show("El recorrido esta dado de baja lógica. No se puede realizar la operacion.");
                else if (e.ColumnIndex == 0)
                {
                    var agregarModificarRecorridos = new AgregarModificarRecorrido(recorrido);
                    agregarModificarRecorridos.OnRecorridoeUpdated += new EventHandler<RecorridoQueSePasa>(agregarModificarRecorrido_OnRecorridoeUpdated);
                    agregarModificarRecorridos.ShowDialog();
                }
                else
                {
                     if (MessageBox.Show(string.Format("Desea eliminar el recorrido {0}?", recorrido.RECORRIDO_CODIGO)
                , "Eliminar recorrido", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    _recorridoManager.BorrarRecorrido(recorrido);

                    int aux = dataSource.IndexOf(recorrido);
                    dataSource.Remove(recorrido);
                    recorrido.BAJA_LOGICA = true;
                    dataSource.Insert(aux, recorrido);

                    MessageBox.Show(string.Format("Recorrido {0} fue eliminado", recorrido.RECORRIDO_CODIGO));
                }
                catch
                {
                    MessageBox.Show("Error al eliminar el recorrido");
                }
            }
                }
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            ViewsManager.LoadView(new FrbaBus.MenuAuxiliar());
        }
    }
}

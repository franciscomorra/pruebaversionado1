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

namespace FrbaBus.Abm_Micro
{
    public partial class MicroForm : Form
    {

        private MicroManager _microManager = new MicroManager();
        private bool _actualizar;
        
        
        
        public MicroForm()
        {
            InitializeComponent();
            datagvMicro.Show();
        }

        private void MicroForm_Load(object sender, EventArgs e)
        {
            BindingList<Micro> dataSource = _microManager.GetAll();
            
            datagvMicro.DataSource = dataSource;
            foreach (Micro micro in dataSource)
            {
                micro.CANT_BUTACAS = micro.BUTACAS.Count;
            }
            datagvMicro.Columns["AgregarButaca"].DisplayIndex = 11;
            datagvMicro.Columns["ModificarMicro"].DisplayIndex = 11;
            datagvMicro.Columns["BajaDefinitiva"].DisplayIndex = 11;
            datagvMicro.Columns["BajaTemporal"].DisplayIndex = 11;
         

        }

        private void Butacas_Click(object sender, EventArgs e)
        {
            if (datagvMicro.SelectedRows == null || datagvMicro.SelectedRows.Count == 0) return;
            var row = datagvMicro.SelectedRows[0];
            var micro = row.DataBoundItem as Micro;

            var ButacasFormulario = new FrbaBus.Abm_Micro.ButacaForm(micro);
            ButacasFormulario.recargarButacas += new EventHandler<MicroQueSePasa>(ButacaForm_recargarButaca);
            ButacasFormulario.ShowDialog();

            
            
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (datagvMicro.SelectedRows == null || datagvMicro.SelectedRows.Count == 0) return;
            var row = datagvMicro.SelectedRows[0];
            var micro = row.DataBoundItem as Micro;
            if (MessageBox.Show(string.Format("Desea eliminar el Micro {0}?", micro.PATENTE)
               , "Eliminar patente", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                try
                {
                    _microManager.BorrarMicro(micro);
                    var dataSource = datagvMicro.DataSource as BindingList<Micro>;

                    int auxIndex = row.Index;
                    dataSource.Remove(micro);
                    micro.FECHA_BAJA_DEFINITIVA = FrbaBus.Common.Configuracion.fechaAhora();
                    dataSource.Insert(auxIndex, micro);
                    datagvMicro.Refresh();
                    MessageBox.Show(string.Format("El micro con patente {0} fue eliminado", micro.PATENTE));
                }
                catch
                {
                    MessageBox.Show("Error al eliminar el micro");
                }
            }

        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            _actualizar = true;
            if (datagvMicro.SelectedRows == null || datagvMicro.SelectedRows.Count == 0) return;
            var row = datagvMicro.SelectedRows[0];
            var micro = row.DataBoundItem as Micro;

            var agregarModificarMicros = new AgregarModificarMicros(micro);
            agregarModificarMicros.OnMicroeUpdated += new EventHandler<MicroQueSePasa>(agregarEditarMicro_OnRoleUpdated);
            agregarModificarMicros.ShowDialog();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            _actualizar = false;
            var agregarModificarMicros = new AgregarModificarMicros();
            agregarModificarMicros.OnMicroeUpdated += new EventHandler<MicroQueSePasa>(agregarEditarMicro_OnRoleUpdated);
            agregarModificarMicros.ShowDialog();
        }


        void agregarEditarMicro_OnRoleUpdated(object sender, MicroQueSePasa e)
        {
           try
           {
                var dataSource = datagvMicro.DataSource as BindingList<Micro>;
                if (string.IsNullOrEmpty(e.Micro.PATENTE))
                {
                    if (dataSource.Where(x => x.PATENTE.Trim().ToUpperInvariant() == e.Micro.PATENTE.Trim().ToUpperInvariant()).Count() >= 1)
                    {
                        MessageBox.Show("La patente del Micro ya esta, ingrese otra porfavor");
                        return;
                    }
                }
                var manager = new MicroManager();
                if (_actualizar) { manager.UpdatearMicro(e.Micro); }
                else {
                    e.Micro.FECHA_ALTA = FrbaBus.Common.Configuracion.fechaAhora();
                    manager.InsertarMicro(e.Micro);  }
                MessageBox.Show(string.Format("Se guardo correctamente el micro {0}.", e.Micro.PATENTE));


                if (dataSource.Contains(e.Micro))
                {
                    int aux = dataSource.IndexOf(e.Micro);
                    dataSource.Remove(e.Micro);
                    dataSource.Insert(aux, e.Micro);
                }
                else
                {
                    dataSource.Add(e.Micro);
                }
                datagvMicro.Refresh();
           }
           catch
           {
                MessageBox.Show("No se pudo guardar el micro.");
           }

        }

        void ButacaForm_recargarButaca(object sender, MicroQueSePasa e)
        {
            var dataSource = datagvMicro.DataSource as BindingList<Micro>;

            int aux = dataSource.IndexOf(e.Micro);
            dataSource.Remove(e.Micro);
            e.Micro.CANT_BUTACAS = e.Micro.BUTACAS.Count;
            dataSource.Insert(aux, e.Micro);
            
        }

        void darDeBajaDefinitiva(object sender, MicroQueSePasa e)
        {
            var dataSource = datagvMicro.DataSource as BindingList<Micro>;

            foreach (Micro micro in dataSource)
            {
                if (micro.PATENTE == e.Micro.PATENTE)
                    micro.FECHA_BAJA_DEFINITIVA = e.Micro.FECHA_BAJA_DEFINITIVA;
            }

            datagvMicro.Refresh();


            MessageBox.Show(string.Format("El micro con patente {0} fue eliminado", e.Micro.PATENTE));
        }

        private void datagvMicro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex >= 0 && e.ColumnIndex <= 3)
            {

                var dataSource = datagvMicro.DataSource as BindingList<Micro>;
                var micro = dataSource[e.RowIndex];

                if (micro.FECHA_BAJA_DEFINITIVA.HasValue)
                    MessageBox.Show("El micro esta dado de baja. No se puede realizar la operacion.");

                else
                {

                    if (e.ColumnIndex == 0)
                    {

                        var ButacasFormulario = new FrbaBus.Abm_Micro.ButacaForm(micro);
                        ButacasFormulario.recargarButacas += new EventHandler<MicroQueSePasa>(ButacaForm_recargarButaca);
                        ButacasFormulario.ShowDialog();
                    }

                    if (e.ColumnIndex == 1)
                    {
                        _actualizar = true;

                        var agregarModificarMicros = new AgregarModificarMicros(micro);
                        agregarModificarMicros.OnMicroeUpdated += new EventHandler<MicroQueSePasa>(agregarEditarMicro_OnRoleUpdated);
                        agregarModificarMicros.ShowDialog();
                    }

                    if (e.ColumnIndex == 2)
                    {
                        if (MessageBox.Show(string.Format("Desea eliminar el Micro {0}?", micro.PATENTE)
                   , "Eliminar patente", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {

                            try
                            {
                                var agregarModificarMicros = new BajaDefiTempo(micro, true);
                                agregarModificarMicros.MicroparaBaja += new EventHandler<MicroQueSePasa>(darDeBajaDefinitiva);
                                agregarModificarMicros.ShowDialog();

                            }
                            catch
                            {
                                MessageBox.Show("Error al dar de baja definitiva el micro");
                            }
                        }
                    }

                    if (e.ColumnIndex == 3)
                    {
                        if (MessageBox.Show(string.Format("Desea dar de baja temporal al Micro {0}?", micro.PATENTE)
                   , "Dar baja temporal", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {

                            try
                            {
                                var agregarModificarMicros = new BajaDefiTempo(micro, false);
                                agregarModificarMicros.MicroparaBaja += new EventHandler<MicroQueSePasa>(darDeBajaDefinitiva);
                                agregarModificarMicros.ShowDialog();
                            }
                            catch
                            {
                                MessageBox.Show("Error al dar de baja temporal el micro");
                            }
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

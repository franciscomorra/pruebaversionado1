using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicaFrba.Core;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;

namespace ClinicaFrba.ReportesForm
{
    [PermissionRequired(Functionalities.ListarEstadisticas)]
    public partial class ReportesForm : Form
    {
        private ReportesManager _reporteManager = new ReportesManager();

        public ReportesForm()
        {
            InitializeComponent();
        }

        private void ListadoEstadisticoForm_Load(object sender, EventArgs e)
        {
            cbxReportType.DataSource = _reporteManager.GetReportTypes();
            cbxReportType.SelectedIndex = 0;
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.Subtract(TimeSpan.FromDays(180));
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde debe ser menor o igual que la fecha hasta");
            }
            dataGridView.DataSource = _reporteManager.GetReporte(cbxReportType.SelectedItem as TipoReporte, dtpDesde.Value, dtpHasta.Value);
            dataGridView.Refresh();
        }
    }
}

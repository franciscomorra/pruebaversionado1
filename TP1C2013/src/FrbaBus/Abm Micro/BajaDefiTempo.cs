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
    public partial class BajaDefiTempo : Form
    {
        public event EventHandler<MicroQueSePasa> MicroparaBaja;
        public Micro _Micro;
        bool _definitiva;
        MicroManager _microManager = new MicroManager();

        public BajaDefiTempo(Micro micro, bool definitiva)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            _Micro = micro;
            _definitiva = definitiva;
            if (definitiva) dateTimePicker1.Visible = false;
            
            dateTimePicker1.MinDate = FrbaBus.Common.Configuracion.fechaAhora();
            dateTimePicker2.MinDate = FrbaBus.Common.Configuracion.fechaAhora();
            dateTimePicker1.Value = dateTimePicker2.Value;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String i;
            if (_definitiva)
            {
                _Micro.FECHA_BAJA_DEFINITIVA = dateTimePicker2.Value;
                i = _microManager.bajaDefinitivaConReemplazo(FrbaBus.Common.Configuracion.fechaAhora(), _Micro);
                if (i == "SinPatente")
                    MessageBox.Show("No se encontro un micro para realizar el Reemplazo. Se han cancelado los pasajes y los paquetes afectados de forma definitiva.");
                else
                    MessageBox.Show("Los viajes correspondientes al micro han sido asignados al micro "+i+" .");
                MicroparaBaja(this, new MicroQueSePasa() { Micro = _Micro });
            }
            else
            {
                i = _microManager.bajaTemporalConReemplazo(FrbaBus.Common.Configuracion.fechaAhora(), _Micro, dateTimePicker1.Value, dateTimePicker2.Value);
                if (i == "SinPatente")
                    MessageBox.Show("No se encontro un micro para realizar el Reemplazo. Se han cancelado los pasajes y los paquetes afectados de forma definitiva.");
                else if (i == null)
                    MessageBox.Show("Las fechas de la baja temporal ingresada, coincide con las fechas de otra baja temporal existente para dicho micro.");
                else
                    MessageBox.Show("Los viajes correspondientes al micro han sido asignados al micro " + i + " .");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_definitiva)
            {
                _Micro.FECHA_BAJA_DEFINITIVA = dateTimePicker2.Value;
                _microManager.bajaDefinitivaSinReemplazo(FrbaBus.Common.Configuracion.fechaAhora(), _Micro);
                MicroparaBaja(this, new MicroQueSePasa() { Micro = _Micro });
            }
            else
            {
                if (!_microManager.bajaTemporalSinReemplazo(FrbaBus.Common.Configuracion.fechaAhora(), _Micro, dateTimePicker1.Value, dateTimePicker2.Value))
                    MessageBox.Show("Las fechas de la baja temporal ingresada, coincide con las fechas de otra baja temporal existente para dicho micro.");
            }
            this.Close();
        }
    }
}

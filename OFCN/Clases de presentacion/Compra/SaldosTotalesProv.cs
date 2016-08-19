using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    public partial class frmSaldosTotalesProv : Form
    {
        public frmSaldosTotalesProv()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerSaldoTotalProv frmReporte = new frmVerSaldoTotalProv();
                crSaldoTotalProv rptLista = frmReporte.cargarReporte(dtpFechaHasta.Value);
                frmReporte.crvSaldoTotalProv.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Saldos Totales");
            }
        }
    }
}

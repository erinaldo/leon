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
    public partial class frmSaldosTotales : Form
    {
        public frmSaldosTotales()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
            frmVerSaldoTotal frmReporte = new frmVerSaldoTotal();
            crSaldoTotal rptLista = frmReporte.cargarReporte(dtpFechaHasta.Value);
            frmReporte.crvSaldoTotal.ReportSource = rptLista;
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

        private void frmSaldosTotales_Load(object sender, EventArgs e)
        {

        }
    }
}

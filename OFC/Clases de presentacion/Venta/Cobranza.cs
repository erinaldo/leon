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
    public partial class frmCobranza : Form
    {
        public frmCobranza()
        {
            InitializeComponent();
        }

        private void frmCobranzaFacturacion_Load(object sender, EventArgs e)
        {
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerCobranza frmReporte = new frmVerCobranza();
                crCobranza rptLista = frmReporte.cargarReporte(dtpFechaDesde.Value, dtpFechaHasta.Value);
                frmReporte.crvCobranza.ReportSource = rptLista;
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
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Cobranzas");
            }
        }
    }
}

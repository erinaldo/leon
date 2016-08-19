using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    class IniciarCrystalReports
    {
        public static void ejecutarDummy()
        {
            try
            {

                //cargo un reporte cualquiera...
                System.Windows.Forms.DateTimePicker dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
                frmVerSaldoTotal frmReporte = new frmVerSaldoTotal();
                crSaldoTotal rptLista = frmReporte.cargarReporte(dtpFechaHasta.Value);
                frmReporte.crvSaldoTotal.ReportSource = rptLista;
                rptLista.Dispose();
                frmReporte.Dispose();

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Ocurrio un error al iniciar Crystal Reports");
            }
        }


    }
}

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
    public partial class frmImpresionDeOrdenDePago : Form
    {
        string cod_comprobante;
        bool existe_retencion;
        string cod_proveedor;
        DateTime fecha_comprobante;

        public frmImpresionDeOrdenDePago(string p_cod_comprobante_pago, bool p_existe_retencion, bool continuar, string p_cod_proveedor, DateTime p_fecha_comprobante)
        {
            InitializeComponent();
            cod_comprobante = p_cod_comprobante_pago;
            existe_retencion = p_existe_retencion;
            cod_proveedor = p_cod_proveedor;
            fecha_comprobante = p_fecha_comprobante;

            if (continuar)
            {
                btnContinuar.Visible = true;
            }
            else
            {
                btnContinuar.Visible = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
            formProcesamiento.Show();

            crOrdenDePago rptLista = GenerarImpresionOrdenDePago.cargarReporte(cod_comprobante);
            rptLista.PrintToPrinter(2, false, 1, 1);
            rptLista.Dispose();

            if (existe_retencion)
            {
                crComprobanteDeRetencion rptListaR = GenerarImpresionOrdenDePago.cargarReporteComprobanteDeRetencion(cod_comprobante, cod_proveedor, fecha_comprobante);
                rptListaR.PrintToPrinter(2, false, 1, 1);
                rptListaR.Dispose();
            }

            formProcesamiento.Dispose();
        }

        private void btnVistaPreliminar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerOrdenDePago frmReporte = new frmVerOrdenDePago();
                crOrdenDePago rptLista = GenerarImpresionOrdenDePago.cargarReporte(cod_comprobante);
                frmReporte.crvOrdenDePago.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Imprimir Orden De Pago");
            }
        }

        private void btnVistaPreliminarRT_Click(object sender, EventArgs e)
        {
            try
            {
                //ahora
                frmVerRetencion frmReporte = new frmVerRetencion();
                crComprobanteDeRetencion rptLista = GenerarImpresionOrdenDePago.cargarReporteComprobanteDeRetencion(cod_comprobante, cod_proveedor, fecha_comprobante);
                frmReporte.crvRetencion.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Imprimir Detalle Retención");
            }
        }

        private void frmImpresionDeOrdenDePago_Load(object sender, EventArgs e)
        {
            if (!existe_retencion)
            {
                btnVistaPreliminarRT.Enabled = false;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


    }
}

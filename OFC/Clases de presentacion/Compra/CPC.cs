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
    public partial class frmCPC : Form
    {
        public frmCPC()
        {
            InitializeComponent();
        }

        private void frmCPC_Load(object sender, EventArgs e)
        {

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            frmABMDeProveedores frmProvee = new frmABMDeProveedores();
            frmProvee.ShowDialog();
            frmProvee.Dispose();
        }

        private void btnConcepto_Click(object sender, EventArgs e)
        {
            frmABMDeConceptos frmConcepto = new frmABMDeConceptos();
            frmConcepto.ShowDialog();
            frmConcepto.Dispose();
        }

        private void btnCCMovimiento_Click(object sender, EventArgs e)
        {
            frmMovimientosCuentaCorrienteProveedor frmCCProv = new frmMovimientosCuentaCorrienteProveedor();
            frmCCProv.ShowDialog();
            frmCCProv.Dispose();
        }

        private void btnCompraConceptos_Click(object sender, EventArgs e)
        {
            frmFacturaConcepto frmFacturaConc = new frmFacturaConcepto();
            frmFacturaConc.ShowDialog();
            frmFacturaConc.Dispose();
        }

        private void btnCompraArticulos_Click(object sender, EventArgs e)
        {
            frmFacturaArticulo frmFacturaArt = new frmFacturaArticulo();
            frmFacturaArt.ShowDialog();
            frmFacturaArt.Dispose();
        }

        private void btnIniciarFactura_Click(object sender, EventArgs e)
        {
            frmIniciarFacturaDeCompra frmFacturaInicial = new frmIniciarFacturaDeCompra();
            frmFacturaInicial.ShowDialog();
            frmFacturaInicial.Dispose();
        }

        private void btnListaDePrecio_Click(object sender, EventArgs e)
        {
            frmListaDePrecioCompra frmListaDePrecio = new frmListaDePrecioCompra();
            frmListaDePrecio.ShowDialog();
            frmListaDePrecio.Dispose();
        }

        private void btnCCOrdenDePago_Click(object sender, EventArgs e)
        {
            frmOrdenDePago frmOrdDePago = new frmOrdenDePago();
            frmOrdDePago.ShowDialog();
            frmOrdDePago.Dispose();
        }

        private void btnLibroIvaCompras_Click(object sender, EventArgs e)
        {
            frmLibroIvaCompras frmLibro = new frmLibroIvaCompras();
            frmLibro.ShowDialog();
            frmLibro.Dispose();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            frmPagos frmPag = new frmPagos();
            frmPag.ShowDialog();
            frmPag.Dispose();
        }

        private void btnNotaDeCreditoDeConceptos_Click(object sender, EventArgs e)
        {
            frmNotaDeCreditoConcepto frmNCConc = new frmNotaDeCreditoConcepto();
            frmNCConc.ShowDialog();
            frmNCConc.Dispose();
        }

        private void btnNotaDeDebitoDeConceptos_Click(object sender, EventArgs e)
        {
            frmNotaDeDebitoConcepto frmNDConc = new frmNotaDeDebitoConcepto();
            frmNDConc.ShowDialog();
            frmNDConc.Dispose();
        }

        private void btnNotaDeDebitoDeArticulos_Click(object sender, EventArgs e)
        {
            frmNotaDeDebitoArticulo frmNDArt = new frmNotaDeDebitoArticulo();
            frmNDArt.ShowDialog();
            frmNDArt.Dispose();
        }

        private void btnNotaDeCreditoDeArticulos_Click(object sender, EventArgs e)
        {
            frmNotaDeCreditoArticulo frmNCArt = new frmNotaDeCreditoArticulo();
            frmNCArt.ShowDialog();
            frmNCArt.Dispose();
        }

        private void btnBuscarComprobante_Click(object sender, EventArgs e)
        {
            frmBuscarComprobanteDeCompra frmBusqueda = new frmBuscarComprobanteDeCompra();
            frmBusqueda.ShowDialog();
            frmBusqueda.Dispose();
        }
    }
}

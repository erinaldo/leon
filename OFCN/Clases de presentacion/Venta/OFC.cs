using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

//feb 1.9.1 solo remito
namespace OFC
{
    public partial class frmOFC : Form
    {
        private UsuarioDatos CurrentUser = null;
        public frmOFC(UsuarioDatos user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void OFC_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void OFC_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(982, 684);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 50, Screen.PrimaryScreen.Bounds.Height - 75);
            }

            CurrentUser.loadPermisos("frmOFC");
            configurarAccesoFormulario(CurrentUser.ListaElementos);
            //if (!BaseDeDatos.realizarBackUp())
            //{
            //    MessageBox.Show("Error al realizar BACKUP de la base de datos. Debe contactar al administrador del sistema.", "Base de Datos");
            //}
        }

        private void configurarAccesoFormulario(List<string> ListaElementos)
        {
            if (ListaElementos.FindIndex(x => x == "pnlOrdenesDeTrabajo") != -1)
            {
                pnlOrdenesDeTrabajo.Visible = true;
            }
            else
            {
                pnlOrdenesDeTrabajo.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnOdtNueva") != -1)
            {
                btnOdtNueva.Visible = true;
            }
            else
            {
                btnOdtNueva.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnOdtBusqueda") != -1)
            {
                btnOdtBusqueda.Visible = true;
            }
            else
            {
                btnOdtBusqueda.Visible = false;
            }
            //if (ListaElementos.FindIndex(x => x == "btnTrabajosYCubiertas") != -1)
            //{
            //    btnTrabajosYCubiertas.Visible = true;

            //}
            //else
            //{
            //    btnTrabajosYCubiertas.Visible = false;
            //}
            if (ListaElementos.FindIndex(x => x == "pnlFacturacion") != -1)
            {
                pnlFacturacion.Visible = true;
            }
            else
            {
                pnlFacturacion.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnFacturacionAutomatica") != -1)
            {
                btnFacturacionAutomatica.Visible = true;
            }
            else
            {
                btnFacturacionAutomatica.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnFacturacionManual") != -1)
            {
                btnFacturacionManual.Visible = true;
            }
            else
            {
                btnFacturacionManual.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "pnlCuentaCorriente") != -1)
            {
                pnlCuentaCorriente.Visible = true;
            }
            else
            {
                pnlCuentaCorriente.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCCMovimiento") != -1)
            {
                btnCCMovimiento.Visible = true;
            }
            else
            {
                btnCCMovimiento.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCCRecibo") != -1)
            {
                btnCCRecibo.Visible = true;
            }
            else
            {
                btnCCRecibo.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCCNotaDeDebito") != -1)
            {
                btnCCNotaDeDebito.Visible = true;
            }
            else
            {
                btnCCNotaDeDebito.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCCNotaDeCredito") != -1)
            {
                btnCCNotaDeCredito.Visible = true;
            }
            else
            {
                btnCCNotaDeCredito.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "pnlClientes") != -1)
            {
                pnlClientes.Visible = true;
            }
            else
            {
                pnlClientes.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCliente") != -1)
            {
                btnCliente.Visible = true;
            }
            else
            {
                btnCliente.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnProductosYServicios") != -1)
            {
                btnProductosYServicios.Visible = true;
            }
            else
            {
                btnProductosYServicios.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnListaDePrecio") != -1)
            {
                btnListaDePrecio.Visible = true;
            }
            else
            {
                btnListaDePrecio.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "pnlEspecial") != -1)
            {
                pnlEspecial.Visible = true;
            }
            else
            {
                pnlEspecial.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnBuscarComprobante") != -1)
            {
                btnBuscarComprobante.Visible = true;
            }
            else
            {
                btnBuscarComprobante.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnHistoricoDeCubiertas") != -1)
            {
                btnHistoricoDeCubiertas.Visible = true;
            }
            else
            {
                btnHistoricoDeCubiertas.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnCobranza") != -1)
            {
                btnCobranza.Visible = true;
            }
            else
            {
                btnCobranza.Visible = false;
            }
            if (ListaElementos.FindIndex(x => x == "btnLibroIvaVentas") != -1)
            {
                btnLibroIvaVentas.Visible = true;
            }
            else
            {
                btnLibroIvaVentas.Visible = false;
            }
            //feb 1.8 fix
            if (ListaElementos.FindIndex(x => x == "btnTalonarioDeRecibo") != -1)
            {
                btnTalonarioDeRecibo.Visible = true;
            }
            else
            {
                btnTalonarioDeRecibo.Visible = false;
            }

            //if (ListaElementos.FindIndex(x => x == "pnlConfiguracion") != -1)
            //{
            //    pnlConfiguracion.Visible = true;
            //}
            //else
            //{
            //    pnlConfiguracion.Visible = false;
            //}
            //if (ListaElementos.FindIndex(x => x == "btnParametrosDeSistema") != -1)
            //{
            //    btnParametrosDeSistema.Visible = true;
            //}
            //else
            //{
            //    btnParametrosDeSistema.Visible = false;
            //}
            //if (ListaElementos.FindIndex(x => x == "pnlEstadisticas") != -1)
            //{
            //    pnlEstadisticas.Visible = true;
            //}
            //else
            //{
            //    pnlEstadisticas.Visible = false;
            //}
            //if (ListaElementos.FindIndex(x => x == "btnEstadisticas") != -1)
            //{
            //    btnEstadisticas.Visible = true;
            //}
            //else
            //{
            //    btnEstadisticas.Visible = false;
            //}
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmABMDeClientes frmCliente = new frmABMDeClientes();
            frmCliente.ShowDialog();
            frmCliente.Dispose();
        }

        private void btnOrdenesDeTrabajo_Click(object sender, EventArgs e)
        {
            frmDetalleDeOrdenesDeTrabajo frmOrdenesDetalle = new frmDetalleDeOrdenesDeTrabajo();
            frmOrdenesDetalle.ShowDialog();
            frmOrdenesDetalle.Dispose();           
        }

        private void btnOdtNueva_Click(object sender, EventArgs e)
        {
            frmNuevaOrdenDeTrabajo frmNuevaOrden = new frmNuevaOrdenDeTrabajo();
            frmNuevaOrden.ShowDialog();
            frmNuevaOrden.Dispose();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            frmFacturacion frmFactura = new frmFacturacion();
            frmFactura.FormClosing += new FormClosingEventHandler(f_FormClosingFact);
            frmFactura.ShowDialog();
            frmFactura.Dispose();
        }

        //feb 1.9.1
        void f_FormClosingFact(object sender, FormClosingEventArgs e)
        {
            Factura _factura = new Factura();
            _factura.refreshGridData();

            Remito _remito = new Remito();
            _remito.refreshGridData();

            if (_factura.GridDataList.Count > 0 || _remito.GridDataList.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Por favor registre los comprobantes generados antes de cerrar.", "Comprobantes");

            }
        }

        //feb 1.9.1
        void f_FormClosingDespachar(object sender, FormClosingEventArgs e)
        {
            Remito _remito = new Remito();
            _remito.refreshGridData();

            if (_remito.GridDataList.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Por favor registre los comprobantes generados antes de cerrar.", "Comprobantes");
            }
        }

        void f_FormClosingCredito (object sender, FormClosingEventArgs e)
        {
            NotaCredito _nota_credito = new NotaCredito();
            _nota_credito.refreshGridData();

            if (_nota_credito.GridDataList.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Por favor registre los comprobantes generados antes de cerrar.", "Nota de Crédito");

            }
        }

        void f_FormClosingDebito(object sender, FormClosingEventArgs e)
        {
            NotaDebito _nota_debito = new NotaDebito();
            _nota_debito.refreshGridData();

            if (_nota_debito.GridDataList.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Por favor registre los comprobantes generados antes de cerrar.", "Nota de Débito");

            }
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            frmMovimientosDeCuentaCorriente frmMovCuentaCorriente = new frmMovimientosDeCuentaCorriente();
            frmMovCuentaCorriente.ShowDialog();
            frmMovCuentaCorriente.Dispose();
        }

        private void btnProductosYServicios_Click(object sender, EventArgs e)
        {
            frmABMProductosYServicios frmProdServ = new frmABMProductosYServicios();
            frmProdServ.ShowDialog();
            frmProdServ.Dispose();
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            frmRecibo frmRec = new frmRecibo();
            frmRec.ShowDialog();
            frmRec.Dispose();
        }

        private void btnNotaDeCredito_Click(object sender, EventArgs e)
        {
            frmNotaDeCredito frmNotaCredito = new frmNotaDeCredito();
            frmNotaCredito.FormClosing += new FormClosingEventHandler(f_FormClosingCredito);
            frmNotaCredito.ShowDialog();
            frmNotaCredito.Dispose();
        }

        private void btnMdcNotaDeDebito_Click(object sender, EventArgs e)
        {
            frmNotaDeDebito frmNotaDebito = new frmNotaDeDebito();
            frmNotaDebito.FormClosing += new FormClosingEventHandler(f_FormClosingDebito);
            frmNotaDebito.ShowDialog();
            frmNotaDebito.Dispose();
        }

        private void lblMovimientosDeCuenta_Click(object sender, EventArgs e)
        {

        }

        private void btnCCAnulacion_Click(object sender, EventArgs e)
        {

        }

        private void btnListaDePrecio_Click(object sender, EventArgs e)
        {
            frmListaDePrecio frmLista = new frmListaDePrecio();
            frmLista.ShowDialog();
            frmLista.Dispose();
        }

        private void btnFacturacionManual_Click(object sender, EventArgs e)
        {
            frmFacturacionManual frmFactManual = new frmFacturacionManual();
            frmFactManual.FormClosing += new FormClosingEventHandler(f_FormClosingFact);
            frmFactManual.ShowDialog();
            frmFactManual.Dispose();
        }

        private void btnLibroIvaVentas_Click(object sender, EventArgs e)
        {
            frmLibroIvaVentas frmLibro = new frmLibroIvaVentas();
            frmLibro.ShowDialog();
            frmLibro.Dispose();
        }

        //private void btnTrabajoCubierta_Click(object sender, EventArgs e)
        //{
        //    frmTrabajoCubierta frmTrabajoCub = new frmTrabajoCubierta();
        //    frmTrabajoCub.ShowDialog();
        //    frmTrabajoCub.Dispose();
        //}

        private void btnHistoricoDeCubiertas_Click(object sender, EventArgs e)
        {
            frmHistoricoCubiertas frmHistCubiertas = new frmHistoricoCubiertas();
            frmHistCubiertas.ShowDialog();
            frmHistCubiertas.Dispose();
        }

        private void btnBuscarComprobante_Click(object sender, EventArgs e)
        {
            frmBuscarComprobante frmComprobante = new frmBuscarComprobante();
            frmComprobante.ShowDialog();
            frmComprobante.Dispose();
        }

        private void btnCobranzaYFacturacion_Click(object sender, EventArgs e)
        {
            frmCobranza frmCobFact = new frmCobranza();
            frmCobFact.ShowDialog();
            frmCobFact.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            frmDespachar frmDespacha = new frmDespachar();
            frmDespacha.FormClosing += new FormClosingEventHandler(f_FormClosingDespachar); //feb 1.9.1
            frmDespacha.ShowDialog();
            frmDespacha.Dispose();
        }

        private void btnConRemito_Click(object sender, EventArgs e)
        {
            frmFacturacionConRemito frmFacturarRemito = new frmFacturacionConRemito();
            frmFacturarRemito.FormClosing += new FormClosingEventHandler(f_FormClosingFact);
            frmFacturarRemito.ShowDialog();
            frmFacturarRemito.Dispose();
        }

        //feb 1.8
        private void btnTalonarioDeRecibo_Click(object sender, EventArgs e)
        {
            TalonarioDeRecibo frmFacturarRemito = new TalonarioDeRecibo();
            frmFacturarRemito.ShowDialog();
            frmFacturarRemito.Dispose();
        }


    }
}

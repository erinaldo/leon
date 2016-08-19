using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace OFC
{
    public partial class frmBuscarComprobanteDeCompra : Form
    {
        private Proveedores _proveedores;
        private FiltrosABMProveedor _filtroProveedores;
        private TipoComprobante _tipo_comprobante;
        private Comprobantes _comprobantes;
        private FacturaDeCompra _factura;
        private NotaDeCreditoDeCompra _nota_credito;
        private NotaDeDebitoDeCompra _nota_debito;
        private Pago _pago;

        public frmBuscarComprobanteDeCompra()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _filtroProveedores = new FiltrosABMProveedor();
            _tipo_comprobante = new TipoComprobante("COMPRA");
            _comprobantes = new Comprobantes();
            _factura = new FacturaDeCompra();
            _nota_credito = new NotaDeCreditoDeCompra();
            _nota_debito = new NotaDeDebitoDeCompra();
            _pago = new Pago();
        }

        private void frmBuscarComprobanteDeCompra_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarFiltrosBusqueda();
            configurarGridComprobantes();
            deshabilitarAmbosModos();
        }

        private void cargarFiltrosBusqueda()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodProveedor.DataSource = _proveedores.CodDataList;

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDeProveedor.DataSource = _proveedores.NombreDataList;

            this.cbxFiltroTipoDeComprobante.DataSource = _tipo_comprobante.OwnDataList;
            this.cbxFiltroTipoDeComprobante.DisplayMember = "valor";
            this.cbxFiltroTipoDeComprobante.ValueMember = "id";

            //int dias_transcurridos = System.DateTime.Now.Day * (-1);
            //this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-365);
        }

        private void configurarGridComprobantes()
        {
            this.dgvComprobantes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fecha = new DataGridViewTextBoxColumn();
            _fecha.DataPropertyName = "v_fecha";
            _fecha.HeaderText = "Fecha del Comprob.";
            _fecha.Width = 141;
            _fecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha.ReadOnly = true;

            DataGridViewTextBoxColumn _proveedorColum = new DataGridViewTextBoxColumn();
            _proveedorColum.DataPropertyName = "id_proveedor";
            _proveedorColum.HeaderText = "Cod. Proveedor";
            _proveedorColum.Width = 120;
            _proveedorColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _proveedorColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _proveedorColum.ReadOnly = true;

            DataGridViewTextBoxColumn _comprobante = new DataGridViewTextBoxColumn();
            _comprobante.DataPropertyName = "tipo_comprobante";
            _comprobante.HeaderText = "Tipo de Comprobante";
            _comprobante.Width = 170;
            _comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobante = new DataGridViewTextBoxColumn();
            _codComprobante.DataPropertyName = "cod_comprobante";
            _codComprobante.HeaderText = "Nro. Comprobante";
            _codComprobante.Width = 166;
            _codComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.ReadOnly = true;

            this.dgvComprobantes.Columns.Add(_fecha);
            this.dgvComprobantes.Columns.Add(_proveedorColum);
            this.dgvComprobantes.Columns.Add(_comprobante);
            this.dgvComprobantes.Columns.Add(_codComprobante);
        }

        private void cbxFiltroCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDeProveedor.Text = _proveedores.obtenerNombre(this.cbxFiltroCodProveedor.Text);
        }

        private void cbxFiltroNombreDeProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxFiltroNombreDeProveedor.Text);
        }

        private void FilterToObject()
        {
            _filtroProveedores.FiltroCodigo = this.cbxFiltroCodProveedor.Text;
            _filtroProveedores.FiltroNombre = this.cbxFiltroNombreDeProveedor.Text;
            _filtroProveedores.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroProveedores.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(0);
            if (this.cbxFiltroTipoDeComprobante.Text != "")
            {
                int resultIndex = this.cbxFiltroTipoDeComprobante.FindStringExact(cbxFiltroTipoDeComprobante.Text);
                if (resultIndex != -1)
                {
                    _filtroProveedores.FiltroTipoComprobante = long.Parse(this.cbxFiltroTipoDeComprobante.SelectedValue.ToString());
                }
                else
                {
                    _filtroProveedores.FiltroTipoComprobante = -1;
                }
            }

            _filtroProveedores.FiltroNroComprobante = this.txtFiltroNroDeComprobante.Text;

            if (this.chbFacturasIncompletas.Checked)
            {
                _filtroProveedores.FiltroFacturaIncompleta = 'S';
            }
            else
            {
                _filtroProveedores.FiltroFacturaIncompleta = 'N';
            }
        }

        private void completarFiltro()
        {
            if (this.cbxFiltroTipoDeComprobante.Text != "")
            {
                int resultIndex = this.cbxFiltroTipoDeComprobante.FindStringExact(cbxFiltroTipoDeComprobante.Text);
                if (resultIndex != -1)
                {
                    this.cbxFiltroCodProveedor.Text = ComprobanteCompraDTO.obtenerCodProveedor(long.Parse(this.cbxFiltroTipoDeComprobante.SelectedValue.ToString()), this.txtFiltroNroDeComprobante.Text);
                }
            }
        }

        private void cargarGridComprobantes()
        {
            _comprobantes.refreshGridData(_filtroProveedores);
            this.dgvComprobantes.DataSource = _comprobantes.GridDataListProv;
            this.dgvComprobantes.ClearSelection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxFiltroCodProveedor.Text == string.Empty)
            {
                completarFiltro();
            }
            FilterToObject();
            cargarGridComprobantes();
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxFiltroCodProveedor.Text == string.Empty)
                {
                    completarFiltro();
                }
                FilterToObject();
                cargarGridComprobantes();
            }
        }

        private void dgvComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvComprobantes.SelectedRows.Count > 0)
            {
                this.objectToForm((ComprobanteCompraDTO)this.dgvComprobantes.SelectedRows[0].DataBoundItem);
            }
        }

        private void objectToForm(ComprobanteCompraDTO data)
        {
            txtTipoDeComprobante.Text = data.Tipo_comprobante;
            txtNroComprobante.Text = data.Cod_comprobante;
            txtFechaDelComprobante.Text = data.V_fecha;
            txtFechaContable.Text = data.V_fecha_contable;
            this.lblPagado.Visible = false;

            if (data.Tipo_comprobante == "FACTURA A" || data.Tipo_comprobante == "FACTURA B")
            {
                btnImprimir.Enabled = false;
                //btnCompletar.Enabled = xxxx; //lo hace cargarGridFactura()
                //txtFechaDeVencimiento.Text = xxxx; //lo hace cargarGridFactura()
                habilitarModoFacturas();
                configurarGridIVA();
                configurarGridImpuesto();
                //preguntar si es articulo o concepto para configurar la grilla
                if (FacturaDeCompraDTO.esConcepto(data.Id_origen))
                {
                    configurarGridConcepto();
                }
                else
                {
                    configurarGridArticulo();
                }
                cargarGridFactura(data.Id_origen, data);
            }

            if (data.Tipo_comprobante == "NOTA DE CREDITO A" || data.Tipo_comprobante == "NOTA DE CREDITO B")
            {
                btnImprimir.Enabled = false;
                btnCompletar.Enabled = false;
                txtFechaDeVencimiento.Text = string.Empty;
                habilitarModoFacturas();
                configurarGridIVA();
                configurarGridImpuesto();
                //preguntar si es articulo o concepto para configurar la grilla
                if (NotaDeCreditoDeCompraDTO.esConcepto(data.Id_origen))
                {
                    configurarGridConcepto();
                }
                else
                {
                    configurarGridArticulo();
                }
                cargarGridNC(data.Id_origen);
            }

            if (data.Tipo_comprobante == "NOTA DE DEBITO A" || data.Tipo_comprobante == "NOTA DE DEBITO B")
            {
                btnImprimir.Enabled = false;
                btnCompletar.Enabled = false;
                txtFechaDeVencimiento.Text = string.Empty;
                habilitarModoFacturas();
                configurarGridIVA();
                configurarGridImpuesto();
                //preguntar si es articulo o concepto para configurar la grilla
                if (NotaDeDebitoDeCompraDTO.esConcepto(data.Id_origen))
                {
                    configurarGridConcepto();
                }
                else
                {
                    configurarGridArticulo();
                }
                cargarGridND(data.Id_origen);
            }

            if (data.Tipo_comprobante == "ORDEN DE PAGO")
            {
                btnImprimir.Enabled = true;
                btnCompletar.Enabled = false;
                txtFechaDeVencimiento.Text = string.Empty;
                habilitarModoOrdenDePago();
                configurarGridOrdenDePago();
                configurarGridComprobantesRel();
                cargarGridOrdenDePago(data.Id_origen);
            }
        }

        private void habilitarModoOrdenDePago()
        {
            dgvComprobantesRelacionados.Visible = true;
            lblComprobantesRelacionados.Visible = true;
            dgvDetalleIVA.Visible = false;
            lblDetalleIva.Visible = false;
            dgvDetalleImpuesto.Visible = false;
            lblDetalleImpuestos.Visible = false;
        }

        private void habilitarModoFacturas()
        {
            dgvComprobantesRelacionados.Visible = false;
            lblComprobantesRelacionados.Visible = false;
            dgvDetalleIVA.Visible = true;
            lblDetalleIva.Visible = true;
            dgvDetalleImpuesto.Visible = true;
            lblDetalleImpuestos.Visible = true;
        }

        private void deshabilitarAmbosModos()
        {
            dgvComprobantesRelacionados.Visible = false;
            lblComprobantesRelacionados.Visible = false;
            dgvDetalleIVA.Visible = false;
            lblDetalleIva.Visible = false;
            dgvDetalleImpuesto.Visible = false;
            lblDetalleImpuestos.Visible = false;
        }

        private void configurarGridArticulo()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "C."; //xx2
            _cantidad.Width = 30; //xx2 -5
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            //xx2
            DataGridViewTextBoxColumn _unidad = new DataGridViewTextBoxColumn();
            _unidad.DataPropertyName = "unidad";
            _unidad.HeaderText = "Unidad";
            _unidad.Width = 55;
            _unidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _unidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _unidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 80; //xx2 -10
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 289; //xx2 -20
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precio_unitario = new DataGridViewTextBoxColumn();
            _precio_unitario.DataPropertyName = "v_precio_unitario";
            _precio_unitario.HeaderText = "P. Unit."; //xx2
            _precio_unitario.Width = 85; //xx2 -10
            _precio_unitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio_unitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio_unitario.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 85; //xx2 -10
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_cantidad);
            this.dgvComprobanteRegistrado.Columns.Add(_unidad); //xx2
            this.dgvComprobanteRegistrado.Columns.Add(_codigo);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);
            this.dgvComprobanteRegistrado.Columns.Add(_precio_unitario);
            this.dgvComprobanteRegistrado.Columns.Add(_importe);
        }

        private void configurarGridConcepto()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 92;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 427;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 105;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_codigo);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);
            this.dgvComprobanteRegistrado.Columns.Add(_importe);
        }

        private void configurarGridIVA()
        {
            this.dgvDetalleIVA.Columns.Clear();
            this.dgvDetalleIVA.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _porcentaje = new DataGridViewTextBoxColumn();
            _porcentaje.DataPropertyName = "v_porcentaje";
            _porcentaje.HeaderText = "%";
            _porcentaje.Width = 200;
            _porcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 100;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;


            this.dgvDetalleIVA.Columns.Add(_porcentaje);
            this.dgvDetalleIVA.Columns.Add(_importe);

        }

        private void configurarGridImpuesto()
        {
            this.dgvDetalleImpuesto.Columns.Clear();
            this.dgvDetalleImpuesto.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "desc_impuesto";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 150;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _porcentaje = new DataGridViewTextBoxColumn();
            _porcentaje.DataPropertyName = "v_porcentaje";
            _porcentaje.HeaderText = "%";
            _porcentaje.Width = 50;
            _porcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 100;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;


            this.dgvDetalleImpuesto.Columns.Add(_descripcion);
            this.dgvDetalleImpuesto.Columns.Add(_porcentaje);
            this.dgvDetalleImpuesto.Columns.Add(_importe);

        }

        private void cargarGridFactura(long idFactura, ComprobanteCompraDTO data)
        {
            //datos principales
            _factura.refreshGridDataReg(idFactura);
            _factura.GridDataListReg[0].Cod_comprobante = txtNroComprobante.Text;
            _factura.GridDataListReg[0].Fecha_comprobante = data.Fecha_creacion;
            _factura.GridDataListReg[0].Fecha_contable = data.Fecha_contable;
            this.objectToFormFact(_factura.GridDataListReg[0]);

            //detalle de la factura
            _factura.refreshGridDataDetalleReg(idFactura);
            this.dgvComprobanteRegistrado.DataSource = _factura.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();

            //iva
            _factura.refreshGridDataIvaReg(idFactura);
            this.dgvDetalleIVA.DataSource = _factura.GridDataListIvaReg;
            this.dgvDetalleIVA.Font = this.txtTotal.Font;
            this.dgvDetalleIVA.ClearSelection();

            //impuestos
            _factura.refreshGridDataImpuestosReg(idFactura);
            this.dgvDetalleImpuesto.DataSource = _factura.GridDataListImpuestosReg;
            this.dgvDetalleImpuesto.Font = this.txtTotal.Font;
            this.dgvDetalleImpuesto.ClearSelection();
        }

        private void cargarGridNC(long idNotaDeCredito)
        {
            //datos principales
            _nota_credito.refreshGridDataReg(idNotaDeCredito);
            _nota_credito.GridDataListReg[0].Cod_comprobante = txtNroComprobante.Text;
            this.objectToFormFact(_nota_credito.GridDataListReg[0]);

            //detalle de la factura
            _nota_credito.refreshGridDataDetalleReg(idNotaDeCredito);
            this.dgvComprobanteRegistrado.DataSource = _nota_credito.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();

            //iva
            _nota_credito.refreshGridDataIvaReg(idNotaDeCredito);
            this.dgvDetalleIVA.DataSource = _nota_credito.GridDataListIvaReg;
            this.dgvDetalleIVA.Font = this.txtTotal.Font;
            this.dgvDetalleIVA.ClearSelection();

            //impuestos
            _nota_credito.refreshGridDataImpuestosReg(idNotaDeCredito);
            this.dgvDetalleImpuesto.DataSource = _nota_credito.GridDataListImpuestosReg;
            this.dgvDetalleImpuesto.Font = this.txtTotal.Font;
            this.dgvDetalleImpuesto.ClearSelection();
        }

        private void cargarGridND(long idNotaDeDebito)
        {
            //datos principales
            _nota_debito.refreshGridDataReg(idNotaDeDebito);
            _nota_debito.GridDataListReg[0].Cod_comprobante = txtNroComprobante.Text;
            this.objectToFormFact(_nota_debito.GridDataListReg[0]);

            //detalle de la factura
            _nota_debito.refreshGridDataDetalleReg(idNotaDeDebito);
            this.dgvComprobanteRegistrado.DataSource = _nota_debito.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();

            //iva
            _nota_debito.refreshGridDataIvaReg(idNotaDeDebito);
            this.dgvDetalleIVA.DataSource = _nota_debito.GridDataListIvaReg;
            this.dgvDetalleIVA.Font = this.txtTotal.Font;
            this.dgvDetalleIVA.ClearSelection();

            //impuestos
            _nota_debito.refreshGridDataImpuestosReg(idNotaDeDebito);
            this.dgvDetalleImpuesto.DataSource = _nota_debito.GridDataListImpuestosReg;
            this.dgvDetalleImpuesto.Font = this.txtTotal.Font;
            this.dgvDetalleImpuesto.ClearSelection();
        }

        private void objectToFormFact(FacturaDeCompraDTO data)
        {
            this.lblDatosDelProveedor.Text = "COD. PROVEEDOR: " + data.Id_proveedor.ToString() + ", " + "NOMBRE: " + data.Nombre_proveedor.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CONDICIÓN DE COMPRA: " + data.Condicion_compra.ToString();

            if (data.Es_definitiva == 'N')
            {
                btnCompletar.Enabled = true;
            }
            else
            {
                btnCompletar.Enabled = false;
            }

            if (data.Pago == 'S')
            {
                this.lblPagado.Visible = true;
            }

            if (data.V_subtotal_neto_exento.ToString() != String.Empty)
            {
                this.txtNetoExento.Text = data.V_subtotal_neto_exento.ToString();
            }
            else
            {
                this.txtNetoExento.Text = "";
            }

            if (data.V_subtotal_neto.ToString() != String.Empty)
            {
                this.txtNeto.Text = data.V_subtotal_neto.ToString();
            }
            else
            {
                this.txtNeto.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIVA.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIVA.Text = "";
            }

            if (data.V_impuesto.ToString() != String.Empty)
            {
                this.txtImpuestos.Text = data.V_impuesto.ToString();
            }
            else
            {
                this.txtImpuestos.Text = "";
            }

            if (data.V_redondeo.ToString() != String.Empty)
            {
                this.txtRedondeo.Text = data.V_redondeo.ToString();
            }
            else
            {
                this.txtRedondeo.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal.Text = "";
            }

            if (data.V_fecha_vencimiento.ToString() != String.Empty)
            {
                this.txtFechaDeVencimiento.Text = data.V_fecha_vencimiento.ToString();
            }
            else
            {
                this.txtFechaDeVencimiento.Text = "";
            }

        }

        private void objectToFormFact(NotaDeCreditoDeCompraDTO data)
        {
            this.lblDatosDelProveedor.Text = "COD. PROVEEDOR: " + data.Id_proveedor.ToString() + ", " + "NOMBRE: " + data.Nombre_proveedor.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CONDICIÓN DE COMPRA: " + data.Condicion_compra.ToString();

            this.lblPagado.Visible = false;

            if (data.V_subtotal_neto_exento.ToString() != String.Empty)
            {
                this.txtNetoExento.Text = data.V_subtotal_neto_exento.ToString();
            }
            else
            {
                this.txtNetoExento.Text = "";
            }

            if (data.V_subtotal_neto.ToString() != String.Empty)
            {
                this.txtNeto.Text = data.V_subtotal_neto.ToString();
            }
            else
            {
                this.txtNeto.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIVA.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIVA.Text = "";
            }

            if (data.V_impuesto.ToString() != String.Empty)
            {
                this.txtImpuestos.Text = data.V_impuesto.ToString();
            }
            else
            {
                this.txtImpuestos.Text = "";
            }

            if (data.V_redondeo.ToString() != String.Empty)
            {
                this.txtRedondeo.Text = data.V_redondeo.ToString();
            }
            else
            {
                this.txtRedondeo.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal.Text = "";
            }

        }

        private void objectToFormFact(NotaDeDebitoDeCompraDTO data)
        {
            this.lblDatosDelProveedor.Text = "COD. PROVEEDOR: " + data.Id_proveedor.ToString() + ", " + "NOMBRE: " + data.Nombre_proveedor.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CONDICIÓN DE COMPRA: " + data.Condicion_compra.ToString();

            if (data.Pago == 'S')
            {
                this.lblPagado.Visible = true;
            }

            if (data.V_subtotal_neto_exento.ToString() != String.Empty)
            {
                this.txtNetoExento.Text = data.V_subtotal_neto_exento.ToString();
            }
            else
            {
                this.txtNetoExento.Text = "";
            }

            if (data.V_subtotal_neto.ToString() != String.Empty)
            {
                this.txtNeto.Text = data.V_subtotal_neto.ToString();
            }
            else
            {
                this.txtNeto.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIVA.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIVA.Text = "";
            }

            if (data.V_impuesto.ToString() != String.Empty)
            {
                this.txtImpuestos.Text = data.V_impuesto.ToString();
            }
            else
            {
                this.txtImpuestos.Text = "";
            }

            if (data.V_redondeo.ToString() != String.Empty)
            {
                this.txtRedondeo.Text = data.V_redondeo.ToString();
            }
            else
            {
                this.txtRedondeo.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal.Text = "";
            }

        }

        private void objectToFormPago(PagoDTO data)
        {
            this.lblDatosDelProveedor.Text = "COD. PROVEEDOR: " + data.Id_proveedor.ToString() + ", " + "NOMBRE: " + data.Nombre_proveedor.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelProveedor.Text += "CONDICIÓN DE COMPRA: " + data.Condicion_compra.ToString();

            this.lblPagado.Visible = false;

            this.txtNetoExento.Text = "";
            this.txtNeto.Text = "";
            this.txtIVA.Text = "";
            this.txtImpuestos.Text = "";
            this.txtRedondeo.Text = "";

            if (data.V_importe.ToString() != String.Empty)
            {
                this.txtTotal.Text = data.V_importe.ToString();
            }
            else
            {
                this.txtTotal.Text = "";
            }
        }

        private void cargarGridOrdenDePago(long idOrdenDePago)
        {
            //datos principales
            _pago.refreshGridDataReg(idOrdenDePago);
            _pago.GridDataListReg[0].Cod_comprobante = txtNroComprobante.Text;
            this.objectToFormPago(_pago.GridDataListReg[0]);

            //detalle de la orden de compra
            _pago.refreshGridDataDetalleReg(idOrdenDePago);
            this.dgvComprobanteRegistrado.DataSource = _pago.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();

            //detalle de los comprobantes relacionados
            _pago.refreshGridDataComprobantesRel(idOrdenDePago);
            this.dgvComprobantesRelacionados.DataSource = _pago.GridDataListComprobantesRel;
            this.dgvComprobantesRelacionados.Font = this.txtTotal.Font;
            this.dgvComprobantesRelacionados.ClearSelection();
        }

        private void configurarGridOrdenDePago()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            //+92+427+105

            DataGridViewTextBoxColumn _modalidadPagoColum = new DataGridViewTextBoxColumn();
            _modalidadPagoColum.DataPropertyName = "modalidad_de_pago";
            _modalidadPagoColum.HeaderText = "Modalidad de Pago";
            _modalidadPagoColum.Width = 220;
            _modalidadPagoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _modalidadPagoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _modalidadPagoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "detalle";
            _descripcion.HeaderText = "Detalle";
            _descripcion.Width = 299;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;


            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_importe";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 105;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_modalidadPagoColum);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);
            this.dgvComprobanteRegistrado.Columns.Add(_impTotalColum);

        }

        private void configurarGridComprobantesRel()
        {
            this.dgvComprobantesRelacionados.Columns.Clear();
            this.dgvComprobantesRelacionados.AutoGenerateColumns = false;

            //+92+427+105

            DataGridViewTextBoxColumn _tipoComprobanteColum = new DataGridViewTextBoxColumn();
            _tipoComprobanteColum.DataPropertyName = "tipo_comprobante";
            _tipoComprobanteColum.HeaderText = "Tipo de Comprobante";
            _tipoComprobanteColum.Width = 220;
            _tipoComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "cod_comprobante";
            _codComprobanteColum.HeaderText = "Cod. Comprobante";
            _codComprobanteColum.Width = 199;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codComprobanteColum.ReadOnly = true;


            DataGridViewTextBoxColumn _impPagadoColum = new DataGridViewTextBoxColumn();
            _impPagadoColum.DataPropertyName = "v_importe_pagado";
            _impPagadoColum.HeaderText = "Importe Pagado";
            _impPagadoColum.Width = 205;
            _impPagadoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.ReadOnly = true;

            this.dgvComprobantesRelacionados.Columns.Add(_tipoComprobanteColum);
            this.dgvComprobantesRelacionados.Columns.Add(_codComprobanteColum);
            this.dgvComprobantesRelacionados.Columns.Add(_impPagadoColum);

        }

        private void btnLimpiarVista_Click(object sender, EventArgs e)
        {
            objectToFormClear();
        }


        private void objectToFormClear()
        {
            this.txtTipoDeComprobante.Text = "";
            this.txtNroComprobante.Text = "";
            this.txtFechaDelComprobante.Text = "";
            this.txtFechaContable.Text = "";
            this.txtFechaDeVencimiento.Text = "";
            this.lblDatosDelProveedor.Text = "";
            this.txtImpuestos.Text = "";
            this.txtIVA.Text = "";
            this.txtNeto.Text = "";
            this.txtNetoExento.Text = "";
            this.txtRedondeo.Text = "";
            this.txtTotal.Text = "";
            this.dgvComprobanteRegistrado.DataSource = null;
            btnCompletar.Enabled = true;
            btnImprimir.Enabled = true;
            this.lblPagado.Visible = false;
            deshabilitarAmbosModos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipoDeComprobante.Text == "ORDEN DE PAGO")
                {
                    bool existe_retencion = false;

                    foreach (PagoDetalleDTO pagoDetalle in _pago.GridDataListDetalleReg)
                    {
                        if (pagoDetalle.Id_tipo_retencion != -1)
                        {
                            existe_retencion = true;
                        }
                    }

                    frmImpresionDeOrdenDePago imp = new frmImpresionDeOrdenDePago(txtNroComprobante.Text, existe_retencion, false, _pago.GridDataListReg[0].Id_proveedor, DateTime.ParseExact(txtFechaDelComprobante.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    imp.ShowDialog();
                    imp.Dispose();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Comprobante Digital");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectFalse();
            cargarGridComprobantes();
            this.cbxFiltroCodProveedor.Focus();
        }

        private void FilterToObjectFalse()
        {
            _filtroProveedores.FiltroCodigo = "XXXXXXXX";
            _filtroProveedores.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroProveedores.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroProveedores.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(1);
            _filtroProveedores.FiltroTipoComprobante = -1;
            _filtroProveedores.FiltroNroComprobante = "XXXXXXXX";
        }

        private void clearFilter()
        {
            this.objectToFilter(new FiltrosABMProveedor());
            this.chbFacturasIncompletas.Checked = false;
            //int dias_transcurridos = System.DateTime.Now.Day * (-1);
            //this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-365);
            this.dtpFechaHasta.Value = System.DateTime.Now;
        }

        private void objectToFilter(FiltrosABMProveedor filtro)
        {
            this.cbxFiltroCodProveedor.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombreDeProveedor.Text = filtro.FiltroNombre;
            if (filtro.FiltroTipoComprobante == -1)
            {
                this.cbxFiltroTipoDeComprobante.Text = "";
            }
            this.txtFiltroNroDeComprobante.Text = filtro.FiltroNroComprobante;
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (txtTipoDeComprobante.Text == "FACTURA A" || txtTipoDeComprobante.Text == "FACTURA B")
            {
                if (_factura.GridDataListReg[0].Es_concepto == 'S')
                {
                    frmFacturaConcepto concepto = new frmFacturaConcepto(_factura.GridDataListReg[0]);
                    concepto.ShowDialog();
                    concepto.Dispose();
                }

                if (_factura.GridDataListReg[0].Es_concepto == 'N')
                {
                    frmFacturaArticulo articulo = new frmFacturaArticulo(_factura.GridDataListReg[0]);
                    articulo.ShowDialog();
                    articulo.Dispose();
                }
            }

            objectToFormClear();            
        }

        private void lblPagado_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_proveedor = string.Empty;
                string nombre_proveedor = string.Empty;
                long id_origen = -1;

                if (txtTipoDeComprobante.Text == "NOTA DE DEBITO A" || txtTipoDeComprobante.Text == "NOTA DE DEBITO B")
                {
                    cod_proveedor = _nota_debito.GridDataListReg[0].Id_proveedor;
                    nombre_proveedor = _nota_debito.GridDataListReg[0].Nombre_proveedor;
                    id_origen = _nota_debito.GridDataListReg[0].Id;
                }

                if (txtTipoDeComprobante.Text == "FACTURA A" || txtTipoDeComprobante.Text == "FACTURA B")
                {
                    cod_proveedor = _factura.GridDataListReg[0].Id_proveedor;
                    nombre_proveedor = _factura.GridDataListReg[0].Nombre_proveedor;
                    id_origen = _factura.GridDataListReg[0].Id;
                }

                frmVerFacturasDeCompraImpagas frmReporte = new frmVerFacturasDeCompraImpagas();
                crFacturasDeCompraImpagas rptLista = frmReporte.cargarReporte(cod_proveedor, nombre_proveedor, CuentaCorrienteProvDTO.obtenerSaldo(cod_proveedor), id_origen);
                frmReporte.crvFacturasDeCompraImpagas.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte de Pagos Realizados");
            }
        }


    }
}

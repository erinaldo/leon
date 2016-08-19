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
    public partial class frmFacturaArticulo : Form
    {
        private Proveedores _proveedores;
        private Producto _articulos;
        private IvaCompras _iva;
        private ImpuestosCompras _impuestos;
        private PrecioProveedor _precios;
        List<FacturaDeCompraDetalleDTO> _facturaDetalle;
        List<ImpuestoDetalleDTO> _impuestoDetalle;
        List<IvaComprasDetalleDTO> _ivaDetalle;
        FacturaDeCompra _facturaDeArticulos;
        FacturaDeCompraDTO _compraIniciada;
        List<ComprobanteRelacionDTO> _comprobanteRelacion; //xx
        private UnidadDeMedida _unidadDeMedida; //xx2

        public frmFacturaArticulo()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _articulos = new Producto();
            _iva = new IvaCompras();
            _impuestos = new ImpuestosCompras();
            _facturaDetalle = new List<FacturaDeCompraDetalleDTO>();
            _impuestoDetalle = new List<ImpuestoDetalleDTO>();
            _ivaDetalle = new List<IvaComprasDetalleDTO>();
            _facturaDeArticulos = new FacturaDeCompra();
            _precios = new PrecioProveedor();
            _compraIniciada = null;
            _comprobanteRelacion = new List<ComprobanteRelacionDTO>();//xx
            _unidadDeMedida = new UnidadDeMedida(); //xx2
        }

        public frmFacturaArticulo(FacturaDeCompraDTO compraIncompleta)
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _articulos = new Producto();
            _iva = new IvaCompras();
            _impuestos = new ImpuestosCompras();
            _facturaDetalle = new List<FacturaDeCompraDetalleDTO>();
            _impuestoDetalle = new List<ImpuestoDetalleDTO>();
            _ivaDetalle = new List<IvaComprasDetalleDTO>();
            _facturaDeArticulos = new FacturaDeCompra();
            _precios = new PrecioProveedor();
            _compraIniciada = compraIncompleta;
            _comprobanteRelacion = new List<ComprobanteRelacionDTO>();//xx
            _unidadDeMedida = new UnidadDeMedida(); //xx2
        }

        private void frmFacturaArticulo_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarDatosProveedorForm();
            cargarDatosArticulosForm();
            cargarDatosImpositivos();
            configurarGridDetalleFactura();
            configurarGridIVA();
            configurarGridImpuesto();

            if (_compraIniciada != null)
            {
                cbxCodProveedor.Text = _compraIniciada.Id_proveedor;
                cbxNombreDelProveedor.Text = _compraIniciada.Nombre_proveedor;
                cbxTipoFactura.Text = _compraIniciada.Tipo_factura.ToString();
                txtNroFacturaCompra.Text = _compraIniciada.Cod_comprobante;
                dtpFechaDelComprobante.Value = _compraIniciada.Fecha_comprobante;
                dtpFechaContable.Value = _compraIniciada.Fecha_contable;
                if (_compraIniciada.V_fecha_vencimiento != string.Empty)
                {
                    cbhFechaDeVencimiento.Checked = true;
                    dtpFechaDeVencimiento.Value = _compraIniciada.Fecha_vencimiento;
                }
                txtTotal.Text = _compraIniciada.V_total;
                txtTotal.ReadOnly = true;
                btnCalcularTotal.Enabled = false;
                cbxCodProveedor.Enabled = false;
                cbxNombreDelProveedor.Enabled = false;
                cbxTipoFactura.Enabled = false;
                txtNroFacturaCompra.ReadOnly = true;
                dtpFechaDelComprobante.Enabled = false;
                dtpFechaContable.Enabled = false;
                dtpFechaDeVencimiento.Enabled = false;
                cbhFechaDeVencimiento.Enabled = false;
            }
        }

        private void configurarGridIVA()
        {
            this.dgvDetalleIVA.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _porcentaje = new DataGridViewTextBoxColumn();
            _porcentaje.DataPropertyName = "v_porcentaje";
            _porcentaje.HeaderText = "%";
            _porcentaje.Width = 491;
            _porcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 105;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;


            this.dgvDetalleIVA.Columns.Add(_porcentaje);
            this.dgvDetalleIVA.Columns.Add(_importe);

        }

        private void configurarGridImpuesto()
        {
            this.dgvDetalleImpuesto.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "desc_impuesto";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 350;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _porcentaje = new DataGridViewTextBoxColumn();
            _porcentaje.DataPropertyName = "v_porcentaje";
            _porcentaje.HeaderText = "%";
            _porcentaje.Width = 141;
            _porcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _porcentaje.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 105;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;


            this.dgvDetalleImpuesto.Columns.Add(_descripcion);
            this.dgvDetalleImpuesto.Columns.Add(_porcentaje);
            this.dgvDetalleImpuesto.Columns.Add(_importe);

        }

        private void configurarGridDetalleFactura()
        {
            this.dgvDetalleFacturaCompra.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "C."; //xx2
            _cantidad.Width = 30; //xx2 -10
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            //xx2
            DataGridViewTextBoxColumn _unidad = new DataGridViewTextBoxColumn();
            _unidad.DataPropertyName = "unidad";
            _unidad.HeaderText = "Unidad";
            _unidad.Width = 60;
            _unidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _unidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _unidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 78; //xx2 -20
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 267;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precio_unitario = new DataGridViewTextBoxColumn();
            _precio_unitario.DataPropertyName = "v_precio_unitario";
            _precio_unitario.HeaderText = "P. Unit."; //xx2
            _precio_unitario.Width = 80; //xx2 -15
            _precio_unitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio_unitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio_unitario.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 80; //xx2 -15
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvDetalleFacturaCompra.Columns.Add(_cantidad);
            this.dgvDetalleFacturaCompra.Columns.Add(_unidad); //xx2
            this.dgvDetalleFacturaCompra.Columns.Add(_codigo);
            this.dgvDetalleFacturaCompra.Columns.Add(_descripcion);
            this.dgvDetalleFacturaCompra.Columns.Add(_precio_unitario);
            this.dgvDetalleFacturaCompra.Columns.Add(_importe);

        }

        private void cargarDatosProveedorForm()
        {
            this.cbxCodProveedor.DataSource = _proveedores.CodDataList;
            this.cbxNombreDelProveedor.DataSource = _proveedores.NombreDataList;
            this.cbxTipoFactura.DataSource = new[] { "A", "B", "C" };
            this.txtPorcentajeBonificacion.Text = "0";
        }

        private void cargarDatosArticulosForm()
        {
            _articulos.refreshOwnData4();

            this.cbxCodArticulo.DataSource = null;
            this.cbxCodArticulo.DataSource = _articulos.OwnDataList4;
            this.cbxCodArticulo.DisplayMember = "codigo";

            this.cbxNombreDeArticulo.DataSource = null;
            this.cbxNombreDeArticulo.DataSource = _articulos.OwnDataList4;
            this.cbxNombreDeArticulo.DisplayMember = "descripcion";

            //xx2
            this.cbxUnidad.DataSource = null;
            this.cbxUnidad.DataSource = _unidadDeMedida.OwnDataList;
            this.cbxUnidad.DisplayMember = "valor";

            this.txtCantidad.Text = "1";
        }

        private void cargarDatosImpositivos()
        {
            this.cbxPorcentajeDeIva.DataSource = _iva.OwnDataList;
            this.cbxPorcentajeDeIva.DisplayMember = "valor_adicional";
            this.cbxPorcentajeDeIva.ValueMember = "id";

            this.cbxDescripcionImpuesto.DataSource = _impuestos.OwnDataList;
            this.cbxDescripcionImpuesto.DisplayMember = "valor";
            this.cbxDescripcionImpuesto.ValueMember = "id";

            this.cbxPorcentajeImpuesto.DataSource = _impuestos.OwnDataList;
            this.cbxPorcentajeImpuesto.DisplayMember = "valor_adicional";
            this.cbxPorcentajeImpuesto.ValueMember = "id";
        }

        private void clearDatosArticulosForm()
        {
            txtCantidad.Text = "1";
            txtCodigoDeBarras.Text = string.Empty;
            cbxCodArticulo.Text = string.Empty;
            cbxNombreDeArticulo.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chbExento.Checked = false;
            chkRelacionarComprobante.Checked = false; //xx
        }


        private void clearForm()
        {
            //datos del proveedor
            cbxCodProveedor.Text = string.Empty;
            cbxNombreDelProveedor.Text = string.Empty;
            txtNroFacturaCompra.Text = string.Empty;
            txtPorcentajeBonificacion.Text = string.Empty;
            cbhFechaDeVencimiento.Checked = false;

            //detalle de la factura
            txtCantidad.Text = "1";
            txtCodigoDeBarras.Text = string.Empty;
            cbxCodArticulo.Text = string.Empty;
            cbxNombreDeArticulo.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            txtImporte.Text = string.Empty;
            chbExento.Checked = false;
            chkRelacionarComprobante.Checked = false;
            dgvDetalleFacturaCompra.DataSource = null;
            txtSubtotal.Text = string.Empty;
            txtNeto.Text = string.Empty;
            txtSubtotalExento.Text = string.Empty;
            txtNetoExento.Text = string.Empty;
            _facturaDetalle.Clear();
            _comprobanteRelacion.Clear(); //xx

            //iva
            cbxPorcentajeDeIva.Text = string.Empty;
            txtImporteIva.Text = string.Empty;
            dgvDetalleIVA.DataSource = null;
            txtImporteIVATotal.Text = string.Empty;
            _ivaDetalle.Clear();

            //impuestos
            cbxDescripcionImpuesto.Text = string.Empty;
            cbxPorcentajeImpuesto.Text = string.Empty;
            txtImporteImpuesto.Text = string.Empty;
            dgvDetalleImpuesto.DataSource = null;
            txtImporteImpuestos.Text = string.Empty;
            _impuestoDetalle.Clear();

            //ultimos
            txtRedondeo.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private bool validarNulidadDatos(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de proveedor.";
            }
            else
            {
                int resultIndex = this.cbxCodProveedor.FindStringExact(cbxCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.cbxNombreDelProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el nombre de proveedor.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelProveedor.FindStringExact(cbxNombreDelProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de proveedor ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.txtNroFacturaCompra.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el número de factura.";
            }

            if (this.dgvDetalleFacturaCompra.RowCount == 0)
            {
                rv = false;
                msg += "\nDebe ingresar el detalle de la factura.";
            }

            if (this.txtTotal.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe total.";
            }

            if (this._compraIniciada != null && sumarImportes() != decimal.Parse(txtTotal.Text))
            {
                rv = false;
                msg += "\nLa sumatoria de los importes no coincide con el total. El total de la factura es " + txtTotal.Text + " y la suma de los importes resulta " + sumarImportes().ToString() + ".";
            }

            return rv;

        }

        private decimal sumarImportes()
        {
            decimal importe = decimal.Zero;

            if (txtNeto.Text != string.Empty)
            {
                decimal neto = decimal.Parse(txtNeto.Text);
                importe += Math.Round(neto, 2, MidpointRounding.AwayFromZero);
            }

            if (txtNetoExento.Text != string.Empty)
            {
                decimal netoExento = decimal.Parse(txtNetoExento.Text);
                importe += Math.Round(netoExento, 2, MidpointRounding.AwayFromZero);
            }

            if (txtImporteIVATotal.Text != string.Empty)
            {
                decimal importeIva = decimal.Parse(txtImporteIVATotal.Text);
                importe += Math.Round(importeIva, 2, MidpointRounding.AwayFromZero);
            }

            if (txtImporteImpuestos.Text != string.Empty)
            {
                decimal importeImpuestos = decimal.Parse(txtImporteImpuestos.Text);
                importe += Math.Round(importeImpuestos, 2, MidpointRounding.AwayFromZero);
            }

            if (txtRedondeo.Text != string.Empty)
            {
                decimal importeRedondeo = decimal.Parse(txtRedondeo.Text);
                importe += Math.Round(importeRedondeo, 2, MidpointRounding.AwayFromZero);
            }

            return importe;
        }

        private bool validarNulidadDatosImpuesto(ref string msg)
        {
            bool rv = true;

            if (this.cbxPorcentajeImpuesto.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el impuesto.";
            }

            if (this.txtImporteImpuesto.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe.";
            }

            return rv;
        }

        private bool validarNulidadDatosIva(ref string msg)
        {
            bool rv = true;

            if (this.cbxPorcentajeDeIva.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el iva.";
            }

            if (this.txtImporteIva.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe.";
            }

            return rv;
        }

        private void clearDatosImpuestosForm()
        {
            cbxDescripcionImpuesto.Text = string.Empty;
            cbxPorcentajeImpuesto.Text = string.Empty;
            txtImporteImpuesto.Text = string.Empty;
        }

        private void clearDatosIvaForm()
        {
            cbxPorcentajeDeIva.Text = string.Empty;
            txtImporteIva.Text = string.Empty;
        }


        private FacturaDeCompraDTO formToObject()
        {
            FacturaDeCompraDTO data = new FacturaDeCompraDTO();

            data.Id_proveedor = cbxCodProveedor.Text;
            data.Nombre_proveedor = cbxNombreDelProveedor.Text;
            data.Es_concepto = 'N';
            data.Es_definitiva = 'S';
            data.Cod_comprobante = txtNroFacturaCompra.Text;
            data.Tipo_factura = char.Parse(cbxTipoFactura.Text);
            data.Categoria_iva = ProveedorDTO.obtenerCategoriaIvaAbreviado(data.Id_proveedor);
            data.Cuit_proveedor = ProveedorDTO.obtenerCuit(data.Id_proveedor);
            data.Fecha_contable = dtpFechaContable.Value;
            data.Fecha_comprobante = dtpFechaDelComprobante.Value.Date;

            if (cbhFechaDeVencimiento.Checked)
            {
                data.Tiene_vencimiento = true;
                data.Fecha_vencimiento = dtpFechaDeVencimiento.Value.Date;
            }

            data.Total = Math.Round(decimal.Parse(txtTotal.Text), 2, MidpointRounding.AwayFromZero);

            if (txtNeto.Text != string.Empty)
            {
                data.Subtotal_neto += Math.Round(decimal.Parse(txtNeto.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtNetoExento.Text != string.Empty)
            {
                data.Subtotal_neto_exento += Math.Round(decimal.Parse(txtNetoExento.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteIVATotal.Text != string.Empty)
            {
                data.Iva = Math.Round(decimal.Parse(txtImporteIVATotal.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteImpuestos.Text != string.Empty)
            {
                data.Impuestos = Math.Round(decimal.Parse(txtImporteImpuestos.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtRedondeo.Text != string.Empty)
            {
                data.Redondeo = Math.Round(decimal.Parse(txtRedondeo.Text), 2, MidpointRounding.AwayFromZero);
            }
            return data;
        }

        //xx
        //completo solo datos del comprobante hijo
        private ComprobanteRelacionDTO formToComprobanteRelacion(long id_tipo_comprobante, string cod_comprobante)
        {
            ComprobanteRelacionDTO data = new ComprobanteRelacionDTO();
            data.Cod_comprobante_hijo = cod_comprobante;
            data.Id_tipo_comprobante_hijo = id_tipo_comprobante;
            if (txtImporte.Text == string.Empty)
            {
                data.Importe_hijo = decimal.Zero;
            }
            else
            {
                data.Importe_hijo = decimal.Round(decimal.Parse(txtImporte.Text), 2, MidpointRounding.AwayFromZero);
            }
            return data;
        }

        private void sumarImpuesto(decimal valor)
        {
            decimal importe;

            if (txtImporteImpuestos.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtImporteImpuestos.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + valor;
            txtImporteImpuestos.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void sumarIva(decimal valor)
        {
            decimal importe;

            if (txtImporteIVATotal.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtImporteIVATotal.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + valor;
            txtImporteIVATotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        //operaciones de suma a no exentos
        private void sumarAlSubtotal(decimal valor)
        {
            decimal importe;

            if (txtSubtotal.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtSubtotal.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + valor;
            txtSubtotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void sumarAlNeto(decimal valor)
        {
            decimal importe;
            decimal multiploBonificacion = 1;
            if (txtPorcentajeBonificacion.Text != string.Empty)
            {
                multiploBonificacion = decimal.Round((100 - decimal.Parse(txtPorcentajeBonificacion.Text)) / 100, 2, MidpointRounding.AwayFromZero);
            }

            if (txtNeto.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtNeto.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + decimal.Round(valor * multiploBonificacion, 2, MidpointRounding.AwayFromZero);
            txtNeto.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        //operaciones de resta a no exentos
        private void restarAlSubtotal(decimal valor)
        {
            decimal importe;

            if (txtSubtotal.Text != string.Empty)
            {

                importe = decimal.Round(decimal.Parse(txtSubtotal.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - valor;
            txtSubtotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void restarAlNeto(decimal valor)
        {
            decimal importe;
            decimal multiploBonificacion = 1;
            if (txtPorcentajeBonificacion.Text != string.Empty)
            {
                decimal.Round((100 - decimal.Parse(txtPorcentajeBonificacion.Text)) / 100, 2, MidpointRounding.AwayFromZero);
            }

            if (txtNeto.Text != string.Empty)
            {

                importe = decimal.Round(decimal.Parse(txtNeto.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - decimal.Round(valor * multiploBonificacion, 2, MidpointRounding.AwayFromZero);
            txtNeto.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void calcularIva()
        {
            if (cbxPorcentajeDeIva.Text != string.Empty)
            {
                decimal neto = decimal.Zero;
                decimal iva;

                if (txtNeto.Text != string.Empty)
                {
                    neto = decimal.Parse(txtNeto.Text);
                }

                iva = neto * (decimal.Parse(cbxPorcentajeDeIva.Text) / 100);

                txtImporteIva.Text = String.Format("{0:0.00}", Math.Round(iva, 2, MidpointRounding.AwayFromZero));
            }
        }

        private void calcularTotal()
        {
            decimal importe = decimal.Zero;
            importe = sumarImportes();
            txtTotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void calcularImpuesto()
        {
            decimal neto = decimal.Zero;
            decimal impuesto;

            if (txtNeto.Text != string.Empty && cbxPorcentajeImpuesto.Text != string.Empty)
            {
                neto = decimal.Parse(txtNeto.Text);
                impuesto = neto * (decimal.Parse(cbxPorcentajeImpuesto.Text) / 100);
                txtImporteImpuesto.Text = String.Format("{0:0.00}", Math.Round(impuesto, 2, MidpointRounding.AwayFromZero));
            }
            if (cbxPorcentajeImpuesto.Text == string.Empty)
            {
                txtImporteImpuesto.Text = string.Empty;
            }
        }

        private void restarAlIvaTotal(decimal valor)
        {
            decimal importe;

            if (txtImporteIVATotal.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtImporteIVATotal.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - valor;
            txtImporteIVATotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void restarAlImpuestoTotal(decimal valor)
        {
            decimal importe;

            if (txtImporteImpuestos.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtImporteImpuestos.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - valor;
            txtImporteImpuestos.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private bool validarNulidadDatosItem(ref string msg)
        {
            bool rv = true;

            if (this.txtCantidad.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la cantidad de artículos.";
            }

            if (this.cbxCodArticulo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de artículo.";
            }
            else
            {
                int resultIndex = this.cbxCodArticulo.FindStringExact(cbxCodArticulo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de artículo ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.cbxNombreDeArticulo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el nombre de artículo.";
            }
            else
            {
                int resultIndex = this.cbxNombreDeArticulo.FindStringExact(cbxNombreDeArticulo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de artículo ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.txtPrecioUnitario.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el precio unitario del artículo.";
            }

            if (this.txtImporte.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe del artículo.";
            }

            return rv;

        }

        private bool validarNulidadDatosItemParcial(ref string msg)
        {
            bool rv = true;

            if (this.txtCantidad.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la cantidad de artículos.";
            }

            if (this.txtDescripcion.Text == string.Empty)
            {

                if (this.cbxCodArticulo.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el código de artículo.";
                }
                else
                {
                    int resultIndex = this.cbxCodArticulo.FindStringExact(cbxCodArticulo.Text);
                    if (resultIndex == -1)
                    {
                        rv = false;
                        msg += "\nEl código de artículo ingresado es incorrecto. Seleccione una de la lista.";
                    }
                }

                if (this.cbxNombreDeArticulo.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el nombre de artículo.";
                }
                else
                {
                    int resultIndex = this.cbxNombreDeArticulo.FindStringExact(cbxNombreDeArticulo.Text);
                    if (resultIndex == -1)
                    {
                        rv = false;
                        msg += "\nEl nombre de artículo ingresado es incorrecto. Seleccione una de la lista.";
                    }
                }

            }

            return rv;
        }

        private void completarPrecioImporte()
        {
            _precios.setPrecio(cbxCodProveedor.Text, cbxCodArticulo.Text);

            decimal importe = _precios.Precio.Valor * int.Parse(txtCantidad.Text);

            if (txtPrecioUnitario.Text == string.Empty)
            {
                txtPrecioUnitario.Text = _precios.Precio.Valor.ToString();
            }

            if (txtImporte.Text == string.Empty)
            {
                txtImporte.Text = importe.ToString();
            }
        }

        private void completarPrecioImporteSiempre()
        {
            _precios.setPrecio(cbxCodProveedor.Text, cbxCodArticulo.Text);
            decimal importe = _precios.Precio.Valor * int.Parse(txtCantidad.Text);

            txtPrecioUnitario.Text = _precios.Precio.Valor.ToString();
            txtImporte.Text = importe.ToString();
        }

        private void cargarGrillaItem()
        {
            FacturaDeCompraDetalleDTO det = new FacturaDeCompraDetalleDTO();
            det.Cantidad = int.Parse(txtCantidad.Text);
            det.Precio_unitario = decimal.Round(decimal.Parse(txtPrecioUnitario.Text), 2, MidpointRounding.AwayFromZero);
            det.V_precio_unitario = det.Precio_unitario.ToString();
            det.Importe = decimal.Round(decimal.Parse(txtImporte.Text), 2, MidpointRounding.AwayFromZero);
            det.V_importe = det.Importe.ToString();
            det.Unidad = cbxUnidad.Text; //xx2

            if (txtDescripcion.Text == string.Empty)
            {
                det.Id_producto = ProductoDTO.buscarId(cbxNombreDeArticulo.Text);
                det.Codigo = cbxCodArticulo.Text;
                det.Descripcion = cbxNombreDeArticulo.Text;
            }
            else
            {
                det.Id_producto = -1;
                det.Codigo = "NA";
                det.Descripcion = txtDescripcion.Text;
            }
            if (!chbExento.Checked)
            {
                sumarAlSubtotal(det.Importe);
                sumarAlNeto(det.Importe);
                det.Exento = 'N';
            }
            else
            {
                sumarAlSubtotalExento(det.Importe);
                sumarAlNetoExento(det.Importe);
                det.Exento = 'S';
            }

            _facturaDetalle.Add(det);
            this.dgvDetalleFacturaCompra.DataSource = null;
            this.dgvDetalleFacturaCompra.DataSource = _facturaDetalle;
            this.dgvDetalleFacturaCompra.ClearSelection();

            clearDatosArticulosForm();
        }

        //operaciones de suma a exentos
        private void sumarAlSubtotalExento(decimal valor)
        {
            decimal importe;

            if (txtSubtotalExento.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtSubtotalExento.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + valor;
            txtSubtotalExento.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void sumarAlNetoExento(decimal valor)
        {
            decimal importe;
            decimal multiploBonificacion = 1;
            if (txtPorcentajeBonificacion.Text != string.Empty)
            {
                multiploBonificacion = decimal.Round((100 - decimal.Parse(txtPorcentajeBonificacion.Text)) / 100, 2, MidpointRounding.AwayFromZero);
            }

            if (txtNetoExento.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtNetoExento.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe + decimal.Round(valor * multiploBonificacion, 2, MidpointRounding.AwayFromZero);
            txtNetoExento.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void txtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtCodigoDeBarras.Text != string.Empty)
                    {
                        string msg = String.Empty;
                        cbxNombreDeArticulo.Text = ProductoDTO.obtenerDescripcion(txtCodigoDeBarras.Text);

                        if (validarNulidadDatosItemParcial(ref msg))
                        {
                            completarPrecioImporte();
                            cargarGrillaItem();
                            txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación agregar artículo");
                }
            }
        }


        private void cbxCodArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string msg = String.Empty;

                    if (validarNulidadDatosItemParcial(ref msg))
                    {
                        completarPrecioImporte();
                        cargarGrillaItem();
                        txtCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación agregar artículo");
                }
            }
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (chkRelacionarComprobante.Checked == false) //xx
                    {
                        string msg = String.Empty;

                        if (validarNulidadDatosItemParcial(ref msg))
                        {
                            completarPrecioImporte();
                            cargarGrillaItem();
                            txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                        }
                    }
                    else //xx
                    {
                        ComprobanteCompraDTO comprobante = ComprobanteCompraDTO.obtenerComprobante(cbxCodProveedor.Text, txtDescripcion.Text);
                        if (comprobante.Cod_comprobante != string.Empty)
                        {
                            string msg = String.Empty;

                            if (validarNulidadDatosItemParcial(ref msg))
                            {
                                completarPrecioImporte();
                                txtDescripcion.Text = comprobante.Tipo_comprobante + " - " + comprobante.Cod_comprobante;
                                _comprobanteRelacion.Add(formToComprobanteRelacion(comprobante.Id_tipo_comprobante, comprobante.Cod_comprobante));
                                cargarGrillaItem();
                                txtCantidad.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El comprobante no existe para el proveedor seleccionado", "Factura de Compra");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación agregar item a la factura");
                }
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkRelacionarComprobante.Checked == false) //xx
                {
                    string msg = String.Empty;

                    if (validarNulidadDatosItemParcial(ref msg))
                    {
                        completarPrecioImporte();
                        cargarGrillaItem();
                        txtCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                    }
                }
                else //xx
                {
                    ComprobanteCompraDTO comprobante = ComprobanteCompraDTO.obtenerComprobante(cbxCodProveedor.Text, txtDescripcion.Text);
                    if (comprobante.Cod_comprobante != string.Empty)
                    {
                        string msg = String.Empty;

                        if (validarNulidadDatosItemParcial(ref msg))
                        {
                            completarPrecioImporte();
                            txtDescripcion.Text = comprobante.Tipo_comprobante + " - " + comprobante.Cod_comprobante;
                            _comprobanteRelacion.Add(formToComprobanteRelacion(comprobante.Id_tipo_comprobante, comprobante.Cod_comprobante));
                            cargarGrillaItem();
                            txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El comprobante no existe para el proveedor seleccionado", "Factura de Compra");
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación agregar item a la factura");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("¿Desea registrar la factura de compra?", "Factura de Compra", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                string msg = String.Empty;

                if (validarNulidadDatos(ref msg))
                {
                    FacturaDeCompraDTO data = this.formToObject();
                    if (_compraIniciada != null)
                    {
                        _facturaDeArticulos.registrarIniciada(data, _facturaDetalle, _ivaDetalle, _impuestoDetalle, new List<FacturaDeCompraCuotaDTO>(), _comprobanteRelacion);
                        MessageBox.Show("La operación fue realizada con éxito.", "Factura de Compra");
                        this.Dispose();
                        this.Close();
                    }
                    else
                    {
                        _facturaDeArticulos.registrar(data, _facturaDetalle, _ivaDetalle, _impuestoDetalle, new List<FacturaDeCompraCuotaDTO>(), _comprobanteRelacion);
                        clearForm();
                        MessageBox.Show("La operación fue realizada con éxito.", "Factura de Compra");
                    }
                }
                else
                {
                    MessageBox.Show("No ha sido posible registrar la factura de compra. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                }
            }
        }

        //operaciones de resta a exentos
        private void restarAlSubtotalExento(decimal valor)
        {
            decimal importe;

            if (txtSubtotalExento.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtSubtotalExento.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - valor;
            txtSubtotalExento.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void restarAlNetoExento(decimal valor)
        {
            decimal importe;
            decimal multiploBonificacion = 1;
            if (txtPorcentajeBonificacion.Text != string.Empty)
            {
                decimal.Round((100 - decimal.Parse(txtPorcentajeBonificacion.Text)) / 100, 2, MidpointRounding.AwayFromZero);
            }

            if (txtNetoExento.Text != string.Empty)
            {
                importe = decimal.Round(decimal.Parse(txtNetoExento.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                importe = decimal.Zero;
            }

            importe = importe - decimal.Round(valor * multiploBonificacion, 2, MidpointRounding.AwayFromZero);
            txtNetoExento.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }


        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleFacturaCompra.SelectedRows.Count > 0)
                {
                    FacturaDeCompraDetalleDTO regSel = (FacturaDeCompraDetalleDTO)this.dgvDetalleFacturaCompra.SelectedRows[0].DataBoundItem;
                    if (regSel.Exento == 'N')
                    {
                        restarAlSubtotal(regSel.Importe);
                        restarAlNeto(regSel.Importe);
                    }
                    else
                    {
                        restarAlSubtotalExento(regSel.Importe);
                        restarAlNetoExento(regSel.Importe);
                    }

                    //xx
                    //recorrer la lista de comprobante relacionados buscando donde coincida la descripcion
                    List<ComprobanteRelacionDTO> relacionAux = new List<ComprobanteRelacionDTO>(_comprobanteRelacion);
                    foreach (ComprobanteRelacionDTO data in relacionAux)
                    {
                        if (regSel.Descripcion.IndexOf(data.Cod_comprobante_hijo) != -1)
                        {
                            _comprobanteRelacion.Remove(data);
                        }
                    }
                    relacionAux.Clear();

                    _facturaDetalle.Remove(regSel);

                    this.dgvDetalleFacturaCompra.DataSource = null;
                    this.dgvDetalleFacturaCompra.DataSource = _facturaDetalle;
                    this.dgvDetalleFacturaCompra.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error al borrar el registro");
            }
        }

        private void cbxCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelProveedor.Text = _proveedores.obtenerNombre(this.cbxCodProveedor.Text);
            this.cbxTipoFactura.Text = ProveedorDTO.obtenerCondicionIva(this.cbxCodProveedor.Text).ToString();
        }

        private void cbxNombreDelProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxNombreDelProveedor.Text);
            this.cbxTipoFactura.Text = ProveedorDTO.obtenerCondicionIva(this.cbxCodProveedor.Text).ToString();
        }

        private void cbhFechaDeVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhFechaDeVencimiento.Checked)
            {
                dtpFechaDeVencimiento.Enabled = true;
            }
            else
            {
                dtpFechaDeVencimiento.Enabled = false;
            }
        }

        private void txtImporteIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtImporteIva.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtRedondeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtRedondeo.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtImporteImpuesto.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtSubtotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtSubtotal.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtNeto.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtSubtotalExento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtSubtotalExento.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtNetoExento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtNetoExento.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtImporte.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtPorcentajeBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtPorcentajeBonificacion.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(this.txtTotal.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar == ',')
                    e.Handled = true;
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtPrecioUnitario.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
        }

        private void txtPrecioUnitario_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                try
                {
                    if (txtCantidad.Text != string.Empty && txtPrecioUnitario.Text != string.Empty)
                    {
                        decimal importe = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecioUnitario.Text);
                        txtImporte.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

                if (e.KeyChar == ',')
                    e.Handled = true;
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtCantidad.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
        }

        private void btnAgregarIVA_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;

            if (validarNulidadDatosIva(ref msg))
            {
                IvaComprasDetalleDTO det = new IvaComprasDetalleDTO();
                det.Id_iva = long.Parse(this.cbxPorcentajeDeIva.SelectedValue.ToString());
                det.Id_factura = -1;
                det.Desc_iva = this.cbxPorcentajeDeIva.Text;
                det.Importe = decimal.Parse(txtImporteIva.Text);
                det.V_importe = txtImporteIva.Text;
                det.V_porcentaje = this.cbxPorcentajeDeIva.Text;

                _ivaDetalle.Add(det);
                this.dgvDetalleIVA.DataSource = null;
                this.dgvDetalleIVA.DataSource = _ivaDetalle;
                this.dgvDetalleIVA.ClearSelection();

                sumarIva(det.Importe);

                clearDatosIvaForm();
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
            }
        }

        private void btnQuitarIVA_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleIVA.SelectedRows.Count > 0)
                {
                    IvaComprasDetalleDTO regSel = (IvaComprasDetalleDTO)this.dgvDetalleIVA.SelectedRows[0].DataBoundItem;
                    restarAlIvaTotal(regSel.Importe);
                    _ivaDetalle.Remove(regSel);
                    this.dgvDetalleIVA.DataSource = null;
                    this.dgvDetalleIVA.DataSource = _ivaDetalle;
                    this.dgvDetalleIVA.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error al borrar el registro");
            }
        }

        private void btnAgregarImpuesto_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;

            if (validarNulidadDatosImpuesto(ref msg))
            {
                ImpuestoDetalleDTO det = new ImpuestoDetalleDTO();
                det.Id_impuesto = long.Parse(this.cbxPorcentajeImpuesto.SelectedValue.ToString());
                det.Id_factura = -1;
                det.Desc_impuesto = this.cbxDescripcionImpuesto.Text;
                det.Importe = Decimal.Parse(txtImporteImpuesto.Text);
                det.V_importe = txtImporteImpuesto.Text;
                det.V_porcentaje = cbxPorcentajeImpuesto.Text;

                _impuestoDetalle.Add(det);
                this.dgvDetalleImpuesto.DataSource = null;
                this.dgvDetalleImpuesto.DataSource = _impuestoDetalle;
                this.dgvDetalleImpuesto.ClearSelection();

                sumarImpuesto(det.Importe);

                clearDatosImpuestosForm();
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
            }
        }

        private void btnQuitarImpuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleImpuesto.SelectedRows.Count > 0)
                {
                    ImpuestoDetalleDTO regSel = (ImpuestoDetalleDTO)this.dgvDetalleImpuesto.SelectedRows[0].DataBoundItem;
                    restarAlImpuestoTotal(regSel.Importe);
                    _impuestoDetalle.Remove(regSel);
                    this.dgvDetalleImpuesto.DataSource = null;
                    this.dgvDetalleImpuesto.DataSource = _impuestoDetalle;
                    this.dgvDetalleImpuesto.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error al borrar el registro");
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void cbxPorcentajeDeIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularIva();
        }

        private void cbxPorcentajeImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularImpuesto();
        }

        private void cbxCodArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCodProveedor.Text != string.Empty && cbxCodArticulo.Text != string.Empty)
            {
                completarPrecioImporteSiempre();
            }
        }

        private void cbxNombreDeArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCodProveedor.Text != string.Empty && cbxCodArticulo.Text != string.Empty)
            {
                completarPrecioImporteSiempre();
            }
        }

    }
}

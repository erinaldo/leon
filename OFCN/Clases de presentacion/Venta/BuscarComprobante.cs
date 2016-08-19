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
    public partial class frmBuscarComprobante : Form
    {
        private Clientes _clientes;
        private FiltrosABMCliente _filtroClientes;
        private TipoComprobante _tipo_comprobante;
        private Comprobantes _comprobantes;
        private Factura _factura;
        private FacturaDetalle _facturaDetalle;
        private NotaCredito _nota_credito;
        private NotaDebito _nota_debito;
        private Recibo _recibo;
        private Remito _remito;
        private RemitoDetalle _remitoDetalle;

        public frmBuscarComprobante()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _filtroClientes = new FiltrosABMCliente();
            _tipo_comprobante = new TipoComprobante("VENTA");
            _comprobantes = new Comprobantes();
            _factura = new Factura();
            _facturaDetalle = new FacturaDetalle();
            _nota_credito = new NotaCredito();
            _nota_debito = new NotaDebito();
            _recibo = new Recibo();
            _remito = new Remito();
            _remitoDetalle = new RemitoDetalle();
        }

        private void frmBuscarComprobante_Load(object sender, EventArgs e)
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
        }

        private void dgvComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvComprobantes.SelectedRows.Count > 0)
            {
                this.objectToForm((ComprobanteDTO)this.dgvComprobantes.SelectedRows[0].DataBoundItem);
            }
        }

        private void objectToForm(ComprobanteDTO data)
        {
            txtTipoDeComprobante.Text = data.Tipo_comprobante;
            txtNroComprobante.Text = data.Cod_comprobante;
            txtFechaDeRegistro.Text = data.V_fecha;
            if (data.Anulado == 'S')
            {
                chbAnulado.Checked = true;
                btnAnular.Enabled = false;
            }
            else
            {
                chbAnulado.Checked = false;
                btnAnular.Enabled = true;
            }
            this.lblPagado.Visible = false;

            if (data.Tipo_comprobante == "FACTURA A" || data.Tipo_comprobante == "FACTURA B")
            {
                btnImprimir.Enabled = true;
                dgvFacturasAsociadas.Visible = false;
                configurarGridFactura();
                cargarGridFactura(data.Id_origen);
            }

            if (data.Tipo_comprobante == "REMITO")
            {
                btnImprimir.Enabled = true;
                dgvFacturasAsociadas.Visible = false;
                configurarGridRemito();
                if (RemitoDTO.existeRemitoSinFactura(data.Id_cliente, data.Cod_comprobante))
                {
                    cargarGridRemitoSinFactura(data.Id_origen);
                }
                else
                {
                    cargarGridRemito(data.Id_origen, data.Id_cliente);
                }
            }

            if (data.Tipo_comprobante == "NOTA DE CREDITO A" || data.Tipo_comprobante == "NOTA DE CREDITO B")
            {
                btnImprimir.Enabled = true;
                dgvFacturasAsociadas.Visible = false;
                configurarGridFactura();
                cargarGridNC(data.Id_origen);
            }

            if (data.Tipo_comprobante == "NOTA DE DEBITO A" || data.Tipo_comprobante == "NOTA DE DEBITO B")
            {
                btnImprimir.Enabled = true;
                dgvFacturasAsociadas.Visible = false;
                configurarGridFactura();
                cargarGridND(data.Id_origen);
            }

            if (data.Tipo_comprobante == "RECIBO")
            {
                btnImprimir.Enabled = false;
                dgvFacturasAsociadas.Visible = true;
                configurarGridRecibo();
                cargarGridRecibo(data.Id_origen);
            }

            if (lblPagado.Visible)
            {
                btnAnular.Enabled = false;
            }
        }

        //feb 1.8
        private void cargarGridRecibo(long idRecibo)
        {
            _recibo.refreshGridDataReg(idRecibo);
            this.objectToFormRec(_recibo.GridDataListReg[0]);
            _recibo.refreshGridDataDetalleReg(idRecibo);
            this.dgvComprobanteRegistrado.DataSource = _recibo.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
            _recibo.refreshGridDataFacturaReg(idRecibo);
            this.dgvFacturasAsociadas.DataSource = _recibo.GridDataListFacturaReg.Select(x => new { Comprobantes = x }).ToList();
            this.dgvFacturasAsociadas.Font = this.txtTotal.Font;
            this.dgvFacturasAsociadas.ClearSelection();
        }

        private void objectToFormRec(ReciboDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "";
            this.txtBonificacion.Text = "";
            this.txtSubtotal.Text = "";
            this.txtIva.Text = "";
            if (data.V_importe.ToString() != String.Empty)
            {
                this.txtTotal.Text = data.V_importe.ToString();
            }
            else
            {
                this.txtTotal.Text = "";
            }
        }

        private void cargarGridNC(long idCredito)
        {
            _nota_credito.refreshGridDataReg(idCredito);
            this.objectToFormFact(_nota_credito.GridDataListReg[0]);
            _nota_credito.refreshGridDataDetalleReg(idCredito);
            this.dgvComprobanteRegistrado.DataSource = _nota_credito.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
        }

        private void cargarGridND(long idDebito)
        {
            _nota_debito.refreshGridDataReg(idDebito);
            this.objectToFormFact(_nota_debito.GridDataListReg[0]);
            _nota_debito.refreshGridDataDetalleReg(idDebito);
            this.dgvComprobanteRegistrado.DataSource = _nota_debito.GridDataListDetalleReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
        }

        private void configurarGridFactura()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "C.";
            _cantidad.Width = 25;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo"; //id_producto + A + id_servicio
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 100;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion"; //medida de la cubierta y servicio
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 345;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precioUnitario = new DataGridViewTextBoxColumn();
            _precioUnitario.DataPropertyName = "v_precio_unitario";
            _precioUnitario.HeaderText = "Precio Unitario";
            _precioUnitario.Width = 85;
            _precioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 85;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_cantidad);
            this.dgvComprobanteRegistrado.Columns.Add(_codigo);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);
            this.dgvComprobanteRegistrado.Columns.Add(_precioUnitario);
            this.dgvComprobanteRegistrado.Columns.Add(_importe);

        }

        private void cargarGridFactura(long idFactura)
        {
            _factura.refreshGridDataReg(idFactura);
            _factura.GridDataListReg[0].Cod_comprobante_remito = FacturaDTO.obtenerRemito(txtNroComprobante.Text);
            _factura.GridDataListReg[0].Cod_comprobante = txtNroComprobante.Text;
            this.objectToFormFact(_factura.GridDataListReg[0]);
            _facturaDetalle.refreshGridDataReg(idFactura);
            this.dgvComprobanteRegistrado.DataSource = _facturaDetalle.GridDataListReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
        }

        private void objectToFormFact(FacturaDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "REMITO\n" + data.Cod_comprobante_remito;

            if (data.Pagado == 'S')
            {
                this.lblPagado.Visible = true;
            }

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva.Text = "";
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

        private void objectToFormFact(NotaCreditoDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "";

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva.Text = "";
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

        private void objectToFormFact(NotaDebitoDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "";

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva.Text = "";
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

        private void configurarGridRemito()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 40;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo"; //id_producto + A + id_servicio
            _codigo.HeaderText = "Código";
            _codigo.Width = 100;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion"; //medida de la cubierta y servicio
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 500;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_cantidad);
            this.dgvComprobanteRegistrado.Columns.Add(_codigo);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);

        }

        private void configurarGridRecibo()
        {
            this.dgvComprobanteRegistrado.Columns.Clear();
            this.dgvComprobanteRegistrado.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _modalidadPago = new DataGridViewTextBoxColumn();
            _modalidadPago.DataPropertyName = "modalidad_de_pago"; 
            _modalidadPago.HeaderText = "Modalidad de Pago";
            _modalidadPago.Width = 140;
            _modalidadPago.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _modalidadPago.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _modalidadPago.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "detalle"; 
            _descripcion.HeaderText = "Detalle";
            _descripcion.Width = 420;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _importePagoColum = new DataGridViewTextBoxColumn();
            _importePagoColum.DataPropertyName = "v_importe"; 
            _importePagoColum.HeaderText = "Importe";
            _importePagoColum.Width = 80;
            _importePagoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importePagoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importePagoColum.ReadOnly = true;

            this.dgvComprobanteRegistrado.Columns.Add(_modalidadPago);
            this.dgvComprobanteRegistrado.Columns.Add(_descripcion);
            this.dgvComprobanteRegistrado.Columns.Add(_importePagoColum);
        }

        private void cargarGridRemito(long id, string id_cliente)
        {
            _factura.refreshGridDataReg(id);
            _factura.GridDataListReg[0].Cod_comprobante = FacturaDTO.obtenerFactura(txtNroComprobante.Text, id, id_cliente); //feb 1.9.2
            this.objectToFormRem(_factura.GridDataListReg[0]);
            _facturaDetalle.refreshGridDataReg(id);
            this.dgvComprobanteRegistrado.DataSource = _facturaDetalle.GridDataListReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
        }

        private void cargarGridRemitoSinFactura(long id)
        {
            _remito.refreshGridDataReg(id);
            this.objectToFormRem(_remito.GridDataListReg[0]);
            _remitoDetalle.refreshGridDataReg(id);
            this.dgvComprobanteRegistrado.DataSource = _remitoDetalle.GridDataListReg;
            this.dgvComprobanteRegistrado.Font = this.txtTotal.Font;
            this.dgvComprobanteRegistrado.ClearSelection();
        }

        private void objectToFormRem(FacturaDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "FACTURA\n" + data.Cod_comprobante;

            this.txtBonificacion.Text = "";
            this.txtSubtotal.Text = "";
            this.txtIva.Text = "";
            this.txtTotal.Text = "";
        }


        private void objectToFormRem(RemitoDTO data)
        {
            this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
            this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
            this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            this.lblTipoFactura.Text = "FACTURA\n" + data.Cod_comprobante_factura;

            this.txtBonificacion.Text = "";
            this.txtSubtotal.Text = "";
            this.txtIva.Text = "";
            this.txtTotal.Text = "";
        }

        private void FilterToObject()
        {
            _filtroClientes.FiltroCodigo = this.cbxFiltroCodCliente.Text;
            _filtroClientes.FiltroNombre = this.cbxFiltroNombreDeCliente.Text;
            _filtroClientes.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroClientes.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(1); //feb 1.9.2
            if (this.cbxFiltroTipoDeComprobante.Text != "")
            {
                int resultIndex = this.cbxFiltroTipoDeComprobante.FindStringExact(cbxFiltroTipoDeComprobante.Text);
                if (resultIndex != -1)
                {
                    _filtroClientes.FiltroTipoComprobante = long.Parse(this.cbxFiltroTipoDeComprobante.SelectedValue.ToString());
                }
                else
                {
                    _filtroClientes.FiltroTipoComprobante = -1;
                }
            }
            _filtroClientes.FiltroNroComprobante = this.txtFiltroNroDeComprobante.Text;
        }

        private void FilterToObjectFalse()
        {
            _filtroClientes.FiltroCodigo = "XXXXXXXX";
            _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroClientes.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroClientes.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(1);
            _filtroClientes.FiltroTipoComprobante = -1;
            _filtroClientes.FiltroNroComprobante = "XXXXXXXX";
        }

        //feb 1.8
        private void cargarFiltrosBusqueda()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodCliente.DataSource = _clientes.CodDataList;

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDeCliente.DataSource = _clientes.NombreDataList;

            this.cbxFiltroTipoDeComprobante.DataSource = _tipo_comprobante.OwnDataList;
            this.cbxFiltroTipoDeComprobante.DisplayMember = "valor";
            this.cbxFiltroTipoDeComprobante.ValueMember = "id";

            //int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-365);
        }

        private void cbxFiltroCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDeCliente.Text = _clientes.obtenerNombre(this.cbxFiltroCodCliente.Text);
        }

        private void cbxFiltroNombreDeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodCliente.Text = _clientes.obtenerCodigo(this.cbxFiltroNombreDeCliente.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxFiltroCodCliente.Text == string.Empty)
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
                if (cbxFiltroCodCliente.Text == string.Empty)
                {
                    completarFiltro();
                }
                FilterToObject();
                cargarGridComprobantes();
            }
        }

        private void completarFiltro()
        {
            if (this.cbxFiltroTipoDeComprobante.Text != "")
            {
                int resultIndex = this.cbxFiltroTipoDeComprobante.FindStringExact(cbxFiltroTipoDeComprobante.Text);
                if (resultIndex != -1 && this.txtFiltroNroDeComprobante.Text != string.Empty) //feb 1.9.1 corrección de bug
                {
                    this.cbxFiltroCodCliente.Text = ComprobanteDTO.obtenerCodCliente(long.Parse(this.cbxFiltroTipoDeComprobante.SelectedValue.ToString()), this.txtFiltroNroDeComprobante.Text);
                    if (this.cbxFiltroCodCliente.Text == string.Empty && this.cbxFiltroTipoDeComprobante.Text == "REMITO")
                    {
                        this.cbxFiltroCodCliente.Text = RemitoDTO.obtenerCodCliente(this.txtFiltroNroDeComprobante.Text);
                    }
                }
            }
        }

        private void cargarGridComprobantes()
        {
            _comprobantes.refreshGridData(_filtroClientes);
            this.dgvComprobantes.DataSource = _comprobantes.GridDataList;
            this.dgvComprobantes.ClearSelection();
        }


        private void configurarGridComprobantes()
        {
            this.dgvComprobantes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fecha = new DataGridViewTextBoxColumn();
            _fecha.DataPropertyName = "v_fecha";
            _fecha.HeaderText = "Fecha de Registro";
            _fecha.Width = 135;
            _fecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha.ReadOnly = true;

            DataGridViewTextBoxColumn _clienteColum = new DataGridViewTextBoxColumn();
            _clienteColum.DataPropertyName = "id_cliente";
            _clienteColum.HeaderText = "Cod. Cliente";
            _clienteColum.Width = 100;
            _clienteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _clienteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _clienteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _comprobante = new DataGridViewTextBoxColumn();
            _comprobante.DataPropertyName = "tipo_comprobante";
            _comprobante.HeaderText = "Tipo de Comprobante";
            _comprobante.Width = 181;
            _comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobante = new DataGridViewTextBoxColumn();
            _codComprobante.DataPropertyName = "cod_comprobante";
            _codComprobante.HeaderText = "Nro. Comprobante";
            _codComprobante.Width = 181;
            _codComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.ReadOnly = true;

            this.dgvComprobantes.Columns.Add(_fecha);
            this.dgvComprobantes.Columns.Add(_clienteColum);
            this.dgvComprobantes.Columns.Add(_comprobante);
            this.dgvComprobantes.Columns.Add(_codComprobante);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectFalse();
            cargarGridComprobantes();
            this.cbxFiltroCodCliente.Focus();
        }

        private void clearFilter()
        {
            this.objectToFilter(new FiltrosABMCliente());
            //int dias_transcurridos = System.DateTime.Now.Day * (-1);
            //this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-365);
            this.dtpFechaHasta.Value = System.DateTime.Now;
        }

        private void objectToFilter(FiltrosABMCliente filtro)
        {
            this.cbxFiltroCodCliente.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombreDeCliente.Text = filtro.FiltroNombre;
            if (filtro.FiltroTipoComprobante == -1)
            {
                this.cbxFiltroTipoDeComprobante.Text = "";
            }
            this.txtFiltroNroDeComprobante.Text = filtro.FiltroNroComprobante;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (txtTipoDeComprobante.Text != "")
            {
                ComprobanteDTO data = new ComprobanteDTO();
                data.Tipo_comprobante = txtTipoDeComprobante.Text;
                data.Cod_comprobante = txtNroComprobante.Text;
                data.V_fecha = txtFechaDeRegistro.Text;
                data.Anulado = 'S';
                string[] customFmts = { "dd/MM/yyyy HH:mm:ss", "d/MM/yyyy HH:mm:ss" };
                //mes y año del comprobante
                int dtcm = DateTime.ParseExact(data.V_fecha, customFmts, new CultureInfo("en-US"), DateTimeStyles.None).Month;
                int dtcy = DateTime.ParseExact(data.V_fecha, customFmts, new CultureInfo("en-US"), DateTimeStyles.None).Year;

                //mes y año actual
                int dtam = System.DateTime.Now.Month;
                int dtay = System.DateTime.Now.Year;

                if ((!dtcm.Equals(dtam) || !dtcy.Equals(dtay)) && txtTipoDeComprobante.Text != "RECIBO")
                {
                    MessageBox.Show("Solo es posible anular un comprobante de facturación durante el mes en curso.", "Anular Comprobante");
                }
                else
                {
                    if (txtTipoDeComprobante.Text == "FACTURA A" || txtTipoDeComprobante.Text == "FACTURA B")
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea anular la factura?", "Comprobante", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _factura.AnularFactura(_factura.GridDataListReg[0]);
                            data.Id_origen = _factura.GridDataListReg[0].Id;
                            objectToForm(data);
                            FilterToObject();
                            cargarGridComprobantes();
                            MessageBox.Show("La operación fue realizada con éxito.", "Comprobante Anulado");
                        }
                    }

                    if (txtTipoDeComprobante.Text == "REMITO")
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea anular el remito?. Atención: Si el remito tiene factura asociada debe también anular ésta para el reingreso automático de la mercadería.", "Comprobante", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //inicio feb 1.9.2
                            bool esRemitoSinFactura = false;

                            if (RemitoDTO.existeRemitoSinFacturaPermanente(data.Cod_comprobante))
                            {
                                _remito.AnularRemitoGenerado(_remito.GridDataListReg[0]);
                                data.Id_origen = _remito.GridDataListReg[0].Id;
                                data.Id_cliente = _remito.GridDataListReg[0].Id_cliente;
                                esRemitoSinFactura = true;
                            }

                            if (RemitoDTO.existeRemitoSinFacturaTemporal(data.Cod_comprobante))
                            {
                                _remito.AnularRemito(_remito.GridDataListReg[0]);
                                data.Id_origen = _remito.GridDataListReg[0].Id;
                                data.Id_cliente = _remito.GridDataListReg[0].Id_cliente;
                                esRemitoSinFactura = true;
                            }

                            if (!esRemitoSinFactura)
                            {
                                _factura.AnularRemito(_factura.GridDataListReg[0]);
                                data.Id_origen = _factura.GridDataListReg[0].Id;
                                data.Id_cliente = _factura.GridDataListReg[0].Id_cliente;
                            }
                            //fin feb 1.9.2
                            objectToForm(data);
                            FilterToObject();
                            cargarGridComprobantes();
                            MessageBox.Show("La operación fue realizada con éxito.", "Comprobante Anulado");
                        }
                    }

                    if (txtTipoDeComprobante.Text == "NOTA DE CREDITO A" || txtTipoDeComprobante.Text == "NOTA DE CREDITO B")
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea anular la nota de crédito?", "Comprobante", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _nota_credito.AnularCredito(_nota_credito.GridDataListReg[0], (List<NotaCreditoDetalleDTO>)dgvComprobanteRegistrado.DataSource);
                            data.Id_origen = _nota_credito.GridDataListReg[0].Id;
                            objectToForm(data);
                            FilterToObject();
                            cargarGridComprobantes();
                            MessageBox.Show("La operación fue realizada con éxito.", "Comprobante Anulado");
                        }
                    }

                    if (txtTipoDeComprobante.Text == "NOTA DE DEBITO A" || txtTipoDeComprobante.Text == "NOTA DE DEBITO B")
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea anular la nota de débito?", "Comprobante", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _nota_debito.AnularDebito(_nota_debito.GridDataListReg[0]);
                            data.Id_origen = _nota_debito.GridDataListReg[0].Id;
                            objectToForm(data);
                            FilterToObject();
                            cargarGridComprobantes();
                            MessageBox.Show("La operación fue realizada con éxito.", "Comprobante Anulado");
                        }
                    }

                    //feb 1.8
                    if (txtTipoDeComprobante.Text == "RECIBO")
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Desea recuperar el recibo del inventario y borrar todos los datos del comprobante?.", "Comprobante", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _recibo.recalcularMovimientosPost(_recibo.GridDataListReg[0]);
                            _recibo.anular(_recibo.GridDataListReg[0]);
                            TalonarioDetalleDTO.actualizarEstado(txtNroComprobante.Text, "DISPONIBLE");
                            objectToFormClear();
                            FilterToObject();
                            cargarGridComprobantes();
                            MessageBox.Show("La operación fue realizada con éxito.", "Comprobante Anulado");
                        }
                    }

                }

            }

        }

        private void objectToFormClear()
        {
            this.txtTipoDeComprobante.Text = "";
            this.txtNroComprobante.Text = "";
            this.txtFechaDeRegistro.Text = "";
            this.lblDatosDelCliente.Text = "";
            this.lblTipoFactura.Text = "";
            this.txtBonificacion.Text = "";
            this.txtSubtotal.Text = "";
            this.txtIva.Text = "";
            this.txtTotal.Text = "";
            this.dgvComprobanteRegistrado.DataSource = null;
            btnAnular.Enabled = true;
            btnImprimir.Enabled = true;
            this.dgvFacturasAsociadas.DataSource = null;
            this.dgvFacturasAsociadas.Visible = false;
            this.lblPagado.Visible = false;
        }

        private void btnLimpiarVista_Click(object sender, EventArgs e)
        {
            objectToFormClear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtTipoDeComprobante.Text == "FACTURA A")
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = null;
                    if (_factura.GridDataListReg[0].Iva105 == 'N')
                    {
                        rptLista = GenerarImpresionFacturaA.cargarReporte(string.Empty, _factura.GridDataListReg[0].Id, _factura.GridDataListReg[0].Cod_comprobante_remito);
                        frmReporte.crvFacturaA.ReportSource = rptLista;
                    }
                    else
                    {
                        rptLista = GenerarImpresionFacturaA.cargarReporte105(string.Empty, _factura.GridDataListReg[0].Id, _factura.GridDataListReg[0].Cod_comprobante_remito);
                        frmReporte.crvFacturaA.ReportSource = rptLista;
                    }
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "NOTA DE CREDITO A")
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteCredito(_nota_credito.GridDataListReg[0].Id);
                    frmReporte.crvFacturaA.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "NOTA DE DEBITO A")
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteDebito(_nota_debito.GridDataListReg[0].Id);
                    frmReporte.crvFacturaA.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "FACTURA B")
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = null;
                    if (_factura.GridDataListReg[0].Iva105 == 'N')
                    {
                        rptLista = GenerarImpresionFacturaB.cargarReporte(string.Empty, _factura.GridDataListReg[0].Id, _factura.GridDataListReg[0].Cod_comprobante_remito);
                        frmReporte.crvFacturaB.ReportSource = rptLista;
                    }
                    else
                    {
                        rptLista = GenerarImpresionFacturaB.cargarReporte105(string.Empty, _factura.GridDataListReg[0].Id, _factura.GridDataListReg[0].Cod_comprobante_remito);
                        frmReporte.crvFacturaB.ReportSource = rptLista;
                    }
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "NOTA DE CREDITO B")
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteCredito(_nota_credito.GridDataListReg[0].Id);
                    frmReporte.crvFacturaB.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "NOTA DE DEBITO B")
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteDebito(_nota_debito.GridDataListReg[0].Id);
                    frmReporte.crvFacturaB.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "REMITO" && !RemitoDTO.existeRemitoSinFactura(txtNroComprobante.Text))
                {
                    string cod_factura = _factura.GridDataListReg[0].Cod_comprobante;
                    frmVerRemito frmReporte = new frmVerRemito();
                    crRemito rptLista = GenerarImpresionRemito.cargarReporte(_factura.GridDataListReg[0].Id, cod_factura);
                    frmReporte.crvRemito.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }

                if (txtTipoDeComprobante.Text == "REMITO" && RemitoDTO.existeRemitoSinFactura(txtNroComprobante.Text))
                {
                    frmVerRemito frmReporte = new frmVerRemito();
                    crRemito rptLista = GenerarImpresionRemito.cargarReporteRemitoPendiente(_remito.GridDataListReg[0].Id, string.Empty);
                    frmReporte.crvRemito.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
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

    }
}

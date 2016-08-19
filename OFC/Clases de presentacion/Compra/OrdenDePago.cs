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
    public partial class frmOrdenDePago : Form
    {
        private Proveedores _proveedores;
        private FiltrosABMProveedor _filtroProveedores;
        private CuentaCorriente _cuenta;
        private FacturaDeCompra _factura;
        private List<FacturaDeCompraDTO> _facturasAPagar;
        private FormaPago _fpago;
        private RetencionOrdenDePago _retencion;
        private List<PagoDetalleDTO> _pagoDetalle;
        private PagoDetalleRetencionDTO _pagoDetalleRetencion;
        private Pago _pago;

        public frmOrdenDePago()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _filtroProveedores = new FiltrosABMProveedor();
            _cuenta = new CuentaCorriente();
            _factura = new FacturaDeCompra();
            _facturasAPagar = new List<FacturaDeCompraDTO>();
            _fpago = new FormaPago();
            _retencion = new RetencionOrdenDePago();
            _pagoDetalle = new List<PagoDetalleDTO>();
            _pagoDetalleRetencion = new PagoDetalleRetencionDTO();
            _pago = new Pago();
        }

        private void frmOrdenDePago_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarDatosForm();
            configurarGridFacturasImpagas();
            configurarGridFacturas();
            configurarGridDatosPago();
            configurarGridPagosDelMes();
            cargarGridFacturasDebitosImpagos();
            cargarGridPagosDelMes();
            setImportesEnCero();
            calcularDirenciaDeImportes();
        }

        private void setImportesEnCero()
        {
            txtImportePagados.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImportePago.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImporteDePagoParcial.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImporteDePago.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
        }

        private void cargarDatosForm()
        {
            this.txtNroOrdenDePago.Text = _pago.Nro_pago.ToString();

            this.cbxCodProveedor.DataSource = _proveedores.CodDataList;
            this.cbxNombreDelProveedor.DataSource = _proveedores.NombreDataList;

            this.cbxModalidadDePago.DataSource = _fpago.OwnDataList;
            this.cbxModalidadDePago.DisplayMember = "valor";
            this.cbxModalidadDePago.ValueMember = "id";

            this.cbxTipoDeRetencion.DataSource = _retencion.OwnDataList;
            this.cbxTipoDeRetencion.DisplayMember = "valor";
            this.cbxTipoDeRetencion.ValueMember = "id";
        }

        private void btnDetalleRetencion_Click(object sender, EventArgs e)
        {
            if (cbxModalidadDePago.Text == "RETENCION" && cbxTipoDeRetencion.Text != string.Empty && cbxCodProveedor.Text != string.Empty)
            {
                //calcular los importes
                _pagoDetalleRetencion.Importe_orden_de_pago = decimal.Parse(txtImporteDePago.Text);
                decimal aux = (decimal) 1 + ((decimal)ParametroDTO.obtenerParametroI("IVA_ORDEN_DE_PAGO")/(decimal)100);
                _pagoDetalleRetencion.Importe_neto = decimal.Divide(_pagoDetalleRetencion.Importe_orden_de_pago, aux);
                _pagoDetalleRetencion.Importe_pagos_anteriores = decimal.Divide(decimal.Parse(txtImportePagados.Text), aux);
                _pagoDetalleRetencion.Importe_retencion_anterior = PagoDetalleRetencionDTO.sumaImportesRetencionDelMes(cbxCodProveedor.Text, long.Parse(this.cbxTipoDeRetencion.SelectedValue.ToString()));

                frmDetalleRetencion frmRetenciones = new frmDetalleRetencion(cbxCodProveedor.Text, long.Parse(this.cbxTipoDeRetencion.SelectedValue.ToString()), _pagoDetalleRetencion);
                frmRetenciones.ShowDialog();
                if (frmRetenciones.Retencion.DetalleRet.Periodo_anio != -1 && frmRetenciones.Retencion.DetalleRet.Periodo_mes != -1)
                {
                    _pagoDetalleRetencion = frmRetenciones.Retencion.DetalleRet;
                    txtImportePago.Text = frmRetenciones.Retencion.DetalleRet.Importe_retencion_actual.ToString();
                    frmRetenciones.Dispose();
                    btnSumar.PerformClick(); //buenisimo
                }
                else
                {
                    frmRetenciones.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar el proveedor, la modalidad de pago y el tipo de retención", "Orden de Pago");
            }
        }

        private void deshabilitarDatosProveedor()
        {
            cbxCodProveedor.Enabled = false;
            cbxNombreDelProveedor.Enabled = false;
            dtpFechaDelComprobante.Enabled = false;
            btnX.Enabled = false;
        }

        private void habilitarDatosProveedor()
        {
            cbxCodProveedor.Enabled = true;
            cbxNombreDelProveedor.Enabled = true;
            dtpFechaDelComprobante.Enabled = true;
            btnX.Enabled = true;
            cbxCodProveedor.Focus();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;

            if (validarNulidadDatosProv(ref msg))
            {
                FilterToObjectABM();
                cargarDatosCuenta();
                cargarGridFacturasDebitosImpagos();
                cargarGridPagosDelMes();
                deshabilitarDatosProveedor();
            }
            else
            {
                MessageBox.Show("No es posible obtener las facturas impagas. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Pago");
            }
            
        }

        private void cbxProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string msg = String.Empty;

                if (validarNulidadDatosProv(ref msg))
                {
                    FilterToObjectABM();
                    cargarDatosCuenta();
                    cargarGridFacturasDebitosImpagos();
                    cargarGridPagosDelMes();
                    deshabilitarDatosProveedor();
                }
                else
                {
                    MessageBox.Show("No es posible obtener las facturas impagas. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Pago");
                }
            }
        }

        
        private void calcularDirenciaDeImportes()
        {
            decimal diferencia = decimal.Parse(txtImporteTotal.Text) - decimal.Parse(txtImporteDePago.Text);
            lblDiferenciaDeImportes.Text = String.Format("{0:0.00}", Math.Round(diferencia, 2, MidpointRounding.AwayFromZero));
        }

        private void cargarGridFacturasDebitosImpagos()
        {
            _factura.refreshGridDataImpagas(this.cbxCodProveedor.Text); //facturas y notas de debitos

            this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
            this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
            this.dgvFacturasImpagas.ClearSelection();
            ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        private void cargarGridPagosDelMes()
        {
            _pago.refreshGridDataPagoDelMes(this.cbxCodProveedor.Text, dtpFechaDelComprobante.Value.Date);

            this.dgvPagoDelMes.DataSource = _pago.GridDataListPagosDelMes;
            this.dgvPagoDelMes.Font = txtImporteFacturas.Font;
            this.dgvPagoDelMes.ClearSelection();
            sumarImportesDePagos(_pago.GridDataListPagosDelMes);

            if (cbxCodProveedor.Text != string.Empty && cbxNombreDelProveedor.Text != string.Empty)
            {
                lblPagosRealizadosEnElMes.Text += ": " + dtpFechaDelComprobante.Value.Date.Month.ToString() + "-" + dtpFechaDelComprobante.Value.Date.Year.ToString();
            }
        }

        private void sumarImportesDePagos(IList<PagoDTO> pagos)
        {
            decimal sumador = decimal.Zero;
            foreach (PagoDTO pago in pagos)
            {
                sumador += pago.Importe;
            }
            txtImportePagados.Text = String.Format("{0:0.00}", Math.Round(sumador, 2, MidpointRounding.AwayFromZero));
        }

        private void FilterToObjectABM()
        {
            if (this.cbxCodProveedor.Text != "")
            {
                _filtroProveedores.FiltroCodigo = this.cbxCodProveedor.Text;
            }
            else
            {
                _filtroProveedores.FiltroCodigo = "XXXXXXXX";
            }

            if (this.cbxNombreDelProveedor.Text != "")
            {
                _filtroProveedores.FiltroNombre = this.cbxNombreDelProveedor.Text;
            }
            else
            {
                _filtroProveedores.FiltroNombre = "XXXXXXXXXXXXXXXX";
            }
        }

        private void cargarDatosCuenta()
        {

            if (_filtroProveedores.FiltroCodigo != "")
            {
                _cuenta.refreshGridData(_filtroProveedores);

                if (_cuenta.GridDataListProv.Count == 1)
                {
                    this.lblSaldoDeudor.Text = "Saldo Cuenta Corriente: " + _cuenta.GridDataListProv[0].V_saldo.ToString();
                }
                else
                {
                    this.lblSaldoDeudor.Text = "";
                }
            }

        }

        private bool validarNulidadDatosProv(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de Proveedor.";
            }
            else
            {
                int resultIndex = this.cbxCodProveedor.FindStringExact(cbxCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxNombreDelProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Nombre de Proveedor.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelProveedor.FindStringExact(cbxNombreDelProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de proveedor ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;

        }

        private void cbxCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelProveedor.Text = _proveedores.obtenerNombre(this.cbxCodProveedor.Text);
        }

        private void cbxNombreDelProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxNombreDelProveedor.Text);
        }

        private void configurarGridFacturasImpagas()
        {
            this.dgvFacturasImpagas.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewTextBoxColumn _fechaColum = new DataGridViewTextBoxColumn();
            _fechaColum.DataPropertyName = "fecha_creacion";
            _fechaColum.HeaderText = "Fecha";
            _fechaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaColum.Width = 80;
            _fechaColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _fechaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _tipoComprobante = new DataGridViewTextBoxColumn();
            _tipoComprobante.DataPropertyName = "tipo_comprobante";
            _tipoComprobante.HeaderText = "TC";
            _tipoComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobante.Width = 45;
            _tipoComprobante.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _tipoComprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "cod_comprobante";
            _codComprobanteColum.HeaderText = "Cód. Comprobante";
            _codComprobanteColum.Width = 133;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _codComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_total";
            _impTotalColum.HeaderText = "Imp. Total";
            _impTotalColum.Width = 103;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impPagadoColum = new DataGridViewTextBoxColumn();
            _impPagadoColum.DataPropertyName = "v_importe_pagado";
            _impPagadoColum.HeaderText = "Imp. Pagado";
            _impPagadoColum.Width = 103;
            _impPagadoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impPagadoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impAdeudadoColum = new DataGridViewTextBoxColumn();
            _impAdeudadoColum.DataPropertyName = "v_importe_adeudado";
            _impAdeudadoColum.HeaderText = "Imp. Adeud.";
            _impAdeudadoColum.Width = 103;
            _impAdeudadoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impAdeudadoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impAdeudadoColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impAdeudadoColum.ReadOnly = true;

            this.dgvFacturasImpagas.Columns.Add(procesar);
            this.dgvFacturasImpagas.Columns.Add(_fechaColum);
            this.dgvFacturasImpagas.Columns.Add(_tipoComprobante);
            this.dgvFacturasImpagas.Columns.Add(_codComprobanteColum);
            this.dgvFacturasImpagas.Columns.Add(_impTotalColum);
            this.dgvFacturasImpagas.Columns.Add(_impPagadoColum);
            this.dgvFacturasImpagas.Columns.Add(_impAdeudadoColum);
            show_chkBox();

        }

        private void configurarGridFacturas()
        {
            this.dgvFacturas.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewTextBoxColumn _tipoComprobanteColum = new DataGridViewTextBoxColumn();
            _tipoComprobanteColum.DataPropertyName = "tipo_comprobante";
            _tipoComprobanteColum.HeaderText = "TC";
            _tipoComprobanteColum.Width = 49;
            _tipoComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _tipoComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "cod_comprobante";
            _codComprobanteColum.HeaderText = "Cód. Comprobante";
            _codComprobanteColum.Width = 150;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _codComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_total";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 125;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impPagadoColum = new DataGridViewTextBoxColumn();
            _impPagadoColum.DataPropertyName = "v_importe_de_pago";
            _impPagadoColum.HeaderText = "Imp. de Pago";
            _impPagadoColum.Width = 125;
            _impPagadoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impPagadoColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impPagadoColum.ReadOnly = true;

            this.dgvFacturas.Columns.Add(procesar);
            this.dgvFacturas.Columns.Add(_tipoComprobanteColum);
            this.dgvFacturas.Columns.Add(_codComprobanteColum);
            this.dgvFacturas.Columns.Add(_impTotalColum);
            this.dgvFacturas.Columns.Add(_impPagadoColum);
            show_chkBox2();

        }

        private void configurarGridDatosPago()
        {
            this.dgvDatosDelPago.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewTextBoxColumn _modalidadPagoColum = new DataGridViewTextBoxColumn();
            _modalidadPagoColum.DataPropertyName = "modalidad_de_pago";
            _modalidadPagoColum.HeaderText = "Modalidad de Pago";
            _modalidadPagoColum.Width = 204;
            _modalidadPagoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _modalidadPagoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _modalidadPagoColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _modalidadPagoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_importe";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 204;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            this.dgvDatosDelPago.Columns.Add(procesar);
            this.dgvDatosDelPago.Columns.Add(_modalidadPagoColum);
            this.dgvDatosDelPago.Columns.Add(_impTotalColum);
            show_chkBox3();

        }

        private void configurarGridPagosDelMes()
        {
            this.dgvPagoDelMes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fechaDePago = new DataGridViewTextBoxColumn();
            _fechaDePago.DataPropertyName = "v_fecha_pago";
            _fechaDePago.HeaderText = "Fecha de Pago";
            _fechaDePago.Width = 200;
            _fechaDePago.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaDePago.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaDePago.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _fechaDePago.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "nro_pago";
            _codComprobanteColum.HeaderText = "Cód. Comprobante";
            _codComprobanteColum.Width = 200;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _codComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_importe";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 151;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            this.dgvPagoDelMes.Columns.Add(_fechaDePago);
            this.dgvPagoDelMes.Columns.Add(_codComprobanteColum);
            this.dgvPagoDelMes.Columns.Add(_impTotalColum);
        }

        private void show_chkBox()
        {
            Rectangle rect = dgvFacturasImpagas.GetCellDisplayRectangle(0, -1, true);

            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dgvOrdenesDeTrabajo[0, 0].ToolTipText = "P.";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.BackColor = dgvFacturasImpagas.RowHeadersDefaultCellStyle.BackColor;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dgvFacturasImpagas.Controls.Add(checkboxHeader);
        }

        private void show_chkBox2()
        {
            Rectangle rect = dgvFacturas.GetCellDisplayRectangle(0, -1, true);

            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dgvOrdenesDeTrabajo[0, 0].ToolTipText = "P.";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.BackColor = dgvFacturas.RowHeadersDefaultCellStyle.BackColor;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged2);
            dgvFacturas.Controls.Add(checkboxHeader);
        }

        private void show_chkBox3()
        {
            Rectangle rect = dgvDatosDelPago.GetCellDisplayRectangle(0, -1, true);

            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dgvOrdenesDeTrabajo[0, 0].ToolTipText = "P.";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.BackColor = dgvDatosDelPago.RowHeadersDefaultCellStyle.BackColor;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged3);
            dgvDatosDelPago.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]);

            int valor;

            if (headerBox.Checked)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }

            for (int i = 0; i < dgvFacturasImpagas.RowCount; i++)
            {

                dgvFacturasImpagas.Rows[i].Cells[0].Value = valor;

            }

            dgvFacturasImpagas.EndEdit();

        }

        private void checkboxHeader_CheckedChanged2(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dgvFacturas.Controls.Find("checkboxHeader", true)[0]);

            int valor;

            if (headerBox.Checked)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }

            for (int i = 0; i < dgvFacturas.RowCount; i++)
            {

                dgvFacturas.Rows[i].Cells[0].Value = valor;

            }

            dgvFacturas.EndEdit();

        }

        private void checkboxHeader_CheckedChanged3(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dgvDatosDelPago.Controls.Find("checkboxHeader", true)[0]);

            int valor;

            if (headerBox.Checked)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }

            for (int i = 0; i < dgvDatosDelPago.RowCount; i++)
            {

                dgvDatosDelPago.Rows[i].Cells[0].Value = valor;

            }

            dgvDatosDelPago.EndEdit();

        }

        private void clearForm()
        {
            _pago.iniciarPago();
            this.txtNroOrdenDePago.Text = _pago.Nro_pago.ToString();
            this.cbxCodProveedor.Text = "";
            this._factura.GridDataListImpagas.Clear();
            this.dgvFacturasImpagas.DataSource = null;
            _facturasAPagar.Clear();
            this.dgvFacturas.DataSource = null;
            this.cbxModalidadDePago.SelectedIndex = 0;
            this.cbxTipoDeRetencion.SelectedIndex = 0;
            this.txtDetalle.Text = String.Empty;
            _pagoDetalle.Clear();
            this.dgvDatosDelPago.DataSource = null;
            lblSaldoDeudor.Text = "";
            this._pago.GridDataListPagosDelMes.Clear();
            this.dgvPagoDelMes.DataSource = null;
            _pagoDetalleRetencion = new PagoDetalleRetencionDTO();
            setImportesEnCero();
            lblPagosRealizadosEnElMes.Text = "Ordenes de Pagos del Mes";
        }

        private void btnLimpiarVista_Click(object sender, EventArgs e)
        {
            clearForm();
            habilitarDatosProveedor();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool haySeleccion = false;
            int cantidad = dgvFacturasImpagas.Rows.Count;
            FacturaDeCompraDTO fcompra = new FacturaDeCompraDTO();

            for (int i = 0; i < cantidad; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    fcompra = (FacturaDeCompraDTO)dgvFacturasImpagas.Rows[i].DataBoundItem;
                    fcompra.Importe_de_pago = fcompra.Total - fcompra.Importe_pagado;
                    fcompra.V_importe_de_pago = String.Format("{0:C}", Math.Round(fcompra.Importe_de_pago, 2, MidpointRounding.AwayFromZero));
                    fcompra.Importe_pagado_acumulado = fcompra.Importe_pagado + fcompra.Importe_de_pago;
                    fcompra.Importe_adeudado_actualizado = fcompra.Total - fcompra.Importe_pagado_acumulado;
                    fcompra.Pago_parcial = 'N';
                    _facturasAPagar.Add(fcompra);
                    haySeleccion = true;
                }
            }

            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Orden de Pago");
            }
            else
            {
                for (int i = cantidad - 1; i >= 0; i--)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        _factura.GridDataListImpagas.Remove((FacturaDeCompraDTO)dgvFacturasImpagas.Rows[i].DataBoundItem);
                    }
                }

                decimal importe = decimal.Zero;
                decimal importeDePago = decimal.Zero;

                foreach (FacturaDeCompraDTO f in _facturasAPagar)
                {
                    importe += f.Total;
                    importeDePago += f.Importe_de_pago;
                }

                txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                txtImporteDePago.Text = String.Format("{0:0.00}", Math.Round(importeDePago, 2, MidpointRounding.AwayFromZero));

                this.dgvFacturas.DataSource = null;
                this.dgvFacturas.DataSource = _facturasAPagar;
                this.dgvFacturas.Font = txtImporteFacturas.Font;
                this.dgvFacturas.ClearSelection();

                this.dgvFacturasImpagas.DataSource = null;
                this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
                this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
                this.dgvFacturasImpagas.ClearSelection();
            }

            ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
            calcularDirenciaDeImportes();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            bool haySeleccion = false;

            int cantidad = dgvFacturas.Rows.Count;

            for (int i = 0; i < cantidad; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturas.Rows[i].Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    //no vuelvo atrás el importe pagado acumulado y el importe adeudado actualizado... pero no deberia traer problema si quito el objeto de la lista. los importes son recalculados en el add.
                    _factura.GridDataListImpagas.Add((FacturaDeCompraDTO)dgvFacturas.Rows[i].DataBoundItem);
                    _factura.GridDataListImpagas = _factura.GridDataListImpagas.OrderBy(o => o.Fecha_creacion).ToList();
                    haySeleccion = true;
                }
            }


            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Orden de Pago");
            }
            else
            {
                for (int i = cantidad - 1; i >= 0; i--)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        _facturasAPagar.Remove((FacturaDeCompraDTO)dgvFacturas.Rows[i].DataBoundItem);
                    }
                }

                decimal importe = decimal.Zero;
                decimal importeDePago = decimal.Zero;

                foreach (FacturaDeCompraDTO f in _facturasAPagar)
                {
                    importe += f.Total;
                    importeDePago += f.Importe_de_pago;
                }

                txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                txtImporteDePago.Text = String.Format("{0:0.00}", Math.Round(importeDePago, 2, MidpointRounding.AwayFromZero));

                this.dgvFacturas.DataSource = null;
                this.dgvFacturas.DataSource = _facturasAPagar;
                this.dgvFacturas.Font = txtImporteFacturas.Font;
                this.dgvFacturas.ClearSelection();

                this.dgvFacturasImpagas.DataSource = null;
                this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
                this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
                this.dgvFacturasImpagas.ClearSelection();
            }

            ((CheckBox)dgvFacturas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
            calcularDirenciaDeImportes();
        }

        private bool validarNulidadDatosPago(ref string msg)
        {
            bool rv = true;

            if (this.cbxModalidadDePago.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la Modalidad de pago.";
            }
            else
            {
                int resultIndex = this.cbxModalidadDePago.FindStringExact(cbxModalidadDePago.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa modalidad de pago ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxModalidadDePago.Text == "RETENCION" && this.cbxTipoDeRetencion.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el tipo de retención.";
            }

            if (this.cbxModalidadDePago.Text == "RETENCION" && this.cbxTipoDeRetencion.Text != "")
            {
                int resultIndex = this.cbxTipoDeRetencion.FindStringExact(cbxTipoDeRetencion.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl tipo de retención ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.cbxModalidadDePago.Text != "RETENCION" && this.cbxTipoDeRetencion.Text != "")
            {
                rv = false;
                msg += "\nNo debe ingresar el tipo de retención.";
            }

            if (this.txtImportePago.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Importe de Pago.";
            }

            return rv;

        }

        private void txtImportePago_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImportePago.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteDePagoParcial_KeyPress(object sender, KeyPressEventArgs e) 
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
                    bool rv = Decimal.TryParse(this.txtImporteDePagoParcial.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;

            if (validarNulidadDatosPago(ref msg))
            {
                decimal importePago = decimal.Zero;

                PagoDetalleDTO det = new PagoDetalleDTO();
                det.Id_modalidad_de_pago = long.Parse(this.cbxModalidadDePago.SelectedValue.ToString());
                det.Modalidad_de_pago = this.cbxModalidadDePago.Text;
                det.Importe = decimal.Parse(this.txtImportePago.Text);
                det.Importe = decimal.Round(det.Importe, 2, MidpointRounding.AwayFromZero);
                det.V_importe = String.Format("{0:0.00}", Math.Round(det.Importe, 2, MidpointRounding.AwayFromZero));
                det.Detalle = txtDetalle.Text;
                if (this.cbxTipoDeRetencion.Text != "")
                {
                    det.Id_tipo_retencion = long.Parse(this.cbxTipoDeRetencion.SelectedValue.ToString());
                }
                else
                {
                    det.Id_tipo_retencion = -1;
                }
                det.DetalleRetencion = _pagoDetalleRetencion;

                _pagoDetalle.Add(det);

                _pagoDetalleRetencion = new PagoDetalleRetencionDTO(); // para limpiar..
                this.dgvDatosDelPago.DataSource = null;
                this.dgvDatosDelPago.DataSource = _pagoDetalle;
                this.dgvDatosDelPago.ClearSelection();

                foreach (PagoDetalleDTO r in _pagoDetalle)
                {
                    importePago += r.Importe;
                }

                txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(importePago, 2, MidpointRounding.AwayFromZero));
                cbxModalidadDePago.Text = "";
                txtDetalle.Text = "";
                cbxTipoDeRetencion.Text = "";
                txtImportePago.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
                calcularDirenciaDeImportes();
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Pago");
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            bool haySeleccion = false;
            decimal importePago = decimal.Zero;

            int cantidad = dgvDatosDelPago.Rows.Count;

            for (int i = cantidad - 1; i >= 0; i--)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDatosDelPago.Rows[i].Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    _pagoDetalle.Remove((PagoDetalleDTO)dgvDatosDelPago.Rows[i].DataBoundItem);
                    haySeleccion = true;
                }
            }


            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Orden de Pago");
            }
            else
            {
                this.dgvDatosDelPago.DataSource = null;
                this.dgvDatosDelPago.DataSource = _pagoDetalle;
                this.dgvDatosDelPago.ClearSelection();
            }

            foreach (PagoDetalleDTO r in _pagoDetalle)
            {
                importePago += r.Importe;
            }

            txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(importePago, 2, MidpointRounding.AwayFromZero));
            calcularDirenciaDeImportes();
        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de Proveedor.";
            }
            else
            {
                int resultIndex = this.cbxCodProveedor.FindStringExact(cbxCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxNombreDelProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Nombre de Proveedor.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelProveedor.FindStringExact(cbxNombreDelProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de proveedor ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.txtNroOrdenDePago.Text == "")
            {
                rv = false;
                msg += "\nFalta cargar el número de Orden de Pago. Llame al administrador del sistema.";
            }

            if (_pagoDetalle.Count == 0)
            {
                rv = false;
                msg += "\nDebe ingresar los Datos del Pago.";
            }

            if (this.txtImporteTotal.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Importe Total.";
            }

            return rv;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("¿Desea registrar la Orden de Pago?", "Orden de Pago", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                string msg = String.Empty;

                if (validarNulidadDatosForm(ref msg))
                {
                    PagoDTO data = this.formToObject();
                    string cod_comprobante_pago = _pago.registrar(data);
                    bool existe_retencion = false;

                    foreach(PagoDetalleDTO pagoDetalle in data.List_pago_detalle)
                    {
                        if (pagoDetalle.Id_tipo_retencion != -1)
                        {
                            existe_retencion = true;
                        }
                    }

                    frmImpresionDeOrdenDePago imp = new frmImpresionDeOrdenDePago(cod_comprobante_pago, existe_retencion, true, cbxCodProveedor.Text, dtpFechaDelComprobante.Value.Date);
                    imp.ShowDialog();
                    imp.Dispose();

                    clearForm();
                    cargarGridFacturasDebitosImpagos();
                    habilitarDatosProveedor();
                    MessageBox.Show("La operación fue realizada con éxito.", "Orden de Pago");
                }
                else
                {
                    MessageBox.Show("No ha sido posible registrar la orden de pago. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Orden de Pago");
                }
            }
        }

        private PagoDTO formToObject()
        {
            PagoDTO rv = new PagoDTO();

            rv.Id_proveedor = this.cbxCodProveedor.Text;
            rv.Nombre_proveedor = this.cbxNombreDelProveedor.Text;
            rv.Cod_comprobante_factura = new List<FacturaDeCompraDTO>(_facturasAPagar);
            rv.Importe = decimal.Parse(this.txtImporteTotal.Text);
            rv.Importe = decimal.Round(rv.Importe, 2, MidpointRounding.AwayFromZero);
            rv.Nro_pago = this.txtNroOrdenDePago.Text;
            rv.List_pago_detalle = new List<PagoDetalleDTO>(_pagoDetalle);
            rv.Fecha_comprobante = dtpFechaDelComprobante.Value.Date;

            return rv;
        }

        private void btnMarcarPago_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea marcar como pagas las facturas o notas de débito seleccionadas?", "Orden de Pago", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool haySeleccion = false;
                int cantidad = dgvFacturasImpagas.Rows.Count;
                List<FacturaDeCompraDTO> facturasMarcadas = new List<FacturaDeCompraDTO>();

                for (int i = 0; i < cantidad; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        facturasMarcadas.Add(((FacturaDeCompraDTO)dgvFacturasImpagas.Rows[i].DataBoundItem));
                        haySeleccion = true;
                    }
                }

                if (!haySeleccion)
                {
                    MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Orden de Pago");
                }
                else
                {
                    PagoDTO.updateFacturasPagas(facturasMarcadas);
                    cargarGridFacturasDebitosImpagos();
                    _facturasAPagar.Clear();
                    this.dgvFacturas.DataSource = null;
                    this.dgvFacturas.DataSource = _facturasAPagar;
                }

                ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
            }
        }

        private void btnPagoParcial_Click(object sender, EventArgs e)
        {
            int cantidadSeleccionada = 0;
            int cantidad = dgvFacturasImpagas.Rows.Count;
            FacturaDeCompraDTO fcompra = new FacturaDeCompraDTO();

            if (txtImporteDePagoParcial.Text != string.Empty)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        fcompra = (FacturaDeCompraDTO)dgvFacturasImpagas.Rows[i].DataBoundItem;
                        fcompra.Importe_de_pago = decimal.Parse(txtImporteDePagoParcial.Text);
                        fcompra.V_importe_de_pago = String.Format("{0:C}", Math.Round(fcompra.Importe_de_pago, 2, MidpointRounding.AwayFromZero));
                        fcompra.Importe_pagado_acumulado = fcompra.Importe_pagado + fcompra.Importe_de_pago;
                        fcompra.Importe_adeudado_actualizado = fcompra.Total - fcompra.Importe_pagado_acumulado;                        
                        fcompra.Pago_parcial = 'S';
                        cantidadSeleccionada += 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un importe de pago.", "Orden de Pago");
                return;
            }

            if (cantidadSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Orden de Pago");
                return;
            }

            if (cantidadSeleccionada > 1)
            {
                MessageBox.Show("Debe seleccionar un único registro de la grilla.", "Orden de Pago");
                return;
            }

            if (cantidadSeleccionada == 1)
            {
                _facturasAPagar.Add(fcompra);

                for (int i = cantidad - 1; i >= 0; i--)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        _factura.GridDataListImpagas.Remove((FacturaDeCompraDTO)dgvFacturasImpagas.Rows[i].DataBoundItem);
                    }
                }

                decimal importe = decimal.Zero;
                decimal importeDePago = decimal.Zero;

                foreach (FacturaDeCompraDTO f in _facturasAPagar)
                {
                    importe += f.Total;
                    importeDePago += f.Importe_de_pago;
                }

                txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                txtImporteDePago.Text = String.Format("{0:0.00}", Math.Round(importeDePago, 2, MidpointRounding.AwayFromZero));

                this.dgvFacturas.DataSource = null;
                this.dgvFacturas.DataSource = _facturasAPagar;
                this.dgvFacturas.Font = txtImporteFacturas.Font;
                this.dgvFacturas.ClearSelection();

                this.dgvFacturasImpagas.DataSource = null;
                this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
                this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
                this.dgvFacturasImpagas.ClearSelection();

                txtImporteDePagoParcial.Text = string.Empty;
            }

            ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
            calcularDirenciaDeImportes();
        }

        private void btnReporteFacturasImpagas_Click(object sender, EventArgs e)
        {
            try
            {
                if (_factura.GridDataListImpagas.Count > 0)
                {
                    frmVerFacturasDeCompraImpagas frmReporte = new frmVerFacturasDeCompraImpagas();
                    crFacturasDeCompraImpagas rptLista = frmReporte.cargarReporte(cbxCodProveedor.Text, cbxNombreDelProveedor.Text, _cuenta.GridDataListProv[0].Saldo);
                    frmReporte.crvFacturasDeCompraImpagas.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }
                else
                {
                    MessageBox.Show("No hay datos suficientes para generar el reporte.", "Orden de Pago");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte de Facturas Impagas o con Pago Parcial");
            }
        }

    }
}

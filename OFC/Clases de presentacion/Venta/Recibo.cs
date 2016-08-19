using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//feb 1.8 (incluye cambios en la vista)
namespace OFC
{
    public partial class frmRecibo : Form
    {
        private Clientes _clientes;
        private Factura _factura;
        private ModalidadPago _mpago;
        private Recibo _recibo;
        private List<FacturaDTO> _facturasAPagar;
        private List<ReciboDetalleDTO> _reciboDetalle;
        private CuentaCorriente _cuenta;
        private FiltrosABMCliente _filtroClientes;
        private Retencion _retencion;
        decimal importe;
        string cod_comprobante_recibo; //feb 1.8

        public frmRecibo()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _factura = new Factura();
            _mpago = new ModalidadPago();
            _recibo = new Recibo();
            _facturasAPagar = new List<FacturaDTO>();
            _reciboDetalle = new List<ReciboDetalleDTO>();
            importe = decimal.Zero;
            _cuenta = new CuentaCorriente();
            _filtroClientes = new FiltrosABMCliente();
            _retencion = new Retencion();
            cod_comprobante_recibo = string.Empty; //feb 1.8
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFormularioRecibo();
            configurarGridFacturasImpagas();
            configurarGridFacturas();
            configurarGridDatosPago();
            cargarGridFacturasImpagas();
            setImportesEnCero();
            calcularDirenciaDeImportes(); //feb 1.8 fix
        }

        //feb 1.8 fix
        private void calcularDirenciaDeImportes()
        {
            decimal diferencia = decimal.Parse(txtImporteTotal.Text) - decimal.Parse(txtImporteFacturas.Text);
            lblDiferenciaDeImportes.Text = String.Format("{0:0.00}", Math.Round(diferencia, 2, MidpointRounding.AwayFromZero));
        }

        private void setImportesEnCero()
        {
            txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImportePago.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
        }

        private void FilterToObjectABM()
        {
            if (this.cbxCodCliente.Text != "")
            {
                _filtroClientes.FiltroCodigo = this.cbxCodCliente.Text;
            }
            else
            {
                _filtroClientes.FiltroCodigo = "XXXXXXXX";
            }

            if (this.cbxNombreDelCliente.Text != "")
            {
                _filtroClientes.FiltroNombre = this.cbxNombreDelCliente.Text;
            }
            else
            {
                _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            }
        }

        private void cargarFormularioRecibo()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;

            this.cbxModalidadDePago.DataSource = _mpago.OwnDataList;
            this.cbxModalidadDePago.DisplayMember = "valor";
            this.cbxModalidadDePago.ValueMember = "id";

            this.cbxTipoDeRetencion.DataSource = _retencion.OwnDataList;
            this.cbxTipoDeRetencion.DisplayMember = "valor";
            this.cbxTipoDeRetencion.ValueMember = "id";

        }

        private void cbxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxCodCliente.Text);
        }

        private void cbxNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodCliente.Text = _clientes.obtenerCodigo(this.cbxNombreDelCliente.Text);
        }

        //feb 1.8
        private void cbxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string msg = String.Empty;

                if (txtNroRecibo.Text != string.Empty)
                {
                    cod_comprobante_recibo = ComprobanteDTO.converToNroRecibo(txtNroRecibo.Text);
                }

                if (validarNroDeReciboYCliente(ref msg))
                {
                    validarNumeroRecibo(); //new
                    FilterToObjectABM();
                    cargarDatosCuenta();
                    cargarGridDebitosFacturasImpagas();
                    deshabilitarDatosCliente();
                    habilitarPanelIzqInferior();
                }
                else
                {
                    MessageBox.Show("No es posible validar el número de recibo y obtener las facturas impagas del cliente. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Recibo");
                }
            }
        }

        //feb 1.8
        private void deshabilitarDatosCliente()
        {
            txtNroRecibo.Enabled = false;
            cbxCodCliente.Enabled = false;
            cbxNombreDelCliente.Enabled = false;
            btnX.Enabled = false;
        }

        //feb 1.8
        private void habilitarDatosCliente()
        {
            txtNroRecibo.Enabled = true;
            cbxCodCliente.Enabled = true;
            cbxNombreDelCliente.Enabled = true;
            btnX.Enabled = true;
        }

        //feb 1.8
        private void deshabilitarPanelIzqInferior()
        {
            pnlIzquierdoInferior.Enabled = false;
        }

        //feb 1.8
        private void habilitarPanelIzqInferior()
        {
            pnlIzquierdoInferior.Enabled = true;
        }

        //feb 1.8
        private bool validarNroDeReciboYCliente(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxNombreDelCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Nombre de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelCliente.FindStringExact(cbxNombreDelCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.txtNroRecibo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de Recibo.";
            }
            else
            {
                if (!TalonarioDetalleDTO.existeInventario(cod_comprobante_recibo))
                {
                    rv = false;
                    msg += "\nEl número de recibo no fue cargado en el inventario.";
                }
            }

            return rv;

        }

        private void txtNroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Se aceptan teclas de control
            if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
            {
                // Se acepta la tecla, si el texto resultante es un número decimal
                Decimal aux = new Decimal();
                bool rv = Decimal.TryParse(this.txtNroRecibo.Text + e.KeyChar, out aux);
                e.Handled = (!rv);
            }

        }


        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la '.'
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

        private void cargarGridFacturasImpagas()
        {
            _factura.refreshGridDataImpagas(this.cbxCodCliente.Text);

            this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
            this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
            this.dgvFacturasImpagas.ClearSelection();
            ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        //feb 1.8
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
            _fechaColum.DataPropertyName = "v_fecha_creacion";
            _fechaColum.HeaderText = "Fecha";
            _fechaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaColum.Width = 130;
            _fechaColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _fechaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _tipoFactura = new DataGridViewTextBoxColumn();
            _tipoFactura.DataPropertyName = "tipo_comprobante";
            _tipoFactura.HeaderText = "TC";
            _tipoFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoFactura.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoFactura.Width = 105;
            _tipoFactura.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _tipoFactura.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "cod_comprobante";
            _codComprobanteColum.HeaderText = "Cód. Comprobante";
            _codComprobanteColum.Width = 170;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _codComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_total";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 150;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            this.dgvFacturasImpagas.Columns.Add(procesar);
            this.dgvFacturasImpagas.Columns.Add(_fechaColum);
            this.dgvFacturasImpagas.Columns.Add(_tipoFactura);
            this.dgvFacturasImpagas.Columns.Add(_codComprobanteColum);
            this.dgvFacturasImpagas.Columns.Add(_impTotalColum);
            show_chkBox();

        }

        //feb 1.8
        private void configurarGridFacturas()
        {
            this.dgvFacturas.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewTextBoxColumn _tipoFactura = new DataGridViewTextBoxColumn();
            _tipoFactura.DataPropertyName = "tipo_comprobante";
            _tipoFactura.HeaderText = "TC";
            _tipoFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoFactura.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoFactura.Width = 60;
            _tipoFactura.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _tipoFactura.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobanteColum = new DataGridViewTextBoxColumn();
            _codComprobanteColum.DataPropertyName = "cod_comprobante";
            _codComprobanteColum.HeaderText = "Cód. Comprobante";
            _codComprobanteColum.Width = 194;
            _codComprobanteColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobanteColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _codComprobanteColum.ReadOnly = true;

            DataGridViewTextBoxColumn _impTotalColum = new DataGridViewTextBoxColumn();
            _impTotalColum.DataPropertyName = "v_total";
            _impTotalColum.HeaderText = "Importe";
            _impTotalColum.Width = 154;
            _impTotalColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _impTotalColum.HeaderCell.Style.Font = this.txtImporteFacturas.Font;
            _impTotalColum.ReadOnly = true;

            this.dgvFacturas.Columns.Add(procesar);
            this.dgvFacturas.Columns.Add(_tipoFactura);
            this.dgvFacturas.Columns.Add(_codComprobanteColum);
            this.dgvFacturas.Columns.Add(_impTotalColum);
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

        private bool validarNulidadDatosClie(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxNombreDelCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Nombre de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelCliente.FindStringExact(cbxNombreDelCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;

        }



        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxNombreDelCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Nombre de Cliente.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelCliente.FindStringExact(cbxNombreDelCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.txtNroRecibo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de Recibo.";
            }

            if (_reciboDetalle.Count == 0)
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

        //feb 1.8
        private void btnX_Click(object sender, EventArgs e)
        {
            string msg = String.Empty;

            if (txtNroRecibo.Text != string.Empty)
            {
                cod_comprobante_recibo = ComprobanteDTO.converToNroRecibo(txtNroRecibo.Text);
            }

            if (validarNroDeReciboYCliente(ref msg))
            {
                validarNumeroRecibo(); //new
                FilterToObjectABM();
                cargarDatosCuenta();
                cargarGridDebitosFacturasImpagas();
                deshabilitarDatosCliente();
                habilitarPanelIzqInferior();
            }
            else
            {
                MessageBox.Show("No es posible validar el número de recibo y obtener las facturas impagas del cliente. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Recibo");
            }
        }

        //feb 1.8
        private void validarNumeroRecibo()
        {
            lbxValidacionesDelRecibo.DataSource = _recibo.ejecutarValidacionDeInventario(txtNroRecibo.Text);
            lblNroDeTalonario.Text = "Nro. de Talonario: " + TalonarioDetalleDTO.getTalonario(cod_comprobante_recibo);
        }

        private void cargarDatosCuenta()
        {

            if (_filtroClientes.FiltroCodigo != "")
            {
                _cuenta.refreshGridData(_filtroClientes);

                if (_cuenta.GridDataList.Count == 1)
                {
                    this.lblSaldoDeudor.Text = "Saldo Cuenta Corriente: " + _cuenta.GridDataList[0].V_saldo.ToString();
                }
                else
                {
                    this.lblSaldoDeudor.Text = "";
                }
            }

        }

        //feb 1.8
        private void clearForm()
        {
            this.txtNroRecibo.Text = String.Empty;
            this.cbxCodCliente.Text = "";
            _facturasAPagar.Clear();
            this.dgvFacturas.DataSource = null;
            this.dgvFacturas.DataSource = _facturasAPagar;
            this.cbxModalidadDePago.SelectedIndex = 0;
            this.cbxTipoDeRetencion.SelectedIndex = 0;
            this.txtDetalle.Text = String.Empty;
            _reciboDetalle.Clear();
            this.dgvDatosDelPago.DataSource = null;
            this.dgvDatosDelPago.DataSource = _reciboDetalle;
            lblSaldoDeudor.Text = "";
            deshabilitarPanelIzqInferior();
            lbxValidacionesDelRecibo.DataSource = null;
            lblNroDeTalonario.Text = "Nro. de Talonario:";
            setImportesEnCero();
        }

        private ReciboDTO formToObject()
        {
            ReciboDTO rv = new ReciboDTO();

            rv.Id_cliente = this.cbxCodCliente.Text;
            rv.Nombre_cliente = this.cbxNombreDelCliente.Text;
            rv.Cod_comprobante_factura = new List<FacturaDTO>(_facturasAPagar);
            rv.Importe = decimal.Parse(this.txtImporteTotal.Text);
            rv.Importe = decimal.Round(rv.Importe, 2, MidpointRounding.AwayFromZero);
            rv.Nro_recibo = this.txtNroRecibo.Text;
            rv.List_recibo_detalle = new List<ReciboDetalleDTO>(_reciboDetalle);

            return rv;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("¿Desea registrar el recibo de pago?", "Recibo", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                string msg = String.Empty;

                if (validarNulidadDatosForm(ref msg))
                {
                    ReciboDTO data = this.formToObject();

                    if (_recibo.isValid(data, ref msg))
                    {
                        bool ok = false;

                        _recibo.registrar(data);

                        ok = true;

                        if (ok)
                        {
                            clearForm();
                            cargarGridFacturasImpagas();
                            habilitarDatosCliente();
                            MessageBox.Show("La operación fue realizada con éxito.", "Recibo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible registrar el recibo de pago. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Recibo");
                    }

                }
                else
                {
                    MessageBox.Show("No ha sido posible registrar el recibo de pago. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Recibo");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            bool haySeleccion = false;

            int cantidad = dgvFacturasImpagas.Rows.Count;

            for (int i = 0; i < cantidad; i++)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    _facturasAPagar.Add((FacturaDTO)dgvFacturasImpagas.Rows[i].DataBoundItem);
                    haySeleccion = true;
                }
            }


            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Recibo");
            }
            else
            {
                for (int i = cantidad - 1; i >= 0; i--)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        _factura.GridDataListImpagas.Remove((FacturaDTO)dgvFacturasImpagas.Rows[i].DataBoundItem);
                    }
                }

                importe = decimal.Zero;

                foreach (FacturaDTO f in _facturasAPagar)
                {
                    importe += f.Total;
                }

                txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));

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

            calcularDirenciaDeImportes(); //feb 1.8 fix

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
                    _factura.GridDataListImpagas.Add((FacturaDTO)dgvFacturas.Rows[i].DataBoundItem);
                    _factura.GridDataListImpagas = _factura.GridDataListImpagas.OrderBy(o => o.Fecha_creacion).ToList();
                    haySeleccion = true;
                }
            }


            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Recibo");
            }
            else
            {
                for (int i = cantidad - 1; i >= 0; i--)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        _facturasAPagar.Remove((FacturaDTO)dgvFacturas.Rows[i].DataBoundItem);
                    }
                }

                importe = decimal.Zero;

                foreach (FacturaDTO f in _facturasAPagar)
                {
                    importe += f.Total;
                }

                txtImporteFacturas.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));

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
            calcularDirenciaDeImportes(); //feb 1.8 fix
        }

        private void btnMarcarPago_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea marcar como pagas las facturas seleccionadas?", "Recibo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool haySeleccion = false;
                int cantidad = dgvFacturasImpagas.Rows.Count;
                List<FacturaDTO> facturasMarcadas = new List<FacturaDTO>();

                for (int i = 0; i < cantidad; i++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFacturasImpagas.Rows[i].Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        facturasMarcadas.Add(((FacturaDTO)dgvFacturasImpagas.Rows[i].DataBoundItem));
                        haySeleccion = true;
                    }
                }


                if (!haySeleccion)
                {
                    MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Recibo");
                }
                else
                {
                    ReciboDTO.updateFacturasPagas(facturasMarcadas);
                    cargarGridFacturasImpagas();
                    _facturasAPagar.Clear();
                    this.dgvFacturas.DataSource = null;
                    this.dgvFacturas.DataSource = _facturasAPagar;
                }

                ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            //validar nulidad
                string msg = String.Empty;

                if (validarNulidadDatosPago(ref msg))
                {
                    decimal importePago = decimal.Zero;

                    ReciboDetalleDTO det = new ReciboDetalleDTO();
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

                    _reciboDetalle.Add(det);

                    this.dgvDatosDelPago.DataSource = null;
                    this.dgvDatosDelPago.DataSource = _reciboDetalle;
                    this.dgvDatosDelPago.ClearSelection();

                    foreach (ReciboDetalleDTO r in _reciboDetalle)
                    {
                        importePago += r.Importe;
                    }

                    txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(importePago, 2, MidpointRounding.AwayFromZero));
                    cbxModalidadDePago.Text = "";
                    txtDetalle.Text = "";
                    cbxTipoDeRetencion.Text = "";
                    txtImportePago.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
                    calcularDirenciaDeImportes(); //feb 1.8 fix
                }
                else
                {
                    MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Recibo");
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
                    _reciboDetalle.Remove((ReciboDetalleDTO)dgvDatosDelPago.Rows[i].DataBoundItem);
                    haySeleccion = true;
                }
            }


            if (!haySeleccion)
            {
                MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Recibo");
            }
            else
            {
                this.dgvDatosDelPago.DataSource = null;
                this.dgvDatosDelPago.DataSource = _reciboDetalle;
                this.dgvDatosDelPago.ClearSelection();
            }

            foreach (ReciboDetalleDTO r in _reciboDetalle)
            {
                importePago += r.Importe;
            }

            txtImporteTotal.Text = String.Format("{0:0.00}", Math.Round(importePago, 2, MidpointRounding.AwayFromZero));
            calcularDirenciaDeImportes(); //feb 1.8 fix

        }

        //feb 1.8
        private void btnLimpiarVista_Click(object sender, EventArgs e)
        {
            clearForm();
            cargarGridDebitosFacturasImpagas();
            habilitarDatosCliente();
            deshabilitarPanelIzqInferior();
            lbxValidacionesDelRecibo.DataSource = null;
            lblNroDeTalonario.Text = "Nro. de Talonario:";
            calcularDirenciaDeImportes(); //feb 1.8 fix
        }

        //feb 1.8
        private void cargarGridDebitosFacturasImpagas()
        {
            _factura.refreshGridDataImpagas(this.cbxCodCliente.Text);

            this.dgvFacturasImpagas.DataSource = _factura.GridDataListImpagas;
            this.dgvFacturasImpagas.Font = txtImporteFacturas.Font;
            this.dgvFacturasImpagas.ClearSelection();
            ((CheckBox)dgvFacturasImpagas.Controls.Find("checkboxHeader", true)[0]).Checked = false;

        }

    }
}

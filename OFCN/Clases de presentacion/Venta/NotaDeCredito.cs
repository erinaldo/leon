using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//feb 1.8
//cambio en el label nro. de factura

namespace OFC
{
    public partial class frmNotaDeCredito : Form
    {

        private Clientes _clientes;
        private MotivoCredito _motivoCredito;
        private NotaCredito _nota_credito;

        public frmNotaDeCredito()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _motivoCredito = new MotivoCredito();
            _nota_credito = new NotaCredito();
            
        }

        private void frmNotaDeCredito_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarDatosForm();
            configurarGridDetalleCredito();
            cargarSolapaNotaCredito();

            if (_nota_credito.GridDataList.Count > 0) //si hay nc
            {
                habilitarFacturacion();
                deshabilitarDatosCliente();
                deshabilitarDatosItem();
            }
            else
            {
                deshabilitarFacturacion();
                deshabilitarDatosItem();
            }
        }


        private void txtNroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
                e.Handled = false;
            else
            {
                // Se aceptan teclas de control
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                {
                    // Se acepta la tecla, si el texto resultante es un número decimal
                    Decimal aux = new Decimal();
                    bool rv = Decimal.TryParse(e.KeyChar.ToString(), out aux);
                    e.Handled = (!rv);
                }
            }

        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta la coma ya que el separador de decimales es la '.'
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

        private void cargarDatosForm()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxCodCliente.DataSource = _clientes.CodDataList;

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;

            this.cbxMotivo.DataSource = _motivoCredito.OwnDataList;
            this.cbxMotivo.DisplayMember = "valor";
            this.cbxMotivo.ValueMember = "id";

            txtImporte.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
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
        private void btnX_Click(object sender, EventArgs e)
        {

            string msg = string.Empty;

            if (validarDatosCliente(ref msg))
            {
                txtImporte.Text = String.Format("{0:0.00}", Math.Round(FacturaDTO.calcularImporte(txtNroFactura.Text), 2, MidpointRounding.AwayFromZero));

                //char condicionIva = ClienteDTO.obtenerCondicionIva(cbxCodCliente.Text);

                //if (condicionIva == 'A')
                //{
                //    txtImporte.Text = String.Format("{0:0.00}", Math.Round(FacturaDTO.calcularImporteFacturaA(txtNroFactura.Text), 2, MidpointRounding.AwayFromZero));
                //}
                //if (condicionIva == 'B')
                //{
                //    txtImporte.Text = String.Format("{0:0.00}", Math.Round(FacturaDTO.calcularImporteFacturaB(txtNroFactura.Text), 2, MidpointRounding.AwayFromZero));
                //}

                if (decimal.Parse(txtImporte.Text) == 0)
                {
                    MessageBox.Show("La factura no corresponde o está anulada. Por favor verifique los datos ingresados.", "Nota de Crédito");
                }
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Crédito");
            }

        }


        private bool validarDatosCliente(ref string msg)
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

        private void cargarSolapaNotaCredito()
        {
            _nota_credito.refreshGridData();

            if (_nota_credito.GridDataList.Count > 0) //si hay datos
            {
                foreach (NotaCreditoDTO row in _nota_credito.GridDataList)
                {
                    this.objectToForm(row);

                    _nota_credito.refreshGridDataDetalle(row.Id);
                    this.dgvNotasDeCredito.DataSource = _nota_credito.GridDataListDetalle;
                    this.dgvNotasDeCredito.Font = txtImporte.Font;
                    this.dgvNotasDeCredito.ClearSelection();
                }
            }

        }


        private void configurarGridDetalleCredito()
        {
            this.dgvNotasDeCredito.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 40;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo"; //id_producto + A + id_servicio
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 45;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion"; //medida de la cubierta y servicio
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 367;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precioUnitario = new DataGridViewTextBoxColumn();
            _precioUnitario.DataPropertyName = "v_precio_unitario";
            _precioUnitario.HeaderText = "Precio Unitario";
            _precioUnitario.Width = 88;
            _precioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 88;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvNotasDeCredito.Columns.Add(_cantidad);
            this.dgvNotasDeCredito.Columns.Add(_codigo);
            this.dgvNotasDeCredito.Columns.Add(_descripcion);
            this.dgvNotasDeCredito.Columns.Add(_precioUnitario);
            this.dgvNotasDeCredito.Columns.Add(_importe);

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
                try
                {
                    string msg = "";

                    if (validarNulidadDatosForm(ref msg))
                    {
                        if (!NotaCreditoDTO.existeCreditoTemp(cbxCodCliente.Text))
                        {
                            _nota_credito.generar(formToObject());
                        }
                        _nota_credito.generar(formToObjectDet());
                        _nota_credito.completarDatosPendientes();
                        cargarSolapaNotaCredito();
                        clearForm();
                        //deshabilitarDatosItem();
                    }
                    else
                    {
                        MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Crédito");
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Nota de Crédito");
                }

        }


        private void clearForm()
        {
            //this.cbxCodCliente.SelectedIndex = 0;
            this.txtNroFactura.Text = String.Empty;
            txtImporte.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            this.cbxMotivo.SelectedIndex = 0;
            this.txtDetalle.Text = "";
        }

        //feb 1.8
        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;
            bool clienteOk = false;

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
                else
                {
                    clienteOk = true;
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

            if (clienteOk && txtNroFactura.Text != "")
            {
                char condicionIva = ClienteDTO.obtenerCondicionIva(cbxCodCliente.Text);

                if (condicionIva == 'A' && !ComprobanteDTO.existeFacturaDebitoA(txtNroFactura.Text))
                {
                    rv = false;
                    msg += "\nNo corresponde el número de factura o nota de debito ingresada según la condición de iva del cliente.";
                }
                if (condicionIva == 'B' && !ComprobanteDTO.existeFacturaDebitoB(txtNroFactura.Text))
                {
                    rv = false;
                    msg += "\nNo corresponde el número de factura o nota de debito ingresada según la condición de iva del cliente.";
                }
            }

            if (this.cbxMotivo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Motivo.";
            }
            else
            {
                int resultIndex = this.cbxMotivo.FindStringExact(cbxMotivo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl motivo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.txtImporte.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Importe.";
            }


            return rv;
        }

        private NotaCreditoDTO formToObject()
        {

            NotaCreditoDTO actual = new NotaCreditoDTO();

            actual.Id_cliente = cbxCodCliente.Text;
            actual.Nombre_cliente = cbxNombreDelCliente.Text;
            return actual;

        }

        private List<NotaCreditoDetalleDTO> formToObjectDet()
        {
            List<NotaCreditoDetalleDTO> listaDetalle = new List<NotaCreditoDetalleDTO>();

            NotaCreditoDetalleDTO detalle = new NotaCreditoDetalleDTO();

            detalle.Id_cliente = cbxCodCliente.Text;
            detalle.Motivo = cbxMotivo.Text;
            detalle.Precio_unitario = decimal.Parse(txtImporte.Text);
            detalle.Importe = decimal.Parse(txtImporte.Text);
            if (txtNroFactura.Text != "")
            {
                detalle.Descripcion = cbxMotivo.Text + " - FACT. " + txtNroFactura.Text + " " + txtDetalle.Text;
                detalle.Cod_comprobante_factura = txtNroFactura.Text;
            }
            else
            {
                detalle.Descripcion = cbxMotivo.Text + " " + txtDetalle.Text;
                detalle.Cod_comprobante_factura = string.Empty;
            }
            
            listaDetalle.Add(detalle);

            return listaDetalle;
        }

        private void objectToForm(NotaCreditoDTO data)
        {
            if (data.Nro_nota_credito.ToString() != "-1")
            {
                this.tbpNroNotaDeCredito.Text = data.Nro_nota_credito.ToString();
                this.txtNroNotaDeCredito.Text = data.Nro_nota_credito.ToString();
                this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura.Text = data.Tipo_nota_credito.ToString();

            }
            else
            {
                this.tbpNroNotaDeCredito.Text = "F1";
                this.txtNroNotaDeCredito.Text = "";
                this.lblDatosDelCliente.Text = "";
                this.lblTipoFactura.Text = "";
                _nota_credito.refreshGridDataDetalle(data.Id);
                this.dgvNotasDeCredito.DataSource = _nota_credito.GridDataListDetalle;
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

        private void btnXCliente_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (validarDatosCliente(ref msg))
            {
                habilidarDatosItem();
                deshabilitarDatosCliente();
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Crédito");
            }
        }

        private void habilidarDatosItem()
        {
            txtNroFactura.Enabled = true;
            txtImporte.Enabled = true;
            btnX.Enabled = true;
            cbxMotivo.Enabled = true;
            txtDetalle.Enabled = true;
            btnProcesar.Enabled = true;
        }

        private void deshabilitarDatosItem()
        {
            txtNroFactura.Enabled = false;
            txtImporte.Enabled = false;
            btnX.Enabled = false;
            cbxMotivo.Enabled = false;
            txtDetalle.Enabled = false;
            btnProcesar.Enabled = false;
        }

        private void deshabilitarDatosCliente()
        {
            cbxCodCliente.Enabled = false;
            cbxNombreDelCliente.Enabled = false;
            btnXCliente.Enabled = false;
        }

        private void habilitarDatosCliente()
        {
            cbxCodCliente.Enabled = true;
            cbxNombreDelCliente.Enabled = true;
            btnXCliente.Enabled = true;
        }

        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if (_nota_credito.GridDataList.Count >= 1 && lblVistaPreliminar.Text != "Vista Definitiva")
            {
                //DialogResult dialogResult = MessageBox.Show("¿Desea cambiar a vista definitiva de nota de crédito? Tenga en cuenta que ya no podrá modificar o borrar la nota de crédito pendiente.", "Nota de Crédito", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                habilitarFacturacion();
                //}
            }
        }

        private void habilitarFacturacion()
        {
            btnImprimir.Enabled = true;
            btnVistaPreliminar.Enabled = true;
            btnCambiarFactura.Enabled = true;
            btnRegistrar.Enabled = true;
            btnBorrar.Enabled = false;
            pnlIzquierda.Enabled = false;
            lblVistaPreliminar.Text = "Vista Definitiva";
        }

        private void deshabilitarFacturacion()
        {
            btnImprimir.Enabled = false;
            btnVistaPreliminar.Enabled = false;
            btnCambiarFactura.Enabled = false;
            btnRegistrar.Enabled = false;
            btnBorrar.Enabled = true;
            pnlIzquierda.Enabled = true;
            lblVistaPreliminar.Text = "Vista Preliminar";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar la nota de crédito pendiente de registrar?", "Nota de Crédito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_nota_credito.GridDataList.Count != 0)
                    {
                        _nota_credito.delete();
                        cargarSolapaNotaCredito();
                        objectToForm(new NotaCreditoDTO());
                        deshabilitarDatosItem();
                        habilitarDatosCliente();

                        //MessageBox.Show("La operación fue realizada con éxito.", "Nota de Crédito");
                    }
                    else
                    {
                        MessageBox.Show("No existe nota de crédito pendiente por borrar.", "Nota de Crédito");
                    }

                }


            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Borrar nota de crédito pendiente");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea registrar la nota de crédito?", "Nota de Crédito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _nota_credito.refreshGridData();

                    if (_nota_credito.GridDataList.Count != 0)
                    {
                        _nota_credito.registrar((List<NotaCreditoDTO>)_nota_credito.GridDataList, (List<NotaCreditoDetalleDTO>)dgvNotasDeCredito.DataSource);
                        cargarSolapaNotaCredito();
                        objectToForm(new NotaCreditoDTO());
                        deshabilitarFacturacion();
                        deshabilitarDatosItem();
                        habilitarDatosCliente();

                        MessageBox.Show("La operación fue realizada con éxito.", "Nota de Crédito");
                    }
                    else
                    {
                        MessageBox.Show("No existe nota de crédito pendiente por registrar.", "Nota de Crédito");
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Registrar Nota de Crédito");
            }
        }

        private void btnCambiarFactura_Click(object sender, EventArgs e)
        {
            if (_nota_credito.GridDataList.Count >= 1)
            {
                registrarAnularGenerar(0);
            }
        }

        private void registrarAnularGenerar(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular la nota de crédito actual y generar una nueva?", "Nota de Crédito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    _nota_credito.registrarAnularCredito(_nota_credito.GridDataList[posicion]);
                    cargarSolapaNotaCredito();

                    //MessageBox.Show("La operación fue realizada con éxito.", "Nota de Crédito");
                }

            }

            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Anular y Generar Nota de Crédito");
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                formProcesamiento.Show();

                if (_nota_credito.GridDataList[0].Tipo_nota_credito == 'A')
                {
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteCredito(_nota_credito.GridDataList[0].Id);
                    rptLista.PrintToPrinter(1, false, 1, 1);
                    rptLista.Dispose();
                }
                if (_nota_credito.GridDataList[0].Tipo_nota_credito == 'B')
                {
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteCredito(_nota_credito.GridDataList[0].Id);
                    rptLista.PrintToPrinter(1, false, 1, 1);
                    rptLista.Dispose();
                }

                formProcesamiento.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Comprobante Digital");
            }
        }

        private void btnVistaPreliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_nota_credito.GridDataList[0].Tipo_nota_credito == 'A')
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteCredito(_nota_credito.GridDataList[0].Id);
                    frmReporte.crvFacturaA.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }
                if (_nota_credito.GridDataList[0].Tipo_nota_credito == 'B')
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteCredito(_nota_credito.GridDataList[0].Id);
                    frmReporte.crvFacturaB.ReportSource = rptLista;
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

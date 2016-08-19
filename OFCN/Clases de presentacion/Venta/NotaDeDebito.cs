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
    public partial class frmNotaDeDebito : Form
    {
        private Clientes _clientes;
        private MotivoDebito _motivoDebito;
        private NotaDebito _nota_debito;

        public frmNotaDeDebito()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _motivoDebito = new MotivoDebito();
            _nota_debito = new NotaDebito();
        }

        private void configurarGridDetalleDebito()
        {
            this.dgvNotasDeDebito.AutoGenerateColumns = false;

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

            this.dgvNotasDeDebito.Columns.Add(_cantidad);
            this.dgvNotasDeDebito.Columns.Add(_codigo);
            this.dgvNotasDeDebito.Columns.Add(_descripcion);
            this.dgvNotasDeDebito.Columns.Add(_precioUnitario);
            this.dgvNotasDeDebito.Columns.Add(_importe);

        }

        private void frmNotaDeDebito_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarDatosForm();
            configurarGridDetalleDebito();
            cargarSolapaNotaDebito();

            if (_nota_debito.GridDataList.Count > 0) //si hay nd
            {
                habilitarFacturacion();
                deshabilitarDatosCliente();
                deshabilitarDatosItemExento();
                deshabilitarDatosItemGravado();
                deshabilitarDatosItem();
            }
            else
            {
                deshabilitarFacturacion();
                deshabilitarDatosItemExento();
                deshabilitarDatosItemGravado();
                deshabilitarDatosItem();
            }

        }

        private void txtImporteExento_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteExento.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteGravado_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteGravado.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
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

        private void cargarDatosForm()
        {
            this.cbxCodCliente.DataSource = _clientes.CodDataList;

            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;

            this.cbxMotivoDeGasto.DataSource = _motivoDebito.OwnDataList;
            this.cbxMotivoDeGasto.DisplayMember = "valor";
            this.cbxMotivoDeGasto.ValueMember = "id";

        }


        private void cbxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxCodCliente.Text);
        }

        private void cbxNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodCliente.Text = _clientes.obtenerCodigo(this.cbxNombreDelCliente.Text);
        }

        private void habilitarDatosItemGravado()
        {
            pnlGravado.Enabled = true;
        }

        private void habilitarDatosItemExento()
        {
            pnlExento.Enabled = true;
        }

        private void deshabilitarDatosItemExento()
        {
            pnlExento.Enabled = false;
            txtDescripcionExento.Text = "";
            txtBanco.Text = "";
            txtNroDeCheque.Text = "";
            txtFechaDeCheque.Text = "";
            txtImporteExento.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
        }

        private void deshabilitarDatosItem()
        {
            rdbExento.Enabled = false;
            rdbGravado.Enabled = false;
            btnProcesar.Enabled = false;
        }

        private void habilitarDatosItem()
        {
            rdbExento.Enabled = true;
            rdbGravado.Enabled = true;
            btnProcesar.Enabled = true;
        }

        private void deshabilitarDatosItemGravado()
        {
            pnlGravado.Enabled = false;
            cbxMotivoDeGasto.Text = "";
            txtImporteGravado.Text = String.Format("{0:0.00}", Math.Round(decimal.Zero, 2, MidpointRounding.AwayFromZero));
            txtDescripcionGravado.Text = "";

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

        private void btnXCliente_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (validarDatosCliente(ref msg))
            {
                habilitarDatosItem();
                habilitarDatosItemExento();
                deshabilitarDatosItemGravado();
                deshabilitarDatosCliente();
                txtDescripcionExento.Focus();
            }
            else
            {
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito");
            }        
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

            if (this.rdbExento.Checked)
            {
                if (this.txtDescripcionExento.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar la Descripción.";
                }

                if (this.txtImporteExento.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el Importe.";
                }
            }

            if (this.rdbGravado.Checked)
            {
                if (this.cbxMotivoDeGasto.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el Motivo.";
                }
                else
                {
                    int resultIndex = this.cbxMotivoDeGasto.FindStringExact(cbxMotivoDeGasto.Text);
                    if (resultIndex == -1)
                    {
                        rv = false;
                        msg += "\nEl motivo ingresado es incorrecto. Seleccione uno de la lista.";
                    }
                }

                if (this.txtImporteGravado.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el Importe.";
                }

            }




            return rv;
        }

        private void cargarSolapaNotaDebito()
        {
            _nota_debito.refreshGridData();

            if (_nota_debito.GridDataList.Count > 0) //si hay datos
            {
                foreach (NotaDebitoDTO row in _nota_debito.GridDataList)
                {
                    this.objectToForm(row);

                    _nota_debito.refreshGridDataDetalle(row.Id);
                    this.dgvNotasDeDebito.DataSource = _nota_debito.GridDataListDetalle;
                    this.dgvNotasDeDebito.Font = txtImporteGravado.Font;
                    this.dgvNotasDeDebito.ClearSelection();
                }
            }

        }

        private void objectToForm(NotaDebitoDTO data)
        {
            if (data.Nro_nota_debito.ToString() != "-1")
            {
                this.tbpNroNotaDeDebito.Text = data.Nro_nota_debito.ToString();
                this.txtNroNotaDeDebito.Text = data.Nro_nota_debito.ToString();
                this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura.Text = data.Tipo_nota_debito.ToString();
            }
            else
            {
                this.tbpNroNotaDeDebito.Text = "F1";
                this.txtNroNotaDeDebito.Text = "";
                this.lblDatosDelCliente.Text = "";
                this.lblTipoFactura.Text = "";
                _nota_debito.refreshGridDataDetalle(data.Id);
                this.dgvNotasDeDebito.DataSource = _nota_debito.GridDataListDetalle;
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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("¿Desea generar la nota de débito?", "Nota de Débito", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                try
                {
                    string msg = "";

                    if (validarNulidadDatosForm(ref msg))
                    {
                        if (!NotaDebitoDTO.existeDebitoTemp(cbxCodCliente.Text))
                        {
                            _nota_debito.generar(formToObject());
                        }
                        _nota_debito.generar(formToObjectDet());
                        _nota_debito.completarDatosPendientes();
                        cargarSolapaNotaDebito();
                        clearForm();
                    }
                    else
                    {
                        MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito");
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Nota de Débito");
                }
            //}
        }

        private void clearForm()
        {
            deshabilitarDatosItemGravado();
            deshabilitarDatosItemExento();
            habilitarDatosItemExento();
            rdbExento.Checked = true;
            
        }

        private NotaDebitoDTO formToObject()
        {

            NotaDebitoDTO actual = new NotaDebitoDTO();

            actual.Id_cliente = cbxCodCliente.Text;
            actual.Nombre_cliente = cbxNombreDelCliente.Text;
            return actual;

        }

        private NotaDebitoDetalleDTO formToObjectDet()
        {
            NotaDebitoDetalleDTO detalle = new NotaDebitoDetalleDTO();

            if (rdbExento.Checked)
            {
                detalle.Id_cliente = cbxCodCliente.Text;
                detalle.Descripcion = txtDescripcionExento.Text;
                if (txtBanco.Text != "")
                    detalle.Descripcion += " BCO: " + txtBanco.Text;
                if (txtNroDeCheque.Text != "")
                    detalle.Descripcion += " NRO: " + txtNroDeCheque.Text;
                if (txtFechaDeCheque.Text != "")
                    detalle.Descripcion += " FCH: " + txtFechaDeCheque.Text;
                detalle.Precio_unitario = decimal.Parse(txtImporteExento.Text);
                detalle.Importe = decimal.Parse(txtImporteExento.Text);
                detalle.Es_item_exento = 'S';
            }

            if (rdbGravado.Checked)
            {
                detalle.Id_cliente = cbxCodCliente.Text;
                detalle.Motivo = cbxMotivoDeGasto.Text;
                detalle.Descripcion = cbxMotivoDeGasto.Text;
                if (txtDescripcionGravado.Text != "")
                    detalle.Descripcion += " " + txtDescripcionGravado.Text;
                detalle.Precio_unitario = decimal.Parse(txtImporteGravado.Text);
                detalle.Importe = decimal.Parse(txtImporteGravado.Text);
                detalle.Es_item_exento = 'N';
            }

           return detalle;
        }

        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if (_nota_debito.GridDataList.Count >= 1 && lblVistaPreliminar.Text != "Vista Definitiva")
            {
                habilitarFacturacion();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar la nota de débito?", "Nota de Débito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _nota_debito.refreshGridData();

                    if (_nota_debito.GridDataList.Count != 0)
                    {
                        _nota_debito.registrar((List<NotaDebitoDTO>)_nota_debito.GridDataList);

                        cargarSolapaNotaDebito();
                        objectToForm(new NotaDebitoDTO());
                        deshabilitarFacturacion();
                        deshabilitarDatosItem();
                        deshabilitarDatosItemExento();
                        deshabilitarDatosItemGravado();
                        habilitarDatosCliente();

                        MessageBox.Show("La operación fue realizada con éxito.", "Nota de Débito");
                    }
                    else
                    {
                        MessageBox.Show("No existe nota de débito pendiente por registrar.", "Nota de Débito");
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar la nota de débito pendiente de registrar?", "Nota de Débito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_nota_debito.GridDataList.Count != 0)
                    {
                        _nota_debito.delete();
                        cargarSolapaNotaDebito();
                        objectToForm(new NotaDebitoDTO());
                        deshabilitarDatosItem();
                        deshabilitarDatosItemExento();
                        deshabilitarDatosItemGravado();
                        habilitarDatosCliente();

                        //MessageBox.Show("La operación fue realizada con éxito.", "Nota de Débito");
                    }
                    else
                    {
                        MessageBox.Show("No existe nota de débito pendiente por borrar.", "Nota de Débito");
                    }

                }


            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Borrar nota de débito pendiente");
            }
        }

        private void btnCambiarFactura_Click(object sender, EventArgs e)
        {
            if (_nota_debito.GridDataList.Count >= 1)
            {
                registrarAnularGenerar(0);
            }
        }

        private void registrarAnularGenerar(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular la nota de débito actual y generar una nueva?", "Nota de Débito", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    _nota_debito.registrarAnularDebito(_nota_debito.GridDataList[posicion]);
                    cargarSolapaNotaDebito();

                    //MessageBox.Show("La operación fue realizada con éxito.", "Nota de Débito");
                }

            }

            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Anular y Generar Nota de Débito");
            }

        }

        private void rdbExento_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDatosItemExento();
            deshabilitarDatosItemGravado();
            txtDescripcionExento.Focus();
        }

        private void rdbGravado_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDatosItemGravado();
            deshabilitarDatosItemExento();
            cbxMotivoDeGasto.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                formProcesamiento.Show();

                if (_nota_debito.GridDataList[0].Tipo_nota_debito == 'A')
                {
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteDebito(_nota_debito.GridDataList[0].Id);
                    rptLista.PrintToPrinter(1, false, 1, 1);
                    rptLista.Dispose();
                }
                if (_nota_debito.GridDataList[0].Tipo_nota_debito == 'B')
                {
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteDebito(_nota_debito.GridDataList[0].Id);
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
                if (_nota_debito.GridDataList[0].Tipo_nota_debito == 'A')
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporteDebito(_nota_debito.GridDataList[0].Id);
                    frmReporte.crvFacturaA.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }
                if (_nota_debito.GridDataList[0].Tipo_nota_debito == 'B')
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporteDebito(_nota_debito.GridDataList[0].Id);
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

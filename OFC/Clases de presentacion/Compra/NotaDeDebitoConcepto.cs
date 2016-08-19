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
    public partial class frmNotaDeDebitoConcepto : Form
    {
        private Proveedores _proveedores;
        private Conceptos _conceptos;
        private IvaCompras _iva;
        private ImpuestosCompras _impuestos;
        List<NotaDeDebitoCompDetalleDTO> _ndDetalle;
        List<ImpuestoDetalleDTO> _impuestoDetalle;
        List<IvaComprasDetalleDTO> _ivaDetalle;
        NotaDeDebitoDeCompra _ndDeConceptos;
        List<ComprobanteRelacionDTO> _comprobanteRelacion;

        public frmNotaDeDebitoConcepto()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _conceptos = new Conceptos();
            _iva = new IvaCompras();
            _impuestos = new ImpuestosCompras();
            _ndDetalle = new List<NotaDeDebitoCompDetalleDTO>();
            _impuestoDetalle = new List<ImpuestoDetalleDTO>();
            _ivaDetalle = new List<IvaComprasDetalleDTO>();
            _ndDeConceptos = new NotaDeDebitoDeCompra();
            _comprobanteRelacion = new List<ComprobanteRelacionDTO>();
        }

        private void NotaDeDebitoConcepto_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarDatosProveedorForm();
            cargarDatosConceptosForm();
            cargarDatosImpositivos();
            configurarGridDetalleDebito();
            configurarGridIVA();
            configurarGridImpuesto();
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

        private void configurarGridDetalleDebito()
        {
            this.dgvDetalleNDCompra.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 108;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 382;
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

            this.dgvDetalleNDCompra.Columns.Add(_codigo);
            this.dgvDetalleNDCompra.Columns.Add(_descripcion);
            this.dgvDetalleNDCompra.Columns.Add(_importe);

        }

        private void cargarDatosProveedorForm()
        {
            this.cbxCodProveedor.DataSource = _proveedores.CodDataList;
            this.cbxNombreDelProveedor.DataSource = _proveedores.NombreDataList;
            this.cbxTipoFactura.DataSource = new[] { "A", "B", "C" };
            this.txtPorcentajeBonificacion.Text = "0";
        }

        private void cargarDatosConceptosForm()
        {
            this.cbxCodConcepto.DataSource = null;
            this.cbxCodConcepto.DataSource = _conceptos.OwnDataList;
            this.cbxCodConcepto.DisplayMember = "codigo";

            this.cbxNombreDeConcepto.DataSource = null;
            this.cbxNombreDeConcepto.DataSource = _conceptos.OwnDataList;
            this.cbxNombreDeConcepto.DisplayMember = "descripcion";
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

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComprobante.Text == string.Empty)
                {
                    string msg = String.Empty;

                    if (validarNulidadDatosItem(ref msg))
                    {
                        NotaDeDebitoCompDetalleDTO det = new NotaDeDebitoCompDetalleDTO();
                        det.Id_concepto = ConceptoDTO.obtenerId(cbxCodConcepto.Text);
                        det.Importe = decimal.Round(decimal.Parse(txtImporte.Text), 2, MidpointRounding.AwayFromZero);
                        det.V_importe = det.Importe.ToString();
                        det.Codigo = cbxCodConcepto.Text;
                        det.Descripcion = cbxNombreDeConcepto.Text;
                        _ndDetalle.Add(det);
                        this.dgvDetalleNDCompra.DataSource = null;
                        this.dgvDetalleNDCompra.DataSource = _ndDetalle;
                        this.dgvDetalleNDCompra.ClearSelection();

                        if (ConceptoDTO.esExento(cbxCodConcepto.Text))
                        {
                            sumarAlSubtotalExento(det.Importe);
                            sumarAlNetoExento(det.Importe);
                        }
                        else
                        {
                            sumarAlSubtotal(det.Importe);
                            sumarAlNeto(det.Importe);
                        }
                        clearDatosConceptosForm();
                        cbxCodConcepto.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito de Compra");
                    }
                }
                else
                {
                    ComprobanteCompraDTO comprobante = ComprobanteCompraDTO.obtenerComprobante(cbxCodProveedor.Text, txtComprobante.Text);
                    if (comprobante.Cod_comprobante != string.Empty)
                    {
                        string msg = String.Empty;

                        if (validarNulidadImporte(ref msg))
                        {
                            txtComprobante.Text = comprobante.Tipo_comprobante + " - " + comprobante.Cod_comprobante;
                            _comprobanteRelacion.Add(formToComprobanteRelacion(comprobante.Id_tipo_comprobante, comprobante.Cod_comprobante));

                            NotaDeDebitoCompDetalleDTO det = new NotaDeDebitoCompDetalleDTO();
                            det.Importe = decimal.Round(decimal.Parse(txtImporte.Text), 2, MidpointRounding.AwayFromZero);
                            det.V_importe = det.Importe.ToString();
                            det.Codigo = "NA";
                            det.Descripcion = txtComprobante.Text;
                            _ndDetalle.Add(det);
                            this.dgvDetalleNDCompra.DataSource = null;
                            this.dgvDetalleNDCompra.DataSource = _ndDetalle;
                            this.dgvDetalleNDCompra.ClearSelection();

                            if (ConceptoDTO.esExento(cbxCodConcepto.Text))
                            {
                                sumarAlSubtotalExento(det.Importe);
                                sumarAlNetoExento(det.Importe);
                            }
                            else
                            {
                                sumarAlSubtotal(det.Importe);
                                sumarAlNeto(det.Importe);
                            }
                            clearDatosConceptosForm();
                            cbxCodConcepto.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito de Compra");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El comprobante no existe para el proveedor seleccionado", "Nota de Débito de Compra");
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación agregar item a la nota de débito");
            }
        }

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

        private void clearDatosConceptosForm()
        {
            cbxCodConcepto.Text = string.Empty;
            cbxNombreDeConcepto.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtComprobante.Text = string.Empty;
        }

        private bool validarNulidadDatosItem(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodConcepto.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de concepto.";
            }
            else
            {
                int resultIndex = this.cbxCodConcepto.FindStringExact(cbxCodConcepto.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de concepto ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.cbxNombreDeConcepto.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el nombre de concepto.";
            }
            else
            {
                int resultIndex = this.cbxNombreDeConcepto.FindStringExact(cbxNombreDeConcepto.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de concepto ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.txtImporte.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe del concepto.";
            }

            return rv;

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

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetalleNDCompra.SelectedRows.Count > 0)
                {
                    NotaDeDebitoCompDetalleDTO regSel = (NotaDeDebitoCompDetalleDTO)this.dgvDetalleNDCompra.SelectedRows[0].DataBoundItem;

                    if (ConceptoDTO.esExento(regSel.Codigo))
                    {
                        restarAlSubtotalExento(regSel.Importe);
                        restarAlNetoExento(regSel.Importe);
                    }
                    else
                    {
                        restarAlSubtotal(regSel.Importe);
                        restarAlNeto(regSel.Importe);
                    }

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

                    _ndDetalle.Remove(regSel);
                    this.dgvDetalleNDCompra.DataSource = null;
                    this.dgvDetalleNDCompra.DataSource = _ndDetalle;
                    this.dgvDetalleNDCompra.ClearSelection();
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
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito de Compra");
            }
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
                MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito de Compra");
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

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            calcularTotal();
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

        private void calcularIva()
        {
            if (cbxPorcentajeDeIva.Text != string.Empty)
            {
                decimal neto = decimal.Zero;
                decimal iva;

                if (txtNeto.Text != string.Empty)
                {
                    //neto = decimal.Parse(txtNeto.Text);
                    neto = _conceptos.sumarSegunIva(_ndDetalle, decimal.Parse(cbxPorcentajeDeIva.Text)); //feb 
                }

                iva = neto * (decimal.Parse(cbxPorcentajeDeIva.Text) / 100);

                txtImporteIva.Text = String.Format("{0:0.00}", Math.Round(iva, 2, MidpointRounding.AwayFromZero));
            }
        }

        private void calcularTotal()
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

            txtTotal.Text = String.Format("{0:0.00}", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
        }

        private void cbxPorcentajeDeIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularIva();
        }

        private void cbxDescripcionImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nada
        }

        private void cbxPorcentajeImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularImpuesto();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("¿Desea registrar la nota de débito de compra?", "Nota de Débito de Compra", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                string msg = String.Empty;

                if (validarNulidadDatos(ref msg))
                {
                    NotaDeDebitoDeCompraDTO data = this.formToObject();
                    _ndDeConceptos.registrar(data, _ndDetalle, _ivaDetalle, _impuestoDetalle, _comprobanteRelacion);
                    clearForm();
                    MessageBox.Show("La operación fue realizada con éxito.", "Nota de Débito de Compra");
                }
                else
                {
                    MessageBox.Show("No ha sido posible registrar la nota de débito de compra. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Nota de Débito de Compra");
                }
            }
        }

        private void clearForm()
        {
            //datos del proveedor
            cbxCodProveedor.Text = string.Empty;
            cbxNombreDelProveedor.Text = string.Empty;
            txtNroFacturaCompra.Text = string.Empty;
            txtPorcentajeBonificacion.Text = string.Empty;

            //detalle de la factura
            cbxCodConcepto.Text = string.Empty;
            cbxNombreDeConcepto.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtComprobante.Text = string.Empty;
            dgvDetalleNDCompra.DataSource = null;
            txtSubtotalExento.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtNetoExento.Text = string.Empty;
            txtNeto.Text = string.Empty;
            _ndDetalle.Clear();
            _comprobanteRelacion.Clear();

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

        private NotaDeDebitoDeCompraDTO formToObject()
        {
            NotaDeDebitoDeCompraDTO data = new NotaDeDebitoDeCompraDTO();

            data.Id_proveedor = cbxCodProveedor.Text;
            data.Nombre_proveedor = cbxNombreDelProveedor.Text;
            data.Es_concepto = 'S';
            data.Cod_comprobante = txtNroFacturaCompra.Text;
            data.Tipo_nota_debito = char.Parse(cbxTipoFactura.Text);
            data.Categoria_iva = ProveedorDTO.obtenerCategoriaIvaAbreviado(data.Id_proveedor);
            data.Cuit_proveedor = ProveedorDTO.obtenerCuit(data.Id_proveedor);
            data.Fecha_contable = dtpFechaContable.Value.Date;
            data.Fecha_comprobante = dtpFechaDelComprobante.Value.Date;
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
                msg += "\nDebe ingresar el número de nota de débito.";
            }

            if (this.dgvDetalleNDCompra.RowCount == 0)
            {
                rv = false;
                msg += "\nDebe ingresar el detalle de la nota de débito.";
            }

            if (this.txtTotal.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe total.";
            }

            return rv;

        }

        //validadores de INPUTs

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

        private bool validarNulidadImporte(ref string msg)
        {
            bool rv = true;

            if (this.txtImporte.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe del comprobante.";
            }

            return rv;

        }


    }
}

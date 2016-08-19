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
    public partial class frmFacturacionConRemito : Form
    {
        //private Clientes _clientes; //feb 1.9.1
        private MedidaCubierta _medidas;
        private Servicio _servicios;
        private Marca _marcas;
        private Orden _orden;
        private OrdenDetalle _ordenDetalle;
        private Factura _factura;
        private FacturaDetalle _facturaDetalle;
        private MotivoDescuento _motivoDescuento;
        private Remito _remito;
        private string nroRemitoProcesado;

        public frmFacturacionConRemito()
        {
            InitializeComponent();
            //_clientes = new Clientes(); //feb 1.9.1
            _medidas = new MedidaCubierta();
            _marcas = new Marca();
            _servicios = new Servicio();
            _orden = new Orden();
            _ordenDetalle = new OrdenDetalle();
            _factura = new Factura();
            _facturaDetalle = new FacturaDetalle();
            _motivoDescuento = new MotivoDescuento();
            _remito = new Remito();
            nroRemitoProcesado = RemitoDTO.getComprobanteTemp();
        }

        private void dgvOrdenesDeTrabajo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvOrdenesDeTrabajo.SelectedRows.Count > 0)
            {
                this.objectToForm((OrdenDetalleDTO)this.dgvOrdenesDeTrabajo.SelectedRows[0].DataBoundItem);
                this.txtRenglon.ReadOnly = true;
                this.pnlDerecho.Enabled = false;
                this.btnProcesar.Enabled = false;
                habilitarFormOrdenes();
            }
        }

        //feb 1.7
        private void txtPorcentajeDeBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
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
                    bool rv = Decimal.TryParse(this.txtPorcentajeDeBonificacion.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void FacturacionConRemito_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            //configuracion izquierda
            cargarFiltroCompleto();
            cargarFormularioDetalleOrden();
            configurarGridDetalleTrabajo();
            deshabilitarFormOrdenes();
            txtPorcentajeDeBonificacion.Text = "0"; //feb 1.7

            //configuracion derecha
            configurarGridDetalleFactura();
            cargarSolapaFacturacion(0);
            if (_factura.GridDataList.Count > 0) //si hay datos
            {
                habilitarFacturacion();
            }
            else
            {
                deshabilitarFacturacion();
            }
        }

        private void habilitarFacturacion()
        {
            btnImprimirFactura.Enabled = true;
            btnVistaPreliminarFactura.Enabled = true;
            btnCambiarFactura.Enabled = true;
            btnRegistrar.Enabled = true;
            btnBorrar.Enabled = false;
            pnlIzquierda.Enabled = false;
            lblVistaPreliminar.Text = "Vista Definitiva";
        }

        private void deshabilitarFacturacion()
        {
            btnImprimirFactura.Enabled = false;
            btnVistaPreliminarFactura.Enabled = false;
            btnCambiarFactura.Enabled = false;
            btnRegistrar.Enabled = false;
            btnBorrar.Enabled = true;
            pnlIzquierda.Enabled = true;
            lblVistaPreliminar.Text = "Vista Preliminar";
        }

        private void objectToFormFact(FacturaDTO data)
        {
            if (data.Nro_factura.ToString() != "-1")
            {
                this.tbpNroFactura.Text = data.Nro_factura.ToString();
                this.txtNroFactura.Text = data.Nro_factura.ToString();

                this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura.Text = data.Tipo_factura.ToString();

            }
            else
            {
                this.tbpNroFactura.Text = "F1";
                this.txtNroFactura.Text = "";
                this.lblDatosDelCliente.Text = "";
                this.lblTipoFactura.Text = "";
                _facturaDetalle.refreshGridData(data.Id);
                this.dgvDetalleFactura.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito.Text = nroRemitoProcesado;
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


        private void cargarSolapaFacturacion(int posicion)
        {

            int nroSolapa = 1;
            _factura.refreshGridDataDeRem();

            if (_factura.GridDataList.Count > 0) //si hay datos
            {
                foreach (FacturaDTO row in _factura.GridDataList)
                {
                    if (nroSolapa == 1)
                    {
                        this.objectToFormFact(row);

                        _facturaDetalle.refreshGridData(row.Id);
                        this.dgvDetalleFactura.DataSource = _facturaDetalle.GridDataList;
                        this.dgvDetalleFactura.Font = txtCoche.Font;
                        this.dgvDetalleFactura.ClearSelection();
                        this.txtRenglones.Text = dgvDetalleFactura.RowCount.ToString();
                    }
                    nroSolapa = nroSolapa + 1;
                }
            }
            else
            {
                this.txtRenglones.Text = string.Empty;
            }
            this.tbcFacturasPendientes.SelectedIndex = posicion;
        }

        private void configurarGridDetalleFactura()
        {
            this.dgvDetalleFactura.AutoGenerateColumns = false;

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
            _codigo.Width = 45;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion"; //medida de la cubierta y servicio
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 374;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precioUnitario = new DataGridViewTextBoxColumn();
            _precioUnitario.DataPropertyName = "v_precio_unitario";
            _precioUnitario.HeaderText = "Precio Unitario";
            _precioUnitario.Width = 73;
            _precioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.ReadOnly = true;

            DataGridViewTextBoxColumn _importe = new DataGridViewTextBoxColumn();
            _importe.DataPropertyName = "v_importe";
            _importe.HeaderText = "Importe";
            _importe.Width = 73;
            _importe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _importe.ReadOnly = true;

            this.dgvDetalleFactura.Columns.Add(_cantidad);
            this.dgvDetalleFactura.Columns.Add(_codigo);
            this.dgvDetalleFactura.Columns.Add(_descripcion);
            this.dgvDetalleFactura.Columns.Add(_precioUnitario);
            this.dgvDetalleFactura.Columns.Add(_importe);
        }

        private void deshabilitarFormOrdenes()
        {
            this.btnActualizar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtCoche.Enabled = false;
            this.cbxMarca.Enabled = false;
            this.cbxMedidaDeCubierta.Enabled = false;
            this.cbxServicioAdicional.Enabled = false;
            this.cbxTrabajo.Enabled = false;
            this.txtNroSerie.Enabled = false;
            this.txtNroInterno.Enabled = false;
            this.txtRenglon.Enabled = false;
            this.txtPorcentajeAPagar.Enabled = false;
            this.cbxMotivoDescuento.Enabled = false;
            this.btnX.Enabled = false;
            this.chbDesglosarEnFactura.Enabled = false;
        }

        private void habilitarFormOrdenes()
        {
            this.btnActualizar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.txtCoche.Enabled = true;
            this.cbxMarca.Enabled = true;
            this.cbxMedidaDeCubierta.Enabled = true;
            this.cbxServicioAdicional.Enabled = true;
            this.cbxTrabajo.Enabled = true;
            this.txtNroSerie.Enabled = true;
            this.txtNroInterno.Enabled = true;
            this.txtRenglon.Enabled = true;
            this.txtPorcentajeAPagar.Enabled = true;
            this.cbxMotivoDescuento.Enabled = true;
            this.btnX.Enabled = true;
            this.chbDesglosarEnFactura.Enabled = true;
        }

        private void configurarGridDetalleTrabajo()
        {
            this.dgvOrdenesDeTrabajo.AutoGenerateColumns = false;

            //tengo 10
            DataGridViewTextBoxColumn _nroDeOrdenColum = new DataGridViewTextBoxColumn();
            _nroDeOrdenColum.DataPropertyName = "id_orden_de_trabajo";
            _nroDeOrdenColum.HeaderText = "Orden";
            _nroDeOrdenColum.Width = 55;
            _nroDeOrdenColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroRenglonColum = new DataGridViewTextBoxColumn();
            _nroRenglonColum.DataPropertyName = "renglon";
            _nroRenglonColum.HeaderText = "R.";
            _nroRenglonColum.Width = 20;
            _nroRenglonColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.ReadOnly = true;

            DataGridViewTextBoxColumn _coche = new DataGridViewTextBoxColumn();
            _coche.DataPropertyName = "coche";
            _coche.HeaderText = "Coche";
            _coche.Width = 111;
            _coche.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.ReadOnly = true;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 111;
            _medidaCubiertaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _marcaColum = new DataGridViewTextBoxColumn();
            _marcaColum.DataPropertyName = "marca";
            _marcaColum.HeaderText = "Marca";
            _marcaColum.Width = 55;
            _marcaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marcaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _NroSerieColum = new DataGridViewTextBoxColumn();
            _NroSerieColum.DataPropertyName = "serie";
            _NroSerieColum.HeaderText = "Serie";
            _NroSerieColum.Width = 60;
            _NroSerieColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.ReadOnly = true;

            DataGridViewTextBoxColumn _internoColum = new DataGridViewTextBoxColumn();
            _internoColum.DataPropertyName = "interno";
            _internoColum.HeaderText = "Interno";
            _internoColum.Width = 57;
            _internoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _internoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _internoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _trabajoColum = new DataGridViewTextBoxColumn();
            _trabajoColum.DataPropertyName = "trabajo";
            _trabajoColum.HeaderText = "Trabajo";
            _trabajoColum.Width = 100;
            _trabajoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _precioSinIvaColum = new DataGridViewTextBoxColumn();
            _precioSinIvaColum.DataPropertyName = "v_precioSIva";
            _precioSinIvaColum.HeaderText = "Total s/iva";
            _precioSinIvaColum.Width = 84;
            _precioSinIvaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioSinIvaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioSinIvaColum.ReadOnly = true;

            this.dgvOrdenesDeTrabajo.Columns.Add(_nroDeOrdenColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_nroRenglonColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_coche);
            this.dgvOrdenesDeTrabajo.Columns.Add(_medidaCubiertaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_marcaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_NroSerieColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_internoColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_trabajoColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_precioSinIvaColum);
        }

        private void cargarFormularioDetalleOrden()
        {
            //
            this.cbxMedidaDeCubierta.DataSource = _medidas.OwnDataList;
            this.cbxMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxMedidaDeCubierta.ValueMember = "id";

            this.cbxMarca.DataSource = _marcas.OwnDataList;
            this.cbxMarca.DisplayMember = "valor";
            this.cbxMarca.ValueMember = "id";

            this.cbxTrabajo.DataSource = _servicios.OwnServList;
            this.cbxTrabajo.DisplayMember = "descripcion";
            this.cbxTrabajo.ValueMember = "id";

            this.cbxServicioAdicional.DataSource = _servicios.OwnServAdicionalList;
            this.cbxServicioAdicional.DisplayMember = "descripcion";
            this.cbxServicioAdicional.ValueMember = "id";

            this.cbxMotivoDescuento.DataSource = _motivoDescuento.OwnDataList;
            this.cbxMotivoDescuento.DisplayMember = "valor";
            this.cbxMotivoDescuento.ValueMember = "id";

        }


        private void cargarFiltroCompleto()
        {
            _remito.refreshOwnData();
            this.cbxFiltroNroDeRemito.DisplayMember = "cod_comprobante_remito";
            this.cbxFiltroNroDeRemito.DataSource = _remito.OwnDataList;
            
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cargarGridDetalleTrabajo()
        {
            _remito.refreshGridDataOrden(cbxFiltroNroDeRemito.Text);
            this.dgvOrdenesDeTrabajo.DataSource = _remito.GridDataOrdenList;
            this.dgvOrdenesDeTrabajo.Font = txtCoche.Font;
            dgvOrdenesDeTrabajo.ClearSelection();
        }

        private void clearForm()
        {
            this.objectToForm(new OrdenDetalleDTO());
        }

        private void objectToForm(OrdenDetalleDTO data)
        {
            this.txtNroOrden.Text = data.Id_orden_de_trabajo.ToString();

            this.txtRenglon.Text = data.Renglon.ToString();

            if (data.Porcentaje_a_pagar == -1)
            {
                this.txtPorcentajeAPagar.Text = "";
                this.txtRenglon.Text = ""; //para darme cuenta de que es blanqueo
            }
            else
            {
                this.txtPorcentajeAPagar.Text = data.Porcentaje_a_pagar.ToString();
            }

            this.txtNroSerie.Text = data.Serie;

            if (data.Interno == -1)
            {
                this.txtNroInterno.Text = "";
            }
            else
            {
                this.txtNroInterno.Text = data.Interno.ToString();
            }

            this.txtCoche.Text = data.Coche;

            if (data.Id_marca == -1 && this.cbxMarca.Items.Count != 0)
            {
                this.cbxMarca.SelectedIndex = 0;
            }
            else
            {
                this.cbxMarca.SelectedValue = data.Id_marca;
            }

            this.cbxMedidaDeCubierta.Text = data.Medida_cubierta;

            if (data.Id_servicio == -1 && this.cbxTrabajo.Items.Count != 0)
            {
                this.cbxTrabajo.SelectedIndex = 0;
            }
            else
            {
                this.cbxTrabajo.SelectedValue = data.Id_servicio;
            }

            if (data.Id_servicio_adicional == -1 && this.cbxServicioAdicional.Items.Count != 0)
            {
                this.cbxServicioAdicional.SelectedIndex = 0;
            }
            else
            {
                this.cbxServicioAdicional.SelectedValue = data.Id_servicio_adicional;
            }

            this.cbxMotivoDescuento.Text = data.Motivo_descuento;

            if (data.Desglosar_serv_adi == 'S')
            {
                this.chbDesglosarEnFactura.Checked = true;
            }
            else
            {
                this.chbDesglosarEnFactura.Checked = false;
            }

        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.txtNroSerie.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de serie.";
            }

            if (this.txtNroInterno.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Número de interno.";
            }

            if (this.txtPorcentajeAPagar.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Porcentaje a pagar.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) < 0)
            {
                rv = false;
                msg += "\nEl porcentaje a pagar no puede ser negativo.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) < 100 && this.cbxMotivoDescuento.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Motivo de descuento.";
            }

            if (int.Parse(this.txtPorcentajeAPagar.Text) >= 100 && this.cbxMotivoDescuento.Text != "")
            {
                rv = false;
                msg += "\nNo debe ingresar un Motivo de descuento.";
            }

            if (this.cbxTrabajo.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Trabajo a realizar.";
            }
            else
            {
                int resultIndex = this.cbxTrabajo.FindStringExact(cbxTrabajo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl trabajo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxServicioAdicional.Text != "")
            {
                int resultIndex = this.cbxServicioAdicional.FindStringExact(cbxServicioAdicional.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl servicio adicional ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxMarca.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la Marca.";
            }
            else
            {
                int resultIndex = this.cbxMarca.FindStringExact(cbxMarca.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa marca ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMedidaDeCubierta.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la Medida de cubierta.";
            }
            else
            {
                int resultIndex = this.cbxMedidaDeCubierta.FindStringExact(cbxMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa medida de cubierta ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMotivoDescuento.Text != "")
            {
                int resultIndex = this.cbxMotivoDescuento.FindStringExact(cbxMotivoDescuento.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl motivo de descuento ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;

        }

        private OrdenDetalleDTO formToObject()
        {
            OrdenDetalleDTO rv = new OrdenDetalleDTO();

            rv.Id_orden_de_trabajo = long.Parse(this.txtNroOrden.Text);
            rv.Renglon = int.Parse(this.txtRenglon.Text);
            rv.Porcentaje_a_pagar = decimal.Parse(this.txtPorcentajeAPagar.Text);
            rv.Serie = this.txtNroSerie.Text;
            rv.Interno = long.Parse(this.txtNroInterno.Text);
            rv.Coche = this.txtCoche.Text;
            rv.Id_marca = long.Parse(this.cbxMarca.SelectedValue.ToString());
            rv.Medida_cubierta = this.cbxMedidaDeCubierta.Text;
            rv.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            rv.Id_servicio = long.Parse(this.cbxTrabajo.SelectedValue.ToString());

            if (this.cbxServicioAdicional.SelectedValue != null)
            {
                rv.Id_servicio_adicional = long.Parse(this.cbxServicioAdicional.SelectedValue.ToString());
            }
            else
            {
                rv.Id_servicio_adicional = -1;
            }

            if (this.chbDesglosarEnFactura.Checked)
            {
                rv.Desglosar_serv_adi = 'S';
            }
            else
            {
                rv.Desglosar_serv_adi = 'N';
            }

            rv.Motivo_descuento = this.cbxMotivoDescuento.Text;

            return rv;
        }

        private void txtNroInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
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
                    bool rv = Decimal.TryParse(this.txtNroInterno.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtPorcentajeAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == '.')
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
                    bool rv = Decimal.TryParse(this.txtPorcentajeAPagar.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el registro de la orden?", "Orden", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string msg = "";

                    if (validarNulidadDatosForm(ref msg))
                    {
                        OrdenDetalleDTO data = this.formToObject();
                        OrdenDTO dataAux = new OrdenDTO();
                        if (OrdenDetalle.isValidHist(dataAux, data, ref msg))
                        {
                            bool ok = false;
                            this._ordenDetalle.updateHist(data);
                            ok = true;

                            if (ok)
                            {
                                cargarGridDetalleTrabajo();
                                this.clearForm();
                                this.pnlDerecho.Enabled = true;
                                this.btnProcesar.Enabled = true;
                                deshabilitarFormOrdenes();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Ordenes de Trabajo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Ordenes de Trabajo");
                    }
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Actualizar Orden");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.clearForm();
            this.pnlDerecho.Enabled = true;
            this.btnProcesar.Enabled = true;
            deshabilitarFormOrdenes();
        }


        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenesDeTrabajo.RowCount > 0)
                {
                    if (_factura.generarFacturaDeRemito((List<OrdenDetalleDTO>)_remito.GridDataOrdenList, decimal.Parse(txtPorcentajeDeBonificacion.Text))) //feb 1.7
                    {
                        nroRemitoProcesado = RemitoDTO.getComprobanteTemp();
                        cargarGridDetalleTrabajo();
                        cargarSolapaFacturacion(0);
                        pnlIzquierda.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Facturación");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar la factura?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_factura.GridDataList.Count != 0)
                    {
                        _factura.refreshGridDataDeRem();
                        _factura.registrarFacturaDeRemito((List<FacturaDTO>)_factura.GridDataList);

                        cargarFiltroCompleto();
                        cargarGridDetalleTrabajo();
                        cargarSolapaFacturacion(0);
                        nroRemitoProcesado = string.Empty;
                        txtCodCliente.Text = string.Empty; //version 1.5
                        txtNombreDelCliente.Text = string.Empty; //version 1.5
                        objectToFormFact(new FacturaDTO());

                        this.tbcFacturasPendientes.SelectedIndex = 0;
                        txtPorcentajeDeBonificacion.Text = "0"; // feb 1.7
                        deshabilitarFacturacion();
                        MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
                    }
                    else
                    {
                        MessageBox.Show("No existe factura pendiente por registrar.", "Facturación");
                    }


                }



            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Registrar Factura");
            }
        }

        private void cbxFiltroNroDeRemito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiltroNroDeRemito.Text != "")
            {
                cargarGridDetalleTrabajo();
                //version 1.5
                string [] datosCliente = RemitoDTO.obtenerCodYNomCliente(cbxFiltroNroDeRemito.Text);
                txtCodCliente.Text = datosCliente[0];
                txtNombreDelCliente.Text = datosCliente[1];
                txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(txtCodCliente.Text).ToString(); //feb 1.7
            }
            else
            {
                dgvOrdenesDeTrabajo.DataSource = null;
            }
            clearForm();
            deshabilitarFormOrdenes();
            btnProcesar.Enabled = true;
            pnlDerecho.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar la factura pendiente de registrar?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_factura.GridDataList.Count != 0)
                    {
                        _factura.deleteConRemito();

                        cargarGridDetalleTrabajo();
                        cargarSolapaFacturacion(0);
                        nroRemitoProcesado = string.Empty;
                        objectToFormFact(new FacturaDTO());
                        this.tbcFacturasPendientes.SelectedIndex = 0;
                        pnlIzquierda.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No existen facturas pendientes por borrar.", "Facturación");
                    }
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Borrar facturas pendientes");
            }
        }

        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 1 && lblVistaPreliminar.Text != "Vista Definitiva")
            {
                habilitarFacturacion();
            }
        }

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            if (txtNroFactura.Text != "")
            {
                string cod_remito = txtNroRemito.Text;
                imprimirFactura(0, cod_remito);
            }
        }


        private void imprimirFactura(int posicion, string cod_remito)
        {
            try
            {
                frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                formProcesamiento.Show();

                if (_factura.GridDataList[posicion].Tipo_factura == 'A')
                {
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporte(string.Empty, _factura.GridDataList[posicion].Id, cod_remito);
                    rptLista.PrintToPrinter(1, false, 1, 1);
                    rptLista.Dispose();
                }
                if (_factura.GridDataList[posicion].Tipo_factura == 'B')
                {
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporte(string.Empty, _factura.GridDataList[posicion].Id, cod_remito);
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

        private void registrarAnularGenerar(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular la factura actual y generar una nueva?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    _factura.registrarAnularFactura(_factura.GridDataList[posicion]);
                    cargarSolapaFacturacion(posicion);

                    //MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
                }

            }

            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Anular y Generar Factura");
            }

        }

        private void btnCambiarFactura_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 1)
            {
                registrarAnularGenerar(0);
            }
        }

        private void btnVistaPreliminarFactura_Click(object sender, EventArgs e)
        {
            if (txtNroFactura.Text != "")
            {
                string cod_remito = txtNroRemito.Text;
                vistaPreliminarFactura(0, cod_remito);
            }
        }

        private void vistaPreliminarFactura(int posicion, string cod_remito)
        {
            try
            {
                if (_factura.GridDataList[posicion].Tipo_factura == 'A')
                {
                    frmVerFacturaA frmReporte = new frmVerFacturaA();
                    crFacturaA rptLista = GenerarImpresionFacturaA.cargarReporte(string.Empty, _factura.GridDataList[posicion].Id, cod_remito);
                    frmReporte.crvFacturaA.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
                }
                if (_factura.GridDataList[posicion].Tipo_factura == 'B')
                {
                    frmVerFacturaB frmReporte = new frmVerFacturaB();
                    crFacturaB rptLista = GenerarImpresionFacturaB.cargarReporte(string.Empty, _factura.GridDataList[posicion].Id, cod_remito);
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

        //feb 1.9.1
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea generar el XML para el sistema Facturación Web?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_factura.GridDataList.Count != 0)
                    {
                        string path_completo = FacturacionWeb.generarXML(_factura);
                        MessageBox.Show("La operación fue realizada con éxito. Se generó el archivo " + path_completo, "Facturación");
                    }
                    else
                    {
                        MessageBox.Show("No existen facturas para exportar.", "Facturación");
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Exportar facturas pendientes");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//feb 1.9.1 solo remito
namespace OFC
{
    public partial class frmFacturacionManual : Form
    {
        private Clientes _clientes;
        private Producto _productos;
        private Servicio _servicios;
        private MedidaCubierta _medidas;
        private Marca _marcas;
        private Factura _factura;
        private FacturaDetalle _facturaDetalle;
        private Remito _remito; //feb 1.9.1
        private RemitoDetalle _remitoDetalle; //feb 1.9.1

        public frmFacturacionManual()
        {
            InitializeComponent();

            _clientes = new Clientes();
            _productos = new Producto();
            _servicios = new Servicio();
            _medidas = new MedidaCubierta();
            _marcas = new Marca();
            _factura = new Factura();
            _facturaDetalle = new FacturaDetalle();
            _remito = new Remito(); //feb 1.9.1
            _remitoDetalle = new RemitoDetalle(); //feb 1.9.1
        }

        private void frmFacturacionManual_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarDatosClienteForm();
            cargarDatosItemForm();
            txtDescripcion.Enabled = false;
            configurarGridDetalleFactura();
            cargarSolapaFacturacion();
            cargarSolapaRemito(); //feb 1.9.1
            txtPorcentajeDeBonificacion.Text = "0"; //feb 1.7

            if (_factura.GridDataList.Count > 0) //si hay datos
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

        private void configurarGridDetalleFactura()
        {
            this.dgvFacturaPendiente.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "C.";
            _cantidad.Width = 30;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo"; //id_producto + A + id_servicio
            _codigo.HeaderText = "Código";
            _codigo.Width = 108;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion"; //medida de la cubierta y servicio
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 320;
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

            this.dgvFacturaPendiente.Columns.Add(_cantidad);
            this.dgvFacturaPendiente.Columns.Add(_codigo);
            this.dgvFacturaPendiente.Columns.Add(_descripcion);
            this.dgvFacturaPendiente.Columns.Add(_precioUnitario);
            this.dgvFacturaPendiente.Columns.Add(_importe);

        }


        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
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

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtPrecioUnitario.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporte.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void cargarDatosClienteForm()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;
        }

        private void cargarDatosItemForm()
        {
            this.cbxCodProducto.DataSource = _productos.OwnDataList;
            this.cbxCodProducto.DisplayMember = "codigo";

            this.cbxProducto.DataSource = _productos.OwnDataList;
            this.cbxProducto.DisplayMember = "descripcion";

            this.cbxMedidaDeCubierta.DataSource = _medidas.OwnDataList;
            this.cbxMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxMedidaDeCubierta.ValueMember = "id";

            this.cbxMarca.DataSource = _marcas.OwnDataList;
            this.cbxMarca.DisplayMember = "valor";
            this.cbxMarca.ValueMember = "id";

            this.cbxTrabajoServicio.DataSource = _servicios.OwnServList;
            this.cbxTrabajoServicio.DisplayMember = "descripcion";
            this.cbxTrabajoServicio.ValueMember = "id";

            this.cbxServicioAdicional.DataSource = _servicios.OwnServAdicionalList;
            this.cbxServicioAdicional.DisplayMember = "descripcion";
            this.cbxServicioAdicional.ValueMember = "id";
        }

        private void cbxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxCodCliente.Text);
            txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(this.cbxCodCliente.Text).ToString(); //feb 1.7
        }

        private void cbxNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodCliente.Text = _clientes.obtenerCodigo(this.cbxNombreDelCliente.Text);
            txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(this.cbxCodCliente.Text).ToString(); //feb 1.7
        }
        
        private void btnXCliente_Click(object sender, EventArgs e)
        {
            if (this.cbxCodCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el Código de cliente.", "Facturación");
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    MessageBox.Show("El Código de cliente ingresado es incorrecto. Seleccione uno de la lista.", "Facturación");
                }
                else
                {
                    //feb 1.9.1 horrible esto....
                    if (cbhSoloRemito.Checked && cbhSoloFactura.Checked)
                    {
                        MessageBox.Show("No es posible continuar con 'Solo Factura' y 'Solo Remito' al mismo tiempo. Por favor seleccione UNA de las dos opciones o ninguna.", "Facturación");
                    }
                    else
                    {
                        deshabilitarDatosCliente();
                        habilitarDatosItem();
                        txtCantidad.Focus();
                    }
                }
            }
        }

        private void deshabilitarDatosCliente()
        {
            pnlIzquierda1.Enabled = false;
        }

        private void habilitarDatosCliente()
        {
            pnlIzquierda1.Enabled = true;
        }

        private void habilitarDatosItem()
        {
            pnlIzquierda2.Enabled = true;
        }

        private void deshabilitarDatosItem()
        {
            pnlIzquierda2.Enabled = false;
        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxProducto.Text == "CUBIERTA")
            {
                pnlDatosCubierta.Enabled = true;
            }
            else
            {
                pnlDatosCubierta.Enabled = false;
                txtCoche.Text = "";
                cbxMedidaDeCubierta.Text = "";
                cbxMarca.Text = "";
                txtNroSerie.Text = "";
                cbxTrabajoServicio.Text = "";
            }
            cbxCodProducto.Enabled = true;
            cbxProducto.Enabled = true;
            txtCodigoDeBarras.Enabled = true;
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
        }

        private void rdbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosCubierta.Enabled = false;
            txtCoche.Text = "";
            cbxMedidaDeCubierta.Text = "";
            cbxMarca.Text = "";
            txtNroSerie.Text = "";
            cbxTrabajoServicio.Text = "";

            cbxCodProducto.Enabled = false;
            cbxProducto.Text = "";
            cbxProducto.Enabled = false;
            txtCodigoDeBarras.Enabled = false;
            txtDescripcion.Enabled = true;
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProducto.Text == "CUBIERTA")
            {
                pnlDatosCubierta.Enabled = true;
            }
            else
            {
                pnlDatosCubierta.Enabled = false;
                txtCoche.Text = "";
                cbxMedidaDeCubierta.Text = "";
                cbxMarca.Text = "";
                txtNroSerie.Text = "";
                cbxTrabajoServicio.Text = "";
                cargarPrecioImporteBis();
            }
        }

        public void cargarPrecioImporteBis()
        {
            if (rdbProducto.Checked)
            {
                string msg = "";

                if (validarNulidadDatosForm(ref msg))
                {
                    Decimal precioUnitario = PrecioDTO.buscarPrecio(formToObjectPrecio());
                    if (precioUnitario != -1 && txtCantidad.Text != "")
                    {
                        txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioUnitario, 2, MidpointRounding.AwayFromZero));
                        txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * precioUnitario, 2, MidpointRounding.AwayFromZero));
                    }
                    else
                    {
                        txtPrecioUnitario.Text = "";
                        txtImporte.Text = "";
                    }
                }
            }
            else
            {
                txtPrecioUnitario.Text = "";
                txtImporte.Text = "";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            try{
                cargarPrecioImporte();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Obtener Precio");
            }
        }

        public void cargarPrecioImporte()
        {
            if (rdbProducto.Checked)
            {
                string msg = "";

                if (validarNulidadDatosForm(ref msg))
                {
                    Decimal precioUnitario = PrecioDTO.buscarPrecio(formToObjectPrecio());
                    Decimal precioAdicionalUnitario = PrecioDTO.buscarPrecio(formToObjectPrecioAdi());

                    if (precioUnitario != -1 && precioAdicionalUnitario == -1 && txtCantidad.Text != "")
                    {
                        txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioUnitario, 2, MidpointRounding.AwayFromZero));
                        txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * precioUnitario, 2, MidpointRounding.AwayFromZero));
                    }
                    if (precioUnitario == -1 && precioAdicionalUnitario != -1 && txtCantidad.Text != "")
                    {
                        txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioAdicionalUnitario, 2, MidpointRounding.AwayFromZero));
                        txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * precioAdicionalUnitario, 2, MidpointRounding.AwayFromZero));
                    }
                    if (precioUnitario != -1 && precioAdicionalUnitario != -1 && txtCantidad.Text != "")
                    {
                        txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioUnitario + precioAdicionalUnitario, 2, MidpointRounding.AwayFromZero));
                        txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * (precioUnitario + precioAdicionalUnitario), 2, MidpointRounding.AwayFromZero));
                    }
                    if ((precioUnitario == -1 && precioAdicionalUnitario == -1) || txtCantidad.Text == "")
                    {
                        txtPrecioUnitario.Text = "";
                        txtImporte.Text = "";
                        MessageBox.Show("No se ha cargado un precio para los valores ingresados. Verifique Cantidad, Artículo, Medida de cubierta o Trabajo/Servicio", "Facturación");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Facturación");
                }
            }
            else
            {
                txtPrecioUnitario.Text = "";
                txtImporte.Text = "";
            }
        }


        private void clearFormItem()
        {
            txtCantidad.Text = "1";
            cbxProducto.Text = "";
            txtCoche.Text = "";
            cbxMedidaDeCubierta.Text = "";
            cbxMarca.Text = "";
            txtNroSerie.Text = "";
            cbxTrabajoServicio.Text = "";
            txtDescripcion.Text = "";
            txtPrecioUnitario.Text = "";
            txtImporte.Text = "";
            txtCodigoDeBarras.Text = "";
            cbxCodProducto.Focus();
            cbxServicioAdicional.Text = "";
        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.txtCantidad.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la cantidad.";
            }

            if (this.cbxProducto.Text != "")
            {
                int resultIndex = this.cbxProducto.FindStringExact(cbxProducto.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl artículo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }
            else
            {
                rv = false;
                msg += "\nDebe seleccionar un artículo de la lista.";
            }

            if (this.cbxTrabajoServicio.Text != "")
            {
                int resultIndex = this.cbxTrabajoServicio.FindStringExact(cbxTrabajoServicio.Text);
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

            if (this.cbxMedidaDeCubierta.Text != "")
            {
                int resultIndex = this.cbxMedidaDeCubierta.FindStringExact(cbxMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa medida de cubierta ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMarca.Text != "")
            {
                int resultIndex = this.cbxMarca.FindStringExact(cbxMarca.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa marca ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            return rv;

        }

        private bool hayStock(ref string msg)
        {
            bool rv = true;
            long cantidadStock;
            long cantidadIngresada;

            if (this.cbxMedidaDeCubierta.Text == "" && rdbProducto.Checked)
            {
                cantidadStock = ProductoDTO.obtenerStock(ProductoDTO.buscarId(this.cbxProducto.Text));
                cantidadStock = cantidadStock - ProductoDTO.obtenerCantidadPorFacturar(ProductoDTO.buscarId(this.cbxProducto.Text));
            }
            else
            {
                cantidadStock = 999999999999;
            }

            if (this.txtCantidad.Text != "")
            {
                cantidadIngresada = long.Parse(txtCantidad.Text);
            }
            else
            {
                cantidadIngresada = 0;
            }

            if (cantidadStock < cantidadIngresada)
            {
                msg += "\nNo hay stock disponible para facturar el artículo ingresado.";
                rv = false;
            }

            return rv;
        }

        private bool validarNulidadDatosForm2(ref string msg, bool solo_remito) //feb 1.9.1
        {
            bool rv = true;

            if (this.txtCantidad.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar la cantidad.";
            }

            if (this.cbxProducto.Text != "" && this.rdbProducto.Checked)
            {
                int resultIndex = this.cbxProducto.FindStringExact(cbxProducto.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl artículo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxProducto.Text == "" && this.rdbProducto.Checked)
            {
                rv = false;
                msg += "\nDebe seleccionar un artículo de la lista.";
            }

            if (this.txtDescripcion.Text == "" && this.rdbDescripcion.Checked)
            {
                rv = false;
                msg += "\nDebe ingresar una descripción.";
            }

            if (this.cbxTrabajoServicio.Text != "" && this.cbxProducto.Text == "CUBIERTA")
            {
                int resultIndex = this.cbxTrabajoServicio.FindStringExact(cbxTrabajoServicio.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl trabajo ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxServicioAdicional.Text != "" && this.cbxProducto.Text == "CUBIERTA")
            {
                int resultIndex = this.cbxServicioAdicional.FindStringExact(cbxServicioAdicional.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl servicio adicional ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            if (this.cbxTrabajoServicio.Text == "" && this.cbxServicioAdicional.Text == "" && this.cbxProducto.Text == "CUBIERTA")
            {
                rv = false;
                msg += "\nDebe ingresar el trabajo o servicio.";
            }

            if (this.cbxMedidaDeCubierta.Text != "" && this.cbxProducto.Text == "CUBIERTA")
            {
                int resultIndex = this.cbxMedidaDeCubierta.FindStringExact(cbxMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa medida de cubierta ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMedidaDeCubierta.Text == "" && this.cbxProducto.Text == "CUBIERTA")
            {
                rv = false;
                msg += "\nDebe ingresar la medida de cubierta.";
            }

            if (this.cbxMarca.Text != "" && this.cbxProducto.Text == "CUBIERTA")
            {
                int resultIndex = this.cbxMarca.FindStringExact(cbxMarca.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nLa marca ingresada es incorrecta. Seleccione una de la lista.";
                }
            }

            if (this.cbxMarca.Text == "" && this.cbxProducto.Text == "CUBIERTA")
            {
                rv = false;
                msg += "\nDebe ingresar la marca.";
            }

            //if (this.txtPrecioUnitario.Text == "")
            //{
            //    rv = false;
            //    msg += "\nDebe ingresar el precio de lista.";
            //}

            //if (this.txtImporte.Text == "")
            //{
            //    rv = false;
            //    msg += "\nDebe ingresar el importe.";
            //}

            //feb 1.9.1
            if (!solo_remito)
            {
                if (this.txtPrecioUnitario.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el precio de lista.";
                }

                if (this.txtImporte.Text == "")
                {
                    rv = false;
                    msg += "\nDebe ingresar el importe.";
                }
            }

            return rv;

        }

        private PrecioDTO formToObjectPrecio()
        {
            PrecioDTO actual = new PrecioDTO();

            actual.Id_lista_precio = ClienteDTO.obtenerIdListaDePrecio(cbxCodCliente.Text);

            if (this.cbxMedidaDeCubierta.Text != "")
            {
                actual.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            }
            else
            {
                actual.Id_producto = ProductoDTO.buscarId(this.cbxProducto.Text); //si cbxproducto es "" devuelve -1 :)
            }

            if (this.cbxTrabajoServicio.Text != "")
            {
                actual.Id_servicio = long.Parse(this.cbxTrabajoServicio.SelectedValue.ToString());
            }
            else
            {
                actual.Id_servicio = -1;
            }

            return actual;

        }

        private PrecioDTO formToObjectPrecioAdi()
        {
            PrecioDTO actual = new PrecioDTO();

            actual.Id_lista_precio = ClienteDTO.obtenerIdListaDePrecio(cbxCodCliente.Text);

            if (this.cbxMedidaDeCubierta.Text != "")
            {
                actual.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            }
            else
            {
                actual.Id_producto = ProductoDTO.buscarId(this.cbxProducto.Text); //si cbxproducto es "" devuelve -1 :)
            }

            if (this.cbxServicioAdicional.Text != "")
            {
                actual.Id_servicio = long.Parse(this.cbxServicioAdicional.SelectedValue.ToString());
            }
            else
            {
                actual.Id_servicio = -1;
            }

            return actual;
        }

        private FacturaManualDTO formToObjectFact()
        {
            FacturaManualDTO actual = new FacturaManualDTO();

            actual.Id_cliente = cbxCodCliente.Text;
            actual.Nombre_cliente = cbxNombreDelCliente.Text;

            if (cbhSoloFactura.Checked)
            {
                actual.Solo_factura = 'S';
            }
            else
            {
                actual.Solo_factura = 'N';
            }

            if (cbhIva105.Checked)
            {
                actual.Iva105 = 'S';
            }
            else
            {
                actual.Iva105 = 'N';
            }

            actual.Cantidad = int.Parse(txtCantidad.Text);
            
            if (this.cbxMedidaDeCubierta.Text != "")
            {
                actual.Id_producto = long.Parse(this.cbxMedidaDeCubierta.SelectedValue.ToString());
            }
            else
            {
                actual.Id_producto = ProductoDTO.buscarId(this.cbxProducto.Text); //si cbxproducto es "" devuelve -1 :) sino devuelve el id del articulo
            }

            if (this.cbxTrabajoServicio.Text != "")
            {
                actual.Id_servicio = long.Parse(this.cbxTrabajoServicio.SelectedValue.ToString());
            }
            else
            {
                actual.Id_servicio = -1;
            }

            actual.Coche = txtCoche.Text;

            if (this.rdbProducto.Checked && this.cbxProducto.Text == "CUBIERTA")
            {
                if (txtCoche.Text != "")
                {
                    actual.Descripcion = txtCoche.Text + "-";
                }

                actual.Descripcion = actual.Descripcion + cbxMedidaDeCubierta.Text + "-" + cbxMarca.Text + "-" + txtNroSerie.Text;

                if (cbxTrabajoServicio.Text != "")
                {
                    actual.Descripcion = actual.Descripcion + "-" + cbxTrabajoServicio.Text;
                }

                if (cbxServicioAdicional.Text != "")
                {
                    actual.Descripcion = actual.Descripcion + "-" + cbxServicioAdicional.Text;
                }

                actual.Codigo = actual.Id_producto + "A" + actual.Id_servicio;
            }

            if (this.rdbProducto.Checked && this.cbxProducto.Text != "CUBIERTA")
            {
                actual.Descripcion = cbxProducto.Text;
                actual.Codigo = ProductoDTO.buscarCodigo(actual.Id_producto); //se que el Id_producto es de un articulo, mirar mas arriba....
            }

            if (this.rdbDescripcion.Checked)
            {
                actual.Descripcion = txtDescripcion.Text;
                actual.Codigo = "NA";
            }

            if (txtPrecioUnitario.Text != string.Empty) //feb 1.9.1
            {
                actual.Precio_unitario = decimal.Round(decimal.Parse(txtPrecioUnitario.Text), 2, MidpointRounding.AwayFromZero);
            }

            if (txtImporte.Text != string.Empty) //feb 1.9.1
            {
                actual.Importe = decimal.Round(decimal.Parse(txtImporte.Text), 2, MidpointRounding.AwayFromZero);
            }
            
            return actual;

        }

        private void btnXCalcular_Click(object sender, EventArgs e)
        {
            try{
                if (txtPrecioUnitario.Text != "" && txtCantidad.Text != "")
                {
                    txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * decimal.Parse(txtPrecioUnitario.Text), 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    MessageBox.Show("No es posible calcular el importe sin precio de lista y cantidad.", "Facturación");
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Obtener Precio");
            }
        }

        private void cargarSolapaFacturacion()
        {
            _factura.refreshGridData();

            if (_factura.GridDataList.Count > 0) //si hay datos
            {
                foreach (FacturaDTO row in _factura.GridDataList)
                {
                    this.objectToFormFact(row);

                    _facturaDetalle.refreshGridDataManual(row.Id);
                    this.dgvFacturaPendiente.DataSource = _facturaDetalle.GridDataListManual;
                    this.dgvFacturaPendiente.Font = txtCoche.Font;
                    this.dgvFacturaPendiente.ClearSelection();
                    this.txtRenglones.Text = dgvFacturaPendiente.RowCount.ToString();
                }
            }
            else
            {
                this.txtRenglones.Text = string.Empty;
            }

        }

        //feb 1.9.1
        private void cargarSolapaRemito()
        {
            _remito.refreshGridData();

            if (_remito.GridDataList.Count > 0) //si hay datos
            {
                foreach (RemitoDTO row in _remito.GridDataList)
                {
                    this.objectToFormRem(row);
                    _remitoDetalle.refreshGridData(row.Id);
                    this.dgvFacturaPendiente.DataSource = _remitoDetalle.GridDataList;
                    this.dgvFacturaPendiente.Font = txtCoche.Font;
                    this.dgvFacturaPendiente.ClearSelection();
                    this.txtRenglones.Text = dgvFacturaPendiente.RowCount.ToString();
                }
            }
            else
            {
                this.txtRenglones.Text = string.Empty;
            }

        }

        //feb 1.9.1
        private void objectToFormRem(RemitoDTO data)
        {

            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroFactura.Text = "R1";
                this.txtNroRemito.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
                this.lblTipoFactura.Text = "";
            }
            else
            {
                this.tbpNroFactura.Text = "F1";
                this.txtNroRemito.Text = "";

                this.lblDatosDelCliente.Text = "";
                this.lblTipoFactura.Text = "";

                _remitoDetalle.refreshGridData(data.Id);
                this.dgvFacturaPendiente.DataSource = _remitoDetalle.GridDataList;
            }

            if (data.Nro_factura.ToString() != "-1")
            {
                this.txtNroFactura.Text = data.Nro_factura.ToString();
            }
            else
            {
                this.txtNroFactura.Text = "";
            }

            this.txtBonificacion.Text = "";
            this.txtSubtotal.Text = "";
            this.txtIva.Text = "";
            this.txtTotal.Text = "";

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
                this.dgvFacturaPendiente.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito.Text = "";
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

        //feb 1.9.1
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";

                if (!cbhSoloRemito.Checked)
                {
                    if (validarNulidadDatosForm2(ref msg, cbhSoloRemito.Checked))
                    {
                        _factura.generar(formToObjectFact(), decimal.Parse(txtPorcentajeDeBonificacion.Text)); //feb 1.7
                        cargarSolapaFacturacion();
                        clearFormItem();
                    }
                    else
                    {
                        MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Facturación");
                    }
                }
                else
                {
                    if (validarNulidadDatosForm2(ref msg, cbhSoloRemito.Checked))
                    {
                        _remito.generar(formToObjectFact());
                        cargarSolapaRemito();
                        clearFormItem();
                    }
                    else
                    {
                        MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Facturación");
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

        private void habilitarFacturacion()
        {
            btnImprimirFactura.Enabled = true;
            btnVistaPreliminarFactura.Enabled = true;
            btnImprimirRemito.Enabled = true;
            btnVistaPreliminarRemito.Enabled = true;
            btnCambiarFactura.Enabled = true;
            btnCambiarRemito.Enabled = true;
            btnRegistrar.Enabled = true;
            btnBorrar.Enabled = false;
            pnlIzquierda2.Enabled = false;
            lblVistaPreliminar.Text = "Vista Definitiva";
        }

        private void deshabilitarFacturacion()
        {
            btnImprimirFactura.Enabled = false;
            btnVistaPreliminarFactura.Enabled = false;
            btnImprimirRemito.Enabled = false;
            btnVistaPreliminarRemito.Enabled = false;
            btnCambiarFactura.Enabled = false;
            btnCambiarRemito.Enabled = false;
            btnRegistrar.Enabled = false;
            btnBorrar.Enabled = true;
            pnlIzquierda2.Enabled = true;
            lblVistaPreliminar.Text = "Vista Preliminar";
        }

        //feb 1.9.1
        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if ((_factura.GridDataList.Count >= 1 || _remito.GridDataList.Count >= 1) && lblVistaPreliminar.Text != "Vista Definitiva") //feb 1.9.1
            {
                //DialogResult dialogResult = MessageBox.Show("¿Desea cambiar a vista definitiva de factura? Tenga en cuenta que ya no podrá modificar o borrar las facturas pendientes.", "Facturación", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                habilitarFacturacion();
                //}
            }
        }

        //feb 1.9.1
        private void btnCambiarRemito_Click(object sender, EventArgs e)
        {
            if ((_factura.GridDataList.Count >= 1 || _remito.GridDataList.Count >= 1) && txtNroRemito.Text != "")
            {
                registrarAnularGenerarRemito(0);
            }
        }

        private void btnCambiarFactura_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 1)
            {
                registrarAnularGenerar(0);
            }
        }

        //feb 1.9.1
        private void registrarAnularGenerarRemito(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular el remito actual y generar uno nuevo?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!(_remito.GridDataList.Count > 0))
                    {
                        _factura.registrarAnularRemito(_factura.GridDataList[posicion]);
                        cargarSolapaFacturacion();
                    }
                    else
                    {
                        _remito.registrarAnularRemito(_remito.GridDataList[posicion]);
                        cargarSolapaRemito();
                    }
                }
            }

            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Anular y Generar Remito");
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
                    cargarSolapaFacturacion();

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

        //feb 1.9.1
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar el comprobante pendiente de registrar?", "Comprobante", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!(_remito.GridDataList.Count > 0))
                    {
                        if (_factura.GridDataList.Count != 0)
                        {
                            _factura.delete();
                            cargarSolapaFacturacion();
                            objectToFormFact(new FacturaDTO());
                            deshabilitarDatosItem();
                            habilitarDatosCliente();
                        }
                        else
                        {
                            MessageBox.Show("No existe comprobante pendiente por borrar.", "Comprobante");
                        }
                    }
                    else
                    {
                        _remito.delete();
                        cargarSolapaRemito();
                        objectToFormFact(new FacturaDTO());
                        deshabilitarDatosItem();
                        habilitarDatosCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Borrar comprobante pendiente");
            }
        }

        //feb 1.9.1
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_factura.GridDataList.Count == 0 && _remito.GridDataList.Count == 0)
                {
                    MessageBox.Show("No existe factura y remito pendiente por registrar.", "Comprobante"); //feb 1.9.1
                }

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar el comprobante?", "Comprobante", MessageBoxButtons.YesNo); //feb 1.9.1
                if (dialogResult == DialogResult.Yes)
                {

                    if (_factura.GridDataList.Count != 0)
                    {
                        _factura.refreshGridData();
                        _factura.registrar((List<FacturaDTO>)_factura.GridDataList);

                        cargarSolapaFacturacion();
                        objectToFormFact(new FacturaDTO());
                        deshabilitarFacturacion();
                        deshabilitarDatosItem();
                        habilitarDatosCliente();

                        MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
                    }

                    if (_remito.GridDataList.Count != 0)
                    {
                        _remito.refreshGridData();
                        _remito.registrarManual((List<RemitoDTO>)_remito.GridDataList); //feb 1.9.2

                        cargarSolapaRemito();
                        objectToFormRem(new RemitoDTO());
                        deshabilitarFacturacion();
                        deshabilitarDatosItem();
                        habilitarDatosCliente();

                        MessageBox.Show("La operación fue realizada con éxito.", "Remito");
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

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroFactura.Text != string.Empty) //feb 1.9.1
                {
                    string cod_remito = string.Empty;

                    if (txtNroRemito.Text != "")
                    {
                        cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito.Text);
                    }

                    frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                    formProcesamiento.Show();

                    if (_factura.GridDataList[0].Tipo_factura == 'A')
                    {
                        crFacturaA rptLista = null;
                        if (_factura.GridDataList[0].Iva105 == 'N')
                        {
                            rptLista = GenerarImpresionFacturaA.cargarReporte(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                        }
                        else
                        {
                            rptLista = GenerarImpresionFacturaA.cargarReporte105(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                        }
                        rptLista.PrintToPrinter(1, false, 1, 1);
                        rptLista.Dispose();
                    }
                    if (_factura.GridDataList[0].Tipo_factura == 'B')
                    {
                        crFacturaB rptLista = null;
                        if (_factura.GridDataList[0].Iva105 == 'N')
                        {
                            rptLista = GenerarImpresionFacturaB.cargarReporte(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                        }
                        else
                        {
                            rptLista = GenerarImpresionFacturaB.cargarReporte105(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                        }
                        rptLista.PrintToPrinter(1, false, 1, 1);
                        rptLista.Dispose();
                    }

                    formProcesamiento.Dispose();
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
        private void btnImprimirRemito_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroRemito.Text != "")
                {
                    string cod_factura = string.Empty;

                    if (txtNroFactura.Text != "")
                    {
                        if (lblTipoFactura.Text == "A")
                        {
                            cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura.Text);
                        }
                        if (lblTipoFactura.Text == "B")
                        {
                            cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura.Text);
                        }

                        frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                        formProcesamiento.Show();
                        crRemito rptLista = GenerarImpresionRemito.cargarReporte(_factura.GridDataList[0].Id, cod_factura);
                        rptLista.PrintToPrinter(1, false, 1, 1);
                        rptLista.Dispose();
                        formProcesamiento.Dispose();
                    }
                    else
                    {
                        frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                        formProcesamiento.Show();
                        crRemito rptLista = GenerarImpresionRemito.cargarReporteRemitoPendiente(_remito.GridDataList[0].Id, cod_factura);
                        rptLista.PrintToPrinter(1, false, 1, 1);
                        rptLista.Dispose();
                        formProcesamiento.Dispose();
                    }
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

        private void txtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    cbxProducto.Text = ProductoDTO.obtenerDescripcion(txtCodigoDeBarras.Text);
                    if (cbxProducto.Text != string.Empty)
                    {
                        Decimal precioUnitario = PrecioDTO.buscarPrecio(formToObjectPrecio());
                        if (precioUnitario != -1 && txtCantidad.Text != "")
                        {
                            txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioUnitario, 2, MidpointRounding.AwayFromZero));
                            txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * precioUnitario, 2, MidpointRounding.AwayFromZero));
                            string msg = "";
                            if (hayStock(ref msg))
                            {
                                if (!cbhSoloRemito.Checked)
                                {
                                    _factura.generar(formToObjectFact(), decimal.Parse(txtPorcentajeDeBonificacion.Text)); //feb 1.7
                                    cargarSolapaFacturacion();
                                    clearFormItem();
                                }
                                else
                                {
                                    _remito.generar(formToObjectFact());
                                    cargarSolapaRemito();
                                    clearFormItem();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Facturación");
                            }
                        }
                        else
                        {
                            txtPrecioUnitario.Text = "";
                            txtImporte.Text = "";
                            cbxProducto.Text = "";
                            MessageBox.Show("No se ha cargado un precio para los valores ingresados. Verifique Cantidad, Artículo, Medida de cubierta o Trabajo/Servicio", "Facturación");
                        }
                    }
                    else
                    {
                        txtPrecioUnitario.Text = "";
                        txtImporte.Text = "";
                        cbxProducto.Text = "";
                        MessageBox.Show("El código de barra no está registrado en el sistema.", "Facturación");
                    }
                    txtCodigoDeBarras.Focus();
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación de Facturación");
                }
            }
        }

        private void cbxCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cbxProducto.Text != string.Empty)
                    {
                        Decimal precioUnitario = PrecioDTO.buscarPrecio(formToObjectPrecio());
                        if (precioUnitario != -1 && txtCantidad.Text != "")
                        {
                            txtPrecioUnitario.Text = String.Format("{0:0.00}", Math.Round(precioUnitario, 2, MidpointRounding.AwayFromZero));
                            txtImporte.Text = String.Format("{0:0.00}", Math.Round(int.Parse(txtCantidad.Text) * precioUnitario, 2, MidpointRounding.AwayFromZero));
                            string msg = "";
                            if (hayStock(ref msg))
                            {
                                if (!cbhSoloRemito.Checked)
                                {
                                    _factura.generar(formToObjectFact(), decimal.Parse(txtPorcentajeDeBonificacion.Text)); //feb 1.7
                                    cargarSolapaFacturacion();
                                    clearFormItem();
                                }
                                else
                                {
                                    _remito.generar(formToObjectFact());
                                    cargarSolapaRemito();
                                    clearFormItem();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Facturación");
                            }
                        }
                        else
                        {
                            txtPrecioUnitario.Text = "";
                            txtImporte.Text = "";
                            cbxProducto.Text = "";
                            MessageBox.Show("No se ha cargado un precio para los valores ingresados. Verifique Cantidad, Artículo, Medida de cubierta o Trabajo/Servicio", "Facturación");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string inner = "";
                    if (ex.InnerException != null)
                        inner = ex.InnerException.Message;
                    MessageBox.Show(ex.Message + ' ' + inner, "Validación de Facturación");
                }
            }
        }

        private void btnVistaPreliminarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroRemito.Text != "")
                {
                    string cod_factura = string.Empty;

                    if (txtNroFactura.Text != "")
                    {

                        if (lblTipoFactura.Text == "A")
                        {
                            cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura.Text);
                        }
                        if (lblTipoFactura.Text == "B")
                        {
                            cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura.Text);
                        }

                        frmVerRemito frmReporte = new frmVerRemito();
                        crRemito rptLista = GenerarImpresionRemito.cargarReporte(_factura.GridDataList[0].Id, cod_factura);
                        frmReporte.crvRemito.ReportSource = rptLista;
                        frmReporte.ShowDialog();
                        rptLista.Dispose();
                        frmReporte.Dispose();
                    }
                    else
                    {
                        frmVerRemito frmReporte = new frmVerRemito();
                        crRemito rptLista = GenerarImpresionRemito.cargarReporteRemitoPendiente(_remito.GridDataList[0].Id, cod_factura);
                        frmReporte.crvRemito.ReportSource = rptLista;
                        frmReporte.ShowDialog();
                        rptLista.Dispose();
                        frmReporte.Dispose();
                    }

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

        private void btnVistaPreliminarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroFactura.Text != string.Empty) //feb 1.9.1
                {
                    string cod_remito = string.Empty;
                    if (txtNroRemito.Text != "")
                    {
                        cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito.Text);
                    }

                    if (_factura.GridDataList[0].Tipo_factura == 'A')
                    {
                        frmVerFacturaA frmReporte = new frmVerFacturaA();
                        crFacturaA rptLista = null;
                        if (_factura.GridDataList[0].Iva105 == 'N')
                        {
                            rptLista = GenerarImpresionFacturaA.cargarReporte(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                            frmReporte.crvFacturaA.ReportSource = rptLista;
                        }
                        else
                        {
                            rptLista = GenerarImpresionFacturaA.cargarReporte105(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                            frmReporte.crvFacturaA.ReportSource = rptLista;
                        }
                        frmReporte.ShowDialog();
                        rptLista.Dispose();
                        frmReporte.Dispose();
                    }
                    if (_factura.GridDataList[0].Tipo_factura == 'B')
                    {
                        frmVerFacturaB frmReporte = new frmVerFacturaB();
                        crFacturaB rptLista = null;
                        if (_factura.GridDataList[0].Iva105 == 'N')
                        {
                            rptLista = GenerarImpresionFacturaB.cargarReporte(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                            frmReporte.crvFacturaB.ReportSource = rptLista;
                        }
                        else
                        {
                            rptLista = GenerarImpresionFacturaB.cargarReporte105(string.Empty, _factura.GridDataList[0].Id, cod_remito);
                            frmReporte.crvFacturaB.ReportSource = rptLista;
                        }
                        frmReporte.ShowDialog();
                        rptLista.Dispose();
                        frmReporte.Dispose();
                    }
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

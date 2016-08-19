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
    public partial class frmFacturacion : Form
    {
        private Clientes _clientes;
        private MedidaCubierta _medidas;
        private Servicio _servicios;
        private Marca _marcas;
        private Orden _orden;
        private OrdenDetalle _ordenDetalle;
        private FiltrosOrden _filtrosOrden;
        private Factura _factura;
        private List<OrdenDetalleDTO> OrdenToProcess;
        private FacturaDetalle _facturaDetalle;
        private MotivoDescuento _motivoDescuento;
        private List<OrdenDetalleDTO> OrdenChecking;
        private List<OrdenDetalleDTO> OrdenCheckingX;

        public frmFacturacion()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _medidas = new MedidaCubierta();
            _marcas = new Marca();
            _servicios = new Servicio();
            _orden = new Orden();
            _ordenDetalle = new OrdenDetalle();
            _filtrosOrden = new FiltrosOrden();
            _factura = new Factura();
            OrdenToProcess = new List<OrdenDetalleDTO>();
            _facturaDetalle = new FacturaDetalle();
            _motivoDescuento = new MotivoDescuento();
            OrdenChecking = new List<OrdenDetalleDTO>();
            OrdenCheckingX = new List<OrdenDetalleDTO>();
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

        private void FilterToObjectOrden()
        {
            _filtrosOrden.FiltroCodCliente = this.cbxFiltroCodCliente.Text;
            _filtrosOrden.FiltroNombreCliente = this.cbxFiltroNombreDeCliente.Text;
            _filtrosOrden.FiltroNroOrden = this.cbxFiltroNroDeOrden.Text;
        }

        private void FilterToObjectOrdenFalse()
        {
            _filtrosOrden.FiltroCodCliente = "XXXXXXXX";
            _filtrosOrden.FiltroNombreCliente = "XXXXXXXXXXXXXXX";
            _filtrosOrden.FiltroNroOrden = "99999999";
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

        private void configurarGridDetalleTrabajo()
        {
            this.dgvOrdenesDeTrabajo.AutoGenerateColumns = false;

            //tengo 10
            //DataGridViewColumnHeaderCell datagridViewCheckBoxHeaderCell = new DataGridViewColumnHeaderCell();

            DataGridViewCheckBoxColumn procesar = new DataGridViewCheckBoxColumn();
            //procesar.HeaderText = "P.";
            procesar.CellTemplate = new DataGridViewCheckboxCellFilter();
            procesar.Width = 26;
            procesar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            procesar.ReadOnly = false;

            DataGridViewCheckBoxColumn _soloFactura = new DataGridViewCheckBoxColumn();
            _soloFactura.HeaderText = "SF";
            _soloFactura.CellTemplate = new DataGridViewCheckboxCellFilter();
            _soloFactura.Width = 26;
            _soloFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _soloFactura.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _soloFactura.ReadOnly = false;

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
            _coche.Width = 85;
            _coche.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.ReadOnly = true;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 101;
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
            _trabajoColum.Width = 84;
            _trabajoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _precioSinIvaColum = new DataGridViewTextBoxColumn();
            _precioSinIvaColum.DataPropertyName = "v_precioSIva";
            _precioSinIvaColum.HeaderText = "Total s/iva";
            _precioSinIvaColum.Width = 84;
            _precioSinIvaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioSinIvaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioSinIvaColum.ReadOnly = true;


            this.dgvOrdenesDeTrabajo.Columns.Add(procesar);
            this.dgvOrdenesDeTrabajo.Columns.Add(_nroDeOrdenColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_nroRenglonColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_coche);
            this.dgvOrdenesDeTrabajo.Columns.Add(_medidaCubiertaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_marcaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_NroSerieColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_internoColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_trabajoColum);
            //this.dgvOrdenesDeTrabajo.Columns.Add(_precioListaColum);
            //this.dgvOrdenesDeTrabajo.Columns.Add(_precioListaAdiColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_precioSinIvaColum);
            this.dgvOrdenesDeTrabajo.Columns.Add(_soloFactura);
            show_chkBox();

        }

        private void cargarFiltroCompleto()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDeCliente.DataSource = _clientes.NombreDataList;

            _orden.refreshOwnData();
            this.cbxFiltroNroDeOrden.DataSource = _orden.OwnDataList;
        }


        private void cargarFiltroOrden()
        {
            _orden.refreshOwnData();
            this.cbxFiltroNroDeOrden.DataSource = null;
            this.cbxFiltroNroDeOrden.DataSource = _orden.OwnDataList;
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

        private void frmFacturacion_Load(object sender, EventArgs e)
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
            FilterToObjectOrdenFalse();
            txtPorcentajeDeBonificacion.Text = "0"; //feb 1.7

            //configuracion derecha
            configurarGridDetalleFactura();
            configurarGridDetalleFactura2();
            configurarGridDetalleFactura3();
            configurarGridDetalleFactura4();
            configurarGridDetalleFactura5();
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

        //feb
        private void show_chkBox()
        {
            Rectangle rect = dgvOrdenesDeTrabajo.GetCellDisplayRectangle(0, -1, true);

            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4);
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            //dgvOrdenesDeTrabajo[0, 0].ToolTipText = "P.";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.BackColor = dgvOrdenesDeTrabajo.RowHeadersDefaultCellStyle.BackColor;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dgvOrdenesDeTrabajo.Controls.Add(checkboxHeader);
        }

        //feb
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerBox = ((CheckBox)dgvOrdenesDeTrabajo.Controls.Find("checkboxHeader", true)[0]);

            int valor;

            if (headerBox.Checked)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }

            for (int i = 0; i < dgvOrdenesDeTrabajo.RowCount; i++)
            {

                dgvOrdenesDeTrabajo.Rows[i].Cells[0].Value = valor;

            }

            dgvOrdenesDeTrabajo.EndEdit();

        }

        private void cargarOrdenToProcess()
        {
            //aquellas ordenes que pertenecen a facturas temporales.
            _ordenDetalle.refreshOrdenToProcess();
            OrdenToProcess.Clear();
            if (_ordenDetalle.PendienteDataList != null)
            {
                OrdenToProcess = _ordenDetalle.PendienteDataList;
            }
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

        private void cargarGridDetalleTrabajo()
        {
            _ordenDetalle.refreshGridDataRegistrado(_filtrosOrden);
            this.dgvOrdenesDeTrabajo.DataSource = _ordenDetalle.GridDataList;
            this.dgvOrdenesDeTrabajo.Font = txtCoche.Font;
            dgvOrdenesDeTrabajo.ClearSelection();
            ((CheckBox)dgvOrdenesDeTrabajo.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        private void cargarSolapaFacturacion(int posicion)
        {

            int nroSolapa = 1;
            _factura.refreshGridData();

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

                    if (nroSolapa == 2)
                    {
                        this.objectToFormFact2(row);

                        _facturaDetalle.refreshGridData(row.Id);
                        this.dgvDetalleFactura2.DataSource = _facturaDetalle.GridDataList;
                        this.dgvDetalleFactura2.Font = txtCoche.Font;
                        this.dgvDetalleFactura2.ClearSelection();
                        this.txtRenglones2.Text = dgvDetalleFactura2.RowCount.ToString();

                    }

                    if (nroSolapa == 3)
                    {
                        this.objectToFormFact3(row);

                        _facturaDetalle.refreshGridData(row.Id);
                        this.dgvDetalleFactura3.DataSource = _facturaDetalle.GridDataList;
                        this.dgvDetalleFactura3.Font = txtCoche.Font;
                        this.dgvDetalleFactura3.ClearSelection();
                        this.txtRenglones3.Text = dgvDetalleFactura3.RowCount.ToString();

                        this.tbpNroFactura3.Focus();

                    }

                    if (nroSolapa == 4)
                    {
                        this.objectToFormFact4(row);

                        _facturaDetalle.refreshGridData(row.Id);
                        this.dgvDetalleFactura4.DataSource = _facturaDetalle.GridDataList;
                        this.dgvDetalleFactura4.Font = txtCoche.Font;
                        this.dgvDetalleFactura4.ClearSelection();
                        this.txtRenglones4.Text = dgvDetalleFactura4.RowCount.ToString();

                        this.tbpNroFactura4.Focus();

                    }


                    if (nroSolapa == 5)
                    {
                        this.objectToFormFact5(row);

                        _facturaDetalle.refreshGridData(row.Id);
                        this.dgvDetalleFactura5.DataSource = _facturaDetalle.GridDataList;
                        this.dgvDetalleFactura5.Font = txtCoche.Font;
                        this.dgvDetalleFactura5.ClearSelection();
                        this.txtRenglones5.Text = dgvDetalleFactura5.RowCount.ToString();

                        this.tbpNroFactura5.Focus();

                    }

                    nroSolapa = nroSolapa + 1;

                }

            }
            else
            {
                this.txtRenglones.Text = string.Empty;
                this.txtRenglones2.Text = string.Empty;
                this.txtRenglones3.Text = string.Empty;
                this.txtRenglones4.Text = string.Empty;
                this.txtRenglones5.Text = string.Empty;
            }
            this.tbcFacturasPendientes.SelectedIndex = posicion;

        }


        private void configurarGridDetalleFactura4()
        {
            this.dgvDetalleFactura4.AutoGenerateColumns = false;

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

            this.dgvDetalleFactura4.Columns.Add(_cantidad);
            this.dgvDetalleFactura4.Columns.Add(_codigo);
            this.dgvDetalleFactura4.Columns.Add(_descripcion);
            this.dgvDetalleFactura4.Columns.Add(_precioUnitario);
            this.dgvDetalleFactura4.Columns.Add(_importe);

        }

        private void configurarGridDetalleFactura3()
        {
            this.dgvDetalleFactura3.AutoGenerateColumns = false;

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

            this.dgvDetalleFactura3.Columns.Add(_cantidad);
            this.dgvDetalleFactura3.Columns.Add(_codigo);
            this.dgvDetalleFactura3.Columns.Add(_descripcion);
            this.dgvDetalleFactura3.Columns.Add(_precioUnitario);
            this.dgvDetalleFactura3.Columns.Add(_importe);

        }

        private void configurarGridDetalleFactura2()
        {
            this.dgvDetalleFactura2.AutoGenerateColumns = false;

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

            this.dgvDetalleFactura2.Columns.Add(_cantidad);
            this.dgvDetalleFactura2.Columns.Add(_codigo);
            this.dgvDetalleFactura2.Columns.Add(_descripcion);
            this.dgvDetalleFactura2.Columns.Add(_precioUnitario);
            this.dgvDetalleFactura2.Columns.Add(_importe);

        }

        private void configurarGridDetalleFactura5()
        {
            this.dgvDetalleFactura5.AutoGenerateColumns = false;

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

            this.dgvDetalleFactura5.Columns.Add(_cantidad);
            this.dgvDetalleFactura5.Columns.Add(_codigo);
            this.dgvDetalleFactura5.Columns.Add(_descripcion);
            this.dgvDetalleFactura5.Columns.Add(_precioUnitario);
            this.dgvDetalleFactura5.Columns.Add(_importe);

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



        private void objectToFormFact2(FacturaDTO data)
        {
            if (data.Nro_factura.ToString() != "-1")
            {
                this.tbpNroFactura2.Text = data.Nro_factura.ToString();
                this.txtNroFactura2.Text = data.Nro_factura.ToString();
                this.lblDatosDelCliente2.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura2.Text = data.Tipo_factura.ToString();
            }
            else
            {
                this.tbpNroFactura2.Text = "F2";
                this.txtNroFactura2.Text = "";
                this.lblDatosDelCliente2.Text = "";
                this.lblTipoFactura2.Text = "";
                _facturaDetalle.refreshGridData(data.Id);
                this.dgvDetalleFactura2.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito2.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito2.Text = "";
            }

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion2.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion2.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal2.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal2.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva2.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva2.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal2.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal2.Text = "";
            }
        }

        private void objectToFormFact3(FacturaDTO data)
        {
            if (data.Nro_factura.ToString() != "-1")
            {
                this.tbpNroFactura3.Text = data.Nro_factura.ToString();
                this.txtNroFactura3.Text = data.Nro_factura.ToString();
                this.lblDatosDelCliente3.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura3.Text = data.Tipo_factura.ToString();
            }
            else
            {
                this.tbpNroFactura3.Text = "F3";
                this.txtNroFactura3.Text = "";
                this.lblDatosDelCliente3.Text = "";
                this.lblTipoFactura3.Text = "";
                _facturaDetalle.refreshGridData(data.Id);
                this.dgvDetalleFactura3.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito3.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito3.Text = "";
            }

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion3.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion3.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal3.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal3.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva3.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva3.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal3.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal3.Text = "";
            }
        }

        private void objectToFormFact4(FacturaDTO data)
        {
            if (data.Nro_factura.ToString() != "-1")
            {
                this.tbpNroFactura4.Text = data.Nro_factura.ToString();
                this.txtNroFactura4.Text = data.Nro_factura.ToString();
                this.lblDatosDelCliente4.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura4.Text = data.Tipo_factura.ToString();
            }
            else
            {
                this.tbpNroFactura4.Text = "F4";
                this.txtNroFactura4.Text = "";
                this.lblDatosDelCliente4.Text = "";
                this.lblTipoFactura4.Text = "";
                _facturaDetalle.refreshGridData(data.Id);
                this.dgvDetalleFactura4.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito4.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito4.Text = "";
            }

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion4.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion4.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal4.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal4.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva4.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva4.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal4.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal4.Text = "";
            }
        }


        private void objectToFormFact5(FacturaDTO data)
        {
            if (data.Nro_factura.ToString() != "-1")
            {
                this.tbpNroFactura5.Text = data.Nro_factura.ToString();
                this.txtNroFactura5.Text = data.Nro_factura.ToString();
                this.lblDatosDelCliente5.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();

                this.lblTipoFactura5.Text = data.Tipo_factura.ToString();
            }
            else
            {
                this.tbpNroFactura5.Text = "F5";
                this.txtNroFactura5.Text = "";
                this.lblDatosDelCliente5.Text = "";
                this.lblTipoFactura5.Text = "";
                _facturaDetalle.refreshGridData(data.Id);
                this.dgvDetalleFactura5.DataSource = _facturaDetalle.GridDataList;
            }

            if (data.Nro_remito.ToString() != "-1")
            {
                this.txtNroRemito5.Text = data.Nro_remito.ToString();
            }
            else
            {
                this.txtNroRemito5.Text = "";
            }

            if (data.V_bonificacion.ToString() != String.Empty)
            {
                this.txtBonificacion5.Text = data.V_bonificacion.ToString();
            }
            else
            {
                this.txtBonificacion5.Text = "";
            }

            if (data.V_subtotal.ToString() != String.Empty)
            {
                this.txtSubtotal5.Text = data.V_subtotal.ToString();
            }
            else
            {
                this.txtSubtotal5.Text = "";
            }

            if (data.V_iva.ToString() != String.Empty)
            {
                this.txtIva5.Text = data.V_iva.ToString();
            }
            else
            {
                this.txtIva5.Text = "";
            }


            if (data.V_total.ToString() != String.Empty)
            {
                this.txtTotal5.Text = data.V_total.ToString();
            }
            else
            {
                this.txtTotal5.Text = "";
            }
        }

        private void cbhSinFacturar_CheckedChanged(object sender, EventArgs e)
        {

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

        private void cbxFiltroNroDeOrden_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.cbxFiltroNroDeOrden.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        //feb 1.7
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbxFiltroCodCliente.Text == "" && cbxFiltroNombreDeCliente.Text == "" && cbxFiltroNroDeOrden.Text == "")
            {
                FilterToObjectOrdenFalse();
            }
            else
            {
                FilterToObjectOrden();
            }

            cargarGridDetalleTrabajo();

            txtPorcentajeDeBonificacion.Text = "0";

            if (dgvOrdenesDeTrabajo.RowCount > 0)
            {
                if (cbxFiltroCodCliente.Text != string.Empty)
                {
                    txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(cbxFiltroCodCliente.Text).ToString();
                }
                if (cbxFiltroNombreDeCliente.Text != string.Empty && cbxFiltroCodCliente.Text == string.Empty)
                {
                    txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuentoPorNombre(cbxFiltroNombreDeCliente.Text).ToString();
                }
                if (cbxFiltroNroDeOrden.Text != string.Empty && cbxFiltroCodCliente.Text == string.Empty && cbxFiltroNombreDeCliente.Text == string.Empty)
                {
                    txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(OrdenDTO.obtenerCliente(long.Parse(cbxFiltroNroDeOrden.Text))).ToString();
                }
            }
            this.clearForm();
            deshabilitarFormOrdenes();
            btnProcesar.Enabled = true;
            pnlDerecho.Enabled = true;
            //this.cbxFiltroCodCliente.Focus();

        }

        //feb 1.7
        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxFiltroCodCliente.Text == "" && cbxFiltroNombreDeCliente.Text == "" && cbxFiltroNroDeOrden.Text == "")
                {
                    FilterToObjectOrdenFalse();
                }
                else
                {
                    FilterToObjectOrden();
                }

                cargarGridDetalleTrabajo();

                txtPorcentajeDeBonificacion.Text = "0";

                if (dgvOrdenesDeTrabajo.RowCount > 0)
                {
                    if (cbxFiltroCodCliente.Text != string.Empty)
                    {
                        txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(cbxFiltroCodCliente.Text).ToString();
                    }
                    if (cbxFiltroNombreDeCliente.Text != string.Empty && cbxFiltroCodCliente.Text == string.Empty)
                    {
                        txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuentoPorNombre(cbxFiltroNombreDeCliente.Text).ToString();
                    }
                    if (cbxFiltroNroDeOrden.Text != string.Empty && cbxFiltroCodCliente.Text == string.Empty && cbxFiltroNombreDeCliente.Text == string.Empty)
                    {
                        txtPorcentajeDeBonificacion.Text = ClienteDTO.obtenerDescuento(OrdenDTO.obtenerCliente(long.Parse(cbxFiltroNroDeOrden.Text))).ToString();
                    }
                }
                this.clearForm();
                deshabilitarFormOrdenes();
                btnProcesar.Enabled = true;
                pnlDerecho.Enabled = true;
                //this.cbxFiltroCodCliente.Focus();
            }
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            clearFilter();
            txtPorcentajeDeBonificacion.Text = "0"; //feb 1.7
            FilterToObjectOrdenFalse();
            cargarGridDetalleTrabajo();
            this.clearForm();
            deshabilitarFormOrdenes();
            this.cbxFiltroCodCliente.Focus();
            btnProcesar.Enabled = true;
        }

        private void clearFilter()
        {
            this.objectToFilterOrden(new FiltrosOrden());
        }

        private void objectToFilterOrden(FiltrosOrden filtro)
        {
            this.cbxFiltroCodCliente.Text = filtro.FiltroCodCliente;
            this.cbxFiltroNombreDeCliente.Text = filtro.FiltroNombreCliente;
            this.cbxFiltroNroDeOrden.Text = filtro.FiltroNroOrden;
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

            //if (this.txtCoche.Text == "")
            //{
            //    rv = false;
            //    msg += "\nDebe ingresar el Coche.";
            //}

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
                        if (OrdenDetalle.isValid(dataAux, data, ref msg))
                        {
                            bool ok = false;
                            this._ordenDetalle.update(data);
                            ok = true;

                            if (ok)
                            {
                                guardarChecks();                               
                                cargarGridDetalleTrabajo();
                                recuperarChecks();
                                this.clearForm();
                                this.pnlDerecho.Enabled = true;
                                this.btnProcesar.Enabled = true;
                                deshabilitarFormOrdenes();
                                //MessageBox.Show("La operación fue realizada con éxito.", "Ordenes de Trabajo");
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

        private void guardarChecks()
        {
            foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    OrdenChecking.Add((OrdenDetalleDTO)row.DataBoundItem);
                }

                DataGridViewCheckBoxCell chkX = (DataGridViewCheckBoxCell)row.Cells[10];
                if (chkX.Value.ToString() == "1")
                {
                    OrdenCheckingX.Add((OrdenDetalleDTO)row.DataBoundItem);
                }
            }
        }

        private void recuperarChecks()
        {
            foreach (OrdenDetalleDTO ord in OrdenChecking)
            {
                foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (ord.Id_orden_de_trabajo == ((OrdenDetalleDTO)row.DataBoundItem).Id_orden_de_trabajo && ord.Renglon == ((OrdenDetalleDTO)row.DataBoundItem).Renglon)
                    {
                        chk.Value = chk.TrueValue;
                        break;
                    }
                }
            }

            foreach (OrdenDetalleDTO ord in OrdenCheckingX)
            {
                foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
                {
                    DataGridViewCheckBoxCell chkX = (DataGridViewCheckBoxCell)row.Cells[10];
                    if (ord.Id_orden_de_trabajo == ((OrdenDetalleDTO)row.DataBoundItem).Id_orden_de_trabajo && ord.Renglon == ((OrdenDetalleDTO)row.DataBoundItem).Renglon)
                    {
                        chkX.Value = chkX.TrueValue;
                        break;
                    }
                }
            }

            OrdenChecking.Clear();
            OrdenCheckingX.Clear();
        }

        private void clearForm()
        {
            this.objectToForm(new OrdenDetalleDTO());
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

                bool haySeleccion = false;
                bool hayIncompatibilidad = false;

                cargarOrdenToProcess(); //ya tienen id_factura

                foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        //agrego los registros seleccionados
                        ((OrdenDetalleDTO)row.DataBoundItem).Es_nuevo = 'S';

                        DataGridViewCheckBoxCell chkSolo = (DataGridViewCheckBoxCell)row.Cells[10];
                        if (chkSolo.Value.ToString() == "1")
                        {
                            ((OrdenDetalleDTO)row.DataBoundItem).Solo_factura = 'S';
                        }
                        else
                        {
                            ((OrdenDetalleDTO)row.DataBoundItem).Solo_factura = 'N';
                        }

                        OrdenToProcess.Add((OrdenDetalleDTO)row.DataBoundItem);
                        haySeleccion = true;
                    }
                }

                if (!haySeleccion)
                {
                    MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Facturación");
                }
                else
                {
                    char patron = OrdenToProcess[0].Solo_factura;

                    foreach (OrdenDetalleDTO orden in OrdenToProcess)
                    {
                        if (orden.Solo_factura != patron)
                        {
                            hayIncompatibilidad = true;
                        }
                    }

                    if (!hayIncompatibilidad)
                    {
                        if (_factura.generar(OrdenToProcess, decimal.Parse(txtPorcentajeDeBonificacion.Text))) //feb 1.7
                        {
                            FacturaDTO.update_modo_temp(patron);
                            cargarGridDetalleTrabajo();
                            cargarSolapaFacturacion(0);
                            //MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay registros que son SOLO FACTURA y otro que NO. Por favor unifique el criterio. Verifique también el criterio en facturas pendientes de registrar.", "Facturación");
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

        private void lblDatosCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar las facturas pendientes de registrar?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_factura.GridDataList.Count != 0)
                    {
                        _factura.delete();

                        cargarGridDetalleTrabajo();
                        cargarSolapaFacturacion(0);
                        objectToFormFact(new FacturaDTO());
                        objectToFormFact2(new FacturaDTO());
                        objectToFormFact3(new FacturaDTO());
                        objectToFormFact4(new FacturaDTO());
                        objectToFormFact5(new FacturaDTO());

                        this.tbcFacturasPendientes.SelectedIndex = 0;

                        //MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
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

        private void pnlDerecho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar las facturas?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_factura.GridDataList.Count != 0)
                    {
                        _factura.refreshGridData();
                        _factura.registrar((List<FacturaDTO>)_factura.GridDataList);

                        cargarFiltroOrden();
                        cargarGridDetalleTrabajo();
                        cargarSolapaFacturacion(0);
                        objectToFormFact(new FacturaDTO());
                        objectToFormFact2(new FacturaDTO());
                        objectToFormFact3(new FacturaDTO());
                        objectToFormFact4(new FacturaDTO());
                        objectToFormFact5(new FacturaDTO());

                        this.tbcFacturasPendientes.SelectedIndex = 0;
                        txtPorcentajeDeBonificacion.Text = "0"; //feb 1.7
                        deshabilitarFacturacion();
                        MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
                    }
                    else
                    {
                        MessageBox.Show("No existen facturas pendientes por registrar.", "Facturación");
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

        private void btnX_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtPorcentajeAPagar.Text) < 100 && int.Parse(txtPorcentajeAPagar.Text) > 0)
            {
                cbxMotivoDescuento.Text = "BONIFICACION";
            }
            if (int.Parse(txtPorcentajeAPagar.Text) == 0)
            {
                cbxMotivoDescuento.Text = "SIN CARGO";
            }
            if (int.Parse(txtPorcentajeAPagar.Text) >= 100)
            {
                cbxMotivoDescuento.Text = "";
            }
        }



        private void registrarAnularGenerarRemito(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular el remito actual y generar uno nuevo?", "Facturación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    _factura.registrarAnularRemito(_factura.GridDataList[posicion]);
                    cargarSolapaFacturacion(posicion);

                    //MessageBox.Show("La operación fue realizada con éxito.", "Facturación");
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

        private void btnCambiarFactura2_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 2)
            {
                registrarAnularGenerar(1);
            }
        }

        private void btnCambiarFactura3_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 3)
            {
                registrarAnularGenerar(2);
            }
        }

        private void btnCambiarFactura4_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 4)
            {
                registrarAnularGenerar(3);
            }
        }

        private void btnCambiarFactura5_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 5)
            {
                registrarAnularGenerar(4);
            }
        }

        private void btnCambiarRemito_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 1 && txtNroRemito.Text != "")
            {
                registrarAnularGenerarRemito(0);
            }
        }

        private void btnCambiarRemito2_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 2 && txtNroRemito2.Text != "")
            {
                registrarAnularGenerarRemito(1);
            }
        }

        private void btnCambiarRemito3_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 3 && txtNroRemito3.Text != "")
            {
                registrarAnularGenerarRemito(2);
            }
        }

        private void btnCambiarRemito4_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 4 && txtNroRemito4.Text != "")
            {
                registrarAnularGenerarRemito(3);
            }
        }

        private void btnCambiarRemito5_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 5 && txtNroRemito5.Text != "")
            {
                registrarAnularGenerarRemito(4);
            }
        }

        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if (_factura.GridDataList.Count >= 1 && lblVistaPreliminar.Text != "Vista Definitiva")
            {
                habilitarFacturacion();
            }
        }

        private void habilitarFacturacion()
        {
            btnImprimirFactura.Enabled = true;
            btnImprimirFactura2.Enabled = true;
            btnImprimirFactura3.Enabled = true;
            btnImprimirFactura4.Enabled = true;
            btnImprimirFactura5.Enabled = true;
            btnVistaPreliminarFactura.Enabled = true;
            btnVistaPreliminarFactura2.Enabled = true;
            btnVistaPreliminarFactura3.Enabled = true;
            btnVistaPreliminarFactura4.Enabled = true;
            btnVistaPreliminarFactura5.Enabled = true;
            btnImprimirRemito.Enabled = true;
            btnImprimirRemito2.Enabled = true;
            btnImprimirRemito3.Enabled = true;
            btnImprimirRemito4.Enabled = true;
            btnImprimirRemito5.Enabled = true;
            btnVistaPreliminarRemito.Enabled = true;
            btnVistaPreliminarRemito2.Enabled = true;
            btnVistaPreliminarRemito3.Enabled = true;
            btnVistaPreliminarRemito4.Enabled = true;
            btnVistaPreliminarRemito5.Enabled = true;
            btnCambiarFactura.Enabled = true;
            btnCambiarFactura2.Enabled = true;
            btnCambiarFactura3.Enabled = true;
            btnCambiarFactura4.Enabled = true;
            btnCambiarFactura5.Enabled = true;
            btnCambiarRemito.Enabled = true;
            btnCambiarRemito2.Enabled = true;
            btnCambiarRemito3.Enabled = true;
            btnCambiarRemito4.Enabled = true;
            btnCambiarRemito5.Enabled = true;
            btnRegistrar.Enabled = true;
            btnBorrar.Enabled = false;
            pnlIzquierda.Enabled = false;
            lblVistaPreliminar.Text = "Vista Definitiva";
        }

        private void deshabilitarFacturacion()
        {
            btnImprimirFactura.Enabled = false;
            btnImprimirFactura2.Enabled = false;
            btnImprimirFactura3.Enabled = false;
            btnImprimirFactura4.Enabled = false;
            btnImprimirFactura5.Enabled = false;
            btnVistaPreliminarFactura.Enabled = false;
            btnVistaPreliminarFactura2.Enabled = false;
            btnVistaPreliminarFactura3.Enabled = false;
            btnVistaPreliminarFactura4.Enabled = false;
            btnVistaPreliminarFactura5.Enabled = false;
            btnImprimirRemito.Enabled = false;
            btnImprimirRemito2.Enabled = false;
            btnImprimirRemito3.Enabled = false;
            btnImprimirRemito4.Enabled = false;
            btnImprimirRemito5.Enabled = false;
            btnVistaPreliminarRemito.Enabled = false;
            btnVistaPreliminarRemito2.Enabled = false;
            btnVistaPreliminarRemito3.Enabled = false;
            btnVistaPreliminarRemito4.Enabled = false;
            btnVistaPreliminarRemito5.Enabled = false;
            btnCambiarFactura.Enabled = false;
            btnCambiarFactura2.Enabled = false;
            btnCambiarFactura3.Enabled = false;
            btnCambiarFactura4.Enabled = false;
            btnCambiarFactura5.Enabled = false;
            btnCambiarRemito.Enabled = false;
            btnCambiarRemito2.Enabled = false;
            btnCambiarRemito3.Enabled = false;
            btnCambiarRemito4.Enabled = false;
            btnCambiarRemito5.Enabled = false;
            btnRegistrar.Enabled = false;
            btnBorrar.Enabled = true;
            pnlIzquierda.Enabled = true;
            lblVistaPreliminar.Text = "Vista Preliminar";
        }

        private void btnImprimirRemito_Click(object sender, EventArgs e)
        {
            if (txtNroRemito.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura.Text);
                }
                if (lblTipoFactura.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura.Text);
                }
                imprimirRemito(0, cod_factura);
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

        private void imprimirRemito(int posicion, string cod_factura)
        {
            try
            {
                frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                formProcesamiento.Show();
                crRemito rptLista = GenerarImpresionRemito.cargarReporte(_factura.GridDataList[posicion].Id, cod_factura);
                rptLista.PrintToPrinter(1, false, 1, 1);
                rptLista.Dispose();
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

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            if (txtNroFactura.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito.Text);
                }
                imprimirFactura(0, cod_remito);
            }
        }

        private void btnImprimirFactura2_Click(object sender, EventArgs e)
        {
            if (txtNroFactura2.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito2.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito2.Text);
                }
                imprimirFactura(1, cod_remito);
            }
        }

        private void btnImprimirFactura3_Click(object sender, EventArgs e)
        {
            if (txtNroFactura3.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito3.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito3.Text);
                }
                imprimirFactura(2, cod_remito);
            }
        }

        private void btnImprimirFactura4_Click(object sender, EventArgs e)
        {
            if (txtNroFactura4.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito4.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito4.Text);
                }
                imprimirFactura(3, cod_remito);
            }
        }

        private void btnImprimirFactura5_Click(object sender, EventArgs e)
        {
            if (txtNroFactura5.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito5.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito5.Text);
                }
                imprimirFactura(4, cod_remito);
            }
        }

        private void btnImprimirRemito2_Click(object sender, EventArgs e)
        {
            if (txtNroRemito2.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura2.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura2.Text);
                }
                if (lblTipoFactura2.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura2.Text);
                }
                imprimirRemito(1, cod_factura);
            }
        }

        private void btnImprimirRemito3_Click(object sender, EventArgs e)
        {
            if (txtNroRemito3.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura3.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura3.Text);
                }
                if (lblTipoFactura3.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura3.Text);
                }
                imprimirRemito(2, cod_factura);
            }
        }

        private void btnImprimirRemito4_Click(object sender, EventArgs e)
        {
            if (txtNroRemito4.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura4.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura4.Text);
                }
                if (lblTipoFactura4.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura4.Text);
                }
                imprimirRemito(3, cod_factura);
            }
        }

        private void btnImprimirRemito5_Click(object sender, EventArgs e)
        {
            if (txtNroRemito5.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura5.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura5.Text);
                }
                if (lblTipoFactura5.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura5.Text);
                }
                imprimirRemito(4, cod_factura);
            }
        }

        private void btnVistaPreliminarRemito_Click(object sender, EventArgs e)
        {
            if (txtNroRemito.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura.Text);
                }
                if (lblTipoFactura.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura.Text);
                }
                vistaPreliminarRemito(0, cod_factura);
            }
        }

        private void vistaPreliminarRemito(int posicion, string cod_factura)
        {
            try
            {
                frmVerRemito frmReporte = new frmVerRemito();
                crRemito rptLista = GenerarImpresionRemito.cargarReporte(_factura.GridDataList[posicion].Id, cod_factura);
                frmReporte.crvRemito.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
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
            if (txtNroFactura.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito.Text);
                }
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

        private void btnVistaPreliminarRemito2_Click(object sender, EventArgs e)
        {
            if (txtNroRemito2.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura2.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura2.Text);
                }
                if (lblTipoFactura2.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura2.Text);
                }
                vistaPreliminarRemito(1, cod_factura);
            }
        }

        private void btnVistaPreliminarRemito3_Click(object sender, EventArgs e)
        {
            if (txtNroRemito3.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura3.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura3.Text);
                }
                if (lblTipoFactura3.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura3.Text);
                }
                vistaPreliminarRemito(2, cod_factura);
            }
        }

        private void btnVistaPreliminarRemito4_Click(object sender, EventArgs e)
        {
            if (txtNroRemito4.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura4.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura4.Text);
                }
                if (lblTipoFactura4.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura4.Text);
                }
                vistaPreliminarRemito(3, cod_factura);
            }
        }

        private void btnVistaPreliminarRemito5_Click(object sender, EventArgs e)
        {
            if (txtNroRemito5.Text != "")
            {
                string cod_factura = string.Empty;

                if (lblTipoFactura5.Text == "A")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaA(txtNroFactura5.Text);
                }
                if (lblTipoFactura5.Text == "B")
                {
                    cod_factura = ComprobanteDTO.converToNroFacturaB(txtNroFactura5.Text);
                }
                vistaPreliminarRemito(4, cod_factura);
            }
        }

        private void btnVistaPreliminarFactura2_Click(object sender, EventArgs e)
        {
            if (txtNroFactura2.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito2.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito2.Text);
                }
                vistaPreliminarFactura(1, cod_remito);
            }
        }

        private void btnVistaPreliminarFactura3_Click(object sender, EventArgs e)
        {
            if (txtNroFactura3.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito3.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito3.Text);
                }
                vistaPreliminarFactura(2, cod_remito);
            }
        }

        private void btnVistaPreliminarFactura4_Click(object sender, EventArgs e)
        {
            if (txtNroFactura4.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito4.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito4.Text);
                }
                vistaPreliminarFactura(3, cod_remito);
            }
        }

        private void btnVistaPreliminarFactura5_Click(object sender, EventArgs e)
        {
            if (txtNroFactura5.Text != "")
            {
                string cod_remito = string.Empty;
                if (txtNroRemito5.Text != "")
                {
                    cod_remito = ComprobanteDTO.converToNroRemito(txtNroRemito5.Text);
                }
                vistaPreliminarFactura(4, cod_remito);
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

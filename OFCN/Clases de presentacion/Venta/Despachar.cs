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
    public partial class frmDespachar : Form
    {
        private Clientes _clientes;
        private MedidaCubierta _medidas;
        private Servicio _servicios;
        private Marca _marcas;
        private Orden _orden;
        private OrdenDetalle _ordenDetalle;
        private FiltrosOrden _filtrosOrden;
        private Remito _remito;
        private List<OrdenDetalleDTO> OrdenToProcess;
        private RemitoDetalle _remitoDetalle;
        private MotivoDescuento _motivoDescuento;
        private List<OrdenDetalleDTO> OrdenChecking;

        public frmDespachar()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _medidas = new MedidaCubierta();
            _marcas = new Marca();
            _servicios = new Servicio();
            _orden = new Orden();
            _ordenDetalle = new OrdenDetalle();
            _filtrosOrden = new FiltrosOrden();
            _remito = new Remito();
            OrdenToProcess = new List<OrdenDetalleDTO>();
            _remitoDetalle = new RemitoDetalle();
            _motivoDescuento = new MotivoDescuento();
            OrdenChecking = new List<OrdenDetalleDTO>();
        }

        private void frmDespachar_Load(object sender, EventArgs e)
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

            configurarGridDetalleRemito();
            configurarGridDetalleRemito2();
            configurarGridDetalleRemito3();
            configurarGridDetalleRemito4();
            configurarGridDetalleRemito5();
            cargarSolapaRemito(0);

            if (_remito.GridDataList.Count > 0) //si hay datos
            {
                habilitarDespachar();
            }
            else
            {
                deshabilitarDespachar();
            }
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
            _trabajoColum.Width = 110;
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
            this.dgvOrdenesDeTrabajo.Columns.Add(_precioSinIvaColum);
            show_chkBox();

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
            this.chbDesglosarEnRemito.Enabled = false;
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
            this.chbDesglosarEnRemito.Enabled = true;
        }

        private void FilterToObjectOrdenFalse()
        {
            _filtrosOrden.FiltroCodCliente = "XXXXXXXX";
            _filtrosOrden.FiltroNombreCliente = "XXXXXXXXXXXXXXX";
            _filtrosOrden.FiltroNroOrden = "99999999";
        }

        private void FilterToObjectOrden()
        {
            _filtrosOrden.FiltroCodCliente = this.cbxFiltroCodCliente.Text;
            _filtrosOrden.FiltroNombreCliente = this.cbxFiltroNombreDeCliente.Text;
            _filtrosOrden.FiltroNroOrden = this.cbxFiltroNroDeOrden.Text;
        }

        private void cargarFiltroOrden()
        {
            _orden.refreshOwnData();
            this.cbxFiltroNroDeOrden.DataSource = null;
            this.cbxFiltroNroDeOrden.DataSource = _orden.OwnDataList;
        }

        private void configurarGridDetalleRemito()
        {
            this.dgvDetalleRemito.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 45;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 55;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 490;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvDetalleRemito.Columns.Add(_cantidad);
            this.dgvDetalleRemito.Columns.Add(_codigo);
            this.dgvDetalleRemito.Columns.Add(_descripcion);
        }

        private void configurarGridDetalleRemito2()
        {
            this.dgvDetalleRemito2.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 45;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 55;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 490;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvDetalleRemito2.Columns.Add(_cantidad);
            this.dgvDetalleRemito2.Columns.Add(_codigo);
            this.dgvDetalleRemito2.Columns.Add(_descripcion);
        }

        private void configurarGridDetalleRemito3()
        {
            this.dgvDetalleRemito3.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 45;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 55;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 490;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvDetalleRemito3.Columns.Add(_cantidad);
            this.dgvDetalleRemito3.Columns.Add(_codigo);
            this.dgvDetalleRemito3.Columns.Add(_descripcion);
        }

        private void configurarGridDetalleRemito4()
        {
            this.dgvDetalleRemito4.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 45;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 55;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 490;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvDetalleRemito4.Columns.Add(_cantidad);
            this.dgvDetalleRemito4.Columns.Add(_codigo);
            this.dgvDetalleRemito4.Columns.Add(_descripcion);
        }

        private void configurarGridDetalleRemito5()
        {
            this.dgvDetalleRemito5.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _cantidad = new DataGridViewTextBoxColumn();
            _cantidad.DataPropertyName = "cantidad";
            _cantidad.HeaderText = "Cant.";
            _cantidad.Width = 45;
            _cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Cód.";
            _codigo.Width = 55;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 490;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvDetalleRemito5.Columns.Add(_cantidad);
            this.dgvDetalleRemito5.Columns.Add(_codigo);
            this.dgvDetalleRemito5.Columns.Add(_descripcion);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
            clearForm();
            deshabilitarFormOrdenes();
            btnProcesar.Enabled = true;
            pnlDerecho.Enabled = true;
        }


        private void cargarGridDetalleTrabajo()
        {
            _ordenDetalle.refreshGridDataRegistrado4(_filtrosOrden);
            this.dgvOrdenesDeTrabajo.DataSource = _ordenDetalle.GridDataList;
            this.dgvOrdenesDeTrabajo.Font = txtCoche.Font;
            dgvOrdenesDeTrabajo.ClearSelection();
            ((CheckBox)dgvOrdenesDeTrabajo.Controls.Find("checkboxHeader", true)[0]).Checked = false;
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
                this.chbDesglosarEnRemito.Checked = true;
            }
            else
            {
                this.chbDesglosarEnRemito.Checked = false;
            }

        }

        private void clearForm()
        {
            this.objectToForm(new OrdenDetalleDTO());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectOrdenFalse();
            cargarGridDetalleTrabajo();
            clearForm();
            deshabilitarFormOrdenes();
            cbxFiltroCodCliente.Focus();
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

                DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el registro de la orden?", "Órdenes de Trabajo", MessageBoxButtons.YesNo);
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
                            }
                        }
                        else
                        {
                            MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Órdenes de Trabajo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No ha sido posible guardar la orden de trabajo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Órdenes de Trabajo");
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

            if (this.chbDesglosarEnRemito.Checked)
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

        private void guardarChecks()
        {
            foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value.ToString() == "1")
                {
                    OrdenChecking.Add((OrdenDetalleDTO)row.DataBoundItem);
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


            OrdenChecking.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.clearForm();
            this.pnlDerecho.Enabled = true;
            this.btnProcesar.Enabled = true;
            deshabilitarFormOrdenes();
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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                bool haySeleccion = false;
                cargarOrdenToProcess(); //ya tienen id_remito

                foreach (DataGridViewRow row in this.dgvOrdenesDeTrabajo.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value.ToString() == "1")
                    {
                        //agrego los registros seleccionados
                        ((OrdenDetalleDTO)row.DataBoundItem).Es_nuevo = 'S';
                        OrdenToProcess.Add((OrdenDetalleDTO)row.DataBoundItem);
                        haySeleccion = true;
                    }
                }

                if (!haySeleccion)
                {
                    MessageBox.Show("Debe seleccionar al menos un registro de la grilla.", "Despachar cubiertas");
                }
                else
                {
                    if (_remito.generar(OrdenToProcess))
                    {
                        cargarGridDetalleTrabajo();
                        cargarSolapaRemito(0);
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Despachar cubiertas");
            }
        }

        private void cargarOrdenToProcess()
        {
            //aquellas ordenes que pertenecen a remitos temporales.
            _ordenDetalle.refreshOrdenToProcessRemito();
            OrdenToProcess.Clear();
            if (_ordenDetalle.PendienteDataList != null)
            {
                OrdenToProcess = _ordenDetalle.PendienteDataList;
            }
        }


        private void cargarSolapaRemito(int posicion)
        {

            int nroSolapa = 1;
            _remito.refreshGridData();

            if (_remito.GridDataList.Count > 0) //si hay datos
            {
                foreach (RemitoDTO row in _remito.GridDataList)
                {

                    if (nroSolapa == 1)
                    {
                        this.objectToFormRem(row);

                        _remitoDetalle.refreshGridData(row.Id);
                        this.dgvDetalleRemito.DataSource = _remitoDetalle.GridDataList;
                        this.dgvDetalleRemito.Font = txtCoche.Font;
                        this.dgvDetalleRemito.ClearSelection();
                        this.txtRenglones.Text = dgvDetalleRemito.RowCount.ToString();

                        //this.tbpNroRemito.Focus();
                    }

                    if (nroSolapa == 2)
                    {
                        this.objectToFormRem2(row);

                        _remitoDetalle.refreshGridData(row.Id);
                        this.dgvDetalleRemito2.DataSource = _remitoDetalle.GridDataList;
                        this.dgvDetalleRemito2.Font = txtCoche.Font;
                        this.dgvDetalleRemito2.ClearSelection();
                        this.txtRenglones2.Text = dgvDetalleRemito2.RowCount.ToString();

                        //this.tbpNroRemito2.Focus();

                    }

                    if (nroSolapa == 3)
                    {
                        this.objectToFormRem3(row);

                        _remitoDetalle.refreshGridData(row.Id);
                        this.dgvDetalleRemito3.DataSource = _remitoDetalle.GridDataList;
                        this.dgvDetalleRemito3.Font = txtCoche.Font;
                        this.dgvDetalleRemito3.ClearSelection();
                        this.txtRenglones3.Text = dgvDetalleRemito3.RowCount.ToString();

                        //this.tbpNroRemito3.Focus();

                    }

                    if (nroSolapa == 4)
                    {
                        this.objectToFormRem4(row);

                        _remitoDetalle.refreshGridData(row.Id);
                        this.dgvDetalleRemito4.DataSource = _remitoDetalle.GridDataList;
                        this.dgvDetalleRemito4.Font = txtCoche.Font;
                        this.dgvDetalleRemito4.ClearSelection();
                        this.txtRenglones4.Text = dgvDetalleRemito4.RowCount.ToString();

                        //this.tbpNroRemito4.Focus();

                    }


                    if (nroSolapa == 5)
                    {
                        this.objectToFormRem5(row);

                        _remitoDetalle.refreshGridData(row.Id);
                        this.dgvDetalleRemito5.DataSource = _remitoDetalle.GridDataList;
                        this.dgvDetalleRemito5.Font = txtCoche.Font;
                        this.dgvDetalleRemito5.ClearSelection();
                        this.txtRenglones5.Text = dgvDetalleRemito5.RowCount.ToString();

                        //this.tbpNroRemito5.Focus();

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
            this.tbcRemitosPendientes.SelectedIndex = posicion;

        }



        private void objectToFormRem(RemitoDTO data)
        {
            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroRemito.Text = data.Nro_remito.ToString();
                this.txtNroRemito.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            }
            else
            {
                this.tbpNroRemito.Text = "R1";
                this.txtNroRemito.Text = "";
                this.lblDatosDelCliente.Text = "";
                _remitoDetalle.refreshGridData(data.Id);
                this.dgvDetalleRemito.DataSource = _remitoDetalle.GridDataList;
            }

        }

        private void objectToFormRem2(RemitoDTO data)
        {
            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroRemito2.Text = data.Nro_remito.ToString();
                this.txtNroRemito2.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente2.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente2.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            }
            else
            {
                this.tbpNroRemito2.Text = "R2";
                this.txtNroRemito2.Text = "";
                this.lblDatosDelCliente2.Text = "";
                _remitoDetalle.refreshGridData(data.Id);
                this.dgvDetalleRemito2.DataSource = _remitoDetalle.GridDataList;
            }

        }

        private void objectToFormRem3(RemitoDTO data)
        {
            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroRemito3.Text = data.Nro_remito.ToString();
                this.txtNroRemito3.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente3.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente3.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            }
            else
            {
                this.tbpNroRemito3.Text = "R3";
                this.txtNroRemito3.Text = "";
                this.lblDatosDelCliente3.Text = "";
                _remitoDetalle.refreshGridData(data.Id);
                this.dgvDetalleRemito3.DataSource = _remitoDetalle.GridDataList;
            }

        }

        private void objectToFormRem4(RemitoDTO data)
        {
            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroRemito4.Text = data.Nro_remito.ToString();
                this.txtNroRemito4.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente4.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente4.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            }
            else
            {
                this.tbpNroRemito4.Text = "R4";
                this.txtNroRemito4.Text = "";
                this.lblDatosDelCliente4.Text = "";
                _remitoDetalle.refreshGridData(data.Id);
                this.dgvDetalleRemito4.DataSource = _remitoDetalle.GridDataList;
            }

        }



        private void objectToFormRem5(RemitoDTO data)
        {
            if (data.Nro_remito.ToString() != "-1")
            {
                this.tbpNroRemito5.Text = data.Nro_remito.ToString();
                this.txtNroRemito5.Text = data.Nro_remito.ToString();

                this.lblDatosDelCliente5.Text = "COD. CLIENTE: " + data.Id_cliente.ToString() + ", " + "NOMBRE: " + data.Nombre_cliente.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "LOCALIDAD: " + data.Localidad.ToString() + ", " + "DIRECCIÓN: " + data.Direccion.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "CUIT: " + data.Cuit.ToString() + ", " + "CATEGORÍA: " + data.Categoria_iva.ToString() + "\n";
                this.lblDatosDelCliente5.Text += "CONDICIÓN DE VENTA: " + data.Condicion_venta.ToString();
            }
            else
            {
                this.tbpNroRemito5.Text = "R5";
                this.txtNroRemito5.Text = "";
                this.lblDatosDelCliente5.Text = "";
                _remitoDetalle.refreshGridData(data.Id);
                this.dgvDetalleRemito5.DataSource = _remitoDetalle.GridDataList;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea borrar los remitos pendientes de registrar?", "Despachar Cubiertas", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_remito.GridDataList.Count != 0)
                    {
                        _remito.delete();

                        cargarGridDetalleTrabajo();
                        cargarSolapaRemito(0);
                        objectToFormRem(new RemitoDTO());
                        objectToFormRem2(new RemitoDTO());
                        objectToFormRem3(new RemitoDTO());
                        objectToFormRem4(new RemitoDTO());
                        objectToFormRem5(new RemitoDTO());

                        this.tbcRemitosPendientes.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No existen remitos pendientes por borrar.", "Despachar Cubiertas");
                    }


                }



            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Borrar remitos pendientes");
            }
        }

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
                clearForm();
                deshabilitarFormOrdenes();
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

        private void btnCambiarRemito_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 1 && txtNroRemito.Text != "")
            {
                registrarAnularGenerarRemito(0);
            }
        }

        private void btnCambiarRemito2_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 2 && txtNroRemito2.Text != "")
            {
                registrarAnularGenerarRemito(1);
            }
        }

        private void btnCambiarRemito3_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 3 && txtNroRemito3.Text != "")
            {
                registrarAnularGenerarRemito(2);
            }
        }

        private void btnCambiarRemito4_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 4 && txtNroRemito4.Text != "")
            {
                registrarAnularGenerarRemito(3);
            }
        }

        private void btnCambiarRemito5_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 5 && txtNroRemito5.Text != "")
            {
                registrarAnularGenerarRemito(4);
            }
        }

        private void registrarAnularGenerarRemito(int posicion)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea anular el remito actual y generar uno nuevo?", "Despachar Cubiertas", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    _remito.registrarAnularRemito(_remito.GridDataList[posicion]);
                    cargarSolapaRemito(posicion);

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


        private void habilitarDespachar()
        {
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

        private void deshabilitarDespachar()
        {
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

        private void btnVistaDefinitiva_Click(object sender, EventArgs e)
        {
            if (_remito.GridDataList.Count >= 1 && lblVistaPreliminar.Text != "Vista Definitiva")
            {
                habilitarDespachar();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar los remitos?", "Despachar Cubiertas", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (_remito.GridDataList.Count != 0)
                    {
                        _remito.refreshGridData();
                        _remito.registrar((List<RemitoDTO>)_remito.GridDataList);

                        cargarFiltroOrden();
                        cargarGridDetalleTrabajo();
                        cargarSolapaRemito(0);
                        objectToFormRem(new RemitoDTO());
                        objectToFormRem2(new RemitoDTO());
                        objectToFormRem3(new RemitoDTO());
                        objectToFormRem4(new RemitoDTO());
                        objectToFormRem5(new RemitoDTO());

                        this.tbcRemitosPendientes.SelectedIndex = 0;
                        deshabilitarDespachar();
                        MessageBox.Show("La operación fue realizada con éxito.", "Despachar Cubiertas");
                    }
                    else
                    {
                        MessageBox.Show("No existen remitos pendientes por registrar.", "Despachar Cubiertas");
                    }


                }



            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Registrar Remito");
            }
        }


        private void imprimirRemito(int posicion, string cod_factura)
        {
            try
            {
                frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
                formProcesamiento.Show();
                crRemito rptLista = GenerarImpresionRemito.cargarReporteRemitoPendiente(_remito.GridDataList[posicion].Id, cod_factura);
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

        private void vistaPreliminarRemito(int posicion, string cod_factura)
        {
            try
            {
                frmVerRemito frmReporte = new frmVerRemito();
                crRemito rptLista = GenerarImpresionRemito.cargarReporteRemitoPendiente(_remito.GridDataList[posicion].Id, cod_factura);
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

        private void btnImprimirRemito_Click(object sender, EventArgs e)
        {
            if (txtNroRemito.Text != "")
            {
                imprimirRemito(0, string.Empty);
            }
        }

        private void btnImprimirRemito2_Click(object sender, EventArgs e)
        {
            if (txtNroRemito2.Text != "")
            {
                imprimirRemito(1, string.Empty);
            }
        }

        private void btnImprimirRemito3_Click(object sender, EventArgs e)
        {
            if (txtNroRemito3.Text != "")
            {
                imprimirRemito(2, string.Empty);
            }
        }

        private void btnImprimirRemito4_Click(object sender, EventArgs e)
        {
            if (txtNroRemito4.Text != "")
            {
                imprimirRemito(3, string.Empty);
            }
        }

        private void btnImprimirRemito5_Click(object sender, EventArgs e)
        {
            if (txtNroRemito5.Text != "")
            {
                imprimirRemito(4, string.Empty);
            }
        }

        private void btnVistaPreliminarRemito_Click(object sender, EventArgs e)
        {
            if (txtNroRemito.Text != "")
            {
                vistaPreliminarRemito(0, string.Empty);
            }
        }

        private void btnVistaPreliminarRemito2_Click(object sender, EventArgs e)
        {
            if (txtNroRemito2.Text != "")
            {
                vistaPreliminarRemito(1, string.Empty);
            }
        }

        private void btnVistaPreliminarRemito3_Click(object sender, EventArgs e)
        {
            if (txtNroRemito3.Text != "")
            {
                vistaPreliminarRemito(2, string.Empty);
            }
        }

        private void btnVistaPreliminarRemito4_Click(object sender, EventArgs e)
        {
            if (txtNroRemito4.Text != "")
            {
                vistaPreliminarRemito(3, string.Empty);
            }
        }

        private void btnVistaPreliminarRemito5_Click(object sender, EventArgs e)
        {
            if (txtNroRemito5.Text != "")
            {
                vistaPreliminarRemito(4, string.Empty);
            }
        }



    }
}


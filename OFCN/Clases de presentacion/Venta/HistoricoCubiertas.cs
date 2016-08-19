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
    public partial class frmHistoricoCubiertas : Form
    {
        private Clientes _clientes;
        private FiltrosABMCliente _filtroClientes;
        private HistoricoCubiertas _historico_cubiertas;
        private MedidaCubierta _medidas;


        public frmHistoricoCubiertas()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _filtroClientes = new FiltrosABMCliente();
            _historico_cubiertas = new HistoricoCubiertas();
            _medidas = new MedidaCubierta();
        }

        private void frmHistoricoCubiertas_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltrosBusqueda();
            configurarGridHistoricoCubiertas();
        }

        private void txtNroOrden_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtFiltroNroDeOrden.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void cargarFiltrosBusqueda()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDeCliente.DataSource = _clientes.NombreDataList;

            //int dias_transcurridos = System.DateTime.Now.Day * (-1); //feb 1.9.1
            //this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1); //feb 1.9.1
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(-365); //feb 1.9.1

            IList<ProductoDTO> medidaFiltro = new List<ProductoDTO>(_medidas.OwnDataList); //independencia

            this.cbxFiltroMedidaDeCubierta.DataSource = medidaFiltro;
            this.cbxFiltroMedidaDeCubierta.DisplayMember = "medida_cubierta";
            this.cbxFiltroMedidaDeCubierta.ValueMember = "id";
        }

        private void cbxFiltroCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDeCliente.Text = _clientes.obtenerNombre(this.cbxFiltroCodCliente.Text);
        }

        private void cbxFiltroNombreDeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodCliente.Text = _clientes.obtenerCodigo(this.cbxFiltroNombreDeCliente.Text);
        }

        private void configurarGridHistoricoCubiertas()
        {
            this.dgvHistoricoCubiertas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fechaCreacion = new DataGridViewTextBoxColumn();
            _fechaCreacion.DataPropertyName = "v_fecha_orden";
            _fechaCreacion.HeaderText = "Fecha de la Orden";
            _fechaCreacion.Width = 135;
            _fechaCreacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaCreacion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaCreacion.ReadOnly = true;

            DataGridViewTextBoxColumn _nroDeOrdenColum = new DataGridViewTextBoxColumn();
            _nroDeOrdenColum.DataPropertyName = "id_orden";
            _nroDeOrdenColum.HeaderText = "Orden";
            _nroDeOrdenColum.Width = 55;
            _nroDeOrdenColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroDeOrdenColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroRenglonColum = new DataGridViewTextBoxColumn();
            _nroRenglonColum.DataPropertyName = "renglon";
            _nroRenglonColum.HeaderText = "R.";
            _nroRenglonColum.Width = 30; //feb 1.9.1
            _nroRenglonColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRenglonColum.ReadOnly = true;

            DataGridViewTextBoxColumn _coche = new DataGridViewTextBoxColumn();
            _coche.DataPropertyName = "coche";
            _coche.HeaderText = "Coche";
            _coche.Width = 110;
            _coche.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _coche.ReadOnly = true;

            DataGridViewTextBoxColumn _medidaCubiertaColum = new DataGridViewTextBoxColumn();
            _medidaCubiertaColum.DataPropertyName = "medida_cubierta";
            _medidaCubiertaColum.HeaderText = "Cubierta";
            _medidaCubiertaColum.Width = 110;
            _medidaCubiertaColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubiertaColum.ReadOnly = true;

            DataGridViewTextBoxColumn _marca = new DataGridViewTextBoxColumn();
            _marca.DataPropertyName = "marca";
            _marca.HeaderText = "Marca";
            _marca.Width = 80;
            _marca.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marca.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _marca.ReadOnly = true;

            DataGridViewTextBoxColumn _NroSerieColum = new DataGridViewTextBoxColumn();
            _NroSerieColum.DataPropertyName = "serie";
            _NroSerieColum.HeaderText = "Serie";
            _NroSerieColum.Width = 70;
            _NroSerieColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroSerieColum.ReadOnly = true;

            DataGridViewTextBoxColumn _trabajoColum = new DataGridViewTextBoxColumn();
            _trabajoColum.DataPropertyName = "trabajo";
            _trabajoColum.HeaderText = "Trabajo";
            _trabajoColum.Width = 150;
            _trabajoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _NroInternoColum = new DataGridViewTextBoxColumn();
            _NroInternoColum.DataPropertyName = "interno";
            _NroInternoColum.HeaderText = "Interno";
            _NroInternoColum.Width = 55;
            _NroInternoColum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroInternoColum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _NroInternoColum.ReadOnly = true;

            DataGridViewTextBoxColumn _servicioAdicionalColum = new DataGridViewTextBoxColumn();
            _servicioAdicionalColum.DataPropertyName = "servicio_adicional";
            _servicioAdicionalColum.HeaderText = "Servicio Adicional";
            _servicioAdicionalColum.Width = 140; //feb 1.9.1
            _servicioAdicionalColum.ReadOnly = true;

            DataGridViewTextBoxColumn _nroFactura = new DataGridViewTextBoxColumn();
            _nroFactura.DataPropertyName = "cod_comprobante_factura";
            _nroFactura.HeaderText = "Factura";
            _nroFactura.Width = 111;
            _nroFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroFactura.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroFactura.ReadOnly = true;

            DataGridViewTextBoxColumn _nroRemito = new DataGridViewTextBoxColumn();
            _nroRemito.DataPropertyName = "cod_comprobante_remito";
            _nroRemito.HeaderText = "Remito";
            _nroRemito.Width = 111;
            _nroRemito.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRemito.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _nroRemito.ReadOnly = true;

            DataGridViewTextBoxColumn _fechaFactura = new DataGridViewTextBoxColumn();
            _fechaFactura.DataPropertyName = "v_fecha_factura";
            _fechaFactura.HeaderText = "Fecha de Factura / Remito";
            _fechaFactura.Width = 135;
            _fechaFactura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaFactura.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fechaFactura.ReadOnly = true;

            this.dgvHistoricoCubiertas.Columns.Add(_fechaCreacion);
            this.dgvHistoricoCubiertas.Columns.Add(_nroDeOrdenColum);
            this.dgvHistoricoCubiertas.Columns.Add(_nroRenglonColum);
            this.dgvHistoricoCubiertas.Columns.Add(_coche);
            this.dgvHistoricoCubiertas.Columns.Add(_medidaCubiertaColum);
            this.dgvHistoricoCubiertas.Columns.Add(_marca);
            this.dgvHistoricoCubiertas.Columns.Add(_NroSerieColum);
            this.dgvHistoricoCubiertas.Columns.Add(_trabajoColum);
            this.dgvHistoricoCubiertas.Columns.Add(_NroInternoColum);
            this.dgvHistoricoCubiertas.Columns.Add(_servicioAdicionalColum);
            this.dgvHistoricoCubiertas.Columns.Add(_nroFactura);
            this.dgvHistoricoCubiertas.Columns.Add(_nroRemito);
            this.dgvHistoricoCubiertas.Columns.Add(_fechaFactura);

        }


        private bool validarDatosFiltros()
        {

            bool rv = true;

            if (this.cbxFiltroCodCliente.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroCodCliente.FindStringExact(cbxFiltroCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            if (this.cbxFiltroNombreDeCliente.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroNombreDeCliente.FindStringExact(cbxFiltroNombreDeCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            if (this.cbxFiltroMedidaDeCubierta.Text != "" && rv)
            {
                int resultIndex = this.cbxFiltroMedidaDeCubierta.FindStringExact(cbxFiltroMedidaDeCubierta.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            return rv;

        }

        private void FilterToObjectABM()
        {
            _filtroClientes.FiltroCodigo = this.cbxFiltroCodCliente.Text;
            _filtroClientes.FiltroNombre = this.cbxFiltroNombreDeCliente.Text;
            _filtroClientes.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroClientes.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(0);
            _filtroClientes.FiltroMedidaCubierta = long.Parse(this.cbxFiltroMedidaDeCubierta.SelectedValue.ToString());
            if (this.txtFiltroNroDeOrden.Text == "")
            {
                _filtroClientes.FiltroNroOrden = -1;
            }
            else
            {
                _filtroClientes.FiltroNroOrden = long.Parse(this.txtFiltroNroDeOrden.Text);
            }
        }

        private void FilterToObjectABMFalse()
        {
            _filtroClientes.FiltroCodigo = "XXXXXXXX";
            _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroClientes.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroClientes.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(0);
            _filtroClientes.FiltroMedidaCubierta = -1;
            _filtroClientes.FiltroNroOrden = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarDatosFiltros())
            {
                FilterToObjectABM();
                cargarGridHistoricoCubiertas();
            }
            else
            {
                FilterToObjectABMFalse();
                cargarGridHistoricoCubiertas();
            }
        }

        private void cargarGridHistoricoCubiertas()
        {
            _historico_cubiertas.refreshGridData(_filtroClientes);
            this.dgvHistoricoCubiertas.DataSource = _historico_cubiertas.GridDataList;
            this.dgvHistoricoCubiertas.ClearSelection();

        }


        private void clearFilter()
        {
            this.objectToFilterABM(new FiltrosABMCliente());
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaHasta.Value = System.DateTime.Now;

        }


        private void objectToFilterABM(FiltrosABMCliente filtro)
        {
            this.cbxFiltroCodCliente.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombreDeCliente.Text = filtro.FiltroNombre;
            if (filtro.FiltroMedidaCubierta == -1)
            {
                this.cbxFiltroMedidaDeCubierta.Text = "";
            }
            if (filtro.FiltroNroOrden == -1)
            {
                this.txtFiltroNroDeOrden.Text = "";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectABMFalse();
            cargarGridHistoricoCubiertas();
            this.cbxFiltroCodCliente.Focus();
        }


        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validarDatosFiltros())
                {
                    FilterToObjectABM();
                    cargarGridHistoricoCubiertas();
                }
                else
                {
                    FilterToObjectABMFalse();
                    cargarGridHistoricoCubiertas();
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                    FilterToObjectABM();
                    frmVerHistoricoDeCubiertas frmReporte = new frmVerHistoricoDeCubiertas();
                    crHistoricoDeCubiertas rptLista = frmReporte.cargarReporte(_filtroClientes, dtpFechaDesde.Value, dtpFechaHasta.Value);
                    frmReporte.crvHistoricoDeCubiertas.ReportSource = rptLista;
                    frmReporte.ShowDialog();
                    rptLista.Dispose();
                    frmReporte.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Histórico de Cubiertas");
            }
        }

    }
}

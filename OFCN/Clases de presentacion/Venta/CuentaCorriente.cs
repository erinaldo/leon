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
    public partial class frmMovimientosDeCuentaCorriente : Form
    {
        private Clientes _clientes;
        private Movimientos _movimientos;
        private FiltrosABMCliente _filtroClientes;
        private CuentaCorriente _cuenta; 

        public frmMovimientosDeCuentaCorriente()
        {
            InitializeComponent();
            _clientes = new Clientes();
            _movimientos = new Movimientos();
            _filtroClientes = new FiltrosABMCliente();
            _cuenta = new CuentaCorriente();
            
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (this.txtNroFactura.Text != "")
                //{

                //    precargarFiltros();

                //}

                //validar datos filtros
                if (validarDatosFiltros() || this.txtNroFactura.Text != "")
                {
                    FilterToObjectABM();
                    cargarGridMovimientos();
                    cargarDatosCliente();
                    cargarDatosCuenta();
                }
                else
                {
                       FilterToObjectABMFalse();
                        cargarGridMovimientos();
                        cargarDatosCliente();
                        cargarDatosCuenta();
                }
            }
        }


        private void frmMovimientosDeCuentaCorriente_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarFiltroCompleto();
            configurarGridMovimientos();
            
        }

        private void cargarFiltroCompleto()
        {
            //this.cbxCodCliente.DataSource = null;
            this.cbxFiltroCodCliente.DataSource = _clientes.CodDataList; //evaluar de que forma ingresen si o si los datos

            //this.cbxNombreDelCliente.DataSource = null;
            this.cbxFiltroNombreDelCliente.DataSource = _clientes.NombreDataList;

            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
        }

        private void cbxFiltroCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxFiltroCodCliente.Text);
        }

        private void cbxFiltroNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodCliente.Text = _clientes.obtenerCodigo(this.cbxFiltroNombreDelCliente.Text);
        }


        private void configurarGridMovimientos()
        {
            this.dgvMovimientos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fecha_y_hora = new DataGridViewTextBoxColumn();
            _fecha_y_hora.DataPropertyName = "v_fecha";
            _fecha_y_hora.HeaderText = "Fecha y Hora";
            _fecha_y_hora.Width = 244;
            _fecha_y_hora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.ReadOnly = true;

            DataGridViewTextBoxColumn _comprobante = new DataGridViewTextBoxColumn();
            _comprobante.DataPropertyName = "comprobante";
            _comprobante.HeaderText = "Comprobante";
            _comprobante.Width = 244;
            _comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobante = new DataGridViewTextBoxColumn();
            _codComprobante.DataPropertyName = "cod_comprobante";
            _codComprobante.HeaderText = "Nro. Comprobante";
            _codComprobante.Width = 244;
            _codComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _pago = new DataGridViewTextBoxColumn();
            _pago.DataPropertyName = "v_pago";
            _pago.HeaderText = "Pagado/Cancelado";
            _pago.Width = 130;
            _pago.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _pago.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _pago.ReadOnly = true;

            DataGridViewTextBoxColumn _debe = new DataGridViewTextBoxColumn();
            _debe.DataPropertyName = "v_debe";
            _debe.HeaderText = "Debe";
            _debe.Width = 130;
            _debe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debe.ReadOnly = true;

            DataGridViewTextBoxColumn _haber = new DataGridViewTextBoxColumn();
            _haber.DataPropertyName = "v_haber";
            _haber.HeaderText = "Haber";
            _haber.Width = 130;
            _haber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haber.ReadOnly = true;

            DataGridViewTextBoxColumn _saldo = new DataGridViewTextBoxColumn();
            _saldo.DataPropertyName = "v_saldo";
            _saldo.HeaderText = "Saldo";
            _saldo.Width = 130;
            _saldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _saldo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _saldo.ReadOnly = true;

            this.dgvMovimientos.Columns.Add(_fecha_y_hora);
            this.dgvMovimientos.Columns.Add(_comprobante);
            this.dgvMovimientos.Columns.Add(_codComprobante);
            this.dgvMovimientos.Columns.Add(_pago);
            this.dgvMovimientos.Columns.Add(_debe);
            this.dgvMovimientos.Columns.Add(_haber);
            this.dgvMovimientos.Columns.Add(_saldo);


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            //if (this.txtNroFactura.Text != "")
            //{
            //    precargarFiltros();
            //}

            //validar datos filtros
            if (validarDatosFiltros() || this.txtNroFactura.Text != "")
            {
                FilterToObjectABM();
                cargarGridMovimientos();
                cargarDatosCliente();
                cargarDatosCuenta();
            }
            else
            {
                FilterToObjectABMFalse();
                cargarGridMovimientos();
                cargarDatosCliente();
                cargarDatosCuenta();
            }

        }

        //feb 1.8 //además se se alinea a la izquierda el label
        private void cargarDatosCuenta()
        {

            if (_filtroClientes.FiltroCodigo != "")
            {
                _cuenta.refreshGridData(_filtroClientes);

                if (_cuenta.GridDataList.Count == 1)
                {
                    this.lblSaldoDeudor.Text = "Fecha de último movimiento: " + String.Format("{0:dd/MM/yyyy}", _cuenta.GridDataList[0].Fecha_actualizacion) + "\n";
                    this.lblSaldoDeudor.Text += "Saldo actual: " + _cuenta.GridDataList[0].V_saldo.ToString() + "\n";
                    this.lblSaldoDeudor.Text += "Saldo a principio de mes: " + _cuenta.obtenerSaldoComienzoDeMes(_filtroClientes.FiltroCodigo);
                }
                else
                {
                    this.lblSaldoDeudor.Text = "";
                }
            }

        }



        private void cargarDatosCliente()
        {
            if (_filtroClientes.FiltroCodigo != "")
            {
                _clientes.refreshGridData(_filtroClientes);

                if (_clientes.GridDataList.Count == 1)
                {

                    this.lblDatosDelCliente.Text = "Cód. Cliente: " + _clientes.GridDataList[0].Id.ToString() + "   " + "Nombre: " + _clientes.GridDataList[0].Nombre.ToString() + "\n";
                    this.lblDatosDelCliente.Text += "Localidad: " + _clientes.GridDataList[0].Localidad_legal.ToString() + "   " + "Dirección: " + _clientes.GridDataList[0].Direccion_legal.ToString() + "\n";
                    this.lblDatosDelCliente.Text += "Cuit: " + _clientes.GridDataList[0].Cuit.ToString() + "   " + "Categoría: " + _clientes.GridDataList[0].Categoria_iva.ToString();

                }
                else
                {
                    this.lblDatosDelCliente.Text = "";
                }
            }

        }

        //private void precargarFiltros()
        //{

        //    this.cbxFiltroCodCliente.Text = ClienteDTO.obtenerIdClienteFact(this.txtNroFactura.Text); //cambia index cbx

        //}

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

            if (this.cbxFiltroNombreDelCliente.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroNombreDelCliente.FindStringExact(cbxFiltroNombreDelCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            return rv;

        }

        private void cargarGridMovimientos()
        {
            _movimientos.refreshGridData(_filtroClientes);
            this.dgvMovimientos.DataSource = _movimientos.GridDataList;
            this.dgvMovimientos.Font = this.txtNroFactura.Font;
            this.dgvMovimientos.ClearSelection();

        }


        private void FilterToObjectABM()
        {
            if (this.cbxFiltroCodCliente.Text != "" || this.txtNroFactura.Text != "")
            {
                _filtroClientes.FiltroCodigo = this.cbxFiltroCodCliente.Text;
            }
            else
            {
                _filtroClientes.FiltroCodigo = "XXXXXXXX";
            }

            if (this.cbxFiltroNombreDelCliente.Text != "" || this.txtNroFactura.Text != "")
            {
                _filtroClientes.FiltroNombre = this.cbxFiltroNombreDelCliente.Text;
            }
            else
            {
                _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            }

            _filtroClientes.FiltroCodComprobanteFact = this.txtNroFactura.Text;
            _filtroClientes.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroClientes.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectABMFalse();
            cargarGridMovimientos();
            cargarDatosCliente();
            cargarDatosCuenta();
            this.cbxFiltroCodCliente.Focus();
        }

        
        
        private void FilterToObjectABMFalse()
        {
            _filtroClientes.FiltroCodigo = "XXXXXXXX";
            _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroClientes.FiltroCodComprobanteFact = "XXXXXXXX";
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
            this.cbxFiltroNombreDelCliente.Text = filtro.FiltroNombre;
            this.txtNroFactura.Text = filtro.FiltroCodComprobanteFact;
            
        }

        private void btnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerResumenDeCuenta frmReporte = new frmVerResumenDeCuenta();
                crResumenDeCuenta rptLista = frmReporte.cargarReporte(cbxFiltroCodCliente.Text, dtpFechaDesde.Value, dtpFechaHasta.Value);
                frmReporte.crvResumenDeCuenta.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Resumen de Cuenta");
            }
        }

        private void btnImprimirSaldosTotales_Click(object sender, EventArgs e)
        {
                frmSaldosTotales frmSaldos = new frmSaldosTotales();
                frmSaldos.ShowDialog();
                frmSaldos.Dispose();
        }

    }
}

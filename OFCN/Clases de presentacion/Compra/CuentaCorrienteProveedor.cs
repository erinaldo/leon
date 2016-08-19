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
    public partial class frmMovimientosCuentaCorrienteProveedor : Form
    {
        private Proveedores _proveedores;
        private FiltrosABMProveedor _filtroProveedores;
        private Movimientos _movimientos;
        private CuentaCorriente _cuenta; 

        public frmMovimientosCuentaCorrienteProveedor()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _filtroProveedores = new FiltrosABMProveedor();
            _movimientos = new Movimientos();
            _cuenta = new CuentaCorriente();
        }

        private void frmMovimientosCuentaCorrienteProveedor_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarDatosForm();
            configurarGridMovimientos();
        }

        private void cargarDatosProveedor()
        {
            _proveedores.refreshGridData(_filtroProveedores);
            if (_proveedores.GridDataList.Count == 1)
            {
                this.lblDatosDelProveedor.Text = "Cód. Proveedor: " + _proveedores.GridDataList[0].Id.ToString() + "   " + "Nombre: " + _proveedores.GridDataList[0].Nombre.ToString() + "\n";
                this.lblDatosDelProveedor.Text += "Localidad: " + _proveedores.GridDataList[0].Localidad.ToString() + "   " + "Dirección: " + _proveedores.GridDataList[0].Direccion.ToString() + "\n";
                this.lblDatosDelProveedor.Text += "Cuit: " + _proveedores.GridDataList[0].Cuit.ToString() + "   " + "Categoría: " + _proveedores.GridDataList[0].Categoria_iva.ToString();
            }
            else
            {
                this.lblDatosDelProveedor.Text = "";
            }
        }

        private void cargarDatosCuenta()
        {
            _cuenta.refreshGridData(_filtroProveedores);
            if (_cuenta.GridDataListProv.Count == 1)
            {

                this.lblSaldoDeudor.Text = "Fecha de último movimiento: " + String.Format("{0:dd/MM/yyyy}", _cuenta.GridDataListProv[0].Fecha_actualizacion) + "\n";
                this.lblSaldoDeudor.Text += "Saldo actual: " + _cuenta.GridDataListProv[0].V_saldo.ToString() + "\n";
                this.lblSaldoDeudor.Text += "Saldo a principio de mes: " + _cuenta.obtenerSaldoComienzoDeMesProv(_filtroProveedores.FiltroCodigo);

            }
            else
            {
                this.lblSaldoDeudor.Text = "";
            }
        }


        private void cargarDatosForm()
        {
            this.cbxFiltroCodProveedor.DataSource = _proveedores.CodDataList;
            this.cbxFiltroNombreDelProveedor.DataSource = _proveedores.NombreDataList;
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
        }

        private void cbxFiltroCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDelProveedor.Text = _proveedores.obtenerNombre(this.cbxFiltroCodProveedor.Text);
        }

        private void cbxFiltroNombreDelProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxFiltroNombreDelProveedor.Text);
        }


        private void configurarGridMovimientos()
        {
            this.dgvMovimientos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fecha_y_hora = new DataGridViewTextBoxColumn();
            _fecha_y_hora.DataPropertyName = "v_fecha";
            _fecha_y_hora.HeaderText = "Fecha y Hora de Registro";
            _fecha_y_hora.Width = 222;
            _fecha_y_hora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.ReadOnly = true;

            DataGridViewTextBoxColumn _fecha_comprobante = new DataGridViewTextBoxColumn();
            _fecha_comprobante.DataPropertyName = "v_fecha_comprobante";
            _fecha_comprobante.HeaderText = "Fecha del Comprobante";
            _fecha_comprobante.Width = 190;
            _fecha_comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _comprobante = new DataGridViewTextBoxColumn();
            _comprobante.DataPropertyName = "comprobante";
            _comprobante.HeaderText = "Comprobante";
            _comprobante.Width = 190;
            _comprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _comprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _comprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobante = new DataGridViewTextBoxColumn();
            _codComprobante.DataPropertyName = "cod_comprobante";
            _codComprobante.HeaderText = "Nro. Comprobante";
            _codComprobante.Width = 190;
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
            _debe.Width = 110;
            _debe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _debe.ReadOnly = true;

            DataGridViewTextBoxColumn _haber = new DataGridViewTextBoxColumn();
            _haber.DataPropertyName = "v_haber";
            _haber.HeaderText = "Haber";
            _haber.Width = 110;
            _haber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _haber.ReadOnly = true;

            DataGridViewTextBoxColumn _saldo = new DataGridViewTextBoxColumn();
            _saldo.DataPropertyName = "v_saldo";
            _saldo.HeaderText = "Saldo";
            _saldo.Width = 110;
            _saldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _saldo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _saldo.ReadOnly = true;

            this.dgvMovimientos.Columns.Add(_fecha_y_hora);
            this.dgvMovimientos.Columns.Add(_fecha_comprobante);
            this.dgvMovimientos.Columns.Add(_comprobante);
            this.dgvMovimientos.Columns.Add(_codComprobante);
            this.dgvMovimientos.Columns.Add(_pago);
            this.dgvMovimientos.Columns.Add(_debe);
            this.dgvMovimientos.Columns.Add(_haber);
            this.dgvMovimientos.Columns.Add(_saldo);


        }

        private void cargarGridMovimientos()
        {
            _movimientos.refreshGridData(_filtroProveedores);
            this.dgvMovimientos.DataSource = _movimientos.GridDataListProv;
            this.dgvMovimientos.Font = this.cbxFiltroCodProveedor.Font;
            this.dgvMovimientos.ClearSelection();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarDatosFiltros())
            {
                FilterToObjectABM();
                cargarGridMovimientos();
                cargarDatosProveedor();
                cargarDatosCuenta();
            }
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validarDatosFiltros())
                {
                    FilterToObjectABM();
                    cargarGridMovimientos();
                    cargarDatosProveedor();
                    cargarDatosCuenta();
                }
            }
        }


        private bool validarDatosFiltros()
        {

            bool rv = true;

            if (this.cbxFiltroCodProveedor.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroCodProveedor.FindStringExact(cbxFiltroCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            if (this.cbxFiltroNombreDelProveedor.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroNombreDelProveedor.FindStringExact(cbxFiltroNombreDelProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            return rv;

        }

        private void FilterToObjectABM()
        {
            if (this.cbxFiltroCodProveedor.Text != "")
            {
                _filtroProveedores.FiltroCodigo = this.cbxFiltroCodProveedor.Text;
            }
            else
            {
                _filtroProveedores.FiltroCodigo = "XXXXXXXX";
            }

            if (this.cbxFiltroNombreDelProveedor.Text != "")
            {
                _filtroProveedores.FiltroNombre = this.cbxFiltroNombreDelProveedor.Text;
            }
            else
            {
                _filtroProveedores.FiltroNombre = "XXXXXXXXXXXXXXXX";
            }

            _filtroProveedores.FiltroFechaDesde = this.dtpFechaDesde.Value.Date;
            _filtroProveedores.FiltroFechaHasta = this.dtpFechaHasta.Value.AddDays(0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectABMFalse();
            cargarGridMovimientos();
            cargarDatosProveedor();
            cargarDatosCuenta();
            this.cbxFiltroCodProveedor.Focus();
        }

        private void clearFilter()
        {
            this.objectToFilterABM(new FiltrosABMProveedor());
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaHasta.Value = System.DateTime.Now;
        }


        private void objectToFilterABM(FiltrosABMProveedor filtro)
        {
            this.cbxFiltroCodProveedor.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombreDelProveedor.Text = filtro.FiltroNombre;
        }

        private void FilterToObjectABMFalse()
        {
            _filtroProveedores.FiltroCodigo = "XXXXXXXX";
            _filtroProveedores.FiltroNombre = "XXXXXXXXXXXXXXXX";
        }

        private void btnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerResumenDeCuentaProv frmReporte = new frmVerResumenDeCuentaProv();
                crResumenDeCuentaProveedor rptLista = frmReporte.cargarReporte(cbxFiltroCodProveedor.Text, dtpFechaDesde.Value, dtpFechaHasta.Value);
                frmReporte.crvResumenDeCuentaProv.ReportSource = rptLista;
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
            frmSaldosTotalesProv frmSaldos = new frmSaldosTotalesProv();
            frmSaldos.ShowDialog();
            frmSaldos.Dispose();
        }
    }
}

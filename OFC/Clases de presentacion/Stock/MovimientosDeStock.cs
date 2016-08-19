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
    public partial class frmMovimientosDeStock : Form
    {

        private Producto _productos;
        private MovimientoDeArticulos _movimientos;

        public frmMovimientosDeStock()
        {
            InitializeComponent();
            _productos = new Producto();
            _movimientos = new MovimientoDeArticulos();
        }

        private void frmMovimientosDeStock_Load(object sender, EventArgs e)
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
            _productos.refreshOwnData2();

            this.cbxFiltroPorArticulo.DataSource = _productos.OwnDataList2;
            this.cbxFiltroPorArticulo.DisplayMember = "codigo";

            this.cbxFiltroDescripcionArticulo.DataSource = _productos.OwnDataList2;
            this.cbxFiltroDescripcionArticulo.DisplayMember = "descripcion";

            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
        }

        private void configurarGridMovimientos()
        {
            this.dgvMovimientosDeStock.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _fecha_y_hora = new DataGridViewTextBoxColumn();
            _fecha_y_hora.DataPropertyName = "v_fecha";
            _fecha_y_hora.HeaderText = "Fecha y Hora de Registro";
            _fecha_y_hora.Width = 190;
            _fecha_y_hora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _fecha_y_hora.ReadOnly = true;

            DataGridViewTextBoxColumn _codProducto = new DataGridViewTextBoxColumn();
            _codProducto.DataPropertyName = "cod_producto";
            _codProducto.HeaderText = "Cód. Artículo";
            _codProducto.Width = 98;
            _codProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codProducto.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codProducto.ReadOnly = true;

            DataGridViewTextBoxColumn _descProducto = new DataGridViewTextBoxColumn();
            _descProducto.DataPropertyName = "desc_producto";
            _descProducto.HeaderText = "Descripción";
            _descProducto.Width = 270;
            _descProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descProducto.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descProducto.ReadOnly = true;

            DataGridViewTextBoxColumn _precioUnitario = new DataGridViewTextBoxColumn();
            _precioUnitario.DataPropertyName = "v_precio_unitario";
            _precioUnitario.HeaderText = "Precio Unitario";
            _precioUnitario.Width = 113;
            _precioUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precioUnitario.ReadOnly = true;

            DataGridViewTextBoxColumn _cantidadEgreso = new DataGridViewTextBoxColumn();
            _cantidadEgreso.DataPropertyName = "cantidad_egreso";
            _cantidadEgreso.HeaderText = "Egreso";
            _cantidadEgreso.Width = 70;
            _cantidadEgreso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidadEgreso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidadEgreso.ReadOnly = true;

            DataGridViewTextBoxColumn _cantidadIngreso = new DataGridViewTextBoxColumn();
            _cantidadIngreso.DataPropertyName = "cantidad_ingreso";
            _cantidadIngreso.HeaderText = "Ingreso";
            _cantidadIngreso.Width = 70;
            _cantidadIngreso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidadIngreso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _cantidadIngreso.ReadOnly = true;

            DataGridViewTextBoxColumn _stock = new DataGridViewTextBoxColumn();
            _stock.DataPropertyName = "stock";
            _stock.HeaderText = "Stock";
            _stock.Width = 75;
            _stock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _stock.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _stock.ReadOnly = true;

            DataGridViewTextBoxColumn _operacion = new DataGridViewTextBoxColumn();
            _operacion.DataPropertyName = "desc_operacion";
            _operacion.HeaderText = "Módulo";
            _operacion.Width = 85;
            _operacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _operacion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _operacion.ReadOnly = true;

            DataGridViewTextBoxColumn _tipoDeComprobante = new DataGridViewTextBoxColumn();
            _tipoDeComprobante.DataPropertyName = "desc_tipo_comprobante";
            _tipoDeComprobante.HeaderText = "Tipo de Comprobante";
            _tipoDeComprobante.Width = 171;
            _tipoDeComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoDeComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tipoDeComprobante.ReadOnly = true;

            DataGridViewTextBoxColumn _codComprobante = new DataGridViewTextBoxColumn();
            _codComprobante.DataPropertyName = "cod_comprobante";
            _codComprobante.HeaderText = "Nro. de Comprobante";
            _codComprobante.Width = 150;
            _codComprobante.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codComprobante.ReadOnly = true;

            this.dgvMovimientosDeStock.Columns.Add(_fecha_y_hora);
            this.dgvMovimientosDeStock.Columns.Add(_codProducto);
            this.dgvMovimientosDeStock.Columns.Add(_descProducto);
            this.dgvMovimientosDeStock.Columns.Add(_operacion);
            this.dgvMovimientosDeStock.Columns.Add(_tipoDeComprobante);
            this.dgvMovimientosDeStock.Columns.Add(_codComprobante);
            this.dgvMovimientosDeStock.Columns.Add(_precioUnitario);
            this.dgvMovimientosDeStock.Columns.Add(_cantidadIngreso);
            this.dgvMovimientosDeStock.Columns.Add(_cantidadEgreso);
            this.dgvMovimientosDeStock.Columns.Add(_stock);

        }

        private bool validarDatosFiltros()
        {

            bool rv = true;

            if (this.cbxFiltroPorArticulo.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroPorArticulo.FindStringExact(cbxFiltroPorArticulo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            if (this.cbxFiltroDescripcionArticulo.Text == "")
            {
                rv = false;
            }
            else
            {
                int resultIndex = this.cbxFiltroDescripcionArticulo.FindStringExact(cbxFiltroDescripcionArticulo.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                }
            }

            return rv;

        }

        private void cargarGridMovimientos()
        {
            _movimientos.refreshGridData(ProductoDTO.buscarId(cbxFiltroDescripcionArticulo.Text), dtpFechaDesde.Value.Date, dtpFechaHasta.Value.AddDays(0));
            this.dgvMovimientosDeStock.DataSource = _movimientos.GridDataList;
            this.dgvMovimientosDeStock.ClearSelection();
        }

        private void clearFilter()
        {
            cbxFiltroPorArticulo.Text = string.Empty;
            cbxFiltroDescripcionArticulo.Text = string.Empty;
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
            this.dtpFechaHasta.Value = System.DateTime.Now;
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validarDatosFiltros())
                {
                    cargarGridMovimientos();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarDatosFiltros())
            {
                cargarGridMovimientos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearFilter();
            dgvMovimientosDeStock.DataSource = null;
        }

    }
}

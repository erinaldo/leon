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
    public partial class frmListaDePrecioCompra : Form
    {
        private Producto _articulos;
        private Proveedores _proveedores;
        private PrecioProveedor _precios;

        public frmListaDePrecioCompra()
        {
            InitializeComponent();
            _articulos = new Producto();
            _proveedores = new Proveedores();
            _precios = new PrecioProveedor();
        }

        private void ListaDePrecioCompra_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltroProveedores();
            configurarGridArticulosDisponibles();
            configurarGridArticulosEnLista();
        }

        private void configurarGridArticulosEnLista()
        {
            this.dgvArticulosEnLista.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigoArticulo = new DataGridViewTextBoxColumn();
            _codigoArticulo.DataPropertyName = "codigo";
            _codigoArticulo.HeaderText = "Cód. Articulo";
            _codigoArticulo.Width = 100;
            _codigoArticulo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codigoArticulo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codigoArticulo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "producto";
            _descripcion.HeaderText = "Descripción del Artículo";
            _descripcion.Width = 343;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _precio = new DataGridViewTextBoxColumn();
            _precio.DataPropertyName = "v_precio";
            _precio.HeaderText = "Precio Unitario";
            _precio.Width = 115;
            _precio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _precio.ReadOnly = true;

            this.dgvArticulosEnLista.Columns.Add(_codigoArticulo);
            this.dgvArticulosEnLista.Columns.Add(_descripcion);
            this.dgvArticulosEnLista.Columns.Add(_precio);
        }

        private void cargarArticulosPnlDerecho()
        {
            //completo panel derecho
            _articulos.refreshOwnData3(cbxFiltroCodDeProveedor.Text);

            this.dgvArticulosDisponibles.DataSource = _articulos.OwnDataList3;
            this.dgvArticulosDisponibles.Font = this.txtCodDeProveedor.Font;
            this.dgvArticulosDisponibles.ClearSelection();

            List<ProductoDTO> articuloDisp = new List<ProductoDTO>(_articulos.OwnDataList3);
            ProductoDTO art = new ProductoDTO();
            articuloDisp.Insert(0, art);

            this.cbxFiltroCodArticuloDisponible.DataSource = null;
            this.cbxFiltroCodArticuloDisponible.DataSource = articuloDisp;
            this.cbxFiltroCodArticuloDisponible.DisplayMember = "codigo";

            this.cbxFiltroNombreArticuloDisponible.DataSource = null;
            this.cbxFiltroNombreArticuloDisponible.DataSource = articuloDisp;
            this.cbxFiltroNombreArticuloDisponible.DisplayMember = "descripcion";
        }

        private void cargarArticulosPnlIzquierdo()
        {
            //completo panel izquierdo
            _precios.refreshGridData(cbxFiltroCodDeProveedor.Text);

            this.dgvArticulosEnLista.DataSource = _precios.GridDataList;
            this.dgvArticulosEnLista.Font = this.txtCodDeProveedor.Font;
            this.dgvArticulosEnLista.ClearSelection();

            List<PrecioProveedorDTO> precioProv = new List<PrecioProveedorDTO>(_precios.GridDataList);
            PrecioProveedorDTO precio = new PrecioProveedorDTO();
            precioProv.Insert(0, precio);

            this.cbxFiltroCodArticuloEnLista.DataSource = null;
            this.cbxFiltroCodArticuloEnLista.DataSource = precioProv;
            this.cbxFiltroCodArticuloEnLista.DisplayMember = "codigo";

            this.cbxFiltroNombreArticuloEnLista.DataSource = null;
            this.cbxFiltroNombreArticuloEnLista.DataSource = precioProv;
            this.cbxFiltroNombreArticuloEnLista.DisplayMember = "producto";
        }

        private void cargarFiltroProveedores()
        {
            this.cbxFiltroCodDeProveedor.DataSource = _proveedores.CodDataList;
            this.cbxFiltroNombreDeProveedor.DataSource = _proveedores.NombreDataList;
        }

        private void configurarGridArticulosDisponibles()
        {
            this.dgvArticulosDisponibles.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 140;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 418;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _descripcion.ReadOnly = true;

            this.dgvArticulosDisponibles.Columns.Add(_codigo);
            this.dgvArticulosDisponibles.Columns.Add(_descripcion);
        }

        private void loadPreciosProveedor()
        {
            clearForm();

            if (cbxFiltroCodDeProveedor.Text != string.Empty)
            {
                cargarArticulosPnlDerecho();
                cargarArticulosPnlIzquierdo();
            }
            else
            {
                dgvArticulosEnLista.DataSource = null;
                dgvArticulosDisponibles.DataSource = null;
            }
        }

        private void cbxFiltroCodDeProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroNombreDeProveedor.Text = _proveedores.obtenerNombre(this.cbxFiltroCodDeProveedor.Text);
            loadPreciosProveedor();  
        }

        private void cbxFiltroNombreDeProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxFiltroCodDeProveedor.Text = _proveedores.obtenerCodigo(this.cbxFiltroNombreDeProveedor.Text);
            loadPreciosProveedor();        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //al fin hago algo bien...
            if (dgvArticulosDisponibles.SelectedRows.Count > 0)
            {
                _precios.generarPrecio((ProductoDTO)dgvArticulosDisponibles.SelectedRows[0].DataBoundItem, cbxFiltroCodDeProveedor.Text);
                _precios.insertar();
                cargarArticulosPnlIzquierdo();
                cargarArticulosPnlDerecho();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvArticulosEnLista.SelectedRows.Count > 0)
            {
                _precios.generarPrecio((PrecioProveedorDTO)dgvArticulosEnLista.SelectedRows[0].DataBoundItem);
                _precios.borrar();
                cargarArticulosPnlIzquierdo();
                cargarArticulosPnlDerecho();
            }
        }

        private void objectToForm(PrecioProveedorDTO precio){
            txtCodDeProveedor.Text = precio.Id_proveedor;
            txtCodDeArticulo.Text = precio.Codigo;
            txtPrecio.Text = precio.Valor.ToString();
        }

        private void dgvArticulosEnLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvArticulosEnLista.SelectedRows.Count > 0)
            {
                this.objectToForm((PrecioProveedorDTO)dgvArticulosEnLista.SelectedRows[0].DataBoundItem);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtPrecio.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private PrecioProveedorDTO formToObject()
        {
            PrecioProveedorDTO precio = new PrecioProveedorDTO();
            precio.Id_producto = ProductoDTO.buscarId4(txtCodDeArticulo.Text);
            precio.Id_proveedor = txtCodDeProveedor.Text;
            precio.Valor = Math.Round(decimal.Parse(txtPrecio.Text), 2, MidpointRounding.AwayFromZero);
            precio.Codigo = txtCodDeArticulo.Text;
            return precio;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PrecioProveedorDTO data = formToObject();
                _precios.generarPrecio(data);
                _precios.actualizar();
                clearForm();
                
                if (cbxFiltroCodArticuloEnLista.Text != string.Empty)
                {
                    cargarGridArticulosEnLista();
                }
                else
                {
                    cargarArticulosPnlIzquierdo();
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Precio");
            }
        }

        private void clearForm(){
            txtCodDeProveedor.Text = string.Empty;
            txtCodDeArticulo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }



        private void cargarGridArticulosDisponibles()
        {
            _articulos.refreshGridData3(cbxFiltroCodDeProveedor.Text, cbxFiltroCodArticuloDisponible.Text);
            
            this.dgvArticulosDisponibles.DataSource = null;
            this.dgvArticulosDisponibles.DataSource = _articulos.GridDataList3;
            this.dgvArticulosDisponibles.ClearSelection();
        }

        private void cargarGridArticulosEnLista()
        {
            _precios.refreshGridData2(cbxFiltroCodDeProveedor.Text, cbxFiltroCodArticuloEnLista.Text);

            this.dgvArticulosEnLista.DataSource = null;
            this.dgvArticulosEnLista.DataSource = _precios.GridDataList2;
            this.dgvArticulosEnLista.ClearSelection();
        }

        private void btnFiltrarArticuloDisponible_Click(object sender, EventArgs e)
        {
            if (cbxFiltroCodArticuloDisponible.Text != string.Empty)
            {
                cargarGridArticulosDisponibles();
            }
            else
            {
                cargarArticulosPnlDerecho();
            }
        }

        private void btnFiltrarArticuloEnLista_Click(object sender, EventArgs e)
        {
            clearForm();

            if (cbxFiltroCodArticuloEnLista.Text != string.Empty)
            {
                cargarGridArticulosEnLista();
            }
            else
            {
                cargarArticulosPnlIzquierdo();
            }
        }



        private void cbxFiltroArticulosDisponibles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbxFiltroCodArticuloDisponible.Text != string.Empty)
                {
                    cargarGridArticulosDisponibles();
                }
                else
                {
                    cargarArticulosPnlDerecho();
                }
            }
        }


        private void cbxFiltroArticulosEnLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clearForm();

                if (cbxFiltroCodArticuloEnLista.Text != string.Empty)
                {
                    cargarGridArticulosEnLista();
                }
                else
                {
                    cargarArticulosPnlIzquierdo();
                }
            }
        }

    }
}

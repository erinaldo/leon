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
    public partial class frmArticulosYNeumaticos : Form
    {
        private Producto _productos;
        private MedidaCubierta _medidas;
        private Cuenta _cuenta;


        public frmArticulosYNeumaticos()
        {
            InitializeComponent();
            _productos = new Producto();
            _medidas = new MedidaCubierta();
            _cuenta = new Cuenta();
            
        }

        private void frmArticulosYNeumaticos_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }

            cargarFiltrosArticulo();
            cargarFiltrosNeumatico();
            cargarFormArticulo();
            cargarFormNeumatico();
            configurarGridArticulos();
            configurarGridNeumaticos();
            cargarGridArticulos();
            cargarGridNeumaticos();
            clearFormArticulo();
            clearFormNeumatico();
        }



        private void cargarFormArticulo()
        {
            this.cbxCodigoCuentaCompra.DataSource = _cuenta.OwnDataList;
            this.cbxCodigoCuentaCompra.DisplayMember = "codigo";
            this.cbxCodigoCuentaCompra.ValueMember = "id";

            this.cbxDescripcionCuentaCompra.DataSource = _cuenta.OwnDataList;
            this.cbxDescripcionCuentaCompra.DisplayMember = "descripcion";
            this.cbxDescripcionCuentaCompra.ValueMember = "id";

            IList<CuentaDTO> cuentasActivas = new List<CuentaDTO>(_cuenta.OwnDataList); //independencia

            this.cbxCodigoCuentaVenta.DataSource = cuentasActivas;
            this.cbxCodigoCuentaVenta.DisplayMember = "codigo";
            this.cbxCodigoCuentaVenta.ValueMember = "id";

            this.cbxDescripcionCuentaVenta.DataSource = cuentasActivas;
            this.cbxDescripcionCuentaVenta.DisplayMember = "descripcion";
            this.cbxDescripcionCuentaVenta.ValueMember = "id";
        }

        private void cargarFormNeumatico()
        {
            IList<CuentaDTO> cuentasActivas = new List<CuentaDTO>(_cuenta.OwnDataList); //independencia

            this.cbxCodigoCuentaVentaNeumatico.DataSource = cuentasActivas;
            this.cbxCodigoCuentaVentaNeumatico.DisplayMember = "codigo";
            this.cbxCodigoCuentaVentaNeumatico.ValueMember = "id";

            this.cbxDescripcionCuentaVentaNeumatico.DataSource = cuentasActivas;
            this.cbxDescripcionCuentaVentaNeumatico.DisplayMember = "descripcion";
            this.cbxDescripcionCuentaVentaNeumatico.ValueMember = "id";
        }

        private void configurarGridArticulos()
        {
            this.dgvProductos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 80;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 358;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _vigente = new DataGridViewTextBoxColumn();
            _vigente.DataPropertyName = "vigente";
            _vigente.HeaderText = "Vigente";
            _vigente.Width = 60;
            _vigente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.ReadOnly = true;

            DataGridViewTextBoxColumn _stock = new DataGridViewTextBoxColumn();
            _stock.DataPropertyName = "stock";
            _stock.HeaderText = "Stock";
            _stock.Width = 60;
            _stock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _stock.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _stock.ReadOnly = true;

            this.dgvProductos.Columns.Add(_codigo);
            this.dgvProductos.Columns.Add(_descripcion);
            this.dgvProductos.Columns.Add(_stock);
            this.dgvProductos.Columns.Add(_vigente);
        }


        private void configurarGridNeumaticos()
        {
            this.dgvNeumaticos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _medidaCubierta = new DataGridViewTextBoxColumn();
            _medidaCubierta.DataPropertyName = "medida_cubierta";
            _medidaCubierta.HeaderText = "Medida de Cubierta";
            _medidaCubierta.Width = 478;
            _medidaCubierta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubierta.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _medidaCubierta.ReadOnly = true;

            DataGridViewTextBoxColumn _vigente = new DataGridViewTextBoxColumn();
            _vigente.DataPropertyName = "vigente";
            _vigente.HeaderText = "Vigente";
            _vigente.Width = 80;
            _vigente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.ReadOnly = true;

            this.dgvNeumaticos.Columns.Add(_medidaCubierta);
            this.dgvNeumaticos.Columns.Add(_vigente);
        }


        private void btnFiltrarProducto_Click(object sender, EventArgs e)
        {
            clearFormArticulo();
            cargarGridArticulos();
        }


        

        private void clearFormArticulo()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtCodigo.ReadOnly = false;
            this.txtCodigoDeBarras.Text = string.Empty;
            this.txtPrecioReferente.Text = string.Empty;
            this.txtDescripcionProducto.Text = string.Empty;
            this.cbhVigenteProducto.Checked = true;
            this.cbxCodigoCuentaCompra.Text = string.Empty;
            this.cbxCodigoCuentaVenta.Text = string.Empty;
            this.cbxDescripcionCuentaCompra.Text = string.Empty;
            this.cbxDescripcionCuentaVenta.Text = string.Empty;
            this.txtId.Text = "-1";
            this.txtStockActual.Text = "0";
            this.btnGuardar.Text = "Crear";
        }

        private void clearFormNeumatico()
        {
            this.txtMedidaDeCubierta.Text = string.Empty;
            this.cbhVigenteNeumatico.Checked = true;
            this.cbxCodigoCuentaCompra.Text = string.Empty;
            this.cbxCodigoCuentaVentaNeumatico.Text = string.Empty;
            this.cbxDescripcionCuentaVentaNeumatico.Text = string.Empty;
            this.txtIdNeumatico.Text = "-1";
            this.btnGuardarNeumatico.Text = "Crear";
        }

        private void cargarGridArticulos()
        {
            _productos.refreshGridData(cbxFiltroDescripcionProducto.Text);
            this.dgvProductos.DataSource = null;
            this.dgvProductos.DataSource = _productos.GridDataList;
            this.dgvProductos.ClearSelection();
        }

        private void cargarGridNeumaticos()
        {
            _productos.refreshGridData2(cbxFiltroMedidaCubierta.Text);
            this.dgvNeumaticos.DataSource = null;
            this.dgvNeumaticos.DataSource = _productos.GridDataList2;
            this.dgvNeumaticos.ClearSelection();
        }

        private void txtPrecioReferente_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtPrecioReferente.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private ProductoDTO formToObjectNeumatico()
        {
            ProductoDTO p = new ProductoDTO();
            p.Codigo = "AUTO";
            p.Descripcion = "CUBIERTA";
            p.Medida_cubierta = this.txtMedidaDeCubierta.Text;
            p.Id = long.Parse(this.txtIdNeumatico.Text);
            p.Es_cubierta = 'S';

            if (cbhVigenteNeumatico.Checked == true)
            {
                p.Vigente = 'S';
            }
            else
            {
                p.Vigente = 'N';
            }

            if (this.cbxCodigoCuentaVentaNeumatico.SelectedValue.ToString() != "0")
                p.Id_cuenta_venta = long.Parse(this.cbxCodigoCuentaVentaNeumatico.SelectedValue.ToString());
            else
                p.Id_cuenta_venta = -1;

            return p;
        }

        private ProductoDTO formToObjectArticulo()
        {
            ProductoDTO p = new ProductoDTO();
            p.Descripcion = this.txtDescripcionProducto.Text;
            p.Codigo_de_barras = this.txtCodigoDeBarras.Text;
            p.Codigo = this.txtCodigo.Text;
            p.Id = long.Parse(this.txtId.Text);
            if (txtPrecioReferente.Text != string.Empty)
            {
                p.Precio_de_referencia = Math.Round(decimal.Parse(txtPrecioReferente.Text), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                p.Precio_de_referencia = decimal.Zero;
            }

            p.Es_cubierta = 'N';

            if (cbhVigenteProducto.Checked == true)
            {
                p.Vigente = 'S';
            }
            else
            {
                p.Vigente = 'N';
            }

            if (this.cbxCodigoCuentaCompra.SelectedValue.ToString() != "0")
                p.Id_cuenta_compra = long.Parse(this.cbxCodigoCuentaCompra.SelectedValue.ToString());
            else
                p.Id_cuenta_compra = -1;

            if (this.cbxCodigoCuentaVenta.SelectedValue.ToString() != "0")
                p.Id_cuenta_venta = long.Parse(this.cbxCodigoCuentaVenta.SelectedValue.ToString());
            else
                p.Id_cuenta_venta = -1;

            return p;
        }

        private void cargarFiltrosArticulo()
        {
            _productos.refreshOwnData2();
            this.cbxFiltroDescripcionProducto.DataSource = null;
            this.cbxFiltroDescripcionProducto.DataSource = _productos.OwnDataList2;
            this.cbxFiltroDescripcionProducto.DisplayMember = "descripcion";
        }


        private void cargarFiltrosNeumatico()
        {
            _medidas.refreshOwnData2();
            this.cbxFiltroMedidaCubierta.DataSource = null;
            this.cbxFiltroMedidaCubierta.DataSource = _medidas.OwnDataList2;
            this.cbxFiltroMedidaCubierta.DisplayMember = "medida_cubierta";
            this.cbxFiltroMedidaCubierta.ValueMember = "id";
        }

        private bool ErrorDuplicidadArticulo(ref string msg)
        {

            bool rv = false;

            if (this.txtDescripcionProducto.Text != "")
            {
                int resultIndex = this.cbxFiltroDescripcionProducto.FindStringExact(txtDescripcionProducto.Text);
                if (resultIndex != -1)
                {
                    msg = "\nExiste un artículo con la descripción ingresada.";
                    rv = true;
                }
            }

            if (this.txtCodigo.Text != "")
            {
                if (ProductoDTO.existeCodigo(txtCodigo.Text))
                {
                    msg = "\nExiste un artículo con el código ingresado.";
                    rv = true;
                }
            }

            if (this.txtCodigoDeBarras.Text != "")
            {
                if (ProductoDTO.existeCodigoDeBarra(txtCodigoDeBarras.Text))
                {
                    msg = "\nExiste un artículo con el código de barras ingresado.";
                    rv = true;
                }
            }

            return rv;

        }


        private bool ErrorDuplicidadNeumatico(ref string msg)
        {
            bool rv = false;

            if (this.txtMedidaDeCubierta.Text != "")
            {
                int resultIndex = this.cbxFiltroMedidaCubierta.FindStringExact(txtMedidaDeCubierta.Text);
                if (resultIndex != -1)
                {
                    msg = "\nExiste un neumático con la medida ingresada.";
                    rv = true;
                }
            }

            return rv;
        }

        private void objectToFormNeumatico(ProductoDTO p)
        {
            txtMedidaDeCubierta.Text = p.Medida_cubierta;

            if (p.Vigente == 'S')
            {
                cbhVigenteNeumatico.Checked = true;
            }
            else
            {
                cbhVigenteNeumatico.Checked = false;
            }

            if (p.Id_cuenta_venta == -1 && this.cbxCodigoCuentaVentaNeumatico.Items.Count != 0)
            {
                this.cbxCodigoCuentaVentaNeumatico.SelectedIndex = 0;
            }
            else
            {
                this.cbxCodigoCuentaVentaNeumatico.Text = CuentaDTO.obtenerCodigo(p.Id_cuenta_venta);
            }

            if (p.Id_cuenta_venta == -1 && this.cbxDescripcionCuentaVentaNeumatico.Items.Count != 0)
            {
                this.cbxDescripcionCuentaVentaNeumatico.SelectedIndex = 0;
            }
            else
            {
                this.cbxDescripcionCuentaVentaNeumatico.Text = CuentaDTO.obtenerDescripcion(p.Id_cuenta_venta);
            }

            txtIdNeumatico.Text = p.Id.ToString();
        }


        private void objectToFormArticulo(ProductoDTO p)
        {
            txtStockActual.Text = p.Stock.ToString();
            txtDescripcionProducto.Text = p.Descripcion;
            txtCodigo.Text = p.Codigo;
            txtCodigoDeBarras.Text = p.Codigo_de_barras;
            txtPrecioReferente.Text = p.Precio_de_referencia.ToString();
            if (p.Vigente == 'S')
            {
                cbhVigenteProducto.Checked = true;
            }
            else
            {
                cbhVigenteProducto.Checked = false;
            }

            if (p.Id_cuenta_compra == -1 && this.cbxCodigoCuentaCompra.Items.Count != 0)
            {
                this.cbxCodigoCuentaCompra.SelectedIndex = 0;
            }
            else
            {
                this.cbxCodigoCuentaCompra.Text = CuentaDTO.obtenerCodigo(p.Id_cuenta_compra);
            }

            if (p.Id_cuenta_compra == -1 && this.cbxDescripcionCuentaCompra.Items.Count != 0)
            {
                this.cbxDescripcionCuentaCompra.SelectedIndex = 0;
            }
            else
            {
                this.cbxDescripcionCuentaCompra.Text = CuentaDTO.obtenerDescripcion(p.Id_cuenta_compra);
            }

            if (p.Id_cuenta_venta == -1 && this.cbxCodigoCuentaVenta.Items.Count != 0)
            {
                this.cbxCodigoCuentaVenta.SelectedIndex = 0;
            }
            else
            {
                this.cbxCodigoCuentaVenta.Text = CuentaDTO.obtenerCodigo(p.Id_cuenta_venta);
            }

            if (p.Id_cuenta_venta == -1 && this.cbxDescripcionCuentaVenta.Items.Count != 0)
            {
                this.cbxDescripcionCuentaVenta.SelectedIndex = 0;
            }
            else
            {
                this.cbxDescripcionCuentaVenta.Text = CuentaDTO.obtenerDescripcion(p.Id_cuenta_venta);
            }

            txtId.Text = p.Id.ToString();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvProductos.SelectedRows.Count > 0)
            {
                this.objectToFormArticulo((ProductoDTO)this.dgvProductos.SelectedRows[0].DataBoundItem);
                txtCodigo.ReadOnly = true;
                this.btnGuardar.Text = "Guardar";
            }
        }

        private void dgvNeumaticos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvNeumaticos.SelectedRows.Count > 0)
            {
                this.objectToFormNeumatico((ProductoDTO)this.dgvNeumaticos.SelectedRows[0].DataBoundItem);
                this.btnGuardarNeumatico.Text = "Guardar";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el artículo del sistema?. Esta acción borra los movimiento de stock de éste artículo y lo borra de la lista de precio.", "Artículos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _productos.delete(((ProductoDTO)this.dgvProductos.SelectedRows[0].DataBoundItem));
                        cargarFiltrosArticulo(); //refresco los filtros
                        cargarGridArticulos(); //cargo grilla
                        clearFormArticulo();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el artículo que desea borrar.", "Validación Borrar Artículo");
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Artículo");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            clearFormArticulo();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProductoDTO actual = formToObjectArticulo();

                if (actual.Id != -1)
                {
                    //actualizando...
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el artículo?", "Artículos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._productos.update(actual);
                        cargarGridArticulos();
                        cargarFiltrosArticulo();
                        clearFormArticulo();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo artículo?", "Artículos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string msg = "";

                        if (!ErrorDuplicidadArticulo(ref msg))
                        {
                            this._productos.insert(actual);
                            cargarGridArticulos();
                            cargarFiltrosArticulo();
                            clearFormArticulo();
                        }
                        else
                        {
                            MessageBox.Show("No ha sido posible crear el nuevo artículo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Artículos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Artículo");
            }
        }


        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            clearFormArticulo();
            cargarGridArticulos();
            }
        }


        private void btnLimpiarNeumatico_Click(object sender, EventArgs e)
        {
            clearFormNeumatico();
        }

        private void btnRealizarMovimiento_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.SelectedRows.Count > 0)
            {
                ProductoDTO p = ((ProductoDTO)this.dgvProductos.SelectedRows[0].DataBoundItem);

                frmAjusteDeStock frmAjuste = new frmAjusteDeStock(p.Id, p.Descripcion);
                frmAjuste.ShowDialog();
                frmAjuste.Dispose();
                cargarGridArticulos(); //cargo grilla
                clearFormArticulo();
            }
            else
            {
                MessageBox.Show("Seleccione el artículo para ajustar el stock.", "Validación Ajuste de Stock");
            }
        }

        private void btnBorrarNeumatico_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNeumaticos.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el neumático del sistema?. Esta acción borra el neumático de la lista de precio.", "Artículos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _productos.delete(((ProductoDTO)this.dgvNeumaticos.SelectedRows[0].DataBoundItem));
                        cargarFiltrosNeumatico(); //refresco los filtros
                        cargarGridNeumaticos(); //cargo grilla
                        clearFormNeumatico();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el neumático que desea borrar.", "Validación Borrar Neumático");
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Neumático");
            }
        }

        private void btnGuardarNeumatico_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoDTO actual = formToObjectNeumatico();

                if (actual.Id != -1)
                {
                    //actualizando...
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el neumático?", "Neumáticos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._productos.update(actual);
                        cargarGridNeumaticos();
                        cargarFiltrosNeumatico();
                        clearFormNeumatico();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo neumático?", "Neumáticos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string msg = "";

                        if (!ErrorDuplicidadNeumatico(ref msg))
                        {
                            this._productos.insert(actual);
                            cargarGridNeumaticos();
                            cargarFiltrosNeumatico();
                            clearFormNeumatico();
                        }
                        else
                        {
                            MessageBox.Show("No ha sido posible crear el nuevo neumático. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Neumáticos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Neumáticos");
            }
        }

        private void btnFiltrarNeumatico_Click(object sender, EventArgs e)
        {
            clearFormNeumatico();
            cargarGridNeumaticos();
        }

        private void cbxFiltroMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clearFormNeumatico();
                cargarGridNeumaticos();
            }
        }


        


    }
}

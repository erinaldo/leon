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
    public partial class frmABMDeProveedores : Form
    {

        private Proveedores _proveedores;
        private CategoriaIva _categoriaIva;
        private Provincias _provincias;
        private Localidades _localidades;
        private FiltrosABMProveedor _filtroProveedores;
        private CondicionCompra _condicionCompra;

        public frmABMDeProveedores()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _categoriaIva = new CategoriaIva();
            _provincias = new Provincias();
            _localidades = new Localidades();
            _filtroProveedores = new FiltrosABMProveedor();
            _condicionCompra = new CondicionCompra();
        }

        private void frmABMDeProveedores_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            this.cargarFormulario();
            this.cargarFiltrosDeBusqueda();
            this.configurarGridProveedores();
        }

        private void configurarGridProveedores()
        {
            this.dgvProveedores.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn codigoColumn = new DataGridViewTextBoxColumn();
            codigoColumn.DataPropertyName = "id";
            codigoColumn.HeaderText = "Código";
            codigoColumn.Width = 70;
            codigoColumn.HeaderCell.Style.Font = txtCodigo.Font;

            DataGridViewTextBoxColumn nombreColumn = new DataGridViewTextBoxColumn();
            nombreColumn.DataPropertyName = "nombre";
            nombreColumn.HeaderText = "Nombre";
            nombreColumn.Width = 234;
            nombreColumn.HeaderCell.Style.Font = txtCodigo.Font;

            DataGridViewTextBoxColumn cuitColumn = new DataGridViewTextBoxColumn();
            cuitColumn.DataPropertyName = "cuit";
            cuitColumn.HeaderText = "Cuit";
            cuitColumn.Width = 100;
            cuitColumn.HeaderCell.Style.Font = txtCodigo.Font;

            DataGridViewTextBoxColumn categoriaIvaColumn = new DataGridViewTextBoxColumn();
            categoriaIvaColumn.DataPropertyName = "categoria_iva";
            categoriaIvaColumn.HeaderText = "Categoría Iva";
            categoriaIvaColumn.Width = 154;
            categoriaIvaColumn.HeaderCell.Style.Font = txtCodigo.Font;

            this.dgvProveedores.Columns.Add(codigoColumn);
            this.dgvProveedores.Columns.Add(nombreColumn);
            this.dgvProveedores.Columns.Add(cuitColumn);
            this.dgvProveedores.Columns.Add(categoriaIvaColumn);
        }

        private void cargarFormulario()
        {

            this.cbxCategoriaIva.DataSource = _categoriaIva.OwnDataList;
            this.cbxCategoriaIva.DisplayMember = "valor";
            this.cbxCategoriaIva.ValueMember = "id";

            this.cbxProvincia.DataSource = _provincias.OwnDataList;
            this.cbxProvincia.DisplayMember = "valor";
            this.cbxProvincia.ValueMember = "id";

            _localidades.refreshOwnDataProv(int.Parse(this.cbxProvincia.SelectedValue.ToString()));
            this.cbxLocalidad.DataSource = _localidades.OwnDataListProv;
            this.cbxLocalidad.DisplayMember = "valor";
            this.cbxLocalidad.ValueMember = "id";

            this.cbxCondicionDeCompra.DataSource = _condicionCompra.OwnDataList;
            this.cbxCondicionDeCompra.DisplayMember = "valor";
            this.cbxCondicionDeCompra.ValueMember = "id";

        }

        private void cargarFiltrosDeBusqueda()
        {
            _proveedores.refreshFiltroData();
            _localidades.refreshOwnData();

            this.cbxFiltroCodigo.DataSource = null;
            this.cbxFiltroCodigo.DataSource = _proveedores.CodDataList;

            this.cbxFiltroNombre.DataSource = null;
            this.cbxFiltroNombre.DataSource = _proveedores.NombreDataList;

            this.cbxFiltroCUIT.DataSource = null;
            this.cbxFiltroCUIT.DataSource = _proveedores.CuitDataList;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FilterToObjectABM();
            cargarGridProveedores();
        }

        private void FilterToObjectABM()
        {
            _filtroProveedores.FiltroCodigo = this.cbxFiltroCodigo.Text;
            _filtroProveedores.FiltroNombre = this.cbxFiltroNombre.Text;
            _filtroProveedores.FiltroCUIT = this.cbxFiltroCUIT.Text;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.clearForm();
            this.txtCodigo.Focus();
        }

        private void clearForm()
        {
            this.objectToForm(new ProveedorDTO());
            txtCodigo.ReadOnly = false;
        }

        private void objectToForm(ProveedorDTO data)
        {
            this.txtCodigo.Text = data.Id;
            this.txtNombre.Text = data.Nombre;
            this.txtCuit.Text = data.Cuit;
            this.txtIngresosBrutos.Text = data.Nro_ingresos_brutos;

            if (data.Provincia == "" && this.cbxProvincia.Items.Count != 0)
            {
                this.cbxProvincia.SelectedIndex = 0;
            }
            else
            {
                this.cbxProvincia.Text = data.Provincia;
            }

            _localidades.refreshOwnDataProv(int.Parse(this.cbxProvincia.SelectedValue.ToString()));
            this.cbxLocalidad.DataSource = _localidades.OwnDataListProv;
            this.cbxLocalidad.DisplayMember = "valor";
            this.cbxLocalidad.ValueMember = "id";

            if (data.Localidad != "")
            {
                this.cbxLocalidad.Text = data.Localidad;
            }

            this.txtDireccion.Text = data.Direccion;

            if (data.Id_categoria_iva == -1 && this.cbxCategoriaIva.Items.Count != 0)
            {
                this.cbxCategoriaIva.SelectedIndex = 0;

            }
            else
            {
                this.cbxCategoriaIva.Text = data.Categoria_iva;
            }

            if (data.Id_condicion_compra == -1 && this.cbxCondicionDeCompra.Items.Count != 0)
            {
                this.cbxCondicionDeCompra.SelectedIndex = 0;

            }
            else
            {
                this.cbxCondicionDeCompra.Text = data.Condicion_compra;
            }

            this.txtCP.Text = data.Codigo_postal;
            this.txtTelefono.Text = data.Telefono_1;
            this.txtTelefono2.Text = data.Telefono_2;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorDTO data = this.formToObject();

                bool ok = false;

                if (!this.txtCodigo.ReadOnly)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo proveedor?", "Proveedores", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _proveedores.insert(data);
                        ok = true;
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar los datos del proveedor?", "Proveedores", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _proveedores.update(data);
                        ok = true;
                    }
                }
                if (ok)
                {
                    this.cargarFiltrosDeBusquedaPost();
                    this.cargarGridProveedores();
                    this.clearForm();
                    this.txtCodigo.Focus();
                    MessageBox.Show("La operación fue realizada con éxito.", "Proveedores");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Proveedor");
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvProveedores.SelectedRows.Count > 0)
            {
                this.objectToForm((ProveedorDTO)this.dgvProveedores.SelectedRows[0].DataBoundItem);
                txtCodigo.ReadOnly = true;
            }
        }

        private void cargarGridProveedores()
        {

            if (_filtroProveedores.FiltroCodigo == "" && _filtroProveedores.FiltroNombre == "" && _filtroProveedores.FiltroCUIT == "")
            {
                FilterToObjectABMFalse();
            }

            _proveedores.refreshGridData(_filtroProveedores);
            this.dgvProveedores.DataSource = _proveedores.GridDataList;
            this.dgvProveedores.Font = txtCodigo.Font;
            this.dgvProveedores.ClearSelection();

        }

        private void FilterToObjectABMFalse()
        {
            _filtroProveedores.FiltroCodigo = "XXXXXXXX";
            _filtroProveedores.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroProveedores.FiltroCUIT = "XXXXXXXX";
        }

        private void cargarFiltrosDeBusquedaPost()
        {
            _proveedores.refreshFiltroData();

            this.cbxFiltroCodigo.DataSource = null;
            this.cbxFiltroCodigo.DataSource = _proveedores.CodDataList;

            this.cbxFiltroNombre.DataSource = null;
            this.cbxFiltroNombre.DataSource = _proveedores.NombreDataList;

            this.cbxFiltroCUIT.DataSource = null;
            this.cbxFiltroCUIT.DataSource = _proveedores.CuitDataList;
        }


        private ProveedorDTO formToObject()
        {
            ProveedorDTO rv = new ProveedorDTO();

            rv.Id = this.txtCodigo.Text;

            rv.Nombre = this.txtNombre.Text;

            rv.Cuit = this.txtCuit.Text;

            if (this.txtIngresosBrutos.Text != "")
                rv.Nro_ingresos_brutos = this.txtIngresosBrutos.Text;
            else
                rv.Nro_ingresos_brutos = string.Empty;

            rv.Codigo_postal = this.txtCP.Text;
            
            rv.Direccion = this.txtDireccion.Text;

            rv.Telefono_1 = this.txtTelefono.Text;

            rv.Telefono_2 = this.txtTelefono2.Text;

            if (this.cbxLocalidad.Text != "")
                rv.Localidad = this.cbxLocalidad.Text;
            else
                rv.Localidad = string.Empty;

            if (this.cbxProvincia.Text != "")
                rv.Provincia = this.cbxProvincia.Text;
            else
                rv.Provincia = string.Empty;

            if (this.cbxCategoriaIva.SelectedValue != null)
                rv.Id_categoria_iva = long.Parse(this.cbxCategoriaIva.SelectedValue.ToString());
            else
                rv.Id_categoria_iva = -1;

            if (this.cbxCondicionDeCompra.SelectedValue != null)
                rv.Id_condicion_compra = long.Parse(this.cbxCondicionDeCompra.SelectedValue.ToString());
            else
                rv.Id_condicion_compra = -1;

            return rv;
        }

        private void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectABMFalse();
            cargarGridProveedores();
            this.cbxFiltroCodigo.Focus();
        }

        private void clearFilter()
        {
            this.objectToFilterABM(new FiltrosABMProveedor());
        }

        private void objectToFilterABM(FiltrosABMProveedor filtro)
        {
            this.cbxFiltroCodigo.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombre.Text = filtro.FiltroNombre;
            this.cbxFiltroCUIT.Text = filtro.FiltroCUIT;
        }

        private void cbxProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxLocalidad.Text = string.Empty;
            _localidades.refreshOwnDataProv(int.Parse(this.cbxProvincia.SelectedValue.ToString()));
            this.cbxLocalidad.DataSource = _localidades.OwnDataListProv;
            this.cbxLocalidad.DisplayMember = "valor";
            this.cbxLocalidad.ValueMember = "id";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvProveedores.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el proveedor y la cuenta corriente? Usted no podrá acceder a toda aquella información relacionada al proveedor.", "Proveedores", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _proveedores.delete(((ProveedorDTO)this.dgvProveedores.SelectedRows[0].DataBoundItem).Id);
                        cargarFiltrosDeBusquedaPost(); //refresco los filtros
                        cargarGridProveedores(); //cargo grilla
                        this.clearForm();
                    }


                }
                this.cbxFiltroCodigo.Focus();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Proveedor");
            }
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterToObjectABM();
                cargarGridProveedores();
            }
        }

    }
}

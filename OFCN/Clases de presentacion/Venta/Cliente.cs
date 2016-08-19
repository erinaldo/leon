using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//cambio en el diseño feb 1.9.1
namespace OFC
{
    public partial class frmABMDeClientes : Form
    {
        private Clientes _clientes;
        private Sexo _sexo;
        private CategoriaIva _categoriaIva;
        private Provincias _provincias;
        private Localidades _localidades;
        private Vendedores _vendedores;
        private FiltrosABMCliente _filtroClientes;
        private ListaDePrecio _listaDePrecio;
        private CondicionVenta _condicionVenta;
        private TipoPersona _tipoDePersona; //feb 1.9.1
        private TipoDocumento _tipoDeDocumento; //feb 1.9.1

        public frmABMDeClientes()
        {
            //bastante cargado, levanta de BD toda la info para mostrar la pantalla
            InitializeComponent();
            _clientes = new Clientes();
            _sexo = new Sexo();
            _categoriaIva = new CategoriaIva();
            _provincias = new Provincias();
            _localidades = new Localidades();
            _vendedores = new Vendedores();
            _filtroClientes = new FiltrosABMCliente();
            _listaDePrecio = new ListaDePrecio();
            _condicionVenta = new CondicionVenta();
            _tipoDePersona = new TipoPersona(); //feb 1.9.1
            _tipoDeDocumento = new TipoDocumento(); //feb 1.9.1
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvClientes.SelectedRows.Count > 0)
            {
                this.objectToForm((ClienteDTO)this.dgvClientes.SelectedRows[0].DataBoundItem);
                txtCodigo.ReadOnly = true;
            }
        }

        private void frmABMDeClientes_Load(object sender, EventArgs e)
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
            this.configurarGridClientes();
        }

        private void cargarFiltrosDeBusquedaPost()
        {
            _clientes.refreshFiltroData();
            _localidades.refreshOwnData();

            this.cbxFiltroCodigo.DataSource = null;
            this.cbxFiltroCodigo.DataSource = _clientes.CodDataList;

            this.cbxFiltroNombre.DataSource = null;
            this.cbxFiltroNombre.DataSource = _clientes.NombreDataList;

            this.cbxFiltroCUIT.DataSource = null;
            this.cbxFiltroCUIT.DataSource = _clientes.CuitDataList;

            this.cbxFiltroLocalidad.DataSource = null;
            this.cbxFiltroLocalidad.DataSource = _localidades.OwnDataList;
            this.cbxFiltroLocalidad.DisplayMember = "valor";
            this.cbxFiltroLocalidad.ValueMember = "id";
        }


        private void cargarFiltrosDeBusqueda()
        {
            _clientes.refreshFiltroData();
            _localidades.refreshOwnData();
            _vendedores.refreshFiltroData();

            this.cbxFiltroCodigo.DataSource = null;
            this.cbxFiltroCodigo.DataSource = _clientes.CodDataList;

            this.cbxFiltroNombre.DataSource = null;
            this.cbxFiltroNombre.DataSource = _clientes.NombreDataList;

            this.cbxFiltroLocalidad.DataSource = null;
            this.cbxFiltroLocalidad.DataSource = _localidades.OwnDataList;
            this.cbxFiltroLocalidad.DisplayMember = "valor";
            this.cbxFiltroLocalidad.ValueMember = "id";

            this.cbxFiltroVendedor.DataSource = null;
            this.cbxFiltroVendedor.DataSource = _vendedores.NameDataList;

            this.cbxFiltroCUIT.DataSource = null;
            this.cbxFiltroCUIT.DataSource = _clientes.CuitDataList;
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterToObjectABM();
                cargarGridClientes();
                //this.cbxFiltroCodigo.Focus();
            }
        }

        //feb 1.9.1
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

            this.cbxVendedor.DataSource = _vendedores.OwnDataList;
            this.cbxVendedor.DisplayMember = "nombre";
            this.cbxVendedor.ValueMember = "id";

            this.cbxListaDePrecio.DataSource = _listaDePrecio.OwnDataList;
            this.cbxListaDePrecio.DisplayMember = "valor";
            this.cbxListaDePrecio.ValueMember = "id";

            this.cbxCondicionDeVenta.DataSource = _condicionVenta.OwnDataList;
            this.cbxCondicionDeVenta.DisplayMember = "valor";
            this.cbxCondicionDeVenta.ValueMember = "id";

            //feb 1.9.1
            this.cbxTipoDePersona.DataSource = _tipoDePersona.OwnDataList;
            this.cbxTipoDePersona.DisplayMember = "valor";
            this.cbxTipoDePersona.ValueMember = "id_externo";

            //feb 1.9.1
            this.cbxTipoDeDocumento.DataSource = _tipoDeDocumento.OwnDataList;
            this.cbxTipoDeDocumento.DisplayMember = "valor";
            this.cbxTipoDeDocumento.ValueMember = "id_externo";

            this.txtDescuento.Text = "0";
        }


        private void cargarGridClientes()
        {

            if (_filtroClientes.FiltroCodigo == "" && _filtroClientes.FiltroNombre == "" && _filtroClientes.FiltroCUIT == "" && _filtroClientes.FiltroLocalidad == "" && _filtroClientes.FiltroVendedor == "")
            {
                FilterToObjectABMFalse();
            }

            _clientes.refreshGridData(_filtroClientes);
            this.dgvClientes.DataSource = _clientes.GridDataList;
            this.dgvClientes.Font = txtCodigo.Font;
            this.dgvClientes.ClearSelection();

        }

        private void configurarGridClientes()
        {
            this.dgvClientes.AutoGenerateColumns = false;

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

            this.dgvClientes.Columns.Add(codigoColumn);
            this.dgvClientes.Columns.Add(nombreColumn);
            this.dgvClientes.Columns.Add(cuitColumn);
            this.dgvClientes.Columns.Add(categoriaIvaColumn);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                ClienteDTO data = this.formToObject();

                bool ok = false;

                if (!this.txtCodigo.ReadOnly)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo cliente?", "Clientes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _clientes.insert(data);
                        ok = true;
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar los datos del cliente?", "Clientes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _clientes.update(data);
                        ok = true;
                    }
                }
                if (ok)
                {
                    this.cargarFiltrosDeBusquedaPost();
                    this.cargarGridClientes();
                    this.clearForm();
                    this.txtCodigo.Focus();
                    MessageBox.Show("La operación fue realizada con éxito.", "Clientes");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Cliente");
            }

        }


        //feb 1.9.1
        private ClienteDTO formToObject()
        {
            ClienteDTO rv = new ClienteDTO();

            rv.Id = this.txtCodigo.Text;

            if (this.txtNombre.Text != "")
            {
                rv.Nombre = this.txtNombre.Text;
            }
            else
            {
                rv.Nombre = string.Empty;
            }

            if (this.txtCuit.Text != "")
            {
                rv.Cuit = this.txtCuit.Text;
            }
            else
            {
                rv.Cuit = string.Empty;
            }

            rv.Direccion_legal = this.txtDireccion.Text;

            if (this.cbxLocalidad.Text != "")
                rv.Localidad_legal = this.cbxLocalidad.Text;
            else
                rv.Localidad_legal = string.Empty;

            if (this.cbxProvincia.Text != "")
                rv.Provincia_legal = this.cbxProvincia.Text;
            else
                rv.Provincia_legal = string.Empty;

            if (this.cbxCategoriaIva.SelectedValue != null)
                rv.Id_categoria_iva = long.Parse(this.cbxCategoriaIva.SelectedValue.ToString());
            else
                rv.Id_categoria_iva = -1;

            if (this.cbxCondicionDeVenta.SelectedValue != null)
                rv.Id_condicion_venta = long.Parse(this.cbxCondicionDeVenta.SelectedValue.ToString());
            else
                rv.Id_condicion_venta = -1;

            Decimal aux = new Decimal();
            if (Decimal.TryParse(this.txtDescuento.Text, out aux))
                rv.Descuento = aux;
            else
                rv.Descuento = 0;

            if (this.cbxListaDePrecio.SelectedValue != null)
                rv.Id_lista_precio = long.Parse(this.cbxListaDePrecio.SelectedValue.ToString());
            else
                rv.Id_lista_precio = -1;

            if (this.cbxVendedor.SelectedValue != null)
                rv.Id_vendedor = long.Parse(this.cbxVendedor.SelectedValue.ToString());
            else
                rv.Id_vendedor = -1;

            if (this.cbhFacturaPorCoche.Checked)
                rv.Factura_por_coche = 'S';
            else
                rv.Factura_por_coche = 'N';

            if (this.txtNombrePersona.Text != "")
            {
                rv.Nombre_persona = this.txtNombrePersona.Text;
            }
            else
            {
                rv.Nombre_persona = string.Empty;
            }

            if (this.txtApellidoPersona.Text != "")
            {
                rv.Apellido_persona = this.txtApellidoPersona.Text;
            }
            else
            {
                rv.Apellido_persona = string.Empty;
            }

            if (this.txtEmail.Text != "")
            {
                rv.Email = this.txtEmail.Text;
            }
            else
            {
                rv.Email = string.Empty;
            }

            if (this.txtCodigoPostal.Text != "")
            {
                rv.Codigo_postal = this.txtCodigoPostal.Text;
            }
            else
            {
                rv.Codigo_postal = string.Empty;
            }

            if (this.txtTelefonoFijo.Text != "")
            {
                rv.Telefono_fijo = this.txtTelefonoFijo.Text;
            }
            else
            {
                rv.Telefono_fijo = string.Empty;
            }

            if (this.txtTelefonoMovil.Text != "")
            {
                rv.Telefono_movil = this.txtTelefonoMovil.Text;
            }
            else
            {
                rv.Telefono_movil = string.Empty;
            }

            if (this.cbxTipoDePersona.SelectedValue != null)
                rv.Fw_id_tipo_persona_externo = int.Parse(this.cbxTipoDePersona.SelectedValue.ToString());
            else
                rv.Fw_id_tipo_persona_externo = -1;

            if (this.cbxTipoDeDocumento.SelectedValue != null)
                rv.Fw_id_tipo_documento_externo = int.Parse(this.cbxTipoDeDocumento.SelectedValue.ToString());
            else
                rv.Fw_id_tipo_documento_externo = -1;

            return rv;
        }

        private void cbxProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxLocalidad.Text = string.Empty;
            _localidades.refreshOwnDataProv(int.Parse(this.cbxProvincia.SelectedValue.ToString()));
            this.cbxLocalidad.DataSource = _localidades.OwnDataListProv;
            this.cbxLocalidad.DisplayMember = "valor";
            this.cbxLocalidad.ValueMember = "id";
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtDescuento.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.clearForm();
            this.txtCodigo.Focus();
        }

        private void clearForm()
        {
            this.objectToForm(new ClienteDTO());
            txtCodigo.ReadOnly = false;
        }


        //feb 1.9.1
        private void objectToForm(ClienteDTO data)
        {
            this.txtCodigo.Text = data.Id;
            this.txtNombre.Text = data.Nombre;
            this.txtCuit.Text = data.Cuit;
            this.txtDireccion.Text = data.Direccion_legal;

            if (data.Provincia_legal == "" && this.cbxProvincia.Items.Count != 0)
            {
                this.cbxProvincia.SelectedIndex = 0;
            }
            else
            {
                this.cbxProvincia.Text = data.Provincia_legal;
            }

            _localidades.refreshOwnDataProv(int.Parse(this.cbxProvincia.SelectedValue.ToString()));
            this.cbxLocalidad.DataSource = _localidades.OwnDataListProv;
            this.cbxLocalidad.DisplayMember = "valor";
            this.cbxLocalidad.ValueMember = "id";

            if (data.Localidad_legal != "")
            {
                this.cbxLocalidad.Text = data.Localidad_legal;
            }

            if (data.Id_categoria_iva == -1 && this.cbxCategoriaIva.Items.Count != 0)
            {
                this.cbxCategoriaIva.SelectedIndex = 0;

            }
            else
            {
                this.cbxCategoriaIva.Text = data.Categoria_iva;
            }

            if (data.Id_condicion_venta == -1 && this.cbxCondicionDeVenta.Items.Count != 0)
            {
                this.cbxCondicionDeVenta.SelectedIndex = 0;

            }
            else
            {
                this.cbxCondicionDeVenta.Text = data.Condicion_venta;
            }

            this.txtDescuento.Text = data.Descuento.ToString();

            if (data.Id_lista_precio == -1 && this.cbxListaDePrecio.Items.Count != 0)
            {
                this.cbxListaDePrecio.SelectedIndex = 0;
            }
            else
            {
                this.cbxListaDePrecio.Text = data.Lista_precio;
            }

            if (data.Id_vendedor == -1 && this.cbxVendedor.Items.Count != 0)
            {
                this.cbxVendedor.SelectedIndex = 0;
            }
            else
            {
                this.cbxVendedor.Text = data.Vendedor;
            }

            if (data.Factura_por_coche == 'S')
            {
                this.cbhFacturaPorCoche.Checked = true;
            }
            else
            {
                this.cbhFacturaPorCoche.Checked = false;
            }

            this.txtNombrePersona.Text = data.Nombre_persona;
            this.txtApellidoPersona.Text = data.Apellido_persona;
            this.txtCodigoPostal.Text = data.Codigo_postal;
            this.txtEmail.Text = data.Email;
            this.txtTelefonoFijo.Text = data.Telefono_fijo;
            this.txtTelefonoMovil.Text = data.Telefono_movil;

            if (data.Fw_id_tipo_persona_externo == -1 && this.cbxTipoDePersona.Items.Count != 0)
            {
                this.cbxTipoDePersona.SelectedIndex = 0;
            }
            else
            {
                this.cbxTipoDePersona.Text = data.Tipo_persona;
            }

            if (data.Fw_id_tipo_documento_externo == -1 && this.cbxTipoDeDocumento.Items.Count != 0)
            {
                this.cbxTipoDeDocumento.SelectedIndex = 0;
            }
            else
            {
                this.cbxTipoDeDocumento.Text = data.Tipo_documento;
            }

        }

        private void FilterToObjectABM()
        {
            _filtroClientes.FiltroCodigo = this.cbxFiltroCodigo.Text;
            _filtroClientes.FiltroNombre = this.cbxFiltroNombre.Text;
            _filtroClientes.FiltroCUIT = this.cbxFiltroCUIT.Text;
            _filtroClientes.FiltroLocalidad = this.cbxFiltroLocalidad.Text;
            _filtroClientes.FiltroVendedor = this.cbxFiltroVendedor.Text;
        }

        private void FilterToObjectABMFalse()
        {
            _filtroClientes.FiltroCodigo = "XXXXXXXX";
            _filtroClientes.FiltroNombre = "XXXXXXXXXXXXXXXX";
            _filtroClientes.FiltroCUIT = "XXXXXXXX";
            _filtroClientes.FiltroLocalidad = "XXXXXXXX";
            _filtroClientes.FiltroVendedor = "XXXXXXXX";
        }

        private void clearFilter()
        {
            this.objectToFilterABM(new FiltrosABMCliente());
        }

        private void objectToFilterABM(FiltrosABMCliente filtro)
        {
            this.cbxFiltroCodigo.Text = filtro.FiltroCodigo;
            this.cbxFiltroNombre.Text = filtro.FiltroNombre;
            this.cbxFiltroCUIT.Text = filtro.FiltroCUIT;
            this.cbxFiltroLocalidad.Text = filtro.FiltroLocalidad;
            this.cbxFiltroVendedor.Text = filtro.FiltroVendedor;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FilterToObjectABM();
            cargarGridClientes();
            //this.cbxFiltroCodigo.Focus();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            clearFilter();
            FilterToObjectABMFalse();
            cargarGridClientes();
            this.cbxFiltroCodigo.Focus();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvClientes.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el cliente y la cuenta corriente? Usted no podrá acceder a toda aquella información relacionada al cliente.", "Clientes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _clientes.delete(((ClienteDTO)this.dgvClientes.SelectedRows[0].DataBoundItem).Id);
                        cargarFiltrosDeBusquedaPost(); //refresco los filtros
                        cargarGridClientes(); //cargo grilla
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
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Cliente");
            }

        }

        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxFiltroCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
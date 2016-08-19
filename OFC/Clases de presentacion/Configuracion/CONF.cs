using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

//feb 1.9.1 //agrego id_externo

namespace OFC
{
    public partial class frmCONF : Form
    {
        private Tabla _tabla;
        private Valor _valor;
        private Clientes _clientes;
        private Proveedores _proveedores;
        private Parametro _parametro;

        public frmCONF()
        {
            InitializeComponent();
            _tabla = new Tabla();
            _valor = new Valor();
            _clientes = new Clientes();
            _parametro = new Parametro();
            _proveedores = new Proveedores();
        }

        private void frmParametrosDeSistema_Load(object sender, EventArgs e)
        {
            cargarFiltrosTabla();
            configurarGridTabla();
            configurarGridValores();
            cargarFiltrosCuenta();
            cargarFiltroParametro();
            configurarGridParametro();
        }

        private void cbxFiltroTabla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarGridValores();
                clearFormValores();
            }
        }


        private void cbxFiltroDescripcionTabla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarGridTabla();
                clearFormTabla();
            }
        }

        private void txtIdValorPadre_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtIdValorPadre.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtPrioridad_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtPrioridad.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtParametro1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtParametro1.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
            }
        }

        private void txtParametro2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtParametro2.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtSaldo.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
            }
        }

        private void txtSaldoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta el punto ya que el separador de decimales es la ','
            if (e.KeyChar == ',')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    // Se aceptan teclas de control
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false; 
                    else
                    {
                        // Se acepta la tecla, si el texto resultante es un número decimal
                        Decimal aux = new Decimal();
                        bool rv = Decimal.TryParse(this.txtSaldoProveedor.Text + e.KeyChar, out aux);
                        e.Handled = (!rv);
                    }
                }
            }
        }

        private void cargarFiltrosCuenta()
        {
            _clientes.refreshFiltroData();

            this.cbxCodCliente.DataSource = null;
            this.cbxCodCliente.DataSource = _clientes.CodDataList;

            this.cbxNombreDelCliente.DataSource = null;
            this.cbxNombreDelCliente.DataSource = _clientes.NombreDataList;

            _proveedores.refreshFiltroData();

            this.cbxCodProveedor.DataSource = null;
            this.cbxCodProveedor.DataSource = _proveedores.CodDataList;

            this.cbxNombreDelProveedor.DataSource = null;
            this.cbxNombreDelProveedor.DataSource = _proveedores.NombreDataList;

        }

        private void cargarFiltroParametro()
        {
            _parametro.refreshOwnData();

            this.cbxFiltroDescripcionParametro.DataSource = null;
            this.cbxFiltroDescripcionParametro.DataSource = _parametro.OwnDataList;
            this.cbxFiltroDescripcionParametro.DisplayMember = "descripcion";
            this.cbxFiltroDescripcionParametro.ValueMember = "id";
        }

        private void cargarFiltrosTabla()
        {
            _tabla.refreshOwnDataTotal();

            cbxFiltroDescripcionTabla.DataSource = _tabla.OwnDataListTotal;
            cbxFiltroDescripcionTabla.DisplayMember = "tabla";

            List<TablaDTO> tablaV = new List<TablaDTO>(_tabla.OwnDataListTotal);

            cbxFiltroTabla.DataSource = tablaV;
            cbxFiltroTabla.DisplayMember = "tabla";

            List<TablaDTO> tablaV2 = new List<TablaDTO>(_tabla.OwnDataListTotal);

            cbxTabla.DataSource = tablaV2;
            cbxTabla.DisplayMember = "tabla";
        }

        private void btnBuscarTabla_Click(object sender, EventArgs e)
        {
            cargarGridTabla();
            clearFormTabla();
        }

        private void cargarGridTabla()
        {
            _tabla.refreshOwnData(this.cbxFiltroDescripcionTabla.Text);
            this.dgvTabla.DataSource = null;
            this.dgvTabla.DataSource = _tabla.OwnDataList;
            this.dgvTabla.ClearSelection();
        }

        private void configurarGridTabla()
        {

            this.dgvTabla.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _id = new DataGridViewTextBoxColumn();
            _id.DataPropertyName = "id";
            _id.HeaderText = "Identificador";
            _id.Width = 150;
            _id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.ReadOnly = true;

            DataGridViewTextBoxColumn _tabla = new DataGridViewTextBoxColumn();
            _tabla.DataPropertyName = "tabla";
            _tabla.HeaderText = "Descripción";
            _tabla.Width = 407;
            _tabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tabla.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _tabla.ReadOnly = true;

            this.dgvTabla.Columns.Add(_id);
            this.dgvTabla.Columns.Add(_tabla);

        }

        private void configurarGridParametro()
        {

            this.dgvParametro.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _id = new DataGridViewTextBoxColumn();
            _id.DataPropertyName = "id";
            _id.HeaderText = "Ident.";
            _id.Width = 40;
            _id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 261;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _parametro_1 = new DataGridViewTextBoxColumn();
            _parametro_1.DataPropertyName = "parametro_1";
            _parametro_1.HeaderText = "Parámetro 1";
            _parametro_1.Width = 99;
            _parametro_1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_1.ReadOnly = true;

            DataGridViewTextBoxColumn _parametro_2 = new DataGridViewTextBoxColumn();
            _parametro_2.DataPropertyName = "parametro_2";
            _parametro_2.HeaderText = "Parámetro 2";
            _parametro_2.Width = 99;
            _parametro_2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_2.ReadOnly = true;

            DataGridViewTextBoxColumn _parametro_3 = new DataGridViewTextBoxColumn();
            _parametro_3.DataPropertyName = "parametro_3";
            _parametro_3.HeaderText = "Parámetro 3";
            _parametro_3.Width = 99;
            _parametro_3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _parametro_3.ReadOnly = true;

            this.dgvParametro.Columns.Add(_id);
            this.dgvParametro.Columns.Add(_descripcion);
            this.dgvParametro.Columns.Add(_parametro_1);
            this.dgvParametro.Columns.Add(_parametro_2);
            this.dgvParametro.Columns.Add(_parametro_3);

        }


        private void objectToForm(TablaDTO p)
        {
            txtIdentificadorTabla.Text = p.Id;
            txtDescripcionTabla.Text = p.Tabla;
        }

        private void clearFormTabla()
        {
            txtIdentificadorTabla.Text = string.Empty;
            txtDescripcionTabla.Text = string.Empty;
        }

        private void clearFormCuenta()
        {
            cbxCodCliente.Text = string.Empty;
            cbxNombreDelCliente.Text = string.Empty;
            txtSaldo.Text = string.Empty;
            cbxCodProveedor.Text = string.Empty;
            cbxNombreDelProveedor.Text = string.Empty;
            txtSaldoProveedor.Text = string.Empty;
        }

        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvTabla.SelectedRows.Count > 0)
            {
                this.objectToForm((TablaDTO)this.dgvTabla.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnNuevoTabla_Click(object sender, EventArgs e)
        {
            clearFormTabla();
        }

        private TablaDTO formToObject()
        {
            TablaDTO p = new TablaDTO();
            p.Id = this.txtIdentificadorTabla.Text;
            p.Tabla = this.txtDescripcionTabla.Text;
            return p;
        }

        private ParametroDTO formToObjectParam()
        {
            ParametroDTO p = new ParametroDTO();

            p.Descripcion = this.txtDescripcionParametro.Text;

            if (this.txtParametro1.Text != string.Empty)
            {
                p.Parametro_1 = long.Parse(this.txtParametro1.Text);
            }
            else
            {
                p.Parametro_1 = -1;
            }

            if (this.txtParametro2.Text != string.Empty)
            {
                p.Parametro_2 = long.Parse(this.txtParametro2.Text);
            }
            else
            {
                p.Parametro_2 = -1;
            }

            p.Parametro_3 = this.txtParametro3.Text;

            return p;
        }

        private ValorDTO formToObjectValor()
        {
            ValorDTO p = new ValorDTO();

            if (this.txtIdValor.Text != string.Empty)
            {
                p.Id = long.Parse(this.txtIdValor.Text);
            }
            else
            {
                p.Id = -1;
            }

            p.Id_tabla = this.txtIdTabla.Text;
            p.Valor = this.txtValor.Text;
            p.Valor_adicional = this.txtValorAdicional.Text;

            if (this.txtIdValorPadre.Text != string.Empty)
            {
                p.Id_valor_padre = int.Parse(this.txtIdValorPadre.Text);
            }
            else
            {
                p.Id_valor_padre = -1;
            }

            if (this.cbhVigenteValor.Checked)
            {
                p.Vigente = 'S';
            }
            else
            {
                p.Vigente = 'N';
            }

            if (this.txtPrioridad.Text != string.Empty)
            {
                p.Prioridad = int.Parse(this.txtPrioridad.Text);
            }
            else
            {
                p.Prioridad = -1;
            }

            //feb 1.9.1
            if (this.txtIdValorExterno.Text != string.Empty)
            {
                p.Id_externo = long.Parse(this.txtIdValorExterno.Text);
            }
            else
            {
                p.Id_externo = -1;
            }

            return p;
        }

        private void btnGuardarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                TablaDTO actual = formToObject();

                if (TablaDTO.existeTabla(txtIdentificadorTabla.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar la descripcion de la tabla?", "Tabla", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._tabla.update(actual);
                        cargarFiltrosTabla();
                        cargarGridTabla();
                        clearFormTabla();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear la nueva tabla?", "Tabla", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._tabla.insert(actual);
                        cargarFiltrosTabla();
                        cargarGridTabla();
                        clearFormTabla();
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Tabla");
            }

        }

        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar la tabla del sistema?", "Tabla", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    TablaDTO actual = formToObject();
                    this._tabla.delete(actual);
                    cargarFiltrosTabla();
                    cargarGridTabla();
                    clearFormTabla();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Tabla");
            }
        }

        private void tbpValores_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarValor_Click(object sender, EventArgs e)
        {
            cargarGridValores();
            clearFormValores();
        }



        private void cargarGridValores()
        {
            _valor.refreshOwnData(TablaDTO.obtenerID(this.cbxFiltroTabla.Text), this.txtFiltroValorDeTabla.Text);
            this.dgvValoresDeTabla.DataSource = null;
            this.dgvValoresDeTabla.DataSource = _valor.OwnDataList;
            this.dgvValoresDeTabla.ClearSelection();
        }

        private void cargarGridParametro()
        {
            _parametro.refreshOwnData(cbxFiltroDescripcionParametro.Text);
            this.dgvParametro.DataSource = null;
            this.dgvParametro.DataSource = _parametro.OwnDataListGrid;
            this.dgvParametro.ClearSelection();
        }

        private void clearFormValores()
        {
            txtValor.Text = string.Empty;
            txtValorAdicional.Text = string.Empty;
            txtIdValorPadre.Text = string.Empty;
            txtPrioridad.Text = string.Empty;
            txtIdTabla.Text = string.Empty;
            cbhVigenteValor.Checked = false;
            txtIdValor.Text = string.Empty;
            txtIdValorExterno.Text = string.Empty; //feb 1.9.1
            cbxTabla.Text = string.Empty;
        }

        private void clearFormParametro()
        {
            txtDescripcionParametro.Text = string.Empty;
            txtParametro1.Text = string.Empty;
            txtParametro2.Text = string.Empty;
            txtParametro3.Text = string.Empty;
        }

        private void configurarGridValores()
        {

            this.dgvValoresDeTabla.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _id = new DataGridViewTextBoxColumn();
            _id.DataPropertyName = "id";
            _id.HeaderText = "Ident.";
            _id.Width = 55;
            _id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _id.ReadOnly = true;

            DataGridViewTextBoxColumn _idTabla = new DataGridViewTextBoxColumn();
            _idTabla.DataPropertyName = "id_tabla";
            _idTabla.HeaderText = "Id. Tabla";
            _idTabla.Width = 45;
            _idTabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idTabla.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idTabla.ReadOnly = true;

            DataGridViewTextBoxColumn _valor = new DataGridViewTextBoxColumn();
            _valor.DataPropertyName = "valor";
            _valor.HeaderText = "Valor";
            _valor.Width = 277;
            _valor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _valor.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _valor.ReadOnly = true;

            DataGridViewTextBoxColumn _valorAdicional = new DataGridViewTextBoxColumn();
            _valorAdicional.DataPropertyName = "valor_adicional";
            _valorAdicional.HeaderText = "Valor Adi.";
            _valorAdicional.Width = 75;
            _valorAdicional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _valorAdicional.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _valorAdicional.ReadOnly = true;

            DataGridViewTextBoxColumn _idValorPadre = new DataGridViewTextBoxColumn();
            _idValorPadre.DataPropertyName = "id_valor_padre";
            _idValorPadre.HeaderText = "Id. Padre";
            _idValorPadre.Width = 55;
            _idValorPadre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idValorPadre.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idValorPadre.ReadOnly = true;

            DataGridViewTextBoxColumn _prioridad = new DataGridViewTextBoxColumn();
            _prioridad.DataPropertyName = "prioridad";
            _prioridad.HeaderText = "Pr."; //feb 1.9.1
            _prioridad.Width = 25; //feb 1.9.1
            _prioridad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _prioridad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _prioridad.ReadOnly = true;

            DataGridViewTextBoxColumn _vigente = new DataGridViewTextBoxColumn();
            _vigente.DataPropertyName = "vigente";
            _vigente.HeaderText = "Vi."; //feb 1.9.1
            _vigente.Width = 25; //feb 1.9.1
            _vigente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.ReadOnly = true;

            //feb 1.9.1
            DataGridViewTextBoxColumn _idExterno = new DataGridViewTextBoxColumn();
            _idExterno.DataPropertyName = "id_externo";
            _idExterno.HeaderText = "Id. Ext.";
            _idExterno.Width = 45;
            _idExterno.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idExterno.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _idExterno.ReadOnly = true;

            this.dgvValoresDeTabla.Columns.Add(_id);
            this.dgvValoresDeTabla.Columns.Add(_idTabla);
            this.dgvValoresDeTabla.Columns.Add(_valor);
            this.dgvValoresDeTabla.Columns.Add(_valorAdicional);
            this.dgvValoresDeTabla.Columns.Add(_idValorPadre);
            this.dgvValoresDeTabla.Columns.Add(_prioridad);
            this.dgvValoresDeTabla.Columns.Add(_vigente);
            this.dgvValoresDeTabla.Columns.Add(_idExterno); //feb 1.9.1

        }

        private void dgvValoresDeTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvValoresDeTabla.SelectedRows.Count > 0)
            {
                this.objectToForm((ValorDTO)this.dgvValoresDeTabla.SelectedRows[0].DataBoundItem);
            }
        }

        //feb 1.9.1
        private void objectToForm(ValorDTO p)
        {
            txtIdTabla.Text = p.Id_tabla;
            cbxTabla.Text = p.Tabla;
            txtValor.Text = p.Valor;
            txtValorAdicional.Text = p.Valor_adicional;
            txtIdValorPadre.Text = p.Id_valor_padre.ToString();
            txtIdValor.Text = p.Id.ToString();
            txtIdValorExterno.Text = p.Id_externo.ToString(); //feb 1.9.1
            txtPrioridad.Text = p.Prioridad.ToString();

            if (p.Vigente == 'S')
            {
                cbhVigenteValor.Checked = true;
            }
            else
            {
                cbhVigenteValor.Checked = false;
            }
        }

        private void btnNuevoValor_Click(object sender, EventArgs e)
        {
            clearFormValores();
        }

        private void btnGuardarValor_Click(object sender, EventArgs e)
        {
            try
            {
                ValorDTO actual = formToObjectValor();

                if (txtIdValor.Text != string.Empty)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar los datos del valor?", "Valor", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._valor.update(actual);
                        cargarGridValores();
                        clearFormValores();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo valor?", "Valor", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._valor.insert(actual);
                        cargarGridValores();
                        clearFormValores();
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Valor");
            }
        }

        private void btnBorrarValor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdValor.Text != string.Empty)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el valor del sistema?", "Valor", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ValorDTO actual = formToObjectValor();
                        this._valor.delete(actual);
                        cargarGridValores();
                        clearFormValores();
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Valor");
            }
        }

        private bool validarNulidadDatosForm(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodCliente.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de cliente.";
            }
            else
            {
                int resultIndex = this.cbxCodCliente.FindStringExact(cbxCodCliente.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de cliente ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;
        }

        private bool validarNulidadDatosFormProv(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el Código de proveedor.";
            }
            else
            {
                int resultIndex = this.cbxCodProveedor.FindStringExact(cbxCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ingresado es incorrecto. Seleccione uno de la lista.";
                }
            }

            return rv;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                if (validarNulidadDatosForm(ref msg))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el saldo de la cuenta del cliente?", "Cuenta Corriente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        CuentaCorrienteDTO.update(cbxCodCliente.Text, decimal.Round(decimal.Parse(txtSaldo.Text) * (-1), 2, MidpointRounding.AwayFromZero));
                        clearFormCuenta();
                        MessageBox.Show("La operación fue realizada con éxito.", "Cuenta Corriente");
                    }
                }
                else
                {
                    MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Cuenta Corriente");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Saldo Cuenta");
            }
        }


        private void cbxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelCliente.Text = _clientes.obtenerNombre(this.cbxCodCliente.Text);
        }

        private void cbxNombreDelCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodCliente.Text = _clientes.obtenerCodigo(this.cbxNombreDelCliente.Text);
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            frmMovimientosDeCuentaCorriente frmMovCuentaCorriente = new frmMovimientosDeCuentaCorriente();
            frmMovCuentaCorriente.ShowDialog();
            frmMovCuentaCorriente.Dispose();
        }

        private void btnBuscarParametro_Click(object sender, EventArgs e)
        {
            cargarGridParametro();
            clearFormParametro();
        }

        private void cbxFiltroDescripcionParametro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarGridParametro();
                clearFormParametro();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearFormParametro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ParametroDTO actual = formToObjectParam();

                if (ParametroDTO.existeParametro(txtDescripcionParametro.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el parámetro del sistema?", "Parámetro", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._parametro.update(actual);
                        cargarFiltroParametro();
                        cargarGridParametro();
                        clearFormParametro();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo parámetro?", "Parámetro", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._parametro.insert(actual);
                        cargarFiltroParametro();
                        cargarGridParametro();
                        clearFormParametro();
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Parámetro");
            }
        }

        private void btnBorrarParametro_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar el parámetro del sistema?", "Tabla", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ParametroDTO actual = formToObjectParam();
                    this._parametro.delete(actual);
                    cargarFiltroParametro();
                    cargarGridParametro();
                    clearFormParametro();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Parámetro");
            }
        }

        private void dgvParametro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvParametro.SelectedRows.Count > 0)
            {
                this.objectToForm((ParametroDTO)this.dgvParametro.SelectedRows[0].DataBoundItem);
            }
        }

        private void objectToForm(ParametroDTO p)
        {
            txtDescripcionParametro.Text = p.Descripcion;
            txtParametro1.Text = p.Parametro_1.ToString();
            txtParametro2.Text = p.Parametro_2.ToString();
            txtParametro3.Text = p.Parametro_3;
        }

        private void btnRealizarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea hacer un backup up de la base de datos?", "Base de Datos", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!BaseDeDatos.realizarBackUp())
                    {
                        MessageBox.Show("Error al realizar BACKUP de la base de datos. Debe contactar al administrador del sistema.");
                    }
                    else
                    {
                        MessageBox.Show("El BACKUP fue exitoso.", "Base de Datos");
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Backup Base de Datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de eliminar la base de datos?. Esta acción cierra la aplicacion y no podrá ingresar nuevamente", "Base de Datos", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("C:/backup/script/DropDB.bat", BaseDeDatos.getParametroConexion("Database") + " " + BaseDeDatos.getParametroConexion("Password"));
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Eliminar Base de Datos");
            }
        }

        private void btnMovimientosCuentaProveedor_Click(object sender, EventArgs e)
        {
            frmMovimientosCuentaCorrienteProveedor frmMovCuentaProveedor = new frmMovimientosCuentaCorrienteProveedor();
            frmMovCuentaProveedor.ShowDialog();
            frmMovCuentaProveedor.Dispose();
        }

        private void btnActualizarSaldoProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                if (validarNulidadDatosFormProv(ref msg))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el saldo de la cuenta del proveedor?", "Cuenta Corriente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MovimientoProvDTO.generarAjusteInicial(cbxCodProveedor.Text, decimal.Round(decimal.Parse(txtSaldoProveedor.Text), 2, MidpointRounding.AwayFromZero), dtpFechaDeRegistro.Value.Date);
                        //CuentaCorrienteProvDTO.update(cbxCodProveedor.Text, decimal.Round(decimal.Parse(txtSaldoProveedor.Text) * (-1), 2, MidpointRounding.AwayFromZero));
                        clearFormCuenta();
                        MessageBox.Show("La operación fue realizada con éxito.", "Cuenta Corriente");
                    }
                }
                else
                {
                    MessageBox.Show("Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Cuenta Corriente");
                }

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Saldo Cuenta");
            }
        }

        private void cbxCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelProveedor.Text = _proveedores.obtenerNombre(this.cbxCodProveedor.Text);
        }

        private void cbxNombreDelProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxNombreDelProveedor.Text);
        }

        private void cbxTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdTabla.Text = TablaDTO.obtenerID(cbxTabla.Text);
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            frmTipoDeAsientoContable frmTipoDeAsiento = new frmTipoDeAsientoContable();
            frmTipoDeAsiento.ShowDialog();
            frmTipoDeAsiento.Dispose();
        }


    }
}

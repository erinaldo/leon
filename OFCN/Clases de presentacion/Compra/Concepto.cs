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
    public partial class frmABMDeConceptos : Form
    {
        private Conceptos _conceptos;
        private Cuenta _cuenta;
        private IvaCompras _iva;

        public frmABMDeConceptos()
        {
            InitializeComponent();
            _conceptos = new Conceptos();
            _cuenta = new Cuenta();
            _iva = new IvaCompras();
        }

        private void frmABMDeConceptos_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
            cargarFiltrosConcepto();
            cargarForm();
            configurarGridConceptos();
            cargarGridConceptos();
            clearForm();
        }

        private void cargarFiltrosConcepto()
        {
            _conceptos.refreshOwnData();
            this.cbxFiltroCodigo.DataSource = null;
            this.cbxFiltroCodigo.DataSource = _conceptos.OwnDataList;
            this.cbxFiltroCodigo.DisplayMember = "codigo";

            this.cbxFiltroDescripcion.DataSource = null;
            this.cbxFiltroDescripcion.DataSource = _conceptos.OwnDataList;
            this.cbxFiltroDescripcion.DisplayMember = "descripcion";
        }

        private void cargarForm()
        {
            this.cbxCodigoCuentaCompra.DataSource = _cuenta.OwnDataList;
            this.cbxCodigoCuentaCompra.DisplayMember = "codigo";
            this.cbxCodigoCuentaCompra.ValueMember = "id";

            this.cbxDescripcionCuentaCompra.DataSource = _cuenta.OwnDataList;
            this.cbxDescripcionCuentaCompra.DisplayMember = "descripcion";
            this.cbxDescripcionCuentaCompra.ValueMember = "id";

            this.cbxIvaCompras.DataSource = _iva.OwnDataList;
            this.cbxIvaCompras.DisplayMember = "valor";
            this.cbxIvaCompras.ValueMember = "id";

            this.cbxPorcentajeIvaCompras.DataSource = _iva.OwnDataList;
            this.cbxPorcentajeIvaCompras.DisplayMember = "valor_adicional";
            this.cbxPorcentajeIvaCompras.ValueMember = "id";
        }

        private void configurarGridConceptos()
        {

            this.dgvConceptos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn _codigo = new DataGridViewTextBoxColumn();
            _codigo.DataPropertyName = "codigo";
            _codigo.HeaderText = "Código";
            _codigo.Width = 100;
            _codigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _codigo.ReadOnly = true;

            DataGridViewTextBoxColumn _descripcion = new DataGridViewTextBoxColumn();
            _descripcion.DataPropertyName = "descripcion";
            _descripcion.HeaderText = "Descripción";
            _descripcion.Width = 377;
            _descripcion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _descripcion.ReadOnly = true;

            DataGridViewTextBoxColumn _vigente = new DataGridViewTextBoxColumn();
            _vigente.DataPropertyName = "vigente";
            _vigente.HeaderText = "Vigente";
            _vigente.Width = 80;
            _vigente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _vigente.ReadOnly = true;

            this.dgvConceptos.Columns.Add(_codigo);
            this.dgvConceptos.Columns.Add(_descripcion);
            this.dgvConceptos.Columns.Add(_vigente);

        }


        private void clearForm()
        {
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.cbhVigente.Checked = true;
            this.cbxCodigoCuentaCompra.Text = string.Empty;
            this.cbxDescripcionCuentaCompra.Text = string.Empty;
            this.cbxIvaCompras.Text = string.Empty;
            this.cbxPorcentajeIvaCompras.Text = string.Empty;
            this.btnGuardar.Text = "Crear";
        }

        private ConceptoDTO formToObject()
        {
            ConceptoDTO p = new ConceptoDTO();
            p.Descripcion = this.txtDescripcion.Text;
            p.Codigo = this.txtCodigo.Text;
            if (cbhVigente.Checked == true)
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

            if (this.cbxIvaCompras.SelectedValue.ToString() != "0")
                p.Id_iva = long.Parse(this.cbxIvaCompras.SelectedValue.ToString());
            else
                p.Id_iva = -1;

            return p;
        }

        private void cargarGridConceptos()
        {
            _conceptos.refreshGridData(cbxFiltroCodigo.Text, cbxFiltroDescripcion.Text);
            this.dgvConceptos.DataSource = null;
            this.dgvConceptos.DataSource = _conceptos.GridDataList;
            this.dgvConceptos.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ConceptoDTO actual = formToObject();

                if (txtCodigo.ReadOnly)
                {
                    //actualizando...
                    DialogResult dialogResult = MessageBox.Show("¿Desea actualizar el concepto?", "Conceptos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._conceptos.update(actual);
                        cargarFiltrosConcepto();
                        cargarGridConceptos();
                        clearForm();
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea crear el nuevo concepto?", "Conceptos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._conceptos.insert(actual);
                        cargarFiltrosConcepto();
                        cargarGridConceptos();
                        clearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Concepto");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            clearForm();
            cargarGridConceptos();
        }

        private void cbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clearForm();
                cargarGridConceptos();
            }
        }


        private void dgvConceptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvConceptos.SelectedRows.Count > 0)
            {
                this.objectToForm((ConceptoDTO)this.dgvConceptos.SelectedRows[0].DataBoundItem);
                txtCodigo.ReadOnly = true;
                this.btnGuardar.Text = "Guardar";
            }
        }


        private void objectToForm(ConceptoDTO p)
        {
            txtCodigo.Text = p.Codigo;
            txtDescripcion.Text = p.Descripcion;

            if (p.Vigente == 'S')
            {
                cbhVigente.Checked = true;
            }
            else
            {
                cbhVigente.Checked = false;
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

            if (p.Id_iva == -1 && this.cbxIvaCompras.Items.Count != 0)
            {
                this.cbxIvaCompras.SelectedIndex = 0;
            }
            else
            {
                this.cbxIvaCompras.Text = ValorDTO.obtenerValor(p.Id_iva);
            }

            if (p.Id_iva == -1 && this.cbxPorcentajeIvaCompras.Items.Count != 0)
            {
                this.cbxPorcentajeIvaCompras.SelectedIndex = 0;
            }
            else
            {
                this.cbxPorcentajeIvaCompras.Text = ValorDTO.obtenerValorAdicional(p.Id_iva);
            }


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvConceptos.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea borrar el concepto del sistema?", "Conceptos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _conceptos.delete(((ConceptoDTO)this.dgvConceptos.SelectedRows[0].DataBoundItem));
                        cargarFiltrosConcepto(); //refresco los filtros
                        cargarGridConceptos(); //cargo grilla
                        clearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el concepto que desea borrar.", "Validación Borrar Concepto");
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Borrar Concepto");
            }
        }

    }
}

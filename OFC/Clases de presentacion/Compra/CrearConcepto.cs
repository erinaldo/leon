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
    public partial class frmCrearConcepto : Form
    {
        private Conceptos _conceptos;
        private Cuenta _cuenta;
        private IvaCompras _iva;

        public frmCrearConcepto()
        {
            InitializeComponent();
            _cuenta = new Cuenta();
            _iva = new IvaCompras();
            _conceptos = new Conceptos();
        }

        private void frmCrearConcepto_Load(object sender, EventArgs e)
        {
            cargarForm();
            clearForm();
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

        private void clearForm()
        {
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.cbxCodigoCuentaCompra.Text = string.Empty;
            this.cbxDescripcionCuentaCompra.Text = string.Empty;
            this.cbxIvaCompras.Text = string.Empty;
            this.cbxPorcentajeIvaCompras.Text = string.Empty;
        }

        private ConceptoDTO formToObject()
        {
            ConceptoDTO p = new ConceptoDTO();
            p.Descripcion = this.txtDescripcion.Text;
            p.Codigo = this.txtCodigo.Text;
            if (cbhVigente.Checked == true) //al pedo pero ni ganas de cambiarlo
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ConceptoDTO actual = formToObject();
                this._conceptos.insert(actual);
                clearForm();
                MessageBox.Show("La operación fue realizada con éxito.", "Factura de Compra");
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Guardar Concepto");
            }
        }

    }
}

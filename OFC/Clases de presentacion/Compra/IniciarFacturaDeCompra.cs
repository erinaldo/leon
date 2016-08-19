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
    public partial class frmIniciarFacturaDeCompra : Form
    {
        private Proveedores _proveedores;
        FacturaDeCompra _facturaDeCompra;

        public frmIniciarFacturaDeCompra()
        {
            InitializeComponent();
            _proveedores = new Proveedores();
            _facturaDeCompra = new FacturaDeCompra();
        }

        private void frmIniciarFacturaDeCompra_Load(object sender, EventArgs e)
        {
            cargarDatosProveedorForm();
        }

        private void cargarDatosProveedorForm()
        {
            this.cbxCodProveedor.DataSource = _proveedores.CodDataList;
            this.cbxNombreDelProveedor.DataSource = _proveedores.NombreDataList;
            this.cbxTipoFactura.DataSource = new[] { "A", "B", "C" };
        }

        private void cbhFechaDeVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhFechaDeVencimiento.Checked)
            {
                dtpFechaDeVencimiento.Enabled = true;
            }
            else
            {
                dtpFechaDeVencimiento.Enabled = false;
            }
        }

        private void txtImporteTotal_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteTotal.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("¿Desea registrar la factura de compra?", "Factura de Compra", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                string msg = String.Empty;

                if (validarNulidadDatos(ref msg))
                {
                    FacturaDeCompraDTO data = this.formToObject();
                    _facturaDeCompra.registrarInicio(data);
                    clearForm();
                    MessageBox.Show("La operación fue realizada con éxito.", "Factura de Compra");
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No ha sido posible registrar la factura de compra. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg, "Factura de Compra");
                }
            }
        }

        private FacturaDeCompraDTO formToObject()
        {
            FacturaDeCompraDTO data = new FacturaDeCompraDTO();

            data.Id_proveedor = cbxCodProveedor.Text;
            data.Nombre_proveedor = cbxNombreDelProveedor.Text;
            data.Cod_comprobante = txtNroFacturaCompra.Text;
            data.Tipo_factura = char.Parse(cbxTipoFactura.Text);
            data.Categoria_iva = ProveedorDTO.obtenerCategoriaIvaAbreviado(data.Id_proveedor);
            data.Cuit_proveedor = ProveedorDTO.obtenerCuit(data.Id_proveedor);
            data.Fecha_comprobante = dtpFechaDelComprobante.Value.Date;
            data.Fecha_contable = dtpFechaContable.Value.Date;

            if (cbhFechaDeVencimiento.Checked)
            {
                data.Tiene_vencimiento = true;
                data.Fecha_vencimiento = dtpFechaDeVencimiento.Value.Date;
            }
            if (rdbArticulos.Checked)
            {
                data.Es_concepto = 'N';
            }
            else
            {
                data.Es_concepto = 'S';
            }
            data.Es_definitiva = 'N';
            data.Total = Math.Round(decimal.Parse(txtImporteTotal.Text), 2, MidpointRounding.AwayFromZero);
            return data;
        }

        private void clearForm()
        {
            cbxCodProveedor.Text = string.Empty;
            cbxNombreDelProveedor.Text = string.Empty;
            txtNroFacturaCompra.Text = string.Empty;
            txtImporteTotal.Text = string.Empty;
            cbhFechaDeVencimiento.Checked = false;
            rdbArticulos.Checked = false;
            rdbConceptos.Checked = false;
        }

        private bool validarNulidadDatos(ref string msg)
        {
            bool rv = true;

            if (this.cbxCodProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de proveedor.";
            }
            else
            {
                int resultIndex = this.cbxCodProveedor.FindStringExact(cbxCodProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.cbxNombreDelProveedor.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el nombre de proveedor.";
            }
            else
            {
                int resultIndex = this.cbxNombreDelProveedor.FindStringExact(cbxNombreDelProveedor.Text);
                if (resultIndex == -1)
                {
                    rv = false;
                    msg += "\nEl nombre de proveedor ingresado es incorrecto. Seleccione una de la lista.";
                }
            }

            if (this.txtNroFacturaCompra.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el número de factura.";
            }

            if (this.txtImporteTotal.Text == "")
            {
                rv = false;
                msg += "\nDebe ingresar el importe total.";
            }

            if (!rdbArticulos.Checked && !rdbConceptos.Checked)
            {
                rv = false;
                msg += "\nDebe elegir si la factura es de artículos o de conceptos.";
            }

            return rv;
        }

        private void cbxCodProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNombreDelProveedor.Text = _proveedores.obtenerNombre(this.cbxCodProveedor.Text);
            this.cbxTipoFactura.Text = ProveedorDTO.obtenerCondicionIva(this.cbxCodProveedor.Text).ToString();
        }

        private void cbxNombreDelProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxCodProveedor.Text = _proveedores.obtenerCodigo(this.cbxNombreDelProveedor.Text);
            this.cbxTipoFactura.Text = ProveedorDTO.obtenerCondicionIva(this.cbxCodProveedor.Text).ToString();
        }
    }
}

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
    public partial class frmAjusteDeStock : Form
    {
        private long idProducto;
        private string descProducto;
        private MovimientoDeArticulos _movimiento;

        public frmAjusteDeStock(long idArticulo, string descArticulo)
        {
            InitializeComponent();
            idProducto = idArticulo;
            descProducto = descArticulo;
            _movimiento = new MovimientoDeArticulos();
        }

        private void frmAjusteDeStock_Load(object sender, EventArgs e)
        {
            txtNroDeAjuste.Text = (ParametroDTO.obtenerParametroII("INICIO NRO AJUSTE DE STOCK") + 1).ToString();
            txtArticulo.Text = descProducto;
        }

        private MovimientoDeArticulosDTO formToObjectMov()
        {
            MovimientoDeArticulosDTO p = new MovimientoDeArticulosDTO();

            p.Id_producto = idProducto;

            p.Id_tipo_comprobante = ValorDTO.obtenerId("AJUSTE DE STOCK");

            if (txtIngreso.Text != string.Empty)
            {
                p.Cantidad_ingreso = long.Parse(txtIngreso.Text);
            }
            else
            {
                p.Cantidad_ingreso = 0;
            }

            if (txtEgreso.Text != string.Empty)
            {
                p.Cantidad_egreso = long.Parse(txtEgreso.Text);
            }
            else
            {
                p.Cantidad_egreso = 0;
            }
            p.Id_modulo = ValorDTO.obtenerId("STOCK");
            p.Cod_comprobante = ComprobanteDTO.converToNroAjuste(txtNroDeAjuste.Text);
            return p;
        }


        private void txtIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta la coma ya que el separador de decimales es la '.'
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
                    bool rv = Decimal.TryParse(this.txtIngreso.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se acepta la coma ya que el separador de decimales es la '.'
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
                    bool rv = Decimal.TryParse(this.txtEgreso.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MovimientoDeArticulosDTO mov = formToObjectMov();

                if (mov.Cantidad_ingreso > 0 && mov.Cantidad_egreso == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea realizar el ingreso de artículos?", "Ajuste de Stock", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._movimiento.ingresar(mov);
                        ParametroDTO.actualizarParamII("INICIO NRO AJUSTE DE STOCK", long.Parse(txtNroDeAjuste.Text));
                        MessageBox.Show("La operación fue realizada con éxito.", "Ajuste de Stock");
                        this.Close();
                    }
                }
                if (mov.Cantidad_ingreso == 0 && mov.Cantidad_egreso > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea realizar el egreso de artículos?", "Ajuste de Stock", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this._movimiento.egresar(mov);
                        ParametroDTO.actualizarParamII("INICIO NRO AJUSTE DE STOCK", long.Parse(txtNroDeAjuste.Text));
                        MessageBox.Show("La operación fue realizada con éxito.", "Ajuste de Stock");
                        this.Close();
                    }
                }
                if (mov.Cantidad_ingreso != 0 && mov.Cantidad_egreso != 0)
                {
                    MessageBox.Show("Verifique los valores de ingreso y egreso. Solo es posible realizar una operación por movimiento.", "Ajuste de Stock");
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Validación Ajuste de Stock");
            }
        }
    }
}

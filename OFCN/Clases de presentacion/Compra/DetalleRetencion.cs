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
    public partial class frmDetalleRetencion : Form
    {
        private DetalleRetencion retencion;

        internal DetalleRetencion Retencion
        {
            get { return retencion; }
            set { retencion = value; }
        }

        string id_proveedor;
        long id_tipo_retencion;

        public frmDetalleRetencion(string p_id_proveedor, long p_id_tipo_retencion, PagoDetalleRetencionDTO ret)
        {
            InitializeComponent();
            retencion = new DetalleRetencion();
            id_proveedor = p_id_proveedor;
            id_tipo_retencion = p_id_tipo_retencion;
            retencion.DetalleRet = ret;
        }

        private void DetalleRetencion_Load(object sender, EventArgs e)
        {
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MM-yyyy";
            objectToForm(retencion.DetalleRet);
        }

        private PagoDetalleRetencionDTO formToObject()
        {
            PagoDetalleRetencionDTO ret = new PagoDetalleRetencionDTO();
            ret.Id_tipo_retencion = id_tipo_retencion;
            ret.Periodo_mes = dtpPeriodo.Value.Month;
            ret.Periodo_anio = dtpPeriodo.Value.Year;
            if (txtImporteOrdenDePago.Text != string.Empty)
            {
                ret.Importe_orden_de_pago = Math.Round(decimal.Parse(txtImporteOrdenDePago.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteNeto.Text != string.Empty)
            {
                ret.Importe_neto = Math.Round(decimal.Parse(txtImporteNeto.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImportePagosAnteriores.Text != string.Empty)
            {
                ret.Importe_pagos_anteriores = Math.Round(decimal.Parse(txtImportePagosAnteriores.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteRetencionActual.Text != string.Empty)
            {
                ret.Importe_retencion_actual = Math.Round(decimal.Parse(txtImporteRetencionActual.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteRetencionAnterior.Text != string.Empty)
            {
                ret.Importe_retencion_anterior = Math.Round(decimal.Parse(txtImporteRetencionAnterior.Text), 2, MidpointRounding.AwayFromZero);
            }
            if (txtImporteRetencionPeriodo.Text != string.Empty)
            {
                ret.Importe_retencion_periodo = Math.Round(decimal.Parse(txtImporteRetencionPeriodo.Text), 2, MidpointRounding.AwayFromZero);
            }
            return ret;
        }

        private void objectToForm(PagoDetalleRetencionDTO ret)
        {
            txtImporteOrdenDePago.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_orden_de_pago, 2, MidpointRounding.AwayFromZero));
            txtImporteNeto.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_neto, 2, MidpointRounding.AwayFromZero));
            txtImportePagosAnteriores.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_pagos_anteriores, 2, MidpointRounding.AwayFromZero));
            txtImporteRetencionPeriodo.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_retencion_periodo, 2, MidpointRounding.AwayFromZero));
            txtImporteRetencionAnterior.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_retencion_anterior, 2, MidpointRounding.AwayFromZero));
            txtImporteRetencionActual.Text = String.Format("{0:0.00}", Math.Round(ret.Importe_retencion_actual, 2, MidpointRounding.AwayFromZero));
        }

        private void txtImporteOrdenDePago_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteOrdenDePago.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteNeto_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteNeto.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteRetencion_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteRetencionPeriodo.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void txtImporteRetencionActual_KeyPress(object sender, KeyPressEventArgs e)
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
                    bool rv = Decimal.TryParse(this.txtImporteRetencionActual.Text + e.KeyChar, out aux);
                    e.Handled = (!rv);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                retencion = new DetalleRetencion(formToObject());
                this.Close();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Importe Incorrecto");
            }
        }
    }
}

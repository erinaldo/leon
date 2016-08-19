using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace OFC
{
    public partial class frmVerFacturasDeCompraImpagas : Form
    {
        public frmVerFacturasDeCompraImpagas()
        {
            InitializeComponent();
        }

        private void frmVerFacturasDeCompraImpagas_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crFacturasDeCompraImpagas cargarReporte(string cod_proveedor, string nombre_proveedor, decimal saldo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from facturasdecompraimpagas('" + cod_proveedor + "') as (fecha_factura date, tipo_comprobante_factura character varying(20), nro_comprobante_factura character varying(30), importe_total_factura double precision, importe_total_pagado double precision, importe_total_adeudado double precision, fecha_orden_de_pago date, nro_comprobante_orden_de_pago character varying(30), importe_pagado double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsFacturasDeCompraImpagas dsLista = new dsFacturasDeCompraImpagas();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturasDeCompraImpagas rptLista = new crFacturasDeCompraImpagas();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturasDeCompraImpagas");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select '" + cod_proveedor + "' as cod_proveedor, '";
            cmComando.CommandText += nombre_proveedor + "' as nombre_proveedor, ";
            cmComando.CommandText += saldo.ToString() + " as saldo, ";
            cmComando.CommandText += "'Facturas Impagas o con Pago Parcial' as titulo, '";
            cmComando.CommandText += DateTime.Now.Date.ToString() + "' as fecha";

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosProveedor");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }

        public crFacturasDeCompraImpagas cargarReporte(string cod_proveedor, string nombre_proveedor, decimal saldo, long idOrigen)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from ordenesdepagoencomprobantedecompra(" + idOrigen + ") as (fecha_factura date, tipo_comprobante_factura character varying(20), nro_comprobante_factura character varying(30), importe_total_factura double precision, importe_total_pagado double precision, importe_total_adeudado double precision, fecha_orden_de_pago date, nro_comprobante_orden_de_pago character varying(30), importe_pagado double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsFacturasDeCompraImpagas dsLista = new dsFacturasDeCompraImpagas();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturasDeCompraImpagas rptLista = new crFacturasDeCompraImpagas();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturasDeCompraImpagas");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select '" + cod_proveedor + "' as cod_proveedor, '";
            cmComando.CommandText += nombre_proveedor + "' as nombre_proveedor, ";
            cmComando.CommandText += saldo.ToString() + " as saldo, ";
            cmComando.CommandText += "'Pagos Realizados' as titulo, '";
            cmComando.CommandText += DateTime.Now.Date.ToString() + "' as fecha";

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosProveedor");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }
    }
}

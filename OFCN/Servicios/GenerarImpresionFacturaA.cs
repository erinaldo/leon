using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace OFC
{
    class GenerarImpresionFacturaA
    {
        public static crFacturaA cargarReporte(string tipoComprobante, long idOrigen, string cod_comprobante_remito)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsFacturaA dsLista = new dsFacturaA();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturaA rptLista = new crFacturaA();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionFactura('" + tipoComprobante + "'," + idOrigen + ",'" + cod_comprobante_remito + "') as (tipo_comprobante character varying(255), fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_remito character varying(20), bonificacion double precision, subtotal double precision, iva21 double precision, iva105 double precision, total double precision, id bigint, condicion_venta character varying(255))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleFactura(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), precio_unitario double precision, importe double precision, id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

        public static crFacturaA cargarReporte105(string tipoComprobante, long idOrigen, string cod_comprobante_remito)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsFacturaA dsLista = new dsFacturaA();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturaA rptLista = new crFacturaA();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionFactura105('" + tipoComprobante + "'," + idOrigen + ",'" + cod_comprobante_remito + "') as (tipo_comprobante character varying(255), fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_remito character varying(20), bonificacion double precision, subtotal double precision, iva21 double precision, iva105 double precision, total double precision, id bigint, condicion_venta character varying(255))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleFactura(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), precio_unitario double precision, importe double precision, id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

        public static crFacturaA cargarReporteCredito(long idOrigen)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsFacturaA dsLista = new dsFacturaA();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturaA rptLista = new crFacturaA();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionCredito('NOTA DE CREDITO'," + idOrigen + ") as (tipo_comprobante character varying(255), fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_remito character varying(20), bonificacion double precision, subtotal double precision, iva21 double precision, iva105 double precision, total double precision, id bigint, condicion_venta character varying(255))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleCredito(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), precio_unitario double precision, importe double precision, id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

        public static crFacturaA cargarReporteDebito(long idOrigen)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsFacturaA dsLista = new dsFacturaA();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crFacturaA rptLista = new crFacturaA();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionDebito('NOTA DE DEBITO'," + idOrigen + ") as (tipo_comprobante character varying(255), fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_remito character varying(20), bonificacion double precision, subtotal double precision, iva21 double precision, iva105 double precision, total double precision, id bigint, condicion_venta character varying(255))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleDebito(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), precio_unitario double precision, importe double precision, id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleFacturaA");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

    }
}

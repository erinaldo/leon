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
    class GenerarImpresionRemito
    {
        public static crRemito cargarReporte(long idOrigen, string cod_comprobante_factura)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsRemito dsLista = new dsRemito();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crRemito rptLista = new crRemito();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionRemito(" + idOrigen + ",'" + cod_comprobante_factura + "') as (fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_factura character varying(20), id bigint)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtRemito");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleRemito(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleRemito");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

        public static crRemito cargarReporteRemitoPendiente(long idOrigen, string cod_comprobante_factura)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            dsRemito dsLista = new dsRemito();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crRemito rptLista = new crRemito();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionRemitoPendiente(" + idOrigen + ",'" + cod_comprobante_factura + "') as (fecha timestamp without time zone, nombre_cliente character varying(255), direccion_cliente character varying(255), localidad_cliente character varying(255), condicion_iva_cliente character varying(255), cod_cliente character varying(8), cuit_cliente character varying(20), nro_factura character varying(20), id bigint)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtRemito");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionDetalleRemitoPendiente(" + idOrigen + ") as (cantidad integer, codigo character varying(10), descripcion character varying(255), id_factura bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalleRemito");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

    }
}

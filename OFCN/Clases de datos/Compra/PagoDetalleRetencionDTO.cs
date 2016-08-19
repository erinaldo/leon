using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace OFC
{
    public class PagoDetalleRetencionDTO
    {
        long id_pago;

        public long Id_pago
        {
            get { return id_pago; }
            set { id_pago = value; }
        }

        long id_tipo_retencion;

        public long Id_tipo_retencion
        {
            get { return id_tipo_retencion; }
            set { id_tipo_retencion = value; }
        }

        long periodo_mes;

        public long Periodo_mes
        {
            get { return periodo_mes; }
            set { periodo_mes = value; }
        }

        long periodo_anio;

        public long Periodo_anio
        {
            get { return periodo_anio; }
            set { periodo_anio = value; }
        }

        decimal importe_orden_de_pago;

        public decimal Importe_orden_de_pago
        {
            get { return importe_orden_de_pago; }
            set { importe_orden_de_pago = value; }
        }

        decimal importe_neto;

        public decimal Importe_neto
        {
            get { return importe_neto; }
            set { importe_neto = value; }
        }

        decimal importe_pagos_anteriores;

        public decimal Importe_pagos_anteriores
        {
            get { return importe_pagos_anteriores; }
            set { importe_pagos_anteriores = value; }
        }

        decimal importe_retencion_periodo;

        public decimal Importe_retencion_periodo
        {
            get { return importe_retencion_periodo; }
            set { importe_retencion_periodo = value; }
        }

        decimal importe_retencion_anterior;

        public decimal Importe_retencion_anterior
        {
            get { return importe_retencion_anterior; }
            set { importe_retencion_anterior = value; }
        }

        decimal importe_retencion_actual;

        public decimal Importe_retencion_actual
        {
            get { return importe_retencion_actual; }
            set { importe_retencion_actual = value; }
        }

        long id_pago_detalle;

        public long Id_pago_detalle
        {
            get { return id_pago_detalle; }
            set { id_pago_detalle = value; }
        }

        long id_certificado;

        public long Id_certificado
        {
            get { return id_certificado; }
            set { id_certificado = value; }
        }
        
        public PagoDetalleRetencionDTO()
        {
        id_pago = -1;
        id_tipo_retencion = -1;
        periodo_mes = -1;
        periodo_anio = -1;
        importe_orden_de_pago = decimal.Zero;
        importe_neto = decimal.Zero;
        importe_pagos_anteriores = decimal.Zero;
        importe_retencion_periodo = decimal.Zero;
        importe_retencion_anterior = decimal.Zero;
        importe_retencion_actual = decimal.Zero;
        id_pago_detalle = -1;
        id_certificado = -1;
        }

        public static void insertar(PagoDetalleRetencionDTO dataRetencion)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_pago_retencion("
            + " id_pago, id_tipo_retencion, periodo_mes, periodo_anio, importe_orden_de_pago, importe_neto,"
            + " importe_pagos_anteriores, importe_retencion_actual, importe_retencion_anterior, importe_retencion_periodo, id_pago_detalle, id_certificado)"
            + " VALUES (@idPago, @idTipoRetencion, @periodoMes, @periodoAnio, @importeOrdenDePago, @importeNeto,"
            + " @importePagosAnteriores, @importeRetencionActual, @importeRetencionAnterior, @importeRetencionPeriodo, @idPagoDetalle, @idCertificado);";

            parameters.Add(new NpgsqlParameter("idPago", dataRetencion.id_pago));
            parameters.Add(new NpgsqlParameter("idTipoRetencion", dataRetencion.id_tipo_retencion));
            parameters.Add(new NpgsqlParameter("periodoMes", dataRetencion.periodo_mes));
            parameters.Add(new NpgsqlParameter("periodoAnio", dataRetencion.periodo_anio));
            parameters.Add(new NpgsqlParameter("importeOrdenDePago", dataRetencion.importe_orden_de_pago));
            parameters.Add(new NpgsqlParameter("importeNeto", dataRetencion.importe_neto));
            parameters.Add(new NpgsqlParameter("importePagosAnteriores", dataRetencion.importe_pagos_anteriores));
            parameters.Add(new NpgsqlParameter("importeRetencionActual", dataRetencion.importe_retencion_actual));
            parameters.Add(new NpgsqlParameter("importeRetencionAnterior", dataRetencion.importe_retencion_anterior));
            parameters.Add(new NpgsqlParameter("importeRetencionPeriodo", dataRetencion.importe_retencion_periodo));
            parameters.Add(new NpgsqlParameter("idPagoDetalle", dataRetencion.id_pago_detalle));
            parameters.Add(new NpgsqlParameter("idCertificado", dataRetencion.id_certificado));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static decimal sumaImportesRetencionDelMes(string id_proveedor, long id_tipo_retencion)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            decimal imp_retencion_anterior = decimal.Zero;
            int dias_transcurridos = System.DateTime.Now.Day * (-1);

            //parametros necesarios
            parameters.Add(new NpgsqlParameter("idTipoRetencion", id_tipo_retencion));
            parameters.Add(new NpgsqlParameter("idProveedor", id_proveedor));
            parameters.Add(new NpgsqlParameter("fechaDesde", DateTime.Now.AddDays(dias_transcurridos + 1)));
            parameters.Add(new NpgsqlParameter("fechahasta", DateTime.Now.AddMonths(1).AddDays(dias_transcurridos)));

            //obtengo la suma de los importes de las retenciones
            string sql = "select sum(ret.importe_retencion_actual) imp_retencion_anterior";
            sql = sql + " from cpc_pago_retencion ret, cpc_pago pago, cpc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where ret.id_pago = pago.id";
            sql = sql + " and comp.id_origen = pago.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor = 'ORDEN DE PAGO'";
            sql = sql + " and ret.id_tipo_retencion = @idTipoRetencion";
            sql = sql + " and pago.id_proveedor = @idProveedor";
            sql = sql + " and comp.fecha_creacion >= @fechaDesde";
            sql = sql + " and comp.fecha_creacion <= @fechaHasta";


            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["imp_retencion_anterior"] != null && data["imp_retencion_anterior"] != DBNull.Value)
                {
                    imp_retencion_anterior = decimal.Parse(data["imp_retencion_anterior"].ToString());
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return imp_retencion_anterior;
        }

    }
}

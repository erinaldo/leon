using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class HistoricoCubiertaDTO
    {

        DateTime fecha_orden;

        public DateTime Fecha_orden
        {
            get { return fecha_orden; }
            set { fecha_orden = value; }
        }

        string v_fecha_orden;

        public string V_fecha_orden
        {
            get { return v_fecha_orden; }
            set { v_fecha_orden = value; }
        }

        long id_orden;

        public long Id_orden
        {
            get { return id_orden; }
            set { id_orden = value; }
        }

        int renglon;

        public int Renglon
        {
            get { return renglon; }
            set { renglon = value; }
        }

        string coche;

        public string Coche
        {
            get { return coche; }
            set { coche = value; }
        }

        string medida_cubierta;

        public string Medida_cubierta
        {
            get { return medida_cubierta; }
            set { medida_cubierta = value; }
        }

        string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        
        string trabajo;

        public string Trabajo
        {
            get { return trabajo; }
            set { trabajo = value; }
        }

        long interno;

        public long Interno
        {
            get { return interno; }
            set { interno = value; }
        }

        string servicio_adicional;

        public string Servicio_adicional
        {
            get { return servicio_adicional; }
            set { servicio_adicional = value; }
        }

        string cod_comprobante_factura;

        public string Cod_comprobante_factura
        {
            get { return cod_comprobante_factura; }
            set { cod_comprobante_factura = value; }
        }

        string cod_comprobante_remito;

        public string Cod_comprobante_remito
        {
            get { return cod_comprobante_remito; }
            set { cod_comprobante_remito = value; }
        }

        DateTime fecha_factura;

        public DateTime Fecha_factura
        {
            get { return fecha_factura; }
            set { fecha_factura = value; }
        }

        string v_fecha_factura;

        public string V_fecha_factura
        {
            get { return v_fecha_factura; }
            set { v_fecha_factura = value; }
        }

        public HistoricoCubiertaDTO()
        {
            this.fecha_orden = DateTime.Now;
            this.v_fecha_orden = string.Empty;
            this.id_orden = -1;
            this.renglon = -1;
            this.coche = string.Empty;
            this.medida_cubierta = string.Empty;
            this.marca = string.Empty;
            this.serie = string.Empty;
            this.trabajo = string.Empty;
            this.interno = -1;
            this.servicio_adicional = string.Empty;
            this.cod_comprobante_factura = string.Empty;
            this.cod_comprobante_remito = string.Empty;
            this.fecha_factura = DateTime.Now;
            this.v_fecha_factura = string.Empty;

        }

        public static List<HistoricoCubiertaDTO> obtenerHistoricoCubiertas(FiltrosABMCliente filtro)
        {

            List<HistoricoCubiertaDTO> lista = new List<HistoricoCubiertaDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select distinct ordh.fecha fecha_orden, ordh.id id_orden, deth.renglon renglon, deth.coche coche,"
            + " prod.medida_cubierta medida_cubierta, marca.valor marca, deth.serie serie, serv.descripcion trabajo,"
            + " deth.interno interno, serva.descripcion servicio_adicional,"
            + " comp.cod_comprobante cod_comprobante_factura, '' cod_comprobante_remito, fact.fecha_creacion fecha_factura_remito"
            + " from ofc_orden_de_trabajo_hist ordh, ofc_factura fact,"
            + " ofc_factura_detalle factd, ofc_comprobante comp, ofc_cliente c, ofc_tabla_valor val,"
            + " ofc_producto prod, ofc_servicio serv,"
            + " ofc_orden_de_trabajo_detalle_hist deth left join ofc_servicio serva on serva.id = deth.id_servicio_adicional, ofc_tabla_valor marca"
            + " where ordh.id = deth.id_orden_de_trabajo"
            + " and factd.id_orden_de_trabajo = deth.id_orden_de_trabajo"
            + " and factd.id_renglon_orden_de_trabajo = deth.renglon"
            + " and fact.id = factd.id_factura"
            + " and comp.id_origen = fact.id"
            + " and comp.id_tipo_comprobante = val.id"
            + " and ordh.id_cliente = c.id"
            + " and prod.id = deth.id_producto"
            + " and serv.id = deth.id_servicio"
            + " and marca.id = deth.id_marca"
            + " and marca.id_tabla = 'MA'"
            + " and val.id_tabla = 'TC'"
            + " and val.valor like 'FACTURA%'"
            + " and upper(ordh.id_cliente) like upper(@id_cliente)"
            + " and c.activo = 'S'"
            + " and comp.anulado = 'N'"
            + " and fact.fecha_creacion >= @fechaDesde"
            + " and fact.fecha_creacion <= @fechaHasta";

            if (filtro.FiltroMedidaCubierta != -1)
            {
                sql = sql + " and prod.id = @idCubierta";
            }

            if (filtro.FiltroNroOrden != -1)
            {
                sql = sql + " and ordh.id = @idOrden";
            }

            sql = sql + " union"
            + " select distinct ordh.fecha fecha_orden, ordh.id id_orden, deth.renglon renglon, deth.coche coche,"
            + " prod.medida_cubierta medida_cubierta, marca.valor marca, deth.serie serie, serv.descripcion trabajo,"
            + " deth.interno interno, serva.descripcion servicio_adicional,"
            + " '' cod_comprobante_factura, rem.cod_comprobante cod_comprobante_remito, rem.fecha_creacion fecha_factura_remito"
            + " from ofc_orden_de_trabajo_hist ordh, ofc_remito rem,"
            + " ofc_remito_detalle remd, ofc_cliente c,"
            + " ofc_producto prod, ofc_servicio serv,"
            + " ofc_orden_de_trabajo_detalle_hist deth left join ofc_servicio serva on serva.id = deth.id_servicio_adicional, ofc_tabla_valor marca"
            + " where ordh.id = deth.id_orden_de_trabajo"
            + " and remd.id_orden_de_trabajo = deth.id_orden_de_trabajo"
            + " and remd.id_renglon_orden_de_trabajo = deth.renglon"
            + " and rem.id = remd.id_remito"
            + " and ordh.id_cliente = c.id"
            + " and prod.id = deth.id_producto"
            + " and serv.id = deth.id_servicio"
            + " and marca.id = deth.id_marca"
            + " and marca.id_tabla = 'MA'"
            + " and upper(ordh.id_cliente) like upper(@id_cliente)"
            + " and c.activo = 'S'"
            + " and not exists (select 1 from ofc_comprobante comp where comp.cod_comprobante = rem.cod_comprobante)"
            + " and rem.fecha_creacion >= @fechaDesde"
            + " and rem.fecha_creacion <= @fechaHasta";

            if (filtro.FiltroMedidaCubierta != -1)
            {
                sql = sql + " and prod.id = @idCubierta";
            }

            if (filtro.FiltroNroOrden != -1)
            {
                sql = sql + " and ordh.id = @idOrden";
            }

            sql = sql + " order by 1, 2, 3";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodigo + "%"));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));
            parameters.Add(new NpgsqlParameter("idCubierta", filtro.FiltroMedidaCubierta));
            parameters.Add(new NpgsqlParameter("idOrden", filtro.FiltroNroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                HistoricoCubiertaDTO e = new HistoricoCubiertaDTO();

                e.fecha_orden = DateTime.Parse(data["fecha_orden"].ToString());
                e.v_fecha_orden = String.Format("{0:d/M/yyyy HH:mm:ss}", e.fecha_orden);
                e.id_orden = long.Parse(data["id_orden"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida_cubierta"].ToString();
                e.marca = data["marca"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.interno = long.Parse(data["interno"].ToString());
                if (data["servicio_adicional"] != null && data["servicio_adicional"] != DBNull.Value) e.servicio_adicional = data["servicio_adicional"].ToString();
                e.cod_comprobante_factura = data["cod_comprobante_factura"].ToString();
                if (e.cod_comprobante_factura != string.Empty)
                {
                    e.cod_comprobante_remito = FacturaDTO.obtenerRemito(e.cod_comprobante_factura);
                }
                else
                {
                    e.cod_comprobante_remito = data["cod_comprobante_remito"].ToString();
                }
                e.fecha_factura = DateTime.Parse(data["fecha_factura_remito"].ToString());
                e.v_fecha_factura = String.Format("{0:d/M/yyyy HH:mm:ss}", e.fecha_factura);

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }


    }
}

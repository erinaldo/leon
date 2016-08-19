using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class OrdenDetalleDTO
    {

        string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        

        long interno;

        public long Interno
        {
            get { return interno; }
            set { interno = value; }
        }

        int renglon;

        public int Renglon
        {
            get { return renglon; }
            set { renglon = value; }
        }

        decimal porcentaje_a_pagar;

        public decimal Porcentaje_a_pagar
        {
            get { return porcentaje_a_pagar; }
            set { porcentaje_a_pagar = value; }
        }

        long id_servicio;

        public long Id_servicio
        {
            get { return id_servicio; }
            set { id_servicio = value; }
        }

        long id_marca;

        public long Id_marca
        {
            get { return id_marca; }
            set { id_marca = value; }
        }

        string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        string medida_cubierta;

        public string Medida_cubierta
        {
            get { return medida_cubierta; }
            set { medida_cubierta = value; }
        }

        string trabajo;

        public string Trabajo
        {
            get { return trabajo; }
            set { trabajo = value; }
        }

        string servicio_adicional;

        public string Servicio_adicional
        {
            get { return servicio_adicional; }
            set { servicio_adicional = value; }
        }


        long id_servicio_adicional;

        public long Id_servicio_adicional
        {
            get { return id_servicio_adicional; }
            set { id_servicio_adicional = value; }
        }

        long id_orden_de_trabajo;

        public long Id_orden_de_trabajo
        {
            get { return id_orden_de_trabajo; }
            set { id_orden_de_trabajo = value; }
        }

        string coche;

        public string Coche
        {
            get { return coche; }
            set { coche = value; }
        }

        string v_precioLista;

        public string V_precioLista
        {
            get { return v_precioLista; }
            set { v_precioLista = value; }
        }

        string v_precioListaServAdicional;

        public string V_precioListaServAdicional
        {
            get { return v_precioListaServAdicional; }
            set { v_precioListaServAdicional = value; }
        }

        string v_precioSIva;

        public string V_precioSIva
        {
            get { return v_precioSIva; }
            set { v_precioSIva = value; }
        }

        Decimal precioLista;

        public Decimal PrecioLista
        {
            get { return precioLista; }
            set { precioLista = value; }
        }

        Decimal precioListaServAdicional;

        public Decimal PrecioListaServAdicional
        {
            get { return precioListaServAdicional; }
            set { precioListaServAdicional = value; }
        }

        Decimal precioSIva;

        public Decimal PrecioSIva
        {
            get { return precioSIva; }
            set { precioSIva = value; }
        }

        Decimal precioCIva;

        public Decimal PrecioCIva
        {
            get { return precioCIva; }
            set { precioCIva = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        string nombre_cliente;

        public string Nombre_cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        char factura_por_coche;

        public char Factura_por_coche
        {
            get { return factura_por_coche; }
            set { factura_por_coche = value; }
        }

        char es_nuevo;

        public char Es_nuevo
        {
            get { return es_nuevo; }
            set { es_nuevo = value; }
        }

        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        long id_remito;

        public long Id_remito
        {
            get { return id_remito; }
            set { id_remito = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        string v_fecha_orden;

        public string V_fecha_orden
        {
            get { return v_fecha_orden; }
            set { v_fecha_orden = value; }
        }

        string motivo_descuento;

        public string Motivo_descuento
        {
            get { return motivo_descuento; }
            set { motivo_descuento = value; }
        }

        char solo_factura;

        public char Solo_factura
        {
            get { return solo_factura; }
            set { solo_factura = value; }
        }

        char desglosar_serv_adi;

        public char Desglosar_serv_adi
        {
            get { return desglosar_serv_adi; }
            set { desglosar_serv_adi = value; }
        }

        public OrdenDetalleDTO()
        {
            serie = string.Empty;
            interno = -1;
            renglon = 1; //si o si
            porcentaje_a_pagar = -1;
            id_servicio = -1;
            id_marca = -1;
            id_producto = -1;
            id_servicio_adicional = -1;
            id_orden_de_trabajo = -1;
            coche = "";
            medida_cubierta = "";
            trabajo = "";
            servicio_adicional = "";
            precioLista = Decimal.Zero;
            precioListaServAdicional = Decimal.Zero;
            precioSIva = Decimal.Zero;
            precioCIva = Decimal.Zero;
            id_cliente = String.Empty;
            factura_por_coche = 'N';
            es_nuevo = 'N';
            v_precioLista = String.Empty;
            v_precioListaServAdicional = String.Empty;
            v_precioSIva = String.Empty;
            nombre_cliente = String.Empty;
            fecha = DateTime.Now;
            motivo_descuento = String.Empty;
            marca = String.Empty;
            solo_factura = 'N';
            v_fecha_orden = string.Empty;
            desglosar_serv_adi = 'N';
            id_remito = -1;
        }

        public static List<OrdenDetalleDTO> obtenerDetalleTemp()
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>(); //lista de codigos de clientes

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional, val.valor marca, det.interno interno";
            sql = sql + " from ofc_comprobante_temp c_temp, ofc_producto prod, ofc_servicio serv, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where c_temp.id_origen = det.id_orden_de_trabajo";
            sql = sql + " and prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and c_temp.comprobante = 'ORDENES'";
            sql = sql + " order by 1, 2";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["id"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.servicio_adicional = data["adicional"].ToString();
                e.marca = data["marca"].ToString();
                e.interno = long.Parse(data["interno"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<OrdenDetalleDTO> obtenerOrdenesFactura()
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select fact.id_factura idFactura, ord.id_cliente idCliente, det.id_orden_de_trabajo idOrden, det.renglon renglon, cliente.factura_por_coche XCoche, det.coche coche, f.solo_factura soloFactura, det.desglosar_serv_adi desglosarServAdi";
            sql = sql + " from ofc_orden_de_trabajo ord, ofc_orden_de_trabajo_detalle det, ofc_factura_detalle fact, ofc_factura f, ofc_cliente cliente";
            sql = sql + " where ord.id = det.id_orden_de_trabajo";
            sql = sql + " and fact.id_orden_de_trabajo = ord.id";
            sql = sql + " and fact.id_renglon_orden_de_trabajo = det.renglon";
            sql = sql + " and cliente.id = ord.id_cliente";
            sql = sql + " and f.id = fact.id_factura";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and exists (select 1 from ofc_comprobante_temp c_temp1 where c_temp1.id_origen = fact.id_factura and c_temp1.comprobante = 'FACTURA')";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["idOrden"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.factura_por_coche = char.Parse(data["XCoche"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.id_factura = long.Parse(data["idFactura"].ToString());
                e.coche = data["coche"].ToString();
                e.es_nuevo = 'N';
                e.solo_factura = char.Parse(data["soloFactura"].ToString());
                e.desglosar_serv_adi = char.Parse(data["desglosarServAdi"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<OrdenDetalleDTO> obtenerOrdenesRemito()
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select rem.id_remito idRemito, ord.id_cliente idCliente, det.id_orden_de_trabajo idOrden, det.renglon renglon, cliente.factura_por_coche XCoche, det.coche coche, det.desglosar_serv_adi desglosarServAdi";
            sql = sql + " from ofc_orden_de_trabajo ord, ofc_orden_de_trabajo_detalle det, ofc_remito_detalle rem, ofc_remito r, ofc_cliente cliente";
            sql = sql + " where ord.id = det.id_orden_de_trabajo";
            sql = sql + " and rem.id_orden_de_trabajo = ord.id";
            sql = sql + " and rem.id_renglon_orden_de_trabajo = det.renglon";
            sql = sql + " and cliente.id = ord.id_cliente";
            sql = sql + " and r.id = rem.id_remito";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and exists (select 1 from ofc_comprobante_temp c_temp1 where c_temp1.id_origen = rem.id_remito and c_temp1.comprobante = 'REMITO')";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["idOrden"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.factura_por_coche = char.Parse(data["XCoche"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.id_remito = long.Parse(data["idRemito"].ToString());
                e.coche = data["coche"].ToString();
                e.es_nuevo = 'N';
                e.desglosar_serv_adi = char.Parse(data["desglosarServAdi"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<OrdenDetalleDTO> obtenerDetalleNoTemp(FiltrosOrden filtro)
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();



            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioT = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioA = BaseDeDatos.obtenerConexion();

            string sql = "select distinct ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca, det.desglosar_serv_adi desglose";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id, ofc_factura_detalle fact_det";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and fact_det.id_orden_de_trabajo = det.id_orden_de_trabajo";
            sql = sql + " and fact_det.id_renglon_orden_de_trabajo = det.renglon";
            sql = sql + " and fact_det.id_factura in (select max(id_factura) from ofc_factura_detalle detf where detf.id_orden_de_trabajo = det.id_orden_de_trabajo and detf.id_renglon_orden_de_trabajo = det.renglon)";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = fact_det.id_factura and c_temp.comprobante = 'FACTURA')";

            if (filtro.FiltroCodCliente != "")
            {
                sql = sql + " and upper(ord.id_cliente) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombreCliente != "")
            {
                sql = sql + " and upper(ord.nombre_cliente) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroNroOrden != "")
            {
                sql = sql + " and ord.id = @nro_orden";
            }            
            
            sql = sql + " union";
            sql = sql + " select ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca, det.desglosar_serv_adi desglose";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and not exists (select 1 from ofc_factura_detalle fact_det where fact_det.id_orden_de_trabajo = det.id_orden_de_trabajo and fact_det.id_renglon_orden_de_trabajo = det.renglon)";


            if (filtro.FiltroCodCliente != "")
            {
                sql = sql + " and upper(ord.id_cliente) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombreCliente != "")
            {
                sql = sql + " and upper(ord.nombre_cliente) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroNroOrden != "")
            {
                sql = sql + " and ord.id = @nro_orden";
            }

            sql = sql + " order by 2, 3";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodCliente + "%"));
            parameters.Add(new NpgsqlParameter("nombre_cliente", "%" + filtro.FiltroNombreCliente + "%"));
            parameters.Add(new NpgsqlParameter("nro_orden", filtro.FiltroNroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataPrecioT = null;
            NpgsqlDataReader dataPrecioA = null;

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["id"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.servicio_adicional = data["adicional"].ToString();
                e.interno = long.Parse(data["interno"].ToString());
                e.porcentaje_a_pagar = decimal.Parse(data["porcentaje"].ToString());
                e.id_marca = long.Parse(data["idMarca"].ToString());
                e.id_servicio = long.Parse(data["idServicio"].ToString());
                if (data["idServAdicional"] != null && data["idServAdicional"] != DBNull.Value)
                    e.id_servicio_adicional = long.Parse(data["idServAdicional"].ToString());
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.fecha = DateTime.Parse(data["fecha"].ToString());
                if (data["motivoDescuento"] != null && data["motivoDescuento"] != DBNull.Value)
                    e.motivo_descuento = data["motivoDescuento"].ToString();
                e.marca = data["marca"].ToString();
                e.desglosar_serv_adi = char.Parse(data["desglose"].ToString());

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrden", e.id_orden_de_trabajo));
                parameters.Add(new NpgsqlParameter("fila", e.renglon));

                sql = "select precio.valor precioTrabajo, cliente.factura_por_coche xCoche";
                sql = sql + " from ofc_orden_de_trabajo ord, ofc_cliente cliente,";
                sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle det";
                sql = sql + " where precio.id_servicio = det.id_servicio ";
                sql = sql + " and precio.id_producto = det.id_producto";
                sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                sql = sql + " and ord.id_cliente = cliente.id";
                sql = sql + " and ord.id = det.id_orden_de_trabajo";
                sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                sql = sql + " and det.renglon = @fila";
                sql = sql + " and cliente.activo = 'S'";

                dataPrecioT = BaseDeDatos.ejecutarQuery(sql, cnPrecioT, parameters);

                while (dataPrecioT != null && dataPrecioT.Read())
                {
                    e.precioLista = (Decimal.Parse(dataPrecioT["precioTrabajo"].ToString()) * e.porcentaje_a_pagar) / 100;
                    e.precioLista = decimal.Round(e.precioLista, 2, MidpointRounding.AwayFromZero);

                    e.v_precioLista = String.Format("{0:0.00}", e.precioLista);

                    e.factura_por_coche = char.Parse(dataPrecioT["xCoche"].ToString());
                }


                //si hay servicio adicional calculo el precio
                if (e.servicio_adicional != "")
                {
                    sql = "select precio.valor precioAdicional";
                    sql = sql + " from ofc_orden_de_trabajo ord, ofc_cliente cliente,";
                    sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle det";
                    sql = sql + " where precio.id_servicio = det.id_servicio_adicional";
                    sql = sql + " and precio.id_producto = det.id_producto";
                    sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and ord.id_cliente = cliente.id";
                    sql = sql + " and ord.id = det.id_orden_de_trabajo";
                    sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                    sql = sql + " and det.renglon = @fila";
                    sql = sql + " and cliente.activo = 'S'";

                    dataPrecioA = BaseDeDatos.ejecutarQuery(sql, cnPrecioA, parameters);

                    while (dataPrecioA != null && dataPrecioA.Read())
                    {
                        e.PrecioListaServAdicional = (Decimal.Parse(dataPrecioA["precioAdicional"].ToString()) * e.porcentaje_a_pagar) / 100;
                        e.PrecioListaServAdicional = decimal.Round(e.PrecioListaServAdicional, 2, MidpointRounding.AwayFromZero);

                        e.v_precioListaServAdicional = String.Format("{0:0.00}", e.PrecioListaServAdicional);
                    }

                }



                e.precioSIva = e.precioLista + e.PrecioListaServAdicional;
                e.precioSIva = decimal.Round(e.precioSIva, 2, MidpointRounding.AwayFromZero);

                e.v_precioSIva = String.Format("{0:0.00}", e.precioSIva);
                
                //dejar para mas adelante
                //e.PrecioCIva = ;    


                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (dataPrecioT != null)
                dataPrecioT.Close();

            if (dataPrecioA != null)
                dataPrecioA.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnPrecioT.State == System.Data.ConnectionState.Open)
                cnPrecioT.Close();

            if (cnPrecioA.State == System.Data.ConnectionState.Open)
                cnPrecioA.Close();

            return lista;

        }


        public static List<OrdenDetalleDTO> obtenerDetalleNoTemp2(FiltrosOrden filtro)
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = " select ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";

            if (filtro.FiltroCodCliente != "")
            {
                sql = sql + " and upper(ord.id_cliente) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombreCliente != "")
            {
                sql = sql + " and upper(ord.nombre_cliente) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroNroOrden != "")
            {
                sql = sql + " and ord.id = @nro_orden";
            }

            sql = sql + " order by 2, 3";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodCliente + "%"));
            parameters.Add(new NpgsqlParameter("nombre_cliente", "%" + filtro.FiltroNombreCliente + "%"));
            parameters.Add(new NpgsqlParameter("nro_orden", filtro.FiltroNroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["id"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.servicio_adicional = data["adicional"].ToString();
                e.interno = long.Parse(data["interno"].ToString());
                e.porcentaje_a_pagar = decimal.Parse(data["porcentaje"].ToString());
                e.id_marca = long.Parse(data["idMarca"].ToString());
                e.id_servicio = long.Parse(data["idServicio"].ToString());
                if (data["idServAdicional"] != null && data["idServAdicional"] != DBNull.Value)
                    e.id_servicio_adicional = long.Parse(data["idServAdicional"].ToString());
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.fecha = DateTime.Parse(data["fecha"].ToString());
                if (data["motivoDescuento"] != null && data["motivoDescuento"] != DBNull.Value)
                    e.motivo_descuento = data["motivoDescuento"].ToString();
                e.marca = data["marca"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<OrdenDetalleDTO> obtenerDetalleNoTemp3(FiltrosOrden filtro)
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select ord.fecha fecha, ord.id_cliente idCliente, ord.nombre_cliente nombreCliente, det.id_orden_de_trabajo idOrden, det.renglon renglon, det.coche coche,";
            sql = sql + " prod.medida_cubierta medida, val.valor marca, det.serie serie, serv.descripcion trabajo, det.interno interno, serv2.descripcion adicional";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";

            if (filtro.FiltroMedida != -1)
            {
                sql = sql + " and det.id_producto = @idProducto";
            }

            if (filtro.FiltroTrabajo != -1)
            {
                sql = sql + " and det.id_servicio = @idTrabajo";
            }

            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("idProducto", filtro.FiltroMedida));
            parameters.Add(new NpgsqlParameter("idTrabajo", filtro.FiltroTrabajo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.fecha = DateTime.Parse(data["fecha"].ToString());
                e.v_fecha_orden = String.Format("{0:d/M/yyyy HH:mm:ss}", e.fecha);
                e.id_cliente = data["idCliente"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.id_orden_de_trabajo = long.Parse(data["idOrden"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida"].ToString();
                e.marca = data["marca"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.interno = long.Parse(data["interno"].ToString());
                e.servicio_adicional = data["adicional"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }


        public static List<OrdenDetalleDTO> obtenerDetalleNoTemp4(FiltrosOrden filtro)
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioT = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioA = BaseDeDatos.obtenerConexion();

            //pertenecen a remitos anulados
            string sql = "select distinct ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca, det.desglosar_serv_adi desglose";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id, ofc_remito_detalle rem_det";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and rem_det.id_orden_de_trabajo = det.id_orden_de_trabajo";
            sql = sql + " and rem_det.id_renglon_orden_de_trabajo = det.renglon";
            sql = sql + " and rem_det.id_remito in (select max(id_remito) from ofc_remito_detalle detr where detr.id_orden_de_trabajo = det.id_orden_de_trabajo and detr.id_renglon_orden_de_trabajo = det.renglon)";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = rem_det.id_remito and c_temp.comprobante = 'REMITO')";

            if (filtro.FiltroCodCliente != "")
            {
                sql = sql + " and upper(ord.id_cliente) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombreCliente != "")
            {
                sql = sql + " and upper(ord.nombre_cliente) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroNroOrden != "")
            {
                sql = sql + " and ord.id = @nro_orden";
            }

            //pertenecen a ordenes nunca despachadas
            sql = sql + " union";
            sql = sql + " select ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca, det.desglosar_serv_adi desglose";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo ord, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id_orden_de_trabajo and c_temp.comprobante = 'ORDENES')";
            sql = sql + " and not exists (select 1 from ofc_remito_detalle rem_det where rem_det.id_orden_de_trabajo = det.id_orden_de_trabajo and rem_det.id_renglon_orden_de_trabajo = det.renglon)";


            if (filtro.FiltroCodCliente != "")
            {
                sql = sql + " and upper(ord.id_cliente) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombreCliente != "")
            {
                sql = sql + " and upper(ord.nombre_cliente) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroNroOrden != "")
            {
                sql = sql + " and ord.id = @nro_orden";
            }

            sql = sql + " order by 2, 3";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodCliente + "%"));
            parameters.Add(new NpgsqlParameter("nombre_cliente", "%" + filtro.FiltroNombreCliente + "%"));
            parameters.Add(new NpgsqlParameter("nro_orden", filtro.FiltroNroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataPrecioT = null;
            NpgsqlDataReader dataPrecioA = null;

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.id_orden_de_trabajo = long.Parse(data["id"].ToString());
                e.renglon = int.Parse(data["renglon"].ToString());
                e.coche = data["coche"].ToString();
                e.medida_cubierta = data["medida"].ToString();
                e.serie = data["serie"].ToString();
                e.trabajo = data["trabajo"].ToString();
                e.servicio_adicional = data["adicional"].ToString();
                e.interno = long.Parse(data["interno"].ToString());
                e.porcentaje_a_pagar = decimal.Parse(data["porcentaje"].ToString());
                e.id_marca = long.Parse(data["idMarca"].ToString());
                e.id_servicio = long.Parse(data["idServicio"].ToString());
                if (data["idServAdicional"] != null && data["idServAdicional"] != DBNull.Value)
                    e.id_servicio_adicional = long.Parse(data["idServAdicional"].ToString());
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.fecha = DateTime.Parse(data["fecha"].ToString());
                if (data["motivoDescuento"] != null && data["motivoDescuento"] != DBNull.Value)
                    e.motivo_descuento = data["motivoDescuento"].ToString();
                e.marca = data["marca"].ToString();
                e.desglosar_serv_adi = char.Parse(data["desglose"].ToString());

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrden", e.id_orden_de_trabajo));
                parameters.Add(new NpgsqlParameter("fila", e.renglon));

                sql = "select precio.valor precioTrabajo, cliente.factura_por_coche xCoche";
                sql = sql + " from ofc_orden_de_trabajo ord, ofc_cliente cliente,";
                sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle det";
                sql = sql + " where precio.id_servicio = det.id_servicio ";
                sql = sql + " and precio.id_producto = det.id_producto";
                sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                sql = sql + " and ord.id_cliente = cliente.id";
                sql = sql + " and ord.id = det.id_orden_de_trabajo";
                sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                sql = sql + " and det.renglon = @fila";
                sql = sql + " and cliente.activo = 'S'";

                dataPrecioT = BaseDeDatos.ejecutarQuery(sql, cnPrecioT, parameters);

                while (dataPrecioT != null && dataPrecioT.Read())
                {
                    e.precioLista = (Decimal.Parse(dataPrecioT["precioTrabajo"].ToString()) * e.porcentaje_a_pagar) / 100;
                    e.precioLista = decimal.Round(e.precioLista, 2, MidpointRounding.AwayFromZero);

                    e.v_precioLista = String.Format("{0:0.00}", e.precioLista);

                    e.factura_por_coche = char.Parse(dataPrecioT["xCoche"].ToString());
                }


                //si hay servicio adicional calculo el precio
                if (e.servicio_adicional != "")
                {
                    sql = "select precio.valor precioAdicional";
                    sql = sql + " from ofc_orden_de_trabajo ord, ofc_cliente cliente,";
                    sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle det";
                    sql = sql + " where precio.id_servicio = det.id_servicio_adicional";
                    sql = sql + " and precio.id_producto = det.id_producto";
                    sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and ord.id_cliente = cliente.id";
                    sql = sql + " and ord.id = det.id_orden_de_trabajo";
                    sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                    sql = sql + " and det.renglon = @fila";
                    sql = sql + " and cliente.activo = 'S'";

                    dataPrecioA = BaseDeDatos.ejecutarQuery(sql, cnPrecioA, parameters);

                    while (dataPrecioA != null && dataPrecioA.Read())
                    {
                        e.PrecioListaServAdicional = (Decimal.Parse(dataPrecioA["precioAdicional"].ToString()) * e.porcentaje_a_pagar) / 100;
                        e.PrecioListaServAdicional = decimal.Round(e.PrecioListaServAdicional, 2, MidpointRounding.AwayFromZero);

                        e.v_precioListaServAdicional = String.Format("{0:0.00}", e.PrecioListaServAdicional);
                    }

                }



                e.precioSIva = e.precioLista + e.PrecioListaServAdicional;
                e.precioSIva = decimal.Round(e.precioSIva, 2, MidpointRounding.AwayFromZero);

                e.v_precioSIva = String.Format("{0:0.00}", e.precioSIva);

                //dejar para mas adelante
                //e.PrecioCIva = ;    


                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (dataPrecioT != null)
                dataPrecioT.Close();

            if (dataPrecioA != null)
                dataPrecioA.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnPrecioT.State == System.Data.ConnectionState.Open)
                cnPrecioT.Close();

            if (cnPrecioA.State == System.Data.ConnectionState.Open)
                cnPrecioA.Close();

            return lista;

        }

        public static void borrarOrdenDetalle(long id_orden, int renglon)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            parameters.Add(new NpgsqlParameter("id_orden", id_orden));
            parameters.Add(new NpgsqlParameter("renglon", renglon));

            //elimino el renglon
            string sql = "delete from ofc_orden_de_trabajo_detalle where id_orden_de_trabajo = @id_orden and renglon = @renglon;";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino la orden si ya no existe mas renglones
            sql = "delete from ofc_orden_de_trabajo where id = @id_orden and not exists (select 1 from ofc_orden_de_trabajo_detalle where id_orden_de_trabajo = @id_orden);";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino el comprobante temporal de formulario si ya no existe mas renglones
            sql = "delete from ofc_comprobante_temp where comprobante = 'ORDENES' and id_origen = @id_orden and not exists (select 1 from ofc_orden_de_trabajo_detalle where id_orden_de_trabajo = @id_orden);";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo la numeracion de los renglones
            //comentado a partir de la versión 2.0 porque genera inconsistencia con los renglones historicos de la orden
            //sql = "update ofc_orden_de_trabajo_detalle";
            //sql = sql + " set renglon = renglon - 1";
            //sql = sql + " where id_orden_de_trabajo = @id_orden";
            //sql = sql + " and renglon > @renglon";
            //BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void actualizarOrdenDetalle(OrdenDetalleDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_orden_de_trabajo_detalle set serie = @serie, interno = @interno, porcentaje_a_pagar = @porcentaje_a_pagar, id_servicio = @id_servicio,"
            + " id_marca = @id_marca, id_producto = @id_producto, id_servicio_adicional = @id_servicio_adicional, coche = @coche, motivo_descuento = @motivo_descuento, desglosar_serv_adi = @desglosar_serv_adi"
            + " where id_orden_de_trabajo = @id_orden_de_trabajo and renglon = @renglon;";

            parameters.Add(new NpgsqlParameter("serie", data.serie));
            parameters.Add(new NpgsqlParameter("interno", data.interno));
            parameters.Add(new NpgsqlParameter("renglon", data.renglon));
            parameters.Add(new NpgsqlParameter("porcentaje_a_pagar", data.porcentaje_a_pagar));
            parameters.Add(new NpgsqlParameter("id_servicio", data.id_servicio));
            parameters.Add(new NpgsqlParameter("id_marca", data.id_marca));
            parameters.Add(new NpgsqlParameter("id_producto", data.id_producto));
            parameters.Add(new NpgsqlParameter("id_servicio_adicional", data.id_servicio_adicional));
            parameters.Add(new NpgsqlParameter("id_orden_de_trabajo", data.id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("coche", data.coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", data.motivo_descuento));
            parameters.Add(new NpgsqlParameter("desglosar_serv_adi", data.desglosar_serv_adi));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void actualizarOrdenDetalleHist(OrdenDetalleDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_orden_de_trabajo_detalle_hist set serie = @serie, interno = @interno, porcentaje_a_pagar = @porcentaje_a_pagar, id_servicio = @id_servicio,"
            + " id_marca = @id_marca, id_producto = @id_producto, id_servicio_adicional = @id_servicio_adicional, coche = @coche, motivo_descuento = @motivo_descuento, desglosar_serv_adi = @desglosar_serv_adi"
            + " where id_orden_de_trabajo = @id_orden_de_trabajo and renglon = @renglon;";

            parameters.Add(new NpgsqlParameter("serie", data.serie));
            parameters.Add(new NpgsqlParameter("interno", data.interno));
            parameters.Add(new NpgsqlParameter("renglon", data.renglon));
            parameters.Add(new NpgsqlParameter("porcentaje_a_pagar", data.porcentaje_a_pagar));
            parameters.Add(new NpgsqlParameter("id_servicio", data.id_servicio));
            parameters.Add(new NpgsqlParameter("id_marca", data.id_marca));
            parameters.Add(new NpgsqlParameter("id_producto", data.id_producto));
            parameters.Add(new NpgsqlParameter("id_servicio_adicional", data.id_servicio_adicional));
            parameters.Add(new NpgsqlParameter("id_orden_de_trabajo", data.id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("coche", data.coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", data.motivo_descuento));
            parameters.Add(new NpgsqlParameter("desglosar_serv_adi", data.desglosar_serv_adi));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertarOrdenDetalle(OrdenDetalleDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            data.Renglon = OrdenDetalleDTO.buscarSiguienteRenglon(data.id_orden_de_trabajo);

            string sql = "insert into ofc_orden_de_trabajo_detalle(serie,interno,renglon,porcentaje_a_pagar,id_servicio,"
            + " id_marca,id_producto,id_servicio_adicional,id_orden_de_trabajo,coche, motivo_descuento, desglosar_serv_adi)"
            + " values(@serie,@interno,@renglon,@porcentaje_a_pagar,@id_servicio,"
            + " @id_marca,@id_producto,@id_servicio_adicional,@id_orden_de_trabajo,@coche,@motivo_descuento,@desglosar_serv_adi);";

            parameters.Add(new NpgsqlParameter("serie", data.serie));
            parameters.Add(new NpgsqlParameter("interno", data.interno));
            parameters.Add(new NpgsqlParameter("renglon", data.renglon));
            parameters.Add(new NpgsqlParameter("porcentaje_a_pagar", data.porcentaje_a_pagar));
            parameters.Add(new NpgsqlParameter("id_servicio", data.id_servicio));
            parameters.Add(new NpgsqlParameter("id_marca", data.id_marca));
            parameters.Add(new NpgsqlParameter("id_producto", data.id_producto));
            parameters.Add(new NpgsqlParameter("id_servicio_adicional", data.id_servicio_adicional));
            parameters.Add(new NpgsqlParameter("id_orden_de_trabajo", data.id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("coche", data.coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", data.motivo_descuento));
            parameters.Add(new NpgsqlParameter("desglosar_serv_adi", data.desglosar_serv_adi));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static bool existePrecio(string idCliente, long idProducto, long idServicio, long idServicioAdicional)
        {
            int count = 0;
            int countAdicional = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnAdi = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad ";
            sql = sql + " from ofc_precio precio, ofc_cliente cliente";
            sql = sql + " where precio.id_lista_precio = cliente.id_lista_precio";
            sql = sql + " and cliente.id = @idCliente";
            sql = sql + " and precio.id_producto = @idProducto";
            sql = sql + " and precio.id_servicio = @idServicio";
            sql = sql + " and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", idCliente));
            parameters.Add(new NpgsqlParameter("idProducto", idProducto));
            parameters.Add(new NpgsqlParameter("idServicio", idServicio));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();

                if (idServicioAdicional != -1)
                {
                    sql = "select count(1) as cantidad ";
                    sql = sql + " from ofc_precio precio, ofc_cliente cliente";
                    sql = sql + " where precio.id_lista_precio = cliente.id_lista_precio";
                    sql = sql + " and cliente.id = @idCliente";
                    sql = sql + " and precio.id_producto = @idProducto";
                    sql = sql + " and precio.id_servicio = @idServicioAdicional";
                    sql = sql + " and cliente.activo = 'S'";

                    parameters.Add(new NpgsqlParameter("idServicioAdicional", idServicioAdicional));

                    NpgsqlDataReader dataAdicional = BaseDeDatos.ejecutarQuery(sql, cnAdi, parameters);

                    if (dataAdicional != null && dataAdicional.Read())
                    {
                        countAdicional = int.Parse(dataAdicional["cantidad"].ToString());
                        dataAdicional.Close();
                    }
                }
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnAdi.State == System.Data.ConnectionState.Open)
                cnAdi.Close();

            return (count != 0 && countAdicional != 0);
        }

        public static int buscarSiguienteRenglon(long idOrden)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            int nroRenglon = 1;
            int nroRenglonFact = 1;
            //maximo renglon de la orden pendiente de facturar
            string sql = "select max(renglon) renglon from ofc_orden_de_trabajo_detalle where id_orden_de_trabajo = @idOrden";
            parameters.Add(new NpgsqlParameter("idOrden", idOrden));

            NpgsqlDataReader dataRenglon = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
     
            while (dataRenglon != null && dataRenglon.Read())
            {
                if (dataRenglon["renglon"] != null && dataRenglon["renglon"] != DBNull.Value)
                {
                    nroRenglon = int.Parse(dataRenglon["renglon"].ToString()) + 1;
                }
            }

            //maximo renglon de orden facturada
            sql = "select max(renglon) renglon from ofc_orden_de_trabajo_detalle_hist where id_orden_de_trabajo = @idOrden";
            parameters.Add(new NpgsqlParameter("idOrden", idOrden));

            NpgsqlDataReader dataRenglon2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (dataRenglon2 != null && dataRenglon2.Read())
            {
                if (dataRenglon2["renglon"] != null && dataRenglon2["renglon"] != DBNull.Value)
                {
                    nroRenglonFact = int.Parse(dataRenglon2["renglon"].ToString()) + 1;
                }
            }

            if (nroRenglon < nroRenglonFact)
            {
                nroRenglon = nroRenglonFact;
            }
            
            if (dataRenglon != null)
                dataRenglon.Close();

            if (dataRenglon2 != null)
                dataRenglon2.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return nroRenglon;
        }

    }
}

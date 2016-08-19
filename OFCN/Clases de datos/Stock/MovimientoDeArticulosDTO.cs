using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class MovimientoDeArticulosDTO
    {

        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        long id_tipo_comprobante;

        public long Id_tipo_comprobante
        {
            get { return id_tipo_comprobante; }
            set { id_tipo_comprobante = value; }
        }

        long cantidad_ingreso;

        public long Cantidad_ingreso
        {
            get { return cantidad_ingreso; }
            set { cantidad_ingreso = value; }
        }

        long cantidad_egreso;

        public long Cantidad_egreso
        {
            get { return cantidad_egreso; }
            set { cantidad_egreso = value; }
        }

        long stock;

        public long Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        long id_modulo;

        public long Id_modulo
        {
            get { return id_modulo; }
            set { id_modulo = value; }
        }

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        string id_proveedor;

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        string desc_operacion;
        public string Desc_operacion
        {
            get { return desc_operacion; }
            set { desc_operacion = value; }
        }

        string desc_producto;
        public string Desc_producto
        {
            get { return desc_producto; }
            set { desc_producto = value; }
        }

        string cod_producto;
        public string Cod_producto
        {
            get { return cod_producto; }
            set { cod_producto = value; }
        }

        string desc_tipo_comprobante;
        public string Desc_tipo_comprobante
        {
            get { return desc_tipo_comprobante; }
            set { desc_tipo_comprobante = value; }
        }

        string v_fecha;

        public string V_fecha
        {
            get { return v_fecha; }
            set { v_fecha = value; }
        }

        decimal precio_unitario;

        public decimal Precio_unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }

        string v_precio_unitario;

        public string V_precio_unitario
        {
            get { return v_precio_unitario; }
            set { v_precio_unitario = value; }
        }

        public MovimientoDeArticulosDTO()
        {
            id = -1;
            fecha = DateTime.Now;
            id_producto = -1;
            id_tipo_comprobante = -1;
            cantidad_ingreso = 0;
            cantidad_egreso = 0;
            stock = 0;
            id_modulo = -1;
            cod_comprobante = string.Empty;
            id_cliente = string.Empty;
            id_proveedor = string.Empty;
            desc_operacion = string.Empty;
            desc_producto = string.Empty;
            cod_producto = string.Empty;
            desc_tipo_comprobante = string.Empty;
            v_fecha = string.Empty;
            precio_unitario = decimal.Zero;
            v_precio_unitario = string.Empty;
        }

        public static void ingreso(MovimientoDeArticulosDTO mov)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long stock = 0;

            string sql = "select stock from ofc_producto where id = @id_producto";

            parameters.Add(new NpgsqlParameter("id_producto", mov.Id_producto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                stock = long.Parse(data["stock"].ToString());
                data.Close();
            }

            sql = "insert into stk_movimiento (id, fecha, id_producto, id_tipo_comprobante, ingreso, egreso, stock, id_modulo, cod_comprobante, id_cliente, id_proveedor, usuario_creacion, precio_unitario)"
            + " values(nextval('stk_movimiento_id_seq'), @fecha, @id_producto, @id_tipo_comprobante, @cantidad_ingreso, @cantidad_egreso, @stock, @id_modulo, @cod_comprobante, @id_cliente, @id_proveedor, @usuario_creacion, @precio_unitario);";

            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now));
            parameters.Add(new NpgsqlParameter("id_producto", mov.id_producto));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", mov.id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cantidad_ingreso", mov.cantidad_ingreso));
            parameters.Add(new NpgsqlParameter("cantidad_egreso", mov.cantidad_egreso));
            parameters.Add(new NpgsqlParameter("stock", stock + mov.cantidad_ingreso));
            parameters.Add(new NpgsqlParameter("id_modulo", mov.id_modulo));
            parameters.Add(new NpgsqlParameter("cod_comprobante", mov.cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_cliente", mov.id_cliente));
            parameters.Add(new NpgsqlParameter("id_proveedor", mov.id_proveedor));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));
            parameters.Add(new NpgsqlParameter("precio_unitario", mov.precio_unitario));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            ProductoDTO.sumarStock(mov.id_producto, mov.cantidad_ingreso);
        }

        public static void egreso(MovimientoDeArticulosDTO mov)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long stock = 0;

            string sql = "select stock from ofc_producto where id = @id_producto";

            parameters.Add(new NpgsqlParameter("id_producto", mov.Id_producto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                stock = long.Parse(data["stock"].ToString());
                data.Close();
            }

            sql = "insert into stk_movimiento (id, fecha, id_producto, id_tipo_comprobante, ingreso, egreso, stock, id_modulo, cod_comprobante, id_cliente, id_proveedor, usuario_creacion, precio_unitario)"
            + " values(nextval('stk_movimiento_id_seq'), @fecha, @id_producto, @id_tipo_comprobante, @cantidad_ingreso, @cantidad_egreso, @stock, @id_modulo, @cod_comprobante, @id_cliente, @id_proveedor, @usuario_creacion, @precio_unitario);";

            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now));
            parameters.Add(new NpgsqlParameter("id_producto", mov.id_producto));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", mov.id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cantidad_ingreso", mov.cantidad_ingreso));
            parameters.Add(new NpgsqlParameter("cantidad_egreso", mov.cantidad_egreso));
            parameters.Add(new NpgsqlParameter("stock", stock - mov.cantidad_egreso));
            parameters.Add(new NpgsqlParameter("id_modulo", mov.id_modulo));
            parameters.Add(new NpgsqlParameter("cod_comprobante", mov.cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_cliente", mov.id_cliente));
            parameters.Add(new NpgsqlParameter("id_proveedor", mov.id_proveedor));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));
            parameters.Add(new NpgsqlParameter("precio_unitario", mov.precio_unitario));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            ProductoDTO.restarStock(mov.id_producto, mov.cantidad_egreso);
        }

        public static List<MovimientoDeArticulosDTO> calcularMov(FacturaDTO fact)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from ofc_factura_detalle a, ofc_producto b where a.id_producto = b.id and a.id_factura = @id_factura and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_factura", fact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_egreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_cliente = fact.Id_cliente;
                m.Id_modulo = ValorDTO.obtenerId("VENTA");
                if (fact.Tipo_factura == 'A')
                {
                    m.Id_tipo_comprobante = ValorDTO.obtenerId("FACTURA A");
                    m.Cod_comprobante = ComprobanteDTO.converToNroFacturaA(fact.Nro_factura.ToString());
                }
                if (fact.Tipo_factura == 'B')
                {
                    m.Id_tipo_comprobante = ValorDTO.obtenerId("FACTURA B");
                    m.Cod_comprobante = ComprobanteDTO.converToNroFacturaB(fact.Nro_factura.ToString());
                }
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMovAnulacion(FacturaDTO fact)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from ofc_factura_detalle a, ofc_producto b where a.id_producto = b.id and a.id_factura = @id_factura and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_factura", fact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_ingreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_cliente = fact.Id_cliente;
                m.Id_modulo = ValorDTO.obtenerId("VENTA");
                m.Cod_comprobante = fact.Cod_comprobante;
                m.Id_tipo_comprobante = ValorDTO.obtenerId("AN. FACTURA " + fact.Tipo_factura.ToString());
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMovAnulacionBis(FacturaDTO fact)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from ofc_factura_detalle a, ofc_producto b where a.id_producto = b.id and a.id_factura = @id_factura and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_factura", fact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_ingreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_cliente = fact.Id_cliente;
                m.Id_modulo = ValorDTO.obtenerId("VENTA");
                if (fact.Tipo_factura == 'A')
                {
                    m.Id_tipo_comprobante = ValorDTO.obtenerId("AN. FACTURA A");
                    m.Cod_comprobante = ComprobanteDTO.converToNroFacturaA(fact.Nro_factura.ToString());
                }
                if (fact.Tipo_factura == 'B')
                {
                    m.Id_tipo_comprobante = ValorDTO.obtenerId("AN. FACTURA B");
                    m.Cod_comprobante = ComprobanteDTO.converToNroFacturaB(fact.Nro_factura.ToString());
                }
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMov(FacturaDeCompraDTO fact)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from cpc_factura_detalle a, ofc_producto b where a.id_producto = b.id and a.id_factura = @id_factura and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_factura", fact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_ingreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_proveedor = fact.Id_proveedor;
                m.Id_modulo = ValorDTO.obtenerId("COMPRA");
                m.Id_tipo_comprobante = ValorDTO.obtenerId("FACTURA " + fact.Tipo_factura.ToString());
                m.Cod_comprobante = fact.Cod_comprobante.ToString();
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMov(NotaDeCreditoDeCompraDTO cred)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from cpc_nota_credito_detalle a, ofc_producto b where a.id_producto = b.id and a.id_nota_credito = @id_nota_credito and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_nota_credito", cred.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_egreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_proveedor = cred.Id_proveedor;
                m.Id_modulo = ValorDTO.obtenerId("COMPRA");
                m.Id_tipo_comprobante = ValorDTO.obtenerId("NOTA DE CREDITO " + cred.Tipo_nota_credito.ToString());
                m.Cod_comprobante = cred.Cod_comprobante.ToString();
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMov(NotaDeDebitoDeCompraDTO deb)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from cpc_nota_debito_detalle a, ofc_producto b where a.id_producto = b.id and a.id_nota_debito = @id_nota_debito and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_nota_debito", deb.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_ingreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_proveedor = deb.Id_proveedor;
                m.Id_modulo = ValorDTO.obtenerId("COMPRA");
                m.Id_tipo_comprobante = ValorDTO.obtenerId("NOTA DE DEBITO " + deb.Tipo_nota_debito.ToString());
                m.Cod_comprobante = deb.Cod_comprobante.ToString();
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> calcularMovAnulacion(FacturaDeCompraDTO fact)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.id_producto idProd, a.precio_unitario precioUnitario, sum(a.cantidad) cantidad from cpc_factura_detalle a, ofc_producto b where a.id_producto = b.id and a.id_factura = @id_factura and b.es_cubierta = 'N' group by a.id_producto, a.precio_unitario";

            parameters.Add(new NpgsqlParameter("id_factura", fact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
                m.Cantidad_egreso = long.Parse(data["cantidad"].ToString());
                m.Stock = ProductoDTO.obtenerStock(m.Id_producto);
                m.Id_proveedor = fact.Id_proveedor;
                m.Id_modulo = ValorDTO.obtenerId("COMPRA");
                m.Id_tipo_comprobante = ValorDTO.obtenerId("AN. FACTURA " + fact.Tipo_factura.ToString());
                m.Cod_comprobante = fact.Cod_comprobante.ToString();
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.precio_unitario = Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero);

                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<MovimientoDeArticulosDTO> obtenerMovimientos(long idArticulo, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<MovimientoDeArticulosDTO> lista = new List<MovimientoDeArticulosDTO>();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select mov.fecha fecha, mov.id_producto idProd, prod.codigo codProducto, prod.descripcion descProducto, mov.egreso cantEgreso, mov.ingreso cantIngreso, mov.stock stock,";
	        sql = sql + " mov.id_cliente idCliente, mov.id_proveedor idProveedor, mov.id_modulo idModulo, val.valor operacion, mov.id_tipo_comprobante idTipoComprobante,";
	        sql = sql + " val2.valor descTipoComprobante, mov.cod_comprobante codComprobante, mov.precio_unitario precioUnitario";	    
	        sql = sql + " from stk_movimiento mov, ofc_tabla_valor val, ofc_producto prod, ofc_tabla_valor val2";	    
	        sql = sql + " where mov.id_producto = prod.id and mov.id_modulo = val.id and val2.id = mov.id_tipo_comprobante";
            sql = sql + " and mov.fecha >= @fechaDesde and mov.fecha <= @fechaHasta and mov.id_producto = @idArticulo order by mov.fecha";

            parameters.Add(new NpgsqlParameter("fechaDesde", fechaDesde));
	        parameters.Add(new NpgsqlParameter("fechaHasta", fechaHasta));
	        parameters.Add(new NpgsqlParameter("idArticulo", idArticulo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoDeArticulosDTO m = new MovimientoDeArticulosDTO();
                m.Id_producto = long.Parse(data["idProd"].ToString());
		        m.Cod_producto = data["codProducto"].ToString();
                m.Desc_producto = data["descProducto"].ToString();
                m.Cantidad_egreso = long.Parse(data["cantEgreso"].ToString());
		        m.Cantidad_ingreso = long.Parse(data["cantIngreso"].ToString());
                m.Stock = long.Parse(data["stock"].ToString());
                m.Id_cliente = data["idCliente"].ToString();
                m.Id_proveedor = data["idProveedor"].ToString();
                m.Id_modulo = long.Parse(data["idModulo"].ToString());
		        m.Desc_operacion = data["operacion"].ToString();
		        m.Id_tipo_comprobante = long.Parse(data["idTipoComprobante"].ToString());
                m.Desc_tipo_comprobante = data["descTipoComprobante"].ToString();
		        m.Cod_comprobante = data["codComprobante"].ToString();
                m.fecha = DateTime.Parse(data["fecha"].ToString());
                m.v_fecha = String.Format("{0:d/M/yyyy HH:mm:ss}", m.fecha);
                m.precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                m.v_precio_unitario = String.Format("{0:C}", Math.Round(m.precio_unitario, 2, MidpointRounding.AwayFromZero));
                
                lista.Add(m);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

    }
}

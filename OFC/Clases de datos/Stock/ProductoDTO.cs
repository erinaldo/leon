using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ProductoDTO
    {

        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        char es_cubierta;

        public char Es_cubierta
        {
            get { return es_cubierta; }
            set { es_cubierta = value; }
        }

        char vigente;

        public char Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        string medida_cubierta;

        public string Medida_cubierta
        {
            get { return medida_cubierta; }
            set { medida_cubierta = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        long id_cuenta_compra;

        public long Id_cuenta_compra
        {
            get { return id_cuenta_compra; }
            set { id_cuenta_compra = value; }
        }

        long id_cuenta_venta;

        public long Id_cuenta_venta
        {
            get { return id_cuenta_venta; }
            set { id_cuenta_venta = value; }
        }

        long stock;

        public long Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        string codigo_de_barras;

        public string Codigo_de_barras
        {
            get { return codigo_de_barras; }
            set { codigo_de_barras = value; }
        }

        decimal precio_de_referencia;

        public decimal Precio_de_referencia
        {
            get { return precio_de_referencia; }
            set { precio_de_referencia = value; }
        }

        string cod_proveedor;

        public string Cod_proveedor
        {
            get { return cod_proveedor; }
            set { cod_proveedor = value; }
        }

        #region Constructor

        public ProductoDTO()
        {
            //new id
            id = -1;
            descripcion = "";
            es_cubierta = 'N';
            vigente = 'N';
            medida_cubierta = "";
            codigo = "";
            id_cuenta_compra = -1;
            id_cuenta_venta = -1;
            stock = 0;
            codigo_de_barras = string.Empty;
            precio_de_referencia = decimal.Zero;
            cod_proveedor = string.Empty;
        }

        #endregion

        public static IList<ProductoDTO> obtenerMedidaCubierta()
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, medida_cubierta";
            sql = sql + " from ofc_producto";
            sql = sql + " where es_cubierta = 'S'";
            sql = sql + " and vigente = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn); 

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.medida_cubierta = data["medida_cubierta"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerMedidaCubierta2()
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, medida_cubierta";
            sql = sql + " from ofc_producto";
            sql = sql + " where es_cubierta = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.medida_cubierta = data["medida_cubierta"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerDescripcion()
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct codigo, descripcion";
            sql = sql + " from ofc_producto";
            sql = sql + " where vigente = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerDescripcion2()
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select codigo, descripcion";
            sql = sql + " from ofc_producto where descripcion <> 'CUBIERTA'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static long buscarId(string descripcion)
        {
            long idProd = -1;

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id";
            sql = sql + " from ofc_producto";
            sql = sql + " where descripcion = @descripcion and es_cubierta = 'N'";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idProd = long.Parse(data["id"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idProd;
        }




        public static long buscarId2(string descripcion)
        {
            long idProd = -1;

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id";
            sql = sql + " from ofc_producto";
            sql = sql + " where descripcion = @descripcion";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idProd = long.Parse(data["id"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idProd;
        }

        public static long buscarId3(string descripcion, string cubierta)
        {
            long idProd = -1;

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id";
            sql = sql + " from ofc_producto";
            sql = sql + " where descripcion = @descripcion and medida_cubierta = @cubierta";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            parameters.Add(new NpgsqlParameter("cubierta", cubierta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idProd = long.Parse(data["id"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idProd;
        }

        public static long buscarId4(string codigo)
        {
            long idProd = -1;

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id";
            sql = sql + " from ofc_producto";
            sql = sql + " where codigo = @codigo and es_cubierta = 'N'";

            parameters.Add(new NpgsqlParameter("codigo", codigo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idProd = long.Parse(data["id"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idProd;
        }

        public static IList<ProductoDTO> obtenerArticulosDisponibles(string cod_proveedor)
        {
            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select prod.id id, prod.descripcion descripcion, prod.codigo codigo";
            sql = sql + " from ofc_producto prod";
            sql = sql + " where prod.es_cubierta = 'N' and prod.vigente = 'S'";
            sql = sql + " except";
            sql = sql + " select prod.id id, prod.descripcion descripcion, prod.codigo codigo";
            sql = sql + " from ofc_producto prod, cpc_precio precio";
            sql = sql + " where prod.id = precio.id_producto and prod.es_cubierta = 'N' and prod.vigente = 'S'";
            sql = sql + " and precio.id_proveedor = @cod_proveedor order by 3,2";

            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.codigo = data["codigo"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerArticulosDisponibles(string cod_proveedor, string cod_articulo)
        {
            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select prod.id id, prod.descripcion descripcion, prod.codigo codigo";
            sql = sql + " from ofc_producto prod";
            sql = sql + " where prod.es_cubierta = 'N' and prod.vigente = 'S' and prod.codigo = @cod_articulo";
            sql = sql + " except";
            sql = sql + " select prod.id id, prod.descripcion descripcion, prod.codigo codigo";
            sql = sql + " from ofc_producto prod, cpc_precio precio";
            sql = sql + " where prod.id = precio.id_producto and prod.es_cubierta = 'N' and prod.vigente = 'S'";
            sql = sql + " and precio.id_proveedor = @cod_proveedor order by 3,2";

            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));
            parameters.Add(new NpgsqlParameter("cod_articulo", cod_articulo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.codigo = data["codigo"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerArticulos()
        {
            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select prod.id id, prod.descripcion descripcion, prod.codigo codigo";
            sql = sql + " from ofc_producto prod";
            sql = sql + " where prod.es_cubierta = 'N' and prod.vigente = 'S' order by 3,2";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.codigo = data["codigo"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerArticulos2(string descripcion) 
        {
            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id, descripcion, medida_cubierta, es_cubierta, vigente, codigo, id_cuenta_compra, id_cuenta_venta, stock, codigo_de_barra, precio_de_referencia";
            sql = sql + " from ofc_producto";
            sql = sql + " where es_cubierta = 'N' and vigente = 'S'";

            if (descripcion != string.Empty)
            {
                sql = sql + " and descripcion = @descripcion";
            }

            sql = sql + " order by 6, 2";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.medida_cubierta = data["medida_cubierta"].ToString();
                e.es_cubierta = char.Parse(data["es_cubierta"].ToString());
                e.vigente = char.Parse(data["vigente"].ToString());
                e.codigo = data["codigo"].ToString();
                e.id_cuenta_compra = long.Parse(data["id_cuenta_compra"].ToString());
                e.id_cuenta_venta = long.Parse(data["id_cuenta_venta"].ToString());
                e.stock = long.Parse(data["stock"].ToString());
                e.codigo_de_barras = data["codigo_de_barra"].ToString();
                e.precio_de_referencia = decimal.Parse(data["precio_de_referencia"].ToString());
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerArticulos(string descripcion)
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id, descripcion, medida_cubierta, es_cubierta, vigente, codigo, id_cuenta_compra, id_cuenta_venta, stock, codigo_de_barra, precio_de_referencia";
            sql = sql + " from ofc_producto";
            sql = sql + " where es_cubierta = 'N'";

            if (descripcion != string.Empty)
            {
                sql = sql + " and descripcion = @descripcion";
            }

            sql = sql + " order by 6, 2, 3";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.medida_cubierta = data["medida_cubierta"].ToString();
                e.es_cubierta = char.Parse(data["es_cubierta"].ToString());
                e.vigente = char.Parse(data["vigente"].ToString());
                e.codigo = data["codigo"].ToString();
                e.id_cuenta_compra = long.Parse(data["id_cuenta_compra"].ToString());
                e.id_cuenta_venta = long.Parse(data["id_cuenta_venta"].ToString());
                e.stock = long.Parse(data["stock"].ToString());
                e.codigo_de_barras = data["codigo_de_barra"].ToString();
                e.precio_de_referencia = decimal.Parse(data["precio_de_referencia"].ToString());
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ProductoDTO> obtenerNeumaticos(string cubierta)
        {

            IList<ProductoDTO> lista = new BindingList<ProductoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id, descripcion, medida_cubierta, es_cubierta, vigente, codigo, id_cuenta_compra, id_cuenta_venta, stock";
            sql = sql + " from ofc_producto";
            sql = sql + " where es_cubierta = 'S'";

            if (cubierta != string.Empty)
            {
                sql = sql + " and medida_cubierta = @cubierta";
            }
            sql = sql + " order by 2, 3";

            parameters.Add(new NpgsqlParameter("cubierta", cubierta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ProductoDTO e = new ProductoDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.medida_cubierta = data["medida_cubierta"].ToString();
                e.es_cubierta = char.Parse(data["es_cubierta"].ToString());
                e.vigente = char.Parse(data["vigente"].ToString());
                e.codigo = data["codigo"].ToString();
                if (data["id_cuenta_compra"] != null && data["id_cuenta_compra"] != DBNull.Value)
                {
                    e.id_cuenta_compra = long.Parse(data["id_cuenta_compra"].ToString());
                }
                if (data["id_cuenta_venta"] != null && data["id_cuenta_venta"] != DBNull.Value)
                {
                    e.id_cuenta_venta = long.Parse(data["id_cuenta_venta"].ToString());
                }
                if (data["stock"] != null && data["stock"] != DBNull.Value)
                {
                    e.stock = long.Parse(data["stock"].ToString());
                }
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static void actualizarPrecioVigente(long idProducto, decimal precioVigente)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_producto set precio_de_referencia = @precio_de_referencia where id = @idProducto;";

            parameters.Add(new NpgsqlParameter("idProducto", idProducto));
            parameters.Add(new NpgsqlParameter("precio_de_referencia", precioVigente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertarProducto(ProductoDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "insert into ofc_producto (id, descripcion, es_cubierta, vigente, medida_cubierta, codigo, id_cuenta_compra, id_cuenta_venta, stock, codigo_de_barra, precio_de_referencia)"
            + " values(nextval('ofc_producto_id_seq'),@descripcion,@es_cubierta,@vigente,@medida_cubierta, @codigo, @id_cuenta_compra, @id_cuenta_venta, @stock, @codigo_de_barra, @precio_de_referencia);";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("es_cubierta", data.es_cubierta));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("medida_cubierta", data.medida_cubierta));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));
            parameters.Add(new NpgsqlParameter("id_cuenta_compra", data.id_cuenta_compra));
            parameters.Add(new NpgsqlParameter("id_cuenta_venta", data.id_cuenta_venta));
            parameters.Add(new NpgsqlParameter("stock", data.stock));
            parameters.Add(new NpgsqlParameter("codigo_de_barra", data.codigo_de_barras));
            parameters.Add(new NpgsqlParameter("precio_de_referencia", data.precio_de_referencia));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void actualizarProducto(ProductoDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_producto set descripcion = @descripcion, medida_cubierta = @medida_cubierta, vigente = @vigente, id_cuenta_compra = @id_cuenta_compra, id_cuenta_venta = @id_cuenta_venta, codigo_de_barra = @codigo_de_barra, precio_de_referencia = @precio_de_referencia where id = @id;";

            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("medida_cubierta", data.medida_cubierta));
            parameters.Add(new NpgsqlParameter("id_cuenta_compra", data.id_cuenta_compra));
            parameters.Add(new NpgsqlParameter("id_cuenta_venta", data.id_cuenta_venta));
            parameters.Add(new NpgsqlParameter("codigo_de_barra", data.codigo_de_barras));
            parameters.Add(new NpgsqlParameter("precio_de_referencia", data.precio_de_referencia));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static bool borrarProducto(long idProducto)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            parameters.Add(new NpgsqlParameter("id", idProducto));

            string sql = "delete from ofc_precio where id_producto = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from stk_movimiento where id_producto = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_producto where id = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return true;
        }

        public static bool tieneMovimientoAsociado(long idProducto)
        {

            long count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //en movimientos de stock
            string sql = "select count(1) as cantidad from stk_movimiento where id_producto = @idProducto";
            parameters.Add(new NpgsqlParameter("idProducto", idProducto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool tieneComprobanteAsociado(long idProducto)
        {

            long count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //en ordenes
            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo_detalle where id_producto = @idProducto";
            parameters.Add(new NpgsqlParameter("idProducto", idProducto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en facturas
            sql = "select count(1) as cantidad from ofc_factura_detalle where id_producto = @idProducto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en facturas de compra
            sql = "select count(1) as cantidad from cpc_factura_detalle where id_producto = @idProducto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en nota de credito de compra
            sql = "select count(1) as cantidad from cpc_nota_credito_detalle where id_producto = @idProducto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en nota de debito de compra
            sql = "select count(1) as cantidad from cpc_nota_debito_detalle where id_producto = @idProducto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeCodigoDeBarra(string codigo)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_producto where codigo_de_barra = @codigo and vigente = 'S' and codigo <> 'AUTO'";
            parameters.Add(new NpgsqlParameter("codigo", codigo));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool existeCodigoDeBarra(long id, string codigo)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_producto where codigo_de_barra = @codigo and vigente = 'S' and codigo <> 'AUTO' and id != @id";
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool existeDescripcion(string descripcion)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_producto where descripcion = @descripcion and vigente = 'S' and codigo <> 'AUTO'";
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool existeDescripcion(long id, string descripcion)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_producto where descripcion = @descripcion and vigente = 'S' and codigo <> 'AUTO' and id != @id";
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool existeCodigo(string codigo)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_producto where codigo = @codigo and vigente = 'S' and codigo <> 'AUTO'";
            parameters.Add(new NpgsqlParameter("codigo", codigo));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static long obtenerStock(long id)
        {
            long stock = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select stock from ofc_producto where id = @id";
            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                stock = long.Parse(data["stock"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return stock;
        }

        public static string obtenerDescripcion(string codigoDeBarra)
        {
            string descripcion = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select descripcion from ofc_producto where codigo_de_barra = @codigoDeBarra and vigente = 'S'";
            parameters.Add(new NpgsqlParameter("codigoDeBarra", codigoDeBarra));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                descripcion = data["descripcion"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return descripcion;
        }

        public static long obtenerCantidadPorFacturar(long id)
        {
            long cantidadAFacturar = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select sum(det.cantidad) cantidad from ofc_comprobante_temp temp, ofc_factura_detalle det where det.id_factura = temp.id_origen and det.id_producto = @id and temp.comprobante = 'FACTURA'";
            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["cantidad"] != null && data["cantidad"] != DBNull.Value)
                {
                    cantidadAFacturar = long.Parse(data["cantidad"].ToString());
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cantidadAFacturar;
        }

        public static string buscarCodigo(long id)
        {
            string codigo = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select codigo from ofc_producto where id = @id";
            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codigo = data["codigo"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return codigo;
        }

        public static void sumarStock(long id, long cantidad)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_producto set stock = stock + @cantidad where id = @id;";

            parameters.Add(new NpgsqlParameter("id", id));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void restarStock(long id, long cantidad)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_producto set stock = stock - @cantidad where id = @id;";

            parameters.Add(new NpgsqlParameter("id", id));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }


    }
}

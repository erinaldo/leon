using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class PrecioProveedorDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        string id_proveedor;

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        string producto;

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        string v_precio;

        public string V_precio
        {
            get { return v_precio; }
            set { v_precio = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public PrecioProveedorDTO()
        {
            id = -1;
            id_proveedor = String.Empty;
            id_producto = -1;
            producto = String.Empty;
            valor = decimal.Zero;
            v_precio = String.Empty;
            codigo = String.Empty;
        }


        public static void insertarPrecio(PrecioProveedorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el precio
            string sql = "insert into cpc_precio (id, id_proveedor, id_producto, valor, codigo)"
            + " values(nextval('cpc_precio_id_seq'),@idProveedor,@idProducto,@precio,@codigo);";

            parameters.Add(new NpgsqlParameter("idProveedor", data.id_proveedor));
            parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));
            parameters.Add(new NpgsqlParameter("precio", decimal.Round(data.valor, 2, MidpointRounding.AwayFromZero)));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }


        public static void borrarPrecio(PrecioProveedorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Borramos el precio
            string sql = "delete from cpc_precio where id_proveedor = @idProveedor and id_producto = @idProducto";

            parameters.Add(new NpgsqlParameter("idProveedor", data.id_proveedor));
            parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void actualizarPrecio(PrecioProveedorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // actualizar el precio
            string sql = "update cpc_precio set valor = @precio"
            + " where id_producto = @idProducto and id_proveedor = @idProveedor";

            parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));
            parameters.Add(new NpgsqlParameter("idProveedor", data.id_proveedor));
            parameters.Add(new NpgsqlParameter("precio", data.valor));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<PrecioProveedorDTO> obtenerPrecios(string id_proveedor)
        {
            List<PrecioProveedorDTO> lista = new List<PrecioProveedorDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select precio.id idPrecio, precio.id_proveedor idProveedor, producto.id idProducto, producto.descripcion descripcionProducto, precio.valor precio, precio.codigo codigo";
            sql = sql + " from cpc_precio precio, ofc_producto producto";
            sql = sql + " where precio.id_producto = producto.id";
            sql = sql + " and producto.vigente = 'S'";
            sql = sql + " and precio.id_proveedor = @id_proveedor";
            sql = sql + " order by 6, 4";

            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de precios                        
            while (data != null && data.Read())
            {
                PrecioProveedorDTO e = new PrecioProveedorDTO();

                e.id = long.Parse(data["idPrecio"].ToString());
                e.id_proveedor = data["idProveedor"].ToString();
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.producto = data["descripcionProducto"].ToString();
                e.valor = Decimal.Parse(data["precio"].ToString());
                e.valor = decimal.Round(e.valor, 2, MidpointRounding.AwayFromZero);
                e.v_precio = String.Format("{0:0.00}", e.valor);
                e.codigo = data["codigo"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<PrecioProveedorDTO> obtenerPrecios(string id_proveedor, string cod_articulo)
        {
            List<PrecioProveedorDTO> lista = new List<PrecioProveedorDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select precio.id idPrecio, precio.id_proveedor idProveedor, producto.id idProducto, producto.descripcion descripcionProducto, precio.valor precio, precio.codigo codigo";
            sql = sql + " from cpc_precio precio, ofc_producto producto";
            sql = sql + " where precio.id_producto = producto.id";
            sql = sql + " and producto.vigente = 'S'";
            sql = sql + " and precio.id_proveedor = @id_proveedor";
            sql = sql + " and producto.codigo = @cod_articulo";
            sql = sql + " order by 6, 4";

            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));
            parameters.Add(new NpgsqlParameter("cod_articulo", cod_articulo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de precios                        
            while (data != null && data.Read())
            {
                PrecioProveedorDTO e = new PrecioProveedorDTO();

                e.id = long.Parse(data["idPrecio"].ToString());
                e.id_proveedor = data["idProveedor"].ToString();
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.producto = data["descripcionProducto"].ToString();
                e.valor = Decimal.Parse(data["precio"].ToString());
                e.valor = decimal.Round(e.valor, 2, MidpointRounding.AwayFromZero);
                e.v_precio = String.Format("{0:0.00}", e.valor);
                e.codigo = data["codigo"].ToString();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class PrecioDTO
    {

        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_servicio;

        public long Id_servicio
        {
            get { return id_servicio; }
            set { id_servicio = value; }
        }

        string servicio;

        public string Servicio
        {
            get { return servicio; }
            set { servicio = value; }
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

        long id_lista_precio;

        public long Id_lista_precio
        {
            get { return id_lista_precio; }
            set { id_lista_precio = value; }
        }

        string lista_de_precio;

        public string Lista_de_precio
        {
            get { return lista_de_precio; }
            set { lista_de_precio = value; }
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

        string medida_cubierta;

        public string Medida_cubierta
        {
            get { return medida_cubierta; }
            set { medida_cubierta = value; }
        }



        public PrecioDTO()
        {
            id = -1;
            id_servicio = -1;
            servicio = String.Empty;
            id_producto = -1;
            producto = String.Empty;
            id_lista_precio = -1;
            lista_de_precio = String.Empty;
            valor = -1;
            v_precio = String.Empty;
            codigo = String.Empty;
            medida_cubierta = String.Empty;
        }

        public static List<PrecioDTO> obtenerPrecios(long idLista, string medidaCubierta, string articulo)
        {
            List<PrecioDTO> lista = new List<PrecioDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();


            //agregar un union para traer los precios de productos sin servicio
            string sql = "select precio.id idPrecio, servicio.id idServicio, servicio.descripcion descripcionServicio, producto.id idProducto, producto.descripcion descripcionProducto, producto.medida_cubierta medidaCubierta, val.valor listaDePrecio, val.id idListaDePrecio, precio.valor precio, precio.codigo codigo";
            sql = sql + " from ofc_precio precio, ofc_servicio servicio, ofc_producto producto, ofc_tabla_valor val";
            sql = sql + " where precio.id_servicio = servicio.id";
            sql = sql + " and precio.id_producto = producto.id";
            sql = sql + " and val.id = precio.id_lista_precio";
            sql = sql + " and servicio.vigente = 'S'";
            sql = sql + " and producto.vigente = 'S'";
            sql = sql + " and val.id_tabla = 'LP'";

            if (idLista != -1)
            {
                sql = sql + " and precio.id_lista_precio = @idLista";
            }

            if (medidaCubierta != string.Empty)
            {
                sql = sql + " and producto.medida_cubierta = @medidaCubierta";
            }

            if (articulo != string.Empty)
            {
                sql = sql + " and producto.descripcion = @articulo";
            }

            sql = sql + " union select precio.id idPrecio, 99999999 idServicio, '' descripcionServicio, producto.id idProducto, producto.descripcion descripcionProducto, producto.medida_cubierta medidaCubierta, val.valor listaDePrecio, val.id idListaDePrecio, precio.valor precio, precio.codigo codigo";
            sql = sql + " from ofc_precio precio, ofc_producto producto, ofc_tabla_valor val";
            sql = sql + " where precio.id_servicio = -1";
            sql = sql + " and precio.id_producto = producto.id";
            sql = sql + " and val.id = precio.id_lista_precio";
            sql = sql + " and producto.vigente = 'S'";
            sql = sql + " and val.id_tabla = 'LP'";

            if (idLista != -1)
            {
                sql = sql + " and precio.id_lista_precio = @idLista";
            }

            if (medidaCubierta != string.Empty)
            {
                sql = sql + " and producto.medida_cubierta = @medidaCubierta";
            }

            if (articulo != string.Empty)
            {
                sql = sql + " and producto.descripcion = @articulo";
            }

            sql = sql + " order by 5, 6, 2";

            parameters.Add(new NpgsqlParameter("idLista", idLista));
            parameters.Add(new NpgsqlParameter("medidaCubierta", medidaCubierta));
            parameters.Add(new NpgsqlParameter("articulo", articulo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de precios                        
            while (data != null && data.Read())
            {
                PrecioDTO e = new PrecioDTO();

                e.id = long.Parse(data["idPrecio"].ToString());
                e.id_servicio = long.Parse(data["idServicio"].ToString());
                e.servicio = data["descripcionServicio"].ToString();
                e.id_producto = long.Parse(data["idProducto"].ToString());
                e.producto = data["descripcionProducto"].ToString();
                e.medida_cubierta = data["medidaCubierta"].ToString();
                e.id_lista_precio = long.Parse(data["idListaDePrecio"].ToString());
                e.lista_de_precio = data["listaDePrecio"].ToString();
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

        public static void insertarPrecio(PrecioDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el precio
            string sql = "insert into ofc_precio (id, id_producto, id_servicio, valor, id_lista_precio, codigo)"
            + " values(nextval('ofc_precio_id_seq'),@idProducto,@idServicio,@precio,@idListaPrecio,@codigo);";

            parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", data.id_servicio));
            parameters.Add(new NpgsqlParameter("precio", decimal.Round(data.valor, 2, MidpointRounding.AwayFromZero)));
            parameters.Add(new NpgsqlParameter("idListaPrecio", data.id_lista_precio));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        
        public static void actualizarPrecio(PrecioDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // actualizar el precio
            string sql = "update ofc_precio set id_producto = @idProducto, id_servicio = @idServicio, valor = @precio, id_lista_precio = @idListaPrecio"
            + " where id = @id;";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", data.id_servicio));
            parameters.Add(new NpgsqlParameter("precio", decimal.Round(data.valor, 2, MidpointRounding.AwayFromZero)));
            parameters.Add(new NpgsqlParameter("idListaPrecio", data.id_lista_precio));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void actualizarPrecio(List<PrecioDTO> listData)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_precio set id_producto = @idProducto, id_servicio = @idServicio, valor = @precio, id_lista_precio = @idListaPrecio"
            + " where id = @id;";

            foreach (PrecioDTO data in listData)
            {

                parameters.Clear();

                parameters.Add(new NpgsqlParameter("id", data.id));
                parameters.Add(new NpgsqlParameter("idProducto", data.id_producto));
                parameters.Add(new NpgsqlParameter("idServicio", data.id_servicio));
                parameters.Add(new NpgsqlParameter("precio", decimal.Round(data.valor, 2, MidpointRounding.AwayFromZero)));
                parameters.Add(new NpgsqlParameter("idListaPrecio", data.id_lista_precio));

                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
        
        public static bool borrarPrecio(long idPrecio)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //borrar el precio
            string sql = "delete from ofc_precio where id = @id";

            parameters.Add(new NpgsqlParameter("id", idPrecio));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return true;
        }

        
        public static long buscarId(PrecioDTO p)
        {

            long idPrecio = -1;
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select precio.id idPrecio";
            sql = sql + " from ofc_precio precio";
            sql = sql + " where precio.id_servicio = @idServicio";
            sql = sql + " and precio.id_producto = @idProducto";
            sql = sql + " and precio.id_lista_precio = @idListaPrecio";

            parameters.Add(new NpgsqlParameter("idServicio", p.id_servicio));
            parameters.Add(new NpgsqlParameter("idProducto", p.id_producto));
            parameters.Add(new NpgsqlParameter("idListaPrecio", p.id_lista_precio));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idPrecio = long.Parse(data["idPrecio"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idPrecio;

        }

        public static decimal buscarPrecio(PrecioDTO p)
        {

            decimal valor = -1;
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select precio.valor valor";
            sql = sql + " from ofc_precio precio";
            sql = sql + " where precio.id_servicio = @idServicio";
            sql = sql + " and precio.id_producto = @idProducto";
            sql = sql + " and precio.id_lista_precio = @idListaPrecio";

            parameters.Add(new NpgsqlParameter("idServicio", p.id_servicio));
            parameters.Add(new NpgsqlParameter("idProducto", p.id_producto));
            parameters.Add(new NpgsqlParameter("idListaPrecio", p.id_lista_precio));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                valor = Decimal.Parse(data["valor"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return valor;

        }

    }
}

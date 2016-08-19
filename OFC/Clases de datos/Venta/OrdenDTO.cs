using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;


namespace OFC
{
    class OrdenDTO
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

        public OrdenDTO()
        {
            id = -1;
            fecha = DateTime.Now;
            nombre_cliente = "";
            id_cliente = "";
        }

        public static void insertarOrden(OrdenDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el cliente
            string sql = "insert into ofc_orden_de_trabajo (id,fecha,nombre_cliente,id_cliente,usuario_creacion)"
            + " values(@id,@fecha,@nombre_cliente,@id_cliente,@usuario_creacion);";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("fecha", data.fecha));
            parameters.Add(new NpgsqlParameter("nombre_cliente", data.nombre_cliente));
            parameters.Add(new NpgsqlParameter("id_cliente", data.id_cliente));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static bool existeNroOrden(long nroOrden)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo where id = @nroOrden";
            parameters.Add(new NpgsqlParameter("nroOrden", nroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool existeNroOrdenHist(long nroOrden)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo_hist where id = @nroOrden";
            parameters.Add(new NpgsqlParameter("nroOrden", nroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool isTemp(long nroOrden)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante_temp where comprobante = 'ORDENES' and id_origen = @nroOrden";
            parameters.Add(new NpgsqlParameter("nroOrden", nroOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static List<OrdenDTO> obtenerNroOrdenesRegistradas()
        {
            List<OrdenDTO> lista = new List<OrdenDTO>(); 

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select det.id id";
            sql = sql + " from ofc_orden_de_trabajo det";
            sql = sql + " where not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = det.id and c_temp.comprobante = 'ORDENES')";
            sql = sql + " order by 1";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);  

            while (data != null && data.Read())
            {
                OrdenDTO e = new OrdenDTO();

                e.id = long.Parse(data["id"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static string obtenerCliente(long idOrden)
        {
            string codCliente = "";
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_cliente idCliente";
            sql = sql + " from ofc_orden_de_trabajo det";
            sql = sql + " where det.id = @idOrden";

            parameters.Add(new NpgsqlParameter("idOrden", idOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codCliente = data["idCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return codCliente;

        }

        public static string obtenerClienteOrdenHist(long idOrden)
        {
            string codCliente = "";
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_cliente idCliente";
            sql = sql + " from ofc_orden_de_trabajo_hist det";
            sql = sql + " where det.id = @idOrden";

            parameters.Add(new NpgsqlParameter("idOrden", idOrden));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codCliente = data["idCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return codCliente;

        }

        public static void migrarAHist(FacturaDTO dataFact)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDetHist = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDet = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnOrd = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_orden_de_trabajo idOrden, det.id_renglon_orden_de_trabajo idRenglon";
            sql = sql + " from ofc_factura_detalle det";
            sql = sql + " where det.id_factura = @idFactura";
            sql = sql + " order by 1, 2";

            parameters.Add(new NpgsqlParameter("idFactura", dataFact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                parameters.Add(new NpgsqlParameter("idOrden", data["idOrden"].ToString()));
                parameters.Add(new NpgsqlParameter("idRenglon", data["idRenglon"].ToString()));

                //inserto solo la primera vez la orden historica
                sql = "INSERT INTO ofc_orden_de_trabajo_hist SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_hist ordh where ordh.id = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //inserto el renglon en la historica de detalle
                sql = "INSERT INTO ofc_orden_de_trabajo_detalle_hist SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_detalle ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //borro el renglon de detalle
                sql = "delete from ofc_orden_de_trabajo_detalle ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDet, parameters);

                //borro la orden si no hay mas renglones
                sql = "delete from ofc_orden_de_trabajo ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_detalle det where det.id_orden_de_trabajo = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnOrd, parameters);
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnDetHist.State == System.Data.ConnectionState.Open)
                cnDetHist.Close();

            if (cnDet.State == System.Data.ConnectionState.Open)
                cnDet.Close();

            if (cnOrd.State == System.Data.ConnectionState.Open)
                cnOrd.Close();

        }

        public static void migrarAHist(RemitoDTO dataRem)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDetHist = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDet = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnOrd = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_orden_de_trabajo idOrden, det.id_renglon_orden_de_trabajo idRenglon";
            sql = sql + " from ofc_remito_detalle det";
            sql = sql + " where det.id_remito = @idRemito";
            sql = sql + " order by 1, 2";

            parameters.Add(new NpgsqlParameter("idRemito", dataRem.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                parameters.Clear(); //feb 1.8 fix bis
                parameters.Add(new NpgsqlParameter("idRemito", dataRem.Id)); //feb 1.8 fix bis
                parameters.Add(new NpgsqlParameter("idOrden", data["idOrden"].ToString()));
                parameters.Add(new NpgsqlParameter("idRenglon", data["idRenglon"].ToString()));

                //inserto solo la primera vez la orden historica
                sql = "INSERT INTO ofc_orden_de_trabajo_hist SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_hist ordh where ordh.id = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //inserto el renglon en la historica de detalle
                sql = "INSERT INTO ofc_orden_de_trabajo_detalle_hist SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_detalle ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //borro el renglon de detalle
                sql = "delete from ofc_orden_de_trabajo_detalle ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDet, parameters);

                //borro la orden si no hay mas renglones
                sql = "delete from ofc_orden_de_trabajo ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_detalle det where det.id_orden_de_trabajo = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnOrd, parameters);
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnDetHist.State == System.Data.ConnectionState.Open)
                cnDetHist.Close();

            if (cnDet.State == System.Data.ConnectionState.Open)
                cnDet.Close();

            if (cnOrd.State == System.Data.ConnectionState.Open)
                cnOrd.Close();

        }


        public static void migrarAPend(FacturaDTO dataFact)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDetHist = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDet = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnOrd = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_orden_de_trabajo idOrden, det.id_renglon_orden_de_trabajo idRenglon";
            sql = sql + " from ofc_factura_detalle det";
            sql = sql + " where det.id_factura = @idFactura";
            sql = sql + " order by 1, 2";

            parameters.Add(new NpgsqlParameter("idFactura", dataFact.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                parameters.Add(new NpgsqlParameter("idOrden", data["idOrden"].ToString()));
                parameters.Add(new NpgsqlParameter("idRenglon", data["idRenglon"].ToString()));

                //inserto solo la primera vez la orden pendiente
                sql = "INSERT INTO ofc_orden_de_trabajo SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_hist ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo ordh where ordh.id = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //inserto el renglon en la tabla de pendientes de detalle
                sql = "INSERT INTO ofc_orden_de_trabajo_detalle SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_detalle_hist ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //borro el renglon de detalle
                sql = "delete from ofc_orden_de_trabajo_detalle_hist ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDet, parameters);

                //borro la orden si no hay mas renglones
                sql = "delete from ofc_orden_de_trabajo_hist ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_detalle_hist det where det.id_orden_de_trabajo = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnOrd, parameters);
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnDetHist.State == System.Data.ConnectionState.Open)
                cnDetHist.Close();

            if (cnDet.State == System.Data.ConnectionState.Open)
                cnDet.Close();

            if (cnOrd.State == System.Data.ConnectionState.Open)
                cnOrd.Close();

        }

        public static void migrarAPend(RemitoDTO dataRem)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDetHist = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnDet = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnOrd = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.id_orden_de_trabajo idOrden, det.id_renglon_orden_de_trabajo idRenglon";
            sql = sql + " from ofc_remito_detalle det";
            sql = sql + " where det.id_remito = @idRemito";
            sql = sql + " order by 1, 2";

            parameters.Add(new NpgsqlParameter("idRemito", dataRem.Id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                parameters.Add(new NpgsqlParameter("idOrden", data["idOrden"].ToString()));
                parameters.Add(new NpgsqlParameter("idRenglon", data["idRenglon"].ToString()));

                //inserto solo la primera vez la orden pendiente
                sql = "INSERT INTO ofc_orden_de_trabajo SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_hist ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo ordh where ordh.id = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //inserto el renglon en la tabla de pendientes de detalle
                sql = "INSERT INTO ofc_orden_de_trabajo_detalle SELECT *";
                sql = sql + " FROM ofc_orden_de_trabajo_detalle_hist ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDetHist, parameters);

                //borro el renglon de detalle
                sql = "delete from ofc_orden_de_trabajo_detalle_hist ord where ord.id_orden_de_trabajo = @idOrden and ord.renglon = @idRenglon";

                BaseDeDatos.ejecutarNonQuery(sql, cnDet, parameters);

                //borro la orden si no hay mas renglones
                sql = "delete from ofc_orden_de_trabajo_hist ord where ord.id = @idOrden and not exists (select 1 from ofc_orden_de_trabajo_detalle_hist det where det.id_orden_de_trabajo = ord.id)";

                BaseDeDatos.ejecutarNonQuery(sql, cnOrd, parameters);
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnDetHist.State == System.Data.ConnectionState.Open)
                cnDetHist.Close();

            if (cnDet.State == System.Data.ConnectionState.Open)
                cnDet.Close();

            if (cnOrd.State == System.Data.ConnectionState.Open)
                cnOrd.Close();

        }

        public static bool existeOrdenSinFacturar(PrecioDTO precio)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo_detalle det, ofc_orden_de_trabajo ord, ofc_cliente cli";
            sql = sql + " where ord.id = det.id_orden_de_trabajo";
            sql = sql + " and cli.id = ord.id_cliente";
            sql = sql + " and det.id_producto = @idProducto";
            sql = sql + " and det.id_servicio = @idServicio";
            sql = sql + " and cli.id_lista_precio = @idListaDePrecio";
            sql = sql + " and cli.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProducto", precio.Id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", precio.Id_servicio));
            parameters.Add(new NpgsqlParameter("idListaDePrecio", precio.Id_lista_precio));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static List<long> obtenerOrdenTemp()
        {
            List<long> lista = new List<long>();
            long idOrden = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select ord.id id_orden";
            sql = sql + " from ofc_comprobante_temp c_temp, ofc_orden_de_trabajo ord";
            sql = sql + " where c_temp.id_origen = ord.id";
            sql = sql + " and c_temp.comprobante = 'ORDENES'";
            sql = sql + " order by 1";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                idOrden = long.Parse(data["id_orden"].ToString());
                lista.Add(idOrden);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }


    }
}

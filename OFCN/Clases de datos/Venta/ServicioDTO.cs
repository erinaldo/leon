using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ServicioDTO
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

        char es_adicional;

        public char Es_adicional
        {
            get { return es_adicional; }
            set { es_adicional = value; }
        }

        char vigente;

        public char Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        #region Constructor

        public ServicioDTO()
        {
            id = -1;
            descripcion = "";
            es_adicional = 'N';
            vigente = 'N';
        }

        #endregion


        public static IList<ServicioDTO> obtenerServicioAdicional()
        {

            IList<ServicioDTO> lista = new BindingList<ServicioDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, descripcion";
            sql = sql + " from ofc_servicio";
            sql = sql + " where vigente = 'S'";
            sql = sql + " and es_adicional = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ServicioDTO e = new ServicioDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ServicioDTO> obtenerServicio()
        {

            IList<ServicioDTO> lista = new BindingList<ServicioDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, descripcion";
            sql = sql + " from ofc_servicio";
            sql = sql + " where vigente = 'S'";
            sql = sql + " and es_adicional = 'N'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn); 

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ServicioDTO e = new ServicioDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ServicioDTO> obtenerServicioTotal()
        {

            IList<ServicioDTO> lista = new BindingList<ServicioDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, descripcion";
            sql = sql + " from ofc_servicio";
            sql = sql + " where vigente = 'S'";
            sql = sql + " order by 1";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ServicioDTO e = new ServicioDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ServicioDTO> obtenerServicioTotal2()
        {

            IList<ServicioDTO> lista = new BindingList<ServicioDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct id, descripcion";
            sql = sql + " from ofc_servicio";
            sql = sql + " order by 1";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ServicioDTO e = new ServicioDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }


        public static IList<ServicioDTO> obtenerServicios(string descripcion)
        {

            IList<ServicioDTO> lista = new BindingList<ServicioDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, descripcion, es_adicional, vigente";
            sql = sql + " from ofc_servicio";
            sql = sql + " where 1 = 1";

            if (descripcion != string.Empty)
            {
                sql = sql + " and descripcion = @descripcion";
            }
            sql = sql + " order by 2";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ServicioDTO e = new ServicioDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                e.es_adicional = char.Parse(data["es_adicional"].ToString());
                e.vigente = char.Parse(data["vigente"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static void insertarServicio(ServicioDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "insert into ofc_servicio (id, descripcion, es_adicional, vigente)"
            + " values(nextval('ofc_servicio_id_seq'),@descripcion,@es_adicional,@vigente);";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("es_adicional", data.es_adicional));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void actualizarServicio(ServicioDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_servicio set vigente = @vigente where id = @id;";

            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("id", data.id));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static long buscarId(string descripcion)
        {
            long idServ = -1;

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id";
            sql = sql + " from ofc_servicio";
            sql = sql + " where descripcion = @descripcion";

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                idServ = long.Parse(data["id"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idServ;
        }

        public static bool borrarServicio(long idServicio)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_servicio where id = @id";

            parameters.Add(new NpgsqlParameter("id", idServicio));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_precio where id_servicio = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return true;
        }

        public static bool tieneComprobanteAsociado(long idServicio)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //en ordenes
            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo_detalle where id_servicio = @idServicio";
            parameters.Add(new NpgsqlParameter("idServicio", idServicio));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en facturas
            sql = "select count(1) as cantidad from ofc_factura_detalle where id_servicio = @idServicio";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class TablaDTO
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string tabla;

        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        public TablaDTO()
        {
            id = string.Empty;
            tabla = string.Empty;
        }

        public static string obtenerID(string descripcion)
        {
            string id_tabla = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id from ofc_tabla where tabla = @descripcion";
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                id_tabla = data["id"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return id_tabla;
        }

        public static bool existeValor(string id)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_tabla_valor where id_tabla = @id";
            parameters.Add(new NpgsqlParameter("id", id));

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
        
        public static bool existeTabla(string id)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_tabla where id = @id";
            parameters.Add(new NpgsqlParameter("id", id));

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


        public static IList<TablaDTO> obtenerTodasLasTablas()
        {

            IList<TablaDTO> lista = new BindingList<TablaDTO>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select tabla, id";
            sql = sql + " from ofc_tabla";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                TablaDTO e = new TablaDTO();
                e.id = data["id"].ToString();
                e.tabla = data["tabla"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<TablaDTO> obtenerTablas(string descripcion)
        {
            IList<TablaDTO> lista = new BindingList<TablaDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select tabla, id";
            sql = sql + " from ofc_tabla";

            if (descripcion != string.Empty)
            {
                sql = sql + " where tabla like @descripcion";
            }

            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                TablaDTO e = new TablaDTO();
                e.id = data["id"].ToString();
                e.tabla = data["tabla"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static void insert(TablaDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO ofc_tabla(id, tabla) VALUES (@id, @tabla);";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("tabla", data.tabla));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void delete(TablaDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "DELETE FROM ofc_tabla where id = @id;";

            parameters.Add(new NpgsqlParameter("id", data.id));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void update(TablaDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE ofc_tabla SET tabla=@tabla where id = @id;";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("tabla", data.tabla));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
               
    }
}

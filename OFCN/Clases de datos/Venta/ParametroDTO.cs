using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ParametroDTO
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

        long parametro_1;

        public long Parametro_1
        {
            get { return parametro_1; }
            set { parametro_1 = value; }
        }

        long parametro_2;

        public long Parametro_2
        {
            get { return parametro_2; }
            set { parametro_2 = value; }
        }

        string parametro_3;

        public string Parametro_3
        {
            get { return parametro_3; }
            set { parametro_3 = value; }
        }

        public ParametroDTO()
        {
            id = -1;
            descripcion = string.Empty;
            parametro_1 = -1;
            parametro_2 = -1;
            parametro_3 = string.Empty;
        }

        public static long obtenerParametroI(string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long param = -1;

            string sql = "select parametro_1 from ofc_parametro where descripcion = @descripcionParam";

            parameters.Add(new NpgsqlParameter("descripcionParam", valor));

            NpgsqlDataReader dataParam = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataParam != null && dataParam.Read())
            {
                param = int.Parse(dataParam["parametro_1"].ToString());
                dataParam.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return param;
        }

        public static long obtenerParametroII(string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long param = -1;

            string sql = "select parametro_2 from ofc_parametro where descripcion = @descripcionParam";

            parameters.Add(new NpgsqlParameter("descripcionParam", valor));

            NpgsqlDataReader dataParam = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataParam != null && dataParam.Read())
            {
                param = int.Parse(dataParam["parametro_2"].ToString());
                dataParam.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return param;
        }

        public static void actualizarParamII(string descripcion, long valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = " update ofc_parametro"
                + " set parametro_2 = @valor"
                + " where descripcion = @descripcion";

            parameters.Add(new NpgsqlParameter("valor", valor));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static string obtenerParametroIII(string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string param = string.Empty;

            string sql = "select parametro_3 from ofc_parametro where descripcion = @descripcionParam";

            parameters.Add(new NpgsqlParameter("descripcionParam", valor));

            NpgsqlDataReader dataParam = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataParam != null && dataParam.Read())
            {
                param = dataParam["parametro_3"].ToString();
                dataParam.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return param;
        }

        public static void insert(ParametroDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO ofc_parametro(id, descripcion, parametro_1, parametro_2, parametro_3) VALUES (nextval('ofc_parametro_id_seq'), @descripcion, @parametro_1, @parametro_2, @parametro_3);";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("parametro_1", data.parametro_1));
            parameters.Add(new NpgsqlParameter("parametro_2", data.parametro_2));
            parameters.Add(new NpgsqlParameter("parametro_3", data.parametro_3));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void delete(string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "DELETE FROM ofc_parametro where descripcion = @valor;";

            parameters.Add(new NpgsqlParameter("valor", valor));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void update(ParametroDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE ofc_parametro set parametro_1 = @parametro_1, parametro_2 = @parametro_2, parametro_3 = @parametro_3 where descripcion = @descripcion;";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("parametro_1", data.parametro_1));
            parameters.Add(new NpgsqlParameter("parametro_2", data.parametro_2));
            parameters.Add(new NpgsqlParameter("parametro_3", data.parametro_3));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<ParametroDTO> obtenerParametros(string valor)
        {
            List<ParametroDTO> lista = new List<ParametroDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id, descripcion, parametro_1, parametro_2, parametro_3 from ofc_parametro";

            if (valor != string.Empty)
            {
                sql += " where descripcion = @descripcionParam";
            }

            sql += " order by descripcion";

            parameters.Add(new NpgsqlParameter("descripcionParam", valor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ParametroDTO e = new ParametroDTO();
                e.id = long.Parse(data["id"].ToString());
                e.descripcion = data["descripcion"].ToString();
                if (data["parametro_1"] != null && data["parametro_1"] != DBNull.Value)
                    e.parametro_1 = long.Parse(data["parametro_1"].ToString());
                if (data["parametro_2"] != null && data["parametro_2"] != DBNull.Value)
                    e.parametro_2 = long.Parse(data["parametro_2"].ToString());
                if (data["parametro_3"] != null && data["parametro_3"] != DBNull.Value)
                    e.parametro_3 = data["parametro_3"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<ParametroDTO> obtenerParametros()
        {
            List<ParametroDTO> lista = new List<ParametroDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id, descripcion from ofc_parametro order by descripcion";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                ParametroDTO e = new ParametroDTO();
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

        public static bool existeParametro(string valor)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_parametro where descripcion = @valor";
            parameters.Add(new NpgsqlParameter("valor", valor));

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



    }
}

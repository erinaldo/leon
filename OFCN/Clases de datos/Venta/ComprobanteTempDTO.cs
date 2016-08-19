using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ComprobanteTempDTO
    {
        string comprobante;

        public string Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }

        long id_origen;

        public long Id_origen
        {
            get { return id_origen; }
            set { id_origen = value; }
        }

        public ComprobanteTempDTO()
        {
            comprobante = "";
            id_origen = -1;
        }

        //feb 1.9.1
        public static void insertarTemporal(ComprobanteTempDTO data, decimal descuento)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            long idUnicoComprobante = -1;
            string sql = "select nextval('ofc_comprobante_id_unico_seq') idUnicoComprobante";
            //nuevo id unico de comprobante
            NpgsqlDataReader dataR = BaseDeDatos.ejecutarQuery(sql, cn);

            if (dataR != null && dataR.Read())
            {
                idUnicoComprobante = long.Parse(dataR["idUnicoComprobante"].ToString());
                dataR.Close();
            }

            sql = "insert into ofc_comprobante_temp(comprobante, id_origen, usuario, id_unico, porcentaje_bonificacion)"
            + " values(@comprobante, @id_origen, @usuario, @id_unico, @descuento);";

            parameters.Add(new NpgsqlParameter("comprobante", data.comprobante));
            parameters.Add(new NpgsqlParameter("id_origen", data.id_origen));
            parameters.Add(new NpgsqlParameter("id_unico", idUnicoComprobante));
            parameters.Add(new NpgsqlParameter("descuento", descuento));
            parameters.Add(new NpgsqlParameter("usuario", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static bool existeInstancia(string tipo, string login)
        {
            int count = 0;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante_temp comp where comp.comprobante = @tipo and comp.usuario <> @login";
            parameters.Add(new NpgsqlParameter("tipo", tipo));
            parameters.Add(new NpgsqlParameter("login", login));

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

        public static void borrarComprobanteTemp(string tipo, long id)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_comprobante_temp where comprobante = @tipo and id_origen = @id";

            parameters.Add(new NpgsqlParameter("tipo", tipo));
            parameters.Add(new NpgsqlParameter("id", id));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void borrarComprobanteTemp(string tipo)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_comprobante_temp where comprobante = @tipo";

            parameters.Add(new NpgsqlParameter("tipo", tipo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void borrarComprobanteTemp()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_comprobante_temp";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters); //al pedo los parametros, pero no tenia ganas de sobrecargar el metodo nonquery

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.9.1
        public static decimal obtenerDescuento(long id_origen, string comprobante)
        {
            decimal descuento = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select porcentaje_bonificacion descuento";
            sql = sql + " from ofc_comprobante_temp";
            sql = sql + " where id_origen = @id_origen";
            sql = sql + " and comprobante = @comprobante";

            parameters.Add(new NpgsqlParameter("id_origen", id_origen));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["descuento"] != null && data["descuento"] != DBNull.Value)
                {
                    descuento = decimal.Parse(data["descuento"].ToString());
                    data.Close();
                }
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return descuento;
        }

        //feb 1.9.2
        public static long obtenerIdUnico(long id_origen, string comprobante)
        {
            long idUnico = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id_unico idUnico";
            sql = sql + " from ofc_comprobante_temp";
            sql = sql + " where id_origen = @id_origen";
            sql = sql + " and comprobante = @comprobante";

            parameters.Add(new NpgsqlParameter("id_origen", id_origen));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["idUnico"] != null && data["idUnico"] != DBNull.Value)
                {
                    idUnico = long.Parse(data["idUnico"].ToString());
                    data.Close();
                }
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idUnico;
        }

        //feb 1.9.2
        public static decimal obtenerIdUnico(string comprobante)
        {
            long idUnico = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id_unico idUnico";
            sql = sql + " from ofc_comprobante_temp";
            sql = sql + " where comprobante = @comprobante";

            parameters.Add(new NpgsqlParameter("comprobante", comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["idUnico"] != null && data["idUnico"] != DBNull.Value)
                {
                    idUnico = long.Parse(data["idUnico"].ToString());
                    data.Close();
                }
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idUnico;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;
//feb 1.8
namespace OFC
{
    class TalonarioDetalleDTO
    {
        long id_talonario;

        public long Id_talonario
        {
            get { return id_talonario; }
            set { id_talonario = value; }
        }

        int numero_comprobante_1;

        public int Numero_comprobante_1
        {
            get { return numero_comprobante_1; }
            set { numero_comprobante_1 = value; }
        }

        long numero_comprobante_2;

        public long Numero_comprobante_2
        {
            get { return numero_comprobante_2; }
            set { numero_comprobante_2 = value; }
        }

        string numero_comprobante;

        public string Numero_comprobante
        {
            get { return numero_comprobante; }
            set { numero_comprobante = value; }
        }

        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        string usuario_creacion;

        public string Usuario_creacion
        {
            get { return usuario_creacion; }
            set { usuario_creacion = value; }
        }

        public TalonarioDetalleDTO()
        {
            id_talonario = -1;
            numero_comprobante_1 = -1;
            numero_comprobante_2 = -1;
            numero_comprobante = string.Empty;
            estado = "LIBRE";
            fecha_creacion = DateTime.Now;
            usuario_creacion = string.Empty;
        }

        public static void insertar(TalonarioDetalleDTO dataTalonarioDet)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero talonario
            string sql = "INSERT INTO ofc_talonario_detalle("
            + " id_talonario, numero_comprobante_1, numero_comprobante_2, numero_comprobante, estado, fecha_creacion, usuario_creacion)"
            + " VALUES (@id_talonario, @numero_comprobante_1, @numero_comprobante_2, @numero_comprobante, @estado, @fecha_creacion, @usuario_creacion);";

            parameters.Add(new NpgsqlParameter("id_talonario", dataTalonarioDet.id_talonario));
            parameters.Add(new NpgsqlParameter("numero_comprobante_1", dataTalonarioDet.numero_comprobante_1));
            parameters.Add(new NpgsqlParameter("numero_comprobante_2", dataTalonarioDet.numero_comprobante_2));
            parameters.Add(new NpgsqlParameter("numero_comprobante", dataTalonarioDet.numero_comprobante));
            parameters.Add(new NpgsqlParameter("estado", dataTalonarioDet.estado));
            parameters.Add(new NpgsqlParameter("fecha_creacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("usuario_creacion", string.Empty)); //a partir de la version 2.0 puede registrarse el usuario

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<TalonarioDetalleDTO> obtenerDetalle(string nro_talonario, string nro_comprobante)
        {
            List<TalonarioDetalleDTO> lista = new List<TalonarioDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id_talonario, numero_comprobante, estado";
            sql = sql + " from ofc_talonario_detalle";
            sql = sql + " where 1 = 1";

            if (nro_talonario != string.Empty)
            {
                sql = sql + " and id_talonario = @nro_talonario";
            }

            if (nro_comprobante != string.Empty)
            {
                sql = sql + " and numero_comprobante = @nro_comprobante";
            }

            sql = sql + " order by id_talonario, numero_comprobante_1, numero_comprobante_2";

            parameters.Add(new NpgsqlParameter("nro_talonario", nro_talonario));
            parameters.Add(new NpgsqlParameter("nro_comprobante", nro_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                TalonarioDetalleDTO e = new TalonarioDetalleDTO();

                e.id_talonario = long.Parse(data["id_talonario"].ToString());
                e.numero_comprobante = data["numero_comprobante"].ToString();
                e.estado = data["estado"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static bool existeRangoNumerico(long inicio, long fin)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_talonario_detalle where numero_comprobante_2 >= @inicio and numero_comprobante_2 <= @fin and numero_comprobante_1 = @numero_inicial";
            parameters.Add(new NpgsqlParameter("inicio", inicio));
            parameters.Add(new NpgsqlParameter("fin", fin));
            parameters.Add(new NpgsqlParameter("numero_inicial", ParametroDTO.obtenerParametroI("INICIO NRO RECIBO")));

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

        public static void actualizarEstado(string numero_comprobante, string estado)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // actualizar el precio
            string sql = "update ofc_talonario_detalle set estado = @estado where numero_comprobante = @numero_comprobante";

            parameters.Add(new NpgsqlParameter("estado", estado));
            parameters.Add(new NpgsqlParameter("numero_comprobante", numero_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static string getEstado(string codComprobante)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string dato = String.Empty;

            string sql = "select estado";
            sql = sql + " from ofc_talonario_detalle";
            sql = sql + " where numero_comprobante = @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                dato = data["estado"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return dato;

        }

        public static bool existeInventario(string codComprobante)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) cantidad";
            sql = sql + " from ofc_talonario_detalle";
            sql = sql + " where numero_comprobante = @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));

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

        public static string getTalonario(string codComprobante)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string dato = String.Empty;

            string sql = "select id_talonario";
            sql = sql + " from ofc_talonario_detalle";
            sql = sql + " where numero_comprobante = @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                dato = data["id_talonario"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return dato;

        }

    }
}

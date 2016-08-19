using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class CuentaDTO
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
        
        decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

	    string v_saldo;

        public string V_saldo
        {
            get { return v_saldo; }
            set { v_saldo = value; }
        }

        string jerarquia;

        public string Jerarquia
        {
            get { return jerarquia; }
            set { jerarquia = value; }
        }

        long id_cuenta_padre;

        public long Id_cuenta_padre
        {
            get { return id_cuenta_padre; }
            set { id_cuenta_padre = value; }
        }

        char activo;

        public char Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        DateTime fecha_actualizacion;

        public DateTime Fecha_actualizacion
        {
            get { return fecha_actualizacion; }
            set { fecha_actualizacion = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        public CuentaDTO()
        {
            id = -1;
            descripcion = string.Empty;
            saldo = Decimal.Zero;
            v_saldo = string.Empty;
            jerarquia = string.Empty;
            id_cuenta_padre = -1;
            activo = 'N';
            fecha_actualizacion = DateTime.Now;
            codigo = string.Empty;
        }

        public static List<CuentaDTO> obtenerCuentas()
        {
            List<CuentaDTO> lista = new List<CuentaDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select id, codigo, descripcion";
            sql = sql + " from con_cuenta";
            sql = sql + " where activo = 'S'";
            sql = sql + " order by codigo";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                CuentaDTO e = new CuentaDTO();

                e.id = long.Parse(data["id"].ToString());
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


        public static string obtenerCodigo(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string codigo = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select codigo";
            sql = sql + " from con_cuenta";
            sql = sql + " where id = @id and activo = 'S'";

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

        public static string obtenerDescripcion(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string codigo = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select descripcion";
            sql = sql + " from con_cuenta";
            sql = sql + " where id = @id and activo = 'S'";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codigo = data["descripcion"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return codigo;
        }

        public static void insertar(CuentaDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            
            // Insertamos la cuenta
            string sql = "insert into con_cuenta(id,descripcion,saldo,jerarquia,id_cuenta_padre,activo,fecha_actualizacion,codigo) "
            + " values(nextval('con_cuenta_id_seq'),@descripcion,@saldo,@jerarquia,@id_cuenta_padre,'S',@fecha_actualizacion,@codigo);";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("saldo", data.saldo));
            parameters.Add(new NpgsqlParameter("jerarquia", data.jerarquia));
            parameters.Add(new NpgsqlParameter("id_cuenta_padre", data.id_cuenta_padre));
            parameters.Add(new NpgsqlParameter("fecha_actualizacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void update(string codigo, decimal saldo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update con_cuenta set saldo = @saldo, fecha_actualizacion = @fecha"
            + " where codigo = @codigo and activo = 'S';";

            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
    }
}

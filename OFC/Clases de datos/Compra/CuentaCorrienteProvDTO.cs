using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class CuentaCorrienteProvDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        string id_proveedor;

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        //feb
        DateTime fecha_actualizacion;

        public DateTime Fecha_actualizacion
        {
            get { return fecha_actualizacion; }
            set { fecha_actualizacion = value; }
        }

        public CuentaCorrienteProvDTO()
        {
            id = -1;
            saldo = Decimal.Zero;
            id_proveedor = String.Empty;
        }

        //insertar cuenta corriente del proveedor.
        public static void insertar(string idProveedor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            decimal saldo = decimal.Zero;

            string sql = "insert into cpc_cuenta_corriente(id,saldo,id_proveedor,activo,fecha_actualizacion)"
            + " values(nextval('cpc_cuenta_corriente_id_seq'),@saldo,@idProveedor,'S',@fecha);";

            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("idProveedor", idProveedor));
            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now)); 

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void update(string idProveedor, decimal saldo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update cpc_cuenta_corriente set saldo = @saldo, fecha_actualizacion = @fecha"
            + " where id_proveedor = @idProveedor and activo = 'S';";

            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("idProveedor", idProveedor));
            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void borrar(string idProveedor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update cpc_cuenta_corriente set activo = 'N' where id_proveedor = @idProveedor"; //feb

            parameters.Add(new NpgsqlParameter("idProveedor", idProveedor));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<CuentaCorrienteProvDTO> obtenerDatosCuenta(FiltrosABMProveedor filtro)
        {

            List<CuentaCorrienteProvDTO> lista = new List<CuentaCorrienteProvDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select saldo, fecha_actualizacion";
            sql = sql + " from cpc_cuenta_corriente";
            sql = sql + " where activo = 'S'";

            if (filtro.FiltroCodigo != "")
            {
                sql = sql + " and upper(id_proveedor) like upper(@idProveedor)";
            }

            parameters.Add(new NpgsqlParameter("idProveedor", filtro.FiltroCodigo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo las cuentas                    
            while (data != null && data.Read())
            {
                CuentaCorrienteProvDTO e = new CuentaCorrienteProvDTO();

                e.saldo = decimal.Parse(data["saldo"].ToString()) * (-1);
                e.v_saldo = String.Format("{0:C}", Math.Round(e.saldo, 2, MidpointRounding.AwayFromZero));

                e.fecha_actualizacion = DateTime.Parse(data["fecha_actualizacion"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static decimal obtenerSaldo(string cod_proveedor)
        {

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            decimal saldo = decimal.Zero; 

            string sql = "select saldo";
            sql = sql + " from cpc_cuenta_corriente";
            sql = sql + " where id_proveedor = @cod_proveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo las cuentas                    
            while (data != null && data.Read())
            {
                saldo = decimal.Parse(data["saldo"].ToString()) * (-1);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return saldo;
        }

    }
}

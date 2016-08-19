using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class CuentaCorrienteDTO
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

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        //feb
        DateTime fecha_actualizacion;

        public DateTime Fecha_actualizacion
        {
            get { return fecha_actualizacion; }
            set { fecha_actualizacion = value; }
        }

        public CuentaCorrienteDTO()
        {
            id = -1;
            saldo = Decimal.Zero;
            id_cliente = String.Empty;
        }

        public static void insertar(string idCliente)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            decimal saldo = decimal.Zero;

            string sql = "insert into ofc_cuenta_corriente(id,saldo,id_cliente,activo,fecha_actualizacion)" 
            + " values(nextval('ofc_cuenta_corriente_id_seq'),@saldo,@idCliente,'S',@fecha);";

            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));
            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now)); 

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void update(string idCliente, decimal saldo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_cuenta_corriente set saldo = @saldo, fecha_actualizacion = @fecha"
            + " where id_cliente = @idCliente and activo = 'S';";

            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));
            parameters.Add(new NpgsqlParameter("fecha", DateTime.Now));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void borrar(string idCliente)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_cuenta_corriente set activo = 'N' where id_cliente = @idCliente"; //feb

            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb
        public static List<CuentaCorrienteDTO> obtenerDatosCuenta(FiltrosABMCliente filtro)
        {

            List<CuentaCorrienteDTO> lista = new List<CuentaCorrienteDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select saldo, fecha_actualizacion";
            sql = sql + " from ofc_cuenta_corriente";
            sql = sql + " where activo = 'S'";

            if (filtro.FiltroCodigo != "")
            {
                sql = sql + " and upper(id_cliente) like upper(@idCliente)";
            }

	        parameters.Add(new NpgsqlParameter("idCliente", filtro.FiltroCodigo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo las cuentas                    
            while (data != null && data.Read())
            {
                CuentaCorrienteDTO e = new CuentaCorrienteDTO();

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

        //feb 1.8
        public static String obtenerSaldoAPrincipioDeMes(string idCliente)
        {

            String v_saldo_principio_de_mes = "DATO NO REGISTRADO";

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select m.saldo * (-1) saldo" + //levanta el saldo del último movimiento del mes pasado.
                " from ofc_movimiento m, ofc_cuenta_corriente c, ofc_cliente cl" +
                " where c.id = m.id_cuenta_corriente" +
                " and cl.id = c.id_cliente" +
                " and c.activo = 'S'" +
                " and cl.activo = 'S'" +
                " and c.id_cliente = @idCliente" +
                " and m.id in (" +
                " select max(a.id) id" +
                " from ofc_movimiento a, ofc_tabla_valor v" +
                " where v.id = a.id_tipo_comprobante" +
                " and a.fecha < @fecha_principio_de_mes" +
                " group by a.id_cuenta_corriente)" +
                " union" + //levanta el saldo inicial de la cuenta en caso de que nunca se haya realizado un movimiento.
                " select cc.saldo * (-1) saldo" +
                " from ofc_cuenta_corriente cc, ofc_cliente cl" +
                " where cl.id = cc.id_cliente" +
                " and cl.activo = 'S'" +
                " and cc.activo = 'S'" +
                " and cc.id_cliente = @idCliente" +
                " and not exists (select 1 from ofc_movimiento a where a.id_cuenta_corriente = cc.id)" +
                " union" + //levanta el saldo inicial de la cuenta en caso de que no se haya realizado un movimientos antes de la fecha de comienzo de mes y exista el movimiento de ajuste inical de cuenta. ULTIMO PARCHE AGREGADO PARA NO PERDER ESTE DATO!
                " select m.saldo * (-1) saldo" +
                " from ofc_cuenta_corriente cc, ofc_cliente cl, ofc_movimiento m" +
                " where cl.id = cc.id_cliente" +
                " and cc.id = m.id_cuenta_corriente" +
                " and cl.activo = 'S'" +
                " and cc.activo = 'S'" +
                " and cc.id_cliente = @idCliente" +
                " and m.id in (select id from ofc_movimiento a where a.id_cuenta_corriente = cc.id and a.id_origen = -1)" +
                " and not exists (select 1 from ofc_movimiento a where a.id_cuenta_corriente = cc.id and a.id_origen != -1 and a.fecha < @fecha_principio_de_mes)";

            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            parameters.Add(new NpgsqlParameter("fecha_principio_de_mes", System.DateTime.Now.AddDays(dias_transcurridos + 1).Date));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo las cuentas                    
            while (data != null && data.Read())
            {
                Decimal saldo_principio_de_mes = decimal.Parse(data["saldo"].ToString());
                v_saldo_principio_de_mes = String.Format("{0:C}", Math.Round(saldo_principio_de_mes, 2, MidpointRounding.AwayFromZero));
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return v_saldo_principio_de_mes;
        }

        public static String obtenerSaldoAPrincipioDeMesProv(string idProveedor)
        {

            String v_saldo_principio_de_mes = "DATO NO REGISTRADO";

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select m.saldo saldo " +
                "from cpc_movimiento m, cpc_cuenta_corriente c, cpc_proveedor pr " +
                "where c.id = m.id_cuenta_corriente " +
                "and pr.id = c.id_proveedor " +
                "and c.activo = 'S' " +
                "and pr.activo = 'S' " +
                "and c.id_proveedor = @id_proveedor " +
                "and m.fecha_comprobante in ( " +
                "select max(a.fecha_comprobante) fecha " +
                "from cpc_movimiento a " +
                "where c.id = a.id_cuenta_corriente " +
                "and a.fecha_comprobante <= @fecha_principio_de_mes) " +
                "and m.id in ( " +
                "select max(a.id) id " +
                "from cpc_movimiento a " +
                "where c.id = a.id_cuenta_corriente " +
                "and a.fecha_comprobante = m.fecha_comprobante)";

            parameters.Add(new NpgsqlParameter("id_proveedor", idProveedor));

            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            parameters.Add(new NpgsqlParameter("fecha_principio_de_mes", System.DateTime.Now.AddDays(dias_transcurridos + 1).Date));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo las cuentas                    
            if (data != null && data.Read())
            {
                if (data["saldo"] != null && data["saldo"] != DBNull.Value)
                {
                    Decimal saldo_principio_de_mes = decimal.Parse(data["saldo"].ToString()) * (-1);
                    v_saldo_principio_de_mes = String.Format("{0:C}", Math.Round(saldo_principio_de_mes, 2, MidpointRounding.AwayFromZero));
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return v_saldo_principio_de_mes;
        }




    }
}

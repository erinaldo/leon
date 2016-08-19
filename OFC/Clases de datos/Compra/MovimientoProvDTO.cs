using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class MovimientoProvDTO
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

        string v_fecha;

        public string V_fecha
        {
            get { return v_fecha; }
            set { v_fecha = value; }
        }


        long id_origen;

        public long Id_origen
        {
            get { return id_origen; }
            set { id_origen = value; }
        }

        long id_cuenta_corriente;

        public long Id_cuenta_corriente
        {
            get { return id_cuenta_corriente; }
            set { id_cuenta_corriente = value; }
        }

        Decimal debe;

        public Decimal Debe
        {
            get { return debe; }
            set { debe = value; }
        }

        Decimal haber;

        public Decimal Haber
        {
            get { return haber; }
            set { haber = value; }
        }

        long id_tipo_comprobante;

        public long Id_tipo_comprobante
        {
            get { return id_tipo_comprobante; }
            set { id_tipo_comprobante = value; }
        }

        string comprobante;

        public string Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }

        

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        char pago;

        public char Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        string v_pago;

        public string V_pago
        {
            get { return v_pago; }
            set { v_pago = value; }
        }
        
        decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        string v_debe;

        public string V_debe
        {
            get { return v_debe; }
            set { v_debe = value; }
        }


        string v_haber;

        public string V_haber
        {
            get { return v_haber; }
            set { v_haber = value; }
        }


        string v_saldo;

        public string V_saldo
        {
            get { return v_saldo; }
            set { v_saldo = value; }
        }

        DateTime fecha_comprobante;

        public DateTime Fecha_comprobante
        {
            get { return fecha_comprobante; }
            set { fecha_comprobante = value; }
        }

        string v_fecha_comprobante;

        public string V_fecha_comprobante
        {
            get { return v_fecha_comprobante; }
            set { v_fecha_comprobante = value; }
        }

        public MovimientoProvDTO()
        {
            id = -1;
            fecha = DateTime.Now;
            id_origen = -1;
            id_cuenta_corriente = -1;
            debe = decimal.Zero;
            haber = decimal.Zero;
            id_tipo_comprobante = -1;
            comprobante = String.Empty;
            cod_comprobante = String.Empty;
            saldo = decimal.Zero;
            v_debe = String.Empty;
            v_haber = String.Empty;
            v_saldo = String.Empty;
            v_fecha = String.Empty;
            fecha_comprobante = DateTime.Now;
            v_fecha_comprobante = String.Empty;
        }

        public static void recalcularMovimientosPostComprobante(long idMovimiento, decimal saldo_inicial)
        {
            long id = -1;
            decimal debe = decimal.Zero;
            decimal haber = decimal.Zero;
            decimal saldo_base = saldo_inicial;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnUpdate = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //get movimientos post recibo
            string sql = "select id, debe, haber, saldo " +
                "from cpc_movimiento " + 
                "where id_cuenta_corriente in (select id_cuenta_corriente from cpc_movimiento where id = @idMovimiento) " +
                "and fecha_comprobante > (select fecha_comprobante from cpc_movimiento where id = @idMovimiento) " +
                "order by fecha_comprobante, id";

            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                parameters.Clear();

                id = long.Parse(data["id"].ToString());
                debe = decimal.Parse(data["debe"].ToString());
                haber = decimal.Parse(data["haber"].ToString());

                if (debe != decimal.Zero)
                {
                    saldo_base = saldo_base - debe;
                }

                if (haber != decimal.Zero)
                {
                    saldo_base = saldo_base + haber;
                }

                sql = "update cpc_movimiento set saldo = @saldo where id = @id";

                parameters.Add(new NpgsqlParameter("saldo", saldo_base));
                parameters.Add(new NpgsqlParameter("id", id));
                BaseDeDatos.ejecutarNonQuery(sql, cnUpdate, parameters);
            }

            if (data != null)
                data.Close();

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id in (select id_cuenta_corriente from cpc_movimiento where id = @idMovimiento)";

            parameters.Add(new NpgsqlParameter("saldo", saldo_base));
            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));
            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnUpdate.State == System.Data.ConnectionState.Open)
                cnUpdate.Close();

        }


        public static decimal getSaldoBase(DateTime fecha_comprobante, string id_proveedor)
        {
            decimal saldo_base = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

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
                "and a.fecha_comprobante <= @fecha_comprobante) " +
                "and m.id in ( " +
                "select max(a.id) id " +
                "from cpc_movimiento a " +
                "where c.id = a.id_cuenta_corriente " +
                "and a.fecha_comprobante = m.fecha_comprobante)";

            parameters.Add(new NpgsqlParameter("fecha_comprobante", fecha_comprobante));
            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["saldo"] != null && data["saldo"] != DBNull.Value)
                {
                    saldo_base = decimal.Parse(data["saldo"].ToString());
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return saldo_base;
        }


        public static long generarFactura(FacturaDeCompraDTO dataFact, decimal saldo_base)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            long idMovimiento = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = saldo_base;

            //conexión
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //nuevo id de movimiento
            string sql = "select nextval('cpc_movimiento_id_seq') idMovimiento";
            
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idMovimiento = long.Parse(data["idMovimiento"].ToString());
                data.Close();
            }

            //obtener id cuenta
            sql = "select id from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataFact.Id_proveedor));

            NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data2 != null && data2.Read())
            {
                idCuenta = long.Parse(data2["id"].ToString());
                data2.Close();
            }

            debe = decimal.Zero;
            haber = dataFact.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("FACTURA " + dataFact.Tipo_factura.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (@idMovimiento, @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));
            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataFact.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataFact.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idMovimiento;
        }

        public static void generarFactura(FacturaDeCompraDTO dataFact)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataFact.Id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            debe = decimal.Zero;
            haber = dataFact.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("FACTURA " + dataFact.Tipo_factura.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (nextval('cpc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataFact.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataFact.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static long generarNotaDeCredito(NotaDeCreditoDeCompraDTO dataCred, decimal saldo_base)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            long idMovimiento = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = saldo_base;

            //conexión
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //nuevo id de movimiento
            string sql = "select nextval('cpc_movimiento_id_seq') idMovimiento";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idMovimiento = long.Parse(data["idMovimiento"].ToString());
                data.Close();
            }

            //obtener id cuenta
            sql = "select id from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataCred.Id_proveedor));

            NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data2 != null && data2.Read())
            {
                idCuenta = long.Parse(data2["id"].ToString());
                data2.Close();
            }

            debe = dataCred.Total;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO " + dataCred.Tipo_nota_credito.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (@idMovimiento, @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante, @codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));
            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataCred.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataCred.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataCred.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idMovimiento;
        }

        public static void generarNotaDeCredito(NotaDeCreditoDeCompraDTO dataCred)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataCred.Id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            debe = dataCred.Total;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO " + dataCred.Tipo_nota_credito.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (nextval('cpc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataCred.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataCred.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataCred.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static long generarNotaDeDebito(NotaDeDebitoDeCompraDTO dataDeb, decimal saldo_base)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            long idMovimiento = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = saldo_base;

            //conexión
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //nuevo id de movimiento
            string sql = "select nextval('cpc_movimiento_id_seq') idMovimiento";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idMovimiento = long.Parse(data["idMovimiento"].ToString());
                data.Close();
            }

            //obtener id cuenta
            sql = "select id from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataDeb.Id_proveedor));

            NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data2 != null && data2.Read())
            {
                idCuenta = long.Parse(data2["id"].ToString());
                data2.Close();
            }

            debe = decimal.Zero;
            haber = dataDeb.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO " + dataDeb.Tipo_nota_debito.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (@idMovimiento, @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante, @codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));
            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataDeb.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataDeb.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataDeb.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idMovimiento;
        }

        public static void generarNotaDeDebito(NotaDeDebitoDeCompraDTO dataDeb)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataDeb.Id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            debe = decimal.Zero;
            haber = dataDeb.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO " + dataDeb.Tipo_nota_debito.ToString());

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (nextval('cpc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataDeb.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", dataDeb.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataDeb.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }


        public static void generarAjusteInicial(string idProveedor, decimal importe, DateTime fecha_movimiento)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select a.id id, a.saldo saldo from cpc_cuenta_corriente a where a.id_proveedor = @idProveedor and a.activo = 'S' and not exists (select 1 from cpc_movimiento m where m.id_cuenta_corriente = a.id)";

            parameters.Add(new NpgsqlParameter("idProveedor", idProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }
            else
            {
                throw new Exception("Ya se ha generado al menos un movimiento sobre la cuenta corriente del proveedor. No es posible la inicialización del saldo de la cuenta bajo la actual condición.");
            }

            if (importe >= 0)
            {
                debe = importe;
                haber = decimal.Zero;
                saldo = saldo - debe;
                saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                debe = decimal.Zero;
                haber = importe;
                saldo = saldo + haber;
                saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);
            }

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("AJUSTE DE SALDO INICIAL");

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (nextval('cpc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante, @codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("fechaHoy", fecha_movimiento));
            parameters.Add(new NpgsqlParameter("idOrigen", -1));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", ""));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", fecha_movimiento));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static long generarPago(PagoDTO dataPago, string cod_comprobante_pago, decimal saldo_base)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            long idMovimiento = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = saldo_base;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //nuevo id de movimiento
            string sql = "select nextval('cpc_movimiento_id_seq') idMovimiento";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idMovimiento = long.Parse(data["idMovimiento"].ToString());
                data.Close();
            }

            //obtener id cuenta y saldo actual
            sql = "select id from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataPago.Id_proveedor));

            NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data2 != null && data2.Read())
            {
                idCuenta = long.Parse(data2["id"].ToString());
                data2.Close();
            }

            debe = dataPago.Importe;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("ORDEN DE PAGO");

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (@idMovimiento, @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante, @codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("idMovimiento", idMovimiento));
            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataPago.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante_pago));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataPago.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idMovimiento;
        }

        public static void generarPago(PagoDTO dataPago, string cod_comprobante_pago)
        {
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from cpc_cuenta_corriente where id_proveedor = @idProveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idProveedor", dataPago.Id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            debe = dataPago.Importe;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("ORDEN DE PAGO");

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO cpc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo, fecha_comprobante)"
            + " VALUES (nextval('cpc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante, @codComprobante, @saldo, @fechaComprobante);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataPago.Id));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante_pago));
            parameters.Add(new NpgsqlParameter("saldo", saldo));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataPago.Fecha_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update cpc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<MovimientoProvDTO> obtenerMovimientos(FiltrosABMProveedor filtro)
        {

            List<MovimientoProvDTO> lista = new List<MovimientoProvDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.fecha fecha, v.valor comprobante, a.cod_comprobante codComprobante, a.debe debe, a.haber haber, a.saldo saldo, a.pago pago, a.fecha_comprobante fecha_comprobante";
            sql = sql + " from cpc_movimiento a, ofc_tabla_valor v, cpc_cuenta_corriente c";
            sql = sql + " where c.id = a.id_cuenta_corriente";
            sql = sql + " and v.id = a.id_tipo_comprobante";
            sql = sql + " and c.activo = 'S'";
            sql = sql + " and upper(c.id_proveedor) like upper(@id_proveedor)";
            sql = sql + " and a.fecha_comprobante >= @fechaDesde";
            sql = sql + " and a.fecha_comprobante <= @fechaHasta";
            sql = sql + " order by a.fecha_comprobante, a.id";

            parameters.Add(new NpgsqlParameter("id_proveedor", filtro.FiltroCodigo));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                MovimientoProvDTO e = new MovimientoProvDTO();

                e.fecha = DateTime.Parse(data["fecha"].ToString());
                e.v_fecha = String.Format("{0:d/M/yyyy HH:mm:ss}", e.fecha);

                e.comprobante = data["comprobante"].ToString();
                e.cod_comprobante = data["codComprobante"].ToString();

                e.debe = decimal.Parse(data["debe"].ToString());
                e.v_debe = String.Format("{0:C}", Math.Round(e.debe, 2, MidpointRounding.AwayFromZero));

                e.haber = decimal.Parse(data["haber"].ToString());
                e.v_haber = String.Format("{0:C}", Math.Round(e.haber, 2, MidpointRounding.AwayFromZero));

                e.saldo = decimal.Parse(data["saldo"].ToString()) * (-1);
                e.v_saldo = String.Format("{0:C}", Math.Round(e.saldo, 2, MidpointRounding.AwayFromZero));

                e.fecha_comprobante = DateTime.Parse(data["fecha_comprobante"].ToString());
                e.v_fecha_comprobante = String.Format("{0:d/M/yyyy}", e.fecha_comprobante);

                if (data["pago"] != null && data["pago"] != DBNull.Value)
                {
                    e.pago = char.Parse(data["pago"].ToString());
                    if (e.pago == 'C')
                    {
                        e.v_pago = "CREDITO";
                    }
                    if (e.pago == 'O')
                    {
                        e.v_pago = "PAGO";
                    }
                    if (e.pago == 'P')
                    {
                        e.v_pago = "PAGO PARCIAL";
                    }
                }

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }



    }
}

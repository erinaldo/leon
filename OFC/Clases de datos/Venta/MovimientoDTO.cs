using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class MovimientoDTO
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

        public MovimientoDTO()
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
        }

        public static void generarRecibo(ReciboDTO dataRecibo)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataRecibo.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataRecibo.Id;
            debe = decimal.Zero;
            haber = dataRecibo.Importe;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("RECIBO");

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void cancelarFactura(long idTipoComprobante, string cod_comprobante_factura)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            parameters.Add(new NpgsqlParameter("codComprobanteFactura", cod_comprobante_factura));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", idTipoComprobante));

            string sql = "update ofc_movimiento set pago = 'C' where cod_comprobante = @codComprobanteFactura and id_tipo_comprobante = @id_tipo_comprobante";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "update ofc_factura set pago = 'S' where id in (select id_origen from ofc_comprobante where cod_comprobante = @codComprobanteFactura and id_tipo_comprobante = @id_tipo_comprobante)";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void recuperarCancelarFactura(long idTipoComprobante, string cod_comprobante_factura)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter("codComprobanteFactura", cod_comprobante_factura));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", idTipoComprobante));

            string sql = "update ofc_movimiento set pago = null where cod_comprobante = @codComprobanteFactura and id_tipo_comprobante = @id_tipo_comprobante";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "update ofc_factura set pago = 'N' where id in (select id_origen from ofc_comprobante where cod_comprobante = @codComprobanteFactura and id_tipo_comprobante = @id_tipo_comprobante)";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
        
        public static void generarNotaDeDebito(NotaDebitoDTO dataDebito)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataDebito.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataDebito.Id;
            debe = dataDebito.Total;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataDebito.Tipo_nota_debito == 'A')
            {
                tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO A");
            }

            if (dataDebito.Tipo_nota_debito == 'B')
            {
                tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void generarNotaDeCredito(NotaCreditoDTO dataCredito)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataCredito.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataCredito.Id;
            debe = decimal.Zero;
            haber = dataCredito.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataCredito.Tipo_nota_credito == 'A')
            {
                tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO A");
            }

            if (dataCredito.Tipo_nota_credito == 'B')
            {
                tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }



        public static void generarFactura(FacturaDTO dataFact)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataFact.Id;
            debe = dataFact.Total;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataFact.Tipo_factura == 'A')
            {
                tipoComprobante = ValorDTO.obtenerId("FACTURA A");
            }

            if (dataFact.Tipo_factura == 'B')
            {
                tipoComprobante = ValorDTO.obtenerId("FACTURA B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void generarAnulaDebito(NotaDebitoDTO dataDebito)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long tipoComprobanteAn = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataDebito.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataDebito.Id;
            debe = decimal.Zero;
            haber = dataDebito.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataDebito.Tipo_nota_debito == 'A')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. NOTA DE DEBITO A");
                tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO A");
            }

            if (dataDebito.Tipo_nota_debito == 'B')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. NOTA DE DEBITO B");
                tipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobanteAn));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void generarAnulaCredito(NotaCreditoDTO dataCredito)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long tipoComprobanteAn = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataCredito.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataCredito.Id;
            debe = dataCredito.Total;
            haber = decimal.Zero;
            saldo = saldo - debe;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataCredito.Tipo_nota_credito == 'A')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. NOTA DE CREDITO A");
                tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO A");
            }

            if (dataCredito.Tipo_nota_credito == 'B')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. NOTA DE CREDITO B");
                tipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobanteAn));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void generarAnulaFactura(FacturaDTO dataFact)
        {
            long idOrigen = -1;
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long tipoComprobanteAn = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;
            Decimal saldo = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id, saldo from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                saldo = decimal.Parse(data["saldo"].ToString());
                data.Close();
            }

            idOrigen = dataFact.Id;
            debe = decimal.Zero;
            haber = dataFact.Total;
            saldo = saldo + haber;
            saldo = decimal.Round(saldo, 2, MidpointRounding.AwayFromZero);

            //obtener id de comprobante
            if (dataFact.Tipo_factura == 'A')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. FACTURA A");
                tipoComprobante = ValorDTO.obtenerId("FACTURA A");
            }

            if (dataFact.Tipo_factura == 'B')
            {
                tipoComprobanteAn = ValorDTO.obtenerId("AN. FACTURA B");
                tipoComprobante = ValorDTO.obtenerId("FACTURA B");
            }

            //obtener cod de comprobante
            sql = "select cod_comprobante codComprobante from ofc_comprobante where id_origen = @idOrigen and id_tipo_comprobante = @tipoComprobante";

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                codComprobante = data["codComprobante"].ToString();
                data.Close();
            }

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobanteAn));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<MovimientoDTO> obtenerMovimientos(FiltrosABMCliente filtro)
        {

            List<MovimientoDTO> lista = new List<MovimientoDTO>(); 
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.fecha fecha, v.valor comprobante, a.cod_comprobante codComprobante, a.debe debe, a.haber haber, a.saldo saldo, a.pago pago";
            sql = sql + " from ofc_movimiento a, ofc_tabla_valor v, ofc_cuenta_corriente c";
            sql = sql + " where c.id = a.id_cuenta_corriente";
            sql = sql + " and v.id = a.id_tipo_comprobante";
            sql = sql + " and c.activo = 'S'";
            sql = sql + " and upper(c.id_cliente) like upper(@id_cliente)";

            if (filtro.FiltroCodComprobanteFact != "XXXXXXXX" && filtro.FiltroCodComprobanteFact != "")
            {
                sql = sql + " and a.cod_comprobante like @cod_comprobante";
            }

            sql = sql + " and a.fecha >= @fechaDesde";
            sql = sql + " and a.fecha <= @fechaHasta";
            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodigo + "%"));
            parameters.Add(new NpgsqlParameter("cod_comprobante", filtro.FiltroCodComprobanteFact));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
       
            while (data != null && data.Read())
            {
                MovimientoDTO e = new MovimientoDTO();

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

                if (data["pago"] != null && data["pago"] != DBNull.Value)
                {
                    e.pago = char.Parse(data["pago"].ToString());
                    if (e.pago == 'C')
                    {
                        e.v_pago = "CREDITO";
                    }
                    if (e.pago == 'R')
                    {
                        e.v_pago = "RECIBO";
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

        //feb 1.8
        public static void cancelarFacturaDebito(string cod_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id_tipo_comprobante idTipoComprobante, v.valor tipoComprobante, c.id_origen idOrigen";
            sql = sql + " from ofc_comprobante c, ofc_tabla_valor v";
            sql = sql + " where c.id_tipo_comprobante = v.id";
            sql = sql + " and c.cod_comprobante = @codComprobante and c.anulado != 'S'";

            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                long id_tipo_comprobante = long.Parse(data["idTipoComprobante"].ToString());
                string tipo_comprobante = data["tipoComprobante"].ToString();
                long id_origen = long.Parse(data["idOrigen"].ToString());

                NpgsqlConnection cn2 = BaseDeDatos.obtenerConexion();
                parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
                parameters.Add(new NpgsqlParameter("id_origen", id_origen));

                sql = "update ofc_movimiento set pago = 'C' where cod_comprobante = @codComprobante and id_tipo_comprobante = @id_tipo_comprobante and id_origen = @id_origen";
                BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);

                if (tipo_comprobante.IndexOf("FACTURA") != -1)
                {
                    sql = "update ofc_factura set pago = 'S' where id = @id_origen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);
                }

                if (tipo_comprobante.IndexOf("NOTA DE DEBITO") != -1)
                {
                    sql = "update ofc_nota_debito set pago = 'S' where id = @id_origen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);
                }

                if (cn2.State == System.Data.ConnectionState.Open)
                    cn2.Close();

                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        //feb 1.8
        public static void recuperarCancelarFacturaDebito(string cod_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id_tipo_comprobante idTipoComprobante, v.valor tipoComprobante, c.id_origen idOrigen";
            sql = sql + " from ofc_comprobante c, ofc_tabla_valor v";
            sql = sql + " where c.id_tipo_comprobante = v.id";
            sql = sql + " and c.cod_comprobante = @codComprobante and c.anulado != 'S'";

            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                long id_tipo_comprobante = long.Parse(data["idTipoComprobante"].ToString());
                string tipo_comprobante = data["tipoComprobante"].ToString();
                long id_origen = long.Parse(data["idOrigen"].ToString());

                NpgsqlConnection cn2 = BaseDeDatos.obtenerConexion();
                parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
                parameters.Add(new NpgsqlParameter("id_origen", id_origen));

                sql = "update ofc_movimiento set pago = null where cod_comprobante = @codComprobante and id_tipo_comprobante = @id_tipo_comprobante and id_origen = @id_origen";
                BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);

                if (tipo_comprobante.IndexOf("FACTURA") != -1)
                {
                    sql = "update ofc_factura set pago = 'N' where id = @id_origen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);
                }

                if (tipo_comprobante.IndexOf("NOTA DE DEBITO") != -1)
                {
                    sql = "update ofc_nota_debito set pago = 'N' where id = @id_origen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn2, parameters);
                }

                if (cn2.State == System.Data.ConnectionState.Open)
                    cn2.Close();

                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.8
        public static void generarAjusteSaldoInicial(string idCliente, decimal saldo)
        {
            string codComprobante = string.Empty;
            long tipoComprobante = -1;
            long idCuenta = -1;
            Decimal debe = decimal.Zero;
            Decimal haber = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id cuenta y salda actual
            string sql = "select id from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id"].ToString());
                data.Close();
            }

            if (saldo > 0)
            {
                debe = saldo;
                haber = decimal.Zero;
            }
            if (saldo < 0)
            {
                debe = decimal.Zero;
                haber = saldo * (-1);
            }

            //obtener id de comprobante
            tipoComprobante = ValorDTO.obtenerId("AJUSTE DE SALDO INICIAL");

            //genero movimiento de cuenta corriente
            sql = "INSERT INTO ofc_movimiento("
            + "id, fecha, id_origen, id_cuenta_corriente, debe, haber, id_tipo_comprobante, cod_comprobante, saldo)"
            + " VALUES (nextval('ofc_movimiento_id_seq'), @fechaHoy, @idOrigen,"
            + " @idCuenta, @debe, @haber, @tipoComprobante,@codComprobante, @saldo);";

            parameters.Add(new NpgsqlParameter("fechaHoy", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));
            parameters.Add(new NpgsqlParameter("debe", debe));
            parameters.Add(new NpgsqlParameter("haber", haber));
            parameters.Add(new NpgsqlParameter("tipoComprobante", tipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));
            parameters.Add(new NpgsqlParameter("saldo", saldo * (-1)));
            parameters.Add(new NpgsqlParameter("idOrigen", -1));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente"
            + " set saldo = @saldo, fecha_actualizacion = @fechaHoy"  //feb
            + " where id = @idCuenta and activo = 'S'";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }
    }
}

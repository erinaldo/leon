using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ReciboDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        string nombre_cliente;

        public string Nombre_cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        string nro_recibo;

        public string Nro_recibo
        {
            get { return nro_recibo; }
            set { nro_recibo = value; }
        }

        List<FacturaDTO> cod_comprobante_factura;

        public List<FacturaDTO> Cod_comprobante_factura
        {
            get { return cod_comprobante_factura; }
            set { cod_comprobante_factura = value; }
        }

        List<ReciboDetalleDTO> list_recibo_detalle;

        public List<ReciboDetalleDTO> List_recibo_detalle
        {
            get { return list_recibo_detalle; }
            set { list_recibo_detalle = value; }
        }

        string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        string cuit;

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        string categoria_iva;

        public string Categoria_iva
        {
            get { return categoria_iva; }
            set { categoria_iva = value; }
        }

        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
        }

        string condicion_venta;

        public string Condicion_venta
        {
            get { return condicion_venta; }
            set { condicion_venta = value; }
        }

        int id_talonario;

        public int Id_talonario
        {
            get { return id_talonario; }
            set { id_talonario = value; }
        }

        public ReciboDTO()
        {
            id = -1;
            importe = decimal.Zero;
            id_factura = -1;
            id_cliente = string.Empty;
            nombre_cliente = string.Empty;
            nro_recibo = string.Empty;
            cod_comprobante_factura = new List<FacturaDTO>();
            direccion = string.Empty;
            localidad = string.Empty;
            cuit = string.Empty;
            categoria_iva = string.Empty;
            v_importe = string.Empty;
            condicion_venta = String.Empty;
            id_talonario = -1;
        }

        //feb 1.8
        public static long insertar(ReciboDTO dataRecibo)
        {
            long idRecibo = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select nextval('ofc_recibo_id_seq') idRecibo";
            //nuevo id de recibo
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRecibo = long.Parse(data["idRecibo"].ToString());
                data.Close();
            }

            //genero recibo
            sql = "INSERT INTO ofc_recibo("
            + " id, valor, id_cliente, nombre_cliente, fecha_creacion)"
            + " VALUES (@idRecibo, @importe, @idCliente, @nombreCliente, @fechaCreacion);";

            parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));
            parameters.Add(new NpgsqlParameter("importe", dataRecibo.importe));
            parameters.Add(new NpgsqlParameter("idCliente", dataRecibo.Id_cliente));
            parameters.Add(new NpgsqlParameter("nombreCliente", dataRecibo.Nombre_cliente));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            foreach (FacturaDTO Factura in dataRecibo.cod_comprobante_factura)
            {
                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrigen", Factura.Id));
                parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));
                parameters.Add(new NpgsqlParameter("codComprobante", Factura.Cod_comprobante));

                //es factura o nota de debito?
                if (Factura.Tipo_comprobante.IndexOf("FAC") != -1)
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("FACTURA " + Factura.Tipo_factura.ToString())));
                    //actualizo factura
                    sql = "update ofc_factura set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("DEB") != -1)
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE DEBITO " + Factura.Tipo_factura.ToString())));
                    //actualizo nota de debito
                    sql = "update ofc_nota_debito set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("CRE") != -1) //feb 1.8 fix
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE CREDITO " + Factura.Tipo_factura.ToString())));
                    //actualizo nota de credito
                    sql = "update ofc_nota_credito set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }

                //genero relacion recibo factura
                sql = "INSERT INTO ofc_recibo_comprobante("
                + " id_recibo, id_origen, id_tipo_comprobante)"
                + " VALUES (@idRecibo, @idOrigen, @id_tipo_comprobante);";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

                sql = "update ofc_movimiento set pago = 'R' where id_origen = @idOrigen and cod_comprobante = @codComprobante and id_tipo_comprobante = @id_tipo_comprobante";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }

            ReciboDetalleDTO.insertar(dataRecibo.list_recibo_detalle, idRecibo);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idRecibo;

        }

        //feb 1.8
        public static void updateFacturasPagas(List<FacturaDTO> codComprobante)
        {
            string sql = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            foreach (FacturaDTO Factura in codComprobante)
            {
                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrigen", Factura.Id));
                parameters.Add(new NpgsqlParameter("codComprobante", Factura.Cod_comprobante));

                if (Factura.Tipo_comprobante.IndexOf("FAC") != -1)
                {
                    //actualizo factura
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("FACTURA " + Factura.Tipo_factura.ToString())));
                    sql = "update ofc_factura set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                else
                {
                    //actualizo nota de débito
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE DEBITO " + Factura.Tipo_factura.ToString())));
                    sql = "update ofc_nota_debito set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }

                sql = "update ofc_movimiento set pago = 'R' where id_origen = @idOrigen and cod_comprobante = @codComprobante and id_tipo_comprobante = @id_tipo_comprobante";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
            }


            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static List<ReciboDTO> obtenerReciboReg(long idRecibo)
        {
            List<ReciboDTO> lista = new List<ReciboDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select recibo.id idRecibo, recibo.valor total, cliente.nombre nombreCliente,";
            sql = sql + " cliente.direccion_legal direccion, cliente.localidad_legal localidad,";
            sql = sql + " condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_recibo recibo, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where recibo.id_cliente = cliente.id";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and condicion.id_tabla = 'CI'";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and recibo.id = @idRecibo";

            parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ReciboDTO e = new ReciboDTO();
                e.id = long.Parse(data["idRecibo"].ToString());
                e.importe = Decimal.Parse(data["total"].ToString());
                e.importe = Decimal.Round(e.importe, 2);
                e.v_importe = String.Format("{0:0.00}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));
                e.id_cliente = data["idCliente"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.cuit = data["cuitCliente"].ToString();
                e.condicion_venta = data["condicionVenta"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        //feb 1.8
        public static void eliminar(ReciboDTO dato)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            parameters.Add(new NpgsqlParameter("id", dato.id));
            decimal importe = decimal.Zero;

            //recupero el importe para quitar de la cuenta
            string sql = "select valor";
            sql = sql + " from ofc_recibo";
            sql = sql + " where id = @id";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["valor"].ToString());
            }

            if (data != null)
                data.Close();

            parameters.Add(new NpgsqlParameter("idCliente", dato.id_cliente));
            parameters.Add(new NpgsqlParameter("importe", importe));

            //actualizo saldo cuenta
            sql = "update ofc_cuenta_corriente set saldo = saldo - @importe where id_cliente = @idCliente and activo = 'S'";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las facturas en el maestro
            sql = "update ofc_factura set pago = 'N' where id in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'FACTURA%' and v.id_tabla = 'TC')"; //feb 1.8
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las notas de débito en el maestro
            sql = "update ofc_nota_debito set pago = 'N' where id in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'NOTA DE DEBITO%' and v.id_tabla = 'TC')"; //feb 1.8
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las notas de crédito en el maestro
            sql = "update ofc_nota_credito set pago = 'N' where id in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'NOTA DE CREDITO%' and v.id_tabla = 'TC')"; //feb 1.8 fix
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las facturas en el movimiento
            sql = "update ofc_movimiento set pago = null where id_cuenta_corriente in (select id from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S') and id_origen in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'FACTURA%' and v.id_tabla = 'TC') and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'FACTURA%')"; //feb 1.8
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las notas de débito en el movimiento
            sql = "update ofc_movimiento set pago = null where id_cuenta_corriente in (select id from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S') and id_origen in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'NOTA DE DEBITO%' and v.id_tabla = 'TC') and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'NOTA DE DEBITO%')"; //feb 1.8
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //actualizo como impagas las notas de crédito en el movimiento
            sql = "update ofc_movimiento set pago = null where id_cuenta_corriente in (select id from ofc_cuenta_corriente where id_cliente = @idCliente and activo = 'S') and id_origen in (select c.id_origen from ofc_recibo_comprobante c, ofc_tabla_valor v where c.id_tipo_comprobante = v.id and c.id_recibo = @id and v.valor like 'NOTA DE CREDITO%' and v.id_tabla = 'TC') and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'NOTA DE CREDITO%')"; //feb 1.8 fix
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino la relacion del recibo con la factura
            sql = "delete from ofc_recibo_comprobante where id_recibo = @id"; //feb 1.8
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino detalle del recibo
            sql = "delete from ofc_recibo_detalle where id_recibo = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino recibo
            sql = "delete from ofc_recibo where id = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino la cobranza
            sql = "delete from ofc_cobranza where nro_comprobante in (select cod_comprobante from ofc_comprobante where id_origen = @id and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'RECIBO'))";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino movimiento de cuenta
            sql = "delete from ofc_movimiento where id_origen = @id and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'RECIBO')";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //elimino comprobante
            sql = "delete from ofc_comprobante where id_origen = @id and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor like 'RECIBO')";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void recalcularMovimientosPost(long id_origen, long id_tipo_comprobante)
        {
            long id = 0;
            decimal debe = decimal.Zero;
            decimal haber = decimal.Zero;
            decimal saldo_base = decimal.Zero;
            long idCuenta = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnUpdate = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //get id cuenta
            string sql = "select id_cuenta_corriente, haber, saldo from ofc_movimiento where id_origen = @id_origen and id_tipo_comprobante = @id_tipo_comprobante";
            
            parameters.Add(new NpgsqlParameter("id_origen", id_origen));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCuenta = long.Parse(data["id_cuenta_corriente"].ToString());
                saldo_base = decimal.Parse(data["saldo"].ToString()) - decimal.Parse(data["haber"].ToString());
                data.Close();
            }

            //get movimientos post recibo
            sql = "select id, debe, haber, saldo from ofc_movimiento where id_cuenta_corriente = @idCuenta and id > (select id from ofc_movimiento where id_origen = @id_origen and id_tipo_comprobante = @id_tipo_comprobante) order by id";

            parameters.Add(new NpgsqlParameter("idCuenta", idCuenta));

            NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data2 != null && data2.Read())
            {
                id = long.Parse(data2["id"].ToString());
                debe = decimal.Parse(data2["debe"].ToString());
                haber = decimal.Parse(data2["haber"].ToString());

                if (debe != decimal.Zero){
                    saldo_base = saldo_base - debe;
                }

                if (haber != decimal.Zero)
                {
                    saldo_base = saldo_base + haber;
                }

                sql = "update ofc_movimiento set saldo = @saldo where id = @id";

                parameters.Add(new NpgsqlParameter("saldo", saldo_base));
                parameters.Add(new NpgsqlParameter("id", id));
                BaseDeDatos.ejecutarNonQuery(sql, cnUpdate, parameters);
            }

            if (data2 != null)
                data2.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnUpdate.State == System.Data.ConnectionState.Open)
                cnUpdate.Close();

        }

    }
}

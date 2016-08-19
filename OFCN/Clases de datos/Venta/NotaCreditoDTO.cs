using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class NotaCreditoDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        Decimal subtotal;

        public Decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        string v_subtotal;

        public string V_subtotal
        {
            get { return v_subtotal; }
            set { v_subtotal = value; }
        }

        Decimal iva;

        public Decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        
        string v_iva;

        public string V_iva
        {
            get { return v_iva; }
            set { v_iva = value; }
        }

        Decimal total;

        public Decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        string v_total;

        public string V_total
        {
            get { return v_total; }
            set { v_total = value; }
        }

        Decimal bonificacion;

        public Decimal Bonificacion
        {
            get { return bonificacion; }
            set { bonificacion = value; }
        }

        string v_bonificacion;

        public string V_bonificacion
        {
            get { return v_bonificacion; }
            set { v_bonificacion = value; }
        }
        
        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        string nombre_cliente;

        public string Nombre_cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        long nro_nota_credito;

        public long Nro_nota_credito
        {
            get { return nro_nota_credito; }
            set { nro_nota_credito = value; }
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

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        char tipo_nota_credito;

        public char Tipo_nota_credito
        {
            get { return tipo_nota_credito; }
            set { tipo_nota_credito = value; }
        }

        string condicion_venta;

        public string Condicion_venta
        {
            get { return condicion_venta; }
            set { condicion_venta = value; }
        }

        public NotaCreditoDTO()
        {
        id = -1;
        subtotal = decimal.Zero;
        v_subtotal = string.Empty;
        iva = decimal.Zero;
        v_iva = string.Empty;
        total = decimal.Zero;
        v_total = string.Empty;
        bonificacion = decimal.Zero;
        v_bonificacion = string.Empty;
        fecha_creacion = DateTime.Now;
        nombre_cliente = string.Empty;
        id_cliente = string.Empty;
        nro_nota_credito = -1;
        direccion = string.Empty;
        localidad = string.Empty;
        cuit = string.Empty;
        categoria_iva = string.Empty;
        cod_comprobante = string.Empty;
        tipo_nota_credito = 'N';
        condicion_venta = String.Empty;
        }

        public static long insert(NotaCreditoDTO dataCredito)
        {
            long idCredito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('ofc_nota_credito_id_seq') idCredito";
            //nuevo id de nc
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idCredito = long.Parse(data["idCredito"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero factura
            sql = "INSERT INTO ofc_nota_credito("
            + " id, fecha_creacion,"
            + " id_cliente, nombre_cliente, usuario_creacion, pago)"
            + " VALUES (@idCredito, @fechaCreacion, @idCliente, @nombreCliente, @usuario_creacion, 'N');";

            parameters.Add(new NpgsqlParameter("idCredito", idCredito));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCliente", dataCredito.Id_cliente));
            parameters.Add(new NpgsqlParameter("nombreCliente", dataCredito.Nombre_cliente));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "NOTA CREDITO";
            comprobante.Id_origen = idCredito;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idCredito;

        }

        public static void insertDetalle(NotaCreditoDetalleDTO dataCreditoDet)
        {

            long idCreditoDetalle = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de factura detalle
            string sql = "select nextval('ofc_nota_credito_detalle_id_seq') idCreditoDetalle";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idCreditoDetalle = long.Parse(data["idCreditoDetalle"].ToString());
                data.Close();
            }

            //formateo
            dataCreditoDet.Precio_unitario = decimal.Round(dataCreditoDet.Precio_unitario, 2, MidpointRounding.AwayFromZero);
            dataCreditoDet.Importe = decimal.Round(dataCreditoDet.Importe, 2, MidpointRounding.AwayFromZero);

            //genero el detalle de la factura
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_nota_credito_detalle("
            + " id, cantidad, motivo, descripcion, precio_unitario, importe,"
            + " id_nota_credito, cod_comprobante_factura)"
            + " VALUES (@idCreditoDetalle, @cantidad, @motivo, @descripcion, @precio_unitario, @importe, @id_nota_credito, @cod_comprobante_factura);";

            //detalle del registro facturable
            parameters.Add(new NpgsqlParameter("idCreditoDetalle", idCreditoDetalle));
            parameters.Add(new NpgsqlParameter("cantidad", 1));
            parameters.Add(new NpgsqlParameter("motivo", dataCreditoDet.Motivo));
            parameters.Add(new NpgsqlParameter("descripcion", dataCreditoDet.Descripcion));
            parameters.Add(new NpgsqlParameter("precio_unitario", dataCreditoDet.Precio_unitario));
            parameters.Add(new NpgsqlParameter("importe", dataCreditoDet.Importe));
            parameters.Add(new NpgsqlParameter("id_nota_credito", dataCreditoDet.Id_nota_credito));
            parameters.Add(new NpgsqlParameter("cod_comprobante_factura", dataCreditoDet.Cod_comprobante_factura));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static long getIdCreditoTemp(string idCliente)
        {
            long idCredito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select c_temp.id_origen idCredito from ofc_comprobante_temp c_temp, ofc_nota_credito credito where c_temp.id_origen = credito.id and c_temp.comprobante = 'NOTA CREDITO' and credito.id_cliente = @idCliente";
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCredito = long.Parse(data["idCredito"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idCredito;
        }


        public static List<NotaCreditoDTO> obtenerCreditoTemp()
        {
            List<NotaCreditoDTO> lista = new List<NotaCreditoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            int contadorFactA = 1;
            int contadorFactB = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnFact = BaseDeDatos.obtenerConexion();

            string sql = "select credito.id idCredito, credito.bonificacion bonificacion, credito.subtotal subtotal, credito.iva iva, credito.total total, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, condicion.valor_adicional tipoFactura, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_nota_credito credito, ofc_comprobante_temp c_temp, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where credito.id = c_temp.id_origen";
            sql = sql + " and cliente.id = credito.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and c_temp.comprobante = 'NOTA CREDITO'";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and c_temp.usuario = @login";
            sql = sql + " order by credito.fecha_creacion";

            parameters.Add(new NpgsqlParameter("login", Usuario.GetInstance().Login));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataFact = null;

            while (data != null && data.Read())
            {
                NotaCreditoDTO e = new NotaCreditoDTO();

                e.id = long.Parse(data["idCredito"].ToString());
                e.bonificacion = Decimal.Parse(data["bonificacion"].ToString());
                e.bonificacion = Decimal.Round(e.bonificacion, 2);
                e.subtotal = Decimal.Parse(data["subtotal"].ToString());
                e.subtotal = Decimal.Round(e.subtotal, 2);
                e.iva = Decimal.Parse(data["iva"].ToString());
                e.iva = Decimal.Round(e.iva, 2);
                e.total = Decimal.Parse(data["total"].ToString());
                e.total = Decimal.Round(e.total, 2);
                e.id_cliente = data["idCliente"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.id_cliente = data["idCliente"].ToString();
                e.cuit = data["cuitCliente"].ToString();
                e.tipo_nota_credito = char.Parse(data["tipoFactura"].ToString());
                e.condicion_venta = data["condicionVenta"].ToString();

                e.v_subtotal = String.Format("{0:0.00}", Math.Round(e.subtotal, 2, MidpointRounding.AwayFromZero));
                e.v_iva = String.Format("{0:0.00}", Math.Round(e.iva, 2, MidpointRounding.AwayFromZero));
                e.v_total = String.Format("{0:0.00}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));
                e.v_bonificacion = String.Format("{0:0.00}", Math.Round(e.bonificacion, 2, MidpointRounding.AwayFromZero));

                sql = "select parametro_2 nroFactura from ofc_parametro a where a.descripcion = 'INICIO NRO NOTA DE CREDITO " + e.tipo_nota_credito + "'"; //feb 1.9
                dataFact = BaseDeDatos.ejecutarQuery(sql, cnFact);

                if (dataFact != null && dataFact.Read())
                {
                    if (e.tipo_nota_credito == 'A')
                    {
                        e.nro_nota_credito = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;

                        while (ComprobanteDTO.existeNotaCreditoA(e.nro_nota_credito))
                        {
                            contadorFactA += 1;
                            e.nro_nota_credito = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;
                        }

                        dataFact.Close();
                        contadorFactA = contadorFactA + 1;
                    }

                    if (e.tipo_nota_credito == 'B')
                    {
                        e.nro_nota_credito = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;

                        while (ComprobanteDTO.existeNotaCreditoB(e.nro_nota_credito))
                        {
                            contadorFactB += 1;
                            e.nro_nota_credito = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;
                        }

                        dataFact.Close();
                        contadorFactB = contadorFactB + 1;
                    }
                }

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnFact.State == System.Data.ConnectionState.Open)
                cnFact.Close();

            return lista;
        }


        public static List<NotaCreditoDTO> obtenerCreditoReg(long idCredito)
        {
            List<NotaCreditoDTO> lista = new List<NotaCreditoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select credito.id idCredito, credito.bonificacion bonificacion, credito.subtotal subtotal, credito.iva iva, credito.total total, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, condicion.valor_adicional tipoFactura, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_nota_credito credito, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where cliente.id = credito.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and credito.id = @idCred";

            parameters.Add(new NpgsqlParameter("idCred", idCredito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                NotaCreditoDTO e = new NotaCreditoDTO();

                e.id = long.Parse(data["idCredito"].ToString());
                e.bonificacion = Decimal.Parse(data["bonificacion"].ToString());
                e.bonificacion = Decimal.Round(e.bonificacion, 2);
                e.subtotal = Decimal.Parse(data["subtotal"].ToString());
                e.subtotal = Decimal.Round(e.subtotal, 2);
                e.iva = Decimal.Parse(data["iva"].ToString());
                e.iva = Decimal.Round(e.iva, 2);
                e.total = Decimal.Parse(data["total"].ToString());
                e.total = Decimal.Round(e.total, 2);
                e.id_cliente = data["idCliente"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.id_cliente = data["idCliente"].ToString();
                e.cuit = data["cuitCliente"].ToString();
                e.tipo_nota_credito = char.Parse(data["tipoFactura"].ToString());
                e.condicion_venta = data["condicionVenta"].ToString();

                e.v_subtotal = String.Format("{0:0.00}", Math.Round(e.subtotal, 2, MidpointRounding.AwayFromZero));
                e.v_iva = String.Format("{0:0.00}", Math.Round(e.iva, 2, MidpointRounding.AwayFromZero));
                e.v_total = String.Format("{0:0.00}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));
                e.v_bonificacion = String.Format("{0:0.00}", Math.Round(e.bonificacion, 2, MidpointRounding.AwayFromZero));

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();


            return lista;
        }


        public static void cargarDatosNotaCredito()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnUpdate = BaseDeDatos.obtenerConexion();
            Decimal valorBonificacion = Decimal.Zero;
            Decimal importe = Decimal.Zero;
            Decimal datoIva = Decimal.Zero;
            Decimal valorIva = Decimal.Zero;
            Decimal valorTotal = Decimal.Zero;
            Decimal valorSubTotal = Decimal.Zero;

            //datoIva = ParametroDTO.obtenerParametroI("IVA");
            datoIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
            datoIva = decimal.Round(datoIva, 2, MidpointRounding.AwayFromZero);

            string sql = "select a.id idCredito, e.valor_adicional condicionIva, sum (b.importe::double precision) importe";
            sql = sql + " from ofc_nota_credito a, ofc_nota_credito_detalle b, ofc_comprobante_temp c, ofc_cliente d, ofc_tabla_valor e";
            sql = sql + " where a.id = b.id_nota_credito";
            sql = sql + " and c.id_origen = a.id";
            sql = sql + " and d.id = a.id_cliente";
            sql = sql + " and e.id = d.id_categoria_iva";
            sql = sql + " and d.activo = 'S'";
            sql = sql + " and c.comprobante = 'NOTA CREDITO'";
            sql = sql + " group by a.id, e.valor_adicional";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            while (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                importe = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);
                valorBonificacion = decimal.Round(Decimal.Zero, 2, MidpointRounding.AwayFromZero);
                valorSubTotal = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);

                //set iva en factura
                if (char.Parse(data["condicionIva"].ToString()) == 'A')
                {
                    valorIva = (valorSubTotal * datoIva) / 100;
                    valorTotal = valorSubTotal + valorIva;
                }
                else
                {
                    valorIva = Decimal.Zero;
                    valorTotal = valorSubTotal;
                }

                valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                valorTotal = decimal.Round(valorTotal, 2, MidpointRounding.AwayFromZero);

                sql = "update ofc_nota_credito";
                sql = sql + " set subtotal = @valorSubTotal,";
                sql = sql + " iva = @valorIva,";
                sql = sql + " bonificacion = @valorBonificacion,";
                sql = sql + " total = @valorTotal";
                sql = sql + " where id = @idCredito; ";

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("valorSubTotal", valorSubTotal));
                parameters.Add(new NpgsqlParameter("valorIva", valorIva));
                parameters.Add(new NpgsqlParameter("valorBonificacion", valorBonificacion));
                parameters.Add(new NpgsqlParameter("valorTotal", valorTotal));
                parameters.Add(new NpgsqlParameter("idCredito", data["idCredito"].ToString()));

                BaseDeDatos.ejecutarNonQuery(sql, cnUpdate, parameters);

            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnUpdate.State == System.Data.ConnectionState.Open)
                cnUpdate.Close();

        }

        public static bool existeCreditoTemp(string idCliente)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante_temp c_temp, ofc_nota_credito credito where c_temp.id_origen = credito.id and c_temp.comprobante = 'NOTA CREDITO' and credito.id_cliente = @idCliente";
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

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

        public static void borrarCreditoTemp()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_nota_credito_detalle where id_nota_credito in (select id_origen from ofc_comprobante_temp where comprobante = 'NOTA CREDITO');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_nota_credito where id in (select id_origen from ofc_comprobante_temp where comprobante = 'NOTA CREDITO');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_comprobante_temp where comprobante = 'NOTA CREDITO';";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static long replicarCredito(NotaCreditoDTO dataCredito)
        {
            long idCredito = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select nextval('ofc_nota_credito_id_seq') idCreditoNew";
            //nuevo id de factura
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idCredito = long.Parse(data["idCreditoNew"].ToString());
                data.Close();
            }

            parameters.Add(new NpgsqlParameter("idCredito", dataCredito.Id));
            parameters.Add(new NpgsqlParameter("idCreditoNew", idCredito));

            //inserto la nueva factura
            sql = "INSERT INTO ofc_nota_credito SELECT @idCreditoNew, subtotal, iva, id_cliente, nombre_cliente, bonificacion, total, fecha_creacion, pago, usuario_creacion";
            sql = sql + " FROM ofc_nota_credito cre where cre.id = @idCredito";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //inserto el detalle nuevo
            sql = "INSERT INTO ofc_nota_credito_detalle SELECT nextval('ofc_nota_credito_detalle_id_seq'), cantidad, motivo, descripcion, precio_unitario, importe, @idCreditoNew, cod_comprobante_factura";
            sql = sql + " FROM ofc_nota_credito_detalle det where det.id_nota_credito = @idCredito order by 1";
            

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "NOTA CREDITO";
            comprobante.Id_origen = idCredito;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idCredito;

        }

        //devuelvo una factura porque la estructura es la misma o casi igual que una nota de credito
        //feb 1.8 fix
        public static IList<FacturaDTO> obtenerCreditosImpagos(string codCliente)
        {
            IList<FacturaDTO> lista = new List<FacturaDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, credito.total total, val.valor tipoCredito, credito.id idCredito, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from ofc_nota_credito credito, ofc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.id_origen = credito.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'NOTA DE CREDITO%'";
            sql = sql + " and credito.id_cliente = @codCliente";
            sql = sql + " and (credito.pago = 'N')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("codCliente", codCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDTO e = new FacturaDTO();

                e.Total = Decimal.Parse(data["total"].ToString()) * (-1);
                e.Total = Decimal.Round(e.Total, 2);
                e.V_total = String.Format("{0:C}", Math.Round(e.Total, 2, MidpointRounding.AwayFromZero));
                e.Cod_comprobante = data["codComprobante"].ToString();
                e.Fecha_creacion = DateTime.Parse(data["fechaCreacion"].ToString());
                e.V_fecha_creacion = String.Format("{0:dd/MM/yyyy}", e.Fecha_creacion);
                e.Id = long.Parse(data["idCredito"].ToString());
                e.Tipo_comprobante = data["tipoComprobanteAbreviado"].ToString();

                if (data["tipoCredito"].ToString() == "NOTA DE CREDITO A")
                {
                    e.Tipo_factura = 'A';
                }

                if (data["tipoCredito"].ToString() == "NOTA DE CREDITO B")
                {
                    e.Tipo_factura = 'B';
                }

                if (data["tipoCredito"].ToString() == "NOTA DE CREDITO C")
                {
                    e.Tipo_factura = 'C';
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

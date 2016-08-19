using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class FacturaDTO
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

        string v_iva;

        public string V_iva
        {
            get { return v_iva; }
            set { v_iva = value; }
        }

        string v_total;

        public string V_total
        {
            get { return v_total; }
            set { v_total = value; }
        }

        string v_bonificacion;

        public string V_bonificacion
        {
            get { return v_bonificacion; }
            set { v_bonificacion = value; }
        }

        Decimal iva;

        public Decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        Decimal total;

        public Decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        long id_estado_factura;

        public long Id_estado_factura
        {
            get { return id_estado_factura; }
            set { id_estado_factura = value; }
        }

        string nombre_cliente;

        public string Nombre_cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }

        Decimal bonificacion;

        public Decimal Bonificacion
        {
            get { return bonificacion; }
            set { bonificacion = value; }
        }

        string coche;

        public string Coche
        {
            get { return coche; }
            set { coche = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        long nro_remito;

        public long Nro_remito
        {
            get { return nro_remito; }
            set { nro_remito = value; }
        }

        long nro_factura;

        public long Nro_factura
        {
            get { return nro_factura; }
            set { nro_factura = value; }
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

        string cod_comprobante_remito;

        public string Cod_comprobante_remito
        {
            get { return cod_comprobante_remito; }
            set { cod_comprobante_remito = value; }
        }

        char solo_factura;

        public char Solo_factura
        {
            get { return solo_factura; }
            set { solo_factura = value; }
        }

        char tipo_factura;

        public char Tipo_factura
        {
            get { return tipo_factura; }
            set { tipo_factura = value; }
        }

        char iva105;

        public char Iva105
        {
            get { return iva105; }
            set { iva105 = value; }
        }

        char pagado;

        public char Pagado
        {
            get { return pagado; }
            set { pagado = value; }
        }

        string condicion_venta;

        public string Condicion_venta
        {
            get { return condicion_venta; }
            set { condicion_venta = value; }
        }

        //feb 1.8
        string v_fecha_creacion;

        public string V_fecha_creacion
        {
            get { return v_fecha_creacion; }
            set { v_fecha_creacion = value; }
        }

        //feb 1.8
        string tipo_comprobante;

        public string Tipo_comprobante
        {
            get { return tipo_comprobante; }
            set { tipo_comprobante = value; }
        }

        //feb 1.9.1
        long id_unico_comprobante;

        public long Id_unico_comprobante
        {
            get { return id_unico_comprobante; }
            set { id_unico_comprobante = value; }
        }

        //feb 1.9.1
        int fw_origen;

        public int Fw_origen
        {
            get { return fw_origen; }
            set { fw_origen = value; }
        }

        //feb 1.9.1
        int fw_tipo_comprobante;

        public int Fw_tipo_comprobante
        {
            get { return fw_tipo_comprobante; }
            set { fw_tipo_comprobante = value; }
        }

        //feb 1.9.1
        int fw_concepto;

        public int Fw_concepto
        {
            get { return fw_concepto; }
            set { fw_concepto = value; }
        }

        //feb 1.9.1
        int fw_id_condicion_venta;

        public int Fw_id_condicion_venta
        {
            get { return fw_id_condicion_venta; }
            set { fw_id_condicion_venta = value; }
        }

        decimal baseImp3;

        public decimal BaseImp3
        {
            get { return baseImp3; }
            set { baseImp3 = value; }
        }

        decimal impIVA3;

        public decimal ImpIVA3
        {
            get { return impIVA3; }
            set { impIVA3 = value; }
        }

        decimal baseImp4;

        public decimal BaseImp4
        {
            get { return baseImp4; }
            set { baseImp4 = value; }
        }

        decimal impIVA4;

        public decimal ImpIVA4
        {
            get { return impIVA4; }
            set { impIVA4 = value; }
        }

        decimal baseImp5;

        public decimal BaseImp5
        {
            get { return baseImp5; }
            set { baseImp5 = value; }
        }

        decimal impIVA5;

        public decimal ImpIVA5
        {
            get { return impIVA5; }
            set { impIVA5 = value; }
        }

        decimal baseImp6;

        public decimal BaseImp6
        {
            get { return baseImp6; }
            set { baseImp6 = value; }
        }

        decimal impIVA6;

        public decimal ImpIVA6
        {
            get { return impIVA6; }
            set { impIVA6 = value; }
        }


        public FacturaDTO()
        {
            id = -1;
            subtotal = Decimal.Zero;
            iva = Decimal.Zero;
            total = Decimal.Zero;
            fecha_creacion = DateTime.Now;
            id_estado_factura = -1;
            nombre_cliente = String.Empty;
            bonificacion = Decimal.Zero;
            coche = String.Empty;
            id_cliente = String.Empty;
            nro_remito = -1;
            nro_factura = -1;
            direccion = String.Empty;
            localidad = String.Empty;
            cuit = String.Empty;
            categoria_iva = String.Empty;
            v_subtotal = String.Empty;
            v_iva = String.Empty;
            v_total = String.Empty;
            v_bonificacion = String.Empty;
            cod_comprobante = String.Empty;
            solo_factura = 'N';
            iva105 = 'N';
            cod_comprobante_remito = String.Empty;
            pagado = 'N';
            condicion_venta = String.Empty;
            tipo_comprobante = String.Empty; //feb 1.8
            v_fecha_creacion = String.Empty; //feb 1.8
            id_unico_comprobante = -1; //inicio feb 1.9.1 
            fw_origen = -1;
            fw_tipo_comprobante = -1;
            fw_concepto = -1;
            fw_id_condicion_venta = -1;
            baseImp3 = decimal.Zero;
            impIVA3 = decimal.Zero;
            baseImp4 = decimal.Zero;
            impIVA4 = decimal.Zero;
            baseImp5 = decimal.Zero;
            impIVA5 = decimal.Zero;
            baseImp6 = decimal.Zero;
            impIVA6 = decimal.Zero;  //fin feb 1.9.1
        }

        public static List<FacturaDTO> obtenerFacturasTempDeRem()
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            int contadorFactA = 1;
            int contadorFactB = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnFact = BaseDeDatos.obtenerConexion();
            //feb 1.9.1 comento:
            //NpgsqlConnection cnRem = BaseDeDatos.obtenerConexion();

            string sql = "select factura.id idFactura, factura.bonificacion bonificacion,  factura.subtotal subtotal,  factura.iva iva, factura.total total, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, factura.solo_factura soloFactura, condicion.valor_adicional tipoFactura, factura.iva105 iva105, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_factura factura, ofc_comprobante_temp c_temp, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where factura.id = c_temp.id_origen";
            sql = sql + " and cliente.id = factura.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and c_temp.comprobante = 'FACTURA'";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and c_temp.usuario = @login";
            sql = sql + " order by factura.fecha_creacion";

            parameters.Add(new NpgsqlParameter("login", Usuario.GetInstance().Login));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataFact = null;

            while (data != null && data.Read())
            {
                FacturaDTO e = new FacturaDTO();

                e.id = long.Parse(data["idFactura"].ToString());
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
                e.solo_factura = char.Parse(data["soloFactura"].ToString());
                e.tipo_factura = char.Parse(data["tipoFactura"].ToString());
                e.iva105 = char.Parse(data["iva105"].ToString());
                e.condicion_venta = data["condicionVenta"].ToString();

                e.v_subtotal = String.Format("{0:0.00}", Math.Round(e.subtotal, 2, MidpointRounding.AwayFromZero));
                e.v_iva = String.Format("{0:0.00}", Math.Round(e.iva, 2, MidpointRounding.AwayFromZero));
                e.v_total = String.Format("{0:0.00}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));
                e.v_bonificacion = String.Format("{0:0.00}", Math.Round(e.bonificacion, 2, MidpointRounding.AwayFromZero));

                sql = "select parametro_2 nroFactura from ofc_parametro a where a.descripcion = 'INICIO NRO FACTURA " + e.tipo_factura + "'";
                dataFact = BaseDeDatos.ejecutarQuery(sql, cnFact);

                if (dataFact != null && dataFact.Read())
                {
                    if (e.tipo_factura == 'A')
                    {
                        e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;

                        while (ComprobanteDTO.existeFacturaA(e.nro_factura))
                        {
                            contadorFactA += 1;
                            e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;
                        }

                        dataFact.Close();
                        contadorFactA = contadorFactA + 1;
                    }

                    if (e.tipo_factura == 'B')
                    {
                        e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;

                        while (ComprobanteDTO.existeFacturaB(e.nro_factura))
                        {
                            contadorFactB += 1;
                            e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;
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

            //feb 1.9.1 comento:
            //if (cnRem.State == System.Data.ConnectionState.Open)
            //    cnRem.Close();

            return lista;
        }


        public static List<FacturaDTO> obtenerFacturasTemp()
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            int contadorFactA = 1;
            int contadorFactB = 1;
            int contadorRem = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnFact = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnRem = BaseDeDatos.obtenerConexion();

            string sql = "select factura.id idFactura, factura.bonificacion bonificacion,  factura.subtotal subtotal,  factura.iva iva, factura.total total, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, factura.solo_factura soloFactura, condicion.valor_adicional tipoFactura, factura.iva105 iva105, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_factura factura, ofc_comprobante_temp c_temp, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where factura.id = c_temp.id_origen";
            sql = sql + " and cliente.id = factura.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and c_temp.comprobante = 'FACTURA'";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and c_temp.usuario = @login";
            sql = sql + " order by factura.fecha_creacion";

            parameters.Add(new NpgsqlParameter("login", Usuario.GetInstance().Login));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataFact = null;
            NpgsqlDataReader dataRem = null;

            while (data != null && data.Read())
            {
                FacturaDTO e = new FacturaDTO();

                e.id = long.Parse(data["idFactura"].ToString());
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
                e.solo_factura = char.Parse(data["soloFactura"].ToString());
                e.tipo_factura = char.Parse(data["tipoFactura"].ToString());
                e.iva105 = char.Parse(data["iva105"].ToString());
                e.condicion_venta = data["condicionVenta"].ToString();

                e.v_subtotal = String.Format("{0:0.00}", Math.Round(e.subtotal, 2, MidpointRounding.AwayFromZero));
                e.v_iva = String.Format("{0:0.00}", Math.Round(e.iva, 2, MidpointRounding.AwayFromZero));
                e.v_total = String.Format("{0:0.00}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));
                e.v_bonificacion = String.Format("{0:0.00}", Math.Round(e.bonificacion, 2, MidpointRounding.AwayFromZero));

                sql = "select parametro_2 nroFactura from ofc_parametro a where a.descripcion = 'INICIO NRO FACTURA " + e.tipo_factura + "'";
                dataFact = BaseDeDatos.ejecutarQuery(sql, cnFact);

                if (dataFact != null && dataFact.Read())
                {
                    if (e.tipo_factura == 'A')
                    {
                        e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;

                        while (ComprobanteDTO.existeFacturaA(e.nro_factura))
                        {
                            contadorFactA += 1;
                            e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactA;
                        }

                        dataFact.Close();
                        contadorFactA = contadorFactA + 1;
                    }
                    
                    if (e.tipo_factura == 'B')
                    {
                        e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;

                        while (ComprobanteDTO.existeFacturaB(e.nro_factura))
                        {
                            contadorFactB += 1;
                            e.nro_factura = long.Parse(dataFact["nroFactura"].ToString()) + contadorFactB;
                        }

                        dataFact.Close();
                        contadorFactB = contadorFactB + 1;
                    }
                }


                if (e.solo_factura == 'N')
                {
                    sql = "select parametro_2 nroRemito from ofc_parametro a where a.descripcion = 'INICIO NRO REMITO'";
                    dataRem = BaseDeDatos.ejecutarQuery(sql, cnRem);

                    if (dataRem != null && dataRem.Read())
                    {
                        e.nro_remito = long.Parse(dataRem["nroRemito"].ToString()) + contadorRem;

                        while (ComprobanteDTO.existeRemito(e.nro_remito))
                        {
                            contadorRem += 1;
                            e.nro_remito = long.Parse(dataRem["nroRemito"].ToString()) + contadorRem;
                        }
                        
                        dataRem.Close();

                        contadorRem = contadorRem + 1;
                    }
                   
                }
                

                //hay que actualizar en la base el incremento del numero

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnFact.State == System.Data.ConnectionState.Open)
                cnFact.Close();

            if (cnRem.State == System.Data.ConnectionState.Open)
                cnRem.Close();

            return lista;
        }

        public static List<FacturaDTO> obtenerFacturasReg(long idFactura)
        {
            List<FacturaDTO> lista = new List<FacturaDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select factura.id idFactura, factura.bonificacion bonificacion,  factura.subtotal subtotal,  factura.iva iva, factura.total total, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, factura.solo_factura soloFactura, condicion.valor_adicional tipoFactura, factura.iva105 iva105, factura.pago pago, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_factura factura, ofc_cliente cliente, ofc_tabla_valor condicion,  ofc_tabla_valor cond_venta";
            sql = sql + " where cliente.id = factura.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and factura.id = @idFac";
            sql = sql + " and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idFac", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDTO e = new FacturaDTO();

                e.id = long.Parse(data["idFactura"].ToString());
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
                e.solo_factura = char.Parse(data["soloFactura"].ToString());
                e.tipo_factura = char.Parse(data["tipoFactura"].ToString());
                e.iva105 = char.Parse(data["iva105"].ToString());
                e.pagado = char.Parse(data["pago"].ToString());
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


        //feb 1.8
        public static IList<FacturaDTO> obtenerFacturasImpagas(string codCliente)
        {
            IList<FacturaDTO> lista = new List<FacturaDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select factura.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, factura.total total, val.valor tipoFactura, factura.id idFactura, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from ofc_factura factura, ofc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.id_origen = factura.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'FACTURA%'";
            sql = sql + " and factura.id_cliente = @codCliente";
            sql = sql + " and (factura.pago = 'N')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " order by factura.fecha_creacion";

            parameters.Add(new NpgsqlParameter("codCliente", codCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDTO e = new FacturaDTO();

                e.total = Decimal.Parse(data["total"].ToString());
                e.total = Decimal.Round(e.total, 2);
                e.v_total = String.Format("{0:C}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));

                e.cod_comprobante = data["codComprobante"].ToString();

                e.fecha_creacion = DateTime.Parse(data["fechaCreacion"].ToString());
                e.V_fecha_creacion = String.Format("{0:dd/MM/yyyy}", e.Fecha_creacion);

                e.Id = long.Parse(data["idFactura"].ToString());

                e.Tipo_comprobante = data["tipoComprobanteAbreviado"].ToString();

                if (data["tipoFactura"].ToString() == "FACTURA A")
                {
                    e.tipo_factura = 'A';
                }

                if (data["tipoFactura"].ToString() == "FACTURA B")
                {
                    e.tipo_factura = 'B';
                }

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        //feb 1.9.1
        public static long insert(OrdenDetalleDTO dataOrden, decimal descuento)
        {
            long idFactura = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('ofc_factura_id_seq') idFactura";
            //nuevo id de factura
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero factura
            sql = "INSERT INTO ofc_factura("
            + " id, fecha_creacion,"
            + " id_cliente, pago, solo_factura, iva105, usuario_creacion)"
            + " VALUES (@idFactura, @fechaCreacion, @idCliente, 'N', 'N', 'N', @usuario_creacion);";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "FACTURA";
            comprobante.Id_origen = idFactura;

            ComprobanteTempDTO.insertarTemporal(comprobante, descuento); //feb 1.9.1

            return idFactura;

        }

        public static long insertDeRemito(OrdenDetalleDTO dataOrden, decimal descuento) //feb 1.9.1
        {
            long idFactura = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('ofc_factura_id_seq') idFactura";
            //nuevo id de factura
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero factura
            sql = "INSERT INTO ofc_factura("
            + " id, fecha_creacion,"
            + " id_cliente, pago, solo_factura, iva105, usuario_creacion)"
            + " VALUES (@idFactura, @fechaCreacion, @idCliente, 'N', 'N', 'N', @usuario_creacion);";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "FACTURA";
            comprobante.Id_origen = idFactura;
            ComprobanteTempDTO.insertarTemporal(comprobante, descuento); //feb 1.9.1

            ComprobanteTempDTO comprobanteRem = new ComprobanteTempDTO();
            comprobanteRem.Comprobante = "REMITO";
            comprobanteRem.Id_origen = dataOrden.Id_remito;
            ComprobanteTempDTO.insertarTemporal(comprobanteRem, decimal.Zero); //feb 1.9.1

            return idFactura;

        }

        private static void insertDetalleDesglosado(OrdenDetalleDTO dataOrden)
        {
            long idFacturaDetalle = -1;
            long idFacturaDetalleAdi = -1;
            decimal valorIva = Decimal.Zero;
            char tipoFactura = 'A';
            decimal importe = Decimal.Zero;
            decimal importeAdi = Decimal.Zero;
            int cantidad = 1;
            decimal precio_unitario = decimal.Zero; //feb 1.9.1
            decimal precio_unitario_adi = decimal.Zero; //feb 1.9.1
            decimal iva_importe = decimal.Zero; //feb 1.9.1
            decimal iva_importe_adi = decimal.Zero; //feb 1.9.1
            decimal total = decimal.Zero; //feb 1.9.1
            decimal total_adi = decimal.Zero; //feb 1.9.1
            decimal bonificacion = ComprobanteTempDTO.obtenerDescuento(dataOrden.Id_factura, "FACTURA"); //feb 1.9.1
            
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de factura detalle
            string sql = "select nextval('ofc_factura_detalle_id_seq') idFacturaDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFacturaDetalle = long.Parse(data["idFacturaDet"].ToString());
                data.Close();
            }

            //obtengo el iva
            //valorIva = ParametroDTO.obtenerParametroI("IVA");
            valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
            valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);

            //calculo el importe del item facturable segun el tipo de factura
            IList<NpgsqlParameter> parametersClie = new List<NpgsqlParameter>();
            sql = "select condicion.valor_adicional tipoFactura from ofc_cliente cliente, ofc_tabla_valor condicion";
            sql = sql + " where cliente.id_categoria_iva = condicion.id";
            sql = sql + " and cliente.id = @idCliente";
            sql = sql + " and cliente.activo = 'S'";

            parametersClie.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));

            NpgsqlDataReader dataTipoClie = BaseDeDatos.ejecutarQuery(sql, cn, parametersClie);

            if (dataTipoClie != null && dataTipoClie.Read())
            {
                tipoFactura = char.Parse(dataTipoClie["tipoFactura"].ToString());
                dataTipoClie.Close();
            }

            //si es tipo B calculo el iva dentro del importe, es decir no lo separo
            //feb 1.9.1
            if (tipoFactura == 'B')
            {
                decimal iva_importe_aux = (dataOrden.PrecioLista * valorIva) / 100;
                iva_importe_aux = decimal.Round(iva_importe_aux, 2, MidpointRounding.AwayFromZero);

                precio_unitario = dataOrden.PrecioLista + iva_importe_aux;
                precio_unitario = decimal.Round(precio_unitario, 2, MidpointRounding.AwayFromZero);

                decimal precio_unitario_aux = dataOrden.PrecioLista - (dataOrden.PrecioLista * (bonificacion / 100));
                iva_importe = (precio_unitario_aux * valorIva) / 100;

                importe = precio_unitario - (precio_unitario * (bonificacion / 100));
                importe = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);

                total = importe;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                precio_unitario = dataOrden.PrecioLista;

                importe = dataOrden.PrecioLista - (dataOrden.PrecioLista * (bonificacion / 100));
                importe = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);

                iva_importe = (importe * valorIva) / 100;
                iva_importe = decimal.Round(iva_importe, 2, MidpointRounding.AwayFromZero);

                total = importe + iva_importe;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }

            //genero el detalle de la factura
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_factura_detalle("
            + " id, id_orden_de_trabajo, importe, id_producto, id_servicio, cantidad,"
            + " precio_unitario, id_renglon_orden_de_trabajo, id_factura, fecha_creacion, codigo, coche, motivo_descuento, descripcion, iva_importe, total)" //feb 1.9.1
            + " VALUES (@idFacturaDetalle, @idOrden, @importe, @idProducto, @idServicio, @cantidad, @precioUnitario, @idRenglon, @idFactura, @fechaCreacion, @codigo, @coche, @motivo_descuento, @descripcion, @iva_importe, @total);"; //feb 1.9.1

            string codigo = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio.ToString();

            //detalle del registro facturable
            string descripcion = String.Empty;
            string interno_aux = String.Empty;
            if (dataOrden.Interno.ToString().Length > 3)
            {
                interno_aux = dataOrden.Interno.ToString().Substring(dataOrden.Interno.ToString().Length - 3);
            }
            else
            {
                for (int i = 3; i > dataOrden.Interno.ToString().Length; i--)
                {
                    interno_aux += "0"; 
                }
                interno_aux += dataOrden.Interno.ToString();
            }

            if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar != 0)
            {
                decimal bon = decimal.Round(100 - dataOrden.Porcentaje_a_pagar, 2, MidpointRounding.AwayFromZero);
                string v_bon = String.Format("{0:0}", bon);
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento) + v_bon + "%";
            }
            if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar == 0)
            {
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento);
            }
            if (dataOrden.Motivo_descuento == "")
            {
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-" + interno_aux;
            }

            parameters.Add(new NpgsqlParameter("idFacturaDetalle", idFacturaDetalle));
            parameters.Add(new NpgsqlParameter("idOrden", dataOrden.Id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("importe", importe)); //pierdo precision
            parameters.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));
            parameters.Add(new NpgsqlParameter("idProducto", dataOrden.Id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", dataOrden.Id_servicio));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));
            parameters.Add(new NpgsqlParameter("idRenglon", dataOrden.Renglon));
            parameters.Add(new NpgsqlParameter("idFactura", dataOrden.Id_factura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("coche", dataOrden.Coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", dataOrden.Motivo_descuento));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            parameters.Add(new NpgsqlParameter("precioUnitario", precio_unitario)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("iva_importe", iva_importe)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("total", total)); //feb 1.9.1

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (dataOrden.Id_servicio_adicional != -1)
            {

                //id de nuevo detalle
                sql = "select nextval('ofc_factura_detalle_id_seq') idFacturaDet";

                NpgsqlDataReader dataAux = BaseDeDatos.ejecutarQuery(sql, cn);

                if (dataAux != null && dataAux.Read())
                {
                    idFacturaDetalleAdi = long.Parse(dataAux["idFacturaDet"].ToString());
                    dataAux.Close();
                }

                //si es tipo B calculo el iva dentro del importe, es decir no lo separo
                //feb 1.9.1
                if (tipoFactura == 'B')
                {
                    decimal iva_importe_adi_aux = (dataOrden.PrecioListaServAdicional * valorIva) / 100;
                    iva_importe_adi_aux = decimal.Round(iva_importe_adi_aux, 2, MidpointRounding.AwayFromZero);

                    precio_unitario_adi = dataOrden.PrecioListaServAdicional + iva_importe_adi_aux;
                    precio_unitario_adi = decimal.Round(precio_unitario_adi, 2, MidpointRounding.AwayFromZero);

                    decimal precio_unitario_aux = dataOrden.PrecioListaServAdicional - (dataOrden.PrecioListaServAdicional * (bonificacion / 100));
                    iva_importe = (precio_unitario_aux * valorIva) / 100;

                    importeAdi = precio_unitario_adi - (precio_unitario_adi * (bonificacion / 100));
                    importeAdi = decimal.Round(importeAdi, 2, MidpointRounding.AwayFromZero);

                    total_adi = importeAdi;
                    total_adi = decimal.Round(total_adi, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    precio_unitario_adi = dataOrden.PrecioListaServAdicional;

                    importeAdi = dataOrden.PrecioListaServAdicional - (dataOrden.PrecioListaServAdicional * (bonificacion / 100));
                    importeAdi = decimal.Round(importeAdi, 2, MidpointRounding.AwayFromZero);

                    iva_importe_adi = (iva_importe_adi * valorIva) / 100;
                    iva_importe_adi = decimal.Round(iva_importe_adi, 2, MidpointRounding.AwayFromZero);

                    total_adi = importeAdi + iva_importe_adi;
                    total_adi = decimal.Round(total_adi, 2, MidpointRounding.AwayFromZero);
                }

                //genero el detalle de la factura para el servicio adicional
                sql = "INSERT INTO ofc_factura_detalle("
                + " id, id_orden_de_trabajo, importe, id_producto, id_servicio, cantidad,"
                + " precio_unitario, id_renglon_orden_de_trabajo, id_factura, fecha_creacion, codigo, coche, motivo_descuento, descripcion, iva_importe, total)" //feb 1.9.1
                + " VALUES (@idFacturaDetalleAdi, @idOrden, @importeAdi, @idProducto, @idServicioAdicional, @cantidad, @precioUnitarioAdi, @idRenglon, @idFactura, @fechaCreacion, @codigoAdi, @coche, @motivo_descuento, @descripcionAdi, @iva_importe_adi, @total_adi);"; //feb 1.9.1

                string codigoAdi = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio_adicional.ToString();

                //detalle del registro facturable
                string descripcionAdi = String.Empty;
                if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar != 0)
                {
                    decimal bon = decimal.Round(100 - dataOrden.Porcentaje_a_pagar, 2, MidpointRounding.AwayFromZero);
                    string v_bon = String.Format("{0:0}", bon);
                    descripcionAdi = dataOrden.Id_orden_de_trabajo + "-";

                    if (dataOrden.Coche != "")
                    {
                        descripcionAdi = descripcionAdi + dataOrden.Coche + "-";
                    }

                    descripcionAdi = descripcionAdi + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Servicio_adicional + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento) + v_bon + "%";
                }
                if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar == 0)
                {

                    descripcionAdi = dataOrden.Id_orden_de_trabajo + "-";

                    if (dataOrden.Coche != "")
                    {
                        descripcionAdi = descripcionAdi + dataOrden.Coche + "-";
                    }

                    descripcionAdi = descripcionAdi + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Servicio_adicional + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento);
                }
                if (dataOrden.Motivo_descuento == "")
                {

                    descripcionAdi = dataOrden.Id_orden_de_trabajo + "-";

                    if (dataOrden.Coche != "")
                    {
                        descripcionAdi = descripcionAdi + dataOrden.Coche + "-";
                    }

                    descripcionAdi = descripcionAdi + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Servicio_adicional + "-" + interno_aux;
                }

                parameters.Add(new NpgsqlParameter("idServicioAdicional", dataOrden.Id_servicio_adicional));
                parameters.Add(new NpgsqlParameter("importeAdi", importeAdi));
                parameters.Add(new NpgsqlParameter("idFacturaDetalleAdi", idFacturaDetalleAdi));
                parameters.Add(new NpgsqlParameter("codigoAdi", codigoAdi));
                parameters.Add(new NpgsqlParameter("descripcionAdi", descripcionAdi));
                parameters.Add(new NpgsqlParameter("precioUnitarioAdi", precio_unitario_adi)); //feb 1.9.1
                parameters.Add(new NpgsqlParameter("iva_importe_adi", iva_importe_adi)); //feb 1.9.1
                parameters.Add(new NpgsqlParameter("total_adi", total_adi)); //feb 1.9.1

                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        private static void insertDetalleSinDesglose(OrdenDetalleDTO dataOrden)
        {
            long idFacturaDetalle = -1;
            decimal valorIva = Decimal.Zero;
            char tipoFactura = 'A';
            decimal importe = Decimal.Zero;
            int cantidad = 1;
            decimal precio_unitario = decimal.Zero; //feb 1.9.1
            decimal iva_importe = decimal.Zero; //feb 1.9.1
            decimal total = decimal.Zero; //feb 1.9.1
            decimal bonificacion = ComprobanteTempDTO.obtenerDescuento(dataOrden.Id_factura, "FACTURA"); //feb 1.9.1

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de factura detalle
            string sql = "select nextval('ofc_factura_detalle_id_seq') idFacturaDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFacturaDetalle = long.Parse(data["idFacturaDet"].ToString());
                data.Close();
            }

            //obtengo el iva
            //valorIva = ParametroDTO.obtenerParametroI("IVA");
            valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
            valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);

            //calculo el importe del item facturable segun el tipo de factura
            IList<NpgsqlParameter> parametersClie = new List<NpgsqlParameter>();
            sql = "select condicion.valor_adicional tipoFactura from ofc_cliente cliente, ofc_tabla_valor condicion";
            sql = sql + " where cliente.id_categoria_iva = condicion.id";
            sql = sql + " and cliente.id = @idCliente";
            sql = sql + " and cliente.activo = 'S'";

            parametersClie.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));

            NpgsqlDataReader dataTipoClie = BaseDeDatos.ejecutarQuery(sql, cn, parametersClie);

            if (dataTipoClie != null && dataTipoClie.Read())
            {
                tipoFactura = char.Parse(dataTipoClie["tipoFactura"].ToString());
                dataTipoClie.Close();
            }

            //si es tipo B calculo el iva dentro del importe, es decir no lo separo
            //feb 1.9.1
            if (tipoFactura == 'B')
            {
                decimal iva_importe_aux = (dataOrden.PrecioSIva * valorIva) / 100;
                iva_importe_aux = decimal.Round(iva_importe_aux, 2, MidpointRounding.AwayFromZero);

                precio_unitario = dataOrden.PrecioSIva + iva_importe_aux;
                precio_unitario = decimal.Round(precio_unitario, 2, MidpointRounding.AwayFromZero);

                importe = precio_unitario - (precio_unitario * (bonificacion / 100));
                importe = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);

                decimal precio_unitario_aux = dataOrden.PrecioSIva - (dataOrden.PrecioSIva * (bonificacion / 100));
                iva_importe = (precio_unitario_aux * valorIva) / 100;

                total = importe;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                precio_unitario = dataOrden.PrecioSIva;

                importe = dataOrden.PrecioSIva - (dataOrden.PrecioSIva * (bonificacion / 100));
                importe = decimal.Round(importe, 2, MidpointRounding.AwayFromZero);

                iva_importe = (importe * valorIva) / 100;
                iva_importe = decimal.Round(iva_importe, 2, MidpointRounding.AwayFromZero);

                total = importe + iva_importe;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }

            //genero el detalle de la factura
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_factura_detalle("
            + " id, id_orden_de_trabajo, importe, id_producto, id_servicio, cantidad,"
            + " precio_unitario, id_renglon_orden_de_trabajo, id_factura, fecha_creacion, codigo, coche, motivo_descuento, descripcion, iva_importe, total)" //feb 1.9.1
            + " VALUES (@idFacturaDetalle, @idOrden, @importe, @idProducto, @idServicio, @cantidad, @precioUnitario, @idRenglon, @idFactura, @fechaCreacion, @codigo, @coche, @motivo_descuento, @descripcion, @iva_importe, @total);"; //feb 1.9.1

            string codigo = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio.ToString();

            //detalle del registro facturable
            string descripcion = String.Empty;
            string interno_aux = String.Empty;
            if (dataOrden.Interno.ToString().Length > 3)
            {
                interno_aux = dataOrden.Interno.ToString().Substring(dataOrden.Interno.ToString().Length - 3);
            }
            else
            {
                for (int i = 3; i > dataOrden.Interno.ToString().Length; i--)
                {
                    interno_aux += "0";
                }
                interno_aux += dataOrden.Interno.ToString();
            }

            if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar != 0)
            {
                decimal bon = decimal.Round(100 - dataOrden.Porcentaje_a_pagar, 2, MidpointRounding.AwayFromZero);
                string v_bon = String.Format("{0:0}", bon);
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento) + v_bon + "%";
            }

            if (dataOrden.Motivo_descuento != "" && dataOrden.Porcentaje_a_pagar == 0)
            {
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-" + interno_aux + "-" + ValorDTO.obtenerValorAdicional("MF", dataOrden.Motivo_descuento);
            }

            if (dataOrden.Motivo_descuento == "")
            {
                descripcion = dataOrden.Id_orden_de_trabajo + "-";

                if (dataOrden.Coche != "")
                {
                    descripcion = descripcion + dataOrden.Coche + "-";
                }

                descripcion = descripcion + dataOrden.Medida_cubierta + "-" + dataOrden.Marca + "-" + dataOrden.Serie + "-" + dataOrden.Trabajo + "-";

                if (dataOrden.Servicio_adicional != "")
                {
                    descripcion = descripcion + dataOrden.Servicio_adicional + "-";
                }

                descripcion = descripcion + interno_aux;
            }

            parameters.Add(new NpgsqlParameter("idFacturaDetalle", idFacturaDetalle));
            parameters.Add(new NpgsqlParameter("idOrden", dataOrden.Id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("importe", importe)); //pierdo precision
            parameters.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));
            parameters.Add(new NpgsqlParameter("idProducto", dataOrden.Id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", dataOrden.Id_servicio));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));
            parameters.Add(new NpgsqlParameter("idRenglon", dataOrden.Renglon));
            parameters.Add(new NpgsqlParameter("idFactura", dataOrden.Id_factura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("coche", dataOrden.Coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", dataOrden.Motivo_descuento));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            parameters.Add(new NpgsqlParameter("precioUnitario", precio_unitario)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("iva_importe", iva_importe)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("total", total)); //feb 1.9.1

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void insertDetalle(OrdenDetalleDTO dataOrden)
        {
            if (dataOrden.Desglosar_serv_adi == 'S')
            {
                insertDetalleDesglosado(dataOrden);
            }
            else
            {
                insertDetalleSinDesglose(dataOrden);
            }
        }

        public static bool existeFacturaTemp(string idCliente)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante_temp c_temp, ofc_factura fact where c_temp.id_origen = fact.id and c_temp.comprobante = 'FACTURA' and fact.id_cliente = @idCliente";
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

        public static long getIdFacturaTemp(string idCliente)
        {
            long idFactura = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select c_temp.id_origen idFactura from ofc_comprobante_temp c_temp, ofc_factura fact where c_temp.id_origen = fact.id and c_temp.comprobante = 'FACTURA' and fact.id_cliente = @idCliente";
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idFactura;
        }

        //feb 1.7 el descuento lo completa al facturar
        //feb 1.9.1 refactor completo
        public static void cargarDatosFactPend()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnUpdate = BaseDeDatos.obtenerConexion();
            Decimal valorBonificacion = Decimal.Zero;
            Decimal sum_importe_neto = Decimal.Zero;
            Decimal sum_precio_unitario = Decimal.Zero;
            Decimal valorIva = Decimal.Zero;
            Decimal valorTotal = Decimal.Zero;

            string sql = "select a.id idFactura, a.iva105 iva105, e.valor_adicional condicionIva, d.nombre nombre, d.id_categoria_iva idIva, sum ((b.cantidad * b.precio_unitario)::double precision) precioUnitario, sum (b.importe::double precision) importe, sum (b.iva_importe::double precision) iva, sum (b.total::double precision) total"; //feb 1.9.1
            sql = sql + " from ofc_factura a, ofc_factura_detalle b, ofc_comprobante_temp c, ofc_cliente d, ofc_tabla_valor e";
            sql = sql + " where a.id = b.id_factura";
            sql = sql + " and c.id_origen = a.id";
            sql = sql + " and d.id = a.id_cliente";
            sql = sql + " and e.id = d.id_categoria_iva";
            sql = sql + " and d.activo = 'S'";
            sql = sql + " and c.comprobante = 'FACTURA'";
            sql = sql + " group by a.id, a.iva105, e.valor_adicional, d.nombre, d.id_categoria_iva";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            while (data != null && data.Read())
            {
                sum_importe_neto = decimal.Parse(data["importe"].ToString());
                sum_importe_neto = decimal.Round(sum_importe_neto, 2, MidpointRounding.AwayFromZero);

                sum_precio_unitario = decimal.Parse(data["precioUnitario"].ToString());
                sum_precio_unitario = decimal.Round(sum_precio_unitario, 2, MidpointRounding.AwayFromZero);

                valorBonificacion = sum_precio_unitario - sum_importe_neto;
                valorBonificacion = decimal.Round(valorBonificacion, 2, MidpointRounding.AwayFromZero);

                if (ValorDTO.obtenerValorAdicional(long.Parse(data["idIva"].ToString())) == "B")
                {
                    valorIva = decimal.Zero;
                }
                else
                {
                    valorIva = decimal.Parse(data["iva"].ToString());
                    valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                }

                valorTotal = decimal.Parse(data["total"].ToString());
                valorTotal = decimal.Round(valorTotal, 2, MidpointRounding.AwayFromZero);

                sql = "update ofc_factura";
                sql = sql + " set subtotal = @valorSubTotal,";
                sql = sql + " iva = @valorIva,";
                sql = sql + " bonificacion = @valorBonificacion,";
                sql = sql + " total = @valorTotal,";
                sql = sql + " nombre_cliente = @nombre";
                sql = sql + " where id = @idFactura; ";

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("valorSubTotal", sum_importe_neto));
                parameters.Add(new NpgsqlParameter("valorIva", valorIva));
                parameters.Add(new NpgsqlParameter("valorBonificacion", valorBonificacion));
                parameters.Add(new NpgsqlParameter("valorTotal", valorTotal));
                parameters.Add(new NpgsqlParameter("nombre", data["nombre"].ToString()));
                parameters.Add(new NpgsqlParameter("idFactura", data["idFactura"].ToString()));

                BaseDeDatos.ejecutarNonQuery(sql, cnUpdate, parameters);

            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnUpdate.State == System.Data.ConnectionState.Open)
                cnUpdate.Close();

        }

        public static void borrarFacturasTemp()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_factura_detalle where id_factura in (select id_origen from ofc_comprobante_temp where comprobante = 'FACTURA');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_factura where id in (select id_origen from ofc_comprobante_temp where comprobante = 'FACTURA');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_comprobante_temp where comprobante = 'FACTURA'";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void update_modo_temp(char soloFactura)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_factura set solo_factura = @soloFactura where id in (select id_origen from ofc_comprobante_temp where comprobante = 'FACTURA');";

            parameters.Add(new NpgsqlParameter("soloFactura", soloFactura));
            
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static long replicarFactura(FacturaDTO dataFact)
        {
            long idFactura = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            

            string sql = "select nextval('ofc_factura_id_seq') idFacturaNew";
            //nuevo id de factura
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFacturaNew"].ToString());
                data.Close();
            }

            parameters.Add(new NpgsqlParameter("idFactura", dataFact.Id));
            parameters.Add(new NpgsqlParameter("idFacturaNew", idFactura));

            //inserto la nueva factura
            sql = "INSERT INTO ofc_factura SELECT @idFacturaNew, subtotal, iva, total, fecha_creacion, nombre_cliente, bonificacion, id_cliente, pago, solo_factura, iva105";
            sql = sql + " FROM ofc_factura fac where fac.id = @idFactura";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //inserto el detalle nuevo
            sql = "INSERT INTO ofc_factura_detalle SELECT nextval('ofc_factura_detalle_id_seq'), id_orden_de_trabajo, importe, id_producto, id_servicio, cantidad, precio_unitario, id_renglon_orden_de_trabajo, @idFacturaNew, fecha_creacion, codigo, coche, motivo_descuento, descripcion, iva_importe, total"; //feb 1.9.2
            sql = sql + " FROM ofc_factura_detalle det where det.id_factura = @idFactura order by 1";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "FACTURA";
            comprobante.Id_origen = idFactura;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idFactura;

        }

        //feb 1.8
        public static decimal calcularImporte(string codComprobante)
        {
            decimal importe = decimal.Zero;

            string v_codComprobante = codComprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select v.valor tipoComprobante, c.id_origen idOrigen";
            sql = sql + " from ofc_comprobante c, ofc_tabla_valor v";
            sql = sql + " where c.id_tipo_comprobante = v.id";
            sql = sql + " and c.cod_comprobante = @codComprobante and c.anulado != 'S'";

            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                string tipo_comprobante = data["tipoComprobante"].ToString();
                long id_origen = long.Parse(data["idOrigen"].ToString());

                if (tipo_comprobante.IndexOf("FACTURA") != -1)
                {
                    NpgsqlConnection cn2 = BaseDeDatos.obtenerConexion();
                    sql = "select subtotal importe from ofc_factura where id = @idOrigen and pago != 'S'";
                    parameters.Add(new NpgsqlParameter("idOrigen", id_origen));

                    NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn2, parameters);

                    if (data2 != null && data2.Read())
                    {
                        if (data2["importe"] != null && data2["importe"] != DBNull.Value)
                        {
                            importe = decimal.Parse(data2["importe"].ToString());
                        }
                        data2.Close();
                    }

                    if (cn2.State == System.Data.ConnectionState.Open)
                        cn2.Close();

                }

                if (tipo_comprobante.IndexOf("NOTA DE DEBITO") != -1)
                {
                    NpgsqlConnection cn2 = BaseDeDatos.obtenerConexion();
                    sql = "select subtotal importe from ofc_nota_debito where id = @idOrigen and pago != 'S'";
                    parameters.Add(new NpgsqlParameter("idOrigen", id_origen));

                    NpgsqlDataReader data2 = BaseDeDatos.ejecutarQuery(sql, cn2, parameters);

                    if (data2 != null && data2.Read())
                    {
                        if (data2["importe"] != null && data2["importe"] != DBNull.Value)
                        {
                            importe = decimal.Parse(data2["importe"].ToString());
                        }
                        data2.Close();
                    }

                    if (cn2.State == System.Data.ConnectionState.Open)
                        cn2.Close();
                }

                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal calcularImporteFacturaA(string codComprobante)
        {
            decimal importe = decimal.Zero;

            string v_codComprobante = codComprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select a.subtotal importe";
            sql = sql + " from ofc_factura a, ofc_comprobante c, ofc_cliente d, ofc_tabla_valor e";
            sql = sql + " where c.id_origen = a.id";
            sql = sql + " and d.id = a.id_cliente";
            sql = sql + " and c.id_tipo_comprobante = e.id";
            sql = sql + " and c.anulado != 'S'";
            sql = sql + " and d.activo = 'S'";
            sql = sql + " and e.id_tabla = 'TC'";
            sql = sql + " and e.valor = 'FACTURA A'";
            sql = sql + " and c.cod_comprobante = @codComprobante";
            
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["importe"] != null && data["importe"] != DBNull.Value)
                {
                    importe = decimal.Parse(data["importe"].ToString());
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal calcularImporteFacturaB(string codComprobante)
        {
            decimal importe = decimal.Zero;
            decimal valorIva = decimal.Zero;
            //obtengo el iva
            //valorIva = ParametroDTO.obtenerParametroI("IVA");
            valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
            valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);

            string v_codComprobante = codComprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select a.subtotal importe";
            sql = sql + " from ofc_factura a, ofc_comprobante c, ofc_cliente d, ofc_tabla_valor e";
            sql = sql + " where c.id_origen = a.id";
            sql = sql + " and d.id = a.id_cliente";
            sql = sql + " and c.id_tipo_comprobante = e.id";
            sql = sql + " and c.anulado != 'S'";
            sql = sql + " and d.activo = 'S'";
            sql = sql + " and e.id_tabla = 'TC'";
            sql = sql + " and e.valor = 'FACTURA B'";
            sql = sql + " and c.cod_comprobante = @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal obtenerTotalFactura(string codComprobante)
        {
            decimal importe = decimal.Zero;
            string v_codComprobante = codComprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select a.total importe";
            sql = sql + " from ofc_factura a, ofc_comprobante c, ofc_cliente d, ofc_tabla_valor e";
            sql = sql + " where c.id_origen = a.id";
            sql = sql + " and d.id = a.id_cliente";
            sql = sql + " and d.activo = 'S'";
            sql = sql + " and c.id_tipo_comprobante = e.id";
            sql = sql + " and e.id_tabla = 'TC'";
            sql = sql + " and e.valor like 'FACTURA%'";
            sql = sql + " and c.cod_comprobante = @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["importe"] != null && data["importe"] != DBNull.Value)
                {
                    importe = decimal.Parse(data["importe"].ToString());
                }
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }


        public static string obtenerRemito(string codComprobanteFact)
        {
            string cod_comprobante_remito = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select c.cod_comprobante cod_comprobante";
            sql = sql + " from ofc_factura a, ofc_comprobante c, ofc_tabla_valor e";
            sql = sql + " where c.id_origen = a.id";
            sql = sql + " and c.id_tipo_comprobante = e.id";
            sql = sql + " and e.id_tabla = 'TC'";
            sql = sql + " and e.valor like 'REMITO%'";
            sql = sql + " and exists (select 1 from ofc_comprobante comp";
            sql = sql + " where comp.id_origen = c.id_origen and comp.cod_comprobante = @codComprobanteFact)";

            parameters.Add(new NpgsqlParameter("codComprobanteFact", codComprobanteFact));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["cod_comprobante"] != null && data["cod_comprobante"] != DBNull.Value) cod_comprobante_remito = data["cod_comprobante"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cod_comprobante_remito;
        }

        public static string obtenerFactura(string codComprobanteRem, long id_origen, string id_cliente) //feb 1.9.2
        {
            string cod_comprobante_factura = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select c.cod_comprobante cod_comprobante";
            sql = sql + " from ofc_factura a, ofc_comprobante c, ofc_tabla_valor e";
            sql = sql + " where c.id_origen = a.id";
            sql = sql + " and c.id_tipo_comprobante = e.id";
            sql = sql + " and e.id_tabla = 'TC'";
            sql = sql + " and e.valor like 'FACTURA%'";
            sql = sql + " and c.id_origen = @id_origen"; //feb 1.9.2
            sql = sql + " and c.id_cliente = @id_cliente";
            sql = sql + " and exists (select 1 from ofc_comprobante comp";
            sql = sql + " where comp.id_origen = c.id_origen and comp.cod_comprobante = @codComprobanteRem and c.id_cliente = comp.id_cliente)";

            parameters.Add(new NpgsqlParameter("codComprobanteRem", codComprobanteRem));
            parameters.Add(new NpgsqlParameter("id_origen", id_origen)); //feb 1.9.2
            parameters.Add(new NpgsqlParameter("id_cliente", id_cliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                if (data["cod_comprobante"] != null && data["cod_comprobante"] != DBNull.Value) cod_comprobante_factura = data["cod_comprobante"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cod_comprobante_factura;
        }

        //feb 1.9.1
        public static FacturaDTO obtenerComprobanteFW(long idFactura)
        {
            FacturaDTO factura = new FacturaDTO();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = " select comp.id_unico id_unico, factura.total total, factura.subtotal subtotal, factura.iva iva, factura.fecha_creacion fecha_creacion, cond_venta.id_externo id_condicion_venta_externo, factura.iva105 iva105, factura.id_cliente id_cliente, cliente.id_categoria_iva idIva";
            sql = sql + " from ofc_factura factura, ofc_cliente cliente, ofc_tabla_valor cond_venta,  ofc_comprobante_temp comp";
            sql = sql + " where cliente.id = factura.id_cliente";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and cond_venta.id_tabla = 'CV'";
            sql = sql + " and comp.id_origen = factura.id";
            sql = sql + " and comp.comprobante like 'FACTURA'";
            sql = sql + " and factura.id = @idFac";
            sql = sql + " and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idFac", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                factura.id_unico_comprobante = long.Parse(data["id_unico"].ToString());
                factura.total = decimal.Parse(data["total"].ToString());
                factura.total = decimal.Round(factura.total, 2, MidpointRounding.AwayFromZero);
                factura.fecha_creacion = DateTime.Parse(data["fecha_creacion"].ToString());
                factura.V_fecha_creacion = factura.fecha_creacion.ToString("yyyyMMdd");
                factura.fw_id_condicion_venta = int.Parse(data["id_condicion_venta_externo"].ToString());
                factura.iva105 = char.Parse(data["iva105"].ToString());

                if (factura.iva105 == 'S')
                {
                    if (ValorDTO.obtenerValorAdicional(long.Parse(data["idIva"].ToString())) == "B")
                    {
                        decimal valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_105"));
                        valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                        factura.subtotal = decimal.Round((factura.total / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                        factura.iva = factura.total - factura.subtotal;
                    }
                    else
                    {
                        factura.subtotal = decimal.Parse(data["subtotal"].ToString());
                        factura.iva = decimal.Parse(data["iva"].ToString());
                    }

                    factura.subtotal = decimal.Round(factura.subtotal, 2, MidpointRounding.AwayFromZero);
                    factura.iva = decimal.Round(factura.iva, 2, MidpointRounding.AwayFromZero);

                    factura.baseImp4 = factura.subtotal;
                    factura.impIVA4 = factura.iva;
                }
                else
                {
                    if (ValorDTO.obtenerValorAdicional(long.Parse(data["idIva"].ToString())) == "B")
                    {
                        decimal valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
                        valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                        factura.subtotal = decimal.Round((factura.total / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                        factura.iva = factura.total - factura.subtotal;
                    }
                    else
                    {
                        factura.subtotal = decimal.Parse(data["subtotal"].ToString());
                        factura.iva = decimal.Parse(data["iva"].ToString());
                    }

                    factura.subtotal = decimal.Round(factura.subtotal, 2, MidpointRounding.AwayFromZero);
                    factura.iva = decimal.Round(factura.iva, 2, MidpointRounding.AwayFromZero);

                    factura.baseImp5 = factura.subtotal;
                    factura.impIVA5 = factura.iva;
                }

                factura.id_cliente = data["id_cliente"].ToString();
                factura.fw_concepto = int.Parse(ValorDTO.obtenerValorAdicional("FW", "comprobante/comprobanteDetalle/concepto"));

                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return factura;
        }

        //feb 1.9.1
        public static int obtenerCantidadDeConceptos(long id_origen)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            int cantidad = -1;

            //obtener cantidad de registros
            string sql = "select count(1) cantidad from ofc_factura_detalle where id_factura = @id_origen";

            parameters.Add(new NpgsqlParameter("id_origen", id_origen));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                cantidad = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cantidad;
        }


    }



}

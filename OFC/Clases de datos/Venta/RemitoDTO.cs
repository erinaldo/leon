using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class RemitoDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        string cod_comprobante_factura;

        public string Cod_comprobante_factura
        {
            get { return cod_comprobante_factura; }
            set { cod_comprobante_factura = value; }
        }

        string cod_comprobante_remito;

        public string Cod_comprobante_remito
        {
            get { return cod_comprobante_remito; }
            set { cod_comprobante_remito = value; }
        }

        string condicion_venta;

        public string Condicion_venta
        {
            get { return condicion_venta; }
            set { condicion_venta = value; }
        }

        //feb 1.9.1
        char tipo_registro;

        public char Tipo_registro
        {
            get { return tipo_registro; }
            set { tipo_registro = value; }
        }

        public RemitoDTO()
        {
            id = -1;
            fecha_creacion = DateTime.Now;
            nombre_cliente = String.Empty;
            id_cliente = String.Empty;
            nro_remito = -1;
            nro_factura = -1;
            direccion = String.Empty;
            localidad = String.Empty;
            cuit = String.Empty;
            categoria_iva = String.Empty;
            cod_comprobante_factura = String.Empty;
            cod_comprobante_remito = String.Empty;
            condicion_venta = String.Empty;
            tipo_registro = 'T'; //T: temportal P: permanente //feb 1.9.1
        }

        public static string obtenerCodCliente(string cod_comprobante)
        {
            string idCliente = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select rem.id_cliente idCliente from ofc_remito rem where rem.cod_comprobante = @cod_comprobante";
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCliente = data["idCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idCliente;
        }

        //version 1.5
        public static string[] obtenerCodYNomCliente(string cod_comprobante)
        {
            string[] datosCliente = new string[]{string.Empty, string.Empty};

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select rem.id_cliente idCliente, rem.nombre_cliente nombreCliente from ofc_remito rem where rem.cod_comprobante = @cod_comprobante";
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                datosCliente[0] = data["idCliente"].ToString();
                datosCliente[1] = data["nombreCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return datosCliente;
        }

        //feb 1.6 FIX
        public static List<OrdenDetalleDTO> obtenerDetalleOrdenesHist(string codComprobanteRemito)
        {
            List<OrdenDetalleDTO> lista = new List<OrdenDetalleDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();


            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioT = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnPrecioA = BaseDeDatos.obtenerConexion();

            string sql = "select distinct ord.id_cliente idCliente, det.id_orden_de_trabajo id, det.renglon renglon, det.coche coche, prod.medida_cubierta medida, det.serie serie, serv.descripcion trabajo, serv2.descripcion adicional,";
            sql = sql + " det.id_marca idMarca, det.id_servicio idServicio, det.id_servicio_adicional idServAdicional, det.id_producto idProducto, det.porcentaje_a_pagar porcentaje, det.interno interno, ord.nombre_cliente nombreCliente, ord.fecha fecha, det.motivo_descuento motivoDescuento, val.valor marca, det.desglosar_serv_adi desglose, rem.id idRemito";
            sql = sql + " from ofc_producto prod, ofc_servicio serv, ofc_orden_de_trabajo_hist ord, ofc_remito rem, ofc_remito_detalle remd, ofc_tabla_valor val, ofc_orden_de_trabajo_detalle_hist det left join ofc_servicio serv2";
            sql = sql + " on det.id_servicio_adicional = serv2.id";
            sql = sql + " where prod.id = det.id_producto";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and ord.id = det.id_orden_de_trabajo";
            sql = sql + " and val.id = det.id_marca";
            sql = sql + " and rem.id = remd.id_remito";
            sql = sql + " and val.id_tabla = 'MA'";
            sql = sql + " and remd.id_orden_de_trabajo = det.id_orden_de_trabajo";
            sql = sql + " and remd.id_renglon_orden_de_trabajo = det.renglon";
            sql = sql + " and rem.cod_comprobante = @codComprobante";
            sql = sql + " and not exists (select 1 from ofc_factura_detalle fdet, ofc_comprobante comp, ofc_tabla_valor val where comp.id_origen = fdet.id_factura and comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor like 'FACTURA%' and fdet.id_orden_de_trabajo = det.id_orden_de_trabajo and fdet.id_renglon_orden_de_trabajo = det.renglon and comp.anulado = 'N')";
            sql = sql + " and not exists (select 1 from ofc_comprobante_temp c_temp where c_temp.id_origen = rem.id and c_temp.comprobante = 'REMITO')";            
            sql = sql + " order by 2, 3";

            parameters.Add(new NpgsqlParameter("codComprobante", codComprobanteRemito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataPrecioT = null;
            NpgsqlDataReader dataPrecioA = null;

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                OrdenDetalleDTO e = new OrdenDetalleDTO();

                e.Id_orden_de_trabajo = long.Parse(data["id"].ToString());
                e.Renglon = int.Parse(data["renglon"].ToString());
                e.Coche = data["coche"].ToString();
                e.Medida_cubierta = data["medida"].ToString();
                e.Serie = data["serie"].ToString();
                e.Trabajo = data["trabajo"].ToString();
                e.Servicio_adicional = data["adicional"].ToString();
                e.Interno = long.Parse(data["interno"].ToString());
                e.Porcentaje_a_pagar = decimal.Parse(data["porcentaje"].ToString());
                e.Id_marca = long.Parse(data["idMarca"].ToString());
                e.Id_servicio = long.Parse(data["idServicio"].ToString());
                if (data["idServAdicional"] != null && data["idServAdicional"] != DBNull.Value)
                    e.Id_servicio_adicional = long.Parse(data["idServAdicional"].ToString());
                e.Id_producto = long.Parse(data["idProducto"].ToString());
                e.Id_cliente = data["idCliente"].ToString();
                e.Nombre_cliente = data["nombreCliente"].ToString();
                e.Fecha = DateTime.Parse(data["fecha"].ToString());
                if (data["motivoDescuento"] != null && data["motivoDescuento"] != DBNull.Value)
                    e.Motivo_descuento = data["motivoDescuento"].ToString();
                e.Marca = data["marca"].ToString();
                e.Desglosar_serv_adi = char.Parse(data["desglose"].ToString());
                e.Id_remito = long.Parse(data["idRemito"].ToString());

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrden", e.Id_orden_de_trabajo));
                parameters.Add(new NpgsqlParameter("fila", e.Renglon));

                sql = "select precio.valor precioTrabajo, cliente.factura_por_coche xCoche";
                sql = sql + " from ofc_orden_de_trabajo_hist ord, ofc_cliente cliente,";
                sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle_hist det";
                sql = sql + " where precio.id_servicio = det.id_servicio ";
                sql = sql + " and precio.id_producto = det.id_producto";
                sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                sql = sql + " and ord.id_cliente = cliente.id";
                sql = sql + " and ord.id = det.id_orden_de_trabajo";
                sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                sql = sql + " and det.renglon = @fila";
                sql = sql + " and cliente.activo = 'S'";

                dataPrecioT = BaseDeDatos.ejecutarQuery(sql, cnPrecioT, parameters);

                while (dataPrecioT != null && dataPrecioT.Read())
                {
                    e.PrecioLista = (Decimal.Parse(dataPrecioT["precioTrabajo"].ToString()) * e.Porcentaje_a_pagar) / 100;
                    e.PrecioLista = decimal.Round(e.PrecioLista, 2, MidpointRounding.AwayFromZero);

                    e.V_precioLista = String.Format("{0:0.00}", e.PrecioLista);

                    e.Factura_por_coche = char.Parse(dataPrecioT["xCoche"].ToString());
                }

                //si hay servicio adicional calculo el precio
                if (e.Servicio_adicional != "")
                {
                    sql = "select precio.valor precioAdicional";
                    sql = sql + " from ofc_orden_de_trabajo_hist ord, ofc_cliente cliente,";
                    sql = sql + " ofc_precio precio, ofc_tabla_valor listaDePrecio, ofc_orden_de_trabajo_detalle_hist det";
                    sql = sql + " where precio.id_servicio = det.id_servicio_adicional";
                    sql = sql + " and precio.id_producto = det.id_producto";
                    sql = sql + " and precio.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and ord.id_cliente = cliente.id";
                    sql = sql + " and ord.id = det.id_orden_de_trabajo";
                    sql = sql + " and cliente.id_lista_precio = listaDePrecio.id";
                    sql = sql + " and det.id_orden_de_trabajo = @idOrden";
                    sql = sql + " and det.renglon = @fila";
                    sql = sql + " and cliente.activo = 'S'";

                    dataPrecioA = BaseDeDatos.ejecutarQuery(sql, cnPrecioA, parameters);

                    while (dataPrecioA != null && dataPrecioA.Read())
                    {
                        e.PrecioListaServAdicional = (Decimal.Parse(dataPrecioA["precioAdicional"].ToString()) * e.Porcentaje_a_pagar) / 100;
                        e.PrecioListaServAdicional = decimal.Round(e.PrecioListaServAdicional, 2, MidpointRounding.AwayFromZero);

                        e.V_precioListaServAdicional = String.Format("{0:0.00}", e.PrecioListaServAdicional);
                    }
                }


                e.PrecioSIva = e.PrecioLista + e.PrecioListaServAdicional;
                e.PrecioSIva = decimal.Round(e.PrecioSIva, 2, MidpointRounding.AwayFromZero);

                e.V_precioSIva = String.Format("{0:0.00}", e.PrecioSIva);

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (dataPrecioT != null)
                dataPrecioT.Close();

            if (dataPrecioA != null)
                dataPrecioA.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnPrecioT.State == System.Data.ConnectionState.Open)
                cnPrecioT.Close();

            if (cnPrecioA.State == System.Data.ConnectionState.Open)
                cnPrecioA.Close();

            return lista;

        }

        public static List<RemitoDTO> obtenerRemitoReg(long idRemito) 
        {
            List<RemitoDTO> lista = new List<RemitoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select remito.id idRemito, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, cond_venta.valor condicionVenta, remito.cod_comprobante cod_comprobante";
            sql = sql + " from ofc_remito remito, ofc_cliente cliente, ofc_tabla_valor condicion,  ofc_tabla_valor cond_venta";
            sql = sql + " where cliente.id = remito.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and remito.id = @idRem";
            sql = sql + " and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idRem", idRemito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                RemitoDTO e = new RemitoDTO();

                e.id = long.Parse(data["idRemito"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.id_cliente = data["idCliente"].ToString();
                e.cuit = data["cuitCliente"].ToString();
                e.condicion_venta = data["condicionVenta"].ToString();
                e.cod_comprobante_remito = data["cod_comprobante"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        //feb 1.9.1
        public static void setRemitoPermanente(long id)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_remito set tipo_registro = 'P'"
            + " where id = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void updateCodRemito(long id, string cod_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_remito set cod_comprobante = @cod_comprobante"
            + " where id = @id";

            parameters.Add(new NpgsqlParameter("id", id));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<RemitoDTO> obtenerRemitosTemp()
        {
            List<RemitoDTO> lista = new List<RemitoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            int contadorRem = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlConnection cnRem = BaseDeDatos.obtenerConexion();

            string sql = "select remito.id idRemito, cliente.nombre nombreCliente, cliente.direccion_legal direccion, cliente.localidad_legal localidad, condicion.valor categoriaIva, cliente.id idCliente, cliente.cuit cuitCliente, cond_venta.valor condicionVenta";
            sql = sql + " from ofc_remito remito, ofc_comprobante_temp c_temp, ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor cond_venta";
            sql = sql + " where remito.id = c_temp.id_origen";
            sql = sql + " and cliente.id = remito.id_cliente";
            sql = sql + " and condicion.id = cliente.id_categoria_iva";
            sql = sql + " and cond_venta.id = cliente.id_condicion_venta";
            sql = sql + " and c_temp.comprobante = 'REMITO'";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " and c_temp.usuario = @login";
            sql = sql + " order by remito.fecha_creacion";

            parameters.Add(new NpgsqlParameter("login", Usuario.GetInstance().Login));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            NpgsqlDataReader dataRem = null;

            while (data != null && data.Read())
            {
                RemitoDTO e = new RemitoDTO();

                e.id = long.Parse(data["idRemito"].ToString());
                e.id_cliente = data["idCliente"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.nombre_cliente = data["nombreCliente"].ToString();
                e.id_cliente = data["idCliente"].ToString();
                e.cuit = data["cuitCliente"].ToString();
                e.condicion_venta = data["condicionVenta"].ToString();

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
                
                //hay que actualizar en la base el incremento del numero

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (cnRem.State == System.Data.ConnectionState.Open)
                cnRem.Close();

            return lista;
        }

        public static List<RemitoDTO> obtenerRemitosSinFactura()
        {
            List<RemitoDTO> lista = new List<RemitoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select remito.cod_comprobante cod_comprobante";
            sql = sql + " from ofc_remito remito";
            sql = sql + " where not exists (select 1 from ofc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.cod_comprobante = remito.cod_comprobante";
            sql = sql + " and val.id = comp.id_tipo_comprobante";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor = 'REMITO'";
            sql = sql + " and comp.id_origen = -1)";
            sql = sql + " and remito.tipo_registro = 'T'"; //feb 1.9.1
            sql = sql + " order by 1";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                RemitoDTO e = new RemitoDTO();
                e.cod_comprobante_remito = data["cod_comprobante"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        //feb 1.9.1
        public static long insert(FacturaManualDTO registro)
        {
            long idRemito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('ofc_remito_id_seq') idRemito";
            //nuevo id de remito
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemito = long.Parse(data["idRemito"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero remito
            sql = "INSERT INTO ofc_remito("
            + " id, fecha_creacion,"
            + " nombre_cliente, id_cliente, cod_comprobante, tipo_registro)" //feb 1.9.1
            + " VALUES (@idRemito, @fechaCreacion, @nombreCliente, @idCliente, '', 'P');"; //feb 1.9.1. Siempre que inserto un registro manual, es permanente en esta tabla

            parameters.Add(new NpgsqlParameter("idRemito", idRemito));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("nombreCliente", registro.Nombre_cliente));
            parameters.Add(new NpgsqlParameter("idCliente", registro.Id_cliente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "REMITO";
            comprobante.Id_origen = idRemito;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idRemito;

        }

        public static long insert(OrdenDetalleDTO dataOrden)
        {
            long idRemito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('ofc_remito_id_seq') idRemito";
            //nuevo id de remito
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemito = long.Parse(data["idRemito"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero remito
            sql = "INSERT INTO ofc_remito("
            + " id, fecha_creacion,"
            + " nombre_cliente, id_cliente, cod_comprobante, usuario_creacion, tipo_registro)" //feb 1.9.1
            + " VALUES (@idRemito, @fechaCreacion, @nombreCliente, @idCliente, '', @usuario_creacion, 'T');"; //feb 1.9.1. Siempre que inserto una orden es temporal

            parameters.Add(new NpgsqlParameter("idRemito", idRemito));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("nombreCliente", dataOrden.Nombre_cliente));
            parameters.Add(new NpgsqlParameter("idCliente", dataOrden.Id_cliente));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "REMITO";
            comprobante.Id_origen = idRemito;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idRemito;

        }


        private static void insertDetalleSinDesglose(OrdenDetalleDTO dataOrden)
        {
            long idRemitoDetalle = -1;
            int cantidad = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de remito detalle
            string sql = "select nextval('ofc_remito_detalle_id_seq') idRemitoDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemitoDetalle = long.Parse(data["idRemitoDet"].ToString());
                data.Close();
            }

            //genero el detalle del remito
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_remito_detalle("
            + " id, id_remito, id_orden_de_trabajo, id_renglon_orden_de_trabajo, fecha_creacion, cantidad,"
            + " codigo, descripcion)"
            + " VALUES (@idRemitoDetalle, @idRemito, @idOrden, @idRenglon, @fechaCreacion, @cantidad, @codigo, @descripcion);";

            string codigo = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio.ToString();

            //detalle del registro
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

            parameters.Add(new NpgsqlParameter("idRemitoDetalle", idRemitoDetalle));
            parameters.Add(new NpgsqlParameter("idRemito", dataOrden.Id_remito));
            parameters.Add(new NpgsqlParameter("idOrden", dataOrden.Id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("idRenglon", dataOrden.Renglon));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        private static void insertDetalleDesglosado(OrdenDetalleDTO dataOrden)
        {
            long idRemitoDetalle = -1;
            long idRemitoDetalleAdi = -1;
            int cantidad = 1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de remito detalle
            string sql = "select nextval('ofc_remito_detalle_id_seq') idRemitoDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemitoDetalle = long.Parse(data["idRemitoDet"].ToString());
                data.Close();
            }

            //genero el detalle del remito
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_remito_detalle("
            + " id, id_remito, id_orden_de_trabajo, id_renglon_orden_de_trabajo, fecha_creacion, cantidad,"
            + " codigo, descripcion)"
            + " VALUES (@idRemitoDetalle, @idRemito, @idOrden, @idRenglon, @fechaCreacion, @cantidad, @codigo, @descripcion);";

            string codigo = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio.ToString();

            //detalle del registro
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

            parameters.Add(new NpgsqlParameter("idRemitoDetalle", idRemitoDetalle));
            parameters.Add(new NpgsqlParameter("idRemito", dataOrden.Id_remito));
            parameters.Add(new NpgsqlParameter("idOrden", dataOrden.Id_orden_de_trabajo));
            parameters.Add(new NpgsqlParameter("idRenglon", dataOrden.Renglon));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("cantidad", cantidad));
            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (dataOrden.Id_servicio_adicional != -1)
            {

                //id de nuevo detalle
                sql = "select nextval('ofc_remito_detalle_id_seq') idRemitoDet";

                NpgsqlDataReader dataAux = BaseDeDatos.ejecutarQuery(sql, cn);

                if (dataAux != null && dataAux.Read())
                {
                    idRemitoDetalleAdi = long.Parse(dataAux["idRemitoDet"].ToString());
                    dataAux.Close();
                }

                //genero el detalle del remito para el servicio adicional
                sql = "INSERT INTO ofc_remito_detalle("
                + " id, id_remito, id_orden_de_trabajo, id_renglon_orden_de_trabajo, fecha_creacion, cantidad,"
                + " codigo, descripcion)"
                + " VALUES (@idRemitoDetalleAdi, @idRemito, @idOrden, @idRenglon, @fechaCreacion, @cantidad, @codigoAdi, @descripcionAdi);";

                string codigoAdi = dataOrden.Id_producto.ToString() + "A" + dataOrden.Id_servicio_adicional.ToString();

                //detalle del registro
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

                parameters.Add(new NpgsqlParameter("idRemitoDetalleAdi", idRemitoDetalleAdi));
                parameters.Add(new NpgsqlParameter("codigoAdi", codigoAdi));
                parameters.Add(new NpgsqlParameter("descripcionAdi", descripcionAdi));

                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.9.1
        public static void insertDetalle(FacturaManualDTO registro)
        {
            long idRemitoDetalle = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de remito detalle
            string sql = "select nextval('ofc_remito_detalle_id_seq') idRemitoDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemitoDetalle = long.Parse(data["idRemitoDet"].ToString());
                data.Close();
            }

            //genero el detalle del remito
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_remito_detalle("
            + " id, id_remito, id_orden_de_trabajo, id_renglon_orden_de_trabajo, fecha_creacion, cantidad,"
            + " codigo, descripcion)"
            + " VALUES (@idRemitoDetalle, @idRemito, @idOrden, @idRenglon, @fechaCreacion, @cantidad, @codigo, @descripcion);";

            parameters.Add(new NpgsqlParameter("idRemitoDetalle", idRemitoDetalle));
            parameters.Add(new NpgsqlParameter("idRemito", registro.Id_remito));
            parameters.Add(new NpgsqlParameter("idOrden", -1));
            parameters.Add(new NpgsqlParameter("idRenglon", -1));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("cantidad", registro.Cantidad));
            parameters.Add(new NpgsqlParameter("codigo", registro.Codigo));
            parameters.Add(new NpgsqlParameter("descripcion", registro.Descripcion));

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

        public static bool existeRemitoTemp(string idCliente)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante_temp c_temp, ofc_remito rem where c_temp.id_origen = rem.id and c_temp.comprobante = 'REMITO' and rem.id_cliente = @idCliente";
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

        public static bool existeRemitoSinFactura(string cod_cliente, string cod_comprobante)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_remito rem where rem.id_cliente = @cod_cliente";

            if (cod_comprobante != "")
            {
                sql = sql + " and rem.cod_comprobante = @cod_comprobante";
            }

            parameters.Add(new NpgsqlParameter("cod_cliente", cod_cliente));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

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


        //public static bool existeRemitoSinFactura(string cod_cliente, string cod_comprobante)
        //{
        //    int count = 0;
        //    NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
        //    IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

        //    string sql = "select count(1) as cantidad from ofc_remito rem where rem.id_cliente = @cod_cliente and rem.tipo_registro = 'T'";
        //    sql += " and not exists (select 1 from ofc_comprobante b where rem.id = b.id_origen and rem.cod_comprobante = b.cod_comprobante)";
            
        //    if (cod_comprobante != "")
        //    {
        //        sql = sql + " and rem.cod_comprobante = @cod_comprobante";
        //    }

        //    parameters.Add(new NpgsqlParameter("cod_cliente", cod_cliente));
        //    parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

        //    NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

        //    if (data != null && data.Read())
        //    {
        //        count = int.Parse(data["cantidad"].ToString());
        //        data.Close();
        //    }

        //    if (cn.State == System.Data.ConnectionState.Open)
        //        cn.Close();

        //    return (count != 0);
        //}

        public static bool existeRemitoSinFactura(string cod_comprobante)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_remito rem where rem.cod_comprobante = @cod_comprobante";

            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

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

        //feb 1.9.2
        public static bool existeRemitoSinFacturaTemporal(string cod_comprobante)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_remito rem where rem.cod_comprobante = @cod_comprobante and rem.tipo_registro = 'T'";

            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

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

        //feb 1.9.2
        public static bool existeRemitoSinFacturaPermanente(string cod_comprobante)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_remito rem where rem.cod_comprobante = @cod_comprobante and rem.tipo_registro = 'P'";

            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

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

        public static long getIdRemitoTemp(string idCliente)
        {
            long idRemito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select c_temp.id_origen idRemito from ofc_comprobante_temp c_temp, ofc_remito rem where c_temp.id_origen = rem.id and c_temp.comprobante = 'REMITO' and rem.id_cliente = @idCliente";
            parameters.Add(new NpgsqlParameter("idCliente", idCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idRemito = long.Parse(data["idRemito"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idRemito;
        }

        public static string getComprobanteTemp()
        {
            string codRemito = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select rem.cod_comprobante cod_comprobante from ofc_comprobante_temp c_temp, ofc_remito rem where c_temp.id_origen = rem.id and c_temp.comprobante = 'REMITO'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                codRemito =data["cod_comprobante"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return codRemito;
        }

        public static void borrarRemitoTemp()
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "delete from ofc_remito_detalle where id_remito in (select id_origen from ofc_comprobante_temp where comprobante = 'REMITO');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_remito where id in (select id_origen from ofc_comprobante_temp where comprobante = 'REMITO');";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            sql = "delete from ofc_comprobante_temp where comprobante = 'REMITO';";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static long replicarRemito(RemitoDTO dataRem)
        {
            long idRemito = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();


            string sql = "select nextval('ofc_remito_id_seq') idRemitoNew";
            //nuevo id de remito
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idRemito = long.Parse(data["idRemitoNew"].ToString());
                data.Close();
            }

            parameters.Add(new NpgsqlParameter("idRemito", dataRem.Id));
            parameters.Add(new NpgsqlParameter("idRemitoNew", idRemito));

            //inserto la nuevo remito
            sql = "INSERT INTO ofc_remito SELECT @idRemitoNew, fecha_creacion, nombre_cliente, id_cliente, '', tipo_registro, usuario_creacion"; //feb 1.9.1
            sql = sql + " FROM ofc_remito rem where rem.id = @idRemito";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            //inserto el detalle nuevo
            sql = "INSERT INTO ofc_remito_detalle SELECT nextval('ofc_remito_detalle_id_seq'), @idRemitoNew, id_orden_de_trabajo, id_renglon_orden_de_trabajo, fecha_creacion, cantidad, codigo, descripcion";
            sql = sql + " FROM ofc_remito_detalle det where det.id_remito = @idRemito order by 1";

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            //genero comprobante temporal
            ComprobanteTempDTO comprobante = new ComprobanteTempDTO();
            comprobante.Comprobante = "REMITO";
            comprobante.Id_origen = idRemito;

            ComprobanteTempDTO.insertarTemporal(comprobante, decimal.Zero); //feb 1.9.1

            return idRemito;

        }


    }
}

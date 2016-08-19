using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    public class FacturaDeCompraDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        decimal subtotal_neto;

        public decimal Subtotal_neto
        {
            get { return subtotal_neto; }
            set { subtotal_neto = value; }
        }

        decimal iva;

        public decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        decimal impuestos;

        public decimal Impuestos
        {
            get { return impuestos; }
            set { impuestos = value; }
        }

        decimal total;

        public decimal Total
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

        string id_proveedor;

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        string nombre_proveedor;

        public string Nombre_proveedor
        {
            get { return nombre_proveedor; }
            set { nombre_proveedor = value; }
        }

        string cuit_proveedor;

        public string Cuit_proveedor
        {
            get { return cuit_proveedor; }
            set { cuit_proveedor = value; }
        }

        long id_tipo_asiento;

        public long Id_tipo_asiento
        {
            get { return id_tipo_asiento; }
            set { id_tipo_asiento = value; }
        }

        decimal redondeo;

        public decimal Redondeo
        {
            get { return redondeo; }
            set { redondeo = value; }
        }

        char es_concepto;

        public char Es_concepto
        {
            get { return es_concepto; }
            set { es_concepto = value; }
        }

        char es_definitiva;

        public char Es_definitiva
        {
            get { return es_definitiva; }
            set { es_definitiva = value; }
        }

        char tipo_factura;

        public char Tipo_factura
        {
            get { return tipo_factura; }
            set { tipo_factura = value; }
        }

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        DateTime fecha_vencimiento;

        public DateTime Fecha_vencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }

        string v_fecha_vencimiento;

        public string V_fecha_vencimiento
        {
            get { return v_fecha_vencimiento; }
            set { v_fecha_vencimiento = value; }
        }

        bool tiene_vencimiento;

        public bool Tiene_vencimiento
        {
            get { return tiene_vencimiento; }
            set { tiene_vencimiento = value; }
        }

        decimal subtotal_neto_exento;

        public decimal Subtotal_neto_exento
        {
            get { return subtotal_neto_exento; }
            set { subtotal_neto_exento = value; }
        }

        char pago;

        public char Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        string v_subtotal_neto_exento;

        public string V_subtotal_neto_exento
        {
            get { return v_subtotal_neto_exento; }
            set { v_subtotal_neto_exento = value; }
        }

        string v_subtotal_neto;

        public string V_subtotal_neto
        {
            get { return v_subtotal_neto; }
            set { v_subtotal_neto = value; }
        }

        string v_iva;

        public string V_iva
        {
            get { return v_iva; }
            set { v_iva = value; }
        }

        string v_impuesto;

        public string V_impuesto
        {
            get { return v_impuesto; }
            set { v_impuesto = value; }
        }

        string v_redondeo;

        public string V_redondeo
        {
            get { return v_redondeo; }
            set { v_redondeo = value; }
        }

        string v_total;

        public string V_total
        {
            get { return v_total; }
            set { v_total = value; }
        }

        string categoria_iva;

        public string Categoria_iva
        {
            get { return categoria_iva; }
            set { categoria_iva = value; }
        }

        DateTime fecha_comprobante;

        public DateTime Fecha_comprobante
        {
            get { return fecha_comprobante; }
            set { fecha_comprobante = value; }
        }

        DateTime fecha_contable;

        public DateTime Fecha_contable
        {
            get { return fecha_contable; }
            set { fecha_contable = value; }
        }

        decimal importe_de_pago;

        public decimal Importe_de_pago
        {
            get { return importe_de_pago; }
            set { importe_de_pago = value; }
        }

        string v_importe_de_pago;

        public string V_importe_de_pago
        {
            get { return v_importe_de_pago; }
            set { v_importe_de_pago = value; }
        }

        decimal importe_pagado;

        public decimal Importe_pagado
        {
            get { return importe_pagado; }
            set { importe_pagado = value; }
        }

        string v_importe_pagado;

        public string V_importe_pagado
        {
            get { return v_importe_pagado; }
            set { v_importe_pagado = value; }
        }

        decimal importe_pagado_acumulado;

        public decimal Importe_pagado_acumulado
        {
            get { return importe_pagado_acumulado; }
            set { importe_pagado_acumulado = value; }
        }

        decimal importe_adeudado_actualizado;

        public decimal Importe_adeudado_actualizado
        {
            get { return importe_adeudado_actualizado; }
            set { importe_adeudado_actualizado = value; }
        }

        decimal importe_adeudado;

        public decimal Importe_adeudado
        {
            get { return importe_adeudado; }
            set { importe_adeudado = value; }
        }

        string v_importe_adeudado;

        public string V_importe_adeudado
        {
            get { return v_importe_adeudado; }
            set { v_importe_adeudado = value; }
        }

        char pago_parcial;

        public char Pago_parcial
        {
            get { return pago_parcial; }
            set { pago_parcial = value; }
        }

        string tipo_comprobante;

        public string Tipo_comprobante
        {
            get { return tipo_comprobante; }
            set { tipo_comprobante = value; }
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

        string condicion_compra;

        public string Condicion_compra
        {
            get { return condicion_compra; }
            set { condicion_compra = value; }
        }

        public FacturaDeCompraDTO()
        {
            id = -1;
            subtotal_neto = decimal.Zero;
            iva = decimal.Zero;
            impuestos = decimal.Zero;
            total = decimal.Zero;
            fecha_creacion = DateTime.Now;
            fecha_vencimiento = DateTime.Now; //no me gusta:(
            id_proveedor = string.Empty;
            nombre_proveedor = string.Empty;
            id_tipo_asiento = -1;
            redondeo = decimal.Zero;
            es_concepto = 'N';
            es_definitiva = 'N';
            tipo_factura = 'N';
            cod_comprobante = string.Empty;
            tiene_vencimiento = false;
            subtotal_neto_exento = decimal.Zero;
            pago = 'N';
            v_total = string.Empty;
            cuit_proveedor = string.Empty;
            categoria_iva = string.Empty;
            fecha_comprobante = DateTime.Now;
            fecha_contable = DateTime.Now;
            importe_de_pago = decimal.Zero;
            v_importe_de_pago = string.Empty;
            importe_pagado = decimal.Zero;
            v_importe_pagado = string.Empty;
            importe_pagado_acumulado = decimal.Zero;
            importe_adeudado_actualizado = decimal.Zero;
            importe_adeudado = decimal.Zero;
            v_importe_adeudado = string.Empty;
            pago_parcial = 'N';
            tipo_comprobante = string.Empty;
            direccion = string.Empty;
            localidad = string.Empty;
            cuit = string.Empty;
            condicion_compra = string.Empty;
            v_subtotal_neto_exento = string.Empty;
            v_subtotal_neto = string.Empty;
            v_redondeo = string.Empty;
            v_iva = string.Empty;
            v_impuesto = string.Empty;
            v_fecha_vencimiento = string.Empty;
        }

        public static long insert(FacturaDeCompraDTO dataFact)
        {
            long idFactura = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('cpc_factura_id_seq') idFactura";
            //nuevo id de factura
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero factura
            sql = "INSERT INTO cpc_factura("
            + " id, subtotal_neto, iva, impuestos, total, fecha_creacion, id_proveedor, nombre_proveedor, id_tipo_asiento, "
            + " redondeo, es_concepto, es_definitiva, tipo_factura, fecha_vencimiento, subtotal_neto_exento, usuario_creacion, pago)"
            + " VALUES (@idFactura, @subtotalNeto, @iva, @impuestos, @total, @fechaCreacion, @idProveedor, @nombreProveedor, -1, @redondedo, @esConcepto, @esDefinitiva, @tipoFactura, @fechaVencimiento, @subtotalNetoExento, @usuario_creacion, @pago);";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));
            parameters.Add(new NpgsqlParameter("subtotalNeto", dataFact.Subtotal_neto));
            parameters.Add(new NpgsqlParameter("iva", dataFact.Iva));
            parameters.Add(new NpgsqlParameter("impuestos", dataFact.Impuestos));
            parameters.Add(new NpgsqlParameter("total", dataFact.Total));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idProveedor", dataFact.Id_proveedor));
            parameters.Add(new NpgsqlParameter("nombreProveedor", dataFact.Nombre_proveedor));
            parameters.Add(new NpgsqlParameter("redondedo", dataFact.Redondeo));
            parameters.Add(new NpgsqlParameter("esConcepto", dataFact.Es_concepto));
            parameters.Add(new NpgsqlParameter("esDefinitiva", dataFact.Es_definitiva));
            parameters.Add(new NpgsqlParameter("tipoFactura", dataFact.Tipo_factura));
            parameters.Add(new NpgsqlParameter("subtotalNetoExento", dataFact.Subtotal_neto_exento));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));
            parameters.Add(new NpgsqlParameter("pago", dataFact.Pago));

            if (dataFact.tiene_vencimiento)
            {
                parameters.Add(new NpgsqlParameter("fechaVencimiento", dataFact.Fecha_vencimiento));
            }
            else
            {
                parameters.Add(new NpgsqlParameter("fechaVencimiento", null));
            }

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idFactura;

        }

        public static void actualizar(FacturaDeCompraDTO dataFact)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //actualizo factura
            string sql = "UPDATE cpc_factura set"
            + " subtotal_neto = @subtotalNeto,"
            + " iva = @iva,"
            + " impuestos = @impuestos,"
            + " redondeo = @redondeo,"
            + " es_definitiva = @esDefinitiva,"
            + " subtotal_neto_exento = @subtotalNetoExento"
            + " where id = @idFactura;";

            parameters.Add(new NpgsqlParameter("idFactura", dataFact.id));
            parameters.Add(new NpgsqlParameter("subtotalNeto", dataFact.Subtotal_neto));
            parameters.Add(new NpgsqlParameter("iva", dataFact.Iva));
            parameters.Add(new NpgsqlParameter("impuestos", dataFact.Impuestos));
            parameters.Add(new NpgsqlParameter("redondeo", dataFact.Redondeo));
            parameters.Add(new NpgsqlParameter("esDefinitiva", dataFact.Es_definitiva));
            parameters.Add(new NpgsqlParameter("subtotalNetoExento", dataFact.Subtotal_neto_exento));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertDetalle(FacturaDeCompraDetalleDTO detalleFact)
        {

            long idFacturaDetalle = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de factura detalle
            string sql = "select nextval('cpc_factura_detalle_id_seq') idFacturaDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idFacturaDetalle = long.Parse(data["idFacturaDet"].ToString());
                data.Close();
            }

            //genero el detalle de la factura
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO cpc_factura_detalle("
            + " id, id_concepto, id_producto, cantidad, precio_unitario, importe,"
            + " id_factura, fecha_creacion, codigo, descripcion, unidad)" //xx2
            + " VALUES (@idFacturaDetalle, @idConcepto, @idProducto, @cantidad, @precioUnitario, @importe, @idFactura, @fechaCreacion, @codigo, @descripcion, @unidad);"; //xx2

            //detalle del registro facturable
            parameters.Add(new NpgsqlParameter("idFacturaDetalle", idFacturaDetalle));
            parameters.Add(new NpgsqlParameter("idConcepto", detalleFact.Id_concepto));
            parameters.Add(new NpgsqlParameter("idProducto", detalleFact.Id_producto));
            parameters.Add(new NpgsqlParameter("cantidad", detalleFact.Cantidad));
            parameters.Add(new NpgsqlParameter("precioUnitario", detalleFact.Precio_unitario));
            parameters.Add(new NpgsqlParameter("importe", detalleFact.Importe));
            parameters.Add(new NpgsqlParameter("idFactura", detalleFact.Id_factura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", detalleFact.Codigo));
            parameters.Add(new NpgsqlParameter("descripcion", detalleFact.Descripcion));
            parameters.Add(new NpgsqlParameter("unidad", detalleFact.Unidad)); //xx2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void insertIva(IvaComprasDetalleDTO detalleIva)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_factura_iva (id_factura, id_iva, importe)"
            + " VALUES (@idFactura, @idIva, @importe);";

            parameters.Add(new NpgsqlParameter("idFactura", detalleIva.Id_factura));
            parameters.Add(new NpgsqlParameter("idIva", detalleIva.Id_iva));
            parameters.Add(new NpgsqlParameter("importe", detalleIva.Importe));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertImpuestos(ImpuestoDetalleDTO detalleImpuestos)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_factura_impuesto (id_factura, id_impuesto, importe)"
            + " VALUES (@idFactura, @idImpuesto, @importe);";

            parameters.Add(new NpgsqlParameter("idFactura", detalleImpuestos.Id_factura));
            parameters.Add(new NpgsqlParameter("idImpuesto", detalleImpuestos.Id_impuesto));
            parameters.Add(new NpgsqlParameter("importe", detalleImpuestos.Importe));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static IList<FacturaDeCompraDTO> obtenerFacturasImpagas(string codProveedor)
        {
            IList<FacturaDeCompraDTO> lista = new List<FacturaDeCompraDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, factura.total total, val.valor tipoFactura, factura.id idFactura, 0 importePagado, factura.total importeAdeudado, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from cpc_factura factura, cpc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.id_origen = factura.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'FACTURA%'";
            sql = sql + " and factura.id_proveedor = @codProveedor";
            sql = sql + " and (factura.pago = 'N')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " union";             //union pago parcial
            sql = sql + " select comp.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, factura.total total, val.valor tipoFactura, factura.id idFactura, sum(pago.importe_pagado) importePagado, (factura.total - sum(pago.importe_pagado)) importeAdeudado, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from cpc_factura factura, cpc_comprobante comp, ofc_tabla_valor val, cpc_pago_comprobante pago";
            sql = sql + " where comp.id_origen = factura.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and pago.id_origen = factura.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'FACTURA%'";
            sql = sql + " and factura.id_proveedor = @codProveedor";
            sql = sql + " and (factura.pago = 'P')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " group by comp.fecha_creacion, comp.cod_comprobante, factura.total, val.valor, factura.id, val.valor_adicional";
            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("codProveedor", codProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDeCompraDTO e = new FacturaDeCompraDTO();

                e.total = Decimal.Parse(data["total"].ToString());
                e.total = Decimal.Round(e.total, 2);
                e.v_total = String.Format("{0:C}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));
                e.cod_comprobante = data["codComprobante"].ToString();
                e.fecha_creacion = DateTime.Parse(data["fechaCreacion"].ToString());
                e.id = long.Parse(data["idFactura"].ToString());
                e.importe_pagado = Decimal.Parse(data["importePagado"].ToString());
                e.importe_pagado = Decimal.Round(e.importe_pagado, 2);
                e.v_importe_pagado = String.Format("{0:C}", Math.Round(e.importe_pagado, 2, MidpointRounding.AwayFromZero));
                e.importe_adeudado = Decimal.Parse(data["importeAdeudado"].ToString());
                e.importe_adeudado = Decimal.Round(e.importe_adeudado, 2);
                e.v_importe_adeudado = String.Format("{0:C}", Math.Round(e.importe_adeudado, 2, MidpointRounding.AwayFromZero));
                e.tipo_comprobante = data["tipoComprobanteAbreviado"].ToString();

                if (data["tipoFactura"].ToString() == "FACTURA A")
                {
                    e.tipo_factura = 'A';
                }

                if (data["tipoFactura"].ToString() == "FACTURA B")
                {
                    e.tipo_factura = 'B';
                }

                if (data["tipoFactura"].ToString() == "FACTURA C")
                {
                    e.tipo_factura = 'C';
                }

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static decimal obtenerImporteIva27(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal importe = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select iva.importe importe";
            sql = sql + " from cpc_factura_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_27' and iva.id_factura = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal obtenerImporteIva21(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal importe = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select iva.importe importe";
            sql = sql + " from cpc_factura_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_21' and iva.id_factura = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal obtenerImporteIva105(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal importe = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select iva.importe importe";
            sql = sql + " from cpc_factura_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_105' and iva.id_factura = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static decimal obtenerImporteImpuestos(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal importe = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select sum(imp.importe) importe";
            sql = sql + " from cpc_factura_impuesto imp";
            sql = sql + " where imp.id_factura = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                importe = decimal.Parse(data["importe"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return importe;
        }

        public static bool esConcepto(string comprobante)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad";
            sql = sql + " from cpc_comprobante com, ofc_tabla_valor val, cpc_factura fac";
            sql = sql + " where com.id_origen = fac.id";
            sql = sql + " and val.id = com.id_tipo_comprobante";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'FACTURA%'";
            sql = sql + " and com.cod_comprobante = @comprobante";
            sql = sql + " and fac.es_concepto = 'S'";

            parameters.Add(new NpgsqlParameter("comprobante", comprobante));

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

        public static bool esConcepto(long id)
        {
            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad";
            sql = sql + " from cpc_factura";
            sql = sql + " where id = @id";
            sql = sql + " and es_concepto = 'S'";

            parameters.Add(new NpgsqlParameter("id", id));

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

        public static List<FacturaDeCompraDTO> obtenerFacturasReg(long idFactura)
        {
            List<FacturaDeCompraDTO> lista = new List<FacturaDeCompraDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select factura.id idFactura, factura.subtotal_neto subtotalNeto, factura.subtotal_neto_exento subtotalNetoExento, factura.iva iva, factura.impuestos impuesto, factura.redondeo redondeo, factura.total total, proveedor.nombre nombreProveedor, proveedor.direccion direccion, proveedor.localidad localidad, condicion.valor categoriaIva, proveedor.id idProveedor, proveedor.cuit cuitProveedor, factura.es_concepto esConcepto, factura.es_definitiva esDefinitiva, condicion.valor_adicional tipoFactura, factura.pago pago, cond_compra.valor condicionCompra, factura.fecha_vencimiento fechaVencimiento";
            sql = sql + " from cpc_factura factura, cpc_proveedor proveedor, ofc_tabla_valor condicion,  ofc_tabla_valor cond_compra";
            sql = sql + " where proveedor.id = factura.id_proveedor";
            sql = sql + " and condicion.id = proveedor.id_categoria_iva";
            sql = sql + " and cond_compra.id = proveedor.id_condicion_compra";
            sql = sql + " and factura.id = @idFac";
            sql = sql + " and proveedor.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idFac", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDeCompraDTO e = new FacturaDeCompraDTO();

                e.id = long.Parse(data["idFactura"].ToString());
                e.subtotal_neto = Decimal.Parse(data["subtotalNeto"].ToString());
                e.subtotal_neto_exento = Decimal.Parse(data["subtotalNetoExento"].ToString());
                e.iva = Decimal.Parse(data["iva"].ToString());
                e.impuestos = Decimal.Parse(data["impuesto"].ToString());
                e.redondeo = Decimal.Parse(data["redondeo"].ToString());
                e.total = Decimal.Parse(data["total"].ToString());
                e.id_proveedor = data["idProveedor"].ToString();
                e.direccion = data["direccion"].ToString();
                e.localidad = data["localidad"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.nombre_proveedor = data["nombreProveedor"].ToString();
                e.cuit = data["cuitProveedor"].ToString();
                e.es_definitiva = char.Parse(data["esDefinitiva"].ToString());
                e.es_concepto = char.Parse(data["esConcepto"].ToString());
                e.tipo_factura = char.Parse(data["tipoFactura"].ToString());
                e.pago = char.Parse(data["pago"].ToString());
                e.condicion_compra = data["condicionCompra"].ToString();

                if (data["fechaVencimiento"] != null && data["fechaVencimiento"] != DBNull.Value)
                {
                    e.fecha_vencimiento = DateTime.Parse(data["fechaVencimiento"].ToString());
                    e.v_fecha_vencimiento = String.Format("{0:dd/MM/yyyy}", e.fecha_vencimiento);
                }

                e.v_subtotal_neto = String.Format("{0:0.00}", Math.Round(e.subtotal_neto, 2, MidpointRounding.AwayFromZero));
                e.v_subtotal_neto_exento = String.Format("{0:0.00}", Math.Round(e.subtotal_neto_exento, 2, MidpointRounding.AwayFromZero));
                e.v_iva = String.Format("{0:0.00}", Math.Round(e.iva, 2, MidpointRounding.AwayFromZero));
                e.v_impuesto = String.Format("{0:0.00}", Math.Round(e.impuestos, 2, MidpointRounding.AwayFromZero));
                e.v_redondeo = String.Format("{0:0.00}", Math.Round(e.redondeo, 2, MidpointRounding.AwayFromZero));
                e.v_total = String.Format("{0:0.00}", Math.Round(e.total, 2, MidpointRounding.AwayFromZero));

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

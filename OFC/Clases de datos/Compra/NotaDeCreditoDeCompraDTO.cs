using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class NotaDeCreditoDeCompraDTO
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

        decimal subtotal_neto_exento;

        public decimal Subtotal_neto_exento
        {
            get { return subtotal_neto_exento; }
            set { subtotal_neto_exento = value; }
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

        decimal redondeo;

        public decimal Redondeo
        {
            get { return redondeo; }
            set { redondeo = value; }
        }

        decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
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

        char es_concepto;

        public char Es_concepto
        {
            get { return es_concepto; }
            set { es_concepto = value; }
        }

        long id_tipo_asiento;

        public long Id_tipo_asiento
        {
            get { return id_tipo_asiento; }
            set { id_tipo_asiento = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        char tipo_nota_credito;

        public char Tipo_nota_credito
        {
            get { return tipo_nota_credito; }
            set { tipo_nota_credito = value; }
        }

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
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

        string cuit_proveedor;

        public string Cuit_proveedor
        {
            get { return cuit_proveedor; }
            set { cuit_proveedor = value; }
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


        public NotaDeCreditoDeCompraDTO()
        {
            id = -1;
            subtotal_neto = decimal.Zero;
            iva = decimal.Zero;
            impuestos = decimal.Zero;
            total = decimal.Zero;
            fecha_creacion = DateTime.Now;
            id_proveedor = string.Empty;
            nombre_proveedor = string.Empty;
            id_tipo_asiento = -1;
            redondeo = decimal.Zero;
            es_concepto = 'N';
            tipo_nota_credito = 'N';
            cod_comprobante = string.Empty;
            subtotal_neto_exento = decimal.Zero;
            v_total = string.Empty;
            cuit_proveedor = string.Empty;
            categoria_iva = string.Empty;
            fecha_comprobante = DateTime.Now;
            fecha_contable = DateTime.Now;
            direccion = string.Empty;
            localidad = string.Empty;
            cuit = string.Empty;
            condicion_compra = string.Empty;
            v_subtotal_neto_exento = string.Empty;
            v_subtotal_neto = string.Empty;
            v_redondeo = string.Empty;
            v_iva = string.Empty;
            v_impuesto = string.Empty;


        }

        public static long insert(NotaDeCreditoDeCompraDTO dataCredito)
        {
            long idNotaCredito = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select nextval('cpc_nota_credito_id_seq') idNotaCredito";

            //nuevo id de nota de credito
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idNotaCredito = long.Parse(data["idNotaCredito"].ToString());
                data.Close();
            }

            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero nota de credito
            sql = "INSERT INTO cpc_nota_credito("
            + " id, subtotal_neto, subtotal_neto_exento, iva, impuestos, redondeo, total, id_proveedor, nombre_proveedor, "
            + " es_concepto, id_tipo_asiento, fecha_creacion, usuario_creacion, tipo_nota_credito, pago)"
            + " VALUES (@idNotaCredito, @subtotalNeto, @subtotalNetoExento, @iva, @impuestos, @redondeo, @total, @idProveedor, @nombreProveedor, @esConcepto, -1, @fecha_creacion, @usuario_creacion, @tipoNotaCredito, 'N');";

            parameters.Add(new NpgsqlParameter("idNotaCredito", idNotaCredito));
            parameters.Add(new NpgsqlParameter("subtotalNeto", dataCredito.subtotal_neto));
            parameters.Add(new NpgsqlParameter("subtotalNetoExento", dataCredito.subtotal_neto_exento));
            parameters.Add(new NpgsqlParameter("iva", dataCredito.iva));
            parameters.Add(new NpgsqlParameter("impuestos", dataCredito.impuestos));
            parameters.Add(new NpgsqlParameter("redondeo", dataCredito.redondeo));
            parameters.Add(new NpgsqlParameter("total", dataCredito.total));
            parameters.Add(new NpgsqlParameter("idProveedor", dataCredito.Id_proveedor));
            parameters.Add(new NpgsqlParameter("nombreProveedor", dataCredito.Nombre_proveedor));
            parameters.Add(new NpgsqlParameter("esConcepto", dataCredito.Es_concepto));
            parameters.Add(new NpgsqlParameter("fecha_creacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("usuario_creacion", Usuario.GetInstance().Login));
            parameters.Add(new NpgsqlParameter("tipoNotaCredito", dataCredito.tipo_nota_credito));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idNotaCredito;
        }

        public static void insertDetalle(NotaDeCreditoCompDetalleDTO detalleCred)
        {

            long idCreditoDetalle = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //obtengo id de credito detalle
            string sql = "select nextval('cpc_nota_credito_detalle_id_seq') idCreditoDet";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idCreditoDetalle = long.Parse(data["idCreditoDet"].ToString());
                data.Close();
            }

            //genero el detalle de la nota de credito
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO cpc_nota_credito_detalle("
            + " id, id_concepto, id_producto, cantidad, precio_unitario, importe,"
            + " id_nota_credito, fecha_creacion, codigo, descripcion, unidad)"
            + " VALUES (@idCreditoDetalle, @idConcepto, @idProducto, @cantidad, @precioUnitario, @importe, @idCredito, @fechaCreacion, @codigo, @descripcion, @unidad);";

            //detalle del registro facturable
            parameters.Add(new NpgsqlParameter("idCreditoDetalle", idCreditoDetalle));
            parameters.Add(new NpgsqlParameter("idConcepto", detalleCred.Id_concepto));
            parameters.Add(new NpgsqlParameter("idProducto", detalleCred.Id_producto));
            parameters.Add(new NpgsqlParameter("cantidad", detalleCred.Cantidad));
            parameters.Add(new NpgsqlParameter("precioUnitario", detalleCred.Precio_unitario));
            parameters.Add(new NpgsqlParameter("importe", detalleCred.Importe));
            parameters.Add(new NpgsqlParameter("idCredito", detalleCred.Id_nota_credito));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", detalleCred.Codigo));
            parameters.Add(new NpgsqlParameter("descripcion", detalleCred.Descripcion));
            parameters.Add(new NpgsqlParameter("unidad", detalleCred.Unidad));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static void insertIva(IvaComprasDetalleDTO detalleIva)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_nota_credito_iva (id_nota_credito, id_iva, importe)"
            + " VALUES (@idCredito, @idIva, @importe);";

            parameters.Add(new NpgsqlParameter("idCredito", detalleIva.Id_factura));
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

            string sql = "INSERT INTO cpc_nota_credito_impuesto (id_nota_credito, id_impuesto, importe)"
            + " VALUES (@idCredito, @idImpuesto, @importe);";

            parameters.Add(new NpgsqlParameter("idCredito", detalleImpuestos.Id_factura));
            parameters.Add(new NpgsqlParameter("idImpuesto", detalleImpuestos.Id_impuesto));
            parameters.Add(new NpgsqlParameter("importe", detalleImpuestos.Importe));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static decimal obtenerImporteIva27(long id)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal importe = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select iva.importe importe";
            sql = sql + " from cpc_nota_credito_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_27' and iva.id_nota_credito = @id";

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
            sql = sql + " from cpc_nota_credito_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_21' and iva.id_nota_credito = @id";

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
            sql = sql + " from cpc_nota_credito_iva iva, ofc_tabla_valor val";
            sql = sql + " where iva.id_iva = val.id and val.id_tabla= 'IC'";
            sql = sql + " and val.valor = 'IVA_105' and iva.id_nota_credito = @id";

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
            sql = sql + " from cpc_nota_credito_impuesto imp";
            sql = sql + " where imp.id_nota_credito = @id";

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
            sql = sql + " from cpc_comprobante com, ofc_tabla_valor val, cpc_nota_credito cre";
            sql = sql + " where com.id_origen = cre.id";
            sql = sql + " and val.id = com.id_tipo_comprobante";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'NOTA DE CREDITO%'";
            sql = sql + " and com.cod_comprobante = @comprobante";
            sql = sql + " and cre.es_concepto = 'S'";

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
            sql = sql + " from cpc_nota_credito";
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

        public static List<NotaDeCreditoDeCompraDTO> obtenerNCReg(long idNotaDeCredito)
        {
            List<NotaDeCreditoDeCompraDTO> lista = new List<NotaDeCreditoDeCompraDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select credito.id idCredito, credito.subtotal_neto subtotalNeto, credito.subtotal_neto_exento subtotalNetoExento, credito.iva iva, credito.impuestos impuesto, credito.redondeo redondeo, credito.total total, proveedor.nombre nombreProveedor, proveedor.direccion direccion, proveedor.localidad localidad, condicion.valor categoriaIva, proveedor.id idProveedor, proveedor.cuit cuitProveedor, credito.es_concepto esConcepto, condicion.valor_adicional tipoCredito, cond_compra.valor condicionCompra";
            sql = sql + " from cpc_nota_credito credito, cpc_proveedor proveedor, ofc_tabla_valor condicion,  ofc_tabla_valor cond_compra";
            sql = sql + " where proveedor.id = credito.id_proveedor";
            sql = sql + " and condicion.id = proveedor.id_categoria_iva";
            sql = sql + " and cond_compra.id = proveedor.id_condicion_compra";
            sql = sql + " and credito.id = @idCre";
            sql = sql + " and proveedor.activo = 'S'";

            parameters.Add(new NpgsqlParameter("idCre", idNotaDeCredito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                NotaDeCreditoDeCompraDTO e = new NotaDeCreditoDeCompraDTO();

                e.id = long.Parse(data["idCredito"].ToString());
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
                e.es_concepto = char.Parse(data["esConcepto"].ToString());
                e.tipo_nota_credito = char.Parse(data["tipoCredito"].ToString());
                e.condicion_compra = data["condicionCompra"].ToString();

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

        //devuelvo una factura porque la estructura es la misma o casi igual que una nota de credito
        public static IList<FacturaDeCompraDTO> obtenerCreditosImpagos(string codProveedor)
        {
            IList<FacturaDeCompraDTO> lista = new List<FacturaDeCompraDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, credito.total total, val.valor tipoCredito, credito.id idCredito, 0 importePagado, credito.total importeAdeudado, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from cpc_nota_credito credito, cpc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.id_origen = credito.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'NOTA DE CREDITO%'";
            sql = sql + " and credito.id_proveedor = @codProveedor";
            sql = sql + " and (credito.pago = 'N')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " union";             //union pago parcial
            sql = sql + " select comp.fecha_creacion fechaCreacion, comp.cod_comprobante codComprobante, credito.total total, val.valor tipoCredito, credito.id idCredito, sum(pago.importe_pagado) importePagado, (credito.total - sum(pago.importe_pagado)) importeAdeudado, val.valor_adicional tipoComprobanteAbreviado";
            sql = sql + " from cpc_nota_credito credito, cpc_comprobante comp, ofc_tabla_valor val, cpc_pago_comprobante pago";
            sql = sql + " where comp.id_origen = credito.id";
            sql = sql + " and comp.id_tipo_comprobante = val.id";
            sql = sql + " and pago.id_origen = credito.id";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor like 'NOTA DE CREDITO%'";
            sql = sql + " and credito.id_proveedor = @codProveedor";
            sql = sql + " and (credito.pago = 'P')";
            sql = sql + " and (comp.anulado != 'S')";
            sql = sql + " group by comp.fecha_creacion, comp.cod_comprobante, credito.total, val.valor, credito.id, val.valor_adicional";
            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("codProveedor", codProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDeCompraDTO e = new FacturaDeCompraDTO();

                e.Total = Decimal.Parse(data["total"].ToString()) * (-1); //es nc
                e.Total = Decimal.Round(e.Total, 2);
                e.V_total = String.Format("{0:C}", Math.Round(e.Total, 2, MidpointRounding.AwayFromZero));
                e.Cod_comprobante = data["codComprobante"].ToString();
                e.Fecha_creacion = DateTime.Parse(data["fechaCreacion"].ToString());
                e.Id = long.Parse(data["idCredito"].ToString());
                e.Importe_pagado = Decimal.Parse(data["importePagado"].ToString()) * (-1); //es nc
                e.Importe_pagado = Decimal.Round(e.Importe_pagado, 2);
                e.V_importe_pagado = String.Format("{0:C}", Math.Round(e.Importe_pagado, 2, MidpointRounding.AwayFromZero));
                e.Importe_adeudado = Decimal.Parse(data["importeAdeudado"].ToString()) * (-1); //es nc
                e.Importe_adeudado = Decimal.Round(e.Importe_adeudado, 2);
                e.V_importe_adeudado = String.Format("{0:C}", Math.Round(e.Importe_adeudado, 2, MidpointRounding.AwayFromZero));
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

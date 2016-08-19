using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace OFC
{
    class PagoDTO
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

        string nro_pago;

        public string Nro_pago
        {
            get { return nro_pago; }
            set { nro_pago = value; }
        }

        List<FacturaDeCompraDTO> cod_comprobante_factura;

        public List<FacturaDeCompraDTO> Cod_comprobante_factura
        {
            get { return cod_comprobante_factura; }
            set { cod_comprobante_factura = value; }
        }

        List<PagoDetalleDTO> list_pago_detalle;

        public List<PagoDetalleDTO> List_pago_detalle
        {
            get { return list_pago_detalle; }
            set { list_pago_detalle = value; }
        }

        //agregar retencion

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

        string condicion_compra;

        public string Condicion_compra
        {
            get { return condicion_compra; }
            set { condicion_compra = value; }
        }

        DateTime fecha_pago;

        public DateTime Fecha_pago
        {
            get { return fecha_pago; }
            set { fecha_pago = value; }
        }

        string v_fecha_pago;

        public string V_fecha_pago
        {
            get { return v_fecha_pago; }
            set { v_fecha_pago = value; }
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

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }


        public PagoDTO()
        {
            id = -1;
            importe = decimal.Zero;
            id_factura = -1;
            id_proveedor = string.Empty;
            nombre_proveedor = string.Empty;
            nro_pago = string.Empty;
            direccion = string.Empty;
            localidad = string.Empty;
            cuit = string.Empty;
            categoria_iva = string.Empty;
            v_importe = string.Empty;
            condicion_compra = string.Empty;
            fecha_pago = DateTime.Now;
            v_fecha_pago = string.Empty;
            fecha_comprobante = DateTime.Now;
            v_fecha_comprobante = string.Empty;
            cod_comprobante = string.Empty;
        }

        public static long insertar(PagoDTO dataPago)
        {
            long idPago = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select nextval('cpc_pago_id_seq') idPago";
            //nuevo id de pago
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            if (data != null && data.Read())
            {
                idPago = long.Parse(data["idPago"].ToString());
                data.Close();
            }

            //genero orden de pago
            sql = "INSERT INTO cpc_pago("
            + " id, valor, id_proveedor, nombre_proveedor, fecha_creacion, usuario_creacion)"
            + " VALUES (@idPago, @importe, @idProveedor, @nombreProveedor, @fechaCreacion, @usuarioCreacion);";

            parameters.Add(new NpgsqlParameter("idPago", idPago));
            parameters.Add(new NpgsqlParameter("importe", dataPago.importe));
            parameters.Add(new NpgsqlParameter("idProveedor", dataPago.Id_proveedor));
            parameters.Add(new NpgsqlParameter("nombreProveedor", dataPago.Nombre_proveedor));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("usuarioCreacion", Usuario.GetInstance().Login));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            foreach (FacturaDeCompraDTO Factura in dataPago.cod_comprobante_factura)
            {
                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrigen", Factura.Id));
                parameters.Add(new NpgsqlParameter("idPago", idPago));
                parameters.Add(new NpgsqlParameter("codComprobanteFactura", Factura.Cod_comprobante));
                parameters.Add(new NpgsqlParameter("importe_pagado", Factura.Importe_de_pago));
                parameters.Add(new NpgsqlParameter("pago_parcial", Factura.Pago_parcial));
                parameters.Add(new NpgsqlParameter("importe_pagado_acumulado", Factura.Importe_pagado_acumulado));
                parameters.Add(new NpgsqlParameter("importe_adeudado_actualizado", Factura.Importe_adeudado_actualizado));

                if (Factura.Pago_parcial == 'S')
                {
                    parameters.Add(new NpgsqlParameter("tipo_de_pago", "P")); //PAGO PARCIAL
                    parameters.Add(new NpgsqlParameter("tipo_de_pago_2", "P")); //PAGO PARCIAL
                }
                else
                {
                    parameters.Add(new NpgsqlParameter("tipo_de_pago", "O")); //PAGO
                    parameters.Add(new NpgsqlParameter("tipo_de_pago_2", "S")); //PAGO
                }

                //es factura, nota de debito o nota de crédito?
                if (Factura.Tipo_comprobante.IndexOf("FAC") != -1)
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("FACTURA " + Factura.Tipo_factura.ToString())));
                    //actualizo factura
                    sql = "update cpc_factura set pago = @tipo_de_pago_2 where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("DEB") != -1)
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE DEBITO " + Factura.Tipo_factura.ToString())));
                    //actualizo nota de debito
                    sql = "update cpc_nota_debito set pago = @tipo_de_pago_2 where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("CRE") != -1)
                {
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE CREDITO " + Factura.Tipo_factura.ToString())));
                    //actualizo nota de credito
                    sql = "update cpc_nota_credito set pago = @tipo_de_pago_2 where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }

                //genero relacion pago comprobante (factura, nota de débito o nota de crédito)
                sql = "INSERT INTO cpc_pago_comprobante("
                + " id_pago, id_origen, importe_pagado, pago_parcial, importe_pagado_acumulado, importe_adeudado_actualizado, id_tipo_comprobante)"
                + " VALUES (@idPago, @idOrigen, @importe_pagado, @pago_parcial, @importe_pagado_acumulado, @importe_adeudado_actualizado, @id_tipo_comprobante);";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

                sql = "update cpc_movimiento set pago = @tipo_de_pago where id_origen = @idOrigen and cod_comprobante = @codComprobanteFactura and id_tipo_comprobante = @id_tipo_comprobante";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
            }


            PagoDetalleDTO.insertar(dataPago.list_pago_detalle, idPago);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idPago;

        }

        public static long obtenerNuevoNro()
        {
            return ParametroDTO.obtenerParametroII("INICIO NRO ORDEN DE PAGO") + 1; ;
        }

        public static void updateFacturasPagas(List<FacturaDeCompraDTO> codComprobante)
        {
            string sql = string.Empty;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            foreach (FacturaDeCompraDTO Factura in codComprobante)
            {

                parameters.Clear();
                parameters.Add(new NpgsqlParameter("idOrigen", Factura.Id));
                parameters.Add(new NpgsqlParameter("codComprobante", Factura.Cod_comprobante));
                

                if (Factura.Tipo_comprobante.IndexOf("FAC") != -1)
                {
                    //actualizo factura
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("FACTURA " + Factura.Tipo_factura.ToString())));
                    sql = "update cpc_factura set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("DEB") != -1)
                {
                    //actualizo nota de débito
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE DEBITO " + Factura.Tipo_factura.ToString())));
                    sql = "update cpc_nota_debito set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }
                if (Factura.Tipo_comprobante.IndexOf("CRE") != -1)
                {
                    //actualizo nota de crédito
                    parameters.Add(new NpgsqlParameter("id_tipo_comprobante", ValorDTO.obtenerId("NOTA DE CREDITO " + Factura.Tipo_factura.ToString())));
                    sql = "update cpc_nota_credito set pago = 'S' where id = @idOrigen";
                    BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);
                }

                sql = "update cpc_movimiento set pago = 'O' where id_origen = @idOrigen and cod_comprobante = @codComprobante and id_tipo_comprobante = @id_tipo_comprobante";
                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static List<PagoDTO> obtenerPagosDelMes(string cod_proveedor, DateTime fecha_orden_de_pago)
        {
            List<PagoDTO> lista = new List<PagoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            int dias_transcurridos = fecha_orden_de_pago.Day * (-1);

            string sql = "select comp.cod_comprobante codComprobante, comp.fecha_creacion fechaPago, pago.valor total";
            sql = sql + " from cpc_pago pago, cpc_comprobante comp, ofc_tabla_valor val";
            sql = sql + " where comp.id_origen = pago.id";
            sql = sql + " and val.id = comp.id_tipo_comprobante";
            sql = sql + " and val.id_tabla = 'TC'";
            sql = sql + " and val.valor = 'ORDEN DE PAGO'";
            sql = sql + " and comp.id_proveedor = @cod_proveedor";
            sql = sql + " and comp.fecha_creacion >= @primer_dia_del_mes";
            sql = sql + " and comp.fecha_creacion <= @ultimo_dia_del_mes";
            sql = sql + " order by comp.fecha_creacion";

            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));
            parameters.Add(new NpgsqlParameter("primer_dia_del_mes", fecha_orden_de_pago.AddDays(dias_transcurridos + 1)));
            parameters.Add(new NpgsqlParameter("ultimo_dia_del_mes", fecha_orden_de_pago.AddMonths(1).AddDays(dias_transcurridos)));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                PagoDTO e = new PagoDTO();
                e.nro_pago = data["codComprobante"].ToString();
                e.fecha_pago = DateTime.Parse(data["fechaPago"].ToString());
                e.v_fecha_pago = String.Format("{0:dd/MM/yyyy}", e.fecha_pago);
                e.importe = decimal.Parse(data["total"].ToString());
                e.v_importe = String.Format("{0:C}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<PagoDTO> obtenerPagoReg(long idOrdenDePago)
        {
            List<PagoDTO> lista = new List<PagoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            int dias_transcurridos = System.DateTime.Now.Day * (-1);

            string sql = "select prov.id idProveedor, prov.nombre nombreProveedor, prov.localidad localidad, prov.direccion direccion, prov.cuit cuit, iva.valor categoriaIva, compra.valor condicionCompra, pago.valor total";
            sql = sql + " from cpc_pago pago, ofc_tabla_valor compra, ofc_tabla_valor iva, cpc_proveedor prov";
            sql = sql + " where pago.id_proveedor = prov.id";
            sql = sql + " and iva.id = prov.id_categoria_iva";
            sql = sql + " and compra.id = prov.id_condicion_compra";
            sql = sql + " and iva.id_tabla = 'CI'";
            sql = sql + " and compra.id_tabla = 'CC'";
            sql = sql + " and pago.id = @idOrdenDePago";

            parameters.Add(new NpgsqlParameter("idOrdenDePago", idOrdenDePago));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                PagoDTO e = new PagoDTO();
                e.id_proveedor = data["idProveedor"].ToString();
                e.nombre_proveedor = data["nombreProveedor"].ToString();
                e.localidad = data["localidad"].ToString();
                e.direccion = data["direccion"].ToString();
                e.cuit = data["cuit"].ToString();
                e.categoria_iva = data["categoriaIva"].ToString();
                e.condicion_compra = data["condicionCompra"].ToString();
                e.importe = decimal.Parse(data["total"].ToString());
                e.v_importe = String.Format("{0:C}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static List<FacturaDeCompraDTO> obtenerFacturaAsociadas(long idOrdenDePago)
        {

            List<FacturaDeCompraDTO> lista = new List<FacturaDeCompraDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select tipo.valor_adicional tipoComprobante, comp.cod_comprobante codComprobante, pago_comp.importe_pagado importePagado";
            sql = sql + " from cpc_pago pago, cpc_pago_comprobante pago_comp, cpc_comprobante comp, ofc_tabla_valor tipo";
            sql = sql + " where pago.id = pago_comp.id_pago";
            sql = sql + " and comp.id_origen = pago_comp.id_origen";
            sql = sql + " and comp.id_tipo_comprobante = pago_comp.id_tipo_comprobante";
            sql = sql + " and comp.id_tipo_comprobante = tipo.id";
            sql = sql + " and tipo.id_tabla = 'TC'";
            sql = sql + " and pago.id = @idOrdenDePago";

            parameters.Add(new NpgsqlParameter("idOrdenDePago", idOrdenDePago));
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDeCompraDTO e = new FacturaDeCompraDTO();
                e.Tipo_comprobante = data["tipoComprobante"].ToString();
                e.Cod_comprobante = data["codComprobante"].ToString();
                e.Importe_pagado = decimal.Parse(data["importePagado"].ToString());
                e.V_importe_pagado = String.Format("{0:C}", Math.Round(e.Importe_pagado, 2, MidpointRounding.AwayFromZero));
                
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }


        public static List<PagoDTO> obtenerPagosParciales(long id_origen, long id_tipo_comprobante)
        {
            List<PagoDTO> lista = new List<PagoDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.cod_comprobante cod_comprobante_pago, pagoc.importe_pagado importe_pagado";
            sql = sql + " from cpc_comprobante comp, cpc_pago_comprobante pagoc, ofc_tabla_valor valor";
            sql = sql + " where comp.id_origen = pagoc.id_pago";
            sql = sql + " and valor.id = comp.id_tipo_comprobante";
            sql = sql + " and valor.id_tabla = 'TC'";
            sql = sql + " and valor.valor = 'ORDEN DE PAGO'";
            sql = sql + " and pagoc.id_origen = @idOrigen";
            sql = sql + " and pagoc.id_tipo_comprobante = @idTipoComprobante";
            sql = sql + " and pagoc.pago_parcial = 'S'";

            parameters.Add(new NpgsqlParameter("idOrigen", id_origen));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", id_tipo_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                PagoDTO e = new PagoDTO();
                e.importe = decimal.Parse(data["importe_pagado"].ToString());
                e.cod_comprobante = data["cod_comprobante_pago"].ToString();

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

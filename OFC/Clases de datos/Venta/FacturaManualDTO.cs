using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class FacturaManualDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        decimal precio_unitario;

        public decimal Precio_unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        long id_servicio;

        public long Id_servicio
        {
            get { return id_servicio; }
            set { id_servicio = value; }
        }

        string coche;

        public string Coche
        {
            get { return coche; }
            set { coche = value; }
        }

        char solo_factura;

        public char Solo_factura
        {
            get { return solo_factura; }
            set { solo_factura = value; }
        }

        char iva105;

        public char Iva105
        {
            get { return iva105; }
            set { iva105 = value; }
        }

        //feb 1.9.1
        long id_remito;

        public long Id_remito
        {
            get { return id_remito; }
            set { id_remito = value; }
        }
                
        public FacturaManualDTO()
        {
            id = -1;
            id_cliente = String.Empty;
            nombre_cliente = String.Empty;
            cantidad = -1;
            id_factura = -1;
            fecha_creacion = DateTime.Now;
            codigo = String.Empty;
            descripcion = String.Empty;
            precio_unitario = decimal.Zero;
            importe = decimal.Zero;
            id_producto = -1;
            id_servicio = -1;
            coche = String.Empty;
            solo_factura = 'N';
            iva105 = 'N';
            id_remito = -1; //feb 1.9.1
        }

        public static long insert(FacturaManualDTO dataFact, decimal descuento) //feb 1.9.1
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
            + " VALUES (@idFactura, @fechaCreacion, @idCliente, 'N', @soloFactura, @iva105, @usuario_creacion);";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));
            parameters.Add(new NpgsqlParameter("soloFactura", dataFact.Solo_factura));
            parameters.Add(new NpgsqlParameter("iva105", dataFact.Iva105));
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

        //feb 1.9.1 refactor
        public static void insertDetalle(FacturaManualDTO dataFact)
        {

            long idFacturaDetalle = -1;
            decimal valorIva = Decimal.Zero;
            char tipoFactura = 'A';
            decimal bonificacion = ComprobanteTempDTO.obtenerDescuento(dataFact.Id_factura, "FACTURA"); //feb 1.9.1
            decimal importeIva = decimal.Zero; //feb 1.9.1
            decimal total = decimal.Zero; //feb 1.9.1

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
            if (dataFact.iva105 == 'S')
            {
                //valorIva = (decimal) ParametroDTO.obtenerParametroI("IVA") / 2;
                valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_105"));
                valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                //valorIva = (decimal) ParametroDTO.obtenerParametroI("IVA");
                valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
                valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
            }

            //calculo el importe del item facturable segun el tipo de factura
            IList<NpgsqlParameter> parametersClie = new List<NpgsqlParameter>();
            sql = "select condicion.valor_adicional tipoFactura from ofc_cliente cliente, ofc_tabla_valor condicion";
            sql = sql + " where cliente.id_categoria_iva = condicion.id";
            sql = sql + " and cliente.id = @idCliente";
            sql = sql + " and cliente.activo = 'S'";

            parametersClie.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));

            NpgsqlDataReader dataTipoClie = BaseDeDatos.ejecutarQuery(sql, cn, parametersClie);

            if (dataTipoClie != null && dataTipoClie.Read())
            {
                tipoFactura = char.Parse(dataTipoClie["tipoFactura"].ToString());
                dataTipoClie.Close();
            }

            //si es tipo B calculo el iva dentro del importe, es decir no lo separo
            if (tipoFactura == 'B')
            {
                decimal importeIvaUni = (dataFact.Precio_unitario * valorIva) / 100;
                importeIvaUni = decimal.Round(importeIvaUni, 2, MidpointRounding.AwayFromZero);

                dataFact.Precio_unitario = dataFact.Precio_unitario + importeIvaUni;
                dataFact.Precio_unitario = decimal.Round(dataFact.Precio_unitario, 2, MidpointRounding.AwayFromZero);

                decimal importe_aux = dataFact.Importe - (dataFact.Importe * (bonificacion / 100));
                importeIva = (importe_aux * valorIva) / 100;

                decimal importeIvaAux = (dataFact.Importe * valorIva) / 100;
                importeIvaAux = decimal.Round(importeIvaAux, 2, MidpointRounding.AwayFromZero);

                dataFact.Importe = dataFact.Importe + importeIvaAux;
                dataFact.Importe = dataFact.Importe - (dataFact.Importe * (bonificacion / 100));
                dataFact.Importe = decimal.Round(dataFact.Importe, 2, MidpointRounding.AwayFromZero);

                total = dataFact.Importe;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                dataFact.Precio_unitario = decimal.Round(dataFact.Precio_unitario, 2, MidpointRounding.AwayFromZero);

                dataFact.Importe = dataFact.Importe - (dataFact.Importe * (bonificacion / 100));
                dataFact.Importe = decimal.Round(dataFact.Importe, 2, MidpointRounding.AwayFromZero);

                importeIva = (dataFact.Importe * valorIva) / 100;
                importeIva = decimal.Round(importeIva, 2, MidpointRounding.AwayFromZero);

                total = dataFact.Importe + importeIva;
                total = decimal.Round(total, 2, MidpointRounding.AwayFromZero);
            }

            //genero el detalle de la factura
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            sql = "INSERT INTO ofc_factura_detalle("
            + " id, id_orden_de_trabajo, importe, id_producto, id_servicio, cantidad,"
            + " precio_unitario, id_renglon_orden_de_trabajo, id_factura, fecha_creacion, codigo, coche, motivo_descuento, descripcion, iva_importe, total)" //feb 1.9.1
            + " VALUES (@idFacturaDetalle, @idOrden, @importe, @idProducto, @idServicio, @cantidad, @precioUnitario, @idRenglon, @idFactura, @fechaCreacion, @codigo, @coche, @motivo_descuento, @descripcion, @iva_importe, @total);";

            //detalle del registro facturable
            parameters.Add(new NpgsqlParameter("idFacturaDetalle", idFacturaDetalle));
            parameters.Add(new NpgsqlParameter("idOrden", -1));
            parameters.Add(new NpgsqlParameter("importe", dataFact.Importe));
            parameters.Add(new NpgsqlParameter("precioUnitario", dataFact.Precio_unitario));
            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));
            parameters.Add(new NpgsqlParameter("idProducto", dataFact.Id_producto));
            parameters.Add(new NpgsqlParameter("idServicio", dataFact.Id_servicio));
            parameters.Add(new NpgsqlParameter("cantidad", dataFact.Cantidad));
            parameters.Add(new NpgsqlParameter("idRenglon", -1));
            parameters.Add(new NpgsqlParameter("idFactura", dataFact.Id_factura));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("codigo", dataFact.Codigo));
            parameters.Add(new NpgsqlParameter("coche", dataFact.Coche));
            parameters.Add(new NpgsqlParameter("motivo_descuento", ""));
            parameters.Add(new NpgsqlParameter("descripcion", dataFact.Descripcion));
            parameters.Add(new NpgsqlParameter("iva_importe", importeIva));
            parameters.Add(new NpgsqlParameter("total", total));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;


namespace OFC
{
    class FacturaDetalleDTO
    {

        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_orden_de_trabajo_detalle;

        public long Id_orden_de_trabajo_detalle
        {
            get { return id_orden_de_trabajo_detalle; }
            set { id_orden_de_trabajo_detalle = value; }
        }

        Decimal importe;

        public Decimal Importe
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

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        Decimal precio_unitario;

        public Decimal Precio_unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
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
        string v_precio_unitario;

        public string V_precio_unitario
        {
            get { return v_precio_unitario; }
            set { v_precio_unitario = value; }
        }


        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
        }

        //feb 1.9.1
        int fw_unidad;

        public int Fw_unidad
        {
            get { return fw_unidad; }
            set { fw_unidad = value; }
        }

        int fw_alicuota;

        public int Fw_alicuota
        {
            get { return fw_alicuota; }
            set { fw_alicuota = value; }
        }

        Decimal fw_importeIva;

        public Decimal Fw_importeIva
        {
            get { return fw_importeIva; }
            set { fw_importeIva = value; }
        }


        Decimal fw_totalConcepto;

        public Decimal Fw_totalConcepto
        {
            get { return fw_totalConcepto; }
            set { fw_totalConcepto = value; }
        }

        Decimal fw_porcentajeBonificacion;

        public Decimal Fw_porcentajeBonificacion
        {
            get { return fw_porcentajeBonificacion; }
            set { fw_porcentajeBonificacion = value; }
        }

        public FacturaDetalleDTO()
        {
            id = -1;
            id_orden_de_trabajo_detalle = -1;
            importe = Decimal.Zero;
            id_producto = -1;
            id_servicio = -1;
            cantidad = -1;
            precio_unitario = Decimal.Zero;
            v_precio_unitario = String.Empty;
            v_importe = String.Empty;
            fw_unidad = -1; //feb 1.9.1
            descripcion = string.Empty; //feb 1.9.1
            fw_alicuota = -1; //feb 1.9.1
            fw_importeIva = Decimal.Zero; //feb 1.9.1
            fw_totalConcepto = Decimal.Zero; //feb 1.9.1
            fw_porcentajeBonificacion = Decimal.Zero; //feb 1.9.1
            codigo = string.Empty; //feb 1.9.1
        }

        public static List<FacturaDetalleDTO> obtenerDetalleFact(long idFactura)
        {
            List<FacturaDetalleDTO> lista = new List<FacturaDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.coche coche, prod.medida_cubierta medCubierta, serv.descripcion servicio, det.precio_unitario pUnitario, det.total importe, det.descripcion descripcion"; //feb 1.9.1
            sql = sql + " from ofc_factura factura, ofc_comprobante_temp c_temp, ofc_factura_detalle det, ofc_servicio serv, ofc_producto prod";
            sql = sql + " where factura.id = c_temp.id_origen";
            sql = sql + " and det.id_factura = factura.id";
            sql = sql + " and c_temp.comprobante = 'FACTURA'";
            sql = sql + " and serv.id = det.id_servicio";
            sql = sql + " and prod.id = det.id_producto";
            sql = sql + " and factura.id = @idFactura";
            sql = sql + " order by det.id_orden_de_trabajo, det.id_renglon_orden_de_trabajo, det.id";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDetalleDTO e = new FacturaDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
                e.codigo = data["codigo"].ToString();
                //e.descripcion = data["coche"].ToString() + " - " + data["medCubierta"].ToString() + " - " + data["servicio"].ToString();
                e.descripcion = data["descripcion"].ToString();
                e.precio_unitario = decimal.Parse(data["pUnitario"].ToString());
                e.importe = decimal.Parse(data["importe"].ToString());

                e.v_precio_unitario = String.Format("{0:0.00}", Math.Round(e.precio_unitario, 2, MidpointRounding.AwayFromZero));
                e.v_importe = String.Format("{0:0.00}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        //feb 1.9.1
        public static List<FacturaDetalleDTO> obtenerDetalleFW(long idFactura, decimal bonificacion, string alicuota)
        {
            List<FacturaDetalleDTO> lista = new List<FacturaDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.descripcion descripcion, det.precio_unitario pUnitario, det.iva_importe importeIva, det.total total, cliente.id_categoria_iva idIva";
            sql = sql + " from ofc_factura factura, ofc_factura_detalle det, ofc_cliente cliente";
            sql = sql + " where det.id_factura = factura.id";
            sql = sql + " and factura.id = @idFactura";
            sql = sql + " and cliente.id = factura.id_cliente";
            sql = sql + " and cliente.activo = 'S'";
            sql = sql + " order by det.id_orden_de_trabajo, det.id_renglon_orden_de_trabajo, det.id";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDetalleDTO e = new FacturaDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
                e.fw_unidad = int.Parse(ValorDTO.obtenerValorAdicional("FW", "comprobante/comprobanteDetalle/unidad"));
                //e.codigo = data["codigo"].ToString(); //feb 1.9.1
                e.descripcion = data["descripcion"].ToString();
                e.fw_alicuota = (int)ValorDTO.obtenerIdExterno("IV", alicuota);

                e.precio_unitario = decimal.Parse(data["pUnitario"].ToString());

                if (ValorDTO.obtenerValorAdicional(long.Parse(data["idIva"].ToString())) == "B" && alicuota == "IVA_105")
                {
                    decimal valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_105")); 
                    valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                    e.precio_unitario = decimal.Round((e.precio_unitario / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                }
                if (ValorDTO.obtenerValorAdicional(long.Parse(data["idIva"].ToString())) == "B" && alicuota == "IVA_21")
                {
                    decimal valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21")); 
                    valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                    e.precio_unitario = decimal.Round((e.precio_unitario / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                }

                e.precio_unitario = decimal.Round(e.precio_unitario, 2, MidpointRounding.AwayFromZero);
                e.v_precio_unitario = String.Format("{0:0.00}", e.precio_unitario);

                e.fw_importeIva = decimal.Parse(data["importeIva"].ToString());
                e.fw_importeIva = decimal.Round(e.fw_importeIva, 2, MidpointRounding.AwayFromZero);

                e.fw_totalConcepto = decimal.Parse(data["total"].ToString());
                e.fw_totalConcepto = decimal.Round(e.fw_totalConcepto, 2, MidpointRounding.AwayFromZero);

                if (e.precio_unitario > decimal.Zero)
                {
                    e.fw_porcentajeBonificacion = decimal.Round(bonificacion, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    e.fw_porcentajeBonificacion = decimal.Zero;
                }

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<FacturaDetalleDTO> obtenerDetalleFactReg(long idFactura)
        {
            List<FacturaDetalleDTO> lista = new List<FacturaDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.descripcion descripcion, det.precio_unitario pUnitario, COALESCE(det.total, det.importe) importe"; //feb 1.9.1
            sql = sql + " from ofc_factura factura, ofc_factura_detalle det";
            sql = sql + " where det.id_factura = factura.id and factura.id = @idFactura";
            sql = sql + " order by det.id_orden_de_trabajo, det.id_renglon_orden_de_trabajo, det.id";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDetalleDTO e = new FacturaDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();
                e.precio_unitario = decimal.Parse(data["pUnitario"].ToString());
                e.importe = decimal.Parse(data["importe"].ToString());

                e.v_precio_unitario = String.Format("{0:0.00}", Math.Round(e.precio_unitario, 2, MidpointRounding.AwayFromZero));
                e.v_importe = String.Format("{0:0.00}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));

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

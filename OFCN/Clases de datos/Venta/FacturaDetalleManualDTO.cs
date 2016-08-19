using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class FacturaDetalleManualDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
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



        public FacturaDetalleManualDTO()
        {
            id = -1;
            importe = Decimal.Zero;
            id_producto = -1;
            id_servicio = -1;
            cantidad = -1;
            precio_unitario = Decimal.Zero;
            v_precio_unitario = String.Empty;
            v_importe = String.Empty;

        }

        public static List<FacturaDetalleManualDTO> obtenerDetalleFact(long idFactura)
        {
            List<FacturaDetalleManualDTO> lista = new List<FacturaDetalleManualDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.precio_unitario pUnitario, det.total importe, det.descripcion descripcion"; //feb 1.9.1
            sql = sql + " from ofc_factura factura, ofc_comprobante_temp c_temp, ofc_factura_detalle det";
            sql = sql + " where factura.id = c_temp.id_origen";
            sql = sql + " and det.id_factura = factura.id";
            sql = sql + " and c_temp.comprobante = 'FACTURA'";
            sql = sql + " and factura.id = @idFactura";
            sql = sql + " order by det.id";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDetalleManualDTO e = new FacturaDetalleManualDTO();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    public class FacturaDeCompraDetalleDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_concepto;

        public long Id_concepto
        {
            get { return id_concepto; }
            set { id_concepto = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
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

        string v_precio_unitario;

        public string V_precio_unitario
        {
            get { return v_precio_unitario; }
            set { v_precio_unitario = value; }
        }

        Decimal importe;

        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
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

        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        char exento;

        public char Exento
        {
            get { return exento; }
            set { exento = value; }
        }

        //xx2
        string unidad;

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }


        public FacturaDeCompraDetalleDTO()
        {
            id = -1;
            id_concepto = -1;
            id_producto = -1;
            cantidad = -1;
            importe = Decimal.Zero;
            v_importe = String.Empty;
            precio_unitario = Decimal.Zero;
            v_precio_unitario = String.Empty;
            codigo = String.Empty;
            descripcion = String.Empty;
            id_factura = -1;
            exento = 'N';
            unidad = String.Empty; //xx2
        }

        public static List<FacturaDeCompraDetalleDTO> obtenerDetalleFactReg(long idFactura)
        {
            List<FacturaDeCompraDetalleDTO> lista = new List<FacturaDeCompraDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.unidad unidad, det.codigo codigo, det.descripcion descripcion, det.precio_unitario pUnitario, det.importe importe"; //xx2
            sql = sql + " from cpc_factura factura, cpc_factura_detalle det";
            sql = sql + " where det.id_factura = factura.id and factura.id = @idFactura";
            sql = sql + " order by det.id";

            parameters.Add(new NpgsqlParameter("idFactura", idFactura));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                FacturaDeCompraDetalleDTO e = new FacturaDeCompraDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
                e.unidad = data["unidad"].ToString(); //xx2
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

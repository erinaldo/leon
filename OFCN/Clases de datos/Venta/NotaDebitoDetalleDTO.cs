using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class NotaDebitoDetalleDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        string motivo;

        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
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

        string v_precio_unitario;

        public string V_precio_unitario
        {
            get { return v_precio_unitario; }
            set { v_precio_unitario = value; }
        }

        decimal importe;

        public decimal Importe
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


        long id_nota_debito;

        public long Id_nota_debito
        {
            get { return id_nota_debito; }
            set { id_nota_debito = value; }
        }

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        char es_item_exento;

        public char Es_item_exento
        {
            get { return es_item_exento; }
            set { es_item_exento = value; }
        }


        public NotaDebitoDetalleDTO()
        {
            id = -1;
            cantidad = -1;
            motivo = string.Empty;
            descripcion = string.Empty;
            precio_unitario = decimal.Zero;
            importe = decimal.Zero;
            id_nota_debito = -1;
            codigo = "NA";
            v_precio_unitario = string.Empty;
            v_importe = string.Empty;
            es_item_exento = 'N';
        }

        public static List<NotaDebitoDetalleDTO> obtenerDetalleDeb(long idDebito)
        {
            List<NotaDebitoDetalleDTO> lista = new List<NotaDebitoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();


            string sql = "select det.cantidad cantidad, det.precio_unitario pUnitario, det.importe importe, det.descripcion descripcion";
            sql = sql + " from ofc_nota_debito debito, ofc_comprobante_temp c_temp, ofc_nota_debito_detalle det";
            sql = sql + " where debito.id = c_temp.id_origen";
            sql = sql + " and det.id_nota_debito = debito.id";
            sql = sql + " and c_temp.comprobante = 'NOTA DEBITO'";
            sql = sql + " and debito.id = @idDebito";
            sql = sql + " order by det.id";

            parameters.Add(new NpgsqlParameter("idDebito", idDebito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                NotaDebitoDetalleDTO e = new NotaDebitoDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
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


        public static List<NotaDebitoDetalleDTO> obtenerDetalleReg(long idDebito)
        {
            List<NotaDebitoDetalleDTO> lista = new List<NotaDebitoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.precio_unitario pUnitario, det.importe importe, det.descripcion descripcion";
            sql = sql + " from ofc_nota_debito debito, ofc_nota_debito_detalle det";
            sql = sql + " where det.id_nota_debito = debito.id";
            sql = sql + " and debito.id = @idDebito";
            sql = sql + " order by det.id";

            parameters.Add(new NpgsqlParameter("idDebito", idDebito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                NotaDebitoDetalleDTO e = new NotaDebitoDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
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

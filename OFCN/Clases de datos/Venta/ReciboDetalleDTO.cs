using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ReciboDetalleDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_recibo;

        public long Id_recibo
        {
            get { return id_recibo; }
            set { id_recibo = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        long id_modalidad_de_pago;

        public long Id_modalidad_de_pago
        {
            get { return id_modalidad_de_pago; }
            set { id_modalidad_de_pago = value; }
        }

        string modalidad_de_pago;

        public string Modalidad_de_pago
        {
            get { return modalidad_de_pago; }
            set { modalidad_de_pago = value; }
        }

        string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
        }

        long id_tipo_retencion;

        public long Id_tipo_retencion
        {
            get { return id_tipo_retencion; }
            set { id_tipo_retencion = value; }
        }

        public ReciboDetalleDTO()
        {
            id = -1;
            importe = decimal.Zero;
            id_modalidad_de_pago = -1;
            modalidad_de_pago = string.Empty;
            v_importe = string.Empty;
            detalle = string.Empty;
            id_tipo_retencion = -1;
        }

        public static List<ReciboDetalleDTO> obtenerReciboDetalleReg(long idRecibo)
        {
            List<ReciboDetalleDTO> lista = new List<ReciboDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select val.valor modalidad_pago, det.detalle detalle, det.importe importe, det.id_tipo_retencion id_tipo_retencion";
            sql = sql + " from ofc_recibo_detalle det, ofc_tabla_valor val";
            sql = sql + " where det.id_modalidad_pago = val.id";
            sql = sql + " and det.id_recibo = @idRecibo";
            sql = sql + " and val.id_tabla = 'MP' order by det.id";

            parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ReciboDetalleDTO e = new ReciboDetalleDTO();
                e.modalidad_de_pago = data["modalidad_pago"].ToString();
                if (e.modalidad_de_pago != "RETENCION")
                {
                    e.detalle = data["detalle"].ToString();
                }
                else
                {
                    e.detalle = ValorDTO.obtenerValor(long.Parse(data["id_tipo_retencion"].ToString())) + " - " + data["detalle"].ToString();
                }
                e.importe = decimal.Parse(data["importe"].ToString());
                e.v_importe = String.Format("{0:0.00}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        //feb 1.8
        public static List<string> obtenerReciboFacturaReg(long idRecibo)
        {
            List<string> lista = new List<string>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.cod_comprobante cod_comprobante";
            sql = sql + " from ofc_recibo recibo, ofc_recibo_comprobante r_factura,";
            sql = sql + " ofc_comprobante comp, ofc_tabla_valor tipo";
            sql = sql + " where recibo.id = r_factura.id_recibo";
            sql = sql + " and r_factura.id_origen = comp.id_origen";
            sql = sql + " and comp.id_tipo_comprobante = tipo.id";
            sql = sql + " and r_factura.id_tipo_comprobante = tipo.id";
            sql = sql + " and tipo.id_tabla = 'TC'";
            //sql = sql + " and tipo.valor like 'FACTURA%'"; //feb 1.8 fix
            sql = sql + " and recibo.id = @idRecibo";

            parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                string e = data["cod_comprobante"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;

        }

        public static void insertar(List<ReciboDetalleDTO> dataRecibo, long idRecibo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idReciboDetalle = -1;

            foreach (ReciboDetalleDTO ReciboDet in dataRecibo)
            {

                string sql = "select nextval('ofc_recibo_detalle_id_seq') idReciboDetalle";
                //nuevo id de recibo
                NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

                if (data != null && data.Read())
                {
                    idReciboDetalle = long.Parse(data["idReciboDetalle"].ToString());
                    data.Close();
                }

                //genero recibo
                sql = "INSERT INTO ofc_recibo_detalle("
                + " id, importe, id_modalidad_pago, detalle, id_recibo, id_tipo_retencion)"
                + " VALUES (@idReciboDetalle, @importe, @idPago, @detalle, @idRecibo, @idTipoRetencion);";

                parameters.Add(new NpgsqlParameter("idReciboDetalle", idReciboDetalle));
                parameters.Add(new NpgsqlParameter("importe", ReciboDet.importe));
                parameters.Add(new NpgsqlParameter("idPago", ReciboDet.id_modalidad_de_pago));
                parameters.Add(new NpgsqlParameter("idTipoRetencion", ReciboDet.id_tipo_retencion));
                parameters.Add(new NpgsqlParameter("detalle", ReciboDet.detalle));
                parameters.Add(new NpgsqlParameter("idRecibo", idRecibo));

                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }


    }
}

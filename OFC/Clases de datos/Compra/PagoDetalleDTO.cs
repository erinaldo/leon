using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace OFC
{
    class PagoDetalleDTO
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

        long id_pago;

        public long Id_pago
        {
            get { return id_pago; }
            set { id_pago = value; }
        }

        long id_tipo_retencion;

        public long Id_tipo_retencion
        {
            get { return id_tipo_retencion; }
            set { id_tipo_retencion = value; }
        }

        PagoDetalleRetencionDTO detalleRetencion;

        public PagoDetalleRetencionDTO DetalleRetencion
        {
            get { return detalleRetencion; }
            set { detalleRetencion = value; }
        }

        public PagoDetalleDTO()
        {
            id = -1;
            importe = decimal.Zero;
            id_modalidad_de_pago = -1;
            modalidad_de_pago = string.Empty;
            v_importe = string.Empty;
            detalle = string.Empty;
            id_pago = -1;
            id_tipo_retencion = -1;
            detalleRetencion = new PagoDetalleRetencionDTO();
        }

        public static void insertar(List<PagoDetalleDTO> dataPago, long idPago)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idPagoDetalle = -1;

            foreach (PagoDetalleDTO PagoDet in dataPago)
            {

                string sql = "select nextval('cpc_pago_detalle_id_seq') idPagoDetalle";
                //nuevo id de pago
                NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

                if (data != null && data.Read())
                {
                    idPagoDetalle = long.Parse(data["idPagoDetalle"].ToString());
                    data.Close();
                }

                //genero pago
                sql = "INSERT INTO cpc_pago_detalle("
                + " id, importe, id_modalidad_pago, detalle, id_pago, id_tipo_retencion)"
                + " VALUES (@idPagoDetalle, @importe, @idModalidadPago, @detalle, @idPago, @idTipoRetencion);";

                parameters.Add(new NpgsqlParameter("idPagoDetalle", idPagoDetalle));
                parameters.Add(new NpgsqlParameter("importe", PagoDet.importe));
                parameters.Add(new NpgsqlParameter("idModalidadPago", PagoDet.id_modalidad_de_pago));
                parameters.Add(new NpgsqlParameter("detalle", PagoDet.detalle));
                parameters.Add(new NpgsqlParameter("idPago", idPago));
                parameters.Add(new NpgsqlParameter("idTipoRetencion", PagoDet.id_tipo_retencion));

                BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

                if (PagoDet.id_tipo_retencion != -1 && PagoDet.detalleRetencion.Periodo_anio != -1 && PagoDet.detalleRetencion.Periodo_mes != -1)
                {
                    PagoDet.detalleRetencion.Id_pago = idPago;
                    PagoDet.detalleRetencion.Id_pago_detalle = idPagoDetalle;
                    PagoDet.detalleRetencion.Id_certificado = ParametroDTO.obtenerParametroII("ID_CERTIFICADO");
                    PagoDetalleRetencionDTO.insertar(PagoDet.detalleRetencion);
                    ParametroDTO.actualizarParamII("ID_CERTIFICADO", PagoDet.detalleRetencion.Id_certificado + 1);
                }
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

        }

        public static List<PagoDetalleDTO> obtenerDetallePagoReg(long idOrdenDePago)
        {
            List<PagoDetalleDTO> lista = new List<PagoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select mop.valor modalidadPago, ret.valor tipoRetencion, pago.detalle detalle, pago.importe importe, pago.id_tipo_retencion idTipoRetencion";
            sql = sql + " from ofc_tabla_valor mop, cpc_pago_detalle pago left join ofc_tabla_valor ret on (ret.id = pago.id_tipo_retencion and ret.id_tabla = 'TR')";
            sql = sql + " where mop.id = pago.id_modalidad_pago";
            sql = sql + " and mop.id_tabla = 'FP'";
            sql = sql + " and pago.id_pago = @idOrdenDePago";
       
            parameters.Add(new NpgsqlParameter("idOrdenDePago", idOrdenDePago));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                PagoDetalleDTO e = new PagoDetalleDTO();

                e.modalidad_de_pago = data["modalidadPago"].ToString();
                if (data["tipoRetencion"].ToString() != string.Empty){
                    e.modalidad_de_pago += " - " + data["tipoRetencion"].ToString();
                }
                e.detalle = data["detalle"].ToString();
                e.importe = decimal.Parse(data["importe"].ToString());
                e.id_tipo_retencion = long.Parse(data["idTipoRetencion"].ToString());

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

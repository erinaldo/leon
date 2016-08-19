using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;


namespace OFC
{
    class CobranzaDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
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
        string nro_comprobante;

        public string Nro_comprobante
        {
            get { return nro_comprobante; }
            set { nro_comprobante = value; }
        }
        decimal mp_cheque;

        public decimal Mp_cheque
        {
            get { return mp_cheque; }
            set { mp_cheque = value; }
        }
        decimal mp_efectivo;

        public decimal Mp_efectivo
        {
            get { return mp_efectivo; }
            set { mp_efectivo = value; }
        }
        decimal mp_tarjeta_de_credito;

        public decimal Mp_tarjeta_de_credito
        {
            get { return mp_tarjeta_de_credito; }
            set { mp_tarjeta_de_credito = value; }
        }
        decimal mp_tarjeta_de_debito;

        public decimal Mp_tarjeta_de_debito
        {
            get { return mp_tarjeta_de_debito; }
            set { mp_tarjeta_de_debito = value; }
        }
        decimal mp_deposito_bancario;

        public decimal Mp_deposito_bancario
        {
            get { return mp_deposito_bancario; }
            set { mp_deposito_bancario = value; }
        }
        decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        decimal mp_retencion;

        public decimal Mp_retencion
        {
            get { return mp_retencion; }
            set { mp_retencion = value; }
        }

        public CobranzaDTO()
        {
            id = -1;
            fecha = DateTime.Now;
            id_cliente = string.Empty;
            nombre_cliente = string.Empty;
            nro_comprobante = string.Empty;
            mp_cheque = decimal.Zero;
            mp_efectivo = decimal.Zero;
            mp_tarjeta_de_credito = decimal.Zero;
            mp_tarjeta_de_debito = decimal.Zero;
            mp_deposito_bancario = decimal.Zero;
            total = decimal.Zero;
            mp_retencion = decimal.Zero;
        }

        public CobranzaDTO(ReciboDTO recibo, string cod_comprobante_recibo)
        {
            fecha = DateTime.Now;
            id_cliente = recibo.Id_cliente;
            nombre_cliente = recibo.Nombre_cliente;
            nro_comprobante = cod_comprobante_recibo;
            mp_cheque = decimal.Zero;
            mp_efectivo = decimal.Zero;
            mp_tarjeta_de_credito = decimal.Zero;
            mp_tarjeta_de_debito = decimal.Zero;
            mp_deposito_bancario = decimal.Zero;
            mp_retencion = decimal.Zero;

            foreach (ReciboDetalleDTO det in recibo.List_recibo_detalle)
            {
                if (det.Modalidad_de_pago == "CHEQUE")
                {
                    mp_cheque += det.Importe;
                }
                if (det.Modalidad_de_pago == "EFECTIVO")
                {
                    mp_efectivo += det.Importe;
                }
                if (det.Modalidad_de_pago == "TARJETA DE CREDITO")
                {
                    mp_tarjeta_de_credito += det.Importe;
                }
                if (det.Modalidad_de_pago == "TARJETA DE DEBITO")
                {
                    mp_tarjeta_de_debito += det.Importe;
                }
                if (det.Modalidad_de_pago == "DEPOSITO BANCARIO")
                {
                    mp_deposito_bancario += det.Importe;
                }
                if (det.Modalidad_de_pago == "RETENCION")
                {
                    mp_retencion += det.Importe;
                }
            }

            total = recibo.Importe;
        }

        public void registrar()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO ofc_cobranza (id, fecha, id_cliente, nombre_cliente, nro_comprobante, mp_cheque, mp_efectivo, mp_tarjeta_de_credito, mp_tarjeta_de_debito, mp_deposito_bancario, total, mp_retencion) VALUES (nextval('ofc_cobranza_id_seq'), @fecha, @idCliente, @nombreCliente, @comprobante, @cheque, @efectivo, @tarjetaDeCredito, @tarjetaDeDebito, @deposito, @total, @retencion);";

            parameters.Add(new NpgsqlParameter("fecha", fecha));
            parameters.Add(new NpgsqlParameter("idCliente", id_cliente));
            parameters.Add(new NpgsqlParameter("nombreCliente", nombre_cliente));
            parameters.Add(new NpgsqlParameter("comprobante", nro_comprobante));
            parameters.Add(new NpgsqlParameter("cheque", mp_cheque));
            parameters.Add(new NpgsqlParameter("efectivo", mp_efectivo));
            parameters.Add(new NpgsqlParameter("tarjetaDeCredito", mp_tarjeta_de_credito));
            parameters.Add(new NpgsqlParameter("tarjetaDeDebito", mp_tarjeta_de_debito));
            parameters.Add(new NpgsqlParameter("deposito", mp_deposito_bancario));
            parameters.Add(new NpgsqlParameter("total", total));
            parameters.Add(new NpgsqlParameter("retencion", mp_retencion));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace OFC
{
    class PagosDTO
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

        string nro_comprobante;

        public string Nro_comprobante
        {
            get { return nro_comprobante; }
            set { nro_comprobante = value; }
        }

        decimal mp_cheque_tercero;

        public decimal Mp_cheque_tercero
        {
            get { return mp_cheque_tercero; }
            set { mp_cheque_tercero = value; }
        }

        decimal mp_efectivo;

        public decimal Mp_efectivo
        {
            get { return mp_efectivo; }
            set { mp_efectivo = value; }
        }

        decimal mp_cheque_propio;

        public decimal Mp_cheque_propio
        {
            get { return mp_cheque_propio; }
            set { mp_cheque_propio = value; }
        }

        decimal mp_transferencia_bancaria;

        public decimal Mp_transferencia_bancaria
        {
            get { return mp_transferencia_bancaria; }
            set { mp_transferencia_bancaria = value; }
        }

        decimal mp_tarjeta_credito;

        public decimal Mp_tarjeta_credito
        {
            get { return mp_tarjeta_credito; }
            set { mp_tarjeta_credito = value; }
        }

        decimal mp_tarjeta_debito;

        public decimal Mp_tarjeta_debito
        {
            get { return mp_tarjeta_debito; }
            set { mp_tarjeta_debito = value; }
        }

        decimal mp_otro;

        public decimal Mp_otro
        {
            get { return mp_otro; }
            set { mp_otro = value; }
        }

        decimal mp_retencion;

        public decimal Mp_retencion
        {
            get { return mp_retencion; }
            set { mp_retencion = value; }
        }

        decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public PagosDTO()
        {
            id = -1;
            fecha = DateTime.Now;
            id_proveedor = string.Empty;
            nombre_proveedor = string.Empty;
            nro_comprobante = string.Empty;
            mp_cheque_tercero = decimal.Zero;
            mp_efectivo = decimal.Zero;
            mp_cheque_propio = decimal.Zero;
            mp_transferencia_bancaria = decimal.Zero;
            mp_tarjeta_credito = decimal.Zero;
            mp_tarjeta_debito = decimal.Zero;
            mp_otro = decimal.Zero;
            mp_retencion = decimal.Zero;
            total = decimal.Zero;
        }

        public PagosDTO(PagoDTO pago, string cod_comprobante_pago)
        {
            fecha = pago.Fecha_comprobante;
            id_proveedor = pago.Id_proveedor;
            nombre_proveedor = pago.Nombre_proveedor;
            nro_comprobante = cod_comprobante_pago;
            mp_cheque_tercero = decimal.Zero;
            mp_efectivo = decimal.Zero;
            mp_cheque_propio = decimal.Zero;
            mp_transferencia_bancaria = decimal.Zero;
            mp_tarjeta_credito = decimal.Zero;
            mp_tarjeta_debito = decimal.Zero;
            mp_otro = decimal.Zero;
            mp_retencion = decimal.Zero;

            foreach (PagoDetalleDTO det in pago.List_pago_detalle)
            {
                if (det.Modalidad_de_pago == "CHEQUE DE TERCERO")
                {
                    mp_cheque_tercero += det.Importe;
                }
                if (det.Modalidad_de_pago == "EFECTIVO")
                {
                    mp_efectivo += det.Importe;
                }
                if (det.Modalidad_de_pago == "CHEQUE PROPIO")
                {
                    mp_cheque_propio += det.Importe;
                }
                if (det.Modalidad_de_pago == "TRANSFERENCIA BANCARIA")
                {
                    mp_transferencia_bancaria += det.Importe;
                }
                if (det.Modalidad_de_pago == "TARJETA DE CREDITO")
                {
                    mp_tarjeta_credito += det.Importe;
                }
                if (det.Modalidad_de_pago == "TARJETA DE DEBITO")
                {
                    mp_tarjeta_debito += det.Importe;
                }
                if (det.Modalidad_de_pago == "OTRO")
                {
                    mp_otro += det.Importe;
                }
                if (det.Modalidad_de_pago == "RETENCION")
                {
                    mp_retencion += det.Importe;
                }
            }

            total = pago.Importe;
        }

        public void registrar()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_pagos (id, fecha, id_proveedor, nombre_proveedor, nro_comprobante, mp_cheque_tercero, mp_efectivo, mp_cheque_propio, mp_transferencia_bancaria, mp_tarjeta_credito, mp_tarjeta_debito, mp_otro, mp_retencion, total) VALUES (nextval('cpc_pagos_id_seq'), @fecha, @idProveedor, @nombreProveedor, @comprobante, @cheque_tercero, @efectivo, @cheque_propio, @transferencia_bancaria, @tarjeta_credito, @tarjeta_debito, @otro, @retencion, @total);";

            parameters.Add(new NpgsqlParameter("fecha", fecha));
            parameters.Add(new NpgsqlParameter("idProveedor", id_proveedor));
            parameters.Add(new NpgsqlParameter("nombreProveedor", nombre_proveedor));
            parameters.Add(new NpgsqlParameter("comprobante", nro_comprobante));
            parameters.Add(new NpgsqlParameter("cheque_tercero", mp_cheque_tercero));
            parameters.Add(new NpgsqlParameter("efectivo", mp_efectivo));
            parameters.Add(new NpgsqlParameter("cheque_propio", mp_cheque_propio));
            parameters.Add(new NpgsqlParameter("transferencia_bancaria", mp_transferencia_bancaria));
            parameters.Add(new NpgsqlParameter("tarjeta_credito", mp_tarjeta_credito));
            parameters.Add(new NpgsqlParameter("tarjeta_debito", mp_tarjeta_debito));
            parameters.Add(new NpgsqlParameter("otro", mp_otro));
            parameters.Add(new NpgsqlParameter("retencion", mp_retencion));
            parameters.Add(new NpgsqlParameter("total", total));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace OFC
{
    class GenerarImpresionOrdenDePago
    {
        public static crOrdenDePago cargarReporte(string cod_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionordendepago('" + cod_comprobante + "') as (nro_pago character varying(15), nombre_proveedor character varying(255), fecha date, total double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsOrdenDePago dsLista = new dsOrdenDePago();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crOrdenDePago rptLista = new crOrdenDePago();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtPago");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from datosempresa('" + BaseDeDatos.empresa + "') as (razon_social character varying(255), domicilio character varying(255), localidad character varying(255), provincia character varying(255), telefono_1 character varying(255), web character varying(255), cp character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosEmpresa");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionretencionsumarizadaop('" + cod_comprobante + "') as (id_pago bigint, periodo character varying(255), importe_orden_de_pago double precision, importe_neto double precision, importe_pagos_anteriores double precision, importe_retencion_actual double precision, importe_retencion_anterior double precision, importe_retencion_periodo double precision, titulo unknown, id_certificado bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtRetencionDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            foreach (DataRow dtRowRetencion in dsLista.dtRetencionDetalle.Rows)
            {
                string _titulo = dtRowRetencion["titulo"].ToString();
                string _periodo = "PERIODO: " + dtRowRetencion["periodo"].ToString();
                string _importe_orden_de_pago = "IMPORTE ORDEN DE PAGO: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_orden_de_pago"].ToString()));
                string _importe_neto = "IMPORTE NETO: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_neto"].ToString()));
                string _importe_pagos_anteriores = "IMPORTE PAGOS ANTERIORES: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_pagos_anteriores"].ToString()));
                string _importe_calculo_retencion = "CALCULO RETENCION: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_retencion_periodo"].ToString()));
                string _importe_retencion_anterior = "IMPORTE RETENCION ANTERIOR: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_retencion_anterior"].ToString()));
                string _importe_retencion_actual = "IMPORTE RETENCION ACTUAL: $ " + String.Format("{0:0.00}", decimal.Parse(dtRowRetencion["importe_retencion_actual"].ToString()));
                string _id_certificado = "CERTIFICADO N°: " + dtRowRetencion["id_certificado"].ToString();
                dsLista.dtDescripcionRetencion.AdddtDescripcionRetencionRow(_titulo, _periodo, _importe_orden_de_pago, _importe_neto, _importe_pagos_anteriores, _importe_calculo_retencion, _importe_retencion_anterior, _importe_retencion_actual, _id_certificado);
            }

            cmComando.CommandText = "select * from impresiondetalleordendepago('" + cod_comprobante + "') as (modalidad_pago character varying(255), detalle character varying(255), importe double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtPagoDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionfacturaordendepago('" + cod_comprobante + "') as (cod_comprobante character varying(30), importe double precision, fecha_comprobante date, pago_parcial character(1), id_origen bigint, id_tipo_comprobante bigint)"; //levantar id_origen y id_tipo_comprobante. Agregar los campos en el ds
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtFacturasDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            //unificacion de los datos para que salga lindo el reporte
            List<string> v_cod_comprobante = new List<string>();
            List<decimal> v_importe = new List<decimal>();
            List<string> v_modalidad_pago = new List<string>();
            List<string> v_detalle = new List<string>();
            List<decimal> v_importe_detalle = new List<decimal>();
            List<string> v_fecha_comprobante = new List<string>();

            //guardo las facturas a pagar
            foreach (DataRow dtRowFactura in dsLista.dtFacturasDetalle.Rows)
            {
                //registro comprobante
                v_fecha_comprobante.Add(String.Format("{0:dd/MM/yyyy}", DateTime.Parse(dtRowFactura["fecha_comprobante"].ToString())));
                string detalle_cod_comprobante = dtRowFactura["cod_comprobante"].ToString();
                if (dtRowFactura["pago_parcial"].ToString() == "S") //si es pago parcial, incluyo la leyenda "A CUENTA"
                {
                    detalle_cod_comprobante += " (A/CTA)";
                }
                v_cod_comprobante.Add(detalle_cod_comprobante);
                v_importe.Add(decimal.Parse(dtRowFactura["importe"].ToString()));

                //registro pago a cuenta del comprobante
                if (dtRowFactura["pago_parcial"].ToString() == "N") //si no es pago parcial, levanto los pagos a cuenta para informarlos
                {
                    //levanto pagos parciales y los recorro
                    List<PagoDTO> pagosParciales = PagoDTO.obtenerPagosParciales(long.Parse(dtRowFactura["id_origen"].ToString()), long.Parse(dtRowFactura["id_tipo_comprobante"].ToString()));

                    foreach (PagoDTO pagoParcial in pagosParciales)
                    {
                        string detalle_cod_comprobante_aux = detalle_cod_comprobante;
                        v_fecha_comprobante.Add(string.Empty);
                        detalle_cod_comprobante_aux += " (A/CTA OP " + pagoParcial.Cod_comprobante + ")";
                        v_cod_comprobante.Add(detalle_cod_comprobante_aux);
                        v_importe.Add(pagoParcial.Importe * (-1));
                    }
                }

            }

            //guardo el detalle del pago
            foreach (DataRow dtRowDetalle in dsLista.dtPagoDetalle.Rows)
            {
                v_modalidad_pago.Add(dtRowDetalle[0].ToString());
                v_detalle.Add(dtRowDetalle[1].ToString());
                v_importe_detalle.Add(decimal.Parse(dtRowDetalle[2].ToString()));
            }

            int i = 0;
            int cant_max = 0;

            if (v_cod_comprobante.Count > v_modalidad_pago.Count)
            {
                cant_max = v_cod_comprobante.Count;
            }
            else
            {
                cant_max = v_modalidad_pago.Count;
            }

            while (i < cant_max)
            {
                string _fecha_comprobante = string.Empty;
                string _cod_comprobante = string.Empty;
                decimal _importe = decimal.Zero;
                string _modalidad_pago = string.Empty;
                string _detalle = string.Empty;
                decimal _importe_detalle = decimal.Zero;

                if (v_fecha_comprobante.Count > i)
                {
                    _fecha_comprobante = v_fecha_comprobante[i];
                }

                if (v_cod_comprobante.Count > i)
                {
                    _cod_comprobante = v_cod_comprobante[i];
                }

                if (v_importe.Count > i)
                {
                    _importe = v_importe[i];
                }

                if (v_modalidad_pago.Count > i)
                {
                    _modalidad_pago = v_modalidad_pago[i];
                }

                if (v_detalle.Count > i)
                {
                    _detalle = v_detalle[i];
                }

                if (v_importe_detalle.Count > i)
                {
                    _importe_detalle = v_importe_detalle[i];
                }

                dsLista.dtDetalleFinal.AdddtDetalleFinalRow(_cod_comprobante, _importe, _modalidad_pago, _detalle, _importe_detalle, _fecha_comprobante);

                i++;
            }


            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }

        public static crRetencion cargarReporteRetencion(string cod_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresionretencionordendepago('" + cod_comprobante + "') as (periodo character varying(255), importe_orden_de_pago double precision, importe_neto double precision, importe_pagos_anteriores double precision, importe_retencion double precision, importe_retencion_anterior double precision, importe_retencion_periodo double precision, descripcion character varying(255))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsOrdenDePago dsLista = new dsOrdenDePago();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crRetencion rptLista = new crRetencion();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtRetencionDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from impresionordendepago('" + cod_comprobante + "') as (nro_pago character varying(15), nombre_proveedor character varying(255), fecha date, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtPago");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from datosempresa('" + BaseDeDatos.empresa + "') as (razon_social character varying(255), domicilio character varying(255), localidad character varying(255), provincia character varying(255), telefono_1 character varying(255), web character varying(255), cp character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosEmpresa");
            rptLista.SetDataSource(dsLista);
            data.Dispose();



            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }


        public static crComprobanteDeRetencion cargarReporteComprobanteDeRetencion(string cod_comprobante, string cod_proveedor, DateTime fecha_comprobante)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from impresiondescripcionretencion('" + cod_comprobante + "') as (fecha date, comprobante character varying(20), importe_bruto double precision, importe_neto double precision, base_de_calculo double precision, calculo_retencion double precision, importe_retencion_anterior double precision, importe_retencion_actual double precision, id_certificado bigint)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsRetención dsLista = new dsRetención();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crComprobanteDeRetencion rptLista = new crComprobanteDeRetencion();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcionRetencion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            int dias_transcurridos = fecha_comprobante.Day * (-1);
            DateTime fecha_principio_de_mes = fecha_comprobante;
            fecha_principio_de_mes = fecha_principio_de_mes.AddDays(dias_transcurridos + 1);

            cmComando.CommandText = "select * from idcertificadopagosanteriores('" + cod_comprobante + "', '" + cod_proveedor + "', '" + fecha_principio_de_mes.ToShortDateString() + "', '" + fecha_comprobante.ToShortDateString() + "') as (id_certificado bigint)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtIdCertificado");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            string _ids_certificado = string.Empty;
            int i = 0;
            foreach (DataRow dtRowIdCertificado in dsLista.dtIdCertificado.Rows)
            {
                if (i == 0)
                {
                    _ids_certificado += dtRowIdCertificado["id_certificado"].ToString();
                }
                else
                {
                    _ids_certificado += " | ";
                    _ids_certificado += dtRowIdCertificado["id_certificado"].ToString();
                }
                i += 1;
            }

            dsLista.dtDescripcionRetencion[0].id_certificado_anteriores = _ids_certificado;

            Conversion c = new Conversion();
            dsLista.dtDescripcionRetencion[0].letras_retencion_actual = "( " + c.enletras(dsLista.dtDescripcionRetencion[0].importe_retencion_actual.ToString()).ToLower() + " )";

            cmComando.CommandText = "select * from agentederetencion('" + BaseDeDatos.empresa + "') as (razon_social character varying(255), domicilio_real character varying(255), localidad_real character varying(255), provincia_real character varying(255), domicilio_legal character varying(255), cp_legal character varying(255), localidad_legal character varying(255), cuit character varying(255), domicilio_fiscal character varying(255), cp_fiscal character varying(255), localidad_fiscal character varying(255), cp_real character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtAgenteDeRetencion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from contribuyente('" + cod_proveedor + "') as (razon_social character varying(255), cuit character varying(255), domicilio character varying(255), localidad character varying(255), provincia character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtContribuyente");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from pagosanteriores('" + cod_comprobante + "', '" + cod_proveedor + "', '" + fecha_principio_de_mes.ToShortDateString() + "', '" + fecha_comprobante.ToShortDateString() + "') as (fecha date, comprobante character varying(20), importe_bruto double precision, importe_neto double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcionPagosAnteriores");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }

    }
}

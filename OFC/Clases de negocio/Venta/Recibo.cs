using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Recibo
    {
        IList<ReciboDTO> _GridDataListReg;

        public IList<ReciboDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<ReciboDetalleDTO> _GridDataListDetalleReg;

        public IList<ReciboDetalleDTO> GridDataListDetalleReg
        {
            get { return _GridDataListDetalleReg; }
            set { _GridDataListDetalleReg = value; }
        }

        IList<string> _GridDataListFacturaReg;

        public IList<string> GridDataListFacturaReg
        {
            get { return _GridDataListFacturaReg; }
            set { _GridDataListFacturaReg = value; }
        }


        public void refreshGridDataReg(long idRecibo)
        {
            try
            {
                this._GridDataListReg = ReciboDTO.obtenerReciboReg(idRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el recibo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idRecibo)
        {
            try
            {
                this._GridDataListDetalleReg = ReciboDetalleDTO.obtenerReciboDetalleReg(idRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle del recibo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataFacturaReg(long idRecibo)
        {
            try
            {
                this._GridDataListFacturaReg = ReciboDetalleDTO.obtenerReciboFacturaReg(idRecibo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las facturas asociadas al recibo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.8
        public bool isValid(ReciboDTO data, ref string msg)
        {

            bool rv = true;

            if (ComprobanteDTO.existeRecibo(data.Nro_recibo))
            {
                rv = false;
                msg += "\nEl número de recibo ya se encuenta ingresado.";
            }

            return rv;

        }

        //feb 1.8
        public void registrar(ReciboDTO data)
        {
            try
            {
                data.Id = ReciboDTO.insertar(data); //inserta en ofc_recibo, actualiza ofc_factura y todo el resto..
                string cod_comprobante_recibo = ComprobanteDTO.insertar("RECIBO", data);
                MovimientoDTO.generarRecibo(data);
                CobranzaDTO cobrado = new CobranzaDTO(data, cod_comprobante_recibo);
                TalonarioDetalleDTO.actualizarEstado(cod_comprobante_recibo, "INGRESADO");
                cobrado.registrar();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar el recibo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void anular(ReciboDTO data)
        {
            try
            {
                ReciboDTO.eliminar(data);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular el recibo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }

        }

        public void recalcularMovimientosPost(ReciboDTO data)
        {
            ReciboDTO.recalcularMovimientosPost(data.Id, ValorDTO.obtenerId("RECIBO"));
        }

        //feb 1.8
        public List<string> ejecutarValidacionDeInventario(string nro_recibo)
        {
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI("DIGITOS NRO RECIBO").ToString());
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI("INICIO NRO RECIBO").ToString());
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII("DIGITOS NRO RECIBO").ToString());

            List<string> validaciones = new List<string>();
            long nro_recibo_aux = long.Parse(nro_recibo);
            string nro_comprobante_recibo = ComprobanteDTO.converToNroReciboSinAccesoBD(cantDigitosA, valorDigitosA, cantDigitosB, nro_recibo_aux.ToString());
            long cantidadDeNumerosAValidar = ParametroDTO.obtenerParametroI("VALIDACION NUMERO DE RECIBO");
            int contador = 1;

            if (TalonarioDetalleDTO.getEstado(nro_comprobante_recibo) == "INGRESADO")
            {
                validaciones.Add("El número de comprobante " + nro_comprobante_recibo + " ya fue ingresado al sistema.");
            }

            nro_comprobante_recibo = ComprobanteDTO.converToNroReciboSinAccesoBD(cantDigitosA, valorDigitosA, cantDigitosB, (nro_recibo_aux - contador).ToString());

            while (contador < cantidadDeNumerosAValidar)
            {
                string estado_inventario = TalonarioDetalleDTO.getEstado(nro_comprobante_recibo);

                if (estado_inventario == "DISPONIBLE")
                {
                    validaciones.Add("El número de comprobante " + nro_comprobante_recibo + " aún no fue ingresado al sistema.");
                }

                contador++;

                nro_comprobante_recibo = ComprobanteDTO.converToNroReciboSinAccesoBD(cantDigitosA, valorDigitosA, cantDigitosB, (nro_recibo_aux - contador).ToString());

            }

            return validaciones;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Pago
    {
        long nro_pago;

        public long Nro_pago
        {
            get { return nro_pago; }
            set { nro_pago = value; }
        }

        IList<PagoDTO> _GridDataListPagosDelMes;

        public IList<PagoDTO> GridDataListPagosDelMes
        {
            get { return _GridDataListPagosDelMes; }
            set { _GridDataListPagosDelMes = value; }
        }

        IList<PagoDTO> _GridDataListReg;

        public IList<PagoDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<PagoDetalleDTO> _GridDataListDetalleReg;

        public IList<PagoDetalleDTO> GridDataListDetalleReg
        {
            get { return _GridDataListDetalleReg; }
            set { _GridDataListDetalleReg = value; }
        }

        IList<FacturaDeCompraDTO> _GridDataListComprobantesRel;

        public IList<FacturaDeCompraDTO> GridDataListComprobantesRel
        {
            get { return _GridDataListComprobantesRel; }
            set { _GridDataListComprobantesRel = value; }
        }

        public Pago()
        {
            iniciarPago();
        }

        public void iniciarPago(){
            nro_pago = PagoDTO.obtenerNuevoNro();
        }

        public string registrar(PagoDTO data)
        {
            try
            {
                data.Id = PagoDTO.insertar(data); //inserta en cpc_pago, actualiza cpc_factura y todo el resto..
                string cod_comprobante_pago = ComprobanteCompraDTO.insertar("ORDEN DE PAGO", data);

                //inserto movimiento de cuenta
                decimal saldoBase = MovimientoProvDTO.getSaldoBase(data.Fecha_comprobante, data.Id_proveedor);
                long idMovimiento = MovimientoProvDTO.generarPago(data, cod_comprobante_pago, saldoBase);
                MovimientoProvDTO.recalcularMovimientosPostComprobante(idMovimiento, saldoBase - data.Importe);

                ParametroDTO.actualizarParamII("INICIO NRO ORDEN DE PAGO", long.Parse(data.Nro_pago));
                PagosDTO pagado = new PagosDTO(data, cod_comprobante_pago);
                pagado.registrar();
                return cod_comprobante_pago;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la orden de pago. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataPagoDelMes(string cod_proveedor, DateTime fecha_orden_de_pago)
        {
            try
            {
                this._GridDataListPagosDelMes = PagoDTO.obtenerPagosDelMes(cod_proveedor, fecha_orden_de_pago);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los pagos a proveedores. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idOrdenDePago)
        {
            try
            {
                this._GridDataListReg = PagoDTO.obtenerPagoReg(idOrdenDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la orden de pago. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idOrdenDePago)
        {
            try
            {
                this._GridDataListDetalleReg = PagoDetalleDTO.obtenerDetallePagoReg(idOrdenDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la orden de pago. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataComprobantesRel(long idOrdenDePago)
        {
            try
            {
                this._GridDataListComprobantesRel = PagoDTO.obtenerFacturaAsociadas(idOrdenDePago);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de los comprobantes relacionados. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

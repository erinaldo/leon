using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class NotaDeCreditoDeCompra
    {

        IList<NotaDeCreditoDeCompraDTO> _GridDataListReg;

        public IList<NotaDeCreditoDeCompraDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<NotaDeCreditoCompDetalleDTO> _GridDataListDetalleReg;

        public IList<NotaDeCreditoCompDetalleDTO> GridDataListDetalleReg
        {
            get { return _GridDataListDetalleReg; }
            set { _GridDataListDetalleReg = value; }
        }

        IList<IvaComprasDetalleDTO> _GridDataListIvaReg;

        public IList<IvaComprasDetalleDTO> GridDataListIvaReg
        {
            get { return _GridDataListIvaReg; }
            set { _GridDataListIvaReg = value; }
        }

        IList<ImpuestoDetalleDTO> _GridDataListImpuestosReg;

        public IList<ImpuestoDetalleDTO> GridDataListImpuestosReg
        {
            get { return _GridDataListImpuestosReg; }
            set { _GridDataListImpuestosReg = value; }
        }

        public void registrar(NotaDeCreditoDeCompraDTO data, List<NotaDeCreditoCompDetalleDTO> dataDetalle, List<IvaComprasDetalleDTO> ivaDetalle, List<ImpuestoDetalleDTO> impDetalle, List<ComprobanteRelacionDTO> comprobanteHijo)
        {
            try
            {
                long id_tipo_comprobante = ValorDTO.obtenerId("NOTA DE CREDITO " + data.Tipo_nota_credito.ToString());

                //inserto nota de credito
                data.Id = NotaDeCreditoDeCompraDTO.insert(data);

                //inserto detalle
                foreach (NotaDeCreditoCompDetalleDTO detalleCred in dataDetalle)
                {
                    detalleCred.Id_nota_credito = data.Id;
                    NotaDeCreditoDeCompraDTO.insertDetalle(detalleCred);
                }

                //inserto iva
                foreach (IvaComprasDetalleDTO detalleIvaCred in ivaDetalle)
                {
                    detalleIvaCred.Id_factura = data.Id;
                    NotaDeCreditoDeCompraDTO.insertIva(detalleIvaCred);
                }

                //inserto impuestos
                foreach (ImpuestoDetalleDTO detalleImpuestosCred in impDetalle)
                {
                    detalleImpuestosCred.Id_factura = data.Id;
                    NotaDeCreditoDeCompraDTO.insertImpuestos(detalleImpuestosCred);
                }

                //inserto comprobante hijo
                foreach (ComprobanteRelacionDTO relacion in comprobanteHijo)
                {
                    relacion.Cod_comprobante_padre = data.Cod_comprobante;
                    relacion.Id_proveedor = data.Id_proveedor;
                    relacion.Importe_padre = data.Total;
                    relacion.Id_tipo_comprobante_padre = id_tipo_comprobante;
                    ComprobanteRelacionDTO.insertar(relacion);
                }

                //inserto el comprobante y lo registro en el libro
                ComprobanteCompraDTO.insertar("NOTA DE CREDITO " + data.Tipo_nota_credito.ToString(), data);
                LibroIvaComprasDTO comprado = new LibroIvaComprasDTO(data, id_tipo_comprobante, 'N');
                comprado.registrar();

                //inserto movimiento de cuenta
                decimal saldoBase = MovimientoProvDTO.getSaldoBase(data.Fecha_comprobante, data.Id_proveedor);
                long idMovimiento = MovimientoProvDTO.generarNotaDeCredito(data, saldoBase);
                MovimientoProvDTO.recalcularMovimientosPostComprobante(idMovimiento, saldoBase - data.Total);

                //actualizo stock
                if (data.Es_concepto == 'N')
                {
                    actualizarStock(data);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la nota de crédito de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //revisar
        private void actualizarStock(NotaDeCreditoDeCompraDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMov(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.egreso(movimiento);
            }
        }

        //revisar
        public void anular(NotaDeCreditoDeCompraDTO data)
        {
            try
            {
                //FacturaConceptoDTO.eliminar(data);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la nota de crédito de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }

        }


        public void refreshGridDataReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListReg = NotaDeCreditoDeCompraDTO.obtenerNCReg(idNotaDeCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListDetalleReg = NotaDeCreditoCompDetalleDTO.obtenerDetalleNCReg(idNotaDeCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataIvaReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListIvaReg = IvaComprasDetalleDTO.obtenerIvaReg(idNotaDeCredito, "NC");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el iva de la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataImpuestosReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListImpuestosReg = ImpuestoDetalleDTO.obtenerImpuestosReg(idNotaDeCredito, "NC");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los impuestos de la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class NotaDeDebitoDeCompra
    {
        IList<NotaDeDebitoDeCompraDTO> _GridDataListImpagas;

        public IList<NotaDeDebitoDeCompraDTO> GridDataListImpagas
        {
            get { return _GridDataListImpagas; }
            set { _GridDataListImpagas = value; }
        }

        IList<NotaDeDebitoDeCompraDTO> _GridDataListReg;

        public IList<NotaDeDebitoDeCompraDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<NotaDeDebitoCompDetalleDTO> _GridDataListDetalleReg;

        public IList<NotaDeDebitoCompDetalleDTO> GridDataListDetalleReg
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

        public void registrar(NotaDeDebitoDeCompraDTO data, List<NotaDeDebitoCompDetalleDTO> dataDetalle, List<IvaComprasDetalleDTO> ivaDetalle, List<ImpuestoDetalleDTO> impDetalle, List<ComprobanteRelacionDTO> comprobanteHijo)
        {
            try
            {
                long id_tipo_comprobante = ValorDTO.obtenerId("NOTA DE DEBITO " + data.Tipo_nota_debito.ToString());

                //inserto note de debito
                data.Id = NotaDeDebitoDeCompraDTO.insert(data);

                //inserto detalle
                foreach (NotaDeDebitoCompDetalleDTO detalleDeb in dataDetalle)
                {
                    detalleDeb.Id_nota_debito = data.Id;
                    NotaDeDebitoDeCompraDTO.insertDetalle(detalleDeb);
                }

                //inserto iva
                foreach (IvaComprasDetalleDTO detalleIvaDeb in ivaDetalle)
                {
                    detalleIvaDeb.Id_factura = data.Id;
                    NotaDeDebitoDeCompraDTO.insertIva(detalleIvaDeb);
                }

                //inserto impuestos
                foreach (ImpuestoDetalleDTO detalleImpuestosDeb in impDetalle)
                {
                    detalleImpuestosDeb.Id_factura = data.Id;
                    NotaDeDebitoDeCompraDTO.insertImpuestos(detalleImpuestosDeb);
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
                ComprobanteCompraDTO.insertar("NOTA DE DEBITO " + data.Tipo_nota_debito.ToString(), data);
                LibroIvaComprasDTO comprado = new LibroIvaComprasDTO(data, id_tipo_comprobante, 'N');
                comprado.registrar();

                //inserto movimiento de cuenta
                decimal saldoBase = MovimientoProvDTO.getSaldoBase(data.Fecha_comprobante, data.Id_proveedor);
                long idMovimiento = MovimientoProvDTO.generarNotaDeDebito(data, saldoBase);
                MovimientoProvDTO.recalcularMovimientosPostComprobante(idMovimiento, saldoBase + data.Total);

                //actualizo stock
                if (data.Es_concepto == 'N')
                {
                    actualizarStock(data);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la nota de débito de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //revisar
        private void actualizarStock(NotaDeDebitoDeCompraDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMov(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.ingreso(movimiento);
            }
        }

        //revisar
        public void anular(NotaDeDebitoDeCompraDTO data)
        {
            try
            {
                //FacturaConceptoDTO.eliminar(data);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la nota de débito de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }

        }

        public void refreshGridDataReg(long idNotaDeDebito)
        {
            try
            {
                this._GridDataListReg = NotaDeDebitoDeCompraDTO.obtenerNDReg(idNotaDeDebito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idNotaDeDebito)
        {
            try
            {
                this._GridDataListDetalleReg = NotaDeDebitoCompDetalleDTO.obtenerDetalleNDReg(idNotaDeDebito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataIvaReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListIvaReg = IvaComprasDetalleDTO.obtenerIvaReg(idNotaDeCredito, "ND");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el iva de la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataImpuestosReg(long idNotaDeCredito)
        {
            try
            {
                this._GridDataListImpuestosReg = ImpuestoDetalleDTO.obtenerImpuestosReg(idNotaDeCredito, "ND");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los impuestos de la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


    }
}

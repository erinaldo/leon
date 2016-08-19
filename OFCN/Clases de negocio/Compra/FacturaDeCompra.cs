using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class FacturaDeCompra
    {
        IList<FacturaDeCompraDTO> _GridDataListImpagas;

        public IList<FacturaDeCompraDTO> GridDataListImpagas
        {
            get { return _GridDataListImpagas; }
            set { _GridDataListImpagas = value; }
        }

        IList<FacturaDeCompraDTO> _GridDataListReg;

        public IList<FacturaDeCompraDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<FacturaDeCompraDetalleDTO> _GridDataListDetalleReg;

        public IList<FacturaDeCompraDetalleDTO> GridDataListDetalleReg
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

        public void registrarInicio(FacturaDeCompraDTO data)
        {
            try
            {
                data.Id = FacturaDeCompraDTO.insert(data);

                //inserto el comprobante y lo registro en el libro
                ComprobanteCompraDTO.insertar("FACTURA " + data.Tipo_factura.ToString(), data);
                LibroIvaComprasDTO comprado = new LibroIvaComprasDTO(data, ValorDTO.obtenerId("FACTURA " + data.Tipo_factura.ToString()), 'N');
                comprado.registrar();

                //inserto movimiento de cuenta
                decimal saldoBase = MovimientoProvDTO.getSaldoBase(data.Fecha_comprobante, data.Id_proveedor);
                long idMovimiento = MovimientoProvDTO.generarFactura(data, saldoBase);
                MovimientoProvDTO.recalcularMovimientosPostComprobante(idMovimiento, saldoBase + data.Total);

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la factura de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void registrar(FacturaDeCompraDTO data, List<FacturaDeCompraDetalleDTO> dataDetalle, List<IvaComprasDetalleDTO> ivaDetalle, List<ImpuestoDetalleDTO> impDetalle, List<FacturaDeCompraCuotaDTO> cuotaDetalle, List<ComprobanteRelacionDTO> comprobanteHijo)
        {
            try
            {
                long id_tipo_comprobante = ValorDTO.obtenerId("FACTURA " + data.Tipo_factura.ToString());

                //inserto factura
                data.Id = FacturaDeCompraDTO.insert(data);

                //inserto cuotas
                foreach (FacturaDeCompraCuotaDTO detalleCuota in cuotaDetalle)
                {
                    detalleCuota.Id_factura = data.Id;
                    FacturaDeCompraCuotaDTO.insert(detalleCuota);
                }

                //inserto detalle
                foreach (FacturaDeCompraDetalleDTO detalleFact in dataDetalle)
                {
                    detalleFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertDetalle(detalleFact);
                    if (detalleFact.Id_producto != -1)
                    {
                        ProductoDTO.actualizarPrecioVigente(detalleFact.Id_producto, detalleFact.Precio_unitario);
                    }
                }

                //inserto iva
                foreach (IvaComprasDetalleDTO detalleIvaFact in ivaDetalle)
                {
                    detalleIvaFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertIva(detalleIvaFact);
                }

                //inserto impuestos
                foreach (ImpuestoDetalleDTO detalleImpuestosFact in impDetalle)
                {
                    detalleImpuestosFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertImpuestos(detalleImpuestosFact);
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
                ComprobanteCompraDTO.insertar("FACTURA " + data.Tipo_factura.ToString(), data);
                LibroIvaComprasDTO comprado = new LibroIvaComprasDTO(data, id_tipo_comprobante, 'N');
                comprado.registrar();

                //inserto movimiento de cuenta
                decimal saldoBase = MovimientoProvDTO.getSaldoBase(data.Fecha_comprobante, data.Id_proveedor);
                long idMovimiento = MovimientoProvDTO.generarFactura(data, saldoBase);
                MovimientoProvDTO.recalcularMovimientosPostComprobante(idMovimiento, saldoBase + data.Total);

                //actualizo stock
                if (data.Es_concepto == 'N')
                {
                    actualizarStock(data);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la factura de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void registrarIniciada(FacturaDeCompraDTO data, List<FacturaDeCompraDetalleDTO> dataDetalle, List<IvaComprasDetalleDTO> ivaDetalle, List<ImpuestoDetalleDTO> impDetalle, List<FacturaDeCompraCuotaDTO> cuotaDetalle, List<ComprobanteRelacionDTO> comprobanteHijo)
        {
            try
            {
                long id_tipo_comprobante = ValorDTO.obtenerId("FACTURA " + data.Tipo_factura.ToString());

                if (data.Tipo_factura == 'A')
                {
                    data.Id = ComprobanteCompraDTO.obtenerIdOrigenFacturaA(data.Cod_comprobante);
                }
                if (data.Tipo_factura == 'B')
                {
                    data.Id = ComprobanteCompraDTO.obtenerIdOrigenFacturaB(data.Cod_comprobante);
                }
                if (data.Tipo_factura == 'C')
                {
                    data.Id = ComprobanteCompraDTO.obtenerIdOrigenFacturaC(data.Cod_comprobante);
                }

                //actualizo factura
                FacturaDeCompraDTO.actualizar(data);

                //inserto cuotas
                foreach (FacturaDeCompraCuotaDTO detalleCuota in cuotaDetalle)
                {
                    detalleCuota.Id_factura = data.Id;
                    FacturaDeCompraCuotaDTO.insert(detalleCuota);
                }

                //inserto detalle
                foreach (FacturaDeCompraDetalleDTO detalleFact in dataDetalle)
                {
                    detalleFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertDetalle(detalleFact);
                    if (detalleFact.Id_producto != -1)
                    {
                        ProductoDTO.actualizarPrecioVigente(detalleFact.Id_producto, detalleFact.Precio_unitario);
                    }
                }

                //inserto iva
                foreach (IvaComprasDetalleDTO detalleIvaFact in ivaDetalle)
                {
                    detalleIvaFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertIva(detalleIvaFact);
                }

                //inserto impuestos
                foreach (ImpuestoDetalleDTO detalleImpuestosFact in impDetalle)
                {
                    detalleImpuestosFact.Id_factura = data.Id;
                    FacturaDeCompraDTO.insertImpuestos(detalleImpuestosFact);
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

                //actualizo el comprobante
                ComprobanteCompraDTO.marcarCompleto("FACTURA " + data.Tipo_factura.ToString(), data);
                LibroIvaComprasDTO comprado = new LibroIvaComprasDTO(data, id_tipo_comprobante, 'N');
                comprado.actualizarImportes();

                //actualizo stock
                if (data.Es_concepto == 'N')
                {
                    actualizarStock(data);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible completar la factura de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        private void actualizarStock(FacturaDeCompraDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMov(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.ingreso(movimiento);
            }
        }

        public void anular(FacturaDeCompraDTO data)
        {
            try
            {
                //FacturaConceptoDTO.eliminar(data);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la factura de compra. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }

        }

        public void refreshGridDataImpagas(string cod_proveedor)
        {
            try
            {
                List<FacturaDeCompraDTO> aux = new List<FacturaDeCompraDTO>();
                aux.AddRange(FacturaDeCompraDTO.obtenerFacturasImpagas(cod_proveedor));
                aux.AddRange(NotaDeDebitoDeCompraDTO.obtenerDebitosImpagos(cod_proveedor));
                aux.AddRange(NotaDeCreditoDeCompraDTO.obtenerCreditosImpagos(cod_proveedor));
                IList<FacturaDeCompraDTO> auxOrdenado = aux.OrderBy(o => o.Fecha_creacion).ThenBy(o => o.Tipo_comprobante).ToList();

                this._GridDataListImpagas = auxOrdenado;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las notas de débito o facturas de compra impagas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idFactura)
        {
            try
            {
                this._GridDataListReg = FacturaDeCompraDTO.obtenerFacturasReg(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idFactura)
        {
            try
            {
                this._GridDataListDetalleReg = FacturaDeCompraDetalleDTO.obtenerDetalleFactReg(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataIvaReg(long idFactura)
        {
            try
            {
                this._GridDataListIvaReg = IvaComprasDetalleDTO.obtenerIvaReg(idFactura, "FA");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el iva de la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataImpuestosReg(long idFactura)
        {
            try
            {
                this._GridDataListImpuestosReg = ImpuestoDetalleDTO.obtenerImpuestosReg(idFactura, "FA");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los impuestos de la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

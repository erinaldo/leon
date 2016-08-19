using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class NotaCredito
    {

        IList<NotaCreditoDTO> _GridDataList;

        public IList<NotaCreditoDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<NotaCreditoDetalleDTO> _GridDataListDetalle;

        public IList<NotaCreditoDetalleDTO> GridDataListDetalle
        {
            get { return _GridDataListDetalle; }
            set { _GridDataListDetalle = value; }
        }

        IList<NotaCreditoDTO> _GridDataListReg;

        public IList<NotaCreditoDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<NotaCreditoDetalleDTO> _GridDataListDetalleReg;

        public IList<NotaCreditoDetalleDTO> GridDataListDetalleReg
        {
            get { return _GridDataListDetalleReg; }
            set { _GridDataListDetalleReg = value; }
        }

        #region Constructor

        public NotaCredito()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridData(); 
        }

        public void refreshGridData()
        {
            try
            {
                this._GridDataList = NotaCreditoDTO.obtenerCreditoTemp();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idCredito)
        {
            try
            {
                this._GridDataListReg = NotaCreditoDTO.obtenerCreditoReg(idCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalle(long idCredito)
        {
            try
            {
                this._GridDataListDetalle = NotaCreditoDetalleDTO.obtenerDetalleCred(idCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idCredito)
        {
            try
            {
                this._GridDataListDetalleReg = NotaCreditoDetalleDTO.obtenerDetalleReg(idCredito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de crédito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void generar(List<NotaCreditoDetalleDTO> data)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {

                    foreach (NotaCreditoDetalleDTO detalle in data)
                    {
                        detalle.Id_nota_credito = NotaCreditoDTO.getIdCreditoTemp(detalle.Id_cliente);

                        if (detalle.Id_nota_credito != -1)
                        {
                            NotaCreditoDTO.insertDetalle(detalle);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el detalle de la nota de crédito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }
        }


        public void generar(NotaCreditoDTO data)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {
                    NotaCreditoDTO.insert(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la nota de crédito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }
        }

        public void completarDatosPendientes()
        {
            try
            {
                NotaCreditoDTO.cargarDatosNotaCredito();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible generar la nota de crédito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool delete()
        {
            try
            {
                NotaCreditoDTO.borrarCreditoTemp();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar la nota de crédito pendiente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //feb 1.8
        public bool registrar(List<NotaCreditoDTO> dataCredito, List<NotaCreditoDetalleDTO> dataCreditoDetalle)
        {
            try
            {
                foreach (NotaCreditoDTO dato in dataCredito)
                {
                    if (dato.Tipo_nota_credito == 'A')
                    {
                        ComprobanteDTO.insertar("NOTA DE CREDITO A", dato); //feb 1.9
                        ParametroDTO.actualizarParamII("INICIO NRO NOTA DE CREDITO A", dato.Nro_nota_credito); //feb 1.9
                        foreach (NotaCreditoDetalleDTO datoDetalle in dataCreditoDetalle)
                        {
                            if (datoDetalle.Cod_comprobante_factura != string.Empty)
                            {
                                //MovimientoDTO.cancelarFactura(ValorDTO.obtenerId("FACTURA A"), datoDetalle.Cod_comprobante_factura);
                                MovimientoDTO.cancelarFacturaDebito(datoDetalle.Cod_comprobante_factura);
                            }
                        }
                    }

                    if (dato.Tipo_nota_credito == 'B')
                    {
                        ComprobanteDTO.insertar("NOTA DE CREDITO B", dato); //feb 1.9
                        ParametroDTO.actualizarParamII("INICIO NRO NOTA DE CREDITO B", dato.Nro_nota_credito); //feb 1.9
                        foreach (NotaCreditoDetalleDTO datoDetalle in dataCreditoDetalle)
                        {
                            if (datoDetalle.Cod_comprobante_factura != string.Empty)
                            {
                                //MovimientoDTO.cancelarFactura(ValorDTO.obtenerId("FACTURA B"), datoDetalle.Cod_comprobante_factura);
                                MovimientoDTO.cancelarFacturaDebito(datoDetalle.Cod_comprobante_factura);
                            }
                        }
                    }

                    MovimientoDTO.generarNotaDeCredito(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("NOTA CREDITO", dato.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la nota de crédito pendiente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrarAnularCredito(NotaCreditoDTO dataCredito)
        {
            try
            {

                if (dataCredito.Tipo_nota_credito == 'A')
                {
                    ComprobanteDTO.insertar("NOTA DE CREDITO A", dataCredito); //feb 1.9
                    ComprobanteDTO.anular("NOTA DE CREDITO A", dataCredito);
                }

                if (dataCredito.Tipo_nota_credito == 'B')
                {
                    ComprobanteDTO.insertar("NOTA DE CREDITO B", dataCredito); //feb 1.9
                    ComprobanteDTO.anular("NOTA DE CREDITO B", dataCredito);
                }

                MovimientoDTO.generarNotaDeCredito(dataCredito);
                MovimientoDTO.generarAnulaCredito(dataCredito);
                ComprobanteTempDTO.borrarComprobanteTemp("NOTA CREDITO", dataCredito.Id);

                //genera nueva factura
                NotaCreditoDTO.replicarCredito(dataCredito);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular y registrar la nota de crédito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //feb 1.8
        public bool AnularCredito(NotaCreditoDTO dataCredito, List<NotaCreditoDetalleDTO> dataCreditoDetalle)
        {
            try
            {

                if (dataCredito.Tipo_nota_credito == 'A')
                {
                    ComprobanteDTO.anular("NOTA DE CREDITO A", dataCredito);
                    foreach (NotaCreditoDetalleDTO datoDetalle in dataCreditoDetalle)
                    {
                        if (datoDetalle.Cod_comprobante_factura != string.Empty)
                        {
                            //MovimientoDTO.recuperarCancelarFactura(ValorDTO.obtenerId("FACTURA A"), datoDetalle.Cod_comprobante_factura);
                            MovimientoDTO.recuperarCancelarFacturaDebito(datoDetalle.Cod_comprobante_factura);
                        }
                    }
                }

                if (dataCredito.Tipo_nota_credito == 'B')
                {
                    ComprobanteDTO.anular("NOTA DE CREDITO B", dataCredito);
                    foreach (NotaCreditoDetalleDTO datoDetalle in dataCreditoDetalle)
                    {
                        if (datoDetalle.Cod_comprobante_factura != string.Empty)
                        {
                            //MovimientoDTO.recuperarCancelarFactura(ValorDTO.obtenerId("FACTURA B"), datoDetalle.Cod_comprobante_factura);
                            MovimientoDTO.recuperarCancelarFacturaDebito(datoDetalle.Cod_comprobante_factura);
                        }
                    }
                }

                MovimientoDTO.generarAnulaCredito(dataCredito);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la nota de crédito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

    }
}

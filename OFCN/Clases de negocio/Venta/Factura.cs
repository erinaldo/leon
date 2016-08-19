using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    class Factura
    {

        IList<FacturaDTO> _GridDataList;

        public IList<FacturaDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        //feb 1.9.1
        FacturaDTO _DataFW;

        public FacturaDTO DataFW
        {
            get { return _DataFW; }
            set { _DataFW = value; }
        }

        IList<FacturaDTO> _GridDataListReg;

        public IList<FacturaDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<FacturaDTO> _GridDataListImpagas;

        public IList<FacturaDTO> GridDataListImpagas
        {
            get { return _GridDataListImpagas; }
            set { _GridDataListImpagas = value; }
        }

        #region Constructor

        public Factura()
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
                this._GridDataList = FacturaDTO.obtenerFacturasTemp();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDeRem()
        {
            try
            {
                this._GridDataList = FacturaDTO.obtenerFacturasTempDeRem();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idFactura)
        {
            try
            {
                this._GridDataListReg = FacturaDTO.obtenerFacturasReg(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.9.1
        public void getDataFW(long idFactura)
        {
            try
            {
                this._DataFW = FacturaDTO.obtenerComprobanteFW(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.8
        public void refreshGridDataImpagas(string codCliente)
        {
            try
            {
                List<FacturaDTO> aux = new List<FacturaDTO>();
                aux.AddRange(FacturaDTO.obtenerFacturasImpagas(codCliente));
                aux.AddRange(NotaDebitoDTO.obtenerDebitosImpagos(codCliente));
                aux.AddRange(NotaCreditoDTO.obtenerCreditosImpagos(codCliente)); //feb 1.8 fix
                IList<FacturaDTO> auxOrdenado = aux.OrderBy(o => o.Fecha_creacion).ThenBy(o => o.Tipo_comprobante).ToList();

                this._GridDataListImpagas = auxOrdenado;

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los comprobantes impagos del cliente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }

        }

        //feb 1.7
        public bool generar(FacturaManualDTO data, decimal descuento)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {

                    data.Id_factura = FacturaDTO.getIdFacturaTemp(data.Id_cliente);

                    if (data.Id_factura == -1)
                    {
                        data.Id_factura = FacturaManualDTO.insert(data, descuento); //feb 1.9.1
                    }

                    FacturaManualDTO.insertDetalle(data);
                    FacturaDTO.cargarDatosFactPend(); //feb 1.7 //feb 1.9.1

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la factura. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }

            return true;
        }

        //feb 1.7
        public bool generar(List<OrdenDetalleDTO> data, decimal descuento)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {

                try
                {
                    List<OrdenDetalleDTO> SortedList = data.OrderBy(o => o.Id_cliente).ThenBy(o => o.Coche).ThenBy(o => o.Es_nuevo).ToList();

                    int contador = 0;
                    long id_factura = -1;
                    string id_cliente_ant = String.Empty;
                    string coche_ant = String.Empty;

                    if (SortedList[contador].Es_nuevo == 'S')
                    {
                        //lo siguiente es por si al ordenar queda primero un coche nuevo de un cliente que factura simple
                        if (SortedList[contador].Factura_por_coche == 'N' && FacturaDTO.existeFacturaTemp(SortedList[contador].Id_cliente))
                        {
                            id_factura = FacturaDTO.getIdFacturaTemp(SortedList[contador].Id_cliente);
                        }
                        else
                        {
                            id_factura = FacturaDTO.insert(SortedList[contador], descuento); //tambien inserta en la temporal (ofc_comprobante_temp) //feb 1.9.1
                        }
                    }
                    else
                    {
                        id_factura = SortedList[contador].Id_factura;
                    }

                    id_cliente_ant = SortedList[contador].Id_cliente;
                    coche_ant = SortedList[contador].Coche;

                    foreach (OrdenDetalleDTO row in SortedList)
                    {
                        if (SortedList[contador].Es_nuevo == 'S')
                        {
                            if (id_cliente_ant == SortedList[contador].Id_cliente)
                            {
                                if (coche_ant == SortedList[contador].Coche)
                                {
                                    SortedList[contador].Id_factura = id_factura;
                                    FacturaDTO.insertDetalle(SortedList[contador]);
                                }
                                else
                                {
                                    coche_ant = SortedList[contador].Coche;
                                    if (SortedList[contador].Factura_por_coche == 'N')
                                    {
                                        SortedList[contador].Id_factura = id_factura;
                                        FacturaDTO.insertDetalle(SortedList[contador]);
                                    }
                                    else
                                    {
                                        id_factura = FacturaDTO.insert(SortedList[contador], descuento); //feb 1.9.1
                                        SortedList[contador].Id_factura = id_factura;
                                        FacturaDTO.insertDetalle(SortedList[contador]);
                                    }

                                }
                            }
                            else
                            {
                                id_cliente_ant = SortedList[contador].Id_cliente;
                                coche_ant = SortedList[contador].Coche;
                                id_factura = FacturaDTO.insert(SortedList[contador], descuento); //feb 1.9.1
                                SortedList[contador].Id_factura = id_factura;
                                FacturaDTO.insertDetalle(SortedList[contador]);
                            }
                        }
                        else
                        {
                            id_factura = SortedList[contador].Id_factura;
                            id_cliente_ant = SortedList[contador].Id_cliente;
                            coche_ant = SortedList[contador].Coche;
                        }

                        contador = contador + 1;
                    }

                    FacturaDTO.cargarDatosFactPend(); //feb 1.7 //feb 1.9.1

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la factura. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }

            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }

            return true;
        }

        //feb 1.7
        public bool generarFacturaDeRemito(List<OrdenDetalleDTO> data, decimal descuento)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {
                    List<OrdenDetalleDTO> SortedList = data.OrderBy(o => o.Id_cliente).ThenBy(o => o.Coche).ThenBy(o => o.Es_nuevo).ToList();

                    int contador = 0;
                    long id_factura = -1;

                    id_factura = FacturaDTO.insertDeRemito(SortedList[contador], descuento); //tambien inserta en la temporal (ofc_comprobante_temp) //feb 1.9.1

                    foreach (OrdenDetalleDTO row in SortedList)
                    {
                        SortedList[contador].Id_factura = id_factura;
                        FacturaDTO.insertDetalle(SortedList[contador]);
                        contador = contador + 1;
                    }

                    FacturaDTO.cargarDatosFactPend(); //feb 1.7 //feb 1.9.1

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la factura. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }

            return true;
        }


        public bool delete()
        {
            try
            {
                FacturaDTO.borrarFacturasTemp();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar las facturas pendientes. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool deleteConRemito()
        {
            try
            {
                FacturaDTO.borrarFacturasTemp();
                ComprobanteTempDTO.borrarComprobanteTemp("REMITO");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar las facturas pendientes. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrar(List<FacturaDTO> dataFacturas)
        {
            try
            {
                //el orden me garantiza la correcta actualizacion de los parametros de inicio fact y rem
                List<FacturaDTO> SortedList = dataFacturas.OrderBy(o => o.Id).ToList();

                foreach (FacturaDTO dato in SortedList)
                {
                    if (dato.Tipo_factura == 'A')
                    {
                        ComprobanteDTO.insertar("FACTURA A", dato);
                        ParametroDTO.actualizarParamII("INICIO NRO FACTURA A", dato.Nro_factura);
                    }

                    if (dato.Tipo_factura == 'B')
                    {
                        ComprobanteDTO.insertar("FACTURA B", dato);
                        ParametroDTO.actualizarParamII("INICIO NRO FACTURA B", dato.Nro_factura);
                    }

                    if (dato.Solo_factura == 'N')
                    {
                        ParametroDTO.actualizarParamII("INICIO NRO REMITO", dato.Nro_remito);
                        ComprobanteDTO.insertar("REMITO", dato);
                    }

                    OrdenDTO.migrarAHist(dato);
                    MovimientoDTO.generarFactura(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("FACTURA", dato.Id);
                    actualizarStock(dato);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar las facturas. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrarFacturaDeRemito(List<FacturaDTO> dataFacturas)
        {
            try
            {
                //el orden me garantiza la correcta actualizacion de los parametros de inicio fact y rem
                List<FacturaDTO> SortedList = dataFacturas.OrderBy(o => o.Id).ToList();

                foreach (FacturaDTO dato in SortedList)
                {
                    if (dato.Tipo_factura == 'A')
                    {
                        ComprobanteDTO.insertar("FACTURA A", dato);
                        ParametroDTO.actualizarParamII("INICIO NRO FACTURA A", dato.Nro_factura);
                    }

                    if (dato.Tipo_factura == 'B')
                    {
                        ComprobanteDTO.insertar("FACTURA B", dato);
                        ParametroDTO.actualizarParamII("INICIO NRO FACTURA B", dato.Nro_factura);
                    }

                    ComprobanteDTO.insertarRemitoFinal(dato);
                    RemitoDTO.borrarRemitoTemp(); //lo hago desaparecer :)
                    MovimientoDTO.generarFactura(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("FACTURA", dato.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar las facturas. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        private void actualizarStock(FacturaDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMov(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.egreso(movimiento);
            }
        }

        private void actualizarStockAnulacion(FacturaDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMovAnulacion(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.ingreso(movimiento);
            }
        }


        private void actualizarStockAnulacionBis(FacturaDTO dato)
        {
            List<MovimientoDeArticulosDTO> listaMov = MovimientoDeArticulosDTO.calcularMovAnulacionBis(dato);
            foreach (MovimientoDeArticulosDTO movimiento in listaMov)
            {
                MovimientoDeArticulosDTO.ingreso(movimiento);
            }
        }

        public bool registrarAnularFactura(FacturaDTO dataFactura)
        {
            try
            {

                if (dataFactura.Tipo_factura == 'A')
                {
                    ComprobanteDTO.insertar("FACTURA A", dataFactura);
                    ComprobanteDTO.anular("FACTURA A", dataFactura);
                }

                if (dataFactura.Tipo_factura == 'B')
                {
                    ComprobanteDTO.insertar("FACTURA B", dataFactura);
                    ComprobanteDTO.anular("FACTURA B", dataFactura);
                }

                MovimientoDTO.generarFactura(dataFactura);
                MovimientoDTO.generarAnulaFactura(dataFactura);

                actualizarStock(dataFactura);
                actualizarStockAnulacionBis(dataFactura);

                ComprobanteTempDTO.borrarComprobanteTemp("FACTURA", dataFactura.Id);

                //genera nueva factura
                FacturaDTO.replicarFactura(dataFactura);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular y registrar la factura. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrarAnularRemito(FacturaDTO dataFactura)
        {
            try
            {
                ComprobanteDTO.insertar("REMITO", dataFactura);
                ComprobanteDTO.anular("REMITO", dataFactura);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular y registrar el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool AnularFactura(FacturaDTO dataFactura)
        {
            try
            {

                if (dataFactura.Tipo_factura == 'A')
                {
                    ComprobanteDTO.anular("FACTURA A", dataFactura);
                }

                if (dataFactura.Tipo_factura == 'B')
                {
                    ComprobanteDTO.anular("FACTURA B", dataFactura);
                }

                OrdenDTO.migrarAPend(dataFactura);
                MovimientoDTO.generarAnulaFactura(dataFactura);
                actualizarStockAnulacion(dataFactura);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la factura. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool AnularRemito(FacturaDTO dataFactura)
        {
            try
            {
                ComprobanteDTO.anular("REMITO", dataFactura);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Remito
    {
        IList<RemitoDTO> _OwnDataList;

        public IList<RemitoDTO> OwnDataList
        {
            get { return _OwnDataList; }
            set { _OwnDataList = value; }
        }

        IList<RemitoDTO> _GridDataList;

        public IList<RemitoDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<RemitoDTO> _GridDataListReg;

        public IList<RemitoDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<OrdenDetalleDTO> _GridDataOrdenList;

        public IList<OrdenDetalleDTO> GridDataOrdenList
        {
            get { return _GridDataOrdenList; }
            set { _GridDataOrdenList = value; }
        }

        #region Constructor

        public Remito()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridData(); 
        }

        public void refreshOwnData()
        {
            try
            {
                this._OwnDataList = RemitoDTO.obtenerRemitosSinFactura();
                RemitoDTO rem = new RemitoDTO();
                this._OwnDataList.Insert(0,rem);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los remitos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData()
        {
            try
            {
                this._GridDataList = RemitoDTO.obtenerRemitosTemp();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los remitos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idRemito)
        {
            try
            {
                this._GridDataListReg = RemitoDTO.obtenerRemitoReg(idRemito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el remito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataOrden(string cod_comprobante_remito)
        {
            try
            {
                this._GridDataOrdenList = RemitoDTO.obtenerDetalleOrdenesHist(cod_comprobante_remito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle del remito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.9.1
        public bool generar(FacturaManualDTO data)
        {
            try
            {
                data.Id_remito = RemitoDTO.getIdRemitoTemp(data.Id_cliente);

                if (data.Id_remito == -1)
                {
                    data.Id_remito = RemitoDTO.insert(data);
                }

                RemitoDTO.insertDetalle(data);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible generar el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
            return true;
        }

        public bool generar(List<OrdenDetalleDTO> data)
        {
            if (Token.RemitoHabilitado(Usuario.GetInstance().Login))
            {
                try
                {
                    List<OrdenDetalleDTO> SortedList = data.OrderBy(o => o.Id_cliente).ThenBy(o => o.Coche).ThenBy(o => o.Es_nuevo).ToList();

                    int contador = 0;
                    long id_remito = -1;
                    string id_cliente_ant = String.Empty;
                    string coche_ant = String.Empty;

                    if (SortedList[contador].Es_nuevo == 'S')
                    {
                        //lo siguiente es por si al ordenar queda primero un coche nuevo de un cliente que factura simple
                        if (SortedList[contador].Factura_por_coche == 'N' && RemitoDTO.existeRemitoTemp(SortedList[contador].Id_cliente))
                        {
                            id_remito = RemitoDTO.getIdRemitoTemp(SortedList[contador].Id_cliente);
                        }
                        else
                        {
                            id_remito = RemitoDTO.insert(SortedList[contador]); //tambien inserta en la temporal (ofc_comprobante_temp)
                        }
                    }
                    else
                    {
                        id_remito = SortedList[contador].Id_remito;
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
                                    SortedList[contador].Id_remito = id_remito;
                                    RemitoDTO.insertDetalle(SortedList[contador]);
                                }
                                else
                                {
                                    coche_ant = SortedList[contador].Coche;
                                    if (SortedList[contador].Factura_por_coche == 'N')
                                    {
                                        SortedList[contador].Id_remito = id_remito;
                                        RemitoDTO.insertDetalle(SortedList[contador]);
                                    }
                                    else
                                    {
                                        id_remito = RemitoDTO.insert(SortedList[contador]);
                                        SortedList[contador].Id_remito = id_remito;
                                        RemitoDTO.insertDetalle(SortedList[contador]);
                                    }

                                }
                            }
                            else
                            {
                                id_cliente_ant = SortedList[contador].Id_cliente;
                                coche_ant = SortedList[contador].Coche;
                                id_remito = RemitoDTO.insert(SortedList[contador]);
                                SortedList[contador].Id_remito = id_remito;
                                RemitoDTO.insertDetalle(SortedList[contador]);
                            }
                        }
                        else
                        {
                            id_remito = SortedList[contador].Id_remito;
                            id_cliente_ant = SortedList[contador].Id_cliente;
                            coche_ant = SortedList[contador].Coche;
                        }

                        contador = contador + 1;
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario generando remito. Aguarde un momento y vuelva a intentarlo.");
            }
            return true;
        }

        public bool delete()
        {
            try
            {
                RemitoDTO.borrarRemitoTemp();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar los remitos pendientes. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //feb 1.9.2 cambia el orden de los comandos
        public bool registrarAnularRemito(RemitoDTO dataRemito)
        {
            try
            {
                RemitoDTO.updateCodRemito(dataRemito.Id, ComprobanteDTO.converToNroRemito(dataRemito.Nro_remito.ToString()));
                RemitoDTO.replicarRemito(dataRemito);
                RemitoDTO.setRemitoPermanente(dataRemito.Id); //feb 1.9.1
                //dataRemito.Id = -1; //feb 1.9.1 corrección para que quede bien referenciado
                ComprobanteDTO.insertarAnulado("REMITO", dataRemito);
                ComprobanteTempDTO.borrarComprobanteTemp("REMITO", dataRemito.Id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular y registrar el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool AnularRemito(RemitoDTO dataRemito)
        {
            try
            {
                OrdenDTO.migrarAPend(dataRemito);
                ComprobanteDTO.insertarAnulado(dataRemito);
                RemitoDTO.setRemitoPermanente(dataRemito.Id); //feb 1.9.1
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //feb 1.9.2
        public bool AnularRemitoGenerado(RemitoDTO dataRemito)
        {
            try
            {
                OrdenDTO.migrarAPend(dataRemito);
                ComprobanteDTO.anular("REMITO", dataRemito);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular el remito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrar(List<RemitoDTO> dataRemito)
        {
            try
            {
                //el orden me garantiza la correcta actualizacion de los parametros de inicio fact y rem
                List<RemitoDTO> SortedList = dataRemito.OrderBy(o => o.Id).ToList();

                foreach (RemitoDTO dato in SortedList)
                {
                    //ComprobanteDTO.insertar("REMITO", dato);
                    RemitoDTO.updateCodRemito(dato.Id, ComprobanteDTO.converToNroRemito(dato.Nro_remito.ToString()));
                    ParametroDTO.actualizarParamII("INICIO NRO REMITO", dato.Nro_remito);
                    OrdenDTO.migrarAHist(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("REMITO", dato.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar los remitos. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        //feb 1.9.2
        public bool registrarManual(List<RemitoDTO> dataRemito)
        {
            try
            {
                List<RemitoDTO> SortedList = dataRemito.OrderBy(o => o.Id).ToList();

                foreach (RemitoDTO dato in SortedList)
                {
                    string cod_comprobante_remito = ComprobanteDTO.converToNroRemito(dato.Nro_remito.ToString());
                    dato.Cod_comprobante_remito = cod_comprobante_remito;
                    ComprobanteDTO.insertar(dato);
                    RemitoDTO.updateCodRemito(dato.Id, cod_comprobante_remito);
                    ParametroDTO.actualizarParamII("INICIO NRO REMITO", dato.Nro_remito);
                    OrdenDTO.migrarAHist(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("REMITO", dato.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar los remitos. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }
    }
}

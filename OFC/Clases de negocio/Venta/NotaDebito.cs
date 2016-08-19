using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class NotaDebito
    {

        IList<NotaDebitoDTO> _GridDataList;

        public IList<NotaDebitoDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<NotaDebitoDetalleDTO> _GridDataListDetalle;

        public IList<NotaDebitoDetalleDTO> GridDataListDetalle
        {
            get { return _GridDataListDetalle; }
            set { _GridDataListDetalle = value; }
        }

        IList<NotaDebitoDTO> _GridDataListReg;

        public IList<NotaDebitoDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<NotaDebitoDetalleDTO> _GridDataListDetalleReg;

        public IList<NotaDebitoDetalleDTO> GridDataListDetalleReg
        {
            get { return _GridDataListDetalleReg; }
            set { _GridDataListDetalleReg = value; }
        }

        #region Constructor

        public NotaDebito()
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
                this._GridDataList = NotaDebitoDTO.obtenerDebitoTemp();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idDebito)
        {
            try
            {
                this._GridDataListReg = NotaDebitoDTO.obtenerDebitoReg(idDebito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalle(long idDebito)
        {
            try
            {
                this._GridDataListDetalle = NotaDebitoDetalleDTO.obtenerDetalleDeb(idDebito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataDetalleReg(long idDebito)
        {
            try
            {
                this._GridDataListDetalleReg = NotaDebitoDetalleDTO.obtenerDetalleReg(idDebito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la nota de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void generar(NotaDebitoDetalleDTO data)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {
                    data.Id_nota_debito = NotaDebitoDTO.getIdDebitoTemp(data.Id_cliente);

                    if (data.Id_nota_debito != -1)
                    {
                        NotaDebitoDTO.insertDetalle(data);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el detalle de la nota de débito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("Existe otra instancia de usuario facturando. Aguarde un momento y vuelva a intentarlo.");
            }
        }


        public void generar(NotaDebitoDTO data)
        {
            if (Token.FacturacionHabilitada(Usuario.GetInstance().Login))
            {
                try
                {
                    NotaDebitoDTO.insert(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la nota de débito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
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
                NotaDebitoDTO.cargarDatosNotaDebito();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible generar la nota de débito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool delete()
        {
            try
            {
                NotaDebitoDTO.borrarDebitoTemp();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar la nota de débito pendiente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrar(List<NotaDebitoDTO> dataDebito)
        {
            try
            {
                foreach (NotaDebitoDTO dato in dataDebito)
                {
                    if (dato.Tipo_nota_debito == 'A')
                    {
                        ComprobanteDTO.insertar("NOTA DE DEBITO A", dato); //feb 1.9
                        ParametroDTO.actualizarParamII("INICIO NRO NOTA DE DEBITO A", dato.Nro_nota_debito); //feb 1.9
                    }

                    if (dato.Tipo_nota_debito == 'B')
                    {
                        ComprobanteDTO.insertar("NOTA DE DEBITO B", dato); //feb 1.9
                        ParametroDTO.actualizarParamII("INICIO NRO NOTA DE DEBITO B", dato.Nro_nota_debito); //feb 1.9
                    }

                    MovimientoDTO.generarNotaDeDebito(dato);
                    ComprobanteTempDTO.borrarComprobanteTemp("NOTA DEBITO", dato.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar la nota de débito pendiente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool registrarAnularDebito(NotaDebitoDTO dataDebito)
        {
            try
            {
                //mañana...
                if (dataDebito.Tipo_nota_debito == 'A')
                {
                    ComprobanteDTO.insertar("NOTA DE DEBITO A", dataDebito);
                    ComprobanteDTO.anular("NOTA DE DEBITO A", dataDebito);
                }

                if (dataDebito.Tipo_nota_debito == 'B')
                {
                    ComprobanteDTO.insertar("NOTA DE DEBITO B", dataDebito);
                    ComprobanteDTO.anular("NOTA DE DEBITO B", dataDebito);
                }

                MovimientoDTO.generarNotaDeDebito(dataDebito);
                MovimientoDTO.generarAnulaDebito(dataDebito);
                ComprobanteTempDTO.borrarComprobanteTemp("NOTA DEBITO", dataDebito.Id);

                NotaDebitoDTO.replicarDebito(dataDebito);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular y registrar la nota de débito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public bool AnularDebito(NotaDebitoDTO dataDebito)
        {
            try
            {

                if (dataDebito.Tipo_nota_debito == 'A')
                {
                    ComprobanteDTO.anular("NOTA DE DEBITO A", dataDebito);
                }

                if (dataDebito.Tipo_nota_debito == 'B')
                {
                    ComprobanteDTO.anular("NOTA DE DEBITO B", dataDebito);
                }

                MovimientoDTO.generarAnulaDebito(dataDebito);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible anular la nota de débito. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }
    }
}

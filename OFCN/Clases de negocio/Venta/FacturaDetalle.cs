using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class FacturaDetalle
    {

        IList<FacturaDetalleDTO> _GridDataList;

        public IList<FacturaDetalleDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<FacturaDetalleDTO> _GridDataListReg;

        public IList<FacturaDetalleDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        IList<FacturaDetalleManualDTO> _GridDataListManual;

        internal IList<FacturaDetalleManualDTO> GridDataListManual
        {
            get { return _GridDataListManual; }
            set { _GridDataListManual = value; }
        }

        //feb 1.9.1
        IList<FacturaDetalleDTO> _DataListFW;

        public IList<FacturaDetalleDTO> DataListFW
        {
            get { return _DataListFW; }
            set { _DataListFW = value; }
        }

        #region Constructor


        public FacturaDetalle()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridDataPendiente(); 
        }

        public void refreshGridData(long idFactura)
        {
            try
            {
                this._GridDataList = FacturaDetalleDTO.obtenerDetalleFact(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idFactura)
        {
            try
            {
                this._GridDataListReg = FacturaDetalleDTO.obtenerDetalleFactReg(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de la factura. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataManual(long idFactura)
        {
            try
            {
                this._GridDataListManual = FacturaDetalleManualDTO.obtenerDetalleFact(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.9.1
        public void getDataFW(long idFactura, string alicuota)
        {
            try
            {
                decimal bonificacion = ComprobanteTempDTO.obtenerDescuento(idFactura, "FACTURA");
                this._DataListFW = FacturaDetalleDTO.obtenerDetalleFW(idFactura, bonificacion, alicuota);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

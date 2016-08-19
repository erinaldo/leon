using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class RemitoDetalle
    {
        IList<RemitoDetalleDTO> _GridDataList;

        public IList<RemitoDetalleDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<RemitoDetalleDTO> _GridDataListReg;

        public IList<RemitoDetalleDTO> GridDataListReg
        {
            get { return _GridDataListReg; }
            set { _GridDataListReg = value; }
        }

        #region Constructor


        public RemitoDetalle()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridDataPendiente(); 
        }

        public void refreshGridData(long idRemito)
        {
            try
            {
                this._GridDataList = RemitoDetalleDTO.obtenerDetalleRem(idRemito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de los remitos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataReg(long idRemito)
        {
            try
            {
                this._GridDataListReg = RemitoDetalleDTO.obtenerDetalleRemReg(idRemito);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de los remitos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

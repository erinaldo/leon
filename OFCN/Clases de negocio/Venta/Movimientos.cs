using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Movimientos
    {

        IList<MovimientoDTO> _GridDataList;

        public IList<MovimientoDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<MovimientoProvDTO> _GridDataListProv;

        public IList<MovimientoProvDTO> GridDataListProv
        {
            get { return _GridDataListProv; }
            set { _GridDataListProv = value; }
        }

        #region Constructor


        public Movimientos()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridDataPendiente(); 
        }

        public void refreshGridData(FiltrosABMCliente filtro)
        {
            try
            {
                this._GridDataList = MovimientoDTO.obtenerMovimientos(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los movimientos de cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(FiltrosABMProveedor filtro)
        {
            try
            {
                this._GridDataListProv = MovimientoProvDTO.obtenerMovimientos(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los movimientos de cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }
    }
}

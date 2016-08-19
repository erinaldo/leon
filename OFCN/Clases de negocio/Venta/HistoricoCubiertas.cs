using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class HistoricoCubiertas
    {
        IList<HistoricoCubiertaDTO> _GridDataList;

        public IList<HistoricoCubiertaDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        #region Constructor


        public HistoricoCubiertas()
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
                this._GridDataList = HistoricoCubiertaDTO.obtenerHistoricoCubiertas(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las cubiertas facturadas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

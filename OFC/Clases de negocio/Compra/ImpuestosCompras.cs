using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class ImpuestosCompras
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public ImpuestosCompras()
        {
            this.initialData();
        }

        #endregion

        #region Métodos

        public void initialData()
        {
            this.refreshOwnData();
        }

        public void refreshOwnData()
        {
            try
            {
                this._ownDataList = ValorDTO.obtenerValores("XC");
                ValorDTO impNulo = new ValorDTO();
                impNulo.Id = 0;
                impNulo.Valor = "";
                this._ownDataList.Insert(0, impNulo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los impuestos de compra. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

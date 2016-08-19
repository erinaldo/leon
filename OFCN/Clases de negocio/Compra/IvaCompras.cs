using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class IvaCompras
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public IvaCompras()
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
                this._ownDataList = ValorDTO.obtenerValores("IC");
                ValorDTO ivaNulo = new ValorDTO();
                ivaNulo.Id = 0;
                this._ownDataList.Insert(0, ivaNulo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los valores de iva compra. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

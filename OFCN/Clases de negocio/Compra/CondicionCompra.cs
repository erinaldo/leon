using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class CondicionCompra
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public CondicionCompra()
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
                this._ownDataList = ValorDTO.obtenerValores("CC");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las condiciones de compra. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

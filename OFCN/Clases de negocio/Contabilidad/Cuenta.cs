using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Cuenta
    {
        IList<CuentaDTO> _ownDataList;

        public IList<CuentaDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }


        #region Constructor


        public Cuenta()
        {
            this.initialData();
        }

        #endregion


        #region Métodos

        public void initialData()
        {
            this.refreshListData();
        }


        public void refreshListData()
        {
            try
            {
                this._ownDataList = CuentaDTO.obtenerCuentas();

                CuentaDTO c = new CuentaDTO();
                c.Id = 0;
                c.Codigo = string.Empty;
                c.Descripcion = string.Empty;
                this._ownDataList.Insert(0, c);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los datos de la cuenta. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        #endregion
    }
}

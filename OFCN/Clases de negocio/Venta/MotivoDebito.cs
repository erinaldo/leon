using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class MotivoDebito
    {

        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        #region Constructor

        public MotivoDebito()
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
                this._ownDataList = ValorDTO.obtenerValores("MD");
                ValorDTO mar = new ValorDTO();
                mar.Id = 0;
                mar.Valor = "";
                this._ownDataList.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los motivos de débito. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

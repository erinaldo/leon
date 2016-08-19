using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class TipoComprobante
    {

        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        #region Constructor

        public TipoComprobante(string valor)
        {
            this.initialData(valor); 
        }

        #endregion

        #region Métodos


        public void initialData(string valor)
        {
            this.refreshOwnData(valor);
        }

        public void refreshOwnData(string valor)
        {
            try
            {
                this._ownDataList = ValorDTO.obtenerValoresNOTNULL("TC", valor);
                ValorDTO mar = new ValorDTO();
                mar.Id = 0;
                mar.Valor = "";
                this._ownDataList.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los tipos de comprobantes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

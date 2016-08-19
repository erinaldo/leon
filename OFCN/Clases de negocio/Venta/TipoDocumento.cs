using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//feb 1.9.1
namespace OFC
{
    class TipoDocumento
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public TipoDocumento()
        {
            this.initialData(); //cuando instancias los tipos de documento, ya sabes cuales son.
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
                this._ownDataList = ValorDTO.obtenerValores("TD");
                this._ownDataList.Insert(0, new ValorDTO());
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los tipos de documento. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class CategoriaIva
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public CategoriaIva()
        {
            this.initialData(); //cuando instancias las categorias de iva, ya sabes cuales son.
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
                this._ownDataList = ValorDTO.obtenerValores("CI");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las categorías de IVA. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion

    }
}

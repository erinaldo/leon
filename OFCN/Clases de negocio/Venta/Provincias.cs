using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Provincias
    {

        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        #region Constructor

        public Provincias()
        {
            this.initialData(); //cuando instancias las provincias, ya sabes cuales son.
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
                this._ownDataList = ValorDTO.obtenerValores("PR");
                ValorDTO mar = new ValorDTO();
                mar.Id = 0;
                mar.Valor = "";
                this._ownDataList.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las provincias. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion

    }
}

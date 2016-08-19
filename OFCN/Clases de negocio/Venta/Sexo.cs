using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Sexo
    {

        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        } 

        #region Constructor

        public Sexo()
        {
            this.initialData(); //cuando instancias el sexo, ya sabes cuales son.
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
                this._ownDataList = ValorDTO.obtenerValores("SX");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los sexos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion


    }
}

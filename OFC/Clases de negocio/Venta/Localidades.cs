using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Localidades
    {

        private IList<ValorDTO> _ownDataList;


        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<ValorDTO> _ownDataListProv;

        public IList<ValorDTO> OwnDataListProv
        {
            get { return _ownDataListProv; }
            set { _ownDataListProv = value; }
        }



        #region Constructor

        public Localidades()
        {
            this.initialData(); //cuando instancias las localidades, ya sabes cuales son.
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

                this._ownDataList = ValorDTO.obtenerLocalidadesDeClientes();

                ValorDTO loc = new ValorDTO();
                loc.Id = 0;
                loc.Valor = "";
                this._ownDataList.Insert(0, loc);

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las localidades. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnDataProv(int id_provincia)
        {
            try
            {
                this._ownDataListProv = ValorDTO.obtenerValores("LO", id_provincia);
                ValorDTO mar = new ValorDTO();
                mar.Id = 0;
                mar.Valor = "";
                this._ownDataListProv.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las localidades. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

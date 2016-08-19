using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class MedidaCubierta
    {

        private IList<ProductoDTO> _ownDataList;

        public IList<ProductoDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<ProductoDTO> _ownDataList2;

        public IList<ProductoDTO> OwnDataList2
        {
            get { return _ownDataList2; }
            set { _ownDataList2 = value; }
        }

        #region Constructor

        public MedidaCubierta()
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
                this._ownDataList = ProductoDTO.obtenerMedidaCubierta();

                ProductoDTO medCu = new ProductoDTO();
                this._ownDataList.Insert(0, medCu);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las medidas de cubiertas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnData2()
        {
            try
            {
                this._ownDataList2 = ProductoDTO.obtenerMedidaCubierta2();

                ProductoDTO medCu = new ProductoDTO();
                this._ownDataList2.Insert(0, medCu);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las medidas de cubiertas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion
    }
}

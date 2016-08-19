using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Vendedores
    {

        private IList<VendedorDTO> _ownDataList;

        internal IList<VendedorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<String> _nameDataList;

        public IList<String> NameDataList
        {
            get { return _nameDataList; }
            set { _nameDataList = value; }
        }

        #region Constructor

        public Vendedores()
        {
            this.initialData();
        }

        #endregion

        #region Métodos

        public void initialData()
        {
            _nameDataList = new List<String>();

            this.refreshFiltroData();
            this.refreshOwnData();

        }

        public void refreshOwnData()
        {
            try
            {

                this._ownDataList = VendedorDTO.obtenerVendedores();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la grilla de clientes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        public void refreshFiltroData()
        {
            try
            {
                this._nameDataList.Clear();
                this._nameDataList.Add("");

                foreach (VendedorDTO c in VendedorDTO.obtenerFiltroVendedorDTO())
                {

                    this._nameDataList.Add(c.Nombre);

                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los filtros de vendedor. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        #endregion

    }
}

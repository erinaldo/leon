using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class CuentaCorriente
    {

        IList<CuentaCorrienteDTO> _GridDataList;

        public IList<CuentaCorrienteDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<CuentaCorrienteProvDTO> _GridDataListProv;

        public IList<CuentaCorrienteProvDTO> GridDataListProv
        {
            get { return _GridDataListProv; }
            set { _GridDataListProv = value; }
        }

        #region Constructor


        public CuentaCorriente()
        {
            this.initialData();
        }

        #endregion


        #region Métodos

        public void initialData()
        {

        }


        public void refreshGridData(FiltrosABMCliente filtro)
        {
            try
            {

                this._GridDataList = CuentaCorrienteDTO.obtenerDatosCuenta(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los datos de la cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(FiltrosABMProveedor filtro)
        {
            try
            {

                this._GridDataListProv = CuentaCorrienteProvDTO.obtenerDatosCuenta(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los datos de la cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.8
        public String obtenerSaldoComienzoDeMes(string idCliente)
        {
            try
            {
                return CuentaCorrienteDTO.obtenerSaldoAPrincipioDeMes(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los datos de la cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public String obtenerSaldoComienzoDeMesProv(string idProveedor)
        {
            try
            {
                return CuentaCorrienteDTO.obtenerSaldoAPrincipioDeMesProv(idProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los datos de la cuenta corriente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        #endregion

    }
}

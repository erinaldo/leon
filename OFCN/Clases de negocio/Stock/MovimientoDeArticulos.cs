using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class MovimientoDeArticulos
    {
        private IList<MovimientoDeArticulosDTO> _gridDataList;

        public IList<MovimientoDeArticulosDTO> GridDataList
        {
            get { return _gridDataList; }
            set { _gridDataList = value; }
        }

        #region Constructor

        public MovimientoDeArticulos()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {

        }

        public void refreshGridData(long idArticulo, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                this._gridDataList = MovimientoDeArticulosDTO.obtenerMovimientos(idArticulo, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los movimientos de artículos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void ingresar(MovimientoDeArticulosDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    MovimientoDeArticulosDTO.ingreso(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible realizar el ingreso. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
                throw new Exception("No ha sido posible realizar el ingreso. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);
        }

        public void egresar(MovimientoDeArticulosDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    MovimientoDeArticulosDTO.egreso(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible realizar el egreso. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
                throw new Exception("No ha sido posible realizar el egreso. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);
        }

        private bool isValid(MovimientoDeArticulosDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Id_producto == -1)
            {
                rv = false;
                msg += "\nEl artículo no existe.";
            }

            return rv;
        }

    }
}

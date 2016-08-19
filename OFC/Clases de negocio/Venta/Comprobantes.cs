using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Comprobantes
    {
        IList<ComprobanteDTO> _GridDataList;

        public IList<ComprobanteDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<ComprobanteCompraDTO> _GridDataListProv;

        public IList<ComprobanteCompraDTO> GridDataListProv
        {
            get { return _GridDataListProv; }
            set { _GridDataListProv = value; }
        }

        #region Constructor


        public Comprobantes()
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
                this._GridDataList = ComprobanteDTO.obtenerComprobantes(filtro);

                if (RemitoDTO.existeRemitoSinFactura(filtro.FiltroCodigo, filtro.FiltroNroComprobante))
                {
                    if (_GridDataList == null)
                    {
                        _GridDataList = new List<ComprobanteDTO>();
                    }

                    foreach (ComprobanteDTO compronante in ComprobanteDTO.obtenerComprobanteRemito(filtro)) //comentario feb 1.9.2: esto sirve para levantarlos solamente los remitos temporales (T)
                    {
                        this._GridDataList.Add(compronante);
                    }

                    //ordeno por fecha...
                    _GridDataList = _GridDataList.OrderBy(o => o.Fecha_creacion).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los comprobantes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(FiltrosABMProveedor filtro)
        {
            try
            {
                this._GridDataListProv = ComprobanteCompraDTO.obtenerComprobantes(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los comprobantes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        #endregion
    }
}

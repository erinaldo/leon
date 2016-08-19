using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Servicio
    {
        private IList<ServicioDTO> _ownServList;

        public IList<ServicioDTO> OwnServList
        {
            get { return _ownServList; }
            set { _ownServList = value; }
        }

        private IList<ServicioDTO> _ownServAdicionalList;

        public IList<ServicioDTO> OwnServAdicionalList
        {
            get { return _ownServAdicionalList; }
            set { _ownServAdicionalList = value; }
        }

        private IList<ServicioDTO> _ownServListTotal;

        public IList<ServicioDTO> OwnServListTotal
        {
            get { return _ownServListTotal; }
            set { _ownServListTotal = value; }
        }

        private IList<ServicioDTO> _ownServListTotal2;

        public IList<ServicioDTO> OwnServListTotal2
        {
            get { return _ownServListTotal2; }
            set { _ownServListTotal2 = value; }
        }

        private IList<ServicioDTO> _gridDataList;

        public IList<ServicioDTO> GridDataList
        {
            get { return _gridDataList; }
            set { _gridDataList = value; }
        }

        #region Constructor

        public Servicio()
        {
            this.initialData();
        }


        #endregion

        #region Métodos


        public void initialData()
        {
            this.refreshServData();
            this.refreshServAdicionalData();
            this.refreshServDataTotal();
        }

        public void refreshServDataTotal()
        {
            try
            {
                this._ownServListTotal = ServicioDTO.obtenerServicioTotal();
                ServicioDTO mar = new ServicioDTO();
                this._ownServListTotal.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los servicios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshServDataTotal2()
        {
            try
            {
                this._ownServListTotal2 = ServicioDTO.obtenerServicioTotal2();
                ServicioDTO mar = new ServicioDTO();
                this._ownServListTotal2.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los servicios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshServData()
        {
            try
            {
                this._ownServList = ServicioDTO.obtenerServicio();
                ServicioDTO mar = new ServicioDTO();
                this._ownServList.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los servicios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshServAdicionalData()
        {
            try
            {
                this._ownServAdicionalList = ServicioDTO.obtenerServicioAdicional();
                ServicioDTO mar = new ServicioDTO();
                this._ownServAdicionalList.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los servicios adicionales. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(string descripcion)
        {
            try
            {
                this._gridDataList = ServicioDTO.obtenerServicios(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los servicios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public ServicioDTO insert(ServicioDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ServicioDTO.insertarServicio(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar el servicio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar el servicio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public ServicioDTO update(ServicioDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ServicioDTO.actualizarServicio(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el servicio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el servicio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        private bool isValid(ServicioDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Descripcion == "")
            {
                rv = false;
                msg += "\nFalta ingresar la descripción.";
            }

            return rv;
        }

        public bool delete(ServicioDTO data)
        {
            string msg = "";

            if (this.isValidDelete(data, ref msg))
            {

                try
                {
                    return ServicioDTO.borrarServicio(data.Id);

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el servicio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el servicio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValidDelete(ServicioDTO data, ref string msg)
        {
            bool rv = true;

            if (ServicioDTO.tieneComprobanteAsociado(data.Id))
            {
                rv = false;
                msg += "\nEl servicio está relacionado a órdenes de trabajo o facturas.";
            }
            else
            {
                rv = true;
            }

            return rv;
        }

        #endregion
    }
}

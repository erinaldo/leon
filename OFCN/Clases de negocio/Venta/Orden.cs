using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Orden
    {

        IList<String> _ownDataList;

        public IList<String> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }


        #region Constructor


        public Orden()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            _ownDataList = new List<String>(); 
            //this.refreshOwnData();
        }

        public void refreshOwnData()
        {
            try
            {
                this._ownDataList.Clear();
                this._ownDataList.Add("");

                foreach (OrdenDTO c in OrdenDTO.obtenerNroOrdenesRegistradas())
                {

                    this._ownDataList.Add(c.Id.ToString());

                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el listado de órdenes por facturar. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public OrdenDTO insert(OrdenDTO data, bool isTemp)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    OrdenDTO.insertarOrden(data);
                    if (isTemp)
                    {
                        ComprobanteTempDTO comp = new ComprobanteTempDTO();
                        comp.Id_origen = data.Id;
                        comp.Comprobante = "ORDENES";
                        ComprobanteTempDTO.insertarTemporal(comp, decimal.Zero); //feb 1.9.1
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar la orden. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
            {
                throw new Exception("No ha sido posible generar la orden. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);
            }

            return data;
        }

        //nunca se da este caso... pensamiento inicial de diseño que quedó sin uso
        private bool isValid(OrdenDTO data, ref string msg)
        {

            bool rv = true;

            if (OrdenDTO.existeNroOrden(data.Id))
            {
                rv = false;
                msg += "\nEl número de orden ya existe.";
            }

            return rv;

        }

        public bool registrar()
        {
            try
            {
                //foreach (long idOrden in OrdenDTO.obtenerOrdenTemp())
                //{
                //    ComprobanteDTO.insertar("ORDEN", idOrden);
                //}
                
                ComprobanteTempDTO.borrarComprobanteTemp();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible registrar las ordenes de trabajo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

    }
}

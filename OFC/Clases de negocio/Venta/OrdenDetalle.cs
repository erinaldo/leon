using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    class OrdenDetalle
    {

        IList<OrdenDetalleDTO> _GridDataList;

        public IList<OrdenDetalleDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        List<OrdenDetalleDTO> _pendienteDataList;

        public List<OrdenDetalleDTO> PendienteDataList
        {
            get { return _pendienteDataList; }
            set { _pendienteDataList = value; }
        }

        List<OrdenDetalleDTO> _pendienteDataListRem;

        public List<OrdenDetalleDTO> PendienteDataListRem
        {
            get { return _pendienteDataListRem; }
            set { _pendienteDataListRem = value; }
        }

        #region Constructor


        public OrdenDetalle()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridDataPendiente(); 
        }

        public void refreshGridDataPendiente()
        {
            try
            {

                this._GridDataList = OrdenDetalleDTO.obtenerDetalleTemp();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo pendientes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridDataRegistrado(FiltrosOrden filtros)
        {
            try
            {

                this._GridDataList = OrdenDetalleDTO.obtenerDetalleNoTemp(filtros);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error grave.");
                
                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo registradas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.");
            }
        }

        public void refreshGridDataRegistrado2(FiltrosOrden filtros)
        {
            try
            {

                this._GridDataList = OrdenDetalleDTO.obtenerDetalleNoTemp2(filtros);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error grave.");

                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo registradas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.");
            }
        }

        public void refreshGridDataRegistrado3(FiltrosOrden filtros)
        {
            try
            {
                this._GridDataList = OrdenDetalleDTO.obtenerDetalleNoTemp3(filtros);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error grave.");

                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo registradas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.");
            }
        }


        public void refreshGridDataRegistrado4(FiltrosOrden filtros)
        {
            try
            {
                this._GridDataList = OrdenDetalleDTO.obtenerDetalleNoTemp4(filtros);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Error grave.");

                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo registradas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.");
            }
        }

        public void refreshOrdenToProcess()
        {
            try
            {

                this._pendienteDataList = OrdenDetalleDTO.obtenerOrdenesFactura();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo a facturar. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOrdenToProcessRemito()
        {
            try
            {

                this._pendienteDataListRem = OrdenDetalleDTO.obtenerOrdenesRemito();
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle de ordenes de trabajo a despachar. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public bool delete(long id_orden, int renglon)
        {
            try
            {
                OrdenDetalleDTO.borrarOrdenDetalle(id_orden, renglon);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar el renglon de la orden. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }


        public OrdenDetalleDTO insert(OrdenDetalleDTO data)
        {
            try
                {
                    OrdenDetalleDTO.insertarOrdenDetalle(data);

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el renglon de la orden. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            return data;
        }

        public OrdenDetalleDTO update(OrdenDetalleDTO data)
        {
            try
            {
                OrdenDetalleDTO.actualizarOrdenDetalle(data);

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible actualizar el renglon de la orden. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
            return data;
        }

        public OrdenDetalleDTO updateHist(OrdenDetalleDTO data)
        {
            try
            {
                OrdenDetalleDTO.actualizarOrdenDetalleHist(data);

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible actualizar el renglon de la orden. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
            return data;
        }


        public static bool isValid(OrdenDTO dataO, OrdenDetalleDTO data, ref string msg)
        {
            bool rv = true;

            if (dataO.Id_cliente == "")
            {
                dataO.Id_cliente = OrdenDTO.obtenerCliente(data.Id_orden_de_trabajo);
            }

            if (!OrdenDetalleDTO.existePrecio(dataO.Id_cliente, data.Id_producto, data.Id_servicio, data.Id_servicio_adicional))
                {
                    rv = false;
                    msg += "\nDebe cargar un precio para la cubierta, trabajo o servicio adicional. Verifique la lista de precio del cliente.";
                }

            return rv;

        }

        public static bool isValidHist(OrdenDTO dataO, OrdenDetalleDTO data, ref string msg)
        {
            bool rv = true;

            if (dataO.Id_cliente == "")
            {
                dataO.Id_cliente = OrdenDTO.obtenerClienteOrdenHist(data.Id_orden_de_trabajo);
            }

            if (!OrdenDetalleDTO.existePrecio(dataO.Id_cliente, data.Id_producto, data.Id_servicio, data.Id_servicio_adicional))
            {
                rv = false;
                msg += "\nDebe cargar un precio para la cubierta, trabajo o servicio adicional. Verifique la lista de precio del cliente.";
            }

            return rv;

        }

    }
}

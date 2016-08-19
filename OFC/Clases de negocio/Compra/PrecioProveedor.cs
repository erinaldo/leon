using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class PrecioProveedor
    {
        IList<PrecioProveedorDTO> _GridDataList;

        public IList<PrecioProveedorDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        IList<PrecioProveedorDTO> _GridDataList2;

        public IList<PrecioProveedorDTO> GridDataList2
        {
            get { return _GridDataList2; }
            set { _GridDataList2 = value; }
        }

        PrecioProveedorDTO precio;

        public PrecioProveedorDTO Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        #region Constructor

        public PrecioProveedor()
        {
            precio = new PrecioProveedorDTO();
            this.initialData();
        }

        #endregion

        public void initialData()
        {

        }

        public void refreshGridData(string id_proveedor)
        {
            try
            {
                this._GridDataList = PrecioProveedorDTO.obtenerPrecios(id_proveedor);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la grilla con los artículos del proveedor. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData2(string id_proveedor, string cod_articulo)
        {
            try
            {
                this._GridDataList2 = PrecioProveedorDTO.obtenerPrecios(id_proveedor, cod_articulo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la grilla con los artículos del proveedor. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void setPrecio(string id_proveedor, string cod_articulo)
        {
            try
            {
                precio = PrecioProveedorDTO.obtenerPrecios(id_proveedor, cod_articulo)[0];
            }
            catch (Exception)
            {
                precio = new PrecioProveedorDTO();
                //throw new Exception("El artículo no está es la lista de precio del proveedor.");
            }
        }

        public void generarPrecio(ProductoDTO articulo, string codProveedor)
        {
            precio.Codigo = articulo.Codigo;
            precio.Id_producto = articulo.Id;
            precio.Id_proveedor = codProveedor;
            precio.Valor = decimal.Zero;
        }

        public void generarPrecio(PrecioProveedorDTO precioParam)
        {
            precio.Codigo = precioParam.Codigo;
            precio.Id_producto = precioParam.Id_producto;
            precio.Id_proveedor = precioParam.Id_proveedor;
            precio.Valor = precioParam.Valor;
        }

        public void insertar()
        {
            try
            {
                PrecioProveedorDTO.insertarPrecio(precio);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible relacionar el artículo con el proveedor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void borrar()
        {
            try
            {
                PrecioProveedorDTO.borrarPrecio(precio);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible quitar el artículo de la lista. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public void actualizar()
        {
            try
            {
                PrecioProveedorDTO.actualizarPrecio(precio);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible guardar el precio del artículo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

    }
}

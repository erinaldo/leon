using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Producto
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

        private IList<ProductoDTO> _ownDataList3;

        public IList<ProductoDTO> OwnDataList3
        {
            get { return _ownDataList3; }
            set { _ownDataList3 = value; }
        }

        private IList<ProductoDTO> _ownDataList4;

        public IList<ProductoDTO> OwnDataList4
        {
            get { return _ownDataList4; }
            set { _ownDataList4 = value; }
        }

        private IList<ProductoDTO> _gridDataList;

        public IList<ProductoDTO> GridDataList
        {
            get { return _gridDataList; }
            set { _gridDataList = value; }
        }

        private IList<ProductoDTO> _gridDataList2;

        public IList<ProductoDTO> GridDataList2
        {
            get { return _gridDataList2; }
            set { _gridDataList2 = value; }
        }

        private IList<ProductoDTO> _gridDataList3;

        public IList<ProductoDTO> GridDataList3
        {
            get { return _gridDataList3; }
            set { _gridDataList3 = value; }
        }

        #region Constructor

        public Producto()
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
                this._ownDataList = ProductoDTO.obtenerDescripcion();

                ProductoDTO medCu = new ProductoDTO();
                this._ownDataList.Insert(0, medCu);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnData2()
        {
            try
            {
                this._ownDataList2 = ProductoDTO.obtenerDescripcion2();

                ProductoDTO medCu = new ProductoDTO();
                this._ownDataList2.Insert(0, medCu);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }



        public void refreshOwnData3(string nombre_proveedor)
        {
            try
            {
                this._ownDataList3 = ProductoDTO.obtenerArticulosDisponibles(nombre_proveedor);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos disponibles. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnData4()
        {
            try
            {
                this._ownDataList4 = ProductoDTO.obtenerArticulos();

                ProductoDTO art = new ProductoDTO();
                this._ownDataList4.Insert(0, art);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos vigentes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(string descripcion)
        {
            try
            {
                this._gridDataList = ProductoDTO.obtenerArticulos(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData2(string medidaCubierta)
        {
            try
            {
                this._gridDataList2 = ProductoDTO.obtenerNeumaticos(medidaCubierta);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los neumáticos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData3(string nombre_proveedor, string cod_articulo)
        {
            try
            {
                this._gridDataList3 = ProductoDTO.obtenerArticulosDisponibles(nombre_proveedor, cod_articulo);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los artículos disponibles. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public ProductoDTO insert(ProductoDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ProductoDTO.insertarProducto(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar el artículo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar el artículo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public ProductoDTO update(ProductoDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ProductoDTO.actualizarProducto(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el artículo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el artículo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        private bool isValid(ProductoDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Es_cubierta == 'S' && data.Medida_cubierta == "")
            {
                rv = false;
                msg += "\nFalta ingresar la medida de la cubierta.";
            }

            if (data.Es_cubierta == 'N' && data.Descripcion == "")
            {
                rv = false;
                msg += "\nFalta ingresar la descripción.";
            }

            if (data.Es_cubierta == 'N' && data.Codigo == "")
            {
                rv = false;
                msg += "\nFalta ingresar el código.";
            }

            if (data.Es_cubierta == 'N' && data.Codigo_de_barras != "" && data.Id != -1)
            {
                if (ProductoDTO.existeCodigoDeBarra(data.Id, data.Codigo_de_barras))
                {
                    msg = "\nExiste un artículo con el código de barras ingresado.";
                    rv = false;
                }
            }

            if (data.Es_cubierta == 'N' && data.Descripcion != "" && data.Id != -1)
            {
                if (ProductoDTO.existeDescripcion(data.Id, data.Descripcion))
                {
                    msg = "\nExiste un artículo con la descripcion ingresada.";
                    rv = false;
                }
            }

            return rv;
        }


        public bool delete(ProductoDTO data)
        {
            string msg = "";

            if (this.isValidDelete(data, ref msg))
            {

                try
                {
                    return ProductoDTO.borrarProducto(data.Id);

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el artículo. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el artículo. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValidDelete(ProductoDTO data, ref string msg)
        {
            bool rv = true;

            if (ProductoDTO.tieneComprobanteAsociado(data.Id))
            {
                rv = false;
                msg += "\nEl artículo está relacionado a órdenes de trabajo o facturas. No puede ser borrado.";
            }

            return rv;
        }


        #endregion
    }
}

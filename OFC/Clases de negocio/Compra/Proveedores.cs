using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Proveedores
    {

        IList<ProveedorDTO> _GridDataList;

        public IList<ProveedorDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        private IList<String> _CodDataList;

        public IList<String> CodDataList
        {
            get { return _CodDataList; }
            set { _CodDataList = value; }
        }

        private IList<String> _NombreDataList;

        public IList<String> NombreDataList
        {
            get { return _NombreDataList; }
            set { _NombreDataList = value; }
        }

        private IList<String> _CuitDataList;

        public IList<String> CuitDataList
        {
            get { return _CuitDataList; }
            set { _CuitDataList = value; }
        }
        
        #region Constructor


        public Proveedores()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            FiltrosABMProveedor f = new FiltrosABMProveedor();

            _CodDataList = new List<String>();
            _NombreDataList = new List<String>();
            _CuitDataList = new List<String>();

            this.refreshFiltroData();
            this.refreshGridData(f);

        }

        public void refreshGridData(FiltrosABMProveedor filtro)
        {
            try
            {
                this._GridDataList = ProveedorDTO.obtenerProveedoresGrilla(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la grilla de proveedores. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshFiltroData()
        {
            try
            {
                _CodDataList.Clear();
                _NombreDataList.Clear();
                _CuitDataList.Clear();

                foreach (ProveedorDTO c in ProveedorDTO.obtenerFiltroProveedorDTO())
                {
                    this._CodDataList.Add(c.Id);
                    this._NombreDataList.Add(c.Nombre);
                    this._CuitDataList.Add(c.Cuit);
                }

                //ordeno las listas
                List<string> listOrder;

                listOrder = (List<string>)this._CodDataList;
                listOrder.Sort();
                listOrder.RemoveAll(item => item == string.Empty);
                this._CodDataList = listOrder;

                listOrder = (List<string>)this._NombreDataList;
                listOrder.Sort();
                listOrder.RemoveAll(item => item == string.Empty);
                this._NombreDataList = listOrder;

                listOrder = (List<string>)this._CuitDataList;
                listOrder.Sort();
                listOrder.RemoveAll(item => item == string.Empty);
                this._CuitDataList = listOrder;

                this._CodDataList.Insert(0, "");
                this._NombreDataList.Insert(0, "");
                this._CuitDataList.Insert(0, "");

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los filtros de proveedores. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public string obtenerNombre(string codigo)
        {
            try
            {

                return ProveedorDTO.obtenerNombrePorCodigo(codigo).Nombre;

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el nombre. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public string obtenerCodigo(string nombre)
        {
            try
            {

                return ProveedorDTO.obtenerCodPorNombre(nombre).Id;


            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el codigo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public bool delete(string codigo)
        {
            try
            {
                ProveedorDTO.borrarProveedor(codigo);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible borrar el proveedor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
            }
        }

        public ProveedorDTO update(ProveedorDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, true))
            {
                try
                {
                    ProveedorDTO.actualizarProveedor(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el proveedor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el proveedor. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }


        public ProveedorDTO insert(ProveedorDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, false))
            {
                try
                {
                    ProveedorDTO.insertarProveedor(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el proveedor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible generar el proveedor. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }



        private bool isValid(ProveedorDTO data, ref string msg, bool es_actualizacion)
        {
            bool rv = true;

            if (data.Id == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de proveedor.";
            }
            else
            {
                // Validamos que no exista el id en nuestra base.
                if (ProveedorDTO.existeId(data.Id) && !es_actualizacion)
                {
                    rv = false;
                    msg += "\nEl código de proveedor ya existe.";
                }
            }

            if (data.Nombre == "")
            {
                rv = false;
                msg += "\nDebe ingresar el nombre de proveedor.";
            }
            else
            {
                // Validamos que no exista el nombre en nuestra base.
                if (ProveedorDTO.existeNombre(data.Nombre, data.Id))
                {
                    rv = false;
                    msg += "\nEl nombre del proveedor ya existe.";
                }
            }

            return rv;

        }

    }
}

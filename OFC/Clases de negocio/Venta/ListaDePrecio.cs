using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class ListaDePrecio
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<ValorDTO> _ownDataList2;

        public IList<ValorDTO> OwnDataList2
        {
            get { return _ownDataList2; }
            set { _ownDataList2 = value; }
        }

        private IList<string> _ownDataColum;

        public IList<string> OwnDataColum
        {
            get { return _ownDataColum; }
            set { _ownDataColum = value; }
        }

        private IList<PrecioDTO> _ownDataModeloPrecio;

        public IList<PrecioDTO> OwnDataModeloPrecio
        {
            get { return _ownDataModeloPrecio; }
            set { _ownDataModeloPrecio = value; }
        }

        #region Constructor

        public ListaDePrecio()
        {
            _ownDataColum = new List<string>();
            _ownDataModeloPrecio = new List<PrecioDTO>();
            this.initialData(); 
        }


        #endregion

        #region Métodos


        public void initialData()
        {
            //dos consultas a base de datos... y bue...
            this.refreshOwnData();
            this.refreshOwnData2();
            //this.refreshOwnDataColum();
        }

        public void refreshOwnDataColum()
        {
            try
            {
                this._ownDataColum.Clear();

                this._ownDataColum.Insert(0,"ARTICULO");
                this._ownDataColum.Insert(1, "PRECIO");
                this._ownDataColum.Insert(2, "CUBIERTA");

                int posicion = 3;

                foreach (ServicioDTO s in ServicioDTO.obtenerServicioTotal())
                {
                    this._ownDataColum.Insert(posicion, s.Descripcion);
                    posicion += 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las listas de precios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnDataModeloPrecio(long idLista, string medidaCubierta, string articulo)
        {
            try
            {
                _ownDataModeloPrecio = PrecioDTO.obtenerPrecios(idLista, medidaCubierta, articulo);
              
            }

            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la lista de precios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        public void refreshOwnData()
        {
            try
            {
                this._ownDataList = ValorDTO.obtenerValores("LP");
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las listas de precios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        public void refreshOwnData2()
        {
            try
            {
                this._ownDataList2 = ValorDTO.obtenerValores("LP");
                ValorDTO val = new ValorDTO();
                val.Id = 0;
                val.Valor = "";
                this._ownDataList2.Insert(0, val);

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las listas de precios. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public PrecioDTO insert(PrecioDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    PrecioDTO.insertarPrecio(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar el precio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar el precio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }


        public PrecioDTO update(PrecioDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    PrecioDTO.actualizarPrecio(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el precio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el precio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public void update(List<PrecioDTO> data)
        {
                try
                {
                    PrecioDTO.actualizarPrecio(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar los precios de la lista. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
        }

        public bool delete(PrecioDTO data)
        {
            string msg = "";

            if (this.isValidDelete(data, ref msg))
            {

                try
                {
                    return PrecioDTO.borrarPrecio(data.Id); 

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el precio. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el precio. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValid(PrecioDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Id_lista_precio == -1 || data.Id_producto == -1)
            {
                rv = false;
                msg += "\nFalta ingresar datos obligatorios.";
            }

            if (data.Valor < 0)
            {
                rv = false;
                msg += "\nEl precio ingresado es incorrecto.";
            }

            return rv;
        }

        private bool isValidDelete(PrecioDTO data, ref string msg)
        {
            bool rv = true;

            if (OrdenDTO.existeOrdenSinFacturar(data))
            {
                rv = false;
                msg += "\nExisten órdenes pendientes de facturar que necesitan el precio.";
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

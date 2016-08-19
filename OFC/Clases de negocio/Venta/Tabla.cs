using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Tabla
    {
        private IList<TablaDTO> _ownDataList;

        public IList<TablaDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<TablaDTO> _ownDataListTotal;

        public IList<TablaDTO> OwnDataListTotal
        {
            get { return _ownDataListTotal; }
            set { _ownDataListTotal = value; }
        }

        #region Constructor

        public Tabla()
        {
            this.initialData(); 
        }
        
        #endregion

        #region Métodos
        
        public void initialData()
        {
           
        }

        public void refreshOwnData(string descripcion)
        {
            try
            {
                this._ownDataList = TablaDTO.obtenerTablas(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las tablas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnDataTotal()
        {
            try
            {
                this._ownDataListTotal = TablaDTO.obtenerTodasLasTablas();
                TablaDTO mar = new TablaDTO();
                mar.Id = string.Empty;
                mar.Tabla = string.Empty;
                this._ownDataListTotal.Insert(0, mar);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener las tablas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }




        public TablaDTO insert(TablaDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    TablaDTO.insert(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar la tabla. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar la tabla. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public TablaDTO update(TablaDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    TablaDTO.update(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar la tabla. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar la tabla. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        private bool isValid(TablaDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Id == "")
            {
                rv = false;
                msg += "\nFalta ingresar el identificador de la tabla.";
            }

            if (data.Tabla == "")
            {
                rv = false;
                msg += "\nFalta ingresar la descripcion de la tabla.";
            }

            return rv;
        }


        public bool delete(TablaDTO data)
        {
            string msg = "";

            if (this.isValidDelete(data, ref msg) && this.isValid(data, ref msg))
            {
                try
                {
                    TablaDTO.delete(data);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar la tabla. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar la tabla. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValidDelete(TablaDTO data, ref string msg)
        {
            bool rv = true;

            if (TablaDTO.existeValor(data.Id))
            {
                rv = false;
                msg += "\nLa tabla tiene valores cargados.";
            }

            return rv;
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Parametro
    {
        private IList<ParametroDTO> _ownDataList;

        public IList<ParametroDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<ParametroDTO> _ownDataListGrid;

        public IList<ParametroDTO> OwnDataListGrid
        {
            get { return _ownDataListGrid; }
            set { _ownDataListGrid = value; }
        }

        private long _iva;

        public long Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        #region Constructor

        public Parametro()
        {
            this.initialData(); 
        }

        #endregion

        #region Métodos

        public void initialData()
        {
            this.refreshIva();
        }

        public void refreshIva()
        {
            try
            {
                this._iva = long.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el IVA. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        public void refreshOwnData()
        {
            try
            {
                this._ownDataList = ParametroDTO.obtenerParametros();

                ParametroDTO medCu = new ParametroDTO();
                this._ownDataList.Insert(0, medCu);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los parámetros del sistema. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnData(string descripcion)
        {
            try
            {
                this._ownDataListGrid = ParametroDTO.obtenerParametros(descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los parámetros del sistema. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public ParametroDTO insert(ParametroDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ParametroDTO.insert(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar el parámetro. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar el parámetro. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public ParametroDTO update(ParametroDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ParametroDTO.update(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el parámetro. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el parámetro. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        private bool isValid(ParametroDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Descripcion == "")
            {
                rv = false;
                msg += "\nFalta ingresar la descripción del parámetro.";
            }

            return rv;
        }

        public bool delete(ParametroDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ParametroDTO.delete(data.Descripcion);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el parámetro. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el parámetro. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        #endregion

    }
}

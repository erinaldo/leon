using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Valor
    {
        private IList<ValorDTO> _ownDataList;

        public IList<ValorDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        #region Constructor

        public Valor()
        {
            this.initialData(); 
        }
        
        #endregion

        #region Métodos
        
        public void initialData()
        {
           
        }

        public void refreshOwnData(string id_tabla, string valor)
        {
            try
            {
                this._ownDataList = ValorDTO.obtenerValores(id_tabla, valor);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los valores de tablas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }


        public ValorDTO insert(ValorDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ValorDTO.insert(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible insertar el valor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible insertar el valor. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        public ValorDTO update(ValorDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    ValorDTO.update(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el valor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el valor. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }

        private bool isValid(ValorDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Id_tabla == "")
            {
                rv = false;
                msg += "\nFalta ingresar el identificador de la tabla.";
            }

            if (data.Valor == "")
            {
                rv = false;
                msg += "\nFalta ingresar el valor.";
            }

            return rv;
        }


        public bool delete(ValorDTO data)
        {
                try
                {
                    ValorDTO.delete(data.Id);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el valor. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
        }



        #endregion


    }
}

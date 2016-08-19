using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//feb 1.8
namespace OFC
{
    class Talonario
    {
        private IList<String> _ownDataList;

        public IList<String> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        #region Constructor

        public Talonario()
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
                this._ownDataList = TalonarioDTO.obtenerTodos();
                this._ownDataList.Insert(0, string.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los talonarios de recibo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void insert(TalonarioDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg))
            {
                try
                {
                    TalonarioDTO.insertar(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el talonario. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible generar el talonario. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValid(TalonarioDTO data, ref string msg)
        {
            bool rv = true;

            if (data.Id == -1)
            {
                rv = false;
                msg += "\nDebe ingresar el número de talonario.";
            }
            else
            {
                // Validamos que no exista el id en nuestra base.
                if (TalonarioDTO.existeId(data.Id))
                {
                    rv = false;
                    msg += "\nEl número de talonario ya existe.";
                }
            }

            return rv;

        }

        #endregion
    }
}

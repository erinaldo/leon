using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Clientes
    {

        IList<ClienteDTO> _GridDataList;

        public IList<ClienteDTO> GridDataList
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

        //feb 1.9.1
        ClienteDTO _DataFW;

        public ClienteDTO DataFW
        {
            get { return _DataFW; }
            set { _DataFW = value; }
        }


        #region Constructor


        public Clientes()
        {
            this.initialData();
        }

        #endregion


        #region Métodos

        public void initialData()
        {
            FiltrosABMCliente f = new FiltrosABMCliente();

            _CodDataList = new List<String>();
            _NombreDataList = new List<String>();
            _CuitDataList = new List<String>();

            this.refreshFiltroData();
            //this.refreshGridData(f); //feb 1.9.1

        }

        public string obtenerNombre(string codigo)
        {
            try
            {

                return ClienteDTO.obtenerNombrePorCodigo(codigo).Nombre;

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

                return ClienteDTO.obtenerCodPorNombre(nombre).Id;


            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el codigo. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshGridData(FiltrosABMCliente filtro)
        {
            try
            {
                
                this._GridDataList = ClienteDTO.obtenerClientesGrilla(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener la grilla de clientes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        //feb 1.9.1
        public void getDataFW(string id_cliente)
        {
            try
            {
                this._DataFW = ClienteDTO.obtenerDatosFW(id_cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el cliente. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshFiltroData()
        {
            try
            {
                _CodDataList.Clear();
                _NombreDataList.Clear();
                _CuitDataList.Clear();

                foreach (ClienteDTO c in ClienteDTO.obtenerFiltroClienteDTO())
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

                this._CodDataList.Insert(0,"");
                this._NombreDataList.Insert(0, "");
                this._CuitDataList.Insert(0, "");

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los filtros de clientes. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public bool delete(string codigo)
        {
            string msg = "";

            if (this.isValidDelete(codigo, ref msg))
            {
                try
                {
                    ClienteDTO.borrarCliente(codigo);

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el cliente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el cliente. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        public ClienteDTO update(ClienteDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, true))  
            {
                try
                {
                    ClienteDTO.actualizarCliente(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el cliente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el cliente. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }


        public ClienteDTO insert(ClienteDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, false))
            {
                try
                {
                    ClienteDTO.insertarCliente(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el cliente. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible generar el cliente. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

            return data;
        }


        private bool isValidDelete(string codigo, ref string msg)
        {
            bool rv = true;

            if (ClienteDTO.existeOrdenAFacturar(codigo))
            {
                rv = false;
                msg += "\nExisten órdenes a facturar.";
            }

            return rv;
        }

        private bool isValid(ClienteDTO data, ref string msg, bool es_actualizacion)
        {
            bool rv = true;

            if (data.Id == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de cliente.";
            }
            else
            {
                // Validamos que no exista el id en nuestra base.
                if (ClienteDTO.existeId(data.Id) && !es_actualizacion)
                {
                    rv = false;
                    msg += "\nEl código de cliente ya existe.";
                }
            }

            //feb 1.9.1
            if (data.Nombre == "" && data.Fw_id_tipo_persona_externo == ValorDTO.obtenerIdExterno("TP", "JURIDICA"))
            {
                rv = false;
                msg += "\nDebe ingresar la razón social del cliente.";
            }
            else
            {
                // Validamos que no exista el nombre en nuestra base.
                if (ClienteDTO.existeNombre(data.Nombre, data.Id))
                {
                    rv = false;
                    msg += "\nLa razón social del cliente ya existe.";
                }
            }

            //feb 1.9.1
            if (data.Nombre_persona == "" && data.Fw_id_tipo_persona_externo == ValorDTO.obtenerIdExterno("TP", "FISICA"))
            {
                rv = false;
                msg += "\nDebe ingresar el nombre del cliente.";
            }

            //feb 1.9.1
            if (data.Apellido_persona == "" && data.Fw_id_tipo_persona_externo == ValorDTO.obtenerIdExterno("TP", "FISICA"))
            {
                rv = false;
                msg += "\nDebe ingresar el apellido del cliente.";
            }

            //feb 1.9.1
            if (data.Fw_id_tipo_persona_externo == -1)
            {
                rv = false;
                msg += "\nDebe ingresar el tipo de persona correspondiente al cliente.";
            }

            //feb 1.9.1
            if (data.Fw_id_tipo_documento_externo == -1)
            {
                rv = false;
                msg += "\nDebe ingresar el tipo de documento correspondiente al cliente.";
            }

            //feb 1.9.1
            if (data.Cuit == string.Empty)
            {
                rv = false;
                msg += "\nDebe ingresar el número de documento del cliente.";
            }

            //feb 1.9.1
            if (data.Email == string.Empty)
            {
                rv = false;
                msg += "\nDebe ingresar el email del cliente.";
            }

            //feb 1.9.1
            if (data.Id_categoria_iva == -1)
            {
                rv = false;
                msg += "\nDebe ingresar la categoría de IVA del cliente.";
            }

            return rv;

        }

      #endregion

    }
}

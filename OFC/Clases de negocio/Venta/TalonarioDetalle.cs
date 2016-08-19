using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//feb 1.8
namespace OFC
{
    class TalonarioDetalle
    {
        IList<TalonarioDetalleDTO> _GridDataList;

        public IList<TalonarioDetalleDTO> GridDataList
        {
            get { return _GridDataList; }
            set { _GridDataList = value; }
        }

        #region Constructor

        public TalonarioDetalle()
        {
            this.initialData();
        }

        #endregion

        public void initialData()
        {
            //this.refreshGridDataPendiente(); 
        }

        public void refreshGridData(string nro_talonario, string numero_comprobante)
        {
            try
            {
                this._GridDataList = TalonarioDetalleDTO.obtenerDetalle(nro_talonario, numero_comprobante);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener el detalle del talonario. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void insert(TalonarioDTO data, string nro_inicial, string nro_final)
        {
            string msg = "";

            if (this.isValid(data, nro_inicial, nro_final, ref msg))
            {
                try
                {
                    long inicio = long.Parse(nro_inicial);
                    long fin = long.Parse(nro_final);

                    while (inicio <= fin)
                    {
                        TalonarioDetalleDTO det = new TalonarioDetalleDTO();

                        det.Id_talonario = data.Id;
                        det.Estado = "DISPONIBLE";
                        det.Numero_comprobante = ComprobanteDTO.converToNroRecibo(inicio.ToString());
                        int cantDigitosA = (int)ParametroDTO.obtenerParametroI("DIGITOS NRO RECIBO");
                        int cantDigitosB = (int)ParametroDTO.obtenerParametroII("DIGITOS NRO RECIBO");
                        det.Numero_comprobante_1 = int.Parse(det.Numero_comprobante.Substring(0, cantDigitosA));
                        det.Numero_comprobante_2 = long.Parse(det.Numero_comprobante.Substring(cantDigitosA + 1, cantDigitosB));

                        TalonarioDetalleDTO.insertar(det);
                        inicio = inicio + 1;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar los recibos del talonario. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }
            else
                throw new Exception("No ha sido posible generar los recibos del talonario. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);
        }

        private bool isValid(TalonarioDTO data, string inicio, string fin, ref string msg)
        {
            bool rv = true;

            if (data.Id == -1)
            {
                rv = false;
                msg += "\nDebe ingresar el número de talonario.";
            }

            if (inicio == string.Empty)
            {
                rv = false;
                msg += "\nDebe ingresar el número de inicio.";
            }

            if (fin == string.Empty)
            {
                rv = false;
                msg += "\nDebe ingresar el número de fin.";
            }

            if (inicio != string.Empty && fin != string.Empty)
            {
                if (long.Parse(inicio) > long.Parse(fin))
                {
                    rv = false;
                    msg += "\nEl número de inicio no puede ser mayor al número de fin.";
                }

                if (TalonarioDetalleDTO.existeRangoNumerico(long.Parse(inicio), long.Parse(fin)))
                {
                    rv = false;
                    msg += "\nEl rango de números dentro de los valores ingresados ya está registrado en el sistema.";
                }
            }



            return rv;

        }
    }
}

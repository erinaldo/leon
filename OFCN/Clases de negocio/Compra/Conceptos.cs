using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Conceptos
    {
        private IList<ConceptoDTO> _ownDataList;

        public IList<ConceptoDTO> OwnDataList
        {
            get { return _ownDataList; }
            set { _ownDataList = value; }
        }

        private IList<ConceptoDTO> _gridDataList;

        public IList<ConceptoDTO> GridDataList
        {
            get { return _gridDataList; }
            set { _gridDataList = value; }
        }

        #region Constructor

        public Conceptos()
        {
            this.initialData();
        }

        #endregion

        #region Métodos

        public void initialData()
        {
            this.refreshOwnData();
        }

        public void refreshGridData(string codigo, string descripcion)
        {
            try
            {
                this._gridDataList = ConceptoDTO.obtenerConceptos(codigo, descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los conceptos. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void refreshOwnData()
        {
            try
            {
                this._ownDataList = ConceptoDTO.obtenerConceptos();
                ConceptoDTO con = new ConceptoDTO();
                this._ownDataList.Insert(0, con);
            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible obtener los conceptos de compra. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

        public void update(ConceptoDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, true))
            {
                try
                {
                    ConceptoDTO.actualizar(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible actualizar el concepto. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible actualizar el concepto. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        public void insert(ConceptoDTO data)
        {
            string msg = "";

            if (this.isValid(data, ref msg, false))
            {
                try
                {
                    ConceptoDTO.insertar(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible generar el concepto. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible generar el concepto. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValid(ConceptoDTO data, ref string msg, bool es_actualizacion)
        {
            bool rv = true;

            if (data.Codigo == "")
            {
                rv = false;
                msg += "\nDebe ingresar el código de concepto.";
            }
            else
            {
                // Validamos que no exista el codigo en nuestra base.
                if (!es_actualizacion && ConceptoDTO.existeCodigo(data.Codigo))
                {
                    rv = false;
                    msg += "\nEl código de concepto ya existe.";
                }
            }

            if (data.Descripcion == "")
            {
                rv = false;
                msg += "\nDebe ingresar la descripción del concepto.";
            }
            else
            {
                // Validamos que no exista la descripcion en nuestra base.
                if (ConceptoDTO.existeDescripcion(data.Descripcion, data.Codigo))
                {
                    rv = false;
                    msg += "\nLa descripción del concepto ya existe.";
                }
            }

            return rv;

        }

        public decimal sumarSegunIva(List<FacturaDeCompraDetalleDTO> data, decimal porcentajeDeIva)
        {
            decimal importe = decimal.Zero;

            foreach (FacturaDeCompraDetalleDTO row in data)
            {
                if (porcentajeDeIva == ConceptoDTO.obtenerPorcentajeDeIva(row.Id_concepto))
                {
                    importe += row.Importe;
                }
            }
            return importe;
        }

        public decimal sumarSegunIva(List<NotaDeCreditoCompDetalleDTO> data, decimal porcentajeDeIva)
        {
            decimal importe = decimal.Zero;

            foreach (NotaDeCreditoCompDetalleDTO row in data)
            {
                if (porcentajeDeIva == ConceptoDTO.obtenerPorcentajeDeIva(row.Id_concepto))
                {
                    importe += row.Importe;
                }
            }
            return importe;
        }

        public decimal sumarSegunIva(List<NotaDeDebitoCompDetalleDTO> data, decimal porcentajeDeIva)
        {
            decimal importe = decimal.Zero;

            foreach (NotaDeDebitoCompDetalleDTO row in data)
            {
                if (porcentajeDeIva == ConceptoDTO.obtenerPorcentajeDeIva(row.Id_concepto))
                {
                    importe += row.Importe;
                }
            }
            return importe;
        }

        public bool delete(ConceptoDTO data)
        {
            string msg = "";

            if (this.isValidDelete(data, ref msg))
            {

                try
                {
                    return ConceptoDTO.borrar(data.Id);

                }
                catch (Exception ex)
                {
                    throw new Exception("No ha sido posible borrar el concepto. Vuelva a intentarlo, si el problema persiste llame al administrador del sistema.", ex);
                }
            }

            else
                throw new Exception("No ha sido posible borrar el concepto. Corrija los siguientes errores y vuelva a intentarlo: \n" + msg);

        }

        private bool isValidDelete(ConceptoDTO data, ref string msg)
        {
            bool rv = true;

            if (ConceptoDTO.tieneComprobanteAsociado(data.Id))
            {
                rv = false;
                msg += "\nEl concepto está relacionado a un comprobante de compra. No puede ser borrado.";
            }

            return rv;
        }

        #endregion
    }
}

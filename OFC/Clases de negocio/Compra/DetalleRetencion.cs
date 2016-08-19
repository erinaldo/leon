using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class DetalleRetencion
    {
        PagoDetalleRetencionDTO detalleRet;

        public PagoDetalleRetencionDTO DetalleRet
        {
            get { return detalleRet; }
            set { detalleRet = value; }
        }

        public DetalleRetencion()
        {
            detalleRet = new PagoDetalleRetencionDTO();
        }

        public DetalleRetencion(PagoDetalleRetencionDTO p_detalleRet)
        {
            detalleRet = p_detalleRet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class Token
    {
        public static bool FacturacionHabilitada(string login)
        {
            bool hayFactura = ComprobanteTempDTO.existeInstancia("FACTURA", login);
            bool hayDebito = ComprobanteTempDTO.existeInstancia("NOTA DEBITO", login);
            bool hayCredito = ComprobanteTempDTO.existeInstancia("NOTA CREDITO", login);
            return (!hayFactura && !hayCredito && !hayCredito);
        }

        public static bool RemitoHabilitado(string login)
        {
            return !ComprobanteTempDTO.existeInstancia("REMITO", login);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    class FiltrosABMProveedor
    {
        string filtroCodigo;

        public string FiltroCodigo
        {
            get { return filtroCodigo; }
            set { filtroCodigo = value; }
        }

        string filtroNombre;

        public string FiltroNombre
        {
            get { return filtroNombre; }
            set { filtroNombre = value; }
        }

        string filtroCUIT;

        public string FiltroCUIT
        {
            get { return filtroCUIT; }
            set { filtroCUIT = value; }
        }

        DateTime filtroFechaDesde;

        public DateTime FiltroFechaDesde
        {
            get { return filtroFechaDesde; }
            set { filtroFechaDesde = value; }
        }

        DateTime filtroFechaHasta;

        public DateTime FiltroFechaHasta
        {
            get { return filtroFechaHasta; }
            set { filtroFechaHasta = value; }
        }

        long filtroTipoComprobante;

        public long FiltroTipoComprobante
        {
            get { return filtroTipoComprobante; }
            set { filtroTipoComprobante = value; }
        }

        string filtroNroComprobante;

        public string FiltroNroComprobante
        {
            get { return filtroNroComprobante; }
            set { filtroNroComprobante = value; }
        }

        char filtroFacturaIncompleta;

        public char FiltroFacturaIncompleta
        {
            get { return filtroFacturaIncompleta; }
            set { filtroFacturaIncompleta = value; }
        }

        public FiltrosABMProveedor()
        {
            this.filtroCodigo = string.Empty;
            this.filtroNombre = string.Empty;
            this.filtroCUIT = string.Empty;
            this.filtroFechaDesde = DateTime.Now;
            this.filtroFechaHasta = DateTime.Now;
            this.filtroTipoComprobante = -1;
            this.filtroNroComprobante = "";
            this.filtroFacturaIncompleta = 'N';
        }

    }
}

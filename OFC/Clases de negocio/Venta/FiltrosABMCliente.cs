using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    public class FiltrosABMCliente
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

        string filtroLocalidad;

        public string FiltroLocalidad
        {
            get { return filtroLocalidad; }
            set { filtroLocalidad = value; }
        }

        string filtroVendedor;

        public string FiltroVendedor
        {
            get { return filtroVendedor; }
            set { filtroVendedor = value; }
        }

        string filtroCUIT;

        public string FiltroCUIT
        {
            get { return filtroCUIT; }
            set { filtroCUIT = value; }
        }

        string filtroCodComprobanteFact;

        public string FiltroCodComprobanteFact
        {
            get { return filtroCodComprobanteFact; }
            set { filtroCodComprobanteFact = value; }
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

        long filtroMedidaCubierta;

        public long FiltroMedidaCubierta
        {
            get { return filtroMedidaCubierta; }
            set { filtroMedidaCubierta = value; }
        }

        long filtroNroOrden;

        public long FiltroNroOrden
        {
            get { return filtroNroOrden; }
            set { filtroNroOrden = value; }
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
        
        public FiltrosABMCliente()
        {
            this.filtroCodigo = "";
            this.filtroNombre = "";
            this.filtroLocalidad = "";
            this.filtroVendedor = "";
            this.filtroCUIT = "";
            this.filtroCodComprobanteFact = "";
            this.filtroFechaDesde = DateTime.Now;
            this.filtroFechaHasta = DateTime.Now;
            this.filtroMedidaCubierta = -1;
            this.filtroNroOrden = -1;
            this.filtroTipoComprobante = -1;
            this.filtroNroComprobante = "";
        }


    }
}

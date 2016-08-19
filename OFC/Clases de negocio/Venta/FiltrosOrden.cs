using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OFC
{
    public class FiltrosOrden
    {
        string filtroCodCliente;

        public string FiltroCodCliente
        {
            get { return filtroCodCliente; }
            set { filtroCodCliente = value; }
        }

        string filtroNombreCliente;

        public string FiltroNombreCliente
        {
            get { return filtroNombreCliente; }
            set { filtroNombreCliente = value; }
        }

        string filtroNroOrden;

        public string FiltroNroOrden
        {
            get { return filtroNroOrden; }
            set { filtroNroOrden = value; }
        }

        long filtroTrabajo;

        public long FiltroTrabajo
        {
            get { return filtroTrabajo; }
            set { filtroTrabajo = value; }
        }

        long filtroServicioAdi;

        public long FiltroServicioAdi
        {
            get { return filtroServicioAdi; }
            set { filtroServicioAdi = value; }
        }

        long filtroMedida;

        public long FiltroMedida
        {
            get { return filtroMedida; }
            set { filtroMedida = value; }
        }

        public FiltrosOrden()
        {
            this.filtroCodCliente = "";
            this.filtroNombreCliente = "";
            this.filtroNroOrden = "";
            this.filtroTrabajo = -1;
            this.filtroServicioAdi = -1;
            this.filtroMedida = -1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace OFC
{
    public partial class frmVerPagos : Form
    {
        public frmVerPagos()
        {
            InitializeComponent();
        }

        private void frmVerPagos_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crPagos cargarReporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from pagos('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (fecha date, id_proveedor character varying(8), nombre_proveedor character varying(255), nro_comprobante character varying(20), mp_cheque_tercero double precision, mp_efectivo double precision, mp_cheque_propio double precision, mp_transferencia_bancaria double precision, mp_tarjeta_credito double precision, mp_tarjeta_debito double precision, mp_otro double precision, mp_retencion double precision, total double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsPagos dsLista = new dsPagos();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crPagos rptLista = new crPagos();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtPagos");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Pagos del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }
    }
}

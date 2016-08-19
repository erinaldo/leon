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
    public partial class frmVerCobranza : Form
    {
        public frmVerCobranza()
        {
            InitializeComponent();
        }

        private void frmVerCobranza_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crCobranza cargarReporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            //IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from cobranza('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (fecha timestamp without time zone, id_cliente character varying(8), nombre_cliente character varying(255), nro_comprobante character varying(20), mp_cheque double precision, mp_efectivo double precision, mp_tarjeta_de_credito double precision, mp_tarjeta_de_debito double precision, mp_deposito_bancario double precision, total double precision, mp_retencion double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsCobranza dsLista = new dsCobranza();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crCobranza rptLista = new crCobranza();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtCobranza");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Cobranza del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
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

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
    public partial class frmVerLibroIvaVentas : Form
    {
        public frmVerLibroIvaVentas()
        {
            InitializeComponent();
        }

        private void frmVerLibroIvaVentas_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crLibroIvaVentas cargarReporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            //IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from libroivaventas('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (fecha timestamp without time zone, tipo_comprobante character varying(255), cod_comprobante character varying(25), nombre_cliente character varying(255), cuit_cliente character varying(13), neto_gravado double precision, neto_no_gravado double precision, iva double precision, iva_105 double precision, total double precision, desc_iva character varying(25))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsLibroIvaVentas dsLista = new dsLibroIvaVentas();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crLibroIvaVentas rptLista = new crLibroIvaVentas();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Libro de Iva Ventas del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_cf('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtConsumidorFinal");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_ex('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtExento");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_mo('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtMonotributista");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_nc('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtNoCategorizado");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_ri('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtResponsableInscripto");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivaventas_resumen_rni('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (gravado double precision, exento double precision, iva21 double precision, iva105 double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtResponsableNoInscripto");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;
        }
    }
}

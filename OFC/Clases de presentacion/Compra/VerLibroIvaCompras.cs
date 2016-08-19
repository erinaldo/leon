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
    public partial class frmVerLibroIvaCompras : Form
    {
        public frmVerLibroIvaCompras()
        {
            InitializeComponent();
        }

        private void VerLibroIvaCompras_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crLibroIvaCompras cargarReporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from libroivacompras('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (fecha date, tipo_comprobante character varying(255), cod_comprobante character varying(25), nombre_proveedor character varying(255), cuit_proveedor character varying(13), neto_gravado double precision, neto_no_gravado double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision, desc_iva character varying(25))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsLibroIvaCompras dsLista = new dsLibroIvaCompras();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crLibroIvaCompras rptLista = new crLibroIvaCompras();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDetalle");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            //dsLista.Tables[dtDetalle].Columns[i].ColumnName
            //System.IO.File.WriteAllLines(

            cmComando.CommandText = "select 'Libro de Iva Compras del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_cf('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtConsumidorFinal");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_ex('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtExento");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_mo('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtMonotributista");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_nc('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtNoCategorizado");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_ri('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtResponsableInscripto");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from libroivacompras_resumen_rni('" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (gravado double precision, exento double precision, iva27 double precision, iva21 double precision, iva105 double precision, otros_impuestos double precision, total double precision)";
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

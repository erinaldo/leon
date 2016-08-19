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
    public partial class frmVerSaldoTotal : Form
    {
        public frmVerSaldoTotal()
        {
            InitializeComponent();
        }

        private void frmVerSaldoTotal_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crSaldoTotal cargarReporte(DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from saldostotalesporfechacliente('" + fechaHasta.AddDays(1).ToShortDateString() + "') as (cod_cliente character varying(8), nombre_cliente character varying(255), saldo_positivo double precision, saldo_negativo double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsSaldoTotal dsLista = new dsSaldoTotal();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crSaldoTotal rptLista = new crSaldoTotal();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtSaldoTotal");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            //sumo los saldos negativos y positivos
            decimal saldo_total = decimal.Zero;
            foreach (DataRow dtRowDetalle in dsLista.dtSaldoTotal.Rows)
            {
                saldo_total += decimal.Parse(dtRowDetalle["saldo_positivo"].ToString());
                saldo_total += decimal.Parse(dtRowDetalle["saldo_negativo"].ToString());
            }

            ////////////////////////////////////////
            //descripcion y saldo total
            cmComando.CommandText = "select 'Listado de Saldos al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion, " + saldo_total + " as saldo_total";
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

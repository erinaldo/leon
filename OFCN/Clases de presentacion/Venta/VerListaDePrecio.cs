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
    public partial class frmReporteListaDePrecio : Form
    {
        public frmReporteListaDePrecio()
        {
            InitializeComponent();
        }

        private void frmVerListaDePrecio_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crListaDePrecio cargarReporte(long idLista)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            //IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from lista_de_precio(" + idLista.ToString() + ") as (codigo character varying(20), producto character varying(255), medida character varying(255), trabajo character varying(255), precio double precision, iva double precision, precio_final double precision)";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsListaDePrecio dsLista = new dsListaDePrecio();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crListaDePrecio rptLista = new crListaDePrecio();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtListaDePrecio");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Lista de Precio ' || valor descripcion from ofc_tabla_valor where id = " + idLista.ToString();
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtNombreLista");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }
    }
}

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
    public partial class frmVerStock : Form
    {
        public frmVerStock()
        {
            InitializeComponent();
        }

        private void frmVerStock_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crStock cargarReporte()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();

            cmComando.Connection = cn;
            cmComando.CommandText = "select * from stock() as (nro_orden bigint, nro_renglon integer, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), nro_serie character varying(255), trabajo character varying(255), nro_interno bigint, servicio_adicional character varying(255), fecha timestamp without time zone, cod_cliente character varying(8))";
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            dsStock dsLista = new dsStock();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crStock rptLista = new crStock();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtStock");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

        public crStock cargarReporte(FiltrosOrden filtro)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            string cadenaCliente = string.Empty;

            cmComando.Connection = cn;
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            if (filtro.FiltroCodCliente != "" && filtro.FiltroNroOrden == "")
            {
                cmComando.CommandText = "select * from stockcliente('%" + filtro.FiltroCodCliente + "%') as (nro_orden bigint, nro_renglon integer, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), nro_serie character varying(255), trabajo character varying(255), nro_interno bigint, servicio_adicional character varying(255), fecha timestamp without time zone, cod_cliente character varying(8))";
                cadenaCliente = "select id cod_cliente, nombre nombre_cliente from ofc_cliente where id = '" + filtro.FiltroCodCliente  + "' and activo = 'S'";
            }

            if (filtro.FiltroNroOrden != "" && filtro.FiltroCodCliente == "")
            {
                cmComando.CommandText = "select * from stockorden(" + filtro.FiltroNroOrden + ") as (nro_orden bigint, nro_renglon integer, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), nro_serie character varying(255), trabajo character varying(255), nro_interno bigint, servicio_adicional character varying(255), fecha timestamp without time zone, cod_cliente character varying(8))";
                cadenaCliente = "select cliente.id cod_cliente, cliente.nombre nombre_cliente from ofc_cliente cliente, ofc_orden_de_trabajo ord where cliente.id = ord.id_cliente and cliente.activo = 'S' and ord.id = " + filtro.FiltroNroOrden;
            }

            if (filtro.FiltroCodCliente != "" && filtro.FiltroNroOrden != "")
            {
                cmComando.CommandText = "select * from stockclienteorden('%" + filtro.FiltroCodCliente + "%'," + filtro.FiltroNroOrden + ") as (nro_orden bigint, nro_renglon integer, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), nro_serie character varying(255), trabajo character varying(255), nro_interno bigint, servicio_adicional character varying(255), fecha timestamp without time zone, cod_cliente character varying(8))";
                cadenaCliente = "select id cod_cliente, nombre nombre_cliente from ofc_cliente where id = '" + filtro.FiltroCodCliente + "' and activo = 'S'";
            }

            dsStock dsLista = new dsStock();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crStock rptLista = new crStock();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtStock");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = cadenaCliente;
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosCliente");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }

    }
}

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
    public partial class frmVerHistoricoDeCubiertas : Form
    {
        public frmVerHistoricoDeCubiertas()
        {
            InitializeComponent();
        }

        private void frmVerHistoricoDeCubiertas_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crHistoricoDeCubiertas cargarReporte(FiltrosABMCliente filtro, DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            //string cadenaCliente = string.Empty;

            cmComando.Connection = cn;
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            if (filtro.FiltroCodigo != "" && filtro.FiltroNroOrden == -1 && filtro.FiltroMedidaCubierta == -1)
            {
                cmComando.CommandText = "select * from historicodecubiertas('" + filtro.FiltroCodigo + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (fecha_orden timestamp without time zone, id_orden bigint, renglon int, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, servicio_adicional character varying(255), cod_comprobante_factura character varying(255), fecha_factura timestamp without time zone, nombre_cliente character varying(255), id_cliente character varying(8))";
                //cadenaCliente = "select id cod_cliente, nombre nombre_cliente from ofc_cliente where id = '" + filtro.FiltroCodigo + "' and activo = 'S'";
            }

            if (filtro.FiltroCodigo != "" && filtro.FiltroNroOrden != -1 && filtro.FiltroMedidaCubierta == -1)
            {
                cmComando.CommandText = "select * from historicodecubiertasorden('" + filtro.FiltroCodigo + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "'," + filtro.FiltroNroOrden + ") as (fecha_orden timestamp without time zone, id_orden bigint, renglon int, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, servicio_adicional character varying(255), cod_comprobante_factura character varying(255), fecha_factura timestamp without time zone, nombre_cliente character varying(255), id_cliente character varying(8))";
                //cadenaCliente = "select cliente.id cod_cliente, cliente.nombre nombre_cliente from ofc_cliente cliente, ofc_orden_de_trabajo ord where cliente.id = ord.id_cliente and cliente.activo = 'S' and ord.id = " + filtro.FiltroNroOrden;
            }

            if (filtro.FiltroCodigo != "" && filtro.FiltroNroOrden == -1 && filtro.FiltroMedidaCubierta != -1)
            {
                cmComando.CommandText = "select * from historicodecubiertas('" + filtro.FiltroCodigo + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "'," + filtro.FiltroMedidaCubierta + ") as (fecha_orden timestamp without time zone, id_orden bigint, renglon int, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, servicio_adicional character varying(255), cod_comprobante_factura character varying(255), fecha_factura timestamp without time zone, nombre_cliente character varying(255), id_cliente character varying(8))";
                //cadenaCliente = "select id cod_cliente, nombre nombre_cliente from ofc_cliente where id = '" + filtro.FiltroCodCliente + "' and activo = 'S'";
            }

            if (filtro.FiltroCodigo != "" && filtro.FiltroNroOrden != -1 && filtro.FiltroMedidaCubierta != -1)
            {
                cmComando.CommandText = "select * from historicodecubiertas('" + filtro.FiltroCodigo + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "'," + filtro.FiltroMedidaCubierta + "," + filtro.FiltroNroOrden + ") as (fecha_orden timestamp without time zone, id_orden bigint, renglon int, coche character varying(255), medida_cubierta character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, servicio_adicional character varying(255), cod_comprobante_factura character varying(255), fecha_factura timestamp without time zone, nombre_cliente character varying(255), id_cliente character varying(8))";
                //cadenaCliente = "select id cod_cliente, nombre nombre_cliente from ofc_cliente where id = '" + filtro.FiltroCodCliente + "' and activo = 'S'";
            }

            dsHistoricoDeCubiertas dsLista = new dsHistoricoDeCubiertas();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crHistoricoDeCubiertas rptLista = new crHistoricoDeCubiertas();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtHistoricoDeCubiertas");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            //cmComando.CommandText = cadenaCliente;
            //data.SelectCommand = cmComando;
            //data.Fill(dsLista, "dtDatosCliente");
            //rptLista.SetDataSource(dsLista);
            //data.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }
    }
}

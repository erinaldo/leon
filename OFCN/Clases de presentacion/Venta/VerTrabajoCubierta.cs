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
    public partial class frmVerTrabajoCubierta : Form
    {
        public frmVerTrabajoCubierta()
        {
            InitializeComponent();
        }

        private void frmVerTrabajoCubierta_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crTrabajoCubierta cargarReporte(FiltrosOrden filtro)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            string cadena = string.Empty;

            cmComando.Connection = cn;
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            if (filtro.FiltroTrabajo != -1 && filtro.FiltroMedida == -1)
            {
                cmComando.CommandText = "select * from trabajocubiertas2(" + filtro.FiltroTrabajo + ") as (fecha timestamp without time zone, idCliente character varying(8), nombreCliente character varying(255), idOrden bigint, renglon integer, coche character varying(255), medida character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, adicional character varying(255))";
                cadena = "select 'NEUMATICOS CON TRABAJO ' || descripcion descripcion from ofc_servicio where id = " + filtro.FiltroTrabajo;
            }

            if (filtro.FiltroTrabajo == -1 && filtro.FiltroMedida != -1)
            {
                cmComando.CommandText = "select * from trabajocubiertas1(" + filtro.FiltroMedida + ") as (fecha timestamp without time zone, idCliente character varying(8), nombreCliente character varying(255), idOrden bigint, renglon integer, coche character varying(255), medida character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, adicional character varying(255))";
                cadena = "select 'NEUMATICOS CON MEDIDA ' || medida_cubierta descripcion from ofc_producto where id = " + filtro.FiltroMedida;
            }

            if (filtro.FiltroTrabajo != -1 && filtro.FiltroMedida != -1)
            {
                cmComando.CommandText = "select * from trabajocubiertas3(" + filtro.FiltroMedida + "," + filtro.FiltroTrabajo + ") as (fecha timestamp without time zone, idCliente character varying(8), nombreCliente character varying(255), idOrden bigint, renglon integer, coche character varying(255), medida character varying(255), marca character varying(255), serie character varying(255), trabajo character varying(255), interno bigint, adicional character varying(255))";
                cadena = "select 'NEUMATICOS' descripcion";
            }

            dsTrabajoCubierta dsLista = new dsTrabajoCubierta();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crTrabajoCubierta rptLista = new crTrabajoCubierta();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtTrabajoCubierta");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = cadena;
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

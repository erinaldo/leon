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
    public partial class frmVerResumenDeCuentaProv : Form
    {
        public frmVerResumenDeCuentaProv()
        {
            InitializeComponent();
        }

        private void frmVerResumenDeCuentaProv_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crResumenDeCuentaProveedor cargarReporte(string codProveedor, DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            string cadenaProveedor = string.Empty;

            cmComando.Connection = cn;
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            if (codProveedor != "")
            {
                cmComando.CommandText = "select * from resumendecuentaproveedor('" + codProveedor + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.ToShortDateString() + "') as (fecha date, comprobante character varying(255), nro_comprobante character varying(255), debe double precision, haber double precision, saldo double precision)";
                cadenaProveedor = "select proveedor.id cod_proveedor, proveedor.nombre nombre_proveedor, cuenta.saldo * (-1) saldo from cpc_proveedor proveedor, cpc_cuenta_corriente cuenta where proveedor.id = cuenta.id_proveedor and cuenta.activo = 'S' and proveedor.id = '" + codProveedor + "' and proveedor.activo = 'S'";
            }

            dsResumenDeCuenta dsLista = new dsResumenDeCuenta();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crResumenDeCuentaProveedor rptLista = new crResumenDeCuentaProveedor();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtMovimientos");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = cadenaProveedor;
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosProveedor");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from datosempresa('" + BaseDeDatos.empresa + "') as (razon_social character varying(255), domicilio character varying(255), localidad character varying(255), provincia character varying(255), telefono_1 character varying(255), web character varying(255), cp character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosEmpresa");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Resumen de Cuenta del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            dsLista.Dispose();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }
    }
}

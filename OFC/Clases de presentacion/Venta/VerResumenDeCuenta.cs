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
    public partial class frmVerResumenDeCuenta : Form
    {
        public frmVerResumenDeCuenta()
        {
            InitializeComponent();
        }

        private void frmVerResumenDeCuenta_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1376, 762);
            if (Resolucion.Escalar())
            {
                Resolucion _ajusteResolucion = new Resolucion();
                _ajusteResolucion.ResizeForm(this, 1376, 762);
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 1, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }

        public crResumenDeCuenta cargarReporte(string codCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            NpgsqlCommand cmComando = new NpgsqlCommand();
            string cadenaCliente = string.Empty;

            cmComando.Connection = cn;
            cmComando.CommandType = CommandType.Text;
            cmComando.CommandTimeout = 0;

            if (codCliente != "")
            {
                cmComando.CommandText = "select * from resumendecuenta('" + codCliente + "', '" + fechaDesde.ToShortDateString() + "', '" + fechaHasta.AddDays(1).ToShortDateString() + "') as (fecha timestamp without time zone, comprobante character varying(255), nro_comprobante character varying(255), debe double precision, haber double precision, saldo double precision)";
                cadenaCliente = "select cliente.id cod_cliente, cliente.nombre nombre_cliente, cuenta.saldo * (-1) saldo from ofc_cliente cliente, ofc_cuenta_corriente cuenta where cliente.id = cuenta.id_cliente and cuenta.activo = 'S' and cliente.id = '" + codCliente + "' and cliente.activo = 'S'";
            }

            dsResumenDeCuenta dsLista = new dsResumenDeCuenta();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter();
            crResumenDeCuenta rptLista = new crResumenDeCuenta();

            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtMovimientos");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = cadenaCliente;
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosCliente");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select 'Resumen de Cuenta del " + String.Format("{0:d/M/yyyy}", fechaDesde.Date) + " al " + String.Format("{0:d/M/yyyy}", fechaHasta.Date) + "' as descripcion";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDescripcion");
            rptLista.SetDataSource(dsLista);
            data.Dispose();

            cmComando.CommandText = "select * from datosempresa('" + BaseDeDatos.empresa + "') as (razon_social character varying(255), domicilio character varying(255), localidad character varying(255), provincia character varying(255), telefono_1 character varying(255), web character varying(255), cp character varying(255))";
            data.SelectCommand = cmComando;
            data.Fill(dsLista, "dtDatosEmpresa");
            rptLista.SetDataSource(dsLista);
            data.Dispose();
            
            dsLista.Dispose();
            
            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return rptLista;

        }
    }
}

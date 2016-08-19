using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OFC
{
    public partial class frmLibroIvaCompras : Form
    {
        public frmLibroIvaCompras()
        {
            InitializeComponent();
        }

        private void frmLibroIvaCompras_Load(object sender, EventArgs e)
        {
            int dias_transcurridos = System.DateTime.Now.Day * (-1);
            this.dtpFechaDesde.Value = System.DateTime.Now.AddDays(dias_transcurridos + 1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerLibroIvaCompras frmReporte = new frmVerLibroIvaCompras();
                crLibroIvaCompras rptLista = frmReporte.cargarReporte(dtpFechaDesde.Value, dtpFechaHasta.Value);
                frmReporte.crvLibroIvaCompras.ReportSource = rptLista;
                frmReporte.ShowDialog();
                rptLista.Dispose();
                frmReporte.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Reporte Libro Iva Compras");
            }
        }

        private void btnDescargarCompleto_Click(object sender, EventArgs e)
        {
            frmProcesandoPeticion formProcesamiento = new frmProcesandoPeticion();
            formProcesamiento.Show();

            try
            {
                string fechaFormateada = DateTime.Now.Year.ToString("D2")
                    + DateTime.Now.Month.ToString("D2")
                    + DateTime.Now.Day.ToString("D2")
                    + DateTime.Now.Hour.ToString("D2")
                    + DateTime.Now.Minute.ToString("D2")
                    + DateTime.Now.Second.ToString("D2");
                string nombre_archivo = ParametroDTO.obtenerParametroIII("NOMBRE_LIBRO_IVA_COMPRA") + fechaFormateada;
                string path = ParametroDTO.obtenerParametroIII("PATH_LIBRO_IVA_COMPRA");
                string path_completo = path + nombre_archivo;

                DataSet dsLibroIvaCompras = LibroIvaComprasDTO.generarEstructura("dtDetalle");
                LibroIvaComprasDTO.cargarDatos(dsLibroIvaCompras, dtpFechaDesde.Value, dtpFechaHasta.Value);
                GenerarArchivo.generar_archivo_csv(dsLibroIvaCompras, path_completo, "dtDetalle");

                formProcesamiento.Dispose();

                MessageBox.Show("La operación fue realizada con éxito. \nSe generó el archivo " + nombre_archivo + ".csv en el directorio " + path + ".", "Libro Iva Compras");
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                formProcesamiento.Dispose();
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                MessageBox.Show(ex.Message + ' ' + inner, "Archivo Libro Iva Compras detallado");
            }
        }
    }
}

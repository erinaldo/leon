using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace OFC
{
    class LibroIvaComprasDTO
    {
        long id_tipo_comprobante;
        string cod_comprobante;
        string id_proveedor;
        string nombre_proveedor;
        string cuit_proveedor;
        decimal neto_gravado;
	    decimal neto_no_gravado;
        decimal iva_27;
	    decimal iva_21;
	    decimal iva_105;
	    decimal impuestos;
        decimal total;
        DateTime fecha;
        string desc_categoria_iva;
        DateTime fecha_contable;
        decimal redondeo;

        public LibroIvaComprasDTO()
        {
            id_tipo_comprobante = -1;
            cod_comprobante = string.Empty;
            id_proveedor = string.Empty;
            nombre_proveedor = string.Empty;
            cuit_proveedor = string.Empty;
            neto_gravado = decimal.Zero;
            neto_no_gravado = decimal.Zero;
            iva_27 = decimal.Zero;
	        iva_21 = decimal.Zero;
	        iva_105 = decimal.Zero;
	        impuestos = decimal.Zero;
            total = decimal.Zero;
            fecha = DateTime.Now;
            desc_categoria_iva = string.Empty;
            fecha_contable = DateTime.Now;
            redondeo = decimal.Zero;
        }

        public LibroIvaComprasDTO(FacturaDeCompraDTO f, long idTipoComprobante, char anula)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = f.Cod_comprobante;
            id_proveedor = f.Id_proveedor;
            nombre_proveedor = f.Nombre_proveedor;
            cuit_proveedor = f.Cuit_proveedor;
            
            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                neto_no_gravado = decimal.Zero;
                iva_27 = decimal.Zero;
                iva_21 = decimal.Zero;
                iva_105 = decimal.Zero;
                impuestos = decimal.Zero;
                total = decimal.Zero;
            }

            if (anula == 'N')
            {
                neto_gravado = f.Subtotal_neto;
                neto_no_gravado = f.Subtotal_neto_exento;
		        iva_27 = FacturaDeCompraDTO.obtenerImporteIva27(f.Id);
                iva_21 = FacturaDeCompraDTO.obtenerImporteIva21(f.Id);
                iva_105 = FacturaDeCompraDTO.obtenerImporteIva105(f.Id);
                impuestos = f.Impuestos;
                redondeo = f.Redondeo;
                total = f.Total;
            }

            fecha = f.Fecha_comprobante;
            desc_categoria_iva = f.Categoria_iva;
            fecha_contable = f.Fecha_contable;
        }

        public LibroIvaComprasDTO(NotaDeCreditoDeCompraDTO n, long idTipoComprobante, char anula)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = n.Cod_comprobante;
            id_proveedor = n.Id_proveedor;
            nombre_proveedor = n.Nombre_proveedor;
            cuit_proveedor = n.Cuit_proveedor;

            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                neto_no_gravado = decimal.Zero;
                iva_27 = decimal.Zero;
                iva_21 = decimal.Zero;
                iva_105 = decimal.Zero;
                impuestos = decimal.Zero;
                total = decimal.Zero;
            }

            if (anula == 'N')
            {
                neto_gravado = n.Subtotal_neto * (-1);
                neto_no_gravado = n.Subtotal_neto_exento * (-1);
                iva_27 = NotaDeCreditoDeCompraDTO.obtenerImporteIva27(n.Id) * (-1);
                iva_21 = NotaDeCreditoDeCompraDTO.obtenerImporteIva21(n.Id) * (-1);
                iva_105 = NotaDeCreditoDeCompraDTO.obtenerImporteIva105(n.Id) * (-1);
                impuestos = (n.Impuestos) * (-1);
                redondeo = (n.Redondeo) * (-1);
                total = n.Total;
            }

            fecha = n.Fecha_comprobante;
            desc_categoria_iva = n.Categoria_iva;
            fecha_contable = n.Fecha_contable;
        }

        public LibroIvaComprasDTO(NotaDeDebitoDeCompraDTO d, long idTipoComprobante, char anula)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = d.Cod_comprobante;
            id_proveedor = d.Id_proveedor;
            nombre_proveedor = d.Nombre_proveedor;
            cuit_proveedor = d.Cuit_proveedor;

            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                neto_no_gravado = decimal.Zero;
                iva_27 = decimal.Zero;
                iva_21 = decimal.Zero;
                iva_105 = decimal.Zero;
                impuestos = decimal.Zero;
                total = decimal.Zero;
            }

            if (anula == 'N')
            {
                neto_gravado = d.Subtotal_neto;
                neto_no_gravado = d.Subtotal_neto_exento;
                iva_27 = NotaDeDebitoDeCompraDTO.obtenerImporteIva27(d.Id);
                iva_21 = NotaDeDebitoDeCompraDTO.obtenerImporteIva21(d.Id);
                iva_105 = NotaDeDebitoDeCompraDTO.obtenerImporteIva105(d.Id);
                impuestos = d.Impuestos;
                redondeo = d.Redondeo;
                total = d.Total;
            }

            fecha = d.Fecha_comprobante;
            desc_categoria_iva = d.Categoria_iva;
            fecha_contable = d.Fecha_contable;
        }

        public void registrar()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_libro_iva_compras(id, id_tipo_comprobante, cod_comprobante, id_proveedor, nombre_proveedor, cuit_proveedor, neto_gravado, neto_no_gravado, iva_27, iva_21, iva_105, impuestos, total, fecha, desc_categoria_iva, fecha_contable, redondeo) VALUES (nextval('cpc_libro_iva_compras_id_seq'), @id_tipo_comprobante, @cod_comprobante, @id_proveedor, @nombre_proveedor, @cuit_proveedor, @neto_gravado, @neto_no_gravado, @iva27, @iva21, @iva105, @impuestos, @total, @fecha, @desc_categoria_iva, @fecha_contable, @redondeo);";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));
            parameters.Add(new NpgsqlParameter("nombre_proveedor", nombre_proveedor));
            parameters.Add(new NpgsqlParameter("cuit_proveedor", cuit_proveedor));
            parameters.Add(new NpgsqlParameter("neto_gravado", neto_gravado));
            parameters.Add(new NpgsqlParameter("neto_no_gravado", neto_no_gravado));
            parameters.Add(new NpgsqlParameter("iva27", iva_27));
            parameters.Add(new NpgsqlParameter("iva21", iva_21));
            parameters.Add(new NpgsqlParameter("iva105", iva_105));
            parameters.Add(new NpgsqlParameter("impuestos", impuestos));
            parameters.Add(new NpgsqlParameter("total", total));
            parameters.Add(new NpgsqlParameter("fecha", fecha));
            parameters.Add(new NpgsqlParameter("desc_categoria_iva", desc_categoria_iva));
            parameters.Add(new NpgsqlParameter("fecha_contable", fecha_contable));
            parameters.Add(new NpgsqlParameter("redondeo", redondeo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public void actualizarImportes()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE cpc_libro_iva_compras set neto_gravado = @neto_gravado, neto_no_gravado = @neto_no_gravado, iva_27 = @iva27, iva_21 = @iva21, iva_105 = @iva105, impuestos = @impuestos, redondeo = @redondeo where id_tipo_comprobante = @id_tipo_comprobante and cod_comprobante = @cod_comprobante and id_proveedor = @id_proveedor;";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));
            parameters.Add(new NpgsqlParameter("neto_gravado", neto_gravado));
            parameters.Add(new NpgsqlParameter("neto_no_gravado", neto_no_gravado));
            parameters.Add(new NpgsqlParameter("iva27", iva_27));
            parameters.Add(new NpgsqlParameter("iva21", iva_21));
            parameters.Add(new NpgsqlParameter("iva105", iva_105));
            parameters.Add(new NpgsqlParameter("impuestos", impuestos));
            parameters.Add(new NpgsqlParameter("redondeo", redondeo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        private static List<string> obtenerColumnas()
        {
            List<string> columnas = new List<string>();
            
            string[] columna = new string[11] { "FECHA", 
                "TIPO_COMPROBANTE", 
                "COD_COMPROBANTE", 
                "PROVEEDOR", 
                "CUIT", 
                "CATEGORIA_IVA", 
                "NETO_GRAVADO", 
                "NETO_NO_GRAVADO", 
                "IVA_27", 
                "IVA_21", 
                "IVA_10.5"};

            //agrega las principales
            for (int i = 0; i < 11; i++)
            {
                columnas.Add(columna[i]);
            }

            //agrego la de impuestos
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select valor from ofc_tabla_valor where id_tabla = 'XC' and vigente = 'S'";
            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            while (data != null && data.Read())
            {
                string columnasDeImpuesto;
                columnasDeImpuesto = data["valor"].ToString();
                columnas.Add(columnasDeImpuesto);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            columnas.Add("REDONDEO");
            //agrego el total
            columnas.Add("TOTAL");

            return columnas;
        }

        public static DataSet generarEstructura(string nombreDeTabla)
        {
            DataSet dsLic = new DataSet("dsLic");
            DataTable dtDetalle = dsLic.Tables.Add(nombreDeTabla);

            List<string> columnas = obtenerColumnas();

            foreach (string columna in columnas)
            {
                DataColumn newColumn = new DataColumn(columna, typeof(string));
                newColumn.DefaultValue = "0.00";
                dtDetalle.Columns.Add(newColumn);
            }

            return dsLic;
        }

        public static void cargarDatos(DataSet dsLibroIvaCompras, DateTime fechaDesde, DateTime fechaHasta)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select a.fecha fecha, a.id_tipo_comprobante id_tipo_comprobante, b.valor_adicional tipo_comprobante, a.cod_comprobante cod_comprobante, a.id_proveedor cod_proveedor, a.nombre_proveedor proveedor, a.cuit_proveedor cuit, a.neto_gravado neto_gravado, a.neto_no_gravado neto_no_gravado, a.iva_27 iva_27, a.iva_21 iva_21, a.iva_105 iva_105, a.total total, a.desc_categoria_iva categoria_iva, a.redondeo redondeo"
            + " from cpc_libro_iva_compras a, ofc_tabla_valor b"
            + " where a.id_tipo_comprobante = b.id"
            + " and b.id_tabla = 'TC'"
            + " and a.fecha_contable >= @fechaDesde"
            + " and a.fecha_contable <= @fechaHasta"
            + " order by a.fecha, a.id";

            parameters.Add(new NpgsqlParameter("fechaDesde", fechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", fechaHasta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                DataRow _row = dsLibroIvaCompras.Tables["dtDetalle"].NewRow();

                _row["FECHA"] = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(data["fecha"].ToString()));
                _row["TIPO_COMPROBANTE"] = data["tipo_comprobante"].ToString();
                _row["COD_COMPROBANTE"] = data["cod_comprobante"].ToString();
                _row["PROVEEDOR"] = data["proveedor"].ToString();
                _row["CUIT"] = data["cuit"].ToString();
                _row["CATEGORIA_IVA"] = data["categoria_iva"].ToString();
                _row["NETO_GRAVADO"] = String.Format("{0:0.00}", decimal.Parse(data["neto_gravado"].ToString()));
                _row["NETO_NO_GRAVADO"] = String.Format("{0:0.00}",decimal.Parse(data["neto_no_gravado"].ToString()));
                _row["IVA_27"] = String.Format("{0:0.00}",decimal.Parse(data["iva_27"].ToString()));
                _row["IVA_21"] = String.Format("{0:0.00}",decimal.Parse(data["iva_21"].ToString()));
                _row["IVA_10.5"] = String.Format("{0:0.00}",decimal.Parse(data["iva_105"].ToString()));
                _row["REDONDEO"] = String.Format("{0:0.00}", decimal.Parse(data["redondeo"].ToString()));
                _row["TOTAL"] = String.Format("{0:0.00}",decimal.Parse(data["total"].ToString()));
                
                List<ImpuestoDetalleDTO> impuestos = obtenerImpuestos(data["cod_comprobante"].ToString(), data["cod_proveedor"].ToString(), long.Parse(data["id_tipo_comprobante"].ToString()));
                if (impuestos != null && impuestos.Count != 0)
                {
                    foreach (ImpuestoDetalleDTO imp in impuestos)
                    {
                        _row[imp.Desc_impuesto] = imp.V_importe;
                    }
                }
                
                dsLibroIvaCompras.Tables["dtDetalle"].Rows.Add(_row);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        private static List<ImpuestoDetalleDTO> obtenerImpuestos(string cod_comprobante, string cod_proveedor, long id_tipo_comprobante)
        {
            List<ImpuestoDetalleDTO> listaDeImpuestos = null;

            if (ValorDTO.obtenerValor(id_tipo_comprobante).Contains("FACTURA"))
            {
                listaDeImpuestos = ImpuestoDetalleDTO.obtenerImpuestosReg(ComprobanteCompraDTO.obtenerIdOrigen(cod_comprobante, cod_proveedor, id_tipo_comprobante), "FA");
            }
            if (ValorDTO.obtenerValor(id_tipo_comprobante).Contains("DEBITO"))
            {
                listaDeImpuestos = ImpuestoDetalleDTO.obtenerImpuestosReg(ComprobanteCompraDTO.obtenerIdOrigen(cod_comprobante, cod_proveedor, id_tipo_comprobante), "ND");
            }
            if (ValorDTO.obtenerValor(id_tipo_comprobante).Contains("CREDITO"))
            {
                listaDeImpuestos = ImpuestoDetalleDTO.obtenerImpuestosReg(ComprobanteCompraDTO.obtenerIdOrigen(cod_comprobante, cod_proveedor, id_tipo_comprobante), "NC");
            }

            return listaDeImpuestos;
        }

    }
}

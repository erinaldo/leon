using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ComprobanteCompraDTO
    {
        long id_tipo_comprobante;

        public long Id_tipo_comprobante
        {
            get { return id_tipo_comprobante; }
            set { id_tipo_comprobante = value; }
        }

        string tipo_comprobante;

        public string Tipo_comprobante
        {
            get { return tipo_comprobante; }
            set { tipo_comprobante = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        string v_fecha;

        public string V_fecha
        {
            get { return v_fecha; }
            set { v_fecha = value; }
        }

        long id_origen;

        public long Id_origen
        {
            get { return id_origen; }
            set { id_origen = value; }
        }

        string cod_comprobante;

        public string Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        string id_proveedor;

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        char anulado;

        public char Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        DateTime fecha_contable;

        public DateTime Fecha_contable
        {
            get { return fecha_contable; }
            set { fecha_contable = value; }
        }

        char incompleto;

        public char Incompleto
        {
            get { return incompleto; }
            set { incompleto = value; }
        }

        string v_fecha_contable;

        public string V_fecha_contable
        {
            get { return v_fecha_contable; }
            set { v_fecha_contable = value; }
        }

        public ComprobanteCompraDTO()
        {
            id_tipo_comprobante = -1;
            fecha_creacion = DateTime.Now;
            v_fecha = String.Empty;
            id_origen = -1;
            cod_comprobante = String.Empty;
            id_proveedor = String.Empty;
            tipo_comprobante = String.Empty;
            anulado = 'N';
            fecha_contable = DateTime.Now;
            incompleto = 'N';
            v_fecha_contable = String.Empty;
        }

        public static void insertar(string tipo, FacturaDeCompraDTO dataFact)
        {
            long idTipoComprobante = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            string sql = "INSERT INTO cpc_comprobante(";
            sql = sql + "id_tipo_comprobante, fecha_creacion, id_origen, cod_comprobante, anulado, id_proveedor, fecha_contable, incompleto)";
            sql = sql + " VALUES (@idTipoComprobante, @fechaComprobante, @idOrigen, @comprobante, 'N', @idProveedor, @fechaContable, @incompleto);";

            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataFact.Fecha_comprobante));
            parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
            parameters.Add(new NpgsqlParameter("comprobante", dataFact.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("idProveedor", dataFact.Id_proveedor));
            parameters.Add(new NpgsqlParameter("fechaContable", dataFact.Fecha_contable));
            if (dataFact.Es_definitiva == 'S')
            {
                parameters.Add(new NpgsqlParameter("incompleto", 'N'));
            }
            else
            {
                parameters.Add(new NpgsqlParameter("incompleto", 'S'));
            }

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertar(string tipo, NotaDeCreditoDeCompraDTO dataCred)
        {
            long idTipoComprobante = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            string sql = "INSERT INTO cpc_comprobante(";
            sql = sql + "id_tipo_comprobante, fecha_creacion, id_origen, cod_comprobante, anulado, id_proveedor, fecha_contable, incompleto)";
            sql = sql + " VALUES (@idTipoComprobante, @fechaComprobante, @idOrigen, @comprobante, 'N', @idProveedor, @fechaContable, 'N');";

            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataCred.Fecha_comprobante));
            parameters.Add(new NpgsqlParameter("idOrigen", dataCred.Id));
            parameters.Add(new NpgsqlParameter("comprobante", dataCred.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("idProveedor", dataCred.Id_proveedor));
            parameters.Add(new NpgsqlParameter("fechaContable", dataCred.Fecha_contable));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertar(string tipo, NotaDeDebitoDeCompraDTO dataDeb)
        {
            long idTipoComprobante = -1;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            string sql = "INSERT INTO cpc_comprobante(";
            sql = sql + "id_tipo_comprobante, fecha_creacion, id_origen, cod_comprobante, anulado, id_proveedor, fecha_contable, incompleto)";
            sql = sql + " VALUES (@idTipoComprobante, @fechaComprobante, @idOrigen, @comprobante, 'N', @idProveedor, @fechaContable, 'N');";

            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataDeb.Fecha_comprobante));
            parameters.Add(new NpgsqlParameter("idOrigen", dataDeb.Id));
            parameters.Add(new NpgsqlParameter("comprobante", dataDeb.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("idProveedor", dataDeb.Id_proveedor));
            parameters.Add(new NpgsqlParameter("fechaContable", dataDeb.Fecha_contable));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static string insertar(string tipo, PagoDTO dataPago)
        {
            long idTipoComprobante = -1;
            string cod_comprobante = "-1";
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            idTipoComprobante = ValorDTO.obtenerId(tipo);
            cod_comprobante = ComprobanteCompraDTO.converToNroOrdenDePago(dataPago.Nro_pago);

            string sql = "INSERT INTO cpc_comprobante(";
            sql = sql + "id_tipo_comprobante, fecha_creacion, id_origen, cod_comprobante, anulado, id_proveedor, fecha_contable, incompleto)";
            sql = sql + " VALUES (@idTipoComprobante, @fechaComprobante, @idOrigen, @comprobante, 'N', @idProveedor, @fechaComprobante, 'N');";

            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaComprobante", dataPago.Fecha_comprobante));
            parameters.Add(new NpgsqlParameter("idOrigen", dataPago.Id));
            parameters.Add(new NpgsqlParameter("comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("idProveedor", dataPago.Id_proveedor));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cod_comprobante;
        }

        public static string converToNroOrdenDePago(string numero)
        {
            string descripcionParam = "DIGITOS NRO ORDEN DE PAGO";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO ORDEN DE PAGO";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO ORDEN DE PAGO";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        public static string obtenerCodProveedor(long id_tipo_comprobante, string cod_comprobante)
        {
            string idProveedor = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_proveedor idProveedor from cpc_comprobante comp where comp.id_tipo_comprobante = @id_tipo_comprobante and comp.cod_comprobante = @cod_comprobante";
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idProveedor = data["idProveedor"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idProveedor;
        }

        public static List<ComprobanteCompraDTO> obtenerComprobantes(FiltrosABMProveedor filtro)
        {

            List<ComprobanteCompraDTO> lista = new List<ComprobanteCompraDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.fecha_creacion fecha, a.id_proveedor cod_proveedor, b.id id_tipo_comprobante, b.valor tipo_comprobante,"
            + " a.cod_comprobante cod_comprobante, a.id_origen id_origen, a.anulado anulado, a.fecha_contable fecha_contable"
            + " from cpc_comprobante a, ofc_tabla_valor b"
            + " where a.id_tipo_comprobante = b.id"
            + " and b.id_tabla = 'TC'"
            + " and a.id_origen != -1"
            + " and a.fecha_creacion >= @fechaDesde"
            + " and a.fecha_creacion <= @fechaHasta";

            if (filtro.FiltroCodigo != "")
            {
                sql = sql + " and a.id_proveedor = @idProveedor";
            }

            if (filtro.FiltroTipoComprobante != -1)
            {
                sql = sql + " and a.id_tipo_comprobante = @idTipoComprobante";
            }

            if (filtro.FiltroFacturaIncompleta == 'S')
            {
                sql = sql + " and a.incompleto = @incompleto";
            }

            if (filtro.FiltroNroComprobante != "")
            {
                sql = sql + " and a.cod_comprobante = @codComprobante";
            }

            sql = sql + " order by 1, 3, 5";

            parameters.Add(new NpgsqlParameter("idProveedor", filtro.FiltroCodigo));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", filtro.FiltroTipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", filtro.FiltroNroComprobante));
            parameters.Add(new NpgsqlParameter("incompleto", filtro.FiltroFacturaIncompleta));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ComprobanteCompraDTO e = new ComprobanteCompraDTO();

                e.fecha_creacion = DateTime.Parse(data["fecha"].ToString());
                e.v_fecha = String.Format("{0:dd/MM/yyyy}", e.fecha_creacion);
                e.id_proveedor = data["cod_proveedor"].ToString();
                e.id_tipo_comprobante = long.Parse(data["id_tipo_comprobante"].ToString());
                e.tipo_comprobante = data["tipo_comprobante"].ToString();
                e.cod_comprobante = data["cod_comprobante"].ToString();
                e.id_origen = long.Parse(data["id_origen"].ToString());
                e.anulado = char.Parse(data["anulado"].ToString());
                e.fecha_contable = DateTime.Parse(data["fecha_contable"].ToString());
                e.v_fecha_contable = String.Format("{0:dd/MM/yyyy}", e.fecha_contable);

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static long obtenerIdOrigenFacturaA(string cod_comprobante)
        {
            long idFactura = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_origen idFactura from cpc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'FACTURA A' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idFactura;
        }

        public static long obtenerIdOrigenFacturaB(string cod_comprobante)
        {
            long idFactura = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_origen idFactura from cpc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'FACTURA B' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idFactura;
        }

        public static long obtenerIdOrigenFacturaC(string cod_comprobante)
        {
            long idFactura = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_origen idFactura from cpc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'FACTURA C' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idFactura = long.Parse(data["idFactura"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idFactura;
        }


        public static void marcarCompleto(string tipo_comprobante, FacturaDeCompraDTO dataFact)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            long idTipoComprobante = ValorDTO.obtenerId(tipo_comprobante);

            //actualizo factura
            string sql = "UPDATE cpc_comprobante set"
            + " incompleto = 'N'"
            + " where id_origen = @idFactura and cod_comprobante = @codComprobante and id_tipo_comprobante = @idTipoComprobante";

            parameters.Add(new NpgsqlParameter("idFactura", dataFact.Id));
            parameters.Add(new NpgsqlParameter("codComprobante", dataFact.Cod_comprobante));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static long obtenerIdOrigen(string cod_comprobante, string cod_proveedor, long id_tipo_comprobante)
        {
            long idOrigen = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id_origen from cpc_comprobante where id_tipo_comprobante = @id_tipo_comprobante and cod_comprobante = @cod_comprobante and id_proveedor = @cod_proveedor";
            
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idOrigen = long.Parse(data["id_origen"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idOrigen;
        }

        public static ComprobanteCompraDTO obtenerComprobante(string cod_proveedor, string cod_comprobante)
        {

            ComprobanteCompraDTO comprobanteEncontrado = new ComprobanteCompraDTO();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select b.id id_tipo_comprobante, b.valor_adicional tipo_comprobante, a.cod_comprobante cod_comprobante"
            + " from cpc_comprobante a, ofc_tabla_valor b"
            + " where a.id_tipo_comprobante = b.id"
            + " and b.id_tabla = 'TC'"
            + " and a.id_origen != -1"
            + " and a.anulado != 'S'"
            + " and a.id_proveedor = @cod_proveedor"
            + " and a.cod_comprobante = @cod_comprobante";                  
              
            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                comprobanteEncontrado.tipo_comprobante = data["tipo_comprobante"].ToString();
                comprobanteEncontrado.cod_comprobante = data["cod_comprobante"].ToString();
                comprobanteEncontrado.id_tipo_comprobante = long.Parse(data["id_tipo_comprobante"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return comprobanteEncontrado;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ComprobanteDTO
    {
        long cod_comprobante_1;

        public long Cod_comprobante_1
        {
            get { return cod_comprobante_1; }
            set { cod_comprobante_1 = value; }
        }

        long cod_comprobante_2;

        public long Cod_comprobante_2
        {
            get { return cod_comprobante_2; }
            set { cod_comprobante_2 = value; }
        }

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

        string id_cliente;

        public string Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        char anulado;

        public char Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }
        
        public ComprobanteDTO()
        {
            cod_comprobante_1 = -1;
            cod_comprobante_2 = -1;
            id_tipo_comprobante = -1;
            fecha_creacion = DateTime.Now;
            v_fecha = String.Empty;
            id_origen = -1;
            cod_comprobante = String.Empty;
            id_cliente = String.Empty;
            tipo_comprobante = String.Empty;
            anulado = 'N';
        }

        public static List<ComprobanteDTO> obtenerComprobantes(FiltrosABMCliente filtro)
        {

            List<ComprobanteDTO> lista = new List<ComprobanteDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select a.fecha_creacion fecha, a.id_cliente cod_cliente, b.id id_tipo_comprobante, b.valor tipo_comprobante,"
            + " a.cod_comprobante cod_comprobante, a.id_origen id_origen, a.anulado anulado"
            + " from ofc_comprobante a, ofc_tabla_valor b"
            + " where a.id_tipo_comprobante = b.id"
            + " and b.id_tabla = 'TC'"
            + " and a.id_cliente = @idCliente"
            + " and a.id_origen != -1"
            + " and a.fecha_creacion >= @fechaDesde"
            + " and a.fecha_creacion <= @fechaHasta";

            if (filtro.FiltroNroComprobante != "")
            {
                sql = sql + " and a.cod_comprobante = @codComprobante";
            }

            //mejora para que permita buscar comprobantes sin conocer el tipo
            if (filtro.FiltroTipoComprobante != -1)
            {
                sql = sql + " and a.id_tipo_comprobante = @idTipoComprobante";
            }

            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("idCliente", filtro.FiltroCodigo));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", filtro.FiltroTipoComprobante));
            parameters.Add(new NpgsqlParameter("codComprobante", filtro.FiltroNroComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ComprobanteDTO e = new ComprobanteDTO();

                e.fecha_creacion = DateTime.Parse(data["fecha"].ToString());
                e.v_fecha = String.Format("{0:dd/MM/yyyy HH:mm:ss}", e.fecha_creacion);
                e.id_cliente = data["cod_cliente"].ToString();
                e.id_tipo_comprobante = long.Parse(data["id_tipo_comprobante"].ToString());
                e.tipo_comprobante = data["tipo_comprobante"].ToString();
                e.cod_comprobante = data["cod_comprobante"].ToString();
                e.id_origen = long.Parse(data["id_origen"].ToString());
                e.anulado = char.Parse(data["anulado"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<ComprobanteDTO> obtenerComprobanteRemito(FiltrosABMCliente filtro)
        {

            List<ComprobanteDTO> lista = new List<ComprobanteDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            //feb 1.9.1
            string sql = "select a.fecha_creacion fecha, a.id_cliente cod_cliente, "
            + " a.cod_comprobante cod_comprobante, a.id id_origen, 'N' anulado"
            + " from ofc_remito a"
            + " where a.id_cliente = @idCliente"
            + " and a.fecha_creacion >= @fechaDesde"
            + " and a.fecha_creacion <= @fechaHasta"
            + " and not exists (select 1 from ofc_comprobante b where a.id = b.id_origen and a.cod_comprobante = b.cod_comprobante)";

            if (filtro.FiltroNroComprobante != "")
            {
                sql = sql + " and a.cod_comprobante = @codComprobante";
            }

            sql = sql + " order by 1";

            parameters.Add(new NpgsqlParameter("idCliente", filtro.FiltroCodigo));
            parameters.Add(new NpgsqlParameter("fechaDesde", filtro.FiltroFechaDesde));
            parameters.Add(new NpgsqlParameter("fechaHasta", filtro.FiltroFechaHasta));
            parameters.Add(new NpgsqlParameter("codComprobante", filtro.FiltroNroComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ComprobanteDTO e = new ComprobanteDTO();

                e.fecha_creacion = DateTime.Parse(data["fecha"].ToString());
                e.v_fecha = String.Format("{0:dd/MM/yyyy HH:mm:ss}", e.fecha_creacion);
                e.id_cliente = data["cod_cliente"].ToString();
                e.id_tipo_comprobante = filtro.FiltroTipoComprobante; 
                e.tipo_comprobante = "REMITO";
                if (data["anulado"] != null && data["anulado"] != DBNull.Value)
                    e.anulado = char.Parse(data["anulado"].ToString());
                e.cod_comprobante = data["cod_comprobante"].ToString();
                e.id_origen = long.Parse(data["id_origen"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static string insertar(string tipo, ReciboDTO dataRecibo)
        {

            //pensar como seria con nota de credito y nota de debito
            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());
            //valorDigitosA = dataRecibo.Id_talonario; //el numero de talonario es ingreso a partir de ahora

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            comprobante_2 = dataRecibo.Nro_recibo.ToString();

            for (int i = 0; i < cantDigitosB - dataRecibo.Nro_recibo.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente)";
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente);";

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataRecibo.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataRecibo.Id_cliente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return comprobante_1 + "-" + comprobante_2;
        }



        public static void insertar(string tipo, long idOrden)
        {

            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo + " DE TRABAJO");

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            comprobante_2 = idOrden.ToString();

            for (int i = 0; i < cantDigitosB - idOrden.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado)";
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N');";

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", idOrden));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }


        public static void insertar(string tipo, NotaDebitoDTO dataDebito)
        {

            //pensar como seria con nota de credito y nota de debito
            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            if (tipo == "NOTA DE DEBITO A") //feb 1.9
            {
                idTipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO A");
            }
            if (tipo == "NOTA DE DEBITO B") //feb 1.9
            {
                idTipoComprobante = ValorDTO.obtenerId("NOTA DE DEBITO B");
            }

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            comprobante_2 = dataDebito.Nro_nota_debito.ToString();
            for (int i = 0; i < cantDigitosB - dataDebito.Nro_nota_debito.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante
            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataDebito.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataDebito.Id_cliente));
            parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico(dataDebito.Id, "NOTA DEBITO"))); //feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "NOTA DE DEBITO B") //feb 1.9
            {
                decimal valorIva = Decimal.Zero;
                //valorIva = ParametroDTO.obtenerParametroI("IVA");
                valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
                valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                decimal auxSubtotal = dataDebito.Subtotal;
                decimal Iva = dataDebito.Iva;
                dataDebito.Subtotal = dataDebito.Subtotal - dataDebito.No_gravado;
                dataDebito.Subtotal = decimal.Round((dataDebito.Subtotal / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                dataDebito.Iva = dataDebito.Total - dataDebito.No_gravado - dataDebito.Subtotal;
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataDebito, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N');
                detLibro.registrar();
                dataDebito.Subtotal = auxSubtotal;
                dataDebito.Iva = Iva;
            }

            if (tipo == "NOTA DE DEBITO A") //feb 1.9
            {
                decimal auxSubtotal = dataDebito.Subtotal;
                dataDebito.Subtotal = dataDebito.Subtotal - dataDebito.No_gravado;
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataDebito, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N');
                detLibro.registrar();
                dataDebito.Subtotal = auxSubtotal;
            }
        }

        public static void insertar(string tipo, NotaCreditoDTO dataCredito)
        {

            //pensar como seria con nota de credito y nota de debito
            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            if (tipo == "NOTA DE CREDITO A") //feb 1.9
            {
                idTipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO A");
            }
            if (tipo == "NOTA DE CREDITO B") //feb 1.9
            {
                idTipoComprobante = ValorDTO.obtenerId("NOTA DE CREDITO B");
            }

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());
            
            //genero codigo 2
            comprobante_2 = dataCredito.Nro_nota_credito.ToString();
            for (int i = 0; i < cantDigitosB - dataCredito.Nro_nota_credito.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataCredito.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataCredito.Id_cliente));
            parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico(dataCredito.Id, "NOTA CREDITO"))); //feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "NOTA DE CREDITO B") //feb 1.9
            {
                decimal valorIva = Decimal.Zero;
                //valorIva = ParametroDTO.obtenerParametroI("IVA");
                valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
                valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                decimal auxSubtotal = dataCredito.Subtotal;
                decimal Iva = dataCredito.Iva;
                dataCredito.Subtotal = decimal.Round((dataCredito.Subtotal / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                dataCredito.Iva = dataCredito.Total - dataCredito.Subtotal;
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataCredito, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N');
                detLibro.registrar();
                dataCredito.Subtotal = auxSubtotal;
                dataCredito.Iva = Iva;
            }
            if (tipo == "NOTA DE CREDITO A") //feb 1.9
            {
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataCredito, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N');
                detLibro.registrar();
            }
        }

        public static void insertarRemitoFinal(FacturaDTO dataFact)
        {
            long idTipoComprobante = -1;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            string comprobante = String.Empty;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId("REMITO");
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI("DIGITOS NRO REMITO").ToString());
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII("DIGITOS NRO REMITO").ToString());
            comprobante = RemitoDTO.getComprobanteTemp();
            comprobante_1 = comprobante.Substring(0, cantDigitosA);
            comprobante_2 = comprobante.Substring(cantDigitosA + 1,cantDigitosB);

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante));
            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));
            parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico("REMITO"))); //feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertar(string tipo, FacturaDTO dataFact)
        {

            //pensar como seria con nota de credito y nota de debito
            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            if (tipo == "FACTURA A" || tipo == "FACTURA B")
            {
                comprobante_2 = dataFact.Nro_factura.ToString();

                for (int i = 0; i < cantDigitosB - dataFact.Nro_factura.ToString().Length; i++)
                {
                    comprobante_2 = "0" + comprobante_2;
                }

            }

            if (tipo == "REMITO")
            {
                comprobante_2 = dataFact.Nro_remito.ToString();

                for (int i = 0; i < cantDigitosB - dataFact.Nro_remito.ToString().Length; i++)
                {
                    comprobante_2 = "0" + comprobante_2;
                }
            }


            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));

            //inicio feb 1.9.2
            if (tipo == "FACTURA A" || tipo == "FACTURA B")
            {
                parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
                parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico(dataFact.Id, "FACTURA")));
            }

            if (tipo == "REMITO")
            {
                parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
                parameters.Add(new NpgsqlParameter("id_unico", ComprobanteDTO.generarIdUnico()));
            }
            //fin feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataFact.Id_cliente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "FACTURA B" )
            {
                decimal valorIva = Decimal.Zero;
                //obtengo el iva
                if (dataFact.Iva105 == 'S')
                {
                    //valorIva = (decimal)ParametroDTO.obtenerParametroI("IVA") / 2;
                    valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_105"));
                    valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    //valorIva = (decimal)ParametroDTO.obtenerParametroI("IVA");
                    valorIva = decimal.Parse(ValorDTO.obtenerValorAdicional("IV", "IVA_21"));
                    valorIva = decimal.Round(valorIva, 2, MidpointRounding.AwayFromZero);
                }
                decimal auxSubtotal = dataFact.Subtotal;
                decimal Iva = dataFact.Iva;
                dataFact.Subtotal = decimal.Round((dataFact.Subtotal / (1 + (valorIva / 100))), 2, MidpointRounding.AwayFromZero);
                dataFact.Iva = dataFact.Total - dataFact.Subtotal;
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataFact, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N', dataFact.Iva105);
                detLibro.registrar();
                dataFact.Subtotal = auxSubtotal;
                dataFact.Iva = Iva;
            }

            if (tipo == "FACTURA A" )
            {
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataFact, idTipoComprobante, comprobante_1 + "-" + comprobante_2, 'N', dataFact.Iva105);
                detLibro.registrar();
            }

        }

        //feb 1.9.2 nuevo método
        public static void insertar(RemitoDTO dataRem)
        {
            long idTipoComprobante = -1;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            string comprobante = String.Empty;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId("REMITO");
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI("DIGITOS NRO REMITO").ToString());
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII("DIGITOS NRO REMITO").ToString());
            comprobante = dataRem.Cod_comprobante_remito;
            comprobante_1 = comprobante.Substring(0, cantDigitosA);
            comprobante_2 = comprobante.Substring(cantDigitosA + 1, cantDigitosB);

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'N', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", dataRem.Fecha_creacion));
            parameters.Add(new NpgsqlParameter("idOrigen", dataRem.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataRem.Id_cliente));
            parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico(dataRem.Id, "REMITO"))); //feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertarAnulado(RemitoDTO dataRem)
        {
            long idTipoComprobante = -1;
            //long idOrigen = -1; //feb 1.9.1
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            string comprobante = String.Empty;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId("REMITO");
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI("DIGITOS NRO REMITO").ToString());
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII("DIGITOS NRO REMITO").ToString());
            comprobante = dataRem.Cod_comprobante_remito;
            comprobante_1 = comprobante.Substring(0, cantDigitosA);
            comprobante_2 = comprobante.Substring(cantDigitosA + 1, cantDigitosB);

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'S', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", dataRem.Fecha_creacion)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("idOrigen", dataRem.Id)); //feb 1.9.1
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataRem.Id_cliente));
            //inicio feb 1.9.2
            long idUnico = ComprobanteTempDTO.obtenerIdUnico(dataRem.Id, "REMITO");
            if (idUnico == -1)
            {
                idUnico = ComprobanteDTO.generarIdUnico();
            }
            parameters.Add(new NpgsqlParameter("id_unico", idUnico));
            //fin feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertarAnulado(string tipo, RemitoDTO dataRem)
        {
            long idTipoComprobante = -1;
            string descripcionParam = String.Empty;
            string descripcionParam2 = String.Empty;
            string descripcionParam3 = String.Empty;
            int cantDigitosA = 0;
            int cantDigitosB = 0;
            int valorDigitosA = 0;
            string comprobante_1 = String.Empty;
            string comprobante_2 = String.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //obtener id de comprobante
            idTipoComprobante = ValorDTO.obtenerId(tipo);

            //tratamiento primeros digitos:
            //obtener cantidad primeros digitos
            descripcionParam = "DIGITOS NRO " + tipo;
            cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            descripcionParam2 = "INICIO NRO " + tipo;
            valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            descripcionParam3 = "DIGITOS NRO " + tipo;
            cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            comprobante_2 = dataRem.Nro_remito.ToString();

            for (int i = 0; i < cantDigitosB - dataRem.Nro_remito.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            //listo comprobante_1 y comprobante_2 ahora inserto el comprobante

            string sql = "INSERT INTO ofc_comprobante(";
            sql = sql + "cod_comprobante_1,cod_comprobante_2,id_tipo_comprobante,fecha_creacion,id_origen,cod_comprobante, anulado, id_cliente, id_unico)"; //feb 1.9.2
            sql = sql + " VALUES (@comprobante_1, @comprobante_2, @idTipoComprobante, @fechaActual, @idOrigen, @comprobante, 'S', @idCliente, @id_unico);"; //feb 1.9.2

            parameters.Add(new NpgsqlParameter("comprobante_1", comprobante_1));
            parameters.Add(new NpgsqlParameter("comprobante_2", comprobante_2));
            parameters.Add(new NpgsqlParameter("idTipoComprobante", idTipoComprobante));
            parameters.Add(new NpgsqlParameter("fechaActual", DateTime.Now));
            parameters.Add(new NpgsqlParameter("idOrigen", dataRem.Id));
            parameters.Add(new NpgsqlParameter("comprobante", comprobante_1 + "-" + comprobante_2));
            parameters.Add(new NpgsqlParameter("idCliente", dataRem.Id_cliente));
            parameters.Add(new NpgsqlParameter("id_unico", ComprobanteTempDTO.obtenerIdUnico(dataRem.Id, "REMITO"))); //feb 1.9.2

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void anular(string tipo, RemitoDTO dataRem)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string cod_comprobante = string.Empty;
            string sql = "update ofc_comprobante set anulado = 'S' where id_origen in (select id from ofc_remito where id = @idOrigen) and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor = @descComprobante);";

            parameters.Add(new NpgsqlParameter("idOrigen", dataRem.Id));
            parameters.Add(new NpgsqlParameter("descComprobante", tipo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void anular(string tipo, FacturaDTO dataFact)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idTipoComprobante = -1;
            string cod_comprobante = string.Empty;
            string sql = "update ofc_comprobante set anulado = 'S' where id_origen in (select id from ofc_factura where id = @idOrigen) and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor = @descComprobante);";

            parameters.Add(new NpgsqlParameter("idOrigen", dataFact.Id));
            parameters.Add(new NpgsqlParameter("descComprobante", tipo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "FACTURA B")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataFact.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataFact, idTipoComprobante, cod_comprobante, 'S', dataFact.Iva105);
                detLibro.actualizar(ValorDTO.obtenerId("AN. FACTURA B"));
            }
            if (tipo == "FACTURA A")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataFact.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataFact, idTipoComprobante, cod_comprobante, 'S', dataFact.Iva105);
                detLibro.actualizar(ValorDTO.obtenerId("AN. FACTURA A"));
            }
        }

        public static void anular(string tipo, NotaCreditoDTO dataCredito)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idTipoComprobante = -1;
            string cod_comprobante = string.Empty;
            string sql = "update ofc_comprobante set anulado = 'S' where id_origen in (select id from ofc_nota_credito where id = @idOrigen) and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor = @descComprobante);";

            parameters.Add(new NpgsqlParameter("idOrigen", dataCredito.Id));
            parameters.Add(new NpgsqlParameter("descComprobante", tipo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "NOTA DE CREDITO B")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataCredito.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataCredito, idTipoComprobante, cod_comprobante, 'S');
                detLibro.actualizar(ValorDTO.obtenerId("AN. NOTA DE CREDITO B"));
            }
            if (tipo == "NOTA DE CREDITO A")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataCredito.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataCredito, idTipoComprobante, cod_comprobante, 'S');
                detLibro.actualizar(ValorDTO.obtenerId("AN. NOTA DE CREDITO A"));
            }

        }


        public static void anular(string tipo, NotaDebitoDTO dataDebito)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idTipoComprobante = -1;
            string cod_comprobante = string.Empty;
            string sql = "update ofc_comprobante set anulado = 'S' where id_origen in (select id from ofc_nota_debito where id = @idOrigen) and id_tipo_comprobante in (select id from ofc_tabla_valor where id_tabla = 'TC' and valor = @descComprobante);";

            parameters.Add(new NpgsqlParameter("idOrigen", dataDebito.Id));
            parameters.Add(new NpgsqlParameter("descComprobante", tipo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            if (tipo == "NOTA DE DEBITO B")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataDebito.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataDebito, idTipoComprobante, cod_comprobante, 'S');
                detLibro.actualizar(ValorDTO.obtenerId("AN. NOTA DE DEBITO B"));
            }
            if (tipo == "NOTA DE DEBITO A")
            {
                idTipoComprobante = ValorDTO.obtenerId(tipo);
                cod_comprobante = ComprobanteDTO.obtenerComprobante(dataDebito.Id, idTipoComprobante);
                LibroIvaVentasDTO detLibro = new LibroIvaVentasDTO(dataDebito, idTipoComprobante, cod_comprobante, 'S');
                detLibro.actualizar(ValorDTO.obtenerId("AN. NOTA DE DEBITO A"));
            }

        }

        public static bool existeFacturaA(long idFactura)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroFacturaA(idFactura.ToString());

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'FACTURA A' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeFacturaA(string cod_comprobante)
        {
            int count = 0;

            string v_codComprobante = cod_comprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'FACTURA A' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        //feb 1.8
        public static bool existeFacturaDebitoA(string cod_comprobante)
        {
            int count = 0;

            string v_codComprobante = cod_comprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor in ('FACTURA A', 'NOTA DE DEBITO A') and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeFacturaB(long idFactura)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroFacturaB(idFactura.ToString());

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'FACTURA B' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeFacturaB(string cod_comprobante)
        {
            int count = 0;

            string v_codComprobante = cod_comprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'FACTURA B' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        //feb 1.8
        public static bool existeFacturaDebitoB(string cod_comprobante)
        {
            int count = 0;

            string v_codComprobante = cod_comprobante;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor in ('FACTURA B', 'NOTA DE DEBITO B') and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeNotaCreditoA(long idCredito)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroCreditoA(idCredito.ToString()); //feb 1.9

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'NOTA DE CREDITO A' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeNotaCreditoB(long idCredito)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroCreditoB(idCredito.ToString()); //feb 1.9

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'NOTA DE CREDITO B' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeNotaDebitoA(long idDebito)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroDebitoA(idDebito.ToString()); //feb 1.9

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'NOTA DE DEBITO A' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeNotaDebitoB(long idDebito)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroDebitoB(idDebito.ToString()); //feb 1.9

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'NOTA DE DEBITO B' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }


        public static bool existeRemito(long idRemito)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroRemito(idRemito.ToString());

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'REMITO' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader dataC = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (dataC != null && dataC.Read())
            {
                count = int.Parse(dataC["cantidad"].ToString());
                dataC.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);

        }

        public static bool existeRecibo(string codComprobante)
        {
            int count = 0;

            string v_codComprobante = ComprobanteDTO.converToNroRecibo(codComprobante.ToString());

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.id_tabla = 'TC' and val.valor = 'RECIBO' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", v_codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count = int.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static long obtenerIdOrigenFacturaA(string cod_comprobante)
        {
            long idFactura = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_origen idFactura from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'FACTURA A' and comp.cod_comprobante = @codComprobante";
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

            string sql = "select comp.id_origen idFactura from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'FACTURA B' and comp.cod_comprobante = @codComprobante";
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

        public static string obtenerComprobante(long id_origen, long id_tipo_comprobante)
        {
            string cod_comprobante = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.cod_comprobante cod_comprobante from ofc_comprobante comp where comp.id_origen = @id_origen and comp.id_tipo_comprobante = @id_tipo_comprobante";
            parameters.Add(new NpgsqlParameter("id_origen", id_origen));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                cod_comprobante = data["cod_comprobante"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cod_comprobante;
        }

        public static string converToNroRemito(string numero)
        {
            string descripcionParam = "DIGITOS NRO REMITO";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO REMITO";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO REMITO";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        public static string converToNroRecibo(string numero)
        {
            string descripcionParam = "DIGITOS NRO RECIBO";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO RECIBO";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO RECIBO";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }


        public static string converToNroFacturaA(string numero)
        {
            string descripcionParam = "DIGITOS NRO FACTURA A";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO FACTURA A";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO FACTURA A";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }


        //feb 1.9
        public static string converToNroCreditoA(string numero)
        {
            string descripcionParam = "DIGITOS NRO NOTA DE CREDITO A";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO NOTA DE CREDITO A";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO NOTA DE CREDITO A";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        //feb 1.9
        public static string converToNroDebitoA(string numero)
        {
            string descripcionParam = "DIGITOS NRO NOTA DE DEBITO A";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO NOTA DE DEBITO A";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO NOTA DE DEBITO A";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        public static string converToNroFacturaB(string numero)
        {
            string descripcionParam = "DIGITOS NRO FACTURA B";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO FACTURA B";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO FACTURA B";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        //feb 1.9
        public static string converToNroCreditoB(string numero)
        {
            string descripcionParam = "DIGITOS NRO NOTA DE CREDITO B";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO NOTA DE CREDITO B";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO NOTA DE CREDITO B";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        //feb 1.9
        public static string converToNroDebitoB(string numero)
        {
            string descripcionParam = "DIGITOS NRO NOTA DE DEBITO B";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO NOTA DE DEBITO B";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO NOTA DE DEBITO B";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        public static string converToNroAjuste(string numero)
        {
            string descripcionParam = "DIGITOS NRO AJUSTE DE STOCK";
            int cantDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam).ToString());

            //obtener valor primeros digitos
            string descripcionParam2 = "INICIO NRO AJUSTE DE STOCK";
            int valorDigitosA = int.Parse(ParametroDTO.obtenerParametroI(descripcionParam2).ToString());

            //genero codigo 1
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            //tratamiento segundos digitos:
            //obtener cantidad segundos digitos
            string descripcionParam3 = "DIGITOS NRO AJUSTE DE STOCK";
            int cantDigitosB = int.Parse(ParametroDTO.obtenerParametroII(descripcionParam3).ToString());

            //genero codigo 2
            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        public static string obtenerCodCliente(long id_tipo_comprobante, string cod_comprobante)
        {
            string idCliente = string.Empty;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_cliente idCliente from ofc_comprobante comp where comp.id_tipo_comprobante = @id_tipo_comprobante and comp.cod_comprobante = @cod_comprobante";
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idCliente = data["idCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idCliente;
        }

        //feb 1.8
        public static long obtenerIdOrigenRecibo(string cod_comprobante)
        {
            long idRecibo = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select comp.id_origen idRecibo from ofc_comprobante comp, ofc_tabla_valor val where comp.id_tipo_comprobante = val.id and val.valor = 'RECIBO' and comp.cod_comprobante = @codComprobante";
            parameters.Add(new NpgsqlParameter("codComprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idRecibo = long.Parse(data["idRecibo"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idRecibo;
        }

        //feb 1.8
        public static string converToNroReciboSinAccesoBD(int cantDigitosA, int valorDigitosA, int cantDigitosB, string numero)
        {
            string comprobante_1 = valorDigitosA.ToString();

            for (int i = 0; i < cantDigitosA - valorDigitosA.ToString().Length; i++)
            {
                comprobante_1 = "0" + comprobante_1;
            }

            string comprobante_2 = numero;

            for (int i = 0; i < cantDigitosB - numero.ToString().Length; i++)
            {
                comprobante_2 = "0" + comprobante_2;
            }

            return comprobante_1 + "-" + comprobante_2;
        }

        //feb 1.9.2
        public static long generarIdUnico()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            long idUnicoComprobante = -1;
            string sql = "select nextval('ofc_comprobante_id_unico_seq') idUnicoComprobante";
            //nuevo id unico de comprobante
            NpgsqlDataReader dataR = BaseDeDatos.ejecutarQuery(sql, cn);

            if (dataR != null && dataR.Read())
            {
                idUnicoComprobante = long.Parse(dataR["idUnicoComprobante"].ToString());
                dataR.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idUnicoComprobante;
        }

    }
}

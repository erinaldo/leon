using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ConceptoDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        char vigente;

        public char Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        long id_cuenta_compra;

        public long Id_cuenta_compra
        {
            get { return id_cuenta_compra; }
            set { id_cuenta_compra = value; }
        }


        long id_iva;

        public long Id_iva
        {
            get { return id_iva; }
            set { id_iva = value; }
        }


        #region Constructor

        public ConceptoDTO()
        {
            id = -1;
            descripcion = "";
            vigente = 'N';
            codigo = "";
            id_cuenta_compra = -1;
            id_iva = -1;
        }

        #endregion

        public static IList<ConceptoDTO> obtenerConceptos(string codigo, string descripcion)
        {
            IList<ConceptoDTO> lista = new BindingList<ConceptoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select descripcion, vigente, codigo, id_cuenta_compra, id_iva, id";
            sql = sql + " from cpc_concepto";
            sql = sql + " where 1 = 1";

            if (codigo != string.Empty)
            {
                sql = sql + " and codigo = @codigo";
            }

            if (descripcion != string.Empty)
            {
                sql = sql + " and descripcion = @descripcion";
            }

            sql = sql + " order by 3, 2";

            parameters.Add(new NpgsqlParameter("codigo", codigo));
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ConceptoDTO e = new ConceptoDTO();
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();
                e.vigente = char.Parse(data["vigente"].ToString());
                e.id_cuenta_compra = long.Parse(data["id_cuenta_compra"].ToString());
                e.id_iva = long.Parse(data["id_iva"].ToString());
                e.id = long.Parse(data["id"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ConceptoDTO> obtenerConceptos()
        {
            IList<ConceptoDTO> lista = new BindingList<ConceptoDTO>();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select distinct codigo, descripcion";
            sql = sql + " from cpc_concepto where vigente = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ConceptoDTO e = new ConceptoDTO();
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static bool esExento(string codigo)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_concepto con, ofc_tabla_valor val where val.id = con.id_iva and con.codigo = @codigo and con.vigente = 'S' and val.valor = 'IVA_0' and val.id_tabla = 'IC'";
            parameters.Add(new NpgsqlParameter("codigo", codigo));

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


        public static long obtenerId(string codigo)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idConcepto = -1;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id";
            sql = sql + " from cpc_concepto where codigo = @codigo";

            parameters.Add(new NpgsqlParameter("codigo", codigo));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                idConcepto = long.Parse(data["id"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idConcepto;
        }

        public static decimal obtenerPorcentajeDeIva(long idConcepto)
        {
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            decimal porcentajeIva = decimal.Zero;

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select val.valor_adicional porcentajeDeIva";
            sql = sql + " from cpc_concepto con, ofc_tabla_valor val where con.id_iva = val.id and con.id = @id";

            parameters.Add(new NpgsqlParameter("id", idConcepto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                porcentajeIva = decimal.Parse(data["porcentajeDeIva"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return porcentajeIva;
        }

        public static void actualizar(ConceptoDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE cpc_concepto SET descripcion = @descripcion, vigente = @vigente, id_cuenta_compra = @id_cuenta_compra, id_iva = @id_iva where codigo = @codigo;";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("id_cuenta_compra", data.id_cuenta_compra));
            parameters.Add(new NpgsqlParameter("id_iva", data.id_iva));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertar(ConceptoDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el concepto
            string sql = "insert into cpc_concepto(id,descripcion,vigente,codigo,id_cuenta_compra,id_iva) "
            + " values(nextval('cpc_concepto_id_seq'),@descripcion,@vigente,@codigo,@id_cuenta_compra,@id_iva);";

            parameters.Add(new NpgsqlParameter("descripcion", data.descripcion));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("codigo", data.codigo));
            parameters.Add(new NpgsqlParameter("id_cuenta_compra", data.id_cuenta_compra));
            parameters.Add(new NpgsqlParameter("id_iva", data.id_iva));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static bool existeCodigo(string identificador)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_concepto where codigo = @codigo and vigente = 'S'";
            parameters.Add(new NpgsqlParameter("codigo", identificador));

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

        public static bool existeDescripcion(string descripcion, string codigo)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_concepto where descripcion = @descripcion and codigo <> @codigo and vigente = 'S'";
            parameters.Add(new NpgsqlParameter("descripcion", descripcion));
            parameters.Add(new NpgsqlParameter("codigo", codigo));

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

        public static bool tieneComprobanteAsociado(long idConcepto)
        {
            long count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //en facturas de compra
            string sql = "select count(1) as cantidad from cpc_factura_detalle where id_concepto = @idConcepto";
            parameters.Add(new NpgsqlParameter("idConcepto", idConcepto));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en nota de credito de compra
            sql = "select count(1) as cantidad from cpc_nota_credito_detalle where id_concepto = @idConcepto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            //en nota de debito de compra
            sql = "select count(1) as cantidad from cpc_nota_debito_detalle where id_concepto = @idConcepto";

            data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                count += long.Parse(data["cantidad"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return (count != 0);
        }

        public static bool borrar(long idConcepto)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            parameters.Add(new NpgsqlParameter("id", idConcepto));

            string sql = "delete from cpc_concepto where id = @id";
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return true;
        }

    }
}

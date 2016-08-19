using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ValorDTO
    {

        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        string id_tabla;

        public string Id_tabla
        {
            get { return id_tabla; }
            set { id_tabla = value; }
        }

        string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        char vigente;

        public char Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        string valor_adicional;

        public string Valor_adicional
        {
            get { return valor_adicional; }
            set { valor_adicional = value; }
        }

        int id_valor_padre;

        public int Id_valor_padre
        {
            get { return id_valor_padre; }
            set { id_valor_padre = value; }
        }

        int prioridad;

        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        //feb 1.9.1
        long id_externo;

        public long Id_externo
        {
            get { return id_externo; }
            set { id_externo = value; }
        }

        string tabla;

        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        
        public ValorDTO()
        {
            id = -1;
            id_tabla = String.Empty;
            valor = String.Empty;
            vigente = 'N';
            valor_adicional = String.Empty;
            id_valor_padre = -1;
            prioridad = -1;
            id_externo = -1;         //feb 1.9.1
            tabla = String.Empty;
        }

        #region Métodos

        //feb 1.9.1
        public static IList<ValorDTO> obtenerValores(string id_tabla)
        {

            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, valor, valor_adicional, id_externo";
            sql = sql + " from ofc_tabla_valor";
            sql = sql + " where id_tabla = @id_tabla";
            sql = sql + " and vigente = 'S'";
            sql = sql + " order by prioridad;";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();

                e.id = int.Parse(data["id"].ToString());
                e.valor = data["valor"].ToString();
                e.valor_adicional = data["valor_adicional"].ToString();

                if (data["id_externo"] != null && data["id_externo"] != DBNull.Value) //feb 1.9.1
                {
                    e.id_externo = long.Parse(data["id_externo"].ToString()); //feb 1.9.1
                }
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        //feb 1.9.1
        public static IList<ValorDTO> obtenerValores(string id_tabla, string valor)
        {
            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select a.id id, a.id_tabla id_tabla, b.tabla tabla, a.valor valor, a.vigente vigente, a.valor_adicional valor_adicional, a.prioridad prioridad, a.id_valor_padre id_valor_padre, a.id_externo id_externo"; //feb 1.9.1
            sql = sql + " from ofc_tabla_valor a, ofc_tabla b where a.id_tabla = b.id";

            if (id_tabla != string.Empty)
            {
                sql = sql + " and a.id_tabla like @id_tabla";
            }

            if (valor != string.Empty)
            {
                sql = sql + " and a.valor like @valor";
            }

            sql = sql + " order by a.prioridad";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));
            parameters.Add(new NpgsqlParameter("valor", valor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();
                e.id = long.Parse(data["id"].ToString());
                e.id_tabla = data["id_tabla"].ToString();
                e.tabla = data["tabla"].ToString();
                e.valor = data["valor"].ToString();
                e.vigente = char.Parse(data["vigente"].ToString());

                if (data["valor_adicional"] != null && data["valor_adicional"] != DBNull.Value)
                    e.valor_adicional = data["valor_adicional"].ToString();

                if (data["prioridad"] != null && data["prioridad"] != DBNull.Value)
                    e.prioridad = int.Parse(data["prioridad"].ToString());

                if (data["id_valor_padre"] != null && data["id_valor_padre"] != DBNull.Value)
                    e.id_valor_padre = int.Parse(data["id_valor_padre"].ToString());

                if (data["id_externo"] != null && data["id_externo"] != DBNull.Value) //feb 1.9.1
                    e.id_externo = long.Parse(data["id_externo"].ToString()); //feb 1.9.1

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }
        
        public static IList<ValorDTO> obtenerValoresNOTNULL(string id_tabla)
        {

            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, valor, valor_adicional";
            sql = sql + " from ofc_tabla_valor";
            sql = sql + " where id_tabla = @id_tabla";
            sql = sql + " and vigente = 'S'";
            sql = sql + " and prioridad != -1";
            sql = sql + " order by prioridad;";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();

                e.id = int.Parse(data["id"].ToString());
                e.valor = data["valor"].ToString();
                e.valor_adicional = data["valor_adicional"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ValorDTO> obtenerValoresNOTNULL(string id_tabla, string padre)
        {

            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select val.id, val.valor, val.valor_adicional";
            sql = sql + " from ofc_tabla_valor val, ofc_tabla_valor val2";
            sql = sql + " where (val.id_valor_padre = val2.id or val.id_valor_padre = -1)";
            sql = sql + " and val.id_tabla = @id_tabla";
            sql = sql + " and val2.valor = @padre";
            sql = sql + " and val.vigente = 'S'";
            sql = sql + " and val.prioridad is not null";
            sql = sql + " order by val.prioridad;";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));
            parameters.Add(new NpgsqlParameter("padre", padre));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();

                e.id = int.Parse(data["id"].ToString());
                e.valor = data["valor"].ToString();
                e.valor_adicional = data["valor_adicional"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<ValorDTO> obtenerValores(string id_tabla, int id_valor_padre)
        {

            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, valor, valor_adicional";
            sql = sql + " from ofc_tabla_valor";
            sql = sql + " where id_tabla = @id_tabla";
            sql = sql + " and vigente = 'S'";
            sql = sql + " and id_valor_padre = @id_valor_padre";
            sql = sql + " order by prioridad;";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));
            parameters.Add(new NpgsqlParameter("id_valor_padre", id_valor_padre));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();

                e.id = int.Parse(data["id"].ToString());
                e.valor = data["valor"].ToString();
                e.valor_adicional = data["valor_adicional"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static string obtenerValorAdicional(string id_tabla, string valor)
        {
            string e = string.Empty;
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, valor, valor_adicional";
            sql = sql + " from ofc_tabla_valor";
            sql = sql + " where id_tabla = @id_tabla";
            sql = sql + " and vigente = 'S'";
            sql = sql + " and valor = @valor";
            sql = sql + " order by prioridad;";

            parameters.Add(new NpgsqlParameter("id_tabla", id_tabla));
            parameters.Add(new NpgsqlParameter("valor", valor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                e = data["valor_adicional"].ToString();
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return e;
        }

        public static IList<ValorDTO> obtenerLocalidadesDeClientes()
        {

            IList<ValorDTO> lista = new BindingList<ValorDTO>(); //lista de valores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            //string sql = "select valores.id id, valores.valor valor, valores.valor_adicional valor_adicional";
            //sql = sql + " from ofc_tabla_valor valores";
            //sql = sql + " where valores.id_tabla = 'LO'";
            //sql = sql + " and valores.vigente = 'S'";
            //sql = sql + " and exists (select 1 from ofc_cliente cliente where cliente.localidad_legal = valores.valor and activo = 'S')";
            //sql = sql + " order by valores.prioridad;";

            string sql = "select distinct localidad_legal valor from ofc_cliente where activo = 'S'";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters); //obtengo los valores    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ValorDTO e = new ValorDTO();

                e.valor = data["valor"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }


        public static long obtenerId(string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idTipoComprobante = -1;

            //obtener id de comprobante
            string sql = "select id from ofc_tabla_valor where valor = @tipo";

            parameters.Add(new NpgsqlParameter("tipo", valor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idTipoComprobante = long.Parse(data["id"].ToString());
                data.Close();
            }


            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idTipoComprobante;
        }

        //feb 1.9.1
        public static long obtenerIdExterno(string id_tabla, string valor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            long idExterno = -1;

            //obtener id de sistemas externos
            string sql = "select id_externo from ofc_tabla_valor where valor = @valor and id_tabla = @tabla";

            parameters.Add(new NpgsqlParameter("valor", valor));
            parameters.Add(new NpgsqlParameter("tabla", id_tabla));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idExterno = long.Parse(data["id_externo"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idExterno;
        }

        public static string obtenerValor(long id)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string valor = string.Empty;

            //obtener valor
            string sql = "select valor from ofc_tabla_valor where id = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                valor = data["valor"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return valor;
        }

        //feb 1.9.1
        public static string obtenerValor(string tabla, long id_externo)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string valor = string.Empty;

            //obtener valor
            string sql = "select valor from ofc_tabla_valor where id_externo = @id_externo and id_tabla = @tabla";

            parameters.Add(new NpgsqlParameter("id_externo", id_externo));
            parameters.Add(new NpgsqlParameter("tabla", tabla));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                valor = data["valor"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return valor;
        }

        public static string obtenerValorAdicional(long id)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string valor = string.Empty;

            //obtener valor
            string sql = "select valor_adicional from ofc_tabla_valor where id = @id";

            parameters.Add(new NpgsqlParameter("id", id));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                valor = data["valor_adicional"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return valor;
        }

        //feb 1.9.1
        public static void insert(ValorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO ofc_tabla_valor(id, id_tabla, valor, vigente, valor_adicional, prioridad, id_valor_padre, id_externo) VALUES (nextval('ofc_tabla_valor_id_seq'), @id_tabla, @valor, @vigente, @valor_adicional, @prioridad, @id_valor_padre, @id_externo);";

            parameters.Add(new NpgsqlParameter("id_tabla", data.id_tabla));
            parameters.Add(new NpgsqlParameter("valor", data.valor));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("valor_adicional", data.valor_adicional));
            parameters.Add(new NpgsqlParameter("prioridad", data.prioridad));
            parameters.Add(new NpgsqlParameter("id_valor_padre", data.id_valor_padre));
            parameters.Add(new NpgsqlParameter("id_externo", data.id_externo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void delete(long id)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "DELETE FROM ofc_tabla_valor where id = @id;";

            parameters.Add(new NpgsqlParameter("id", id));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.9.1
        public static void update(ValorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE ofc_tabla_valor SET id_tabla = @id_tabla, valor = @valor, vigente = @vigente, valor_adicional = @valor_adicional, prioridad = @prioridad, id_valor_padre = @id_valor_padre, id_externo = @id_externo where id = @id;";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("id_tabla", data.id_tabla));
            parameters.Add(new NpgsqlParameter("valor", data.valor));
            parameters.Add(new NpgsqlParameter("vigente", data.vigente));
            parameters.Add(new NpgsqlParameter("valor_adicional", data.valor_adicional));
            parameters.Add(new NpgsqlParameter("prioridad", data.prioridad));
            parameters.Add(new NpgsqlParameter("id_valor_padre", data.id_valor_padre));
            parameters.Add(new NpgsqlParameter("id_externo", data.id_externo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        #endregion
    }
}

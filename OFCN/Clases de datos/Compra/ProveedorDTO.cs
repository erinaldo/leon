using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ProveedorDTO
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        string codigo_postal;

        public string Codigo_postal
        {
            get { return codigo_postal; }
            set { codigo_postal = value; }
        }

        string cuit;

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        long id_categoria_iva;

        public long Id_categoria_iva
        {
            get { return id_categoria_iva; }
            set { id_categoria_iva = value; }
        }

        string categoria_iva;

        public string Categoria_iva
        {
            get { return categoria_iva; }
            set { categoria_iva = value; }
        }
        
        long id_unico;

        public long Id_unico
        {
            get { return id_unico; }
            set { id_unico = value; }
        }

        char activo;

        public char Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        long id_condicion_compra;

        public long Id_condicion_compra
        {
            get { return id_condicion_compra; }
            set { id_condicion_compra = value; }
        }

        string condicion_compra;

        public string Condicion_compra
        {
            get { return condicion_compra; }
            set { condicion_compra = value; }
        }

        string telefono_1;

        public string Telefono_1
        {
            get { return telefono_1; }
            set { telefono_1 = value; }
        }

        string telefono_2;

        public string Telefono_2
        {
            get { return telefono_2; }
            set { telefono_2 = value; }
        }

        string nro_ingresos_brutos;

        public string Nro_ingresos_brutos
        {
            get { return nro_ingresos_brutos; }
            set { nro_ingresos_brutos = value; }
        }

        public ProveedorDTO()
        {
            id = string.Empty;
            nombre = string.Empty;
            direccion = string.Empty;
            localidad = string.Empty;
            cuit = string.Empty;
            id_categoria_iva = -1;
            categoria_iva = string.Empty;
            provincia = string.Empty;
            codigo_postal = string.Empty;
            id_unico = -1;
            activo = 'N';
            id_condicion_compra = -1;
            condicion_compra = string.Empty;
            telefono_1 = string.Empty;
            telefono_2 = string.Empty;
            nro_ingresos_brutos = string.Empty;
        }


        #region Métodos


        public static void borrarProveedor(string cod_proveedor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update cpc_proveedor set activo = 'N' where id = @cod_proveedor;";
            parameters.Add(new NpgsqlParameter("cod_proveedor", cod_proveedor));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            CuentaCorrienteProvDTO.borrar(cod_proveedor);

        }

        public static void actualizarProveedor(ProveedorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Actualizamos el proveedor
            string sql = " update cpc_proveedor"
                + " set nombre=@nombre, direccion=@direccion, localidad=@localidad, provincia=@provincia, codigo_postal = @codigo_postal,"
                + " cuit=@cuit, id_categoria_iva=@id_categoria_iva,"
                + " id_condicion_compra=@id_condicion_compra, telefono_1=@telefono_1, telefono_2=@telefono_2, nro_ingresos_brutos = @nro_ingresos_brutos"
                + " WHERE id = @id and activo = 'S'";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("nombre", data.nombre));
            parameters.Add(new NpgsqlParameter("direccion", data.direccion));
            parameters.Add(new NpgsqlParameter("localidad", data.localidad));
            parameters.Add(new NpgsqlParameter("provincia", data.provincia));
            parameters.Add(new NpgsqlParameter("codigo_postal", data.codigo_postal));
            parameters.Add(new NpgsqlParameter("cuit", data.cuit));
            parameters.Add(new NpgsqlParameter("id_categoria_iva", data.id_categoria_iva));
            parameters.Add(new NpgsqlParameter("telefono_1", data.telefono_1));
            parameters.Add(new NpgsqlParameter("telefono_2", data.telefono_2));
            parameters.Add(new NpgsqlParameter("id_condicion_compra", data.id_condicion_compra));
            parameters.Add(new NpgsqlParameter("nro_ingresos_brutos", data.nro_ingresos_brutos));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static void insertarProveedor(ProveedorDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el proveedor
            string sql = "insert into cpc_proveedor(id,nombre,direccion,localidad,provincia,codigo_postal,"
            + " cuit,id_categoria_iva,id_unico,activo,id_condicion_compra,telefono_1,telefono_2, nro_ingresos_brutos)"
            + " values(@id,@nombre,@direccion,@localidad,@provincia,@codigo_postal,"
            + " @cuit,@id_categoria_iva,nextval('cpc_proveedor_id_unico_seq'),'S',@id_condicion_compra,@telefono_1,@telefono_2, @nro_ingresos_brutos);";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("nombre", data.nombre));
            parameters.Add(new NpgsqlParameter("direccion", data.direccion));
            parameters.Add(new NpgsqlParameter("localidad", data.localidad));
            parameters.Add(new NpgsqlParameter("provincia", data.provincia));
            parameters.Add(new NpgsqlParameter("codigo_postal", data.codigo_postal));
            parameters.Add(new NpgsqlParameter("cuit", data.cuit));
            parameters.Add(new NpgsqlParameter("id_categoria_iva", data.id_categoria_iva));
            parameters.Add(new NpgsqlParameter("id_condicion_compra", data.id_condicion_compra));
            parameters.Add(new NpgsqlParameter("telefono_1", data.telefono_1));
            parameters.Add(new NpgsqlParameter("telefono_2", data.telefono_2));
            parameters.Add(new NpgsqlParameter("nro_ingresos_brutos", data.nro_ingresos_brutos));
                
            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            CuentaCorrienteProvDTO.insertar(data.id);
        }


        public static bool existeId(string identificador)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_proveedor where id = @id and activo = 'S'";
            parameters.Add(new NpgsqlParameter("id", identificador));

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


        public static bool existeNombre(string nombre, string codigo)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_proveedor where nombre = @nombre and id <> @codigo and activo = 'S'";
            parameters.Add(new NpgsqlParameter("nombre", nombre));
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

        public static bool existeCUIT(string cuit, string codigo)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from cpc_proveedor where cuit = @cuit and id <> @codigo and activo = 'S'";
            parameters.Add(new NpgsqlParameter("cuit", cuit));
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

        public static ProveedorDTO obtenerNombrePorCodigo(string identificador)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select nombre";
            sql = sql + " from cpc_proveedor";
            sql = sql + " where id = @identificador and activo = 'S'";

            parameters.Add(new NpgsqlParameter("identificador", identificador));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            ProveedorDTO e = new ProveedorDTO();

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {

                e.id = identificador;
                e.nombre = data["nombre"].ToString();

            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return e;
        }

        public static ProveedorDTO obtenerCodPorNombre(string identificador)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id";
            sql = sql + " from cpc_proveedor";
            sql = sql + " where nombre = @identificador and activo = 'S'";

            parameters.Add(new NpgsqlParameter("identificador", identificador));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            ProveedorDTO e = new ProveedorDTO();

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {

                e.id = data["id"].ToString(); ;
                e.nombre = identificador;

            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return e;
        }

        public static string obtenerCuit(string id_proveedor)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string cuit = string.Empty;

            string sql = "select cuit";
            sql = sql + " from cpc_proveedor";
            sql = sql + " where id = @id_proveedor and activo = 'S'";

            parameters.Add(new NpgsqlParameter("id_proveedor", id_proveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                cuit = data["cuit"].ToString();
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cuit;
        }

        public static char obtenerCondicionIva(string codProveedor)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            char idTipo = '\0';

            string sql = "select condicion.valor_adicional tipo_factura";
            sql = sql + " from cpc_proveedor proveedor, ofc_tabla_valor condicion";
            sql = sql + " where proveedor.id_categoria_iva = condicion.id and condicion.id_tabla = 'CI' and proveedor.id = @codProveedor and proveedor.activo = 'S'";

            parameters.Add(new NpgsqlParameter("codProveedor", codProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idTipo = char.Parse(data["tipo_factura"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idTipo;

        }

        public static string obtenerCategoriaIva(string codProveedor) 
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string categoria = string.Empty;

            string sql = "select condicion.valor categoria_iva";
            sql = sql + " from cpc_proveedor proveedor, ofc_tabla_valor condicion";
            sql = sql + " where proveedor.id_categoria_iva = condicion.id and condicion.id_tabla = 'CI' and proveedor.id = @codProveedor and proveedor.activo = 'S'";

            parameters.Add(new NpgsqlParameter("codProveedor", codProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                categoria = data["categoria_iva"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return categoria;

        }

        public static string obtenerCategoriaIvaAbreviado(string codProveedor)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string categoria = string.Empty;

            string sql = "select param.parametro_3 categoria_iva";
            sql = sql + " from cpc_proveedor proveedor, ofc_tabla_valor condicion, ofc_parametro param";
            sql = sql + " where proveedor.id_categoria_iva = condicion.id and param.descripcion = condicion.valor and condicion.id_tabla = 'CI' and proveedor.id = @codProveedor and proveedor.activo = 'S'";

            parameters.Add(new NpgsqlParameter("codProveedor", codProveedor));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                categoria = data["categoria_iva"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return categoria;

        }

        public static List<ProveedorDTO> obtenerProveedoresGrilla(FiltrosABMProveedor filtro)
        {

            List<ProveedorDTO> lista = new List<ProveedorDTO>(); //lista de codigos de proveedores
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select proveedor.id Id, proveedor.nombre Nombre, proveedor.cuit Cuit, proveedor.nro_ingresos_brutos ingresosBrutos, proveedor.provincia Provincia,";
            sql = sql + " proveedor.localidad Localidad, proveedor.direccion Direccion, categoria.valor CategoriaIva, proveedor.codigo_postal codigoPostal, proveedor.telefono_1 tel1, proveedor.telefono_2 tel2,";
            sql = sql + " proveedor.id_categoria_iva idCategoriaIva, condicion.valor CondicionCompra, proveedor.id_condicion_compra idCondicionCompra";
            sql = sql + " from cpc_proveedor proveedor, ofc_tabla_valor categoria, ofc_tabla_valor condicion";
            sql = sql + " where proveedor.id_categoria_iva = categoria.id";
            sql = sql + " and proveedor.id_condicion_compra = condicion.id";
            sql = sql + " and activo = 'S'";

            if (filtro.FiltroCodigo != "")
            {
                sql = sql + " and upper(proveedor.id) like upper(@id_proveedor)";
            }

            if (filtro.FiltroNombre != "")
            {
                sql = sql + " and upper(proveedor.nombre) like upper(@nombre_proveedor)";
            }

            if (filtro.FiltroCUIT != "")
            {
                sql = sql + " and upper(proveedor.cuit) like upper(@cuit_proveedor)";
            }

            sql = sql + " order by proveedor.id";

            parameters.Add(new NpgsqlParameter("id_proveedor", "%" + filtro.FiltroCodigo + "%"));
            parameters.Add(new NpgsqlParameter("nombre_proveedor", "%" + filtro.FiltroNombre + "%"));
            parameters.Add(new NpgsqlParameter("cuit_proveedor", "%" + filtro.FiltroCUIT + "%"));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProveedorDTO e = new ProveedorDTO();

                e.id = data["Id"].ToString();
                e.nombre = data["Nombre"].ToString();
                e.cuit = data["Cuit"].ToString();
                e.nro_ingresos_brutos = data["ingresosBrutos"].ToString();
                e.provincia = data["Provincia"].ToString();
                e.localidad = data["Localidad"].ToString();
                e.direccion = data["Direccion"].ToString();
                e.categoria_iva = data["CategoriaIva"].ToString();
                e.id_categoria_iva = long.Parse(data["idCategoriaIva"].ToString());
                e.condicion_compra = data["CondicionCompra"].ToString();
                e.id_condicion_compra = long.Parse(data["idCondicionCompra"].ToString());
                e.codigo_postal = data["codigoPostal"].ToString();
                e.telefono_1 = data["tel1"].ToString();
                e.telefono_2 = data["tel2"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }


        public static List<ProveedorDTO> obtenerFiltroProveedorDTO()
        {

            List<ProveedorDTO> lista = new List<ProveedorDTO>(); //lista de codigos de proveedores

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, nombre, cuit";
            sql = sql + " from cpc_proveedor where activo = 'S'";
            //sql = sql + " order by id";


            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ProveedorDTO e = new ProveedorDTO();

                e.id = data["id"].ToString();
                e.nombre = data["nombre"].ToString();
                e.cuit = data["cuit"].ToString();

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }




        #endregion



    }
}

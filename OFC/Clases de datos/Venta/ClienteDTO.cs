using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;
using System.Text.RegularExpressions; //feb 1.9.1

namespace OFC
{
    class ClienteDTO
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

        string direccion_legal;

        public string Direccion_legal
        {
            get { return direccion_legal; }
            set { direccion_legal = value; }
        }

        string localidad_legal;

        public string Localidad_legal
        {
            get { return localidad_legal; }
            set { localidad_legal = value; }
        }

        string direccion_comercial;

        public string Direccion_comercial
        {
            get { return direccion_comercial; }
            set { direccion_comercial = value; }
        }

        string localidad_comercial;

        public string Localidad_comercial
        {
            get { return localidad_comercial; }
            set { localidad_comercial = value; }
        }

        string cuit;

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        Decimal descuento;

        public Decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        char factura_por_coche;

        public char Factura_por_coche
        {
            get { return factura_por_coche; }
            set { factura_por_coche = value; }
        }

        long id_vendedor;

        public long Id_vendedor
        {
            get { return id_vendedor; }
            set { id_vendedor = value; }
        }

        string vendedor;

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        long id_lista_precio;

        public long Id_lista_precio
        {
            get { return id_lista_precio; }
            set { id_lista_precio = value; }
        }

        string lista_precio;

        public string Lista_precio
        {
            get { return lista_precio; }
            set { lista_precio = value; }
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


        char sexo;

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        string provincia_legal;

        public string Provincia_legal
        {
            get { return provincia_legal; }
            set { provincia_legal = value; }
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

        long id_condicion_venta;

        public long Id_condicion_venta
        {
            get { return id_condicion_venta; }
            set { id_condicion_venta = value; }
        }

        string condicion_venta;

        public string Condicion_venta
        {
            get { return condicion_venta; }
            set { condicion_venta = value; }
        }

        //inicio feb 1.9.1
        int fw_id_tipo_documento_externo;

        public int Fw_id_tipo_documento_externo
        {
            get { return fw_id_tipo_documento_externo; }
            set { fw_id_tipo_documento_externo = value; }
        }

        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        int fw_id_tipo_persona_externo;

        public int Fw_id_tipo_persona_externo
        {
            get { return fw_id_tipo_persona_externo; }
            set { fw_id_tipo_persona_externo = value; }
        }

        string nombre_persona;

        public string Nombre_persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }

        string apellido_persona;

        public string Apellido_persona
        {
            get { return apellido_persona; }
            set { apellido_persona = value; }
        }

        string codigo_postal;

        public string Codigo_postal
        {
            get { return codigo_postal; }
            set { codigo_postal = value; }
        }

        string telefono_fijo;

        public string Telefono_fijo
        {
            get { return telefono_fijo; }
            set { telefono_fijo = value; }
        }

        string telefono_movil;

        public string Telefono_movil
        {
            get { return telefono_movil; }
            set { telefono_movil = value; }
        }

        int fw_id_condicion_iva_externo;

        public int Fw_id_condicion_iva_externo
        {
            get { return fw_id_condicion_iva_externo; }
            set { fw_id_condicion_iva_externo = value; }
        }

        int fw_id_provincia_externo;

        public int Fw_id_provincia_externo
        {
            get { return fw_id_provincia_externo; }
            set { fw_id_provincia_externo = value; }
        }

        string tipo_persona;

        public string Tipo_persona
        {
            get { return tipo_persona; }
            set { tipo_persona = value; }
        }

        string tipo_documento;

        public string Tipo_documento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }

        //fin feb 1.9.1

        #region Constructor

        public ClienteDTO()
        {
            id = "";
            nombre = "";
            direccion_legal = "";
            localidad_legal = "";
            direccion_comercial = "";
            localidad_comercial = "";
            cuit = "";
            descuento = 0;
            factura_por_coche = 'N';
            id_vendedor = -1;
            vendedor = "";
            id_lista_precio = -1;
            lista_precio = "";
            id_categoria_iva = -1;
            categoria_iva = "";
            sexo = 'M';
            provincia_legal  = "";
            id_unico = -1;
            activo = 'N';
            id_condicion_venta = -1;
            condicion_venta = "";
            fw_id_tipo_documento_externo = -1; //inicio feb 1.9.1
            email = "";
            fw_id_tipo_persona_externo = -1;
            nombre_persona = "";
            apellido_persona = "";
            codigo_postal = "";
            telefono_fijo = "";
            telefono_movil = "";
            fw_id_condicion_iva_externo = -1;
            fw_id_provincia_externo = -1;
            tipo_persona = string.Empty;
            tipo_documento = string.Empty; //fin feb 1.9.1
        }

        #endregion

        #region Métodos


        public static void borrarCliente(string cod_cliente)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "update ofc_cliente set activo = 'N' where id = @cod_cliente;";
            parameters.Add(new NpgsqlParameter("cod_cliente", cod_cliente));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            CuentaCorrienteDTO.borrar(cod_cliente); 

        }

        //feb 1.9.1
        public static void actualizarCliente(ClienteDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el cliente
            string sql = " update ofc_cliente"
                + " set nombre=@nombre, direccion_legal=@direccion_legal, localidad_legal=@localidad_legal, direccion_comercial=@direccion_comercial,"
                + " localidad_comercial=@localidad_comercial, cuit=@cuit, descuento=@descuento, factura_por_coche=@factura_por_coche,"
                + " id_vendedor=@id_vendedor, id_lista_precio=@id_lista_precio, id_categoria_iva=@id_categoria_iva, sexo=@sexo,"
                + " provincia_legal=@provincia_legal, id_condicion_venta=@id_condicion_venta, "
                + " id_tipo_documento_externo=@id_tipo_documento_externo, email=@email, "
                + " id_tipo_persona_externo=@id_tipo_persona_externo, nombre_persona=@nombre_persona, apellido_persona=@apellido_persona, "
                + " codigo_postal=@codigo_postal, telefono_fijo=@telefono_fijo, telefono_movil=@telefono_movil"
                + " WHERE id = @id and activo = 'S'";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("nombre", data.nombre));
            parameters.Add(new NpgsqlParameter("direccion_legal", data.direccion_legal));
            parameters.Add(new NpgsqlParameter("localidad_legal", data.localidad_legal));
            parameters.Add(new NpgsqlParameter("direccion_comercial", data.direccion_comercial));
            parameters.Add(new NpgsqlParameter("localidad_comercial", data.localidad_comercial));
            parameters.Add(new NpgsqlParameter("cuit", data.cuit));
            parameters.Add(new NpgsqlParameter("descuento", data.descuento));
            parameters.Add(new NpgsqlParameter("factura_por_coche", data.factura_por_coche));
            parameters.Add(new NpgsqlParameter("id_vendedor", data.id_vendedor));
            parameters.Add(new NpgsqlParameter("id_lista_precio", data.id_lista_precio));
            parameters.Add(new NpgsqlParameter("id_categoria_iva", data.id_categoria_iva));
            parameters.Add(new NpgsqlParameter("sexo", data.sexo));
            parameters.Add(new NpgsqlParameter("provincia_legal", data.provincia_legal));
            parameters.Add(new NpgsqlParameter("id_condicion_venta", data.id_condicion_venta));
            parameters.Add(new NpgsqlParameter("id_tipo_documento_externo", data.fw_id_tipo_documento_externo));
            parameters.Add(new NpgsqlParameter("email", data.email));
            parameters.Add(new NpgsqlParameter("id_tipo_persona_externo", data.fw_id_tipo_persona_externo));
            parameters.Add(new NpgsqlParameter("nombre_persona", data.nombre_persona));
            parameters.Add(new NpgsqlParameter("apellido_persona", data.apellido_persona));
            parameters.Add(new NpgsqlParameter("codigo_postal", data.codigo_postal));
            parameters.Add(new NpgsqlParameter("telefono_fijo", data.telefono_fijo));
            parameters.Add(new NpgsqlParameter("telefono_movil", data.telefono_movil));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.9.1
        public static void insertarCliente(ClienteDTO data)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            // Insertamos el cliente
            string sql = "insert into ofc_cliente(id,nombre,direccion_legal,localidad_legal,direccion_comercial,localidad_comercial,"
            + " cuit,descuento,factura_por_coche,id_vendedor,id_lista_precio,id_categoria_iva, sexo, provincia_legal, id_unico, activo, id_condicion_venta,"
            + " id_tipo_documento_externo, email, id_tipo_persona_externo, nombre_persona, apellido_persona, codigo_postal, telefono_fijo, telefono_movil)"
            + " values(@id,@nombre,@direccion_legal,@localidad_legal,@direccion_comercial,@localidad_comercial,"
            + " @cuit,@descuento,@factura_por_coche,@id_vendedor,@id_lista_precio,@id_categoria_iva, @sexo, @provincia_legal, nextval('ofc_cliente_id_unico_seq'), 'S', @id_condicion_venta,"
            + " @id_tipo_documento_externo, @email, @id_tipo_persona_externo, @nombre_persona, @apellido_persona, @codigo_postal, @telefono_fijo, @telefono_movil);";

            parameters.Add(new NpgsqlParameter("id", data.id));
            parameters.Add(new NpgsqlParameter("nombre", data.nombre));
            parameters.Add(new NpgsqlParameter("direccion_legal", data.direccion_legal));
            parameters.Add(new NpgsqlParameter("localidad_legal", data.localidad_legal));
            parameters.Add(new NpgsqlParameter("direccion_comercial", data.direccion_comercial));
            parameters.Add(new NpgsqlParameter("localidad_comercial", data.localidad_comercial));
            parameters.Add(new NpgsqlParameter("cuit", data.cuit));
            parameters.Add(new NpgsqlParameter("descuento", data.descuento));
            parameters.Add(new NpgsqlParameter("factura_por_coche", data.factura_por_coche));
            parameters.Add(new NpgsqlParameter("id_vendedor", data.id_vendedor));
            parameters.Add(new NpgsqlParameter("id_lista_precio", data.id_lista_precio));
            parameters.Add(new NpgsqlParameter("id_categoria_iva", data.id_categoria_iva));
            parameters.Add(new NpgsqlParameter("sexo", data.sexo));
            parameters.Add(new NpgsqlParameter("provincia_legal", data.provincia_legal));
            parameters.Add(new NpgsqlParameter("id_condicion_venta", data.id_condicion_venta));
            parameters.Add(new NpgsqlParameter("id_tipo_documento_externo", data.fw_id_tipo_documento_externo));
            parameters.Add(new NpgsqlParameter("email", data.email));
            parameters.Add(new NpgsqlParameter("id_tipo_persona_externo", data.fw_id_tipo_persona_externo));
            parameters.Add(new NpgsqlParameter("nombre_persona", data.nombre_persona));
            parameters.Add(new NpgsqlParameter("apellido_persona", data.apellido_persona));
            parameters.Add(new NpgsqlParameter("codigo_postal", data.codigo_postal));
            parameters.Add(new NpgsqlParameter("telefono_fijo", data.telefono_fijo));
            parameters.Add(new NpgsqlParameter("telefono_movil", data.telefono_movil));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            CuentaCorrienteDTO.insertar(data.id);
        }

        public static bool existeId(string identificador)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_cliente where id = @id and activo = 'S'";
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

            string sql = "select count(1) as cantidad from ofc_cliente where nombre = @nombre and id <> @codigo and activo = 'S'";
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

            string sql = "select count(1) as cantidad from ofc_cliente where cuit = @cuit and id <> @codigo and activo = 'S'";
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

        public static bool existeOrdenAFacturar(string codigo)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_orden_de_trabajo where id_cliente = @codigo";
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

        //feb 1.9.1
        public static List<ClienteDTO> obtenerClientesGrilla(FiltrosABMCliente filtro)
        {

            List<ClienteDTO> lista = new List<ClienteDTO>(); //lista de codigos de clientes
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();

            string sql = "select cliente.id Id, cliente.nombre Nombre, cliente.cuit Cuit, cliente.sexo Sexo, cliente.provincia_legal Provincia,";
            sql = sql + " cliente.localidad_legal Localidad, cliente.direccion_legal Direccion, categoria.valor CategoriaIva, cliente.descuento Descuento,";
            sql = sql + " cliente.factura_por_coche FacturaPorCoche, vendedor.nombre Vendedor, lista_precio.valor ListaDePrecio,";
            sql = sql + " cliente.id_vendedor idVendedor, cliente.id_lista_precio idListaPrecio, cliente.id_categoria_iva idCategoriaIva, condicion.valor CondicionVenta, cliente.id_condicion_venta idCondicionVenta,";
            sql = sql + " cliente.id_tipo_documento_externo idTipoDocumento, cliente.email email, cliente.id_tipo_persona_externo idTipoPersona, cliente.nombre_persona nombrePersona, cliente.apellido_persona apellidoPersona,"; //feb 1.9.1
            sql = sql + " cliente.codigo_postal codigoPostal, cliente.telefono_fijo telefonoFijo, cliente.telefono_movil telefonoMovil"; //feb 1.9.1
            sql = sql + " from ofc_cliente cliente, ofc_tabla_valor categoria, ofc_vendedor vendedor, ofc_tabla_valor lista_precio, ofc_tabla_valor condicion";
            sql = sql + " where cliente.id_categoria_iva = categoria.id";
            sql = sql + " and vendedor.id = cliente.id_vendedor";
            sql = sql + " and lista_precio.id = cliente.id_lista_precio";
            sql = sql + " and cliente.id_condicion_venta = condicion.id";
            sql = sql + " and activo = 'S'";

            if (filtro.FiltroCodigo != "")
            {
                sql = sql + " and upper(cliente.id) like upper(@id_cliente)";
            }

            if (filtro.FiltroNombre != "")
            {
                sql = sql + " and upper(cliente.nombre) like upper(@nombre_cliente)";
            }

            if (filtro.FiltroCUIT != "")
            {
                sql = sql + " and upper(cliente.cuit) like upper(@cuit_cliente)";
            }

            if (filtro.FiltroLocalidad != "")
            {
                sql = sql + " and upper(cliente.localidad_legal) like upper(@localidad)";
            }

            if (filtro.FiltroVendedor != "")
            {
                sql = sql + " and upper(vendedor.nombre) like upper(@vendedor)";
            }

            sql = sql + " order by cliente.id";

            parameters.Add(new NpgsqlParameter("id_cliente", "%" + filtro.FiltroCodigo + "%"));
            parameters.Add(new NpgsqlParameter("nombre_cliente", "%" + filtro.FiltroNombre + "%"));
            parameters.Add(new NpgsqlParameter("cuit_cliente", "%" + filtro.FiltroCUIT + "%"));
            parameters.Add(new NpgsqlParameter("localidad", "%" + filtro.FiltroLocalidad + "%"));
            parameters.Add(new NpgsqlParameter("vendedor", "%" + filtro.FiltroVendedor + "%"));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ClienteDTO e = new ClienteDTO();

                e.id = data["Id"].ToString();
                e.nombre = data["Nombre"].ToString();
                e.cuit = data["Cuit"].ToString();
                e.categoria_iva = data["CategoriaIva"].ToString();
                e.sexo = char.Parse(data["Sexo"].ToString());
                e.provincia_legal = data["Provincia"].ToString();
                e.localidad_legal = data["Localidad"].ToString();
                e.direccion_legal = data["Direccion"].ToString();
                e.descuento = decimal.Parse(data["Descuento"].ToString());
                e.factura_por_coche = char.Parse(data["FacturaPorCoche"].ToString());
                e.vendedor = data["Vendedor"].ToString();
                e.lista_precio = data["ListaDePrecio"].ToString();
                e.id_vendedor = long.Parse(data["idVendedor"].ToString());
                e.id_lista_precio = long.Parse(data["idListaPrecio"].ToString());
                e.id_categoria_iva = long.Parse(data["idCategoriaIva"].ToString());
                e.condicion_venta = data["CondicionVenta"].ToString();
                e.id_condicion_venta = long.Parse(data["idCondicionVenta"].ToString());

                //inicio feb 1.9.1
                if (data["idTipoDocumento"] != null && data["idTipoDocumento"] != DBNull.Value)
                {
                    e.fw_id_tipo_documento_externo = int.Parse(data["idTipoDocumento"].ToString());
                    e.tipo_documento = ValorDTO.obtenerValor("TD", e.fw_id_tipo_documento_externo);
                }

                e.email = data["email"].ToString();

                if (data["idTipoPersona"] != null && data["idTipoPersona"] != DBNull.Value)
                {
                    e.fw_id_tipo_persona_externo = int.Parse(data["idTipoPersona"].ToString());
                    e.tipo_persona = ValorDTO.obtenerValor("TP", e.fw_id_tipo_persona_externo);
                }

                e.nombre_persona = data["nombrePersona"].ToString();
                e.apellido_persona = data["apellidoPersona"].ToString();
                e.codigo_postal = data["codigoPostal"].ToString();
                e.telefono_fijo = data["telefonoFijo"].ToString();
                e.telefono_movil = data["telefonoMovil"].ToString();
                //fin feb 1.9.1

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static List<ClienteDTO> obtenerFiltroClienteDTO()
        {

            List<ClienteDTO> lista = new List<ClienteDTO>(); //lista de codigos de clientes

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, nombre, cuit";
            sql = sql + " from ofc_cliente where activo = 'S'";
            //sql = sql + " order by id";


            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn); //obtengo los cod. de cliente    

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                ClienteDTO e = new ClienteDTO();
                
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

        public static ClienteDTO obtenerNombrePorCodigo(string identificador)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select nombre";
            sql = sql + " from ofc_cliente";
            sql = sql + " where id = @identificador and activo = 'S'";

            parameters.Add(new NpgsqlParameter("identificador", identificador));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            ClienteDTO e = new ClienteDTO();

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

        public static ClienteDTO obtenerCodPorNombre(string identificador)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select id";
            sql = sql + " from ofc_cliente";
            sql = sql + " where nombre = @identificador and activo = 'S'";

            parameters.Add(new NpgsqlParameter("identificador", identificador));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            ClienteDTO e = new ClienteDTO();

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


        //feb

        //antes hay que asegurarse de que el cod de comprobante q ingrese sea unico, para que no devuelva mas de un cliente
        public static string obtenerIdClienteFact(string codComprobante)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string dato = String.Empty;

            string sql = "select fact.id_cliente idCliente";
            sql = sql + " from ofc_comprobante comp, ofc_factura fact";
            sql = sql + " where comp.id_origen = fact.id and comp.id_tipo_comprobante in (select id from ofc_tabla_valor where valor like 'FACTURA%' and id_tabla = 'TC') and comp.cod_comprobante like @codComprobante";

            parameters.Add(new NpgsqlParameter("codComprobante", codComprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                dato = data["idCliente"].ToString();
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return dato;

        }

        
        public static long obtenerIdListaDePrecio(string codCliente)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            long idLista = -1;

            string sql = "select id_lista_precio";
            sql = sql + " from ofc_cliente";
            sql = sql + " where id = @codCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("codCliente", codCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                idLista = long.Parse(data["id_lista_precio"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return idLista;

        }

        public static char obtenerCondicionIva(string codCliente)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            char idTipo = 'N';

            string sql = "select condicion.valor_adicional tipo_factura";
            sql = sql + " from ofc_cliente cliente, ofc_tabla_valor condicion";
            sql = sql + " where cliente.id_categoria_iva = condicion.id and condicion.id_tabla = 'CI' and cliente.id = @codCliente and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("codCliente", codCliente));

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

        //feb 1.7
        public static decimal obtenerDescuento(string codCliente)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            decimal descuento = decimal.Zero;

            string sql = "select descuento";
            sql = sql + " from ofc_cliente";
            sql = sql + " where id = @codCliente and activo = 'S'";

            parameters.Add(new NpgsqlParameter("codCliente", codCliente));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                descuento = decimal.Parse(data["descuento"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return descuento;
        }

        //feb 1.7
        public static decimal obtenerDescuentoPorNombre(string nombre)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            decimal descuento = decimal.Zero;

            string sql = "select descuento";
            sql = sql + " from ofc_cliente";
            sql = sql + " where nombre = @nombre and activo = 'S'";

            parameters.Add(new NpgsqlParameter("nombre", nombre));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                descuento = decimal.Parse(data["descuento"].ToString());
                data.Close();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return descuento;
        }

        //feb 1.9.1
        public static ClienteDTO obtenerDatosFW(string identificador)
        {

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            ClienteDTO cliente = new ClienteDTO();

            string sql = " select cliente.id_tipo_documento_externo id_tipo_documento,";
            sql = sql + " cliente.cuit nro_documento,";
            sql = sql + " cliente.email email,";
            sql = sql + " cliente.id_tipo_persona_externo id_tipo_persona,";
            sql = sql + " cliente.nombre_persona nombre,";
            sql = sql + " cliente.apellido_persona apellido,";
            sql = sql + " cliente.nombre razon_social,";
            sql = sql + " condicion.id_externo id_condicion,";
            sql = sql + " cliente.direccion_legal direccion,";
            sql = sql + " cliente.localidad_legal ciudad,";
            sql = sql + " provincia.id_externo id_provincia,";
            sql = sql + " cliente.codigo_postal cp,";
            sql = sql + " cliente.telefono_fijo telefono,";
            sql = sql + " cliente.telefono_movil celular";
            sql = sql + " from ofc_cliente cliente, ofc_tabla_valor condicion, ofc_tabla_valor provincia";
            sql = sql + " where cliente.id_categoria_iva = condicion.id";
            sql = sql + " and condicion.id_tabla = 'CI'";
            sql = sql + " and cliente.provincia_legal = provincia.valor";
            sql = sql + " and provincia.id_tabla = 'PR'";
            sql = sql + " and cliente.id = @identificador";
            sql = sql + " and cliente.activo = 'S'";

            parameters.Add(new NpgsqlParameter("identificador", identificador));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            //cargo la lista de valores                        
            if (data != null && data.Read())
            {
                cliente.fw_id_tipo_documento_externo = int.Parse(data["id_tipo_documento"].ToString());
                cliente.cuit = data["nro_documento"].ToString();
                cliente.cuit = Regex.Replace(cliente.cuit, @"[^0-9A-Za-z]", "", RegexOptions.Compiled); //quita los caracteres especiales
                cliente.email = data["email"].ToString();
                cliente.fw_id_tipo_persona_externo = int.Parse(data["id_tipo_persona"].ToString());
                if (cliente.fw_id_tipo_persona_externo == 0)
                {
                    cliente.nombre_persona = string.Empty;
                    cliente.apellido_persona = string.Empty;
                    cliente.nombre = data["razon_social"].ToString();
                }
                else
                {
                    cliente.nombre_persona = data["nombre"].ToString();
                    cliente.apellido_persona = data["apellido"].ToString();
                    cliente.nombre = string.Empty;
                }
                cliente.fw_id_condicion_iva_externo = int.Parse(data["id_condicion"].ToString());
                cliente.direccion_legal = data["direccion"].ToString();
                cliente.localidad_legal = data["ciudad"].ToString();
                cliente.fw_id_provincia_externo = int.Parse(data["id_provincia"].ToString());
                cliente.codigo_postal = data["cp"].ToString();
                cliente.telefono_fijo = data["telefono"].ToString();
                cliente.telefono_movil = data["celular"].ToString();

                data.Close();

            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return cliente;
        }


        #endregion



    }
}

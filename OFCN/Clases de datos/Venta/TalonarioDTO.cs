using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;
//feb 1.8
namespace OFC
{
    class TalonarioDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        string usuario_creacion;

        public string Usuario_creacion
        {
            get { return usuario_creacion; }
            set { usuario_creacion = value; }
        }

        public TalonarioDTO()
        {
            id = -1;
            fecha_creacion = DateTime.Now;
            usuario_creacion = string.Empty;
        }

        public static void insertar(TalonarioDTO dataTalonario)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            //genero talonario
            string sql = "INSERT INTO ofc_talonario("
            + " id, fecha_creacion, usuario_creacion)"
            + " VALUES (@id, @fechaCreacion, @usuarioCreacion);";

            parameters.Add(new NpgsqlParameter("id", dataTalonario.id));
            parameters.Add(new NpgsqlParameter("fechaCreacion", DateTime.Now));
            parameters.Add(new NpgsqlParameter("usuarioCreacion", string.Empty)); //a partir de la version 2.0 puede registrarse el usuario

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public static IList<String> obtenerTodos()
        {
            IList<String> lista = new BindingList<String>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id";
            sql = sql + " from ofc_talonario";
            sql = sql + " order by id;";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn);

            //cargo la lista de valores                        
            while (data != null && data.Read())
            {
                String e = data["id"].ToString();
                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static bool existeId(long identificador)
        {

            int count = 0;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select count(1) as cantidad from ofc_talonario where id = @id";
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


    }
}

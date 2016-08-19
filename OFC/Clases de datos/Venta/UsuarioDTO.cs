using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Windows.Forms;

namespace OFC
{
    public class UsuarioDatos
    {

        string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        List<string> listaElementos;

        public List<string> ListaElementos
        {
            get { return listaElementos; }
            set { listaElementos = value; }
        }



        public UsuarioDatos(string p_login)
        {
            login = p_login;
            listaElementos = new List<string>();
        }

        public static UsuarioDatos existeUsuario(string p_login, string p_pass)
        {
            UsuarioDatos user = null;
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select login from ofc_usuario where login like @p_login and pass like @p_pass";
            parameters.Add(new NpgsqlParameter("p_login", p_login));
            parameters.Add(new NpgsqlParameter("p_pass", p_pass));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);
            if (data != null && data.Read())
            {
                user = new UsuarioDatos(data["login"].ToString());
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
            {
                //MessageBox.Show("Cierra conexion", "Conexion");
                cn.Close();
            }

            return user;
        }

        public void loadPermisos(string p_form)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select f.elemento elemento from ofc_usuario u, ofc_rol_elemento r, ofc_formulario_elemento f where u.id_rol = r.id_rol ";
            sql = sql + "and f.id = r.id_formulario_elemento and r.habilitado = 'S' and u.login like @p_login and f.formulario = @p_form";

            parameters.Add(new NpgsqlParameter("p_login", login));
            parameters.Add(new NpgsqlParameter("p_form", p_form));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                string elemento;
                elemento = data["elemento"].ToString();
                listaElementos.Add(elemento);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }

    }
}

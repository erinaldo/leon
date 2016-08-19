using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class VendedorDTO
    {
        long id;

        public long Id
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

        char letra;

        public char Letra
        {
            get { return letra; }
            set { letra = value; }
        }



        #region Métodos

        public static List<VendedorDTO> obtenerFiltroVendedorDTO()
        {

            List<VendedorDTO> lista = new List<VendedorDTO>(); //lista de codigos de vendedores

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, nombre, letra";
            sql = sql + " from ofc_vendedor";
            sql = sql + " order by nombre";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn); //obtengo los vendedores    

            //cargo la lista de vendedores                        
            while (data != null && data.Read())
            {
                VendedorDTO e = new VendedorDTO();
                
                e.id = long.Parse((data["id"].ToString()));
                e.nombre = data["nombre"].ToString();
                e.letra = char.Parse(data["letra"].ToString());

                lista.Add(e);
            }

            if (data != null)
                data.Close();

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            return lista;
        }

        public static IList<VendedorDTO> obtenerVendedores()
        {

            //lista de codigos de vendedores
            IList<VendedorDTO> lista = new BindingList<VendedorDTO>();

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            string sql = "select id, nombre, letra";
            sql = sql + " from ofc_vendedor";
            sql = sql + " order by nombre";

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn); //obtengo los vendedores    

            //cargo la lista de vendedores                        
            while (data != null && data.Read())
            {
                VendedorDTO e = new VendedorDTO();

                e.id = long.Parse((data["id"].ToString()));
                e.nombre = data["nombre"].ToString();
                e.letra = char.Parse(data["letra"].ToString());

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

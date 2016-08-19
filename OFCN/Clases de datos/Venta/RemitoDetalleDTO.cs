using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class RemitoDetalleDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_orden_de_trabajo;

        public long Id_orden_de_trabajo
        {
            get { return id_orden_de_trabajo; }
            set { id_orden_de_trabajo = value; }
        }

        long id_renglon_orden_de_trabajo;

        public long Id_renglon_orden_de_trabajo
        {
            get { return id_renglon_orden_de_trabajo; }
            set { id_renglon_orden_de_trabajo = value; }
        }

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        string codigo;

        public string Codigo
        {
          get { return codigo; }
          set { codigo = value; }
        }

        string descripcion;

        public string Descripcion
        {
          get { return descripcion; }
          set { descripcion = value; }
        }

        public RemitoDetalleDTO()
        {
            id = -1;
            id_orden_de_trabajo = -1;
            id_renglon_orden_de_trabajo = -1;
            cantidad = -1;
            codigo = String.Empty;
            descripcion = String.Empty;
        }

        public static List<RemitoDetalleDTO> obtenerDetalleRem(long idRemito)
        {
            List<RemitoDetalleDTO> lista = new List<RemitoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.descripcion descripcion";
            sql = sql + " from ofc_remito remito, ofc_comprobante_temp c_temp, ofc_remito_detalle det";
            sql = sql + " where remito.id = c_temp.id_origen";
            sql = sql + " and det.id_remito = remito.id";
            sql = sql + " and c_temp.comprobante = 'REMITO'";
            sql = sql + " and remito.id = @idRemito";
            sql = sql + " order by det.id_orden_de_trabajo, det.id_renglon_orden_de_trabajo, det.id";

            parameters.Add(new NpgsqlParameter("idRemito", idRemito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                RemitoDetalleDTO e = new RemitoDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
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

        public static List<RemitoDetalleDTO> obtenerDetalleRemReg(long idRemito)
        {
            List<RemitoDetalleDTO> lista = new List<RemitoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.codigo codigo, det.descripcion descripcion";
            sql = sql + " from ofc_remito remito, ofc_remito_detalle det";
            sql = sql + " where det.id_remito = remito.id";
            sql = sql + " and remito.id = @idRemito";
            sql = sql + " order by det.id_orden_de_trabajo, det.id_renglon_orden_de_trabajo, det.id";

            parameters.Add(new NpgsqlParameter("idRemito", idRemito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                RemitoDetalleDTO e = new RemitoDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
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


    }
}

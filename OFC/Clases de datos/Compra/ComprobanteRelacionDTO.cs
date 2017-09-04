using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class ComprobanteRelacionDTO
    {
        string id_proveedor;

        //nueva relacion para la factura electronica

        public string Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        long id_tipo_comprobante_padre;

        public long Id_tipo_comprobante_padre
        {
            get { return id_tipo_comprobante_padre; }
            set { id_tipo_comprobante_padre = value; }
        }

        string cod_comprobante_padre;

        public string Cod_comprobante_padre
        {
            get { return cod_comprobante_padre; }
            set { cod_comprobante_padre = value; }
        }

        long id_tipo_comprobante_hijo;

        public long Id_tipo_comprobante_hijo
        {
            get { return id_tipo_comprobante_hijo; }
            set { id_tipo_comprobante_hijo = value; }
        }

        string cod_comprobante_hijo;

        public string Cod_comprobante_hijo
        {
            get { return cod_comprobante_hijo; }
            set { cod_comprobante_hijo = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        decimal importe_padre;

        public decimal Importe_padre
        {
            get { return importe_padre; }
            set { importe_padre = value; }
        }

        decimal importe_hijo;

        public decimal Importe_hijo
        {
            get { return importe_hijo; }
            set { importe_hijo = value; }
        }

        public ComprobanteRelacionDTO()
        {
            id_proveedor = string.Empty;
            id_tipo_comprobante_padre = -1;
            cod_comprobante_padre = string.Empty;
            id_tipo_comprobante_hijo = -1;
            cod_comprobante_hijo = string.Empty;
            fecha_creacion = DateTime.Now;
            importe_padre = decimal.Zero;
            importe_hijo = decimal.Zero;
        }

        public static void insertar(ComprobanteRelacionDTO dataRelacion)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_comprobante_relacion(";
            sql = sql + "id_proveedor, id_tipo_comprobante_padre, cod_comprobante_padre, id_tipo_comprobante_hijo, cod_comprobante_hijo, fecha_creacion, importe_padre, importe_hijo)";
            sql = sql + " VALUES (@id_proveedor, @id_tipo_comprobante_padre, @cod_comprobante_padre, @id_tipo_comprobante_hijo, @cod_comprobante_hijo, @fecha_creacion, @importe_padre, @importe_hijo);";

            parameters.Add(new NpgsqlParameter("id_proveedor", dataRelacion.id_proveedor));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante_padre", dataRelacion.id_tipo_comprobante_padre));
            parameters.Add(new NpgsqlParameter("cod_comprobante_padre", dataRelacion.cod_comprobante_padre));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante_hijo", dataRelacion.id_tipo_comprobante_hijo));
            parameters.Add(new NpgsqlParameter("cod_comprobante_hijo", dataRelacion.cod_comprobante_hijo));
            parameters.Add(new NpgsqlParameter("fecha_creacion", dataRelacion.fecha_creacion));
            parameters.Add(new NpgsqlParameter("importe_padre", dataRelacion.importe_padre));
            parameters.Add(new NpgsqlParameter("importe_hijo", dataRelacion.importe_hijo));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

    }
}

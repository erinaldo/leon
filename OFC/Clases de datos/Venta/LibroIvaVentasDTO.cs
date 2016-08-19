using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class LibroIvaVentasDTO
    {
        long id_tipo_comprobante;
        string cod_comprobante;
        string id_cliente;
        string nombre_cliente;
        string cuit_cliente;
        decimal neto_gravado;
        decimal iva;
        decimal total;
        DateTime fecha;
        string desc_categoria_iva;
        decimal iva_105;
        decimal neto_no_gravado;

        public LibroIvaVentasDTO()
        {
            id_tipo_comprobante = -1;
            cod_comprobante = string.Empty;
            id_cliente = string.Empty;
            nombre_cliente = string.Empty;
            cuit_cliente = string.Empty;
            neto_gravado = decimal.Zero;
            iva = decimal.Zero;
            total = decimal.Zero;
            fecha = DateTime.Now;
            desc_categoria_iva = string.Empty;
            iva_105 = decimal.Zero;
            neto_no_gravado = decimal.Zero;
        }

        public LibroIvaVentasDTO(FacturaDTO f, long idTipoComprobante, string codComprobante, char anula, char iva105)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = codComprobante;
            id_cliente = f.Id_cliente;
            nombre_cliente = f.Nombre_cliente;
            cuit_cliente = f.Cuit;
            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                iva = decimal.Zero;
                iva_105 = decimal.Zero;
                total = decimal.Zero;
            }
            if (anula == 'N')
            {
                neto_gravado = f.Subtotal;
                if (iva105 == 'N')
                {
                    iva = f.Iva;
                    iva_105 = decimal.Zero;
                }
                else
                {
                    iva = decimal.Zero;
                    iva_105 = f.Iva;
                }
                total = f.Total;
            }
            fecha = DateTime.Now;
            desc_categoria_iva = ParametroDTO.obtenerParametroIII(f.Categoria_iva);
        }

        public LibroIvaVentasDTO(NotaDebitoDTO d, long idTipoComprobante, string codComprobante, char anula)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = codComprobante;
            id_cliente = d.Id_cliente;
            nombre_cliente = d.Nombre_cliente;
            cuit_cliente = d.Cuit;
            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                iva = decimal.Zero;
                total = decimal.Zero;
                neto_no_gravado = decimal.Zero;
            }
            if (anula == 'N')
            {
                neto_gravado = d.Subtotal;
                iva = d.Iva;
                total = d.Total;
                neto_no_gravado = d.No_gravado;
            }
            fecha = DateTime.Now;
            desc_categoria_iva = ParametroDTO.obtenerParametroIII(d.Categoria_iva);
        }

        public LibroIvaVentasDTO(NotaCreditoDTO n, long idTipoComprobante, string codComprobante, char anula)
        {
            id_tipo_comprobante = idTipoComprobante;
            cod_comprobante = codComprobante;
            id_cliente = n.Id_cliente;
            nombre_cliente = n.Nombre_cliente;
            cuit_cliente = n.Cuit;
            if (anula == 'N')
            {
                neto_gravado = n.Subtotal * (-1);
                iva = n.Iva * (-1);
                total = n.Total * (-1);
            }
            if (anula == 'S')
            {
                neto_gravado = decimal.Zero;
                iva = decimal.Zero;
                total = decimal.Zero;
            }
            fecha = DateTime.Now;
            desc_categoria_iva = ParametroDTO.obtenerParametroIII(n.Categoria_iva);
        }

        public void registrar()
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO ofc_libro_iva_ventas(id, id_tipo_comprobante, cod_comprobante, id_cliente, nombre_cliente, cuit_cliente, neto_gravado, iva, total, fecha, desc_categoria_iva, iva_105, neto_no_gravado) VALUES (nextval('ofc_libro_iva_ventas_id_seq'), @id_tipo_comprobante, @cod_comprobante, @id_cliente, @nombre_cliente, @cuit_cliente, @neto_gravado, @iva, @total, @fecha, @desc_categoria_iva, @iva_105, @neto_no_gravado);";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_cliente", id_cliente));
            parameters.Add(new NpgsqlParameter("nombre_cliente", nombre_cliente));
            parameters.Add(new NpgsqlParameter("cuit_cliente", cuit_cliente));
            parameters.Add(new NpgsqlParameter("neto_gravado", neto_gravado));
            parameters.Add(new NpgsqlParameter("iva", iva));
            parameters.Add(new NpgsqlParameter("total", total));
            parameters.Add(new NpgsqlParameter("fecha", fecha));
            parameters.Add(new NpgsqlParameter("desc_categoria_iva", desc_categoria_iva));
            parameters.Add(new NpgsqlParameter("iva_105", iva_105));
            parameters.Add(new NpgsqlParameter("neto_no_gravado", neto_no_gravado));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        public void actualizar(long id_tipo_comprobante_an)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "UPDATE ofc_libro_iva_ventas set id_cliente = @id_cliente_an, nombre_cliente = @nombre_cliente_an, cuit_cliente = @cuit_cliente_an, desc_categoria_iva = @desc_categoria_iva_an, neto_gravado = @neto_gravado, iva = @iva, total = @total, fecha = @fecha, iva_105 = @iva_105, neto_no_gravado = @neto_no_gravado, id_tipo_comprobante = @id_tipo_comprobante_an where id_tipo_comprobante = @id_tipo_comprobante and cod_comprobante = @cod_comprobante and id_cliente = @id_cliente;";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("id_tipo_comprobante_an", id_tipo_comprobante_an));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));
            parameters.Add(new NpgsqlParameter("id_cliente", id_cliente));
            parameters.Add(new NpgsqlParameter("neto_gravado", neto_gravado));
            parameters.Add(new NpgsqlParameter("iva", iva));
            parameters.Add(new NpgsqlParameter("total", total));
            parameters.Add(new NpgsqlParameter("fecha", fecha));
            parameters.Add(new NpgsqlParameter("iva_105", iva_105));
            parameters.Add(new NpgsqlParameter("neto_no_gravado", neto_no_gravado));
            parameters.Add(new NpgsqlParameter("id_cliente_an", string.Empty));
            parameters.Add(new NpgsqlParameter("nombre_cliente_an", string.Empty));
            parameters.Add(new NpgsqlParameter("cuit_cliente_an", string.Empty));
            parameters.Add(new NpgsqlParameter("desc_categoria_iva_an", string.Empty));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //feb 1.9.1
        public static decimal obtenerSubtotal(string cod_comprobante, string tipo_comprobante_desc)
        {
            decimal subtotal = decimal.Zero;
            long id_tipo_comprobante = ValorDTO.obtenerId(tipo_comprobante_desc);

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select neto_gravado"
                 + " from ofc_libro_iva_ventas"
                 + " where id_tipo_comprobante = @id_tipo_comprobante"
                 + " and cod_comprobante = @cod_comprobante";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                subtotal = decimal.Parse(data["neto_gravado"].ToString());
                data.Close();
            }

            return subtotal;
        }

        //feb 1.9.1
        public static decimal obtenerIva(string cod_comprobante, string tipo_comprobante_desc)
        {
            decimal iva = decimal.Zero;
            long id_tipo_comprobante = ValorDTO.obtenerId(tipo_comprobante_desc);

            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select iva"
                 + " from ofc_libro_iva_ventas"
                 + " where id_tipo_comprobante = @id_tipo_comprobante"
                 + " and cod_comprobante = @cod_comprobante";

            parameters.Add(new NpgsqlParameter("id_tipo_comprobante", id_tipo_comprobante));
            parameters.Add(new NpgsqlParameter("cod_comprobante", cod_comprobante));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            if (data != null && data.Read())
            {
                iva = decimal.Parse(data["iva"].ToString());
                data.Close();
            }

            return iva;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    public class IvaComprasDetalleDTO
    {
        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        long id_iva;

        public long Id_iva
        {
            get { return id_iva; }
            set { id_iva = value; }
        }

        string desc_iva;

        public string Desc_iva
        {
            get { return desc_iva; }
            set { desc_iva = value; }
        }

        string v_porcentaje;

        public string V_porcentaje
        {
            get { return v_porcentaje; }
            set { v_porcentaje = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
        }

        public IvaComprasDetalleDTO()
        {
            id_factura = -1;
            id_iva = -1;
            desc_iva = string.Empty;
            v_porcentaje = string.Empty;
            importe = decimal.Zero;
            v_importe = string.Empty;
        }

        public static List<IvaComprasDetalleDTO> obtenerIvaReg(long idOrigen, string tipo)
        {
            List<IvaComprasDetalleDTO> lista = new List<IvaComprasDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            string sql = string.Empty;

            if (tipo == "FA")
            {
                sql = "select factura.id_factura idOrigen, factura.id_iva idIva, val.valor descIva, val.valor_adicional porcentaje, factura.importe importe";
                sql = sql + " from cpc_factura_iva factura, ofc_tabla_valor val";
                sql = sql + " where val.id = factura.id_iva and factura.id_factura = @idOrigen";
                sql = sql + " order by factura.id_iva";
            }
            if (tipo == "NC")
            {
                sql = "select credito.id_nota_credito idOrigen, credito.id_iva idIva, val.valor descIva, val.valor_adicional porcentaje, credito.importe importe";
                sql = sql + " from cpc_nota_credito_iva credito, ofc_tabla_valor val";
                sql = sql + " where val.id = credito.id_iva and credito.id_nota_credito = @idOrigen";
                sql = sql + " order by credito.id_iva";
            }
            if (tipo == "ND")
            {
                sql = "select debito.id_nota_debito idOrigen, debito.id_iva idIva, val.valor descIva, val.valor_adicional porcentaje, debito.importe importe";
                sql = sql + " from cpc_nota_debito_iva debito, ofc_tabla_valor val";
                sql = sql + " where val.id = debito.id_iva and debito.id_nota_debito = @idOrigen";
                sql = sql + " order by debito.id_iva";
            }

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                IvaComprasDetalleDTO e = new IvaComprasDetalleDTO();

                e.id_factura = long.Parse(data["idOrigen"].ToString());
                e.id_iva = long.Parse(data["idIva"].ToString());
                e.desc_iva = data["descIva"].ToString();
                e.importe = decimal.Parse(data["importe"].ToString());

                e.v_porcentaje = String.Format("{0:0.00}",decimal.Parse(data["porcentaje"].ToString()));
                e.v_importe = String.Format("{0:0.00}", Math.Round(e.importe, 2, MidpointRounding.AwayFromZero));

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    public class ImpuestoDetalleDTO
    {
        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        //bug arreglado

        long id_impuesto;

        public long Id_impuesto
        {
            get { return id_impuesto; }
            set { id_impuesto = value; }
        }

        string desc_impuesto;

        public string Desc_impuesto
        {
            get { return desc_impuesto; }
            set { desc_impuesto = value; }
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

        public ImpuestoDetalleDTO()
        {
            id_factura = -1;
            id_impuesto = -1;
            desc_impuesto = string.Empty;
            v_porcentaje = string.Empty;
            importe = decimal.Zero;
            v_importe = string.Empty;
        }

        public static List<ImpuestoDetalleDTO> obtenerImpuestosReg(long idOrigen, string tipo)
        {
            List<ImpuestoDetalleDTO> lista = new List<ImpuestoDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = string.Empty;

            if (tipo == "FA")
            {
                sql = "select factura.id_factura idOrigen, factura.id_impuesto idImpuesto, val.valor descImpuesto, val.valor_adicional porcentaje, factura.importe importe";
                sql = sql + " from cpc_factura_impuesto factura, ofc_tabla_valor val";
                sql = sql + " where val.id = factura.id_impuesto and factura.id_factura = @idOrigen";
                sql = sql + " order by factura.id_impuesto";
            }
            if (tipo == "NC")
            {
                sql = "select credito.id_nota_credito idOrigen, credito.id_impuesto idImpuesto, val.valor descImpuesto, val.valor_adicional porcentaje, credito.importe importe";
                sql = sql + " from cpc_nota_credito_impuesto credito, ofc_tabla_valor val";
                sql = sql + " where val.id = credito.id_impuesto and credito.id_nota_credito = @idOrigen";
                sql = sql + " order by credito.id_impuesto";
            }
            if (tipo == "ND")
            {
                sql = "select debito.id_nota_debito idOrigen, debito.id_impuesto idImpuesto, val.valor descImpuesto, val.valor_adicional porcentaje, debito.importe importe";
                sql = sql + " from cpc_nota_debito_impuesto debito, ofc_tabla_valor val";
                sql = sql + " where val.id = debito.id_impuesto and debito.id_nota_debito = @idOrigen";
                sql = sql + " order by debito.id_impuesto";
            }

            parameters.Add(new NpgsqlParameter("idOrigen", idOrigen));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                ImpuestoDetalleDTO e = new ImpuestoDetalleDTO();

                e.id_factura = long.Parse(data["idOrigen"].ToString());
                e.id_impuesto = long.Parse(data["idImpuesto"].ToString());
                e.desc_impuesto = data["descImpuesto"].ToString();
                e.importe = decimal.Parse(data["importe"].ToString());

                e.v_porcentaje = String.Format("{0:0.00}", decimal.Parse(data["porcentaje"].ToString()));
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

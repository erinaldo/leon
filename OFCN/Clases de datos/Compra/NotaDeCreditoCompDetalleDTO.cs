using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class NotaDeCreditoCompDetalleDTO
    {
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        long id_concepto;

        public long Id_concepto
        {
            get { return id_concepto; }
            set { id_concepto = value; }
        }

        long id_producto;

        public long Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        Decimal precio_unitario;

        public Decimal Precio_unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }

        Decimal importe;

        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        long id_nota_credito;

        public long Id_nota_credito
        {
            get { return id_nota_credito; }
            set { id_nota_credito = value; }
        }

        DateTime fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
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

        string v_importe;

        public string V_importe
        {
            get { return v_importe; }
            set { v_importe = value; }
        }

        string v_precio_unitario;

        public string V_precio_unitario
        {
            get { return v_precio_unitario; }
            set { v_precio_unitario = value; }
        }

        char exento;

        public char Exento
        {
            get { return exento; }
            set { exento = value; }
        }

        string unidad;

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public NotaDeCreditoCompDetalleDTO()
        {
            id = -1;
            id_concepto = -1;
            id_producto = -1;
            cantidad = -1;
            fecha_creacion = DateTime.Now;
            importe = Decimal.Zero;
            v_importe = String.Empty;
            precio_unitario = Decimal.Zero;
            v_precio_unitario = String.Empty;
            codigo = String.Empty;
            descripcion = String.Empty;
            id_nota_credito = -1;
            exento = 'N';
            unidad = String.Empty;
        }

        public static List<NotaDeCreditoCompDetalleDTO> obtenerDetalleNCReg(long idNotaDeCredito)
        {
            List<NotaDeCreditoCompDetalleDTO> lista = new List<NotaDeCreditoCompDetalleDTO>();
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "select det.cantidad cantidad, det.unidad unidad, det.codigo codigo, det.descripcion descripcion, det.precio_unitario pUnitario, det.importe importe";
            sql = sql + " from cpc_nota_credito credito, cpc_nota_credito_detalle det";
            sql = sql + " where det.id_nota_credito = credito.id and credito.id = @idNotaDeCredito";
            sql = sql + " order by det.id";

            parameters.Add(new NpgsqlParameter("idNotaDeCredito", idNotaDeCredito));

            NpgsqlDataReader data = BaseDeDatos.ejecutarQuery(sql, cn, parameters);

            while (data != null && data.Read())
            {
                NotaDeCreditoCompDetalleDTO e = new NotaDeCreditoCompDetalleDTO();

                e.cantidad = int.Parse(data["cantidad"].ToString());
                e.codigo = data["codigo"].ToString();
                e.descripcion = data["descripcion"].ToString();
                e.precio_unitario = decimal.Parse(data["pUnitario"].ToString());
                e.importe = decimal.Parse(data["importe"].ToString());
                e.unidad = data["unidad"].ToString();

                e.v_precio_unitario = String.Format("{0:0.00}", Math.Round(e.precio_unitario, 2, MidpointRounding.AwayFromZero));
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

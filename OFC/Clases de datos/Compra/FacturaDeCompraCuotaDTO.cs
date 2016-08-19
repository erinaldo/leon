using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.ComponentModel;

namespace OFC
{
    class FacturaDeCompraCuotaDTO
    {
        long id_factura;

        public long Id_factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        DateTime fecha_vencimiento;

        public DateTime Fecha_vencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
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

        //string estado;

        //public string Estado
        //{
        //  get { return estado; }
        //  set { estado = value; }
        //}
        
        public FacturaDeCompraCuotaDTO()
        {
            id_factura = -1;
            numero = -1;
            fecha_vencimiento = DateTime.Now;
            importe = decimal.Zero;
            v_importe = string.Empty;
            //estado = string.Empty;
        }

        public static void insert(FacturaDeCompraCuotaDTO cuota)
        {
            NpgsqlConnection cn = BaseDeDatos.obtenerConexion();
            IList<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            string sql = "INSERT INTO cpc_factura_cuota("
            + " id_factura, numero, fecha_vencimiento, importe)"
            + " VALUES (@id_factura, @numero, @fecha_vencimiento, @importe);";

            //detalle del registro facturable
            parameters.Add(new NpgsqlParameter("id_factura", cuota.id_factura));
            parameters.Add(new NpgsqlParameter("numero", cuota.numero));
            parameters.Add(new NpgsqlParameter("fecha_vencimiento", cuota.fecha_vencimiento));
            parameters.Add(new NpgsqlParameter("importe", cuota.importe));

            BaseDeDatos.ejecutarNonQuery(sql, cn, parameters);

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();
        }

        //public FacturaDeCompraCuotaDTO obtenerCuotas(DateTime fecha_desde)
        //{
        //    FacturaDeCompraCuotaDTO cuota = new FacturaDeCompraCuotaDTO();

        //    return cuota;
        //}


    }
}

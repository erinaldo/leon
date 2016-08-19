using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace OFC
{
    class GenerarArchivo
    {
        public static void generar_archivo_csv(DataSet ds, String path, String table_name)
        {
            String[] texto;
            texto = new String[ds.Tables[table_name].Rows.Count + 1];
            //Rellenamos la cabecera del fichero
            texto[0] = String.Empty;
            for (int i = 0; i < ds.Tables[table_name].Columns.Count; i++)
            {
                texto[0] += ds.Tables[table_name].Columns[i].ColumnName + ",";
            }
            //Rellenamos el detalle del fichero
            String linea;
            for (int i = 0; i < ds.Tables[table_name].Rows.Count; i++)
            {
                linea = String.Empty;
                for (int j = 0; j < ds.Tables[table_name].Columns.Count; j++)
                {
                    linea += ds.Tables[table_name].Rows[i][j].ToString() + ",";
                }
                texto[i + 1] = linea;
            }
            File.WriteAllLines(path + ".csv", texto);
        }

    }
}

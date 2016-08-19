using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BK_DB_OFC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BaseDeDatos db = new BaseDeDatos();
                db.loadParametersAndBackup();
                string[] cadena = new string[1];
                cadena[0] = System.DateTime.Today.ToLongDateString() + ". Backup DB Exitoso.";
                logger(cadena);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    string[] cadena = new string[3];
                    cadena[0] = System.DateTime.Today.ToLongDateString();
                    cadena[1] = ex.Message;
                    cadena[2] = ex.InnerException.Message;
                    logger(cadena);
                }
                
            }
        }

        static void logger(string[] texto)
        {
            File.WriteAllLines("C:/backup/script/log.txt", texto);
        }
    }
}

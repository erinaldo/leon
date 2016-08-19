using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace BK_DB_OFC
{
    public class BaseDeDatos
    {
        public void loadParametersAndBackup()
        {
            try
            {
                if (File.Exists("C:/backup/script/config.ini"))
                {
                    IDictionary data = new Hashtable(); //cache
                    string[] parameters = File.ReadAllLines("C:/backup/script/config.ini");
                    foreach (string par in parameters)
                    {
                        if (!par.StartsWith("#"))
                        {
                            string[] splitResult = par.Split(';');
                            if (splitResult.Length == 2)
                            {
                                if (splitResult[0].Trim() == "password")
                                {
                                    Encriptacion datosConexion = new Encriptacion();
                                    data.Add(splitResult[0].Trim(), datosConexion.Desencriptar(splitResult[1].Trim()));
                                }
                                else
                                {
                                    data.Add(splitResult[0].Trim(), splitResult[1].Trim());
                                }
                            }
                        }
                        else
                        {
                            if (!realizarBackUp(data["dbname"].ToString(), data["password"].ToString()))
                            {
                                throw new Exception("Excepcion al lanzar el proceso de backup: " + data["dbname"].ToString());
                            }

                            data.Clear(); //limpio el cache
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Excepcion General. No fue posible realizar el backup de la base de datos del Sistema OFC. Asegúrese de configurar el archivo config.ini con los parámetros correspondientes.");
            }
        }

        private bool realizarBackUp(string db, string pass)
        {
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:/backup/script/backupDB.bat";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = db + " " + pass;
            try
            {
                Process exeProcess = Process.Start(startInfo);
            }
            catch
            {
                return false;
            }

            return true;
        }

    }

}



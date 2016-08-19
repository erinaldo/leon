using System;
using System.Collections.Generic;
using Npgsql;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace OFC
{
    public class BaseDeDatos
    {
        private static String myConnectionString = null;

        public static String MyConnectionString
        {
            get { return BaseDeDatos.myConnectionString; }
            set { BaseDeDatos.myConnectionString = value; }
        }

        public static String empresa;

        public static NpgsqlConnection obtenerConexion()
        {
            NpgsqlConnection cn = null;
            if (myConnectionString == null)
                loadConnectionString();

            cn = new NpgsqlConnection(myConnectionString);
            cn.Open();
            return cn;
        }

        private static void loadConnectionString()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\config.ini"))
                {
                    IDictionary data = new Hashtable();
                    string[] parameters = File.ReadAllLines(Application.StartupPath + "\\config.ini");
                    int s = 0;
                    foreach (string par in parameters)
                    {
                        if (par.StartsWith("//"))
                        {
                            if (par.Substring(2).Equals(empresa)) //input
                            {
                                s = 1;
                            }
                            else
                            {
                                s = 0;
                            }
                        }
                        if (s == 1)
                        {
                            string[] splitResult = par.Split(';');
                            if (splitResult.Length == 2)
                            {
                                if (splitResult[0].Trim() == "user" || splitResult[0].Trim() == "password")
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
                    }

                    //feb 2.3
                    string hostaddress = string.Empty;

                    if (data["ifserver"].ToString() == "true")
                    {
                        hostaddress = data["hostaddr"].ToString();
                    }
                    else
                    {
                        string[] parametersClient = File.ReadAllLines(data["pathConfigClient"].ToString() + "\\ipServer.ini");
                        hostaddress = parametersClient[0].Trim();
                    }

                    myConnectionString = "Server=" + hostaddress + ";Port=" + data["port"].ToString() + ";UserId=" + data["user"].ToString() + ";Password=" + data["password"].ToString() + ";Database=" + data["dbname"].ToString() + ";Pooling=" + data["pooling"].ToString() + ";";
                    
                }
            }
            catch
            {
                throw new Exception("No fue posible establecer la conexión con la base de datos. Asegúrese de configurar el archivo config.ini con los parámetros correspondientes.");
            }
        }


        public static int ejecutarNonQuery(string sql, NpgsqlConnection cn, IList<NpgsqlParameter> parameters)
        {
            int rv = 0;
            NpgsqlCommand cmd = cn.CreateCommand();
            foreach (var par in parameters) //agregamos parámetros
                cmd.Parameters.Add(par);
            cmd.CommandText = sql;
            cmd.CommandTimeout = 0; //no corta la conexion
            rv = cmd.ExecuteNonQuery();
            return rv;
        }

        public static NpgsqlDataReader ejecutarQuery(string sql, NpgsqlConnection cn)
        {
            return ejecutarQuery(sql, cn, new List<NpgsqlParameter>());
        }

        public static NpgsqlDataReader ejecutarQuery(string sql, NpgsqlConnection cn, IList<NpgsqlParameter> parameters)
        {
            NpgsqlCommand cmd = cn.CreateCommand();
            NpgsqlDataReader data = null;
            foreach (var par in parameters)
                cmd.Parameters.Add(par);
            cmd.CommandText = sql;
            cmd.CommandTimeout = 0;
            data = cmd.ExecuteReader();
            return data;
        }

        public static string getParametroConexion(string parametro){

            int positionInicioBase = MyConnectionString.IndexOf(parametro);
            int positionMedioBase = MyConnectionString.IndexOf('=', positionInicioBase);
            int positionFinBase = MyConnectionString.IndexOf(';', positionMedioBase);
            return MyConnectionString.Substring(positionMedioBase + 1, positionFinBase - positionMedioBase - 1);

        }

        public static bool realizarBackUp(){
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:/backup/script/backupDB.bat";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = BaseDeDatos.getParametroConexion("Database") + " " + BaseDeDatos.getParametroConexion("Password");
            
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



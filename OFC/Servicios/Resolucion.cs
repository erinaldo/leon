using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace OFC
{
    class Resolucion
    {
        private static string escalar = string.Empty;
        private float f_HeightRatio = new float();
        private float f_WidthRatio = new float();
        
        public static bool Escalar()
        {
            if (escalar == string.Empty)
                loadResolution();
            if (escalar == "on")
                return true;
            else
                return false;
        }

        private static void loadResolution()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\resolucion.ini"))
                {
                    IDictionary data = new Hashtable();
                    string[] parameters = File.ReadAllLines(Application.StartupPath + "\\resolucion.ini");
                    foreach (string par in parameters)
                    {
                        string[] splitResult = par.Split(':');
                        if (splitResult.Length == 2)
                        {
                            data.Add(splitResult[0].Trim(), splitResult[1].Trim());
                        }
                    }
                    escalar = data["escalar"].ToString();
                }
            }
            catch
            {
                throw new Exception("No fue posible establecer la resolución de la pantalla. Asegúrese de configurar el archivo resolucion.ini con los parámetros correspondientes.");
            }
        }

        public void ResizeForm(Form ObjForm, int ancho, int alto)
        {
            #region Code for Resizing and Font Change According to Resolution
            int i_StandardHeight = alto; //alto por defecto
            int i_StandardWidth = ancho; //ancho por defecto
            int i_PresentHeight = Screen.PrimaryScreen.Bounds.Height;//Present Resolution Height
            int i_PresentWidth = Screen.PrimaryScreen.Bounds.Width;//Presnet Resolution Width
            f_HeightRatio = (float)((float)i_PresentHeight / (float)i_StandardHeight);
            f_WidthRatio = (float)((float)i_PresentWidth / (float)i_StandardWidth);
            ObjForm.AutoScaleMode = AutoScaleMode.None;//Make the Autoscale Mode=None
            ObjForm.Scale(new SizeF(f_WidthRatio, f_HeightRatio));
            #endregion
        }

        
    }
}

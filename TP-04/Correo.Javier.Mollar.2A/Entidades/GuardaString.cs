using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            try
            {
                string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);
                StreamWriter escribir = new StreamWriter(strPath + "//" + archivo, true);
                escribir.WriteLine(texto + "\n");
                escribir.Close();
                retorno = true;
            }
            catch (Exception e)
            { }
            return retorno;
        }
    }
}

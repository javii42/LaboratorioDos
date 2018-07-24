using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Burbujeo
    {
        public Burbujeo() {

        }

        public static void MetodoClase() {
            try
            {
                Burbujeo b = new Burbujeo();
                b.MetodoInstancia();
            }
            catch (MiException e) {
                Burbujeo.EscribirArchivo(e.Message);
                throw new MiException("MetodoClase");
            }
        }

        public void MetodoInstancia() {
            throw new MiException("MetodoInstancia");
        }

        public static bool EscribirArchivo(string msg) {
            bool retorno = true;
            try
            {
                StreamWriter escribir = new StreamWriter(@"E:\javii\Documents\Facultad\archivo.txt", true);
                escribir.WriteLine(msg + " - " +DateTime.Now);
                escribir.Close();
            }
            catch (Exception e)
            {
                retorno = false;
            }
            return retorno;
        }
        public static string LeerArchivo()
        {
            string linea;
            string textoRecuperado = "";
            try
            {

                StreamReader leer = new StreamReader(@"E:\javii\Documents\Facultad\archivo.txt");
                while ((linea = leer.ReadLine()) != null)
                {
                    textoRecuperado += linea + "\n";
                }
                leer.Close();
            }
            catch (Exception e)
            { }
            return textoRecuperado;
        }
    }
}

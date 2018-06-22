using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comando;

        static PaqueteDAO()
        {

        }
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            int cant;
            string query = "Insert into  dbo.Paquetes (direccionEntrega,trackingID,alumno) values ('" + p.DireccionEntrega + "','"
                    + p.TrackingID + "', 'Javier Mollar')";
            //Console.WriteLine(query + "\n\n");
           try
           {
                _conexion = new SqlConnection(Properties.Settings.Default.conexion);
                _comando = new SqlCommand(query, _conexion);
                _conexion.Open();
                // SqlDataReader lector = comando.ExecuteReader();
                cant = _comando.ExecuteNonQuery();
                _conexion.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la base de datos");
            }
            return retorno;
        }
    }
}

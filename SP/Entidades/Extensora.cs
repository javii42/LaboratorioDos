using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public static class Extensora
    {
        public static string MostrarBD(this Producto p) {
            string retorno = "";
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM dbo.productos", conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                //lector[1].ToString();//devuelve el nombre 
                //lector["id"];//devuelve un object del id
                retorno += "Nombre= " + lector[0].ToString() 
                    + " - Stock: " +lector[1].ToString() + "\n";
            }
            lector.Close();
            conexion.Close();
            return retorno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string _nombre;
        public int _stock;
        public string nombre { get { return this._nombre; } }
        public int stock { get { return this._stock; } }

        public Producto() { }
        public Producto(string nombre, int stock) {
            this._nombre = nombre;
            this._stock = stock;
        }

        public static bool operator ==(Producto p1, Producto p2) {
            bool retorno = false;
            if (p1._nombre == p2._nombre) {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1==p2);
        }


    }
}

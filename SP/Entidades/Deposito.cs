using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito
    {
        public Producto[] _productos;
        public Producto[] productos { get { return this._productos; } }
        private int _cantidad;
        public Deposito(int cantidad) {
            this._productos = new Producto[cantidad];
            this._cantidad = cantidad;
        }
        public Deposito() : this(3) {

        }
        public static Producto[] operator +(Deposito d1, Deposito d2) {
            int cantidad = d1._cantidad + d2._cantidad;
            int stock, count = 0, posicion;
            bool flag = false;
            Producto p;
            Producto[] aux = new Producto[cantidad];
            foreach (Producto item in d1.productos) {
                if (Deposito.ExisteProducto(aux, item, out posicion))
                {
                    stock = aux[posicion].stock + item.stock;
                    p = new Producto(aux[posicion].nombre, stock);
                    aux[posicion] = p;
                }
                else {
                    p = new Producto(item.nombre, item.stock);
                    aux[count] = p;
                    count++;
                }
            }
            foreach (Producto item in d2.productos)
            {
                if (Deposito.ExisteProducto(aux, item, out posicion))
                {
                    stock = aux[posicion].stock + item.stock;
                    p = new Producto(aux[posicion].nombre, stock);
                    aux[posicion] = p;
                }
                else
                {
                    p = new Producto(item.nombre, item.stock);
                    aux[count] = p;
                    count++;
                }
            }
            return aux;
        }

        public static bool ExisteProducto(Producto[] aux, Producto p, out int posicion) {
            bool retorno = false;
            posicion = -1;
            int count = 0;
            foreach (Producto item in aux) {
                if ((object)item != null) {
                    if (item == p)
                    {
                        retorno = true;
                        posicion = count;
                        break;
                    }
                    count++;
                }
               
            }
            return retorno;
        }
    }

}


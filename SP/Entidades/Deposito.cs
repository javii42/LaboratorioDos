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
        public static Producto[] operator +(Deposito d1, Deposito d2){
            int cantidad = d1._cantidad + d2._cantidad;
            int stock, count=0;
            bool flag = false;
            Producto p;
            Producto[] aux = new Producto[cantidad];
            for (int i = 0; i < d1._cantidad; i++){
                stock = d1.productos[i].stock;
                for (int j = 0; j < d2._cantidad; j++) {
                    if (d1.productos[i] == d2.productos[j]) { //sobrecarge igualdad en Producto
                        stock += d2.productos[j].stock;
                    }
                }
                p = new Producto(d1.productos[i].nombre, stock);
                aux[count] = p;
                count++;
            }
            for (int i = 0; i < d2._cantidad; i++)
            {
                for (int j = 0; j < d1._cantidad; j++)
                {
                    if (d2.productos[i] == d1.productos[j])
                    { //sobrecarge igualdad en Producto
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    p = new Producto(d2.productos[i].nombre, d2.productos[i].stock);
                    aux[count] = p;
                    count++;
                }
                else
                {
                    flag = false;
                }
            }
            return aux;
        }
    }

}


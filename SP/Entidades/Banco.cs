using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public abstract class Banco
    {
        private string _nombre;
        public string Nombre {
            get {
                return this._nombre;
            }
            set {
                this._nombre = value;
            }
        }
        public Banco(string nombre) {
            this._nombre = nombre;
        }

        public abstract string Mostrar();
        public abstract string Mostrar(Banco b);
        
    }
}

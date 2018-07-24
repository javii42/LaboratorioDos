using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public delegate void ManejadorPares(object sender, EventArgs e);
    public class EntidadesFinancieras<T>
    {
        private List<T> _elementos;
        private int _capacidad;

        public event ManejadorPares ElementosParesEvent;

        private EntidadesFinancieras() {
            this._elementos = new List<T>();
        }

        public EntidadesFinancieras(int capacidad) : this() {
            if (capacidad >= 0)
            {
                this._capacidad = capacidad;
            }
            else {
                this._capacidad = 0;
            }
        }

        public bool Add(T elemento) {
            bool retorno = false ;
            if (this._capacidad > this._elementos.Count) {
                this._elementos.Add(elemento);
                if ((this._elementos.Count % 2) == 0) {
                    this.ElementosParesEvent(this, EventArgs.Empty);
                }
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            string retorno = "";
            foreach (T elemento in this._elementos) {
                retorno += elemento.ToString() + "\n";
            }
            return retorno;
        }

    }
}

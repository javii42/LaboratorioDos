using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        public abstract bool TieneCarozo { get; }
        public Fruta() {
            this._color = ConsoleColor.Black;
            this._peso = 0;
        }
        public Fruta(float peso, ConsoleColor color) {
            this._peso = peso;
            this._color = color;
        }

        protected virtual string FrutaToString() {
            return string.Format("Peso: {0} \nColor: {1}\n", this._peso, this._color);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Platano: Fruta
    {
        public string paisOrigen;

        public override bool TieneCarozo { get { return false; } }
        public string Tipo { get { return "Platano"; } }

        protected override string FrutaToString()
        {
            return "Fruta: " + this.Tipo +" \nPais de Origen: "+ this.paisOrigen + "\n" + base.FrutaToString();
        }

        public Platano(float peso, ConsoleColor color, string pais) : base(peso, color) {
            this.paisOrigen = pais;
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}

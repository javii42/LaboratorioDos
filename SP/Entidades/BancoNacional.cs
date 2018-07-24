using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BancoNacional: Banco
    {
        private string _pais;
        public string Pais {
            get { return this._pais; }
            set {
                this._pais = value;
            }
        }
        public BancoNacional(string nombre, string pais) : base(nombre) {
            this._pais = pais;
        }

        public override string Mostrar()
        {
            return "Nombre: "+this.Nombre;
        }

        public override string Mostrar(Banco b)
        {
            return this.Mostrar() + "\nPais: " + this.Pais;
        }
    }
}

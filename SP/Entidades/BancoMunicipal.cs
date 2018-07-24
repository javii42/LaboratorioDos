using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BancoMunicipal: BancoProvincial
    {
        private string _municipio;
        public BancoMunicipal(BancoProvincial bancoProvincial, string municipio)
            :base((BancoNacional) bancoProvincial, bancoProvincial.Provincia)
        {
            this._municipio = municipio;
        }

        public override string Mostrar(Banco b)
        {
            return base.Mostrar(b) + "\nMunicipio: " + this._municipio;
        }
    }
}

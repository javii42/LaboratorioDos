using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BancoProvincial: BancoNacional
    {
        private string _provincia;
        public string Provincia {
            get {
                return this._provincia;
            }
            set {
                this._provincia = value;
            }
        }
        public BancoProvincial(BancoNacional bancoNacional, string provincia)
            :base(bancoNacional.Nombre,bancoNacional.Pais) {
            this._provincia = provincia;
        }

        public override string Mostrar(Banco b)
        {
            return base.Mostrar(b) + "\nProvincia: " +this.Provincia;
        }
    }
}

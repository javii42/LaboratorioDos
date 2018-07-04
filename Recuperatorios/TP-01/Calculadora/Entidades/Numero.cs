using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double _numero;
        public string SetNumero { set { this._numero = ValidarNumero(value); } }

        public Numero()
        {
            this._numero = 0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public string BinarioDecimal(string binario)
        {
            String retorno = "Valor invalido";
            if (!binario.Contains(","))
            {
                retorno = Convert.ToString(Convert.ToInt32(binario, 2), 10);
            }
            return retorno;
        }
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        public string DecimalBinario(string numero)
        {
            String retorno = "Valor invalido";
            if (!numero.Contains(","))
            {
                retorno = Convert.ToString(Convert.ToInt32(numero, 10), 2);
            }
            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1._numero + n2._numero;
            return retorno;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1._numero - n2._numero;
            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;
            retorno = n1._numero * n2._numero;
            return retorno;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = -1;
            if (n2._numero != 0)
            {
                retorno = n1._numero / n2._numero;
            }
            return retorno;
        }

        private double ValidarNumero(string strNumero)
        {
            double resultado;
            if (!double.TryParse(strNumero, out resultado))
            {
                resultado = 0;
            }
            return resultado;
        }
    }
}

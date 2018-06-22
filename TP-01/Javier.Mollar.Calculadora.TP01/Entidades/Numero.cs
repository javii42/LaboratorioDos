using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        public string SetNumero {
            set {
                this._numero = ValidarNumero(value) ;
            }
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }
        public Numero() :this(0){
        }
        public Numero(String numero) {
            SetNumero = numero;
        }


        public string BinarioDecimal(string binario) {
            return "";
        }
        public string DecimalBinario(double binario)
        {
            return "";
        }
        public string DecimalBinario(string binario)
        {
            return "";
        }

        private double ValidarNumero(string strNumero)
        {
            double resultado;
            double.TryParse(strNumero, out resultado);
            return resultado;
        }

        public static double operator +(Numero n1, Numero n2) {
            double retorno = 0;
            retorno = n1._numero + n2._numero;
            return retorno;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = 0;
            retorno = n1._numero - n2._numero;
            return retorno;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = 0;
            retorno = n1._numero * n2._numero;
            return retorno;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if(n2._numero != 0)
            {
                retorno = n1._numero / n2._numero;
            }
            return retorno;
        }
     



    }
}

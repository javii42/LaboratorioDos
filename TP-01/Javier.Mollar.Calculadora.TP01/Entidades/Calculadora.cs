using System;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero n1, Numero n2, string operador) {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = n1 + n2;
                    break;
                case "-":
                    resultado = n1 - n2;
                    break;
                case "*":
                    resultado = n1 * n2;
                    break;
                case "/":
                    resultado = n1 / n2;                
                    break;
                default:
                    resultado = 0;
                    break;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador) {
            switch (operador) {
                case "+":
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    operador = "+";
                    break;
        }
            return operador;
        }
    }
}

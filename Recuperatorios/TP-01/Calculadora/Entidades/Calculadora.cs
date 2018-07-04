using System;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }
            return resultado;
        }
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
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

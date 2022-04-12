using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida el operador que se recibe por parametro y realiza la funcion que corresponda.
        /// </summary>
        /// <param name="num1">Numero a operar 1</param>
        /// <param name="num2">Numero a operar 2</param>
        /// <param name="operador">Tipo de operacion que se quiera realizar</param>
        /// <returns>Resultado de la operacion realizada</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char opValidado = ValidarOperando(operador);
            double retorno = 0;

            switch (opValidado)
            {
                case '/':
                    retorno = num1 / num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el operador sea -,+,/,* y en caso de que no lo sea retorna un +.
        /// </summary>
        /// <param name="operador">Operador</param>
        /// <returns>Operador validado o un + en caso de que no sea valido</returns>
        private static char ValidarOperando(char operador)
        {
            if (operador.Equals('-') || operador.Equals('*') || operador.Equals('/') || operador.Equals('+'))
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
    }
}

using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Setter de la instancia numero validado.
        /// </summary>
        public string setNumero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }

        /// <summary>
        /// Constructor Operando.
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Constructor Operando con parametro double.
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor Operando con parametro string.
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string numero)
        {
            this.setNumero = numero;
        }

        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>Retorna la cadena convertida a decimal</returns>
        public static string BinarioDecimal(string binario)
        {
            int numero = 0;
            int digito = 0;
            const int DIVISOR = 10;
            long bin = (long)Convert.ToDouble(binario);
            string retorno = "Error";

            if (EsBinario(binario))
            {
                for (long i = bin, j = 0; i > 0; i /= DIVISOR, j++)
                {
                    digito = (int)i % DIVISOR;
                    if (digito != 1 && digito != 0)
                    {
                        break;
                    }
                    numero += digito * (int)Math.Pow(2, j);
                }
                retorno = numero.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en binario.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero en binario</returns>
        public static string DecimalBinario(double numero)
        {
            long binario = 0;
            const double DIVISOR = 2;
            long digito = 0;
            string retorno = "Error";

            for (double i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = (long)(i % DIVISOR);
                binario += digito * (long)Math.Pow(10, j);
            }

            if (EsBinario(Convert.ToString(binario)))
            {
                retorno = Convert.ToString(binario);
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en binario.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>El numero en binario</returns>
        public static string DecimalBinario(string numeroStr)
        {
            double numero = Convert.ToDouble(numeroStr);
            long binario = 0;
            const double DIVISOR = 2;
            long digito = 0;
            string retorno = "Error";

            for (double i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = (long)(i % DIVISOR);
                binario += digito * (long)Math.Pow(10, j);
            }

            if (EsBinario(Convert.ToString(binario)))
            {
                retorno = Convert.ToString(binario);
            }

            return retorno;
        }

        /// <summary>
        /// Valida si un numero es binario o no.
        /// </summary>
        /// <param name="binario">Numero a validar</param>
        /// <returns>Verdadero si es binario o Falso si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] binarioCharArray = binario.ToCharArray();

            foreach (char caracter in binarioCharArray)
            {
                if (!caracter.Equals('0') && !caracter.Equals('1'))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador -.
        /// </summary>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador +.
        /// </summary>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /.
        /// </summary>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = double.MinValue;

            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador *.
        /// </summary>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Valida que el operando sea solo numeros
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>El numero ingresado en caso de que sea valido y 0 en caso de que no lo sea</returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

    }
}

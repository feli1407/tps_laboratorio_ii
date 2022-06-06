using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.FuncionesForm
{
    public static class HerramientasForm
    {
        /// <summary>
        /// Valida que el string este compuesto solo por numeros.
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>El numero ingresado en caso de que sea valido y 0 en caso de que no lo sea</returns>
        public static double ValidarStringSoloNumeros(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

    }
}

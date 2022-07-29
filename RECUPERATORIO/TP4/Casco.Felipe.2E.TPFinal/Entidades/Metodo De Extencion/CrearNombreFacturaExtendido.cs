using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Metodo_De_Extencion
{
    public static class CrearNombreFacturaExtendido
    {
        /// <summary>
        /// Extiende la clase int devolviendo un string con el nombre deel archivo txt.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CrearNombreFactura(this int num)
        {
           return "factura" + num + ".txt";
        }
    }
}

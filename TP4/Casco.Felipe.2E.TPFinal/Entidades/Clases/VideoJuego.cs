using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public enum EGenero
    {
        Accion,
        Aventura,
        Estrategia,
        Deporte,
        Simulador,
        Musical
    }

    [XmlInclude(typeof(JuegoPlay)), XmlInclude(typeof(JuegoXbox)), XmlInclude(typeof(JuegoNintendo))]

    public abstract class VideoJuego
    {
        private string nombre;
        private int precioCompra;
        private int precioVenta;
        private EGenero genero;
        private int stock;

        public VideoJuego()
        {

        }

        public VideoJuego(string nombre, int precioCompra, EGenero genero)
        {
            this.nombre = nombre;
            this.precioCompra = precioCompra;
            this.genero = genero;
        }
        public VideoJuego(string nombre, int precioCompra, EGenero genero, int stock)
        {
            this.nombre = nombre;
            this.precioCompra = precioCompra;
            this.genero = genero;
            this.stock = stock;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public int PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public EGenero Genero { get => genero; set => genero = value; }
        public int Stock { get => stock; set => stock = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"|Nombre: {this.Nombre}|");
            sb.Append($"|Genero: {this.Genero}|");
            sb.Append($"|Precio Compra: {this.PrecioCompra}|");
            sb.Append($"|Stock: {this.Stock}|");
            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con solo los datos que aparecen en la venta(factura).
        /// </summary>
        /// <returns></returns>
        public virtual string DatosVenta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Nombre: {this.Nombre}|");
            sb.AppendLine($"|Genero: {this.Genero}|");
            sb.AppendLine($"|Precio: {this.precioVenta}|");
            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con el tipo de videojuego que es el videojuego que se le pasa por parametro.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string TipodDeVideoJuego(VideoJuego v)
        {
            if(v is JuegoPlay)
            {
                return "PlayStation";
            }
            else if(v is JuegoXbox)
            {
                return "Xbox";
            }
            else
            {
                return "Nintendo";
            }
        }

        public static bool operator ==(VideoJuego v1, VideoJuego v2)
        {
            if(v1.Nombre == v2.Nombre)
            {
                if(v1 is JuegoPlay && v2 is JuegoPlay)
                {
                    return true;
                }
                else if(v1 is JuegoXbox && v2 is JuegoXbox)
                {
                    return true;
                }
                else if(v1 is JuegoNintendo && v2 is JuegoNintendo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(VideoJuego v1, VideoJuego v2)
        {
            return !(v1 == v2);
        }
    }
}

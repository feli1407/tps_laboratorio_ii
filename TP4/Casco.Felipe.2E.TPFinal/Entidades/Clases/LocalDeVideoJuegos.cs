using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class LocalDeVideoJuegos
    {
        private List<VideoJuego> videoJuegos;
        private int porcentajeGanancia;

        public LocalDeVideoJuegos()
        {
            this.videoJuegos = new List<VideoJuego>();
        }

        public LocalDeVideoJuegos(int porcentajeGanancia) : this()
        {
            this.PorcentajeGanancia = porcentajeGanancia;
        }

        public List<VideoJuego> VideoJuegos { get => videoJuegos; set => videoJuegos = value; }
        public int PorcentajeGanancia { get => porcentajeGanancia; set => porcentajeGanancia = value; }

        /// <summary>
        /// Asigna el precio de venta de los videojuegos del local segun el porcentaje de ganancia que tenga asignado.
        /// </summary>
        public void AsignarPrecioVenta()
        {
            float ganancia;

            foreach (VideoJuego videoJuego in videoJuegos)
            {
                ganancia = (videoJuego.PrecioCompra * PorcentajeGanancia) / 100;
                videoJuego.PrecioVenta = (int)((int)videoJuego.PrecioCompra + ganancia);
            }
        }

        /// <summary>
        /// Devuelve un string builder con todos los datos de los videojuegos que tiene el local.
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            foreach (VideoJuego videoJuego in videoJuegos)
            {
                sb.AppendLine(videoJuego.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Recibe una lista de videojuegos y un videojuego, en caso de que este el videojuego en la lista
        /// retorna true de lo contrario false.
        /// </summary>
        /// <param name="listajuegos"></param>
        /// <param name="juego"></param>
        /// <returns></returns>
        public static bool SeEncuentraEnLaLista(List<VideoJuego> listajuegos, VideoJuego juego)
        {
            bool retorno = false;
            if (listajuegos is not null && juego is not null)
            {
                foreach (VideoJuego videoJuego in listajuegos)
                {
                    if (videoJuego == juego)
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }
    }
}

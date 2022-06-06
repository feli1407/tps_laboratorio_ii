using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AsignarPrecioVenta()
        {
            float ganancia;

            foreach(VideoJuego videoJuego in videoJuegos)
            {
                ganancia = (videoJuego.PrecioCompra * PorcentajeGanancia) / 100;
                videoJuego.PrecioVenta = (int)((int)videoJuego.PrecioCompra + ganancia);
            }
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            foreach(VideoJuego videoJuego in videoJuegos)
            {
                sb.AppendLine(videoJuego.ToString());
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class JuegoPlay : VideoJuego
    {
        private bool exclusivoPlay;

        public JuegoPlay()
        {

        }

        public JuegoPlay(string nombre, int precioCompra, EGenero genero, bool exclusivoPlay) : this(nombre, precioCompra, genero,exclusivoPlay,1)
        {

        }
        
        public JuegoPlay(string nombre, int precioCompra, EGenero genero, bool exclusivoPlay, int stock) : base(nombre, precioCompra, genero, stock)
        {
            this.ExclusivoPlay = exclusivoPlay;
        }

        public bool ExclusivoPlay { get => exclusivoPlay; set => exclusivoPlay = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de PLAY|");
            sb.Append(base.ToString());
            sb.Append($"|Exclusivo de play: {this.exclusivoPlay}|");
            return sb.ToString();
        }

        public override string DatosVenta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de PLAY|");
            sb.Append(base.DatosVenta());
            sb.AppendLine($"|Exclusivo de play: {this.exclusivoPlay}|");
            return sb.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class JuegoXbox : VideoJuego
    {
        private bool exclusivoXbox;

        public JuegoXbox()
        {

        }
        public JuegoXbox(string nombre, int precioCompra, EGenero genero, bool exclusivoXbox) : this(nombre, precioCompra, genero, exclusivoXbox,1)
        {
        }
        public JuegoXbox(string nombre, int precioCompra, EGenero genero, bool exclusivoXbox, int stock) : base(nombre, precioCompra, genero,stock)
        {
            this.ExclusivoXbox = exclusivoXbox;
        }

        public bool ExclusivoXbox { get => exclusivoXbox; set => exclusivoXbox = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de XBOX|");
            sb.Append(base.ToString());
            sb.Append($"|Exclusivo de xbox: {this.ExclusivoXbox}|");
            return sb.ToString();
        }

        public override string DatosVenta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de XBOX|");
            sb.Append(base.DatosVenta());
            sb.AppendLine($"|Exclusivo de xbox: {this.ExclusivoXbox}|");
            return sb.ToString();
        }
    }
}

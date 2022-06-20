using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class JuegoNintendo : VideoJuego
    {
        private bool exclusivoNintendo;

        public JuegoNintendo()
        {

        }
        public JuegoNintendo(string nombre, int precioCompra, EGenero genero, bool exclusivoNintendo, int stock) : base(nombre, precioCompra, genero, stock)
        {
            this.exclusivoNintendo = exclusivoNintendo;
        }

        public JuegoNintendo(string nombre, int precioCompra, EGenero genero, bool exclusivoNintendo) : this(nombre, precioCompra, genero, exclusivoNintendo, 1)
        {

        }

        public bool ExclusivoNintendo { get => exclusivoNintendo; set => exclusivoNintendo = value; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de NINTENDO|");
            sb.Append(base.ToString());
            sb.Append($"|Exclusivo de nintendo: {this.ExclusivoNintendo}|");
            return sb.ToString();
        }

        public override string DatosVenta()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Juego de NINTENDO|");
            sb.Append(base.DatosVenta());
            sb.AppendLine($"|Exclusivo de nintendo: {this.ExclusivoNintendo}|");
            return sb.ToString();
        }

    }
}

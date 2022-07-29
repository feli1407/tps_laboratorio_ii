using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellido) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Cliente(int id, string nombre, string apellido) : this(nombre, apellido)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***CLIENTE***");
            sb.AppendLine($"|ID: {this.id}|");
            sb.AppendLine($"|Nombre: {this.nombre}|");
            sb.AppendLine($"|Apellido: {this.apellido}|");
            return sb.ToString();
        }
    }
}

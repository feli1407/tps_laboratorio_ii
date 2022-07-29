using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public delegate void NotificarCambio(Reloj sender);

    public class Reloj
    {
        private int hora;
        private int minutos;
        private int segundos;
        private string fecha;

        public int Hora { get => hora; set => hora = value; }
        public int Minutos { get => minutos; set => minutos = value; }
        public int Segundos { get => segundos; set => segundos = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        public event NotificarCambio OnNotificarCambio;

        /// <summary>
        /// Inicia un hilo donde se invoca al delegado que se usaria para notificar al usario los cambios de la hora.
        /// </summary>
        public void Iniciar()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    DateTime dt = DateTime.Now;
                    Thread.Sleep(100);

                    if (dt.Second != this.segundos)
                    {
                        if (OnNotificarCambio is not null)
                        {
                            this.OnNotificarCambio.Invoke(this);
                        }
                    }
                    hora = dt.Hour;
                    minutos = dt.Minute;
                    segundos = dt.Second;
                    fecha = dt.Date.ToString("d");
                }
            });
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hora: {Hora} : {Minutos} : {Segundos}");
            sb.AppendLine($"Fecha: {fecha}");
            return sb.ToString();
        }
    }
}

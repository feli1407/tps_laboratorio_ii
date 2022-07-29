using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public delegate void NotificarStock();
    public class Stock
    {
        public event NotificarStock OnNotificarStock;

        /// <summary>
        /// Inicia un hilo donde se invoca al delegado que se usaria para notificar al usario los video juegos que 
        /// quedaron en Stock 0 cada 30 segundos.
        /// </summary>
        public void Iniciar()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    if (OnNotificarStock is not null)
                    {
                        this.OnNotificarStock.Invoke();
                    }
                    Thread.Sleep(30000);
                }
            });
        }
    }
}

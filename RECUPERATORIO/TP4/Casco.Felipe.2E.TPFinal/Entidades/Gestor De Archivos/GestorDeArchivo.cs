using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Gestor_De_Archivos
{
    public abstract class GestorDeArchivo
    {
        protected string rutaBase;
        protected ETipo tipo;
        public enum ETipo { XML, JSON, TXT };

        protected GestorDeArchivo(ETipo tipo)
        {
            DirectoryInfo path = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{tipo}\\");
            rutaBase = path.FullName;
            this.tipo = tipo;
        }

    }
}

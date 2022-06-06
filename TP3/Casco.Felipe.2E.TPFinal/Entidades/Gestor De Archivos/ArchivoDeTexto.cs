using Entidades.Excepcion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Gestor_De_Archivos
{
    public class ArchivoTexto : GestorDeArchivo, IArchivos<string>
    {
        public ArchivoTexto() : base(ETipo.TXT)
        {

        }

        public void Escribir(string nombreArchivo, string contenido, bool append)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter($"{rutaBase}\\{nombreArchivo}", append);
                streamWriter.WriteLine(contenido);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al escribir", ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();

                }
            }

        }
        public void Escribir(string nombreArchivo, string contenido)
        {

            try
            {
                using (StreamWriter streamWriter = new StreamWriter($"{rutaBase}\\{nombreArchivo}"))
                {
                    streamWriter.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al escribir", ex);
            }


        }
        public string Leer(string nombreArchivo)
        {

            try
            {
                using (StreamReader streamReader = new StreamReader($"{rutaBase}\\{nombreArchivo}"))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al leer", ex);
            }


        }
    }
}

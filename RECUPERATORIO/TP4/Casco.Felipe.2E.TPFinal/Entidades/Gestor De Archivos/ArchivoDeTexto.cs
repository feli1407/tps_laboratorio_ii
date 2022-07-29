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

        /// <summary>
        /// Escribe uun archivo de texto con el nombre y texto que se le pasa por parametro, en la direccion asignada
        /// en la clase GestorDeArchivo, y tiene un booleano para poder Agregar la informacion al archivo existente en caso
        /// de que exista.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <param name="append"></param>
        /// <exception cref="ArchivosException"></exception>
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
                throw new ArchivosException("Error al escribir en un archivo de texto", ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();

                }
            }

        }

        /// <summary>
        /// Escribe uun archivo de texto con el nombre y texto que se le pasa por parametro, en la direccion asignada
        /// en la clase GestorDeArchivo.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <exception cref="ArchivosException"></exception>
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
                throw new ArchivosException("Error al escribir en un archivo de texto", ex);
            }


        }
        /// <summary>
        /// Lee el archivo de texto con el nombre pasado por parametro y devuelve el contenido en un string.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivosException"></exception>
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
                throw new ArchivosException("Error al leer de un archivo de texto", ex);
            }


        }
    }
}

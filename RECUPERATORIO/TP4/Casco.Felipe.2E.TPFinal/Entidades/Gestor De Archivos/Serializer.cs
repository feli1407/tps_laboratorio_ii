using Entidades.Excepcion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Gestor_De_Archivos
{
    public class Serializer<T> : GestorDeArchivo, IArchivos<T> where T : class, new()
    {
        public Serializer(ETipo tipo) : base(tipo)
        {
        }

        /// <summary>
        /// recibe un nombre de archivo y un tipo de archivo a serializar y en caso de que sea xml o json escribe
        /// un archivo en la direccion rutabase de la clase gestordearchivos. y serealiza segun sea xml o json.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="elemento"></param>
        /// <exception cref="ArchivosException"></exception>
        public void Escribir(string nombreArchivo, T elemento)
        {
            try
            {
                if (tipo == ETipo.XML)
                {
                    if (Path.GetExtension(nombreArchivo) == ".xml")
                    {
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter($"{rutaBase}\\{nombreArchivo}", Encoding.UTF8))
                        {
                            xmlTextWriter.Formatting = Formatting.Indented;
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            serializer.Serialize(xmlTextWriter, elemento);
                        }
                    }
                    else
                    {
                        throw new ArchivosException("Extension invalida, se esperaba XML");
                    }
                }
                else
                {
                    if (Path.GetExtension(nombreArchivo) == ".json")
                    {

                        string json = JsonSerializer.Serialize(elemento, typeof(T));
                        EscribirJSON($"{rutaBase}\\{nombreArchivo}", json);
                    }
                    else
                    {
                        throw new ArchivosException("Extension invalida, se esperaba JSON");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al Serializar", ex);
            }
        }

        /// <summary>
        /// lee un archivo segun el nombre pasado por parametro, y deserealiza segun sea xml o json.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivosException"></exception>
        public T Leer(string nombreArchivo)
        {
            try
            {
                if (tipo == ETipo.XML)
                {
                    if (Path.GetExtension(nombreArchivo) == ".xml")
                    {
                        using (XmlTextReader xmlTextReader = new XmlTextReader($"{rutaBase}\\{nombreArchivo}"))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            return serializer.Deserialize(xmlTextReader) as T;
                        }
                    }
                    else
                    {
                        throw new ArchivosException("Extension invalida, se esperaba XML");
                    }
                }
                else
                {
                    if (Path.GetExtension(nombreArchivo) == ".json")
                    {
                        string json = LeerJSON($"{rutaBase}\\{nombreArchivo}");
                        return JsonSerializer.Deserialize<T>(json);
                    }
                    else
                    {
                        throw new ArchivosException("Extension invalida, se esperaba JSON");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al Deserializar", ex);
            }
        }

        /// <summary>
        /// Escribe un JSON en la ruta indicada con el contenido indicado.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="contenido"></param>
        private void EscribirJSON(string ruta, string contenido)
        {

            using (StreamWriter streamWriter = new StreamWriter(ruta))
            {
                streamWriter.WriteLine(contenido);
            }
        }
        /// <summary>
        /// Lee un JSON en la direccion que se le pasa por parametro.
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        private string LeerJSON(string ruta)
        {
            using (StreamReader streamReader = new StreamReader(ruta))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}

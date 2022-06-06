using Entidades;
using Entidades.Gestor_De_Archivos;
using System;
using System.Collections.Generic;

namespace TestConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LocalDeVideoJuegos local = new LocalDeVideoJuegos(30);

            JuegoPlay jp1 = new JuegoPlay("God of war 3", 3900, EGenero.Aventura, false,20);
            JuegoPlay jp2 = new JuegoPlay("Call of duty", 6490, EGenero.Accion, true);
            JuegoPlay jp3 = new JuegoPlay("Sonic generations", 6490, EGenero.Accion, true);

            JuegoXbox jx1 = new JuegoXbox("Halo 3", 7500, EGenero.Accion, false);
            JuegoXbox jx2 = new JuegoXbox("Fifa 22", 4800, EGenero.Deporte, true,25);
            JuegoXbox jx3 = new JuegoXbox("Far Cry 4", 3800, EGenero.Aventura, true,15);
            JuegoXbox jx4 = new JuegoXbox("Call of duty BO2", 7890, EGenero.Accion, true,25);
            JuegoXbox jx5 = new JuegoXbox("Just Dance", 12000, EGenero.Musical, true,2);
            JuegoXbox jx6 = new JuegoXbox("Kinect Olimpiadas", 2700, EGenero.Deporte, false,42);

            JuegoNintendo jn1 = new JuegoNintendo("Zelda", 5750, EGenero.Aventura, true);
            JuegoNintendo jn2 = new JuegoNintendo("Pes 2021", 3787, EGenero.Deporte, false, 12);
            JuegoNintendo jn3 = new JuegoNintendo("Pes 2021", 3787, EGenero.Deporte, false, 12);


            List<VideoJuego> juegos = new List<VideoJuego>();
            juegos.Add(jp1);
            juegos.Add(jp2);
            juegos.Add(jp3);
            juegos.Add(jx1);
            juegos.Add(jx3);
            juegos.Add(jx4);
            juegos.Add(jx5);
            juegos.Add(jx6);
            juegos.Add(jx2);
            juegos.Add(jn1);
            juegos.Add(jn2);
            juegos.Add(jn3);

            local.VideoJuegos = juegos;

            local.AsignarPrecioVenta();//Asigna la ganancia en porcentaje.

            //PROBANDO ARCHIVOS Y SERIALIZACION

            Serializer<LocalDeVideoJuegos> serializadorXML = new Serializer<LocalDeVideoJuegos>(GestorDeArchivo.ETipo.XML);
            serializadorXML.Escribir("localdevideojuegos.xml", local);
            Console.WriteLine("Ya serialize XML");

            Console.ReadKey();

            Console.Clear();

            //El JSON da problemas para serializar clases con listas genericas.
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            juegosPlay.Add(jp1);
            juegosPlay.Add(jp2);
            juegosPlay.Add(jp3);

            Serializer<List<JuegoPlay>> serializadorJSON = new Serializer<List<JuegoPlay>>(GestorDeArchivo.ETipo.JSON);
            serializadorJSON.Escribir("juegosPlay.json", juegosPlay);
            Console.WriteLine("Ya Serialize JSON");

            Console.WriteLine("Leyendo JSON");
            List<JuegoPlay> juegosPlayLeido = serializadorJSON.Leer("juegosPlay.json");
            foreach(JuegoPlay juegoPlay in juegosPlayLeido)
            {
                Console.WriteLine(juegoPlay.ToString());
            }

            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("Leyendo XML");
            LocalDeVideoJuegos localLeido2 = serializadorXML.Leer("localdevideojuegos.xml");
            Console.WriteLine(localLeido2.Mostrar());

            Console.ReadKey();

            Console.Clear();
        }
    }
}

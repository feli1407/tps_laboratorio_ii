using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.SQL
{
    public class VideoJuegoDAO
    {
        private static string cadenaConexion;

        static VideoJuegoDAO()
        {
            VideoJuegoDAO.cadenaConexion = "Server=DESKTOP-2JGV9AR;Database=TPFinalCascoFelipe;Trusted_Connection=True;";
        }

        /// <summary>
        /// Guarda el juego de play pasado por parametro en la tabla de juegos de play en la base de datos.
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public static bool GuardarJuegoPlay(JuegoPlay juego)
        {
            bool retorno = false;
            //Borro el contenido de la tabla antes de volver a cargar los datos para que no se repitan los datos.
            string query = "delete from JuegosPlay insert into JuegosPlay (Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) " +
                "values (@nombre, @preciocompra, @precioventa, @genero, @stock, @exclusivoplay)";
            using (SqlConnection conexion = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("nombre", juego.Nombre);
                cmd.Parameters.AddWithValue("preciocompra", juego.PrecioCompra);
                cmd.Parameters.AddWithValue("precioventa", juego.PrecioVenta);
                cmd.Parameters.AddWithValue("genero", juego.Genero.ToString());
                cmd.Parameters.AddWithValue("stock", juego.Stock);
                if (juego.ExclusivoPlay == true)
                {
                    cmd.Parameters.AddWithValue("exclusivoplay", 1);//true
                }
                else
                {
                    cmd.Parameters.AddWithValue("exclusivoplay", 0);//false
                }
                cmd.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Guarda el juego de xbox pasado por parametro en la tabla de juegos de xbox en la base de datos.
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public static bool GuardarJuegoXbox(JuegoXbox juego)
        {
            bool retorno = false;
            //Borro el contenido de la tabla antes de volver a cargar los datos para que no se repitan los datos.
            string query = "delete from JuegosXbox insert into JuegosXbox (Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) " +
                "values (@nombre, @preciocompra, @precioventa, @genero, @stock, @exclusivoxbox)";
            using (SqlConnection conexion = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("nombre", juego.Nombre);
                cmd.Parameters.AddWithValue("preciocompra", juego.PrecioCompra);
                cmd.Parameters.AddWithValue("precioventa", juego.PrecioVenta);
                cmd.Parameters.AddWithValue("genero", juego.Genero.ToString());
                cmd.Parameters.AddWithValue("stock", juego.Stock);
                if (juego.ExclusivoXbox == true)
                {
                    cmd.Parameters.AddWithValue("exclusivoxbox", 1);//true
                }
                else
                {
                    cmd.Parameters.AddWithValue("exclusivoxbox", 0);//false
                }
                cmd.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        ///  Guarda el juego de nintendo pasado por parametro en la tabla de juegos de nintendo en la base de datos.
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public static bool GuardarJuegoNintendo(JuegoNintendo juego)
        {
            bool retorno = false;
            //Borro el contenido de la tabla antes de volver a cargar los datos para que no se repitan los datos.
            string query = "delete from JuegosXbox insert into JuegosXbox (Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) " +
                "values (@nombre, @preciocompra, @precioventa, @genero, @stock, @exclusivonintendo)";
            using (SqlConnection conexion = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("nombre", juego.Nombre);
                cmd.Parameters.AddWithValue("preciocompra", juego.PrecioCompra);
                cmd.Parameters.AddWithValue("precioventa", juego.PrecioVenta);
                cmd.Parameters.AddWithValue("genero", juego.Genero.ToString());
                cmd.Parameters.AddWithValue("stock", juego.Stock);
                if (juego.ExclusivoNintendo == true)
                {
                    cmd.Parameters.AddWithValue("exclusivonintendo", 1);//true
                }
                else
                {
                    cmd.Parameters.AddWithValue("exclusivonintendo", 0);//false
                }
                cmd.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Lee todos los juegos de play que hay en la tabla de juegos de play de la base de datos y devuelve una lista
        /// con estos.
        /// </summary>
        /// <returns></returns>
        public static List<JuegoPlay> LeerJuegosPlay()
        {
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            string query = "select * from JuegosPlay order by Nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    int precioCompra = reader.GetInt32(1);
                    int precioVenta = reader.GetInt32(2);
                    string genero = reader.GetString(3);
                    int stock = reader.GetInt32(4);
                    bool exclusivo = reader.GetBoolean(5);
                    JuegoPlay juegoPlay = new JuegoPlay(nombre, precioCompra, (EGenero)Enum.Parse(typeof(EGenero), genero), exclusivo, stock);
                    juegosPlay.Add(juegoPlay);
                }
            }

            return juegosPlay;
        }

        /// <summary>
        /// Lee todos los juegos de xbox que hay en la tabla de juegos de xbox de la base de datos y devuelve una lista
        /// con estos.
        /// </summary>
        /// <returns></returns>
        public static List<JuegoXbox> LeerJuegosXbox()
        {
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            string query = "select * from JuegosXbox order by Nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    int precioCompra = reader.GetInt32(1);
                    int precioVenta = reader.GetInt32(2);
                    string genero = reader.GetString(3);
                    int stock = reader.GetInt32(4);
                    bool exclusivo = reader.GetBoolean(5);
                    JuegoXbox juegoXbox = new JuegoXbox(nombre, precioCompra, (EGenero)Enum.Parse(typeof(EGenero), genero), exclusivo, stock);
                    juegosXbox.Add(juegoXbox);
                }
            }

            return juegosXbox;
        }

        /// <summary>
        /// Lee todos los juegos de nintendo que hay en la tabla de juegos de nintendo de la base de datos y devuelve una lista
        /// con estos.
        /// </summary>
        /// <returns></returns>
        public static List<JuegoNintendo> LeerJuegosNintendo()
        {
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();
            string query = "select * from JuegosNintendo order by Nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    int precioCompra = reader.GetInt32(1);
                    int precioVenta = reader.GetInt32(2);
                    string genero = reader.GetString(3);
                    int stock = reader.GetInt32(4);
                    bool exclusivo = reader.GetBoolean(5);
                    JuegoNintendo juegoNintendo = new JuegoNintendo(nombre, precioCompra, (EGenero)Enum.Parse(typeof(EGenero), genero), exclusivo, stock);
                    juegosNintendo.Add(juegoNintendo);
                }
            }

            return juegosNintendo;
        }

        /// <summary>
        /// Borra el juego de play de la base de datos que tenga el mismo nombre que se pasa por parametro.
        /// </summary>
        /// <param name="nombre"></param>
        public static void BorrarJuegoPlay(string nombre)
        {
            string query = "DELETE FROM JuegosPlay where nombre=@nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Borra el juego de xbox de la base de datos que tenga el mismo nombre que se pasa por parametro.
        /// </summary>
        /// <param name="nombre"></param>
        public static void BorrarJuegoXbox(string nombre)
        {
            string query = "DELETE FROM JuegosXbox where nombre=@nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Borra el juego de nintendo de la base de datos que tenga el mismo nombre que se pasa por parametro.
        /// </summary>
        /// <param name="nombre"></param>
        public static void BorrarJuegoNintendo(string nombre)
        {
            string query = "DELETE FROM JuegosNintendo where nombre=@nombre";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", nombre);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Guarda el cliente que se le pasa por parametro en la base de datos, en la respectiva tabla de clientes.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool GuardarCliente(Cliente cliente)
        {
            bool retorno = false;

            string query = "insert into ClientesTPFinal (Nombre, Apellido) values (@nombre, @apellido)";
            using (SqlConnection conexion = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("apellido", cliente.Apellido);
                cmd.ExecuteNonQuery();
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Devuelve la lista de clientes que esta en la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> LeerCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "select * from ClientesTPFinal order by ID";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    Cliente cliente = new Cliente(id, nombre, apellido);
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        /// <summary>
        /// Devuelve el cliente que se encuentra en el id pasado por parametro dentro de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cliente LeerDatosPorIDCliente(int id)
        {
            Cliente cliente = null;
            string query = "select * from ClientesTPFinal where id=@id";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(@query, connection);
                cmd.Parameters.AddWithValue("id", id);//Paso el parametro
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    cliente = new Cliente(id, nombre, apellido);
                }
            }

            return cliente;
        }

        /// <summary>
        /// Cambia el cliente que esta en el id pasado por parametro en la base de datos por el cliente que
        /// se pasa por parametro.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="id"></param>
        public static void ModificarCliente(Cliente cliente, int id)
        {
            string query = "update ClientesTPFinal set nombre=@nombre, apellido=@apellido where id=@id";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("apellido", cliente.Apellido);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Elimina el cliente que tiene el mismo id que se pasa por parametros de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        public static void BorrarCliente(int id)
        {
            string query = "DELETE FROM ClientesTPFinal where id=@id";
            using (SqlConnection connection = new SqlConnection(VideoJuegoDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

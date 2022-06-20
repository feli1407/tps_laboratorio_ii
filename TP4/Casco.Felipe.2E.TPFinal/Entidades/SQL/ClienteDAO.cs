using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SQL
{
    public class ClienteDAO
    {
        private static string cadenaConexion;

        static ClienteDAO()
        {
            ClienteDAO.cadenaConexion = "Server=DESKTOP-2JGV9AR;Database=TPFinalCascoFelipe;Trusted_Connection=True;";
        }

        /// <summary>
        /// Guarda el cliente que se le pasa por parametro en la base de datos, en la respectiva tabla de clientes.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool Guardar(Cliente cliente)
        {
            bool retorno = false;

            string query = "insert into ClientesTPFinal (Nombre, Apellido) values (@nombre, @apellido)";
            using (SqlConnection conexion = new SqlConnection(ClienteDAO.cadenaConexion))
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
        public static List<Cliente> Leer()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "select * from ClientesTPFinal order by ID";
            using (SqlConnection connection = new SqlConnection(ClienteDAO.cadenaConexion))
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
        public static Cliente LeerDatosPorID(int id)
        {
            Cliente cliente = null;
            string query = "select * from ClientesTPFinal where id=@id";
            using (SqlConnection connection = new SqlConnection(ClienteDAO.cadenaConexion))
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
        public static void Modificar(Cliente cliente, int id)
        {
            string query = "update ClientesTPFinal set nombre=@nombre, apellido=@apellido where id=@id";
            using (SqlConnection connection = new SqlConnection(ClienteDAO.cadenaConexion))
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
        public static void Borrar(int id)
        {
            string query = "DELETE FROM ClientesTPFinal where id=@id";
            using (SqlConnection connection = new SqlConnection(ClienteDAO.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

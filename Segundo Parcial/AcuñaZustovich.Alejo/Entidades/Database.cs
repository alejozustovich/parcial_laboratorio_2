using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class Database
    {
        #region Atributos
        private const string cadena = @"Server=.\SQLEXPRESS;Database=LocalComidas;Integrated security=true";
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estático: instancia la conexión y el comando.
        /// </summary>
        static Database()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = cadena;

            comando = new SqlCommand();
            comando.Connection = conexion;
        }
        #endregion

        #region Insertar Pedido
        /// <summary>
        /// Ingresa un nuevo pedido en la base de datos.
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool InsertarPedido(Pedido p1)
        {
            try
            {
                int flag = 0;

                if(!(p1 is null))
                {
                    if (p1.Delivery is true)
                        flag = 1;
                }
                else
                {
                    throw new PedidoException("Agregame la direccion pa");
                }
                
                conexion.Open();
                comando.CommandText = "INSERT INTO Pedido VALUES (@comida, @precio, @flag_delivery, @direccion, @estado)";
                comando.Parameters.Clear();
                //comando.Parameters.Add(new SqlParameter("@ticket", p1.Ticket)); // hago el ticket identity porque si cierro la app y vuelvo a abrir me pisa id y tira error.
                comando.Parameters.Add(new SqlParameter("@comida", p1.Comida.Plato));
                comando.Parameters.Add(new SqlParameter("@precio", p1.Comida.Precio));
                comando.Parameters.Add(new SqlParameter("@flag_delivery", flag));
                comando.Parameters.Add(new SqlParameter("@direccion", p1.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("@estado", p1.Estado.ToString()));
                return comando.ExecuteNonQuery() != -1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion





        #region Importar Pedidos
        public static List<Pedido> ImportarPedidos(Local l1)
        {
            try
            {
                List<Pedido> p1 = new List<Pedido>();
                comando.CommandText =
                    "SELECT Pedido.ticket, Comida.nombre, Comida.precio, Pedido.flag_delivery, Pedido.direccion, Pedido.estado " +
                    "FROM Pedido " +
                    "INNER JOIN Comida ON Pedido.id_comida = Comida.id";
                conexion.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    Pedido pAux = new Pedido(
                        int.Parse(dr["ticket"].ToString()),
                        l1.Comidas.BuscarDescripcion(dr["nombre"].ToString()),
                        int.Parse(dr["precio"].ToString()),
                        (int.Parse(dr["flag_delivery"].ToString()) == 0 ? false : true),
                        dr["direccion"].ToString(),
                        (Pedido.EEstado)Enum.Parse(typeof(Pedido.EEstado), dr["estado"].ToString()));

                    p1.Add(pAux);
                }

                return p1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Insertar Comida
        /// <summary>
        /// Ingresa un nuevo pedido en la base de datos.
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool InsertarComida(Comida c1)
        {
            try
            {
                conexion.Open();
                comando.CommandText = "INSERT INTO Comida VALUES (@nombre, @precio)";
                comando.Parameters.Clear();
                comando.Parameters.Add(new SqlParameter("@nombre", c1.Plato));
                comando.Parameters.Add(new SqlParameter("@nombre", c1.Precio));

                return comando.ExecuteNonQuery() != -1;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion
    }
}

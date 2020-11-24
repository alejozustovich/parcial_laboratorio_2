using Archivos;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Entidades
{
    public class Local
    {
        #region Atributos
        public List<Thread> hiloPedidos;
        private List<Pedido> pedidos;
        private List<Comida> comidas;
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura para los Pedidos.
        /// </summary>
        public List<Pedido> Pedidos { get { return this.pedidos; } set { this.pedidos = value; } }

        /// <summary>
        /// Permisos de lectura y escritura para las Comidas.
        /// </summary>
        public List<Comida> Comidas { get { return this.comidas; } set { this.comidas = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Local()
        {
            this.hiloPedidos = new List<Thread>();
            this.pedidos = new List<Pedido>();
            this.comidas = new List<Comida>();
        }
        #endregion

        #region Mostrar Pedidos
        /// <summary>
        /// Muestra todos los pedidos.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public string MostrarDatos(List<Pedido> pedidos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Pedido p in pedidos)
            {
                sb.Append(string.Format("Pedido {0}: {1} para {2} ({3}) \n", p.Ticket, p.Comida.Plato, p.DireccionEntrega, p.Estado.ToString()));
            }

            return sb.ToString();
        }
        #endregion

        #region Hilos - Cierre
        /// <summary>
        /// Si los hilos están abiertos, los cierra.
        /// </summary>
        public void FinPreparaciones()
        {
            foreach (Thread t in this.hiloPedidos)
            {
                if (t != null && t.IsAlive)
                {
                    t.Abort();
                }
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Agrega un pedido al local e inicio su respectivo hilo.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Local operator +(Local l, Pedido p)
        {
            try
            {
                if (l.Pedidos is null)
                {
                    l.Pedidos.Add(p);
                }
                else
                {
                    foreach (Pedido item in l.Pedidos)
                    {
                        if (p.Ticket == item.Ticket)
                            throw new PedidoException("El pedido ya se encuentra registrado.");
                    }

                    l.Pedidos.Add(p);
                }

                Thread t = new Thread(p.EtapasPedido);
                l.hiloPedidos.Add(t);
                //Thread.Sleep(4000);
                t.Start();

                return l;
            }
            catch (Exception e)
            {
                throw new PedidoException("Ocurrió un error con la generación del pedido", e);
            }
        }
        #endregion

        #region Archivos
        /// <summary>
        /// Serializa los pedidos en un XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public static bool Guardar(List<Pedido> pedidos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Pedidos.xml";
                XmlSerializer xml = new XmlSerializer(typeof(List<Pedido>));
                XML<List<Pedido>> archivo = new XML<List<Pedido>>();

                archivo.Guardar(path, pedidos);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
        #endregion

        #region Database
        /// <summary>
        /// Ingresa los nuevos pedidos a la base de datos.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool InsertarDB(List<Pedido> l)
        {
            try
            {
                for (int i = 0; i < l.Count; i++)
                {
                    Database.InsertarPedido(l[i]);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new DBException(e);
            }
        }
        #endregion
    }
}

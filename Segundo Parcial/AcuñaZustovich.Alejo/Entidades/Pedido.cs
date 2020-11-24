using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        #region Atributos
        public enum EEstado { Ingresado, EnPreparacion, Listo };
        public delegate void DelegadoEstado(object sender);
        public event DelegadoEstado InformaEstado;
        private int ticket;
        private Comida comida;
        private int precio;
        private bool delivery;
        private string direccionEntrega;
        private EEstado estado;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Pedido()
        {

        }

        /// <summary>
        /// Constructor parametrizado: nuevos pedidos sin delivery.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="comida"></param>
        /// <param name="precio"></param>
        public Pedido(int ticket, Comida comida, int precio) : this()
        {
            this.ticket = ticket;
            this.comida = comida;
            this.precio = precio;
            this.estado = EEstado.Ingresado;
            this.delivery = false;
            this.direccionEntrega = "Sin delivery";
        }

        /// <summary>
        /// Constructor parametrizado: nuevos pedidos con delivery.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="comida"></param>
        /// <param name="precio"></param>
        /// <param name="direccion"></param>
        public Pedido(int ticket, Comida comida, int precio, string direccion) : this()
        {
            this.ticket = ticket;
            this.comida = comida;
            this.precio = precio;
            this.estado = EEstado.Ingresado;
            this.delivery = true;
            this.direccionEntrega = direccion;
        }

        /// <summary>
        /// Constructor parametrizado: pedidos levantados desde la Base de Datos.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="comida"></param>
        /// <param name="precio"></param>
        /// <param name="delivery"></param>
        /// <param name="direccion"></param>
        /// <param name="estado"></param>
        public Pedido(int ticket, Comida comida, int precio, bool delivery, string direccion, EEstado estado) : this()
        {
            this.ticket = ticket;
            this.comida = comida;
            this.precio = precio;
            this.delivery = delivery;
            this.direccionEntrega = direccion;
            this.estado = estado;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de lectura y escritura para los atributos.
        /// </summary>
        public int Ticket 
        { 
            get { return this.ticket; }
            set
            {
                try
                {
                    this.ticket = value;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }
        }
        public Comida Comida { get { return this.comida; } set { this.comida = value; } }
        public int Precio { get { return this.precio; } }
        public bool Delivery { get { return this.delivery; } set { this.delivery = value; } }
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        #endregion

        #region Hilos - Pedidos
        /// <summary>
        /// Actualiza el estado de los nuevos pedidos cada 4 segundos.
        /// Mientras no esté Listado, seteo estado cada 4 segundos.
        /// </summary>
        public void EtapasPedido()
        {
            while (this.estado != EEstado.Listo)
            {
                Thread.Sleep(4000);

                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnPreparacion;
                        break;

                    case EEstado.EnPreparacion:
                        this.estado = EEstado.Listo;
                        break;
                }

                InformaEstado.Invoke(this);
            }
        }
        #endregion

        #region Archivos
        /// <summary>
        /// Guarda el ticket del pedido para el delivery.
        /// </summary>
        /// <returns></returns>
        public bool Guardar(string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Ticket_" + this.Ticket.ToString() + ".txt";

                Texto texto = new Texto();

                texto.Guardar(path, datos);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }

        /// <summary>
        /// Lee los pedidos de un XML.
        /// </summary>
        /// <returns></returns>
        public static List<Pedido> Leer()
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Pedidos.xml";
                XML<List<Pedido>> archivo = new XML<List<Pedido>>();
                archivo.Leer(path, out pedidos);

                return pedidos;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
        #endregion

        #region Mostrar Pedidos
        /// <summary>
        /// Muestra los datos de los pedidos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string MostrarDatos(Pedido p)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0} a entregar en: {1} ${2}\n", p.Comida.Plato, p.direccionEntrega, p.Comida.Precio));
            
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos pedidos son iguales si tienen el mismo ticket.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Pedido p1, Pedido p2)
        {
            return p1.Ticket == p2.Ticket;
        }
        /// <summary>
        /// Valida que dos pedidos sean diferentes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Pedido p1, Pedido p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}

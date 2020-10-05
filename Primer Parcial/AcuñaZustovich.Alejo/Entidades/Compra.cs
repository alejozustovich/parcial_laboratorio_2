using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra
    {
        #region ATRIBUTOS
        int nroTicket;
        List<Producto> productos;
        double precio;
        Cliente comprador;
        Empleado vendedor;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor parametrizado: asigna los atributos de la compra.
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="precio"></param>
        /// <param name="comprador"></param>
        /// <param name="vendedor"></param>
        public Compra(List<Producto> productos, double precio, Cliente comprador, Empleado vendedor)
        {
            this.nroTicket = Inventario.AsignarNroTicket();
            this.productos = productos;
            this.precio = precio;
            this.comprador = comprador;
            comprador.Compras ++;
            this.vendedor = vendedor;
            vendedor.Ventas ++;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de sólo lectura para el ticket.
        /// </summary>
        public int NroTicket
        {
            get { return this.nroTicket; }
        }

        /// <summary>
        /// Propiedad de sólo lectura para los productos: devuelve descripciones.
        /// </summary>
        public string Productos
        {
            get { return GetDescripciones(this); }
        }

        /// <summary>
        /// Propiedad de sólo lectura para el precio.
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
        }

        /// <summary>
        /// Propiedad de sólo lectura para el comprador: devuelve el nombre.
        /// </summary>
        public string Comprador
        {
            get { return this.comprador.Comprador; }
        }

        /// <summary>
        /// Propiedad de sólo lectura: devuelve el nombre.
        /// </summary>
        public string Vendedor
        {
            get { return this.vendedor.Vendedor; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna las descripciones de los productos de la compra.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Descripciones de los productos.</returns>
        private static string GetDescripciones(Compra c)
        {
            string descripciones = string.Empty;

            foreach (Producto producto in c.productos)
            {
                descripciones += producto.Descripcion + ". ";
            }

            return descripciones;
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Muestra todos los datos de la compra.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Datos de la compra.</returns>
        public static string ToString(Compra c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TICKET : " + c.NroTicket.ToString());
            sb.AppendLine("************");
            sb.AppendLine("\nPRODUCTOS : " + c.Productos);
            sb.AppendLine("PRECIO : $" + c.Precio.ToString());
            sb.AppendLine(c.vendedor.Mostrar());
            sb.AppendLine(c.comprador.Mostrar());
            return sb.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        #region ATRIBUTOS
        int id;
        string descripcion;
        double precio;
        int unidadesVendidas;
        int unidadesEnStock;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor parametrizado: asigna todos los atributos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(int id, string descripcion, double precio, int stock)
        {
            this.descripcion = descripcion;
            this.id = id;
            this.precio = precio;
            this.unidadesEnStock = stock;
            this.unidadesVendidas = 0;
        }

        /// <summary>
        /// Constructor parametrizado: asigna unidades vendidas para productos hardcodeados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        /// <param name="vendidas"></param>
        public Producto(int id, string descripcion, double precio, int stock, int vendidas) : this(id,descripcion,precio,stock)
        {
            this.unidadesVendidas = vendidas;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Permisos de sólo lectura para el id.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Permisos de sólo lectura para la descripción.
        /// </summary>
        public string Descripcion
        {
            get { return this.descripcion; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para el precio.
        /// </summary>
        public double Precio
        {
            get { return this.precio; }
            set { precio = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para las unidades vendidas.
        /// </summary>
        public int Vendidos
        {
            get { return this.unidadesVendidas; }
            set { unidadesVendidas = value; }
        }

        /// <summary>
        /// Permisos de lectura y escritura para las unidades en stock.
        /// </summary>
        public int Stock
        {
            get { return this.unidadesEnStock; }
            set { unidadesEnStock = value; }
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Evalúa si el producto ya existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator == (List<Producto> listadoProductos, Producto producto)
        {
            foreach (Producto p in listadoProductos)
            {
                if (p.Id == producto.Id)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Evalúa si el producto no existe en el listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator != (List<Producto> listadoProductos, Producto producto)
        {
            return !(listadoProductos == producto);
        }

        /// <summary>
        /// Agrega un producto al listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si se pudo agregar, caso contrario False.</returns>
        public static bool operator + (List<Producto> listadoProductos, Producto producto)
        {
            if (listadoProductos == producto)
                return false;
            
            listadoProductos.Add(producto);
            return true;
        }

        /// <summary>
        /// Elimina un producto del listado.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>True si se pudo eliminar, caso contrario False.</returns>
        public static bool operator - (List<Producto> listadoProductos, Producto producto)
        {
            if (listadoProductos != producto)
                return false;

            for (int i = 0; i < listadoProductos.Count; i++)
            {
                if (listadoProductos[i].Id == producto.Id)
                {
                    listadoProductos.RemoveAt(i);
                    break;
                }
            }

            return true;
        }
        #endregion
    }
}
using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Comida
    {
        #region Propiedades
        public string Plato { get; set; }
        public int Precio { get; set; }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Comida()
        {

        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        public Comida(string nombre, int precio) : this()
        {
            this.Plato = nombre;
            this.Precio = precio;
        }
        #endregion

        #region Archivos

        /// <summary>
        /// Guarda el listado de comidas en XML.
        /// </summary>
        /// <param name="comidas"></param>
        /// <returns></returns>
        public static bool Guardar(List<Comida> comidas)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Comidas.xml";
                XmlSerializer xml = new XmlSerializer(typeof(List<Pedido>));
                XML<List<Comida>> archivo = new XML<List<Comida>>();

                archivo.Guardar(path, comidas);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }

        /// <summary>
        /// Lee un XML con las comidas.
        /// </summary>
        /// <returns></returns>
        public static List<Comida> Leer()
        {
            try
            {
                List<Comida> comidas = new List<Comida>();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Comidas.xml";
                XML<List<Comida>> archivo = new XML<List<Comida>>();
                archivo.Leer(path, out comidas);

                return comidas;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Valida que una comida exista en el local.
        /// </summary>
        /// <param name="l"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool operator ==(Local l, Comida c)
        {
            foreach (Comida item in l.Comidas)
            {
                if (c.Plato == item.Plato)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Valida que una comida no exista en el local.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns>.</returns>
        public static bool operator !=(Local l, Comida c)
        {
            return !(l == c);
        }

        /// <summary>
        /// Agrega una comida al local.
        /// </summary>
        /// <param name="listadoProductos"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static Local operator +(Local l, Comida c)
        {
            if (l != c)
            {
                l.Comidas.Add(c);
                return l;
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion
    }
}

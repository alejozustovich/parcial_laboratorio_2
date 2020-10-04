using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        #region ATRIBUTOS
        int codigoCliente;
        int cantidadCompras;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor parametrizado: asigna los atributos.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="codigo"></param>
        public Cliente(int dni, string nombre, string apellido, int codigo) : base(nombre, apellido, dni)
        {
            this.codigoCliente = codigo;
            this.cantidadCompras = 0;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de sólo lectura: devuelve el nombre completo.
        /// </summary>
        public string Comprador
        {
            get { return base.Nombre + " " + base.Apellido; }
        }

        /// <summary>
        /// Propiedad de sólo lectura para el código.
        /// </summary>
        public int Codigo
        {
            get { return this.codigoCliente; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la cantidad de compras.
        /// </summary>
        public int Compras
        {
            get { return this.cantidadCompras; }
            set { this.cantidadCompras = value; }
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga == : evalúa si el cliente existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        public static bool operator == (List<Cliente> listadoClientes, Cliente cliente)
        {
            foreach  (Cliente c in listadoClientes)
            {
                if (c.Codigo == cliente.Codigo)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga != : evalúa si el cliente no existe en la lista.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si no existe, caso contrario False.</returns>
        public static bool operator != (List<Cliente> listadoClientes, Cliente cliente)
        {
            return !(listadoClientes == cliente);
        }

        /// <summary>
        /// Sobrecarga + : si el cliente no existe en la lista, lo agrega.
        /// </summary>
        /// <param name="listadoClientes"></param>
        /// <param name="cliente"></param>
        /// <returns>True si lo pudo agregar, caso contrario False.</returns>
        public static bool operator + (List<Cliente> listadoClientes, Cliente cliente)
        {
            if (listadoClientes == cliente)
                return false;
            
            listadoClientes.Add(cliente);
            return true;
        }
        #endregion
    }
}

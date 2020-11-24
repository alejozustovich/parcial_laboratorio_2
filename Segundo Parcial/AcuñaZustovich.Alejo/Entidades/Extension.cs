using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class Extension
    {
        /// <summary>
        /// Extiende un método para una lista retornando el proximo id.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public static int ProximoID(this List<Pedido> pedidos)
        {
            int ultimoID = 0;

            foreach (Pedido item in pedidos)
            {
                if (item is null)
                    return 1;

                if (item.Ticket > ultimoID)
                    ultimoID = item.Ticket;
            }

            return ultimoID+1;
        }

        /// <summary>
        /// Extiende un método para una lista retornando el elemento por la descripción.
        /// </summary>
        /// <param name="comidas"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static Comida BuscarDescripcion(this List<Comida> comidas, string desc)
        {
            foreach (Comida item in comidas)
            {
                if (item.Plato == desc)
                    return item;
            }

            return null;
        }
    }
}

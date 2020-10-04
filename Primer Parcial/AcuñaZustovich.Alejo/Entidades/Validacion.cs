using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validacion
    {
        /// <summary>
        /// Valida que no sea una cadena vacía.
        /// </summary>
        /// <param name="arrayAux"></param>
        /// <returns>True si tienen datos, caso contrario False.</returns>
        public static bool StringConDatos(string[] arrayAux)
        {
            foreach (string aux in arrayAux)
            {
                if (aux == string.Empty)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que la cadena sea un número entero.
        /// </summary>
        /// <param name="aux"></param>
        /// <returns>El número convertido, caso contrario -1.</returns>
        public static int EsUnEntero(string aux)
        {
            if (int.TryParse(aux, out int numero))
                return numero;
            return -1;
        }

        /// <summary>
        /// Valida que la cadena sea un precio (double).
        /// </summary>
        /// <param name="aux"></param>
        /// <returns>El importe convertido, caso contrario -1.</returns>
        public static double EsUnPrecio(string aux)
        {
            if (double.TryParse(aux, out double precio))
                return precio;
            return -1;
        }
    }
}

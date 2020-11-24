using System;

namespace Archivos
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Excepción: Archivos.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivoException(Exception innerException) : base("Ha ocurrido un error con el archivo.", innerException)
        {

        }
    }
}

namespace Archivos
{
    public interface IArchivos <T>
    {
        /// <summary>
        /// Firma del método a implementar para guardar datos en un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Firma del método a implementar para leer datos de un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}

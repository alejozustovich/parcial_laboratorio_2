using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class XML <T> : IArchivos <T>
    {
        #region Metodos
        /// <summary>
        /// Implementación del Método: guarda datos en un archivo XML.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns>True si lo pudo guardar, caso contrario lanza excepcion.</returns>
        public bool Guardar(string path, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                using (StreamWriter sw = new StreamWriter(path))
                {
                    xml.Serialize(sw, datos);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }

        /// <summary>
        /// Implementación del Método: lee datos de un archivo XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si los pudo leer, caso contrario lanza excepcion.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                using (TextReader tr = new StreamReader(archivo))
                {
                    datos = (T)xml.Deserialize(tr);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
        #endregion
    }
}

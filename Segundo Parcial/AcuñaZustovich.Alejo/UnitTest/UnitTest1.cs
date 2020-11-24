using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(PedidoException))]
        public void ExcepcionPedidoRepetido()
        {
            Local l1 = new Local();

            Pedido p1 = new Pedido(1, l1.Comidas.BuscarDescripcion("milanga a la napolitana"), 200);
            Pedido p2 = new Pedido(1, l1.Comidas.BuscarDescripcion("asadito"), 200);

            l1 += p1;
            l1 += p2;
        }

        /// <summary>
        /// Valida que se lance la Excepción al intentar guardar en un directorio sin especificar.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void GuardarArchivoTexto()
        {
            Texto texto = new Texto();
            texto.Guardar(null, "asd");
            texto.Guardar(string.Empty, "asd");
            texto.Guardar("", "asd");
        }

        /// <summary>
        /// Valida que se lance la Excepción al intentar leer de un directorio sin especificar.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void LeerArchivoTexto()
        {
            Texto texto = new Texto();
            texto.Leer(null, out string datos);
            texto.Leer(string.Empty, out string datos2);
            texto.Leer("", out string datos3);
        }
    }
}

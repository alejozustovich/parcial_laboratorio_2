using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoException : Exception
    {
        public PedidoException(string mensaje) : base(mensaje)
        {

        }

        public PedidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}

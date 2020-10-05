using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        #region ATRIBUTOS
        int legajo;
        int cantidadVentas;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor parametrizado: asigna los atributos.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="legajo"></param>
        /// <param name="ventas"></param>
        public Empleado(int dni, string nombre, string apellido, int legajo) : base(nombre, apellido, dni)
        {
            this.legajo = legajo;
            this.cantidadVentas = 0;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de sólo lectura: devuelve el nombre completo.
        /// </summary>
        public string Vendedor
        {
            get { return base.NombreCompleto; }
        }

        /// <summary>
        /// Propiedad de sólo lectura: devuelve el legajo.
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para las ventas.
        /// </summary>
        public int Ventas
        {
            get { return this.cantidadVentas; }
            set { this.cantidadVentas = value; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra todos los datos del empleado.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nVENDEDOR");
            sb.AppendLine("**********");
            sb.AppendLine((string)this);
            sb.Append("Legajo : " + this.Legajo);
            return sb.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        string nombre;
        string apellido;
        int dni;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor parametrizado: asigna los atributos de la persona.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        protected Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Permisos de sólo lectura para el nombre.
        /// </summary>
        private string Nombre
        {
            get { return this.nombre; }
        }

        /// <summary>
        /// Permisos de sólo lectura para el apellido.
        /// </summary>
        private string Apellido
        {
            get { return this.apellido; }
        }

        protected string NombreCompleto
        {
            get { return this.Nombre + " " + this.Apellido; }
        }

        /// <summary>
        /// Permisos de sólo lectura para el dni.
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Sobrecarga explicita del operador string: muestra atributos de la persona.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Persona p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre : " + p.NombreCompleto);
            sb.Append("Dni : " + p.Dni);
            return sb.ToString();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra los atributos de la persona.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return this.ToString();
        }
        #endregion
    }
}

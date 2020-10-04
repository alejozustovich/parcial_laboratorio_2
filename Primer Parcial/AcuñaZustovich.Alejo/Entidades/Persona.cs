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
        protected string Nombre
        {
            get { return this.nombre; }
        }

        /// <summary>
        /// Permisos de sólo lectura para el apellido.
        /// </summary>
        protected string Apellido
        {
            get { return this.apellido; }
        }

        /// <summary>
        /// Permisos de sólo lectura para el dni.
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
        }
        #endregion
    }
}

using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmAltaCliente : Form
    {
        #region ATRIBUTOS
        Cliente cliente;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Permisos de sólo lectura para el cliente.
        /// </summary>
        public Cliente Cliente
        {
            get { return this.cliente; }
        }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmAltaCliente()
        {
            InitializeComponent();
        }
        #endregion

        #region ACEPTAR
        /// <summary>
        /// Crea el cliente con los campos completados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string[] campos = new string[] { this.txtDNI.Text, this.txtNombre.Text, this.txtApellido.Text, this.txtCodigo.Text };

            if(Validacion.StringConDatos(campos))
            {
                int dni = Validacion.EsUnEntero(campos[0]);
                int codigo = Validacion.EsUnEntero(campos[3]);

                if(dni != -1 && codigo != -1)
                {
                    cliente = new Cliente(dni, campos[1], campos[2], codigo);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Valores incorrectos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Se deben completar todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region CANCELAR
        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

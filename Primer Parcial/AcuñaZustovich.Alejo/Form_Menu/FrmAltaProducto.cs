using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Forms
{
    public partial class FrmAltaProducto : Form
    {
        #region ATRIBUTOS
        public Producto producto;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmAltaProducto()
        {
            InitializeComponent();
        }
        #endregion

        #region ACEPTAR
        /// <summary>
        /// Crea el producto con los atributos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string[] campos = { this.txtID.Text, this.txtDescripcion.Text, this.txtPrecio.Text, this.txtUnidadesStock.Text };

            if(Validacion.StringConDatos(campos))
            {
                int id = Validacion.EsUnEntero(campos[0]);
                double precio = Validacion.EsUnPrecio(campos[2]);
                int stock = Validacion.EsUnEntero(campos[3]);

                if(id != -1 && precio != -1 && stock != -1)
                {
                    producto = new Producto(id, campos[1], precio, stock);
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

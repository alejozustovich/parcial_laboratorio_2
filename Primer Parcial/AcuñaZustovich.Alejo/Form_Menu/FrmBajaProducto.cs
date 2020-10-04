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
    public partial class FrmBajaProducto : Form
    {
        #region ATRIBUTOS
        public Producto producto;
        int id;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmBajaProducto()
        {
            InitializeComponent();
        }
        #endregion

        #region LOAD
        /// <summary>
        /// Carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBajaProducto_Load(object sender, EventArgs e)
        {
            id = -1;
        }
        #endregion

        #region BUSCAR ID DEL PRODUCTO
        /// <summary>
        /// Busca el producto según el ID ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            id = Validacion.EsUnEntero(this.txtID.Text);

            if(id != -1)
            {
                int indice = Inventario.BuscarIndicePorID(Inventario.ListadoProductos, id);

                if(indice != -1)
                {
                    this.txtDescripcion.Text = Inventario.ListadoProductos[indice].Descripcion;
                    this.txtPrecio.Text = (Inventario.ListadoProductos[indice].Precio).ToString();
                    this.txtUnidadesStock.Text = (Inventario.ListadoProductos[indice].Stock).ToString();
                    this.txtVendidos.Text = (Inventario.ListadoProductos[indice].Vendidos).ToString();
                }
                else
                    MessageBox.Show("El ID no corresponde a un producto registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Formato incorrecto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region ACEPTAR
        /// <summary>
        /// Devuelve el producto a eliminar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                producto = new Producto(id,
                    this.txtDescripcion.Text,
                    Convert.ToDouble(this.txtPrecio.Text),
                    Convert.ToInt32(this.txtUnidadesStock.Text),
                    Convert.ToInt32(this.txtVendidos.Text));

                    this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Se debe completar el ID del producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

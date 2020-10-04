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
    public partial class FrmModifProducto : Form
    {
        #region ATRIBUTOS
        int indice;
        int id;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmModifProducto()
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
        private void FrmModifProducto_Load(object sender, EventArgs e)
        {
            indice = -1;
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

            if (id != -1)
            {
                indice = Inventario.BuscarIndicePorID(Inventario.ListadoProductos, id);
              
                if (indice != -1)
                {
                    this.txtDescripcion.Text = Inventario.ListadoProductos[indice].Descripcion;
                    this.txtPrecio.Text = (Inventario.ListadoProductos[indice].Precio).ToString();
                    this.txtUnidadesStock.Text = (Inventario.ListadoProductos[indice].Stock).ToString();
                    this.txtVendidos.Text = (Inventario.ListadoProductos[indice].Vendidos).ToString();

                    this.txtID.ReadOnly = true;
                    this.txtPrecio.ReadOnly = false;
                    this.txtUnidadesStock.ReadOnly = false;
                    this.txtVendidos.ReadOnly = false;
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
        /// Devuelve el producto con los atributos modificados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                double precio = Validacion.EsUnPrecio(this.txtPrecio.Text);
                int stock = Validacion.EsUnEntero(this.txtUnidadesStock.Text);
                int vendidas = Validacion.EsUnEntero(this.txtVendidos.Text);

                if (precio != -1 && stock != -1 && vendidas != -1)
                {
                    Inventario.ListadoProductos[indice].Precio = precio;
                    Inventario.ListadoProductos[indice].Vendidos = vendidas;
                    Inventario.ListadoProductos[indice].Stock = stock;

                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Datos ingresados erróneos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

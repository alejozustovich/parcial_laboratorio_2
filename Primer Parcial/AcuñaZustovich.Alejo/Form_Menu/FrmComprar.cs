using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Forms
{
    public partial class FrmComprar : Form
    {
        #region ATRIBUTOS
        List<Producto> carrito;
        Cliente comprador;
        Empleado vendedor;
        Producto producto;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmComprar()
        {
            InitializeComponent();
            carrito = new List<Producto>();
        }
        #endregion

        #region LOAD
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComprar_Load(object sender, EventArgs e)
        {
            this.dgvProductos.DataSource = Inventario.ListadoProductos;
            this.dgvClientes.DataSource = Inventario.ListadoClientes;
            this.dgvEmpleados.DataSource = Inventario.ListadoEmpleados;
        }
        #endregion

        #region COMPRAR
        /// <summary>
        /// Toma los datos del datagridview y los textbox para crear la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            bool hayStock = true;

            foreach (DataGridViewRow fila in dgvProductos2.Rows)
            {
                string descripcion = fila.Cells["Descripcion"].Value.ToString();
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                producto = Inventario.BuscarProductoPorDescripcion(Inventario.ListadoProductos, descripcion);
                
                if(producto.Stock >= cantidad)
                {
                    carrito.Add(producto);
                    Inventario.ProductoComprado(producto, cantidad);
                }
                else
                {
                    hayStock = false;
                    break;
                }
            }

            if(!hayStock)
            {
                MessageBox.Show("No hay stock.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnComprar.Enabled = false;
            }
            else
            {
                comprador = Inventario.BuscarClientePorNombre(Inventario.ListadoClientes, this.txtCliente.Text);
                vendedor = Inventario.BuscarEmpleadoPorNombre(Inventario.ListadoEmpleados, this.txtVendedor.Text);

                Compra unaCompra = new Compra(carrito, Convert.ToDouble(this.txtPrecio.Text), comprador, vendedor);

                Inventario.ListadoCompras.Add(unaCompra);

                MessageBox.Show(Compra.ToString(unaCompra), "¡Muchas gracias por su compra!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TextWriter ticket = new StreamWriter("ticket.txt", true);
                ticket.WriteLine("FECHA Y HORA: " + DateTime.Now.ToString() + "\n");
                ticket.WriteLine(Compra.ToString(unaCompra));
                ticket.WriteLine("********************\n");
                ticket.Close();

                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region CALCULAR PRECIO
        /// <summary>
        /// Calcula el precio total de la compra en base a los productos y la cantidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            bool validacion = true;
            double precio = 0;
            int cantidad = -1;
            
            foreach (DataGridViewRow fila in dgvProductos2.Rows)
            {
                cantidad = Validacion.EsUnEntero(fila.Cells["Cantidad"].Value.ToString());

                if(cantidad == -1)
                {
                    validacion = false;
                    break;
                }
                else
                    precio += (Convert.ToDouble(fila.Cells["Precio"].Value) * cantidad);
             }

            if(validacion)
            {
                if (this.txtCliente.Text.Contains("Simpson"))
                    precio -= (precio * 13 / 100);

                this.txtPrecio.Text = precio.ToString();
                btnComprar.Enabled = true;
                precio = 0;
            }
            else
                MessageBox.Show("Datos erróneos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Devuelve una celda específica de la fila seleccionada del datagridview
        /// </summary>
        /// <param name="aux"></param>
        /// <param name="celda"></param>
        /// <returns></returns>
        private string PasarFilaDGV(DataGridView aux, string celda)
        {
            return aux.CurrentRow.Cells[celda].Value.ToString();
        }
        #endregion

        #region DOBLE CLICK
        /// <summary>
        /// Asigna el nombre de la fila seleccionada al campo Cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCliente.Text = PasarFilaDGV(this.dgvClientes, "Comprador");
        }

        /// <summary>
        /// Asigna el nombre de la fila seleccionada al campo Vendedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtVendedor.Text = PasarFilaDGV(this.dgvEmpleados, "Vendedor");
        }

        /// <summary>
        /// Copia el producto seleccionado al segundo datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string descripcion = this.dgvProductos.CurrentRow.Cells[1].Value.ToString();
            string precio = this.dgvProductos.CurrentRow.Cells[2].Value.ToString();

            dgvProductos2.Rows.Add(descripcion, precio);
        }
        #endregion

        #region LIMPIAR
        /// <summary>
        /// Borra todos los registros del datagridview que recibe los productos seleccionados y el precio calculado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dgvProductos2.Rows.Clear();
            this.txtPrecio.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtVendedor.Text = string.Empty;
        }
        #endregion

        #region NUEVO CLIENTE
        /// <summary>
        /// Instancia un nuevo formulario para dar de alta un cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente agregarCliente = new FrmAltaCliente();

            if (agregarCliente.ShowDialog() == DialogResult.OK)
            {
                if (Inventario.AgregarCliente(agregarCliente.Cliente))
                {
                    this.dgvClientes.DataSource = null;
                    this.dgvClientes.DataSource = Inventario.ListadoClientes;
                    MessageBox.Show("El cliente se agregó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("El cliente ya existe en el negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

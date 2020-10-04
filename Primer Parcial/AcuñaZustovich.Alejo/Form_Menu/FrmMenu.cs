using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Form_Menu.Properties;

namespace Forms
{
    public partial class FrmMenu : Form
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor sin parámetros del formulario.
        /// </summary>
        public FrmMenu()
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
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Inventario.CargaInformacion();

            this.RefrescarDataGridProductos(Inventario.ListadoProductos);
            this.RefrescarDataGridClientes(Inventario.ListadoClientes);
            this.RefrescarDataGridEmpleados(Inventario.ListadoEmpleados);
            this.RefrescarDataGridCompras(Inventario.ListadoCompras);

            this.MostrarSoloUnDGV(this.dgvClientes,this.dgvCompras,this.dgvEmpleados,this.dgvProductos);
        }
        #endregion

        #region AGREGAR PRODUCTO
        /// <summary>
        /// Agrega un nuevo producto al negocio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            FrmAltaProducto agregarProducto = new FrmAltaProducto();

            if (agregarProducto.ShowDialog() == DialogResult.OK)
            {
                if (Inventario.AgregarProducto(agregarProducto.producto))
                {
                    this.MostrarProductos(this.dgvClientes, this.dgvEmpleados, this.dgvCompras, this.dgvProductos, Inventario.ListadoProductos);
                    MessageBox.Show("El producto se agregó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("El producto ya existe en el negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region MODIFICAR PRODUCTO
        /// <summary>
        /// Modifica uno o varios atributos de un producto existente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            FrmModifProducto modificacionProducto = new FrmModifProducto();

            if (modificacionProducto.ShowDialog() == DialogResult.OK)
            {
                this.MostrarProductos(this.dgvClientes, this.dgvEmpleados, this.dgvCompras, this.dgvProductos, Inventario.ListadoProductos);
                MessageBox.Show("El producto se modificó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ELIMINAR PRODUCTO
        /// <summary>
        /// Elimina un producto del negocio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            FrmBajaProducto eliminarProducto = new FrmBajaProducto();

            if (eliminarProducto.ShowDialog() == DialogResult.OK)
            {
                if(Inventario.QuitarProducto(eliminarProducto.producto))
                {
                    this.MostrarProductos(this.dgvClientes, this.dgvEmpleados, this.dgvCompras, this.dgvProductos, Inventario.ListadoProductos);
                    MessageBox.Show("El producto se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region COMPRAR
        /// <summary>
        /// Abre el formulario de Compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmComprar realizarCompra = new FrmComprar();

            if (realizarCompra.ShowDialog() == DialogResult.OK)
            {
                this.MostrarSoloUnDGV(this.dgvClientes, this.dgvEmpleados, this.dgvProductos, this.dgvCompras);
                this.RefrescarDataGridCompras(Inventario.ListadoCompras);

                SoundPlayer jefeDeLosMinisuper = new SoundPlayer(Resources.Compra);
                jefeDeLosMinisuper.Play();
                MessageBox.Show("Gracias!! Vuelva prontosss");
            }
        }
        #endregion

        #region LISTAR PRODUCTOS
        /// <summary>
        /// Lista los productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            this.MostrarProductos(this.dgvClientes,this.dgvEmpleados,this.dgvCompras,this.dgvProductos, Inventario.ListadoProductos);
        }

        /// <summary>
        /// Lista productos con menos de 10 unidades en stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn10Unidades_Click(object sender, EventArgs e)
        {
            this.MostrarProductos(this.dgvClientes,this.dgvEmpleados,this.dgvCompras,this.dgvProductos, 
                Inventario.ProductosConMenos10Unidades(Inventario.ListadoProductos));
        }

        /// <summary>
        /// Actualiza y muestra productos.
        /// </summary>
        /// <param name="dgv1"></param>
        /// <param name="dgv2"></param>
        /// <param name="dgv3"></param>
        /// <param name="dgv4"></param>
        /// <param name="listAux"></param>
        private void MostrarProductos(DataGridView dgv1, DataGridView dgv2, DataGridView dgv3, DataGridView dgv4, List<Producto> listAux)
        {
            this.RefrescarDataGridProductos(listAux);
            this.MostrarSoloUnDGV(dgv1, dgv2, dgv3, dgv4);
        }
        #endregion

        #region LISTAR EMPLEADOS
        /// <summary>
        /// Lista los empleados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarEmpleados_Click(object sender, EventArgs e)
        {
            this.MostrarSoloUnDGV(this.dgvProductos,this.dgvClientes,this.dgvCompras,this.dgvEmpleados);
            this.RefrescarDataGridEmpleados(Inventario.ListadoEmpleados);
        }

        /// <summary>
        /// Listar vendedores con más de 10 ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMejoresVendedores_Click(object sender, EventArgs e)
        {
            this.MostrarSoloUnDGV(this.dgvProductos, this.dgvClientes, this.dgvCompras, this.dgvEmpleados);
            this.RefrescarDataGridEmpleados(Inventario.EmpleadosMas10Ventas(Inventario.EmpleadosMas10Ventas(Inventario.ListadoEmpleados)));
        }
        #endregion

        #region LISTAR CLIENTES
        /// <summary>
        /// Listar los clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            this.MostrarSoloUnDGV(this.dgvProductos,this.dgvEmpleados,this.dgvCompras,this.dgvClientes);
            this.RefrescarDataGridClientes(Inventario.ListadoClientes);
        }

        /// <summary>
        /// Listar los clientes con más de 10 compras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMejoresClientes_Click(object sender, EventArgs e)
        {
            this.MostrarSoloUnDGV(this.dgvProductos, this.dgvEmpleados, this.dgvCompras, this.dgvClientes);
            this.RefrescarDataGridClientes(Inventario.ClientesMas10Compras(Inventario.ClientesMas10Compras(Inventario.ListadoClientes)));
        }
        #endregion

        #region LISTAR COMPRAS
        /// <summary>
        /// Actualiza y muestra el DGV de Compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarCompras_Click(object sender, EventArgs e)
        {
            MostrarSoloUnDGV(this.dgvClientes, this.dgvEmpleados, this.dgvProductos, this.dgvCompras);
            RefrescarDataGridCompras(Inventario.ListadoCompras);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Actualiza datagridview de Productos.
        /// </summary>
        /// <param name="listAux"></param>
        private void RefrescarDataGridProductos(List<Producto> listAux)
        {
            this.dgvProductos.DataSource = null;
            this.dgvProductos.DataSource = listAux;
        }

        /// <summary>
        /// Actualiza datagridview de Empleados.
        /// </summary>
        /// <param name="listAux"></param>
        private void RefrescarDataGridEmpleados(List<Empleado> listAux)
        {
            this.dgvEmpleados.DataSource = null;
            this.dgvEmpleados.DataSource = listAux;
        }

        /// <summary>
        /// Actualiza datagridview de Clientes.
        /// </summary>
        /// <param name="listAux"></param>
        private void RefrescarDataGridClientes(List<Cliente> listAux)
        {
            this.dgvClientes.DataSource = null;
            this.dgvClientes.DataSource = listAux;
        }

        /// <summary>
        /// Actualiza datagridview de Compras.
        /// </summary>
        /// <param name="listAux"></param>
        private void RefrescarDataGridCompras(List<Compra> listAux)
        {
            this.dgvCompras.DataSource = null;
            this.dgvCompras.DataSource = listAux;
        }

        /// <summary>
        /// Muestra un sólo datagridview en el formulario.
        /// </summary>
        /// <param name="dgvOculto1"></param>
        /// <param name="dgvOculto2"></param>
        /// <param name="dgvOculto3"></param>
        /// <param name="dgvVisible"></param>
        private void MostrarSoloUnDGV(DataGridView dgvOculto1, DataGridView dgvOculto2, DataGridView dgvOculto3, DataGridView dgvVisible)
        {
            dgvOculto1.Hide();
            dgvOculto2.Hide();
            dgvOculto3.Hide();
            dgvVisible.Show();
        }
        #endregion

        #region SALIR
        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                this.Show();
            else
                Application.Exit();
        }
        #endregion
    }
}

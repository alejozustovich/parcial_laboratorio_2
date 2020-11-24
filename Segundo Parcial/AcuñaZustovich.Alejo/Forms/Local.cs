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
using Archivos;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Forms
{
    public partial class Local : Form
    {
        #region Atributos
        private Entidades.Local local;
        private List<Pedido> pedidosAux;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Local()
        {
            InitializeComponent();
            local = new Entidades.Local();
            pedidosAux = new List<Pedido>();
        }
        #endregion

        #region Load
        /// <summary>
        /// Carga del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Local_Load(object sender, EventArgs e)
        {
            pedidosAux = Entidades.Pedido.Leer();
            local.Comidas = Entidades.Comida.Leer();
            dgvComidas.DataSource = local.Comidas;
            this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos);
        }
        #endregion

        #region Iniciar pedidos iniciales
        /// <summary>
        /// Preparar pedidos levantados de XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            foreach (Pedido item in pedidosAux)
            {
                local += item;
                item.InformaEstado += InformarEstado;
                this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos);
                this.ActualizarEstados();
            }
        }
        #endregion

        #region Actualizar estados
        /// <summary>
        /// Actualiza estados en los ListBox.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lbIngresados.Items.Clear();
            this.lbEnPreparacion.Items.Clear();
            this.lbListos.Items.Clear();

            foreach (Pedido p in local.Pedidos)
            {
                switch (p.Estado)
                {
                    case Pedido.EEstado.Ingresado:
                        lbIngresados.Items.Add(p);
                        this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos); break;

                    case Pedido.EEstado.EnPreparacion:
                        lbEnPreparacion.Items.Add(p);
                        this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos); break;

                    case Pedido.EEstado.Listo:
                        lbListos.Items.Add(p);
                        this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos); break;

                    default:
                        break;
                }
            }
        }
        #endregion

        #region Delegado
        /// <summary>
        /// Delego la acción de Actualizar los estados en ListBox ya que los hilos no tienen acceso.
        /// </summary>
        /// <param name="sender"></param>
        private void InformarEstado(object sender)
        {
            if (this.InvokeRequired)
            {
                Pedido.DelegadoEstado d = new Pedido.DelegadoEstado(InformarEstado);
                this.Invoke(d, new object[] { sender });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        #endregion

        #region Actualizar Pedidos
        private void btnMostrarPedidos_Click(object sender, EventArgs e)
        {
            if (!(local.Pedidos is null))
            {
                this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos);
            }
            else
            {
                MessageBox.Show("No hay pedidos registrados.");
            }
        }
        #endregion

        #region Agregar Nuevo Pedido

        /// <summary>
        /// Completa los textbox con la comida seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvComidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtComida.Text = dgvComidas.CurrentRow.Cells["Plato"].Value.ToString();
            this.txtPrecio.Text = dgvComidas.CurrentRow.Cells["Precio"].Value.ToString();
        }

        /// <summary>
        /// Crea un nuevo pedido con los campos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                string comida = txtComida.Text.ToString();
                int precio = int.Parse(txtPrecio.Text.ToString());
                string direccion = txtDireccion.Text.ToString();
                Pedido p1 = null;

                try
                {
                    if (cbDelivery.Checked)
                    {
                        if (direccion != string.Empty)
                        {
                            p1 = new Pedido(local.Pedidos.ProximoID(), local.Comidas.BuscarDescripcion(comida), precio, direccion);
                            p1.Guardar(p1.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Se debe completar la dirección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        p1 = new Pedido(local.Pedidos.ProximoID(), local.Comidas.BuscarDescripcion(comida), precio);
                    }

                    local += p1;
                    p1.InformaEstado += InformarEstado;
                    this.rtbPedidos.Text = local.MostrarDatos(local.Pedidos);
                    this.ActualizarEstados();
                }
                catch (PedidoException)
                {
                    MessageBox.Show("Ha ocurrido un error en la generación del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Se deben completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cierre
        /// <summary>
        /// Cerrando.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Local_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere salir?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Cierra el formulario y aborta los hilos que estén corriendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Local_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.local.InsertarDB(local.Pedidos);
            this.local.FinPreparaciones();
        }
        #endregion
    }
}

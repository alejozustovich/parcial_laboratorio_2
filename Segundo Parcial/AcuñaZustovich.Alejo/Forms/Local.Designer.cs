namespace Forms
{
    partial class Local
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbPedidos = new System.Windows.Forms.GroupBox();
            this.lbListos = new System.Windows.Forms.ListBox();
            this.lbEnPreparacion = new System.Windows.Forms.ListBox();
            this.lbIngresados = new System.Windows.Forms.ListBox();
            this.lblListos = new System.Windows.Forms.Label();
            this.lblPreparacion = new System.Windows.Forms.Label();
            this.lblIngresados = new System.Windows.Forms.Label();
            this.rtbPedidos = new System.Windows.Forms.RichTextBox();
            this.btnMostrarPedidos = new System.Windows.Forms.Button();
            this.gbNuevoPedido = new System.Windows.Forms.GroupBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtComida = new System.Windows.Forms.TextBox();
            this.dgvComidas = new System.Windows.Forms.DataGridView();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.cbDelivery = new System.Windows.Forms.CheckBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblComida = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.gbPedidos.SuspendLayout();
            this.gbNuevoPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComidas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPedidos
            // 
            this.gbPedidos.Controls.Add(this.lbListos);
            this.gbPedidos.Controls.Add(this.lbEnPreparacion);
            this.gbPedidos.Controls.Add(this.lbIngresados);
            this.gbPedidos.Controls.Add(this.lblListos);
            this.gbPedidos.Controls.Add(this.lblPreparacion);
            this.gbPedidos.Controls.Add(this.lblIngresados);
            this.gbPedidos.Location = new System.Drawing.Point(12, 12);
            this.gbPedidos.Name = "gbPedidos";
            this.gbPedidos.Size = new System.Drawing.Size(1172, 300);
            this.gbPedidos.TabIndex = 0;
            this.gbPedidos.TabStop = false;
            this.gbPedidos.Text = "Pedidos";
            // 
            // lbListos
            // 
            this.lbListos.FormattingEnabled = true;
            this.lbListos.Location = new System.Drawing.Point(798, 30);
            this.lbListos.Name = "lbListos";
            this.lbListos.Size = new System.Drawing.Size(352, 251);
            this.lbListos.TabIndex = 3;
            // 
            // lbEnPreparacion
            // 
            this.lbEnPreparacion.FormattingEnabled = true;
            this.lbEnPreparacion.Location = new System.Drawing.Point(408, 30);
            this.lbEnPreparacion.Name = "lbEnPreparacion";
            this.lbEnPreparacion.Size = new System.Drawing.Size(352, 251);
            this.lbEnPreparacion.TabIndex = 2;
            // 
            // lbIngresados
            // 
            this.lbIngresados.FormattingEnabled = true;
            this.lbIngresados.Location = new System.Drawing.Point(17, 32);
            this.lbIngresados.Name = "lbIngresados";
            this.lbIngresados.Size = new System.Drawing.Size(352, 251);
            this.lbIngresados.TabIndex = 1;
            // 
            // lblListos
            // 
            this.lblListos.AutoSize = true;
            this.lblListos.Location = new System.Drawing.Point(1116, 14);
            this.lblListos.Name = "lblListos";
            this.lblListos.Size = new System.Drawing.Size(34, 13);
            this.lblListos.TabIndex = 3;
            this.lblListos.Text = "Listos";
            // 
            // lblPreparacion
            // 
            this.lblPreparacion.AutoSize = true;
            this.lblPreparacion.Location = new System.Drawing.Point(680, 14);
            this.lblPreparacion.Name = "lblPreparacion";
            this.lblPreparacion.Size = new System.Drawing.Size(80, 13);
            this.lblPreparacion.TabIndex = 2;
            this.lblPreparacion.Text = "En Preparación";
            // 
            // lblIngresados
            // 
            this.lblIngresados.AutoSize = true;
            this.lblIngresados.Location = new System.Drawing.Point(310, 14);
            this.lblIngresados.Name = "lblIngresados";
            this.lblIngresados.Size = new System.Drawing.Size(59, 13);
            this.lblIngresados.TabIndex = 1;
            this.lblIngresados.Text = "Ingresados";
            // 
            // rtbPedidos
            // 
            this.rtbPedidos.Location = new System.Drawing.Point(12, 318);
            this.rtbPedidos.Name = "rtbPedidos";
            this.rtbPedidos.ReadOnly = true;
            this.rtbPedidos.Size = new System.Drawing.Size(558, 221);
            this.rtbPedidos.TabIndex = 1;
            this.rtbPedidos.Text = "";
            // 
            // btnMostrarPedidos
            // 
            this.btnMostrarPedidos.Location = new System.Drawing.Point(12, 545);
            this.btnMostrarPedidos.Name = "btnMostrarPedidos";
            this.btnMostrarPedidos.Size = new System.Drawing.Size(461, 55);
            this.btnMostrarPedidos.TabIndex = 2;
            this.btnMostrarPedidos.Text = "Actualizar Pedidos";
            this.btnMostrarPedidos.UseVisualStyleBackColor = true;
            this.btnMostrarPedidos.Click += new System.EventHandler(this.btnMostrarPedidos_Click);
            // 
            // gbNuevoPedido
            // 
            this.gbNuevoPedido.Controls.Add(this.lblDireccion);
            this.gbNuevoPedido.Controls.Add(this.lblPrecio);
            this.gbNuevoPedido.Controls.Add(this.lblComida);
            this.gbNuevoPedido.Controls.Add(this.txtPrecio);
            this.gbNuevoPedido.Controls.Add(this.txtComida);
            this.gbNuevoPedido.Controls.Add(this.dgvComidas);
            this.gbNuevoPedido.Controls.Add(this.btnAgregarPedido);
            this.gbNuevoPedido.Controls.Add(this.cbDelivery);
            this.gbNuevoPedido.Controls.Add(this.txtDireccion);
            this.gbNuevoPedido.Location = new System.Drawing.Point(576, 318);
            this.gbNuevoPedido.Name = "gbNuevoPedido";
            this.gbNuevoPedido.Size = new System.Drawing.Size(608, 282);
            this.gbNuevoPedido.TabIndex = 3;
            this.gbNuevoPedido.TabStop = false;
            this.gbNuevoPedido.Text = "Ingresar nuevo pedido";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(425, 93);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(161, 20);
            this.txtPrecio.TabIndex = 10;
            // 
            // txtComida
            // 
            this.txtComida.Location = new System.Drawing.Point(425, 50);
            this.txtComida.Name = "txtComida";
            this.txtComida.ReadOnly = true;
            this.txtComida.Size = new System.Drawing.Size(161, 20);
            this.txtComida.TabIndex = 9;
            // 
            // dgvComidas
            // 
            this.dgvComidas.AllowUserToAddRows = false;
            this.dgvComidas.AllowUserToDeleteRows = false;
            this.dgvComidas.AllowUserToResizeColumns = false;
            this.dgvComidas.AllowUserToResizeRows = false;
            this.dgvComidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvComidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvComidas.ColumnHeadersHeight = 24;
            this.dgvComidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvComidas.EnableHeadersVisualStyles = false;
            this.dgvComidas.Location = new System.Drawing.Point(9, 25);
            this.dgvComidas.Name = "dgvComidas";
            this.dgvComidas.ReadOnly = true;
            this.dgvComidas.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvComidas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvComidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComidas.Size = new System.Drawing.Size(347, 246);
            this.dgvComidas.TabIndex = 8;
            this.dgvComidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComidas_CellContentClick);
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.Location = new System.Drawing.Point(367, 203);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(219, 68);
            this.btnAgregarPedido.TabIndex = 4;
            this.btnAgregarPedido.Text = "Agregar Pedido";
            this.btnAgregarPedido.UseVisualStyleBackColor = true;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // cbDelivery
            // 
            this.cbDelivery.AutoSize = true;
            this.cbDelivery.Location = new System.Drawing.Point(425, 142);
            this.cbDelivery.Name = "cbDelivery";
            this.cbDelivery.Size = new System.Drawing.Size(64, 17);
            this.cbDelivery.TabIndex = 2;
            this.cbDelivery.Text = "Delivery";
            this.cbDelivery.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(425, 165);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(161, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // lblComida
            // 
            this.lblComida.AutoSize = true;
            this.lblComida.Location = new System.Drawing.Point(364, 53);
            this.lblComida.Name = "lblComida";
            this.lblComida.Size = new System.Drawing.Size(45, 13);
            this.lblComida.TabIndex = 4;
            this.lblComida.Text = "Comida:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(364, 96);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(16, 13);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "$ ";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(364, 168);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Dirección:";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(479, 545);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(91, 55);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar Preparación";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // Local
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 611);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.gbNuevoPedido);
            this.Controls.Add(this.btnMostrarPedidos);
            this.Controls.Add(this.rtbPedidos);
            this.Controls.Add(this.gbPedidos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Local";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Local_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Local_FormClosed);
            this.Load += new System.EventHandler(this.Local_Load);
            this.gbPedidos.ResumeLayout(false);
            this.gbPedidos.PerformLayout();
            this.gbNuevoPedido.ResumeLayout(false);
            this.gbNuevoPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPedidos;
        private System.Windows.Forms.Label lblPreparacion;
        private System.Windows.Forms.Label lblIngresados;
        private System.Windows.Forms.Label lblListos;
        private System.Windows.Forms.ListBox lbListos;
        private System.Windows.Forms.ListBox lbEnPreparacion;
        private System.Windows.Forms.ListBox lbIngresados;
        private System.Windows.Forms.RichTextBox rtbPedidos;
        private System.Windows.Forms.Button btnMostrarPedidos;
        private System.Windows.Forms.GroupBox gbNuevoPedido;
        private System.Windows.Forms.CheckBox cbDelivery;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.DataGridView dgvComidas;
        private System.Windows.Forms.TextBox txtComida;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblComida;
        private System.Windows.Forms.Button btnIniciar;
    }
}


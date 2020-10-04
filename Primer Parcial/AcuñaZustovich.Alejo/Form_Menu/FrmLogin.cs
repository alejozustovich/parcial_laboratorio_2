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
    public partial class FrmLogin : Form
    {
        #region ATRIBUTOS
        Dictionary<string, string> baseDeDatosUsuarios;
        string[] campos;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            baseDeDatosUsuarios = new Dictionary<string, string>();
            campos = new string[2];
        }
        #endregion

        #region LOAD
        /// <summary>
        /// Carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            baseDeDatosUsuarios.Add("apu", "apulin");
            baseDeDatosUsuarios.Add("sanjay", "elsanjito");
            campos[0] = string.Empty;
            campos[1] = string.Empty;
        }
        #endregion

        #region ACCEDER
        /// <summary>
        /// Si el usuario y la contraseña son correctos, accede al sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            campos[0] = this.txtUsuario.Text;
            campos[1] = this.txtContraseña.Text;

            if(Validacion.StringConDatos(campos))
            {
                if(baseDeDatosUsuarios.ContainsKey(campos[0]))
                {
                    baseDeDatosUsuarios.TryGetValue(campos[0], out string contraseña);

                    if(contraseña == campos[1])
                    {
                        this.Hide();
                        FrmMenu mainMenu = new FrmMenu();
                        mainMenu.Show();
                    }
                    else
                        MessageBox.Show("Contraseña incorrecta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Usuario incorrecto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Debe completar los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region SALIR
        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                this.Show();
            else
                Application.Exit();
        }
        #endregion

        #region CREAR USUARIO
        /// <summary>
        /// Crea el usuario con los campos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            campos[0] = this.txtUsuario.Text;
            campos[1] = this.txtContraseña.Text;

            if (Validacion.StringConDatos(campos))
            {
                if (!baseDeDatosUsuarios.ContainsKey(campos[0]))
                {
                    baseDeDatosUsuarios.Add(campos[0], campos[1]);
                    MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Usuario ya registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Debe completar los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region TEXT_LEAVE
        /// <summary>
        /// Alinea el usuario eliminando espacios en blanco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            this.txtUsuario.Text = this.txtUsuario.Text.Trim();
        }
        #endregion
    }
}
